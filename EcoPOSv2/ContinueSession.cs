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
    public partial class ContinueSession : Form
    {
        public ContinueSession()
        {
            InitializeComponent();
        }
        private SQLControl SQL = new SQLControl();
        private Helper HP = new Helper();
        private RolePermission RP = new RolePermission();

        public Login frmLogin;
        public Order frmOrder;

        
        //METHODS
        private void LoadPermissions(int roleID)
        {
            SQL.AddParam("@roleID", roleID);

            SQL.Query("SELECT * FROM role_permission WHERE roleID = @roleID");
            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                Main.Instance.rp_ord_payment = Convert.ToBoolean(r["ord_payment"].ToString());
                Main.Instance.rp_ord_customer = Convert.ToBoolean(r["ord_customer"].ToString());
                Main.Instance.rp_ord_discount = Convert.ToBoolean(r["ord_discount"].ToString());
                Main.Instance.rp_ord_void_item = Convert.ToBoolean(r["ord_void_item"].ToString());
                Main.Instance.rp_ord_void_transaction = Convert.ToBoolean(r["ord_void_transaction"].ToString());
                Main.Instance.rp_ord_cancel_transaction = Convert.ToBoolean(r["ord_cancel_transaction"].ToString());
                Main.Instance.rp_ord_refund_transaction = Convert.ToBoolean(r["ord_refund_transaction"].ToString());
                Main.Instance.rp_ord_return_exchange = Convert.ToBoolean(r["ord_return_exchange"].ToString());
                Main.Instance.rp_ord_redeem_item = Convert.ToBoolean(r["ord_redeem_item"].ToString());
                Main.Instance.rp_home_switch_cashier = Convert.ToBoolean(r["home_switch_cashier"].ToString());
                Main.Instance.rp_home_more = Convert.ToBoolean(r["home_more"].ToString());
                Main.Instance.rp_more_ejournal = Convert.ToBoolean(r["more_ejournal"].ToString());
                Main.Instance.rp_more_customer_membership = Convert.ToBoolean(r["more_customer_membership"].ToString());
                Main.Instance.rp_more_pay_in_out = Convert.ToBoolean(r["more_pay_in_out"].ToString());
                Main.Instance.rp_more_logs = Convert.ToBoolean(r["more_logs"].ToString());
                Main.Instance.rp_more_redeem_settings = Convert.ToBoolean(r["more_redeem_settings"].ToString());
                Main.Instance.rp_more_manage_discounts = Convert.ToBoolean(r["more_manage_discounts"].ToString());
                Main.Instance.rp_more_manage_products = Convert.ToBoolean(r["more_manage_products"].ToString());
                Main.Instance.rp_more_inventory = Convert.ToBoolean(r["more_inventory"].ToString());
                Main.Instance.rp_more_close_store = Convert.ToBoolean(r["more_close_store"].ToString());
                Main.Instance.rp_more_database = Convert.ToBoolean(r["more_database"].ToString());
                Main.Instance.rp_more_settings = Convert.ToBoolean(r["more_settings"].ToString());
                Main.Instance.rp_pay_payment_method = Convert.ToBoolean(r["pay_payment_method"].ToString());
                Main.Instance.rp_pay_gift_certificate = Convert.ToBoolean(r["pay_gift_certificate"].ToString());
            }
        }
        //METHODS
        private void ContinueSession_Load(object sender, EventArgs e)
        {
            lblCS_Username.Text = SQL.ReturnResult("SELECT user_name FROM shift WHERE ended IS NULL AND shiftID = (SELECT MAX(shiftID) FROM shift)");
            if (SQL.HasException(true))return;

            this.ActiveControl = tbCSPassword;
        }

        private void ContinueSession_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
        int roleID;
        private void btnContinueSession_Click(object sender, EventArgs e)
        {
            string encrypt_password = HP.Encrypt(tbCSPassword.Text);

            SQL.AddParam("@user_name", lblCS_Username.Text);
            SQL.AddParam("@password", encrypt_password);
            int check_admin = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM admin_accts WHERE user_name = @user_name AND password = @password"));
            if (SQL.HasException(true)) return;

            SQL.AddParam("@user_name", lblCS_Username.Text);
            SQL.AddParam("@password", encrypt_password);
            int check_user = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM users WHERE user_name = @user_name AND password = @password"));
            if (SQL.HasException(true))
                return;

            if (check_user == 1 & check_admin == 0)
            {
                SQL.AddParam("@user_name", lblCS_Username.Text);
                SQL.AddParam("@password", encrypt_password);

                SQL.Query("SELECT * FROM users WHERE user_name = @user_name AND password = @password");
                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    Main.Instance.current_id = r["userID"].ToString();
                    Main.Instance.current_username = r["user_name"].ToString();
                    Main.Instance.current_user_first_name = r["first_name"].ToString();
                    Main.Instance.lblUser.Text = r["first_name"].ToString() + " " + r["last_name"].ToString();
                    roleID = Convert.ToInt32(r["roleID"].ToString());
                }

                LoadPermissions(roleID);

                RP.Order(Order.Instance);
                RP.Home(Main.Instance);

                Main.Instance.Show();
                Close();
                return;
            }
            else if (check_admin == 1 & check_user == 0)
            {
                SQL.AddParam("@user_name", lblCS_Username.Text);
                SQL.AddParam("@password", encrypt_password);

                SQL.Query("SELECT * FROM admin_accts WHERE user_name = @user_name AND password = @password");
                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    Main.Instance.current_id = r["adminID"].ToString();
                    Main.Instance.current_username = r["user_name"].ToString();
                    Main.Instance.current_user_first_name = r["first_name"].ToString();
                    Main.Instance.lblUser.Text = r["first_name"].ToString() + " " + r["last_name"].ToString();
                }

                //new Notification().PopUp("Login Success!", "Success", "success");

                Main.Instance.Show();
                Close();
            }
            else
            {
                new Notification().PopUp("Incorrect username or password.", "Error", "error");
                //MessageBox.Show("Incorrect password.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            string encrypt_password = HP.Encrypt(tbPassword.Text);
            SQL.AddParam("@user_name", tbUsername.Text);
            SQL.AddParam("@password", encrypt_password);
            int check_user = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM admin_accts WHERE user_name = @user_name AND password = @password"));
            if (SQL.HasException(true))
                return;
            if (check_user == 1)
            {
                SQL.AddParam("@user_name", tbUsername.Text);
                SQL.AddParam("@password", encrypt_password);
                SQL.Query("SELECT * FROM admin_accts WHERE user_name = @user_name AND password = @password");
                if (SQL.HasException(true))
                    return;
                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    Main.Instance.current_id = r["adminID"].ToString();
                    Main.Instance.current_username = r["user_name"].ToString();
                    Main.Instance.current_user_first_name = r["first_name"].ToString();
                    Main.Instance.lblUser.Text = r["first_name"].ToString() + " " + r["last_name"].ToString();
                }

                new Notification().PopUp("Login Success!","Success","success");

                Main.Instance.Show();
                Close();
            }
            else
            {
                //new Notification().PopUp("Incorrect Username or password", "Error", "error");
                //MessageBox.Show("Incorrect username or password.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void tbCSPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnContinueSession.PerformClick();
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLoginAdmin.PerformClick();
        }
    }
}
