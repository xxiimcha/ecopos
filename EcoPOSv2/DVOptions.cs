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
    public partial class DVOptions : Form
    {
        public DVOptions()
        {
            InitializeComponent();
        }
        private void DVOptions_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.dbName == "EcoPOS")
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
            else if (Properties.Settings.Default.dbName == "EcoPOS_Training")
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
        }

        private void btnChangeStoreSettings_Click(object sender, EventArgs e)
        {
            EditSD frmEditSD = new EditSD();
            frmEditSD.ShowDialog();
        }

        private void btnImportDatabase_Click(object sender, EventArgs e)
        {
            ImportDatabase frmImportDatabase = new ImportDatabase();
            frmImportDatabase.ShowDialog();
        }

        private void btnShowMainForm_Click(object sender, EventArgs e)
        {
            Main.Instance.Show();

            Prompt.Instance.Close();
            Login.Instance.Close();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbName = "EcoPOS_Training";
            Properties.Settings.Default.Save();

            MessageBox.Show("Traning mode started.. Application will restart.", "Restarting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
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
