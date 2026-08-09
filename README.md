# Libre Hardware Monitor Plugin for MSI Afterburner

This is a monitoring plugin for [MSI Afterburner](https://www.msi.com/Landing/afterburner) that exposes hardware monitoring data provided by [Libre Hardware Monitor](https://github.com/LibreHardwareMonitor/LibreHardwareMonitor) library.

You can use it to get motherboard temperatures, fan speeds, etc. that are not built-in to Afterburner and RTSS OSD without running external monitoring software.

## RTX 50 (Blackwell) Hot Spot support

NVIDIA does not expose the Hot Spot temperature of GeForce RTX 50 GPUs through the
public NVAPI. When an RTX 50 GPU and the [PawnIO](https://pawnio.eu/) kernel driver
are present, and the `GPUs` hardware group with the `Temperature` sensor type are
enabled in the plugin setup, the plugin reads the hidden thermal channels directly
from the GPU THERM block (BAR0 + 0xAD0A90) through the official PawnIO Nvidia module,
and adds these sensors under the `LibreHardwareMonitor` group:

* `GPU Hot Spot` - the maximum of the six thermal channels (the Hot Spot temperature,
  the same value reported by HWMonitor 1.65.1 and later)
* `GPU Hot Spot Channel #1..#6` - the six raw thermal channels

This is unofficial, reverse engineered functionality. NVIDIA provides no guarantee for
these values and future drivers may change or block the register access.

## Requirements

* [MSI Afterburner](https://www.msi.com/Landing/afterburner) (version 4.6.6 used in development)
* .Net Framework >= 4.8
* [PawnIO universal kernel driver](https://pawnio.eu/) (technically optional, but required for many sensors, including the RTX 50 Hot Spot sensors)
  * Note: the latest version 2.1.0.0 isn't compatible with releases prior to v0.8.0
  * Use the latest PawnIO driver version; the NVIDIA thermal module requires a recent one

## Installing

Download latest release of `LibreHardwareMonitor.dll` [here](https://github.com/ts-korhonen/LibreHardwareMonitorAfterburnerPlugin/releases) and place in into `Plugins/Monitoring` of MSI Afterburner installation folder.

E.g. `C:\Program Files (x86)\MSI Afterburner\Plugins\Monitoring`

Plugin is standalone, it doesn't need Libre Hardware Monitor to be installed or running.

## Setup

Start MSI Afterburner and go to `Settings > Monitoring` and click `[...]` button next to `Active hardware monitoring graphs`.

In the list of `Active plugin modules` select and activate the checkmark next to `LibreHardwareMonitor.dll`.

Click `Setup` to open plugin setup dialog where you can select which hardware and sensor types you want to monitor.

Afterburner should now be populated with discovered sensors.

## Uninstalling

Exit MSI Afterburner and delete `LibreHardwareMonitor.dll` you installed earlier.

In the same folder delete `LibreHardwareMonitor.sys` and `LibreHardwareMonitor.dll.log` if they exist.

## License

The plugin source code is licensed under [Mozilla Public License 2.0](https://mozilla.org/MPL/2.0/)

The bundled `Resources/Nvidia.bin` thermal module is part of the PawnIO module set
(https://github.com/namazso/PawnIO.Modules) and is licensed under LGPL-2.1-or-later,
see `Resources/PawnIO-COPYING.txt`.
