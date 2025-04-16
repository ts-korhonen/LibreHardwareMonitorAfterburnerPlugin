using System.Diagnostics;
using System.Reflection;

namespace LibreHardwareMonitorAfterburnerPlugin;

public partial class AboutDialog : Form
{
    public AboutDialog()
    {
        InitializeComponent();

        using var iconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), "icon.ico");

        var icon = new Icon(iconStream);

        this.Icon = icon;

        this.pictureBox1.Image = new Icon(icon, new Size(48, 48)).ToBitmap();

        info.Text = info.Text.Replace(
            "{{ver}}",
            Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion
                .Split('+')[0]
        );
    }

    private void License_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://mozilla.org/MPL/2.0/");

    private void ProjectLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://github.com/ts-korhonen/LibreHardwareMonitorAfterburnerPlugin");

    private void LibraryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://github.com/LibreHardwareMonitor/LibreHardwareMonitor");
}
