using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreHardwareMonitorAfterburnerPlugin
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();           

            info.Text = info.Text.Replace("{{ver}}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        private void License_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://mozilla.org/MPL/2.0/");
        }

        private void ProjectLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/ts-korhonen/LibreHardwareMonitorAfterburnerPlugin");
        }

        private void LibraryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/LibreHardwareMonitor/LibreHardwareMonitor");
        }
    }
}
