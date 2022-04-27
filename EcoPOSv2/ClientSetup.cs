using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class ClientSetup : Form
    {
        public ClientSetup()
        {
            InitializeComponent();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e) // Save button
        {
            //Server PC
            if (checkBoxServerPC.Checked)
            {
                Properties.Settings.Default.isServerPC = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.isServerPC = false;
                Properties.Settings.Default.Save();
            }

            //Server Type
            if (checkBoxServerType.Checked)
            {
                Properties.Settings.Default.servertype = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.isServerPC = false;
                Properties.Settings.Default.servertype = false;
                Properties.Settings.Default.dbServerName = ".";
                Properties.Settings.Default.dbName = "EcoPOS";
                Properties.Settings.Default.dbUser = "sa";
                Properties.Settings.Default.dbPass = "123123";
                Properties.Settings.Default.Save();
            }

            new Notification().PopUp("Setup Settings Saved", "Success", "success");
        }

        private void ClientSetup_Load(object sender, EventArgs e)
        {
            //SERVER TYPE/NON-SERVER TYPE
            if (Properties.Settings.Default.servertype == true)
            {
                checkBoxServerType.Checked = true;
                //SERVER PC
                if (Properties.Settings.Default.isServerPC == true)
                {
                    checkBoxServerPC.Checked = true;
                    btnStaticIP.Enabled = true;
                    btnEnableTCP.Enabled = true;
                }
                else
                {
                    checkBoxServerPC.Checked = false;
                    btnStaticIP.Enabled = false;
                    btnEnableTCP.Enabled = false;
                }
            }
            else
            {
                checkBoxServerType.Checked = false;
                btnDatabaseSettings.Enabled = false;
                btnStaticIP.Enabled = false;
                btnEnableTCP.Enabled = false;
                checkBoxServerPC.Enabled = false;
            }
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "unknown";
        }

        public string GetLocalIpAllocationMode()
        {
            string MethodResult = "";
            try
            {
                ManagementObjectSearcher searcherNetwork = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapterConfiguration");
                Dictionary<string, string> Properties = new Dictionary<string, string>();
                foreach (ManagementObject queryObj in searcherNetwork.Get())
                {
                    foreach (var prop in queryObj.Properties)
                    {
                        if (prop.Name != null && prop.Value != null && !Properties.ContainsKey(prop.Name))
                        {
                            Properties.Add(prop.Name, prop.Value.ToString());
                        }
                    }
                }
                MethodResult = Properties["DHCPEnabled"].ToLower() == "true" ? "DHCP" : "Static";
            }
            catch (Exception ex)
            {

            }
            return MethodResult;
        }

        private void btnStaticIP_Click(object sender, EventArgs e)
        {
            if (GetLocalIpAllocationMode()=="Static")
            {
                MessageBox.Show("Your IP is already set as static IP.\n"+GetLocalIPAddress());
            }
            else { 
                if (MessageBox.Show(this, "Do you want to set your IP to a static IP?\n"+ GetLocalIPAddress(), "Set Static IP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExecuteAsAdmin(@"C:\EcoPOS\ServerSetup\1_IPtoStatic.bat");
                }
            }
        }

        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }

        public void PSexecute()
        {

        }

        private void checkBoxServerType_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxServerType.Checked)
            {
                checkBoxServerPC.Enabled = true;
                btnDatabaseSettings.Enabled = true;
                if (checkBoxServerPC.Checked)
                {
                    btnStaticIP.Enabled = true;
                    btnEnableTCP.Enabled = true;
                }
            }
            else
            {
                checkBoxServerPC.Enabled = false;
                btnDatabaseSettings.Enabled = false;
                btnStaticIP.Enabled = false;
                btnEnableTCP.Enabled = false;
            }
        }

        private void btnDatabaseSettings_Click(object sender, EventArgs e)
        {
            new DatabaseSettings().ShowDialog();
        }

        private void checkBoxServerPC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxServerPC.Checked)
            {
                btnStaticIP.Enabled = true;
                btnEnableTCP.Enabled = true;
            }
            else
            {
                btnStaticIP.Enabled = false;
                btnEnableTCP.Enabled = false;
            }
        }

        private void btnEnableTCP_Click(object sender, EventArgs e)
        {
            ExecuteAsAdmin(@"C:\EcoPOS\ServerSetup\2_RunTCP.bat");
            ExecuteAsAdmin(@"C:\EcoPOS\ServerSetup\3_SetPort.bat");
            ExecuteAsAdmin(@"C:\EcoPOS\ServerSetup\4_SetFirewallRule.bat");
        }
    }
}
