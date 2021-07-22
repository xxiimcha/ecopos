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
    public partial class UserBypass : Form
    {

        private SQLControl SQL = new SQLControl();
        private Helper HP = new Helper();
        private RolePermission RP = new RolePermission();
        public Order frmOrder;
        public More frmMore;
        public bool fromOrder;
        public bool fromMore;

        public UserBypass()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            SQL.AddParam("@user_name", txtUsername.Text);
            SQL.AddParam("@keycode", txtKeycode.Text);
            int check_user = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) as 'count' FROM users WHERE user_name = @user_name AND keycode = @keycode"));
            if (SQL.HasException(true))
                return;
            SQL.AddParam("@user_name", txtUsername.Text);
            SQL.AddParam("@keycode", txtKeycode.Text);
            int check_admin = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) as 'count' FROM admin_accts WHERE user_name = @user_name AND keycode = @keycode"));
            if (SQL.HasException(true))
                return;
            if (check_user == 1 | check_admin == 1)
            {
                if (check_user == 1)
                {
                    var roleID = default(int);
                    SQL.AddParam("@user_name", txtUsername.Text);
                    SQL.AddParam("@keycode", txtKeycode.Text);
                    SQL.Query("SELECT * FROM users WHERE user_name = @user_name AND keycode = @keycode");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        Main.Instance.by_pass_userID = Convert.ToInt32(r["userID"].ToString());
                        Main.Instance.by_pass_user_name = r["user_name"].ToString();
                        Main.Instance.lblByPassUser.Text = r["first_name"].ToString() + " " + r["last_name"].ToString();
                        roleID = Convert.ToInt32(r["roleID"].ToString());
                    }

                    Main.Instance.by_pass_user = true;
                    SQL.AddParam("@roleID", roleID);
                    SQL.Query("SELECT * FROM role_permission WHERE roleID = @roleID");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        Main.Instance.bp_ord_payment = Convert.ToBoolean(r["ord_payment"].ToString());
                        Main.Instance.bp_ord_customer = Convert.ToBoolean(r["ord_customer"].ToString());
                        Main.Instance.bp_ord_discount = Convert.ToBoolean(r["ord_discount"].ToString());
                        Main.Instance.bp_ord_void_item = Convert.ToBoolean(r["ord_void_item"].ToString());
                        Main.Instance.bp_ord_void_transaction = Convert.ToBoolean(r["ord_void_transaction"].ToString());
                        Main.Instance.bp_ord_cancel_transaction = Convert.ToBoolean(r["ord_cancel_transaction"].ToString());
                        Main.Instance.bp_ord_refund_transaction = Convert.ToBoolean(r["ord_refund_transaction"].ToString());
                        Main.Instance.bp_ord_return_exchange = Convert.ToBoolean(r["ord_return_exchange"].ToString());
                        Main.Instance.bp_ord_redeem_item = Convert.ToBoolean(r["ord_redeem_item"].ToString());
                        Main.Instance.bp_home_switch_cashier = Convert.ToBoolean(r["home_switch_cashier"].ToString());
                        Main.Instance.bp_home_more = Convert.ToBoolean(r["home_more"].ToString());
                        Main.Instance.bp_more_ejournal = Convert.ToBoolean(r["more_ejournal"].ToString());
                        Main.Instance.bp_more_customer_membership = Convert.ToBoolean(r["more_customer_membership"].ToString());
                        Main.Instance.bp_more_pay_in_out = Convert.ToBoolean(r["more_pay_in_out"].ToString());
                        Main.Instance.bp_more_logs = Convert.ToBoolean(r["more_logs"].ToString());
                        Main.Instance.bp_more_redeem_settings = Convert.ToBoolean(r["more_redeem_settings"].ToString());
                        Main.Instance.bp_more_manage_discounts = Convert.ToBoolean(r["more_manage_discounts"].ToString());
                        Main.Instance.bp_more_manage_products = Convert.ToBoolean(r["more_manage_products"].ToString());
                        Main.Instance.bp_more_inventory = Convert.ToBoolean(r["more_inventory"].ToString());
                        Main.Instance.bp_more_close_store = Convert.ToBoolean(r["more_close_store"].ToString());
                        Main.Instance.bp_more_database = Convert.ToBoolean(r["more_database"].ToString());
                        Main.Instance.bp_more_settings = Convert.ToBoolean(r["more_settings"].ToString());
                        Main.Instance.bp_pay_payment_method = Convert.ToBoolean(r["pay_payment_method"].ToString());
                        Main.Instance.bp_pay_gift_certificate = Convert.ToBoolean(r["pay_gift_certificate"].ToString());
                    }

                    RP.Home(Main.Instance);
                    if (fromOrder)
                        RP.Order(frmOrder);
                    if (fromMore)
                        RP.More(frmMore);
                    Close();    
                }
                else if (check_admin == 1)
                {
                    SQL.AddParam("@user_name", txtUsername.Text);
                    SQL.AddParam("@keycode", txtKeycode.Text);
                    SQL.Query("SELECT * FROM admin_accts WHERE user_name = @user_name AND keycode = @keycode");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        Main.Instance.by_pass_userID = int.Parse(r["adminID"].ToString());
                        Main.Instance.by_pass_user_name = r["user_name"].ToString();
                        Main.Instance.lblByPassUser.Text = r["first_name"].ToString() + " " + r["last_name"].ToString();
                    }

                    Main.Instance.by_pass_user = true;
                    Main.Instance.bp_ord_payment = true;
                    Main.Instance.bp_ord_customer = true;
                    Main.Instance.bp_ord_discount = true;
                    Main.Instance.bp_ord_void_item = true;
                    Main.Instance.bp_ord_void_transaction = true;
                    Main.Instance.bp_ord_cancel_transaction = true;
                    Main.Instance.bp_ord_refund_transaction = true;
                    Main.Instance.bp_ord_return_exchange = true;
                    Main.Instance.bp_ord_redeem_item = true;
                    Main.Instance.bp_home_switch_cashier = true;
                    Main.Instance.bp_home_more = true;
                    Main.Instance.bp_more_ejournal = true;
                    Main.Instance.bp_more_customer_membership = true;
                    Main.Instance.bp_more_pay_in_out = true;
                    Main.Instance.bp_more_logs = true;
                    Main.Instance.bp_more_redeem_settings = true;
                    Main.Instance.bp_more_manage_discounts = true;
                    Main.Instance.bp_more_manage_products = true;
                    Main.Instance.bp_more_inventory = true;
                    Main.Instance.bp_more_close_store = true;
                    Main.Instance.bp_more_database = true;
                    Main.Instance.bp_more_settings = true;
                    Main.Instance.bp_pay_payment_method = true;
                    Main.Instance.bp_pay_gift_certificate = true;
                    if (fromMore)
                        RP.More(frmMore);
                    if (fromOrder)
                        RP.Order(Order.Instance);
                    RP.Home(Main.Instance);
                    Close();
                }
                Main.Instance.btnOrder.PerformClick();

            }
            else
            {
                new Notification().PopUp("Incorrect username or password.", "","error");
            }
        }

        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
        }

        private void TxtKeycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
        }

        private void UserBypass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
