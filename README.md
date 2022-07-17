# Libre Hardware Monitor Plugin for MSI Afterburner

This is a monitoring plugin for [MSI Afterburner](https://www.msi.com/Landing/afterburner) that exposes hardware monitoring data provided by [Libre Hardware Monitor](https://github.com/LibreHardwareMonitor/LibreHardwareMonitor) library.

You can use it to get motherboard temperatures, fan speeds, etc. that are not built-in to Afterburner and RTSS OSD without running external monitoring software.

## Requirements

* MSI Afterburner (version 4.6.4 used in development)
* .Net Framefork >= 4.8

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
