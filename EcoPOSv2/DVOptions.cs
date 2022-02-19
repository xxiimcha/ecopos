using EcoPOSControl;
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

            if (login == 0)
            {
                btnChangeStoreSettings.Enabled = false;
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
            if(MessageBox.Show(this,"Do you want to Reset Product & Category ?","Reset Database",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLControl SQL = new SQLControl();

                btnResetDatabase.Enabled = false;
                btnResetDatabase.Text = "Cleaning the database Tables..";
                SQL.Query("DELETE FROM Audit");
                SQL.Query("DELETE FROM cashier_declaration");
                SQL.Query("DELETE FROM customer");
                SQL.Query("DELETE FROM discount");
                SQL.Query("DELETE FROM giftcard");
                SQL.Query("DELETE FROM inventory");
                SQL.Query("DELETE FROM inventory_operation");
                SQL.Query("DELETE FROM inventory_operation_items");
                SQL.Query("DELETE FROM inventory_supplier");
                SQL.Query("DELETE FROM keep");
                SQL.Query("DELETE FROM member_card");
                SQL.Query("DELETE FROM membership");
                SQL.Query("DELETE FROM order_cart");
                SQL.Query("DELETE FROM order_no");
                SQL.Query("DELETE FROM pay_in_out");
                SQL.Query("DELETE FROM points_award");
                SQL.Query("DELETE FROM product_category");
                SQL.Query("DELETE FROM products");
                SQL.Query("DELETE FROM profit");
                SQL.Query("DELETE FROM redeem_cart");
                SQL.Query("DELETE FROM redeem_items");
                SQL.Query("DELETE FROM redeem_transaction");
                SQL.Query("DELETE FROM redeem_transaction_items");
                SQL.Query("DELETE FROM role_permission");
                SQL.Query("DELETE FROM shift");
                SQL.Query("DELETE FROM store_start");
                SQL.Query("DELETE FROM transaction_details");
                SQL.Query("DELETE FROM transaction_items");
                SQL.Query("DELETE FROM user_logs");
                SQL.Query("DELETE FROM user_role");
                SQL.Query("DELETE FROM users");
                SQL.Query("DELETE FROM void_item");
                SQL.Query("DELETE FROM void_transaction");
                SQL.Query("DELETE FROM xreading");
                SQL.Query("DELETE FROM zreading");

                SQL.Query(@"DBCC CHECKIDENT ('[customer]', RESEED, 0);
                DBCC CHECKIDENT('[discount]', RESEED, 0);
                DBCC CHECKIDENT('[giftcard]', RESEED, 0);
                DBCC CHECKIDENT('[inventory_operation]', RESEED, 0);
                DBCC CHECKIDENT('[inventory_operation_items]', RESEED, 0);
                DBCC CHECKIDENT('[inventory_supplier]', RESEED, 0);
                DBCC CHECKIDENT('[member_card]', RESEED, 0);
                DBCC CHECKIDENT('[membership]', RESEED, 0);
                DBCC CHECKIDENT('[order_no]', RESEED, 0);
                DBCC CHECKIDENT('[order_cart]', RESEED, 0);
                DBCC CHECKIDENT('[product_category]', RESEED, 0);
                DBCC CHECKIDENT('[products]', RESEED, 0);
                DBCC CHECKIDENT('[profit]', RESEED, 0);
                DBCC CHECKIDENT('[redeem_cart]', RESEED, 0);
                DBCC CHECKIDENT('[redeem_items]', RESEED, 0);
                DBCC CHECKIDENT('[shift]', RESEED, 0);
                DBCC CHECKIDENT('[store_start]', RESEED, 0);
                DBCC CHECKIDENT('[user_logs]', RESEED, 0);
                DBCC CHECKIDENT('[user_role]', RESEED, 0);
                DBCC CHECKIDENT('[users]', RESEED, 0);
                DBCC CHECKIDENT('[void_item]', RESEED, 0);
                DBCC CHECKIDENT('[void_transaction]', RESEED, 0);
                DBCC CHECKIDENT('[warehouse]', RESEED, 0);
                DBCC CHECKIDENT('[xreading]', RESEED, 0);");

                btnResetDatabase.Text = "Database tables has been cleaned.";
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
            if (MessageBox.Show(this, "Do you want to Reset Sales?", "Reset Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                SQL.Query("delete from keep");
                SQL.Query("delete from redeem_transaction");
                SQL.Query("delete from redeem_transaction_items");
                SQL.Query("delete from transaction_details");
                SQL.Query("delete from transaction_items");
                SQL.Query("delete from void_item");
                SQL.Query("delete from void_transaction");
                SQL.Query("delete from xreading");
                SQL.Query("delete from zreading");

                SQL.Query(@"DBCC CHECKIDENT('[order_no]', RESEED, 0);
                DBCC CHECKIDENT('[order_cart]', RESEED, 0);
                DBCC CHECKIDENT('[profit]', RESEED, 0);
                DBCC CHECKIDENT('[redeem_cart]', RESEED, 0);
                DBCC CHECKIDENT('[redeem_items]', RESEED, 0);
                DBCC CHECKIDENT('[shift]', RESEED, 0);
                DBCC CHECKIDENT('[void_item]', RESEED, 0);
                DBCC CHECKIDENT('[void_transaction]', RESEED, 0);
                DBCC CHECKIDENT('[xreading]', RESEED, 0);");

                btnResetSales.Text = "Sales has been reset.";
            }
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

        private void BtnClientSetup_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            new ClientSetup().ShowDialog();
        }

        private void DVOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
