﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LibreHardwareMonitorAfterburnerPlugin
{
    internal class SensorSource
    {
        /// <summary>
        /// The access point to LibreHardwareMonitorLib
        /// </summary>
        private readonly Computer _computer = new Computer();
        
        /// <summary>
        /// References all used sensors
        /// </summary>
        private readonly List<ISensor> _sensors = new List<ISensor>();

        /// <summary>
        /// Keeps record of hardware update times
        /// </summary>
        private readonly Dictionary<IHardware, int> _lastUpdate = new Dictionary<IHardware, int>();

        public SensorSource()
        {
            InitializeGroups();

            _computer.Open();

            Initialize();
        }

        public void Reload()
        {
            _sensors.Clear();

            _lastUpdate.Clear();

            InitializeGroups();

            _computer.Reset();

            Initialize();
        }

        private void InitializeGroups()
        {
            // Hardware group filtering

            _computer.IsMotherboardEnabled = Properties.Settings.Default.MainboardEnabled;

            _computer.IsCpuEnabled = Properties.Settings.Default.CpuEnabled;

            _computer.IsMemoryEnabled = Properties.Settings.Default.RamEnabled;

            _computer.IsGpuEnabled = Properties.Settings.Default.GpuEnabled;

            _computer.IsControllerEnabled = Properties.Settings.Default.FanControllerEnabled;

            _computer.IsStorageEnabled = Properties.Settings.Default.HddEnabled;

            _computer.IsNetworkEnabled = Properties.Settings.Default.NetworkEnabled;

            _computer.IsBatteryEnabled = Properties.Settings.Default.BatteryEnabled;

            _computer.IsPsuEnabled = Properties.Settings.Default.PsuEnabled;
        }

        private void Initialize()
        {
            // Sensortype filtering

            HashSet<SensorType> enabledSensors = new HashSet<SensorType>();
            if (Properties.Settings.Default.TemperatureEnabled)
                enabledSensors.Add(SensorType.Temperature);

            if (Properties.Settings.Default.FanSpeedEnabled)
                enabledSensors.Add(SensorType.Fan);

            if (Properties.Settings.Default.ControlEnabled)
                enabledSensors.Add(SensorType.Control);

            if (Properties.Settings.Default.ClockEnabled)
                enabledSensors.Add(SensorType.Clock);

            if (Properties.Settings.Default.FactorEnabled)
                enabledSensors.Add(SensorType.Factor);

            if (Properties.Settings.Default.VoltageEnabled)
                enabledSensors.Add(SensorType.Voltage);

            if (Properties.Settings.Default.PowerEnabled)
                enabledSensors.Add(SensorType.Power);

            if (Properties.Settings.Default.LoadEnabled)
                enabledSensors.Add(SensorType.Load);

            if (Properties.Settings.Default.FlowEnabled)
                enabledSensors.Add(SensorType.Flow);

            if (Properties.Settings.Default.MiscEnabled)
            {
                enabledSensors.Add(SensorType.Level);
                enabledSensors.Add(SensorType.Data);
                enabledSensors.Add(SensorType.SmallData);
                enabledSensors.Add(SensorType.Throughput);

                enabledSensors.Add(SensorType.Current);
                enabledSensors.Add(SensorType.Energy);
                enabledSensors.Add(SensorType.Frequency);
            }

            // Update all found hardware to create sensors
            _computer.Accept(new HardwareUpdateVisitor());

            // Collect found sensors to a list to be referenced by index.
            // While index is used in the plugin interface, Afterburner uses
            // the name to distinguish sources and store their settings.
            _computer.Accept(new SensorVisitor(sensor =>
            {
                if (enabledSensors.Contains(sensor.SensorType))
                    _sensors.Add(sensor);
            }));

            // Find duplicated names
            var duplicates = _sensors
                .GroupBy(sensor => sensor.Name)
                .Where(group => group.Count() > 1);

            // Append index number to each duplicated name (#2,#3,...)
            foreach (var group in duplicates.Select(g => g.Skip(1)))
            {
                int index = 2;
                foreach (var sensor in group)
                    sensor.Name += $" #{index++}";
            }
        }

        public int SensorCount => _sensors.Count;

        public float SensorValue(int index)
        {
            var sensor = _sensors.ElementAtOrDefault(index);

            if (sensor == null)
                return 0f;

            // Update sensors hardware if last update was over 100ms ago.
            // This most likely results in one update per hardware in a polling cycle as long as polling interval is greater.
            if (!_lastUpdate.TryGetValue(sensor.Hardware, out int last) || (Environment.TickCount - last) > 100)
            {
                sensor.Hardware.Update();

                _lastUpdate[sensor.Hardware] = Environment.TickCount;
            }

            return sensor.Value ?? 0f;
        }

        public void FillDescription(int index, ref MonitoringSourceDesc desc)
        {
            var sensor = _sensors.ElementAtOrDefault(index);

            if (sensor == null)
                return;

            desc.szName = sensor.Name;

            desc.szUnits = GetSensorUnit(sensor.SensorType);

            desc.szGroup = "LibreHardwareMonitor";

            desc.dwID = GetSensorPluginID(sensor.Hardware.HardwareType);

            desc.dwInstance = 0;

            desc.fltMinLimit = 0f;

            desc.fltMaxLimit = GetSensorMaxLimit(sensor.SensorType);

            desc.szFormat = GetSensorFormat(sensor.SensorType);
        }

        private static string GetSensorUnit(SensorType type)
        {
            switch (type)
            {
                case SensorType.Voltage: return "V";
                case SensorType.Current: return "A";
                case SensorType.Power: return "W";
                case SensorType.Clock: return "MHz";
                case SensorType.Temperature: return "°C";
                case SensorType.Load: return "%";
                case SensorType.Frequency: return "Hz";
                case SensorType.Fan: return "RPM";
                case SensorType.Flow: return "L/h";
                case SensorType.Control: return "%";
                case SensorType.Level: return "%";
                case SensorType.Factor: return "1";
                case SensorType.Data: return "GB";
                case SensorType.SmallData: return "MB";
                case SensorType.Throughput: return "MB/s";
                case SensorType.Energy: return "mWh";
                default: return "";
            }
        }

        private static uint GetSensorPluginID(HardwareType type)
        {
            switch (type)
            {
                case HardwareType.Motherboard:
                case HardwareType.SuperIO:
                    return 0x000000F2; //MONITORING_SOURCE_ID_PLUGIN_MOBO
                case HardwareType.Cpu:
                    return 0x000000F1; //MONITORING_SOURCE_ID_PLUGIN_CPU
                case HardwareType.Memory:
                    return 0x000000F3; //MONITORING_SOURCE_ID_PLUGIN_RAM
                case HardwareType.GpuNvidia:
                case HardwareType.GpuAmd:
                case HardwareType.GpuIntel:
                    return 0x000000F0; //MONITORING_SOURCE_ID_PLUGIN_GPU
                case HardwareType.Storage:
                    return 0x000000F4; //MONITORING_SOURCE_ID_PLUGIN_HDD
                case HardwareType.Network:
                    return 0x000000F5; //MONITORING_SOURCE_ID_PLUGIN_NET
                default:
                    return 0x000000FF; //MONITORING_SOURCE_ID_PLUGIN_MISC
            }
        }

        private static float GetSensorMaxLimit(SensorType type)
        {
            switch (type)
            {
                case SensorType.Voltage: return 5f;
                case SensorType.Power: return 1000f;
                case SensorType.Clock: return 6000f;
                case SensorType.Temperature: return 100f;
                case SensorType.Load: return 100f;
                case SensorType.Frequency: return 1000f;
                case SensorType.Fan: return 3000f;
                case SensorType.Flow: return 1500f;
                case SensorType.Control: return 100f;
                case SensorType.Level: return 100f;
                case SensorType.Factor: return 10f;
                case SensorType.Data: return 1000f;
                case SensorType.SmallData: return 1000f;
                case SensorType.Throughput: return 1000f;
                default: return 100f;
            }
        }

        private static string GetSensorFormat(SensorType type)
        {
            switch (type)
            {
                case SensorType.Voltage:
                case SensorType.Factor:
                    return "%.3f";
                case SensorType.Frequency:
                case SensorType.Fan:
                case SensorType.Control:
                case SensorType.Energy:
                    return "%.0f";
                default:
                    return "%.1f";
            }
        }
    }
}
