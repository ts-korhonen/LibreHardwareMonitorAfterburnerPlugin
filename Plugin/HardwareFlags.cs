/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

namespace LibreHardwareMonitorAfterburnerPlugin;

public class HardwareFlags
{
    public bool MainboardEnabled { get; set; }
    public bool CpuEnabled { get; set; }
    public bool RamEnabled { get; set; }
    public bool GpuEnabled { get; set; }
    public bool FanControllerEnabled { get; set; }
    public bool HddEnabled { get; set; }
    public bool NetworkEnabled { get; set; }
    public bool BatteryEnabled { get; set; }
    public bool PsuEnabled { get; set; }

    public HardwareFlags Clone() => (HardwareFlags)MemberwiseClone();
}
