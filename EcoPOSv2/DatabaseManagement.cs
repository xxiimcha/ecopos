using EcoPOSControl;
using EcoPOSMasterControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class DatabaseManagement : Form
    {
        public DatabaseManagement()
        {
            InitializeComponent();
        }
        public static DatabaseManagement _DatabaseManagement;
        bool CheckForInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static DatabaseManagement Instance
        {
            get
            {
                if (_DatabaseManagement == null)
                {
                    _DatabaseManagement = new DatabaseManagement();
                }
                return _DatabaseManagement;
            }
        }
        public void SetDoubleBuffered(Panel panel)
        {
            typeof(Panel).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               panel,
               new object[] { true });
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        //METHODS
        private void HideAllTabsOnTabControl(TabControl theTabControl)
        {
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;
        }
        void EnableBackupByTime(bool status)
        {
            Task.Run(
                () =>
                {
                    SQLControl psql = new SQLControl();

                    psql.Query("UPDATE backup_setting SET backup_by_time = '" + status + "' ");
                    if (psql.HasException(true)) return;
                }
                );
        }
        void EnableBackupByTimeSaved(String time, String directory)
        {
            Task.Run(
                () =>
                {
                    SQLControl psql = new SQLControl();
                    psql.Query("UPDATE backup_setting SET backup_time = '" + time + "', backup_time_destination = '" + directory + "' ");
                    if (psql.HasException(true)) return;
                });
        }

        void EnableBackupByEndShift(Boolean value)
        {
            Task.Run(
                () =>
                {
                    SQLControl psql = new SQLControl();
                    psql.Query("UPDATE backup_setting SET backup_by_end_shift = '" + value + "' ");
                    if (psql.HasException(true)) return;
                });
        }

        public static void EnableBackupByEndShiftSaved(String directory)
        {
            Task.Run(
                () =>
                {
                    SQLControl psql = new SQLControl();
                    psql.Query("UPDATE backup_setting SET backup_end_of_shift_destination = '" + directory + "' ");
                    if (psql.HasException(true)) return;
                });
        }
        public static void EnableBackupByEndDay(Boolean value)
        {
            Task.Run(
                () =>
                {
                    SQLControl psql = new SQLControl();
                    psql.Query("UPDATE backup_setting SET backup_by_end_day = '" + value + "' ");
                    if (psql.HasException(true)) return;
                });
        }
        public static void EnableBackupByEndDaySaved(String directory)
        {
            Task.Run(
                () =>
                {
                    SQLControl psql = new SQLControl();
                    psql.Query("UPDATE backup_setting SET backup_end_of_day_destination = '" + directory + "' ");
                    if (psql.HasException(true)) return;
                });
        }

        void KillProcess(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    Environment.Exit(1);
                }
                Process[] mainAppProcessOrProcessesRunning = Process.GetProcessesByName(name);
                foreach (var p in mainAppProcessOrProcessesRunning)
                {
                    p.Kill();
                }
            }
            catch (Exception) { MessageBox.Show("Error in backup"); }
        }

        ////TEMPORARY
        //public static void Copy(string inputFilePath, string outputFilePath)
        //{
        //    using (FileStream streamRead = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
        //    using (FileStream streamWrite = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
        //    {
        //        int bytesRead = 0;

        //        byte[] buffer = new byte[8096];

        //        while((bytesRead = streamRead.Read(buffer,0,buffer.Length)) > 0)
        //        {
        //            streamWrite.Write(buffer, 0, bytesRead);

        //        }
        //    }
        //}
        ////TEMPORARY
        public void BackupDatabaseInFolder()
        {
            try
            {
                //KillProcess("sqlservr");
                SQLControl sql = new SQLControl();
                string directory = "";

                if (Main.Instance.endOfShift)
                {
                    directory = sql.ReturnResult("SELECT backup_end_of_shift_destination FROM backup_setting");
                }
                else if (Main.Instance.endOfDay)
                {
                    directory = sql.ReturnResult("SELECT backup_end_of_day_destination FROM backup_setting");
                }
                else if (Main.Instance.bytime)
                {
                    directory = sql.ReturnResult("SELECT backup_time_destination FROM backup_setting");
                }
                String folderName = "EcoPOS BACKUP (" + DateTime.Now.ToString("MM-dd-yyyy hh mm tt") + ")";
                String location = @"" + directory + "";
                String path = Path.Combine(location, folderName);
                Directory.CreateDirectory(path);

                SQLMasterControl SQLMaster = new SQLMasterControl();

                SQLMaster.Query("Backup database EcoPOS to disk= '" + directory + "\\" + folderName + "\\EcoPOS.bak' ");

                //string ApplicationPath = AppDomain.CurrentDomain.BaseDirectory;

                //string EcoPOS_Filename = "EcoPOS.mdf";
                //string EcoPOS_Training_Filename = "EcoPOS_Training.mdf";

                //string EcoPOS = Path.Combine(ApplicationPath, EcoPOS_Filename);
                //string EcoPOS_path = Path.Combine(path, EcoPOS_Filename);

                //string EcoPOS_Training = Path.Combine(ApplicationPath, EcoPOS_Training_Filename);
                //string EcoPOS_Training_Path = Path.Combine(path, EcoPOS_Training_Filename);

                //MessageBox.Show(directory);

                //Copy(@EcoPOS, @path);
                //Copy(@EcoPOS_Training, @path);
                //File.Copy(@EcoPOS, @EcoPOS_path);
                //File.Copy(@EcoPOS_Training, @EcoPOS_Training_Path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //LOADSettings
        string backup_id;

        void loadSettings()
        {
            //string backup_id, backup_time, backup_end_of_day_destination, backup_end_of_shift_destination, backup_time_destination, backup_by_time, backup_by_end_day, backup_by_end_shift;

            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    SQLControl psql = new SQLControl();

                    int count = Convert.ToInt32(psql.ReturnResult("select count(*) from backup_setting"));

                    if (count > 0)
                    {
                        psql.Query("SELECT * from backup_setting");
                        if (psql.HasException(true)) return;

                        foreach (DataRow dr in psql.DBDT.Rows)
                        {
                            backup_id = dr["backup_id"].ToString();
                            Main.Instance.bytime = Boolean.Parse(dr["backup_by_time"].ToString());
                            Main.Instance.endOfShift = Boolean.Parse(dr["backup_by_end_shift"].ToString());
                            Main.Instance.endOfDay = Boolean.Parse(dr["backup_by_end_day"].ToString());

                            checkBoxBackupTime.Checked = Boolean.Parse(dr["backup_by_time"].ToString());
                            checkBoxBackupEndDay.Checked = Boolean.Parse(dr["backup_by_end_day"].ToString());
                            checkBoxBackupEndShift.Checked = Boolean.Parse(dr["backup_by_end_shift"].ToString());

                            txtBackupTime.Text = dr["backup_time"].ToString();
                            txtDirectory.Text = dr["backup_time_destination"].ToString();
                            txtDirectoryEndShift.Text = dr["backup_end_of_shift_destination"].ToString();
                            txtDirectoryEndDay.Text = dr["backup_end_of_day_destination"].ToString();
                        }
                    }
                    else
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

            }).Start();
        }
        //EMAIL DATABASE
        void Clear()
        {
            txtUsername.Text = "";
            txtTo.Text = "";
            txtSubject.Text = "";
            txtPassword.Text = "";
            txtMessage.Text = "";
            txtFileName.Text = "";
        }
        //METHODS

        private void btnAutoBackup_Click(object sender, EventArgs e)
        {
            pIndicator.Location = new Point(225, 74);

            tControl.SelectedIndex = 0;
        }

        private void btnEmailDatabase_Click(object sender, EventArgs e)
        {
            pIndicator.Location = new Point(225, 119);

            tControl.SelectedIndex = 1;

            firstContainer.BringToFront();
        }

        private void DatabaseManagement_Load(object sender, EventArgs e)
        {
            HideAllTabsOnTabControl(tControl);

            loadSettings();

            _DatabaseManagement = this;
        }

        private void checkBoxBackupTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBackupTime.Checked)
            {
                guna2ImageButton1.PerformClick();
            }
            if (!checkBoxBackupTime.Checked)
            {
                EnableBackupByTime(false);
                panel1.Visible = false;
            }
        }

        private void checkBoxBackupEndShift_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBackupEndShift.Checked)
            {
                guna2ImageButton2.PerformClick();
            }
            if (!checkBoxBackupEndShift.Checked)
            {
                EnableBackupByEndShift(false);
                panel3.Visible = false;
            }
        }

        private void checkBoxBackupEndDay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBackupEndDay.Checked)
            {
                guna2ImageButton3.PerformClick();
            }
            if (!checkBoxBackupEndDay.Checked)
            {
                EnableBackupByEndDay(false);
                panel5.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBackupTime.Text.Equals("") || txtDirectory.Text.Equals(""))
            {
                MessageBox.Show("Complete the fields first.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtBackupTime.Text.Contains(":") && (txtBackupTime.Text.Contains(" PM") || txtBackupTime.Text.Contains(" AM")))
                {
                    EnableBackupByTime(true);
                    EnableBackupByTimeSaved(txtBackupTime.Text, txtDirectory.Text);
                    MessageBox.Show("Successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please check your time format.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSaveEndShift_Click(object sender, EventArgs e)
        {
            if (txtDirectoryEndShift.Text.Equals(""))
            {
                MessageBox.Show("Please select directory first.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                EnableBackupByEndShift(true);
                EnableBackupByEndShiftSaved(txtDirectoryEndShift.Text);
                MessageBox.Show("Successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveEndDay_Click(object sender, EventArgs e)
        {
            if (txtDirectoryEndDay.Text.Equals(""))
            {
                MessageBox.Show("Please select directory first.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                EnableBackupByEndDay(true);
                EnableBackupByEndDaySaved(txtDirectoryEndDay.Text);
                MessageBox.Show("Successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            if (panel3.Visible)
            {
                panel3.Visible = false;
            }
            else
            {
                panel3.Visible = true;
            }

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            if (panel5.Visible)
            {
                panel5.Visible = false;
            }
            else
            {
                panel5.Visible = true;
            }
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbd.SelectedPath;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDirectoryEndShift.Text = fbd.SelectedPath;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDirectoryEndDay.Text = fbd.SelectedPath;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1.FillColor = ColorTranslator.FromHtml("#97D5FE");
            btn1.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            btn2.FillColor = Color.FromArgb(255, 255, 255);
            btn2.ForeColor = ColorTranslator.FromHtml("#000000");
            firstContainer.BringToFront();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btn2.FillColor = ColorTranslator.FromHtml("#97D5FE");
            btn2.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            btn1.FillColor = Color.FromArgb(255, 255, 255);
            btn1.ForeColor = ColorTranslator.FromHtml("#000000");
            secondContainer.BringToFront();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals("") || txtPassword.Text.Equals("") || !txtUsername.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Check your username/password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                btn2.PerformClick();
            }
        }
        BackgroundWorker workerSendEmail;
        private void btnSend_Click(object sender, EventArgs e)
        {
            workerSendEmail = new BackgroundWorker();
            workerSendEmail.DoWork += WorkerSendEmail_DoWork;

            workerSendEmail.RunWorkerAsync();
        }

        private void WorkerSendEmail_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (txtUsername.Text.Equals("") || txtPassword.Text.Equals("") || !txtUsername.Text.Contains("@gmail.com"))
                {
                    MessageBox.Show("Check your username/password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btn1.PerformClick();
                }
                else if (txtSubject.Text.Equals("") || txtTo.Text.Equals("") || txtMessage.Text.Equals(""))
                {
                    MessageBox.Show("Complete all fields first..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtFileName.Text.Equals(""))
                {
                    MessageBox.Show("Please attach the backup file first.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (CheckForInternetConnection())
                    {
                        lblSending.Visible = true;
                        progressBar1.Visible = true;
                        progressBar1.Minimum = 1;
                        progressBar1.Maximum = 20000;
                        progressBar1.Value = 1;
                        progressBar1.Step = 1;
                        for (int x = 1; x <= 20000; x++)
                        {
                            progressBar1.PerformStep();
                        }
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(txtUsername.Text);
                        mail.Sender = new MailAddress(txtUsername.Text);
                        mail.To.Add(txtTo.Text);
                        mail.IsBodyHtml = true;
                        mail.Subject = txtSubject.Text;
                        mail.Body = txtMessage.Text;
                        mail.Attachments.Add(new Attachment(txtFileName.Text));
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential(txtUsername.Text, txtPassword.Text);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;
                        smtp.Timeout = 100000;
                        try
                        {
                            smtp.Send(mail);
                            MessageBox.Show("Successfully Sent Message.");
                            progressBar1.Visible = false;
                            lblSending.Visible = false;

                            Clear();
                        }
                        catch (SmtpException ex)
                        {
                            MessageBox.Show("Your credentials is not exist");
                            progressBar1.Visible = false;
                            lblSending.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please check your internet connection first.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }));
        }

        private void btnAttackFileEmail_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Bak files (*.bak)|*.bak";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = dialog.FileName;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnNext.PerformClick();
            }
        }
    }
}
