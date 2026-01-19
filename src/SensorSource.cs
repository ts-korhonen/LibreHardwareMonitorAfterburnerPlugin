/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using LibreHardwareMonitor.Hardware;

namespace LibreHardwareMonitorAfterburnerPlugin;

internal class SensorSource
{
    /// <summary>
    /// The access point to LibreHardwareMonitorLib
    /// </summary>
    private readonly Computer _computer = new();
    
    /// <summary>
    /// References all used sensors
    /// </summary>
    private readonly List<ISensor> _sensors = [];

    /// <summary>
    /// Keeps record of hardware update times
    /// </summary>
    private readonly Dictionary<IHardware, int> _lastUpdate = [];

    private readonly object _lock = new();

    public SensorSource(Settings settings)
    {
        InitializeGroups(settings.HardwareFlags);

        _computer.Open();

        Initialize(settings.SensorFlags);
    }

    public void Reload(Settings settings)
    {
        lock (_lock)
        {

            _sensors.Clear();

            _lastUpdate.Clear();

            InitializeGroups(settings.HardwareFlags);

            _computer.Reset();

            Initialize(settings.SensorFlags);
        }
    }

    private void InitializeGroups(HardwareFlags hwFlags)
    {
        // Hardware group filtering

        _computer.IsMotherboardEnabled = hwFlags.MainboardEnabled;

        _computer.IsCpuEnabled = hwFlags.CpuEnabled;

        _computer.IsMemoryEnabled = hwFlags.RamEnabled;

        _computer.IsGpuEnabled = hwFlags.GpuEnabled;

        _computer.IsControllerEnabled = hwFlags.FanControllerEnabled;

        _computer.IsStorageEnabled = hwFlags.HddEnabled;

        _computer.IsNetworkEnabled = hwFlags.NetworkEnabled;

        _computer.IsBatteryEnabled = hwFlags.BatteryEnabled;

        _computer.IsPsuEnabled = hwFlags.PsuEnabled;
    }

    private void Initialize(SensorFlags sensorFlags)
    {
        // Sensor type filtering

        HashSet<SensorType> enabledSensors = [];

        if (sensorFlags.TemperatureEnabled)
            enabledSensors.Add(SensorType.Temperature);

        if (sensorFlags.FanSpeedEnabled)
            enabledSensors.Add(SensorType.Fan);

        if (sensorFlags.ControlEnabled)
            enabledSensors.Add(SensorType.Control);

        if (sensorFlags.ClockEnabled)
            enabledSensors.Add(SensorType.Clock);

        if (sensorFlags.FactorEnabled)
            enabledSensors.Add(SensorType.Factor);

        if (sensorFlags.VoltageEnabled)
            enabledSensors.Add(SensorType.Voltage);

        if (sensorFlags.PowerEnabled)
            enabledSensors.Add(SensorType.Power);

        if (sensorFlags.LoadEnabled)
            enabledSensors.Add(SensorType.Load);

        if (sensorFlags.FlowEnabled)
            enabledSensors.Add(SensorType.Flow);

        if (sensorFlags.MiscEnabled)
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

    public bool FillDescription(int index, MonitoringSourceDesc desc)
    {
        var sensor = _sensors.ElementAtOrDefault(index);

        if (sensor == null)
            return false;

        desc.szName = sensor.Name;

        desc.szUnits = GetSensorUnit(sensor.SensorType);

        desc.szGroup = "LibreHardwareMonitor";

        desc.dwID = GetSensorPluginID(sensor.Hardware.HardwareType);

        desc.dwInstance = 0;

        desc.fltMinLimit = 0f;

        desc.fltMaxLimit = GetSensorMaxLimit(sensor.SensorType);

        desc.szFormat = GetSensorFormat(sensor.SensorType);

        return true;
    }

    private static string GetSensorUnit(SensorType type) => type switch
    {
        SensorType.Voltage => "V",
        SensorType.Current => "A",
        SensorType.Power => "W",
        SensorType.Clock => "MHz",
        SensorType.Temperature => "°C",
        SensorType.Load => "%",
        SensorType.Frequency => "Hz",
        SensorType.Fan => "RPM",
        SensorType.Flow => "L/h",
        SensorType.Control => "%",
        SensorType.Level => "%",
        SensorType.Factor => "1",
        SensorType.Data => "GB",
        SensorType.SmallData => "MB",
        SensorType.Throughput => "MB/s",
        SensorType.Energy => "mWh",
        _ => "",
    };

    private static uint GetSensorPluginID(HardwareType type) => type switch
    {
        HardwareType.Motherboard or HardwareType.SuperIO => 0x000000F2,     //MONITORING_SOURCE_ID_PLUGIN_MOBO
        HardwareType.Cpu => 0x000000F1,     //MONITORING_SOURCE_ID_PLUGIN_CPU
        HardwareType.Memory => 0x000000F3,     //MONITORING_SOURCE_ID_PLUGIN_RAM
        HardwareType.GpuNvidia
            or HardwareType.GpuAmd
            or HardwareType.GpuIntel => 0x000000F0,     //MONITORING_SOURCE_ID_PLUGIN_GPU
        HardwareType.Storage => 0x000000F4,     //MONITORING_SOURCE_ID_PLUGIN_HDD
        HardwareType.Network => 0x000000F5,     //MONITORING_SOURCE_ID_PLUGIN_NET
        _ => 0x000000FF,     //MONITORING_SOURCE_ID_PLUGIN_MISC
    };

    private static float GetSensorMaxLimit(SensorType type) => type switch
    {
        SensorType.Voltage => 5f,
        SensorType.Power => 1000f,
        SensorType.Clock => 6000f,
        SensorType.Temperature => 100f,
        SensorType.Load => 100f,
        SensorType.Frequency => 1000f,
        SensorType.Fan => 3000f,
        SensorType.Flow => 1500f,
        SensorType.Control => 100f,
        SensorType.Level => 100f,
        SensorType.Factor => 10f,
        SensorType.Data => 1000f,
        SensorType.SmallData => 1000f,
        SensorType.Throughput => 1000f,
        _ => 100f,
    };

    private static string GetSensorFormat(SensorType type) => type switch
    {
        SensorType.Voltage
            or SensorType.Factor => "%.3f",
        SensorType.Frequency
            or SensorType.Fan
            or SensorType.Control
            or SensorType.Energy => "%.0f",
        _ => "%.1f",
    };
}
