using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoPOSControl;
using Microsoft.Win32;
using static EcoPOSv2.GlobalVariables;

namespace EcoPOSv2
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        //DECLARING AREA
        public static SplashScreen _splashScreen;
        SQLControl SQL = new SQLControl();
        int seconds = 0;


        public static SplashScreen Instance
        {
            get
            {
                if (_splashScreen == null)
                {
                    _splashScreen = new SplashScreen();
                }
                return _splashScreen;
            }
        }
        //CREATING BACKUPSETTINGS
        Thread td;
        void CheckIfBackupSettingsIsSetup()
        {
            td = new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    SQLControl psql = new SQLControl();

                    int count = int.Parse(SQL.ReturnResult("select count(*) from backup_setting"));

                    if (count <= 0)
                    {
                        psql.AddParam("@backup_by_time", false);
                        psql.AddParam("@backup_by_end_shift", false);
                        psql.AddParam("@backup_by_end_day", false);

                        psql.AddParam("@backup_time", "00:00:00 AM");
                        psql.AddParam("@backup_time_destination", "");
                        psql.AddParam("@backup_end_of_shift_destination", "");
                        psql.AddParam("@backup_end_of_day_destination", "");

                        psql.Query("Insert into backup_setting (backup_by_time,backup_by_end_shift,backup_by_end_day,backup_time,backup_time_destination,backup_end_of_shift_destination,backup_end_of_day_destination) VALUES (@backup_by_time,@backup_by_end_shift,@backup_by_end_day,@backup_time,@backup_time_destination,@backup_end_of_shift_destination,@backup_end_of_day_destination)");

                        if (psql.HasException(true)) return;
                    }
                }));
            });

            td.IsBackground = true;
            td.Start();

        }
        void CheckComputerIfValid()
        {
            RegistryKey myKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Electronics\\EcoPOS", true);

            if (myKey == null)
            {
                MessageBox.Show("Wag mo na icopy. Sa Ibang Computer ^_^", "Piracy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            if (myKey.GetValue("EcoPOS").ToString() != new Helper().Decrypt("CD7MY63RkDVQJfI8epabkw=="))
            {
                MessageBox.Show("Wag mo na icopy. Sa Ibang Computer ^_^", "Piracy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            CheckComputerIfValid();

            _splashScreen = this;

            //GLOBAL VARIABLES LOAD
            GlobalVariables.LoadPurchaseProducts();

            //SERVER TYPE OR NOT
            if (Properties.Settings.Default.servertype == true)
            {
                lblType.Text = "SERVER-TYPE POS SYSTEM ";
            }
            else
            {
                lblType.Text = "STAND-ALONE POS SYSTEM ";
            }

            seconds = 2;

            //DATABASE CONNECTION CHECKER
            string connection = SQL.CheckConnection();

            if (connection == "success")
            {
                //DITO LAHAT NG ADDIONAL FUNCTION


                //HULI TO LAGI
                CountDownTimer.Start();

                CheckIfBackupSettingsIsSetup();
            }
            else
            {
                new DVOptions().Show();
                //DatabaseSettings ds = new DatabaseSettings();
                //ds.ShowDialog();
            }
        }

        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            seconds--;

            if (seconds == 0)
            {
                CountDownTimer.Stop();

                Login l = new Login();
                l.Show();

                this.Hide();
                //DECLARE LOGIN FORM
            }
        }
        private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
