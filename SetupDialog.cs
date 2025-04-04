using System.Reflection;

namespace LibreHardwareMonitorAfterburnerPlugin;

public partial class SetupDialog : Form
{
    public SetupDialog(HardwareFlags hardwareFlags, SensorFlags sensorFlags)
    {
        InitializeComponent();

        using var iconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), "icon.ico");

        this.Icon = new Icon(iconStream);

        hardwareFlagsSource.DataSource = hardwareFlags;

        sensorFlagsSource.DataSource = sensorFlags;
    }

    private void About_Click(object sender, EventArgs e) => new AboutDialog().ShowDialog();
}
