using EcoPOSControl;
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
    public partial class Settings : Form
    {
        private Panel currentPanel;
        private Button currentBtn;
        private FormLoad OL = new FormLoad();
        public Form currentChildForm;


        public Settings()
        {
            InitializeComponent();
        }

        private void BtnStore_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new Store(), ref currentChildForm, btnStore, ref currentBtn, ref pnlChild);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.servertype == true)
            {
                btnDatabaseManagement.Enabled = true;
                btnDatabaseManagement.Visible = true;
            }
            else
            {
                btnDatabaseManagement.Enabled = false;
                btnDatabaseManagement.Visible = false;
            }

            currentBtn = btnStore;
            OL.changeFormWithButton(new Store(), ref currentChildForm, btnStore, ref currentBtn, ref pnlChild);
        }

        private void BtnStaff_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new Staff(), ref currentChildForm, btnStore, ref currentBtn, ref pnlChild);
        }

        private void BtnDeveloper_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new Developer(), ref currentChildForm, btnStore, ref currentBtn, ref pnlChild);
        }

        private void btnDatabackup_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new DatabaseManagement(), ref currentChildForm, btnDatabaseManagement, ref currentBtn, ref pnlChild);
            //SQLControl sql = new SQLControl();
            //string dbname = "EcoPOS";

            //if(Properties.Settings.Default.dbName == "EcoPOS")
            //{
            //    dbname = "EcoPOS";
            //}
            //else
            //{
            //    dbname = "EcoPOS_Training";
            //}

            //string path = "";

            //FolderBrowserDialog fbd = new FolderBrowserDialog();

            //if (fbd.ShowDialog() == DialogResult.OK)
            //{
            //    path = fbd.SelectedPath;
            //    sql.Query("BACKUP DATABASE [" + dbname + "] TO DISK='" + path.ToString() + "\\" + "Database" + "-" + DateTime.Now.ToString("MM.dd.yyyy---h.mmTT") + ".bak'");
            //    MessageBox.Show("Backup taken successfully", "Backup successs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            ////MessageBox.Show("Database BackUp has been created successfully.");
        }
    }
}
