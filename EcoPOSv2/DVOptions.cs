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
    }
}
