/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace LibreHardwareMonitorAfterburnerPlugin;

/// <summary>
/// Native DLL Exports
/// Implementing plugin interface according to SDK samples included with MSI Afterburner 4.6.3
/// </summary>
public static class Exports
{
    /// <summary>
    ///     The directory where the plugin dll is located.
    /// </summary>
    private static readonly string plugin_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    /// <summary>
    ///     Settings file location
    /// </summary>
    private static readonly string settings_path = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        nameof(LibreHardwareMonitorAfterburnerPlugin),
#if DEBUG
        "settings.debug.json");
#else
        "settings.json");
#endif

    private static readonly Settings settings;

    private static readonly Lazy<SensorSource> source;

    /// <summary>
    ///     Initialize the plugin.
    /// </summary>
    /// <remarks>
    ///     While the exported methods are technically the entry points,
    ///     static constructor is called before they are entered.
    /// </remarks>
    static Exports()
    {
        AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolver;

        settings = Settings.Load(settings_path);

        source = new(() => new SensorSource(settings));
    }

    /// <summary>
    ///     This is called to query if sources have settings, and to show setup dialog.
    /// </summary>
    /// <remarks>
    ///     Since we don't have any individual source settings, we only show the plugin settings dialog.
    /// </remarks>
    /// <param name="dwIndex">Index of a source</param>
    /// <param name="hWnd">parent window's handle or NULL</param>
    /// <returns></returns>
    [DllExport]
    public static bool SetupSource(uint dwIndex, IntPtr hWnd) => CatchAndLog(() =>
    {
        // The call was just a query
        if (hWnd == IntPtr.Zero)
            return dwIndex == 0xFFFFFFFF; // Only true for the plugin setup

        // The call was to show the setup dialog

        // Clone for dialog to preserve original settings
        var hardwareFlags = settings.HardwareFlags.Clone();
        var sensorFlags = settings.SensorFlags.Clone();

        var dlg = new SetupDialog(hardwareFlags, sensorFlags, GetPawnIOVersion());

        if (dlg.ShowDialog() != DialogResult.OK)
            return false;

        // Replace with modified settings
        settings.HardwareFlags = hardwareFlags;
        settings.SensorFlags = sensorFlags;

        settings.Save(settings_path);

        // Reload new settings if SensorSource already exists
        if (source.IsValueCreated)
            source.Value.Reload(settings);

        return true;
    });

    /// <summary>
    ///     Retrieves the data source count.
    /// </summary>
    /// <returns>Source count</returns>
    [DllExport]
    public static uint GetSourcesNum() => CatchAndLog(() => (uint)source.Value.SensorCount);

    /// <summary>
    ///     Get descriptor for a data source.
    /// </summary>
    /// <param name="dwIndex">data source index</param>
    /// <param name="pDesc">filled descriptor</param>
    /// <returns>if sensor existed at the index</returns>
    [DllExport]
    public static bool GetSourceDesc(uint dwIndex, [In, Out] MonitoringSourceDesc pDesc) => CatchAndLog(() => source.Value.FillDescription((int)dwIndex, pDesc));

    /// <summary>
    ///     Get the value of a data source.
    /// </summary>
    /// <param name="dwIndex">data source index</param>
    /// <returns>sensor value</returns>
    [DllExport]
    public static float GetSourceData(uint dwIndex) => CatchAndLog(() => source.Value.SensorValue((int)dwIndex));

    /// <summary>
    ///     Loads an assembly from the plugin directory or from the embedded resources.
    /// </summary>
    /// <remarks>
    ///     The event is called when assembly is not found. This means that the host process (MSI Afterburner)
    ///     executable directory has precedence over this. If assembly is found there, it will be loaded, and
    ///     this event will not fire.
    ///
    ///     While the intended flow is to load the embedded resources, this allows to override LibreHardwareMonitor.lib
    ///     with a custom version by placing it in the same directory as the plugin dll.
    /// </remarks>
    /// <param name="obj"></param>
    /// <param name="args"></param>
    /// <returns>requested assembly</returns>
    private static Assembly? AssemblyResolver(object obj, ResolveEventArgs args)
    {
        try
        {
            var localAssembly = Path.Combine(plugin_path, args.Name.Split(',')[0]) + ".dll";

            if (File.Exists(localAssembly))
            {
                // Assembly was found in the plugin directory.
                return Assembly.LoadFrom(localAssembly);
            }
        }
        catch (Exception e)
        {
            Log(e);
        }

        try
        {
            var resourceName = $"{nameof(LibreHardwareMonitorAfterburnerPlugin)}.{new AssemblyName(args.Name).Name}.dll";

            using var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);

            if (resourceStream is not null)
            {
                // Assembly was found in the embedded resources.

                using var assemblyStream = new MemoryStream();

                using var deflateStream = new DeflateStream(resourceStream, CompressionMode.Decompress);

                deflateStream.CopyTo(assemblyStream);

                return Assembly.Load(assemblyStream.ToArray());
            }
        }
        catch (Exception e)
        {
            Log(e);
        }

        Log($"Couldn't resolve `{args.Name}` for `{args.RequestingAssembly}`");

        return null;
    }

    /// <summary>
    ///     Wrapper to catch exceptions and log them.
    /// </summary>
    /// <typeparam name="TReturn">wrapped method return type</typeparam>
    /// <param name="proc">wrapped method</param>
    /// <param name="returnValueOnError">value to return in exception situation</param>
    /// <returns></returns>
    private static TReturn CatchAndLog<TReturn>(Func<TReturn> proc, TReturn returnValueOnError = default) where TReturn : struct
    {
        try
        {
            return proc();
        }
        catch(Exception e)
        {
            Log(e);
        }

        return returnValueOnError;
    }

    /// <summary>
    ///     Simple file logger.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    private static void Log<T>(T message)
    {
        try
        {
            File.AppendAllText(Assembly.GetExecutingAssembly().Location + ".log", $"{DateTime.UtcNow:s}: {message}{Environment.NewLine}");
        }
        catch { /* Ignore; Let's not crash the host process. */ }
    }

    private static string? GetPawnIOVersion()
    {
        try
        {
            using var hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            using var key = hive.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\PawnIO");

            if (key is not null && key.GetValue("DisplayVersion") is string version)
                return version;
        }
        catch (Exception e)
        {
            Log(e);
        }

        return null;
    }
}
