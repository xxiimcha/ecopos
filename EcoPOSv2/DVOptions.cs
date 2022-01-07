﻿using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class DVOptions : Form
    {
        public DVOptions()
        {
            InitializeComponent();
            //MAGIC LINE
            CheckForIllegalCrossThreadCalls = false;
        }
        public int login = 0;

        public static DVOptions _DVOptions;
        public static DVOptions Instance
        {
            get
            {
                if (_DVOptions == null)
                {
                    _DVOptions = new DVOptions();
                }
                return _DVOptions;
            }
        }
        private void DVOptions_Load(object sender, EventArgs e)
        {
            _DVOptions = this;

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
            btnResetDatabase.Text = "Reset Database " + Properties.Settings.Default.dbName;


            if (login == 0)
            {
                btnChangeStoreSettings.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = false;
                btnResetDatabase.Enabled = false;
                btnInvoiceEditor.Enabled = false;
                btnResetSales.Enabled = false;
                btnFeatures.Enabled = false;
                btnTerminal.Enabled = false;
                btnQuery.Enabled = false;

                btnShowMainForm.Enabled = false;
            }
            else if(login == 1)
            {
                btnChangeStoreSettings.Enabled = true;
                btnStart.Enabled = true;
                btnStop.Enabled = true;
                btnResetDatabase.Enabled = true;
                btnInvoiceEditor.Enabled = true;
                btnResetSales.Enabled = true;
                btnFeatures.Enabled = true;
                btnTerminal.Enabled = true;
                btnQuery.Enabled = false;

                btnShowMainForm.Enabled = true;
            }
        }

        private void btnChangeStoreSettings_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            EditSD frmEditSD = new EditSD();
            frmEditSD.ShowDialog();
        }

        private void btnImportDatabase_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            ImportDatabase frmImportDatabase = new ImportDatabase();
            frmImportDatabase.ShowDialog();
        }

        private void btnShowMainForm_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            new Main().Show();

            Prompt.Instance.Close();

            Login.Instance.close = true;
            Login.Instance.Close();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbName = "EcoPOS_Training";
            Properties.Settings.Default.Save();

            MessageBox.Show("Traning mode started.. Application will restart.", "Restarting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Application.Restart();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbName = "EcoPOS";
            Properties.Settings.Default.Save();

            MessageBox.Show("Traning mode has been stopped. Application will restart.", "Restarting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Application.Restart();
        }
        private void btnResetDatabase_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            Task.Run(() =>
            {
                using (WaitForm frm = new WaitForm(ResetDatabase))
                {
                    frm.ShowDialog(this);
                }
            }
            );
        }

        private void ResetDatabase()
        {
            if(MessageBox.Show(this,"Do you want to Reset product & Category ?","Reset Product",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLControl SQL = new SQLControl();

                btnResetDatabase.Enabled = false;
                btnResetDatabase.Text = "Cleaning the database Tables..";
                SQL.Query("delete from Audit");
                SQL.Query("delete from cashier_declaration");
                SQL.Query("delete from customer");
                SQL.Query("delete from discount");
                SQL.Query("delete from giftcard");
                SQL.Query("delete from inventory");
                SQL.Query("delete from inventory_operation");
                SQL.Query("delete from inventory_operation_items");
                //SQL.Query("delete from inventory_supplier");
                SQL.Query("delete from member_card");
                SQL.Query("delete from membership");
                SQL.Query("delete from order_cart");
                SQL.Query("delete from order_no");
                SQL.Query("delete from pay_in_out");
                SQL.Query("delete from points_award");
                SQL.Query("delete from product_category");
                SQL.Query("delete from products");
                SQL.Query("delete from profit");
                SQL.Query("delete from redeem_cart");
                SQL.Query("delete from redeem_items");
                SQL.Query("delete from redeem_transaction");
                SQL.Query("delete from redeem_transaction_items");
                //SQL.Query("delete from role_permission");
                SQL.Query("delete from shift");
                SQL.Query("delete from store_start");
                SQL.Query("delete from transaction_details");
                //SQL.Query("delete from user_logs");
                //SQL.Query("delete from user_role");
                //SQL.Query("delete from users");
                SQL.Query("delete from void_item");
                SQL.Query("delete from void_transaction");
                SQL.Query("delete from xreading");
                SQL.Query("delete from zreading");

                btnResetDatabase.Text = "Database tables has been cleaned.";

                //Environment.Exit(0);
                //System.Diagnostics.Process.Start(Application.ExecutablePath);
            }
            else
            {
                SQLControl SQL = new SQLControl();

                btnResetDatabase.Enabled = false;
                btnResetDatabase.Text = "Cleaning the database Tables..";
                SQL.Query("delete from Audit");
                SQL.Query("delete from cashier_declaration");
                SQL.Query("delete from customer");
                SQL.Query("delete from discount");
                SQL.Query("delete from giftcard");
                //SQL.Query("delete from inventory");
                SQL.Query("delete from inventory_operation");
                SQL.Query("delete from inventory_operation_items");
                //SQL.Query("delete from inventory_supplier");
                SQL.Query("delete from member_card");
                SQL.Query("delete from membership");
                SQL.Query("delete from order_cart");
                SQL.Query("delete from order_no");
                SQL.Query("delete from pay_in_out");
                SQL.Query("delete from points_award");
                //SQL.Query("delete from product_category");
                //SQL.Query("delete from products");
                SQL.Query("delete from profit");
                SQL.Query("delete from redeem_cart");
                SQL.Query("delete from redeem_items");
                SQL.Query("delete from redeem_transaction");
                SQL.Query("delete from redeem_transaction_items");
                //SQL.Query("delete from role_permission");
                SQL.Query("delete from shift");
                SQL.Query("delete from store_start");
                SQL.Query("delete from transaction_details");
                //SQL.Query("delete from user_logs");
                //SQL.Query("delete from user_role");
                //SQL.Query("delete from users");
                SQL.Query("delete from void_item");
                SQL.Query("delete from void_transaction");
                SQL.Query("delete from xreading");
                SQL.Query("delete from zreading");

                btnResetDatabase.Text = "Database tables has been cleaned.";

                //Environment.Exit(0);
                //System.Diagnostics.Process.Start(Application.ExecutablePath);
            }
        }

        private void BtnInvoiceEditor_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            InvoiceEditor IE = new InvoiceEditor();
            IE.ShowDialog();
        }

        private void BtnTerminal_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            new TerminalNumberEditor().ShowDialog();
        }

        private void btnFeatures_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            Features F = new Features();
            F.ShowDialog();
        }
        void ResetSales()
        {
            SQLControl SQL = new SQLControl();

            btnResetSales.Enabled = false;
            btnResetSales.Text = "Resetting Sales..";
            SQL.Query("delete from order_cart");
            SQL.Query("delete from order_no");
            SQL.Query("delete from points_award");
            SQL.Query("delete from profit");
            SQL.Query("delete from inventory_operation");
            SQL.Query("delete from inventory_operation_items");
            SQL.Query("delete from redeem_transaction");
            SQL.Query("delete from redeem_transaction_items");
            SQL.Query("delete from transaction_details");
            SQL.Query("delete from transaction_items");
            SQL.Query("delete from void_item");
            SQL.Query("delete from void_transaction");
            SQL.Query("delete from xreading");
            SQL.Query("delete from zreading");

            btnResetSales.Text = "Sales has been reset.";
        }
        private void BtnResetSales_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            Task.Run(() =>
            {
                using (WaitForm frm = new WaitForm(ResetSales))
                {
                    frm.ShowDialog(this);
                }
            }
            );
        }

        private void DVOptions_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F12)
            {
                this.TopMost = false;

                new CodePlayGround().ShowDialog();
            }
        }

        private void DVOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            new SQLManualQuery().ShowDialog();
        }

        private void BtnDatabaseSettings_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            new DatabaseSettings().ShowDialog();
        }
    }
}
