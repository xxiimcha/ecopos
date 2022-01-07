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

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SetServer(".");
        }

        private void OpenFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            SetServer(".");
        }

        public static string servername = EcoPOSv2.Properties.Settings.Default.dbServerName;
        public static string dbuser = EcoPOSv2.Properties.Settings.Default.dbUser; //GALING SA SETTINGS
        public static string dbpass = EcoPOSv2.Properties.Settings.Default.dbPass; //GALING SA SETTINGS

        private void SetServer(string str)
        {

            con = new SqlConnection(@"Data Source=" + servername + "; user=" + dbuser + "; password=" + dbpass + ";");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand(@"IF (EXISTS (SELECT name 
                                   FROM master.dbo.sysdatabases
                                   WHERE(name = 'EcoPOS')))
                                   BEGIN
                                   USE master
                                   ALTER DATABASE EcoPOS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                                   DROP DATABASE EcoPOS
                                   END;", con);
            cmd.ExecuteReader();
            con.Close();

            con.Open();
            cmd = new SqlCommand("RESTORE DATABASE EcoPOS FROM disk='" + txtDatabase.Text + "'", con);
            cmd.ExecuteReader();
            con.Close();

            new Notification().PopUp("Database restored. Please restart application.", "Database", "information");
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.ShowDialog();
            txtDatabase.Text = OpenFileDialog1.FileName;

        }

        private void BtnChooseFile2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            txtDatabase2.Text = openFileDialog2.FileName;
        }

        private void BtnConfirm2_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand(@"IF (EXISTS (SELECT name 
                                   FROM master.dbo.sysdatabases
                                   WHERE(name = 'EcoPOS_Training')))
                                   BEGIN
                                   USE master
                                   ALTER DATABASE EcoPOS_Training SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                                   DROP DATABASE EcoPOS_Training
                                   END;", con);
            cmd.ExecuteReader();
            con.Close();

            con.Open();
            cmd = new SqlCommand("RESTORE DATABASE EcoPOS_Training FROM disk='" + txtDatabase2.Text + "'", con);
            cmd.ExecuteReader();
            con.Close();

            new Notification().PopUp("Database restored. Please restart application.", "Database", "information");

        }

        private void BtnRestartApp_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

     
    }
}
