using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreHardwareMonitorAfterburnerPlugin
{
    public partial class SetupDialog : Form
    {
        public SetupDialog()
        {
            InitializeComponent();
        }

        private void About_Click(object sender, EventArgs e)
        {
            new AboutDialog().ShowDialog();
        }
    }
}
