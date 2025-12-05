using System.Diagnostics;
﻿using System.Reflection;

namespace LibreHardwareMonitorAfterburnerPlugin;

public partial class SetupDialog : Form
{
    public SetupDialog(HardwareFlags hardwareFlags, SensorFlags sensorFlags, string? pawnIoVersion)
    {
        InitializeComponent();

        using var iconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), "icon.ico");

        this.Icon = new Icon(iconStream);

        hardwareFlagsSource.DataSource = hardwareFlags;

        sensorFlagsSource.DataSource = sensorFlags;

        if (pawnIoVersion != null)
        {
            pawnIoStatus.Text = $"PawnIO Version: {pawnIoVersion}";
            pawnIoStatus.ForeColor = Color.DarkGreen;
            pawnIoStatus.LinkArea = new LinkArea(0, 0);
        }
        else
        {
            pawnIoStatus.Text = "PawnIO universal driver not detected! Most sensor data requires PawnIO, go to https://pawnio.eu for download.";
            pawnIoStatus.ForeColor = Color.Red;

            var url = "https://pawnio.eu";
            var start = pawnIoStatus.Text.IndexOf(url);
            if (start != -1)
            {
                pawnIoStatus.LinkArea = new LinkArea(start, url.Length);
            }
        }

        pawnIoStatus.LinkClicked += (s, e) =>
        {
            try
            {
                Process.Start("https://pawnio.eu");
            }
            catch { }
        };
    }

    private void About_Click(object sender, EventArgs e) => new AboutDialog().ShowDialog();
}
