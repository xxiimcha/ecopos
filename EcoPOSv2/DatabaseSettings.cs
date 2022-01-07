﻿using EcoPOSControl;
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
    public partial class DatabaseSettings : Form
    {
        public DatabaseSettings()
        {
            InitializeComponent();
        }
        //CLEAR ALL FIELDS
        void clearallfields()
        {
            tbDatabaseName.SelectedIndex = 0;
            tbServerName.Text = "";

            //tbUsername.Clear();
            //tbPassword.Clear();

            tbServerName.Focus();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbServerName = tbServerName.Text;
            Properties.Settings.Default.dbName = tbDatabaseName.Text;
            Properties.Settings.Default.dbUser = tbUsername.Text;
            Properties.Settings.Default.dbPass = tbPassword.Text;
            Properties.Settings.Default.Save();

            //new Notification().PopUp("Database setup applied.", "Application will be restart.");
            MessageBox.Show("Database setup applied.","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearallfields();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            //Prompt.Instance.Pop(1);

            Prompt frmPrompt = new Prompt();
            frmPrompt.Pop(1);
        }

        private void DatabaseSettings_Load(object sender, EventArgs e)
        {
            tbServerName.Focus();
        }
    }
}
