using EcoPOSv2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class TrainingMode : Form
    {
        public TrainingMode()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbName = "EcoPOS_Training";
            Properties.Settings.Default.Save();

            MessageBox.Show("Traning mode started.. Application will restart.", "Restarting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();

            //Main.Instance.dynamicDB = "EcoPOS_Training";
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbName = "EcoPOS";
            Properties.Settings.Default.Save();

            MessageBox.Show("Traning mode has been stopped. Application will restart.", "Restarting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }
    }
}
