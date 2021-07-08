using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class ImportDatabase : Form
    {
        public ImportDatabase()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dread;
        SQLControl SQL = new SQLControl();

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("RESTORE DATABASE EcoPOS FROM disk='" + txtDatabase.Text + "'", con);
            cmd.ExecuteReader();

            tmrClose.Start();

            new Notification().PopUp("Store details saved. System will restart.", "Database", "information");
            Application.Restart();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.ShowDialog();

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDatabase.Text = OpenFileDialog1.FileName;
            }
        }
    }
}
