/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibreHardwareMonitorAfterburnerPlugin
{
    /// <summary>
    /// Native DLL Exports
    /// Implementing plugin interface according to SDK samples included with MSI Afterburner 4.6.3
    /// </summary>
    public class Exports
    {
        private static readonly Lazy<SensorSource> _source = new Lazy<SensorSource>(System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        [DllExport]
        public static bool SetupSource(uint dwIndex, IntPtr hWnd)
        {
            try
            {
                if (hWnd != IntPtr.Zero)
                {
                    var settingsChanged = false;

                    // see if settings are changed during dialog
                    void changeWatcher(object sender, PropertyChangedEventArgs e) => settingsChanged = true;

                    Properties.Settings.Default.PropertyChanged += changeWatcher;

                    var dlg = new SetupDialog();

                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (settingsChanged)
                        {
                            Properties.Settings.Default.Save();

                            // Reload new settings if SensorSource already exists
                            if (_source.IsValueCreated)
                                _source.Value.Reload();
                        }

                        Properties.Settings.Default.PropertyChanged -= changeWatcher;

                        return true;
                    }

                    Properties.Settings.Default.PropertyChanged -= changeWatcher;

                    // Setup was cancelled, reload old settings.
                    Properties.Settings.Default.Reload();

                    return false;
                }

                // only plugin settings, no individual source settings
                return dwIndex == 0xFFFFFFFF;
            }
            catch (Exception e)
            {
                try
                {
                    Properties.Settings.Default.Reload();

                    File.AppendAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + ".log", $"{DateTime.Now:s}: {e}\r\n");
                }
                catch { }

                return false;
            }
        }

        [DllExport]
        public static uint GetSourcesNum()
        {
            try
            {
                return (uint)_source.Value.SensorCount;
            }
            catch (Exception e)
            {
                try
                {
                    File.AppendAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + ".log", $"{DateTime.Now:s}: {e}\r\n");
                }
                catch { }

                return 0u;
            }
        }

        [DllExport]
        public static bool GetSourceDesc(uint dwIndex, ref MonitoringSourceDesc pDesc)
        {
            try
            {
                _source.Value.FillDescription((int)dwIndex, ref pDesc);

                return true;
            }
            catch (Exception e)
            {
                try
                {
                    File.AppendAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + ".log", $"{DateTime.Now:s}: {e}\r\n");
                }
                catch { }

                return false;
            }
        }

        [DllExport]
        public static float GetSourceData(uint dwIndex)
        {
            try
            {
                return _source.Value.SensorValue((int)dwIndex);
            }
            catch (Exception e)
            {
                try
                {
                    File.AppendAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + ".log", $"{DateTime.Now:s}: {e}\r\n");
                }
                catch { }

                return 0f;
            }
        }
    }
}
