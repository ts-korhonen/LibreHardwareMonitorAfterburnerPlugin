/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

namespace LibreHardwareMonitorAfterburnerPlugin;

public class SensorFlags
{
    public bool TemperatureEnabled { get; set; }
    public bool FanSpeedEnabled { get; set; }
    public bool ControlEnabled { get; set; }
    public bool ClockEnabled { get; set; }
    public bool FactorEnabled { get; set; }
    public bool VoltageEnabled { get; set; }
    public bool PowerEnabled { get; set; }
    public bool LoadEnabled { get; set; }
    public bool FlowEnabled { get; set; }
    public bool MiscEnabled { get; set; }

    public SensorFlags Clone() => (SensorFlags)MemberwiseClone();
}
