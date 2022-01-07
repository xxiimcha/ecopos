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
    public partial class CloudConfiguration : Form
    {
        public CloudConfiguration()
        {
            InitializeComponent();
        }

        private void TbServerName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CloudServerName = tbServerName.Text;
            Properties.Settings.Default.Save();
        }

        private void TbDBName1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CloudEcoPOS = tbDBName1.Text;
            Properties.Settings.Default.Save();
        }

        private void TbDBName2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CloudEcoPOS_Training = tbDBName2.Text;
            Properties.Settings.Default.Save();
        }

        private void CloudConfiguration_Load(object sender, EventArgs e)
        {
            tbServerName.Text = Properties.Settings.Default.CloudServerName;
            tbDBName1.Text = Properties.Settings.Default.CloudEcoPOS;
            tbDBName2.Text = Properties.Settings.Default.CloudEcoPOS_Training;
        }

        private void BtnSyncFromServer_Click(object sender, EventArgs e)
        {
            rtbStatus.Clear();
        }
    }
}
