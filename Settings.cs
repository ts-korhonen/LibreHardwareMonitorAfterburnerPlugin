/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;

namespace LibreHardwareMonitorAfterburnerPlugin;

/// <summary>
///     Plugin settings
/// </summary>
public class Settings
{
    /// <summary>
    ///     Version number can be used if there's breaking changes in the future.
    /// </summary>
    public int Version { get; set; } = 1;

    /// <summary>
    ///     Enabled hardware.
    /// </summary>
    public HardwareFlags HardwareFlags { get; set; }

    /// <summary>
    ///     Enabled sensor groups.
    /// </summary>
    public SensorFlags SensorFlags { get; set; }

    /// <summary>
    ///     Default constructor for empty settings.
    /// </summary>
    public Settings()
    {
        HardwareFlags = new();
        SensorFlags = new();
    }

    /// <summary>
    ///    Load settings from json file.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static Settings Load(string path)
    {
        if (!File.Exists(path))
        {
            var settings = ImportFromXml() ?? new();
            settings.Save(path);
            return settings;
        }

        var serializer = new DataContractJsonSerializer(typeof(Settings));

        using var file = File.OpenRead(path);

        return (Settings)serializer.ReadObject(file);
    }

    /// <summary>
    ///    Save settings to json file.
    /// </summary>
    /// <param name="path"></param>
    public void Save(string path)
    {
        var directory = Path.GetDirectoryName(path);

        if (directory is not { Length: 0 })
            Directory.CreateDirectory(directory);

        using var file = File.Open(path, FileMode.Create);

        using var writer = JsonReaderWriterFactory.CreateJsonWriter(file, Encoding.UTF8, true, true);

        var serializer = new DataContractJsonSerializer(typeof(Settings));

        serializer.WriteObject(writer, this);
    }

    /// <summary>
    ///     Attempt to import settings from old version.
    /// </summary>
    /// <returns>imported settings or null</returns>
    private static Settings? ImportFromXml()
    {
        // Old settings was stored with the host application path
        var root = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MSIAfterburner"
        );

        // Find all user.config files, sort by Afterburner version to try the latest first
        var files = Directory.EnumerateFiles(root, "user.config", SearchOption.AllDirectories)
            .OrderByDescending(x => Path.GetDirectoryName(x)?
                .Split(Path.DirectorySeparatorChar)[^1]
                .Replace(",_", "."));

        foreach (var file in files)
        {
            XElement xml;
            try
            {
                xml = XElement.Load(file);
            }
            catch
            {
                // Skip files that can't be loaded as XML
                continue;
            }

            // If the file is our settings file, it should have corresponding element
            var settings = xml
                .Descendants("LibreHardwareMonitorAfterburnerPlugin.Properties.Settings")
                .FirstOrDefault()?
                .Elements("setting")
                .Select(x =>
                (
                    x.Attribute("name")?.Value ?? "",
                    bool.TryParse(x.Element("value")?.Value, out bool value) && value
                ));

            // If the structure doesn't match, skip this file
            if (settings is null)
                continue;

            var mySettings = new Settings();
            var lookup = new Dictionary<string, Action<bool>>();

            // Use reflection to set values as the names are same

            foreach (var hardware in typeof(HardwareFlags).GetProperties())
                lookup.Add(hardware.Name, v => hardware.SetValue(mySettings.HardwareFlags, v));

            foreach (var sensor in typeof(SensorFlags).GetProperties())
                lookup.Add(sensor.Name, v => sensor.SetValue(mySettings.SensorFlags, v));

            foreach (var (name, value) in settings)
                if (lookup.TryGetValue(name, out var action))
                    action(value);

            return mySettings;
        }

        return null;
    }
}