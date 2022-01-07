using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class TrialAuth : Form
    {
        public TrialAuth()
        {
            InitializeComponent();
        }
        //METHOD
        string Authkey, startdate;
        string[] hybridAuth;
        void Authenticate(string text)
        {
            string[] linefrompastebin = new string[10000];
            int i = 0;
            int maxLines = 0;
            bool _isAllowed = false;

            var url = "https://pastebin.com/raw/UzNNhUmq";
            var client = new WebClient();

            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                linefrompastebin[0] = "";

                //Store lines from HTML into string
                while ((linefrompastebin[i] = reader.ReadLine()) != null)
                {
                    i++;
                }
                maxLines = i;
            }
            //do some line processing - compare user with whitelist
            for (i = 0; i < maxLines; i++)
            {
                if (linefrompastebin[i].ToString().Contains(","))
                {
                    hybridAuth = linefrompastebin[i].Split(',');

                    //GET TEXT
                    startdate = hybridAuth[1];
                    Authkey = hybridAuth[0];

                    if (Authkey == text)
                    {
                        lblStatus.Text = "Authentication Success!";
                        lblStatus.ForeColor = Color.Lime;

                        DateTime TrialEndDate = DateTime.Parse(startdate);

                        if(TrialEndDate.AddDays(31) < DateTime.Now)
                        {
                            lblStatus.Text = "Authentication key expired!";
                            lblStatus.ForeColor = Color.Red;

                            MessageBox.Show("This authentication key is already expired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        //SAVE TO SETTINGS
                        Properties.Settings.Default.Trial = "Active";
                        Properties.Settings.Default.TrialExpiryDate = TrialEndDate.AddDays(31).ToShortDateString();
                        Properties.Settings.Default.Save();

                        new SplashScreen().Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        lblStatus.Text = "Authentication Error!";
                        lblStatus.ForeColor = Color.Red;
                        continue;
                    }
                }
            }
        }
        private void TrialAuth_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Trial == "Active")
            {
                new SplashScreen().Show();
                this.Hide();
            }

            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);

            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("Electronics");
            RegistryKey AppVersionKey = AppNameKey.CreateSubKey("EcoPOS");

            AppVersionKey.SetValue("EcoPOS", new Helper().Decrypt("CD7MY63RkDVQJfI8epabkw=="));
        }

        private void TbAuthKey_Enter(object sender, EventArgs e)
        {
            if(tbAuthKey.Text == "Authentication Key")
            {
                tbAuthKey.Clear();
                tbAuthKey.ForeColor = Color.Black;
            }
        }

        private void TbAuthKey_Leave(object sender, EventArgs e)
        {
            if(tbAuthKey.Text == "")
            {
                tbAuthKey.Text = "Authentication Key";
                tbAuthKey.ForeColor = Color.Gray;
            }
        }
        private void TbAuthKey_TextChanged(object sender, EventArgs e)
        {
            if(tbAuthKey.Text != "")
            {
                Authenticate(tbAuthKey.Text);
            }
        }

        private void LlFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/ecopos.info");
        }
    }
}
