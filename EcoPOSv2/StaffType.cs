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
using Guna.UI2.WinForms;
using static EcoPOSv2.GroupAction;

namespace EcoPOSv2
{
    public partial class StaffType : Form
    {
        public StaffType()
        {
            InitializeComponent();
        }

        SQLControl SQL = new SQLControl();
        GroupAction GA = new GroupAction();
        List<Guna2TextBox> requiredFields = new List<Guna2TextBox>();
        string roleID = "";
        List<Control> allTxt = new List<Control>();
        //METHODS
        public static StaffType _StaffType;
        public static StaffType Instance
        {
            get
            {
                if (_StaffType == null)
                {
                    _StaffType = new StaffType();
                }
                return _StaffType;
            }
        }
        private void LoadStaffType()
        {
            SQL.Query("SELECT roleID, name as 'Staff Type' FROM user_role ORDER BY name ASC");
            if (SQL.HasException(true))
                return;

            dgvStaffType.DataSource = SQL.DBDT;
            dgvStaffType.Columns[0].Visible = false;
        }

        private void StaffTypeRF()
        {
            requiredFields = new List<Guna2TextBox>();

            requiredFields.Add(txtStaffType);
        }

        private void ClearFields()
        {
            txtStaffType.Clear();
            roleID = "";
            lblID.Text = "";

            // uncheck all permission
            GA.DoThis(ref allTxt, flpPermission, ControlType.CheckBox, GroupAction.Action.Uncheck);
        }
        //METHODS
        private void StaffType_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            _StaffType = this;
            ClearFields();
            LoadStaffType();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult approval = MessageBox.Show("Delete this item?", "", MessageBoxButtons.YesNo);

            if (approval == DialogResult.Yes)
            {
                if (roleID == "")
                {
                    new Notification().PopUp("No item selected.", "","error");
                    return;
                }

                SQL.AddParam("@roleID", roleID);
                SQL.Query("DELETE FROM user_role WHERE roleID = @roleID");

                if (SQL.HasException(true))
                    return;

                LoadStaffType();
                Staff.Instance.LoadStaffType();

                ClearFields();

                new Notification().PopUp("Item deleted.", "", "information");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StaffTypeRF();

            int requiredFieldsMet = ControlBehavior.GunaRequireField(ref requiredFields);

            if (requiredFieldsMet == 1)
            {
                string action = "Update";
                if (roleID == "")
                    action = "New";

                switch (action)
                {
                    case "New":
                        {
                            // check for duplicate names
                            SQL.AddParam("@name", txtStaffType.Text);
                            int result = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM user_role WHERE name = @name) > 0,'1', '0') as result"));
                            if (SQL.HasException(true))
                                return;

                            if (result == 0)
                            {
                                // insert new user_role
                                SQL.AddParam("@name", txtStaffType.Text);
                                SQL.Query("INSERT INTO user_role (name) VALUES (@name)");
                                if (SQL.HasException(true))
                                    return;

                                // insert new role_permission
                                SQL.AddParam("@ord_payment", cbxOrd_Payment.Checked);
                                SQL.AddParam("@ord_customer", cbxOrd_Customer.Checked);
                                SQL.AddParam("@ord_discount", cbxOrd_Discount.Checked);
                                SQL.AddParam("@ord_void_item", cbxOrd_VoidItem.Checked);
                                SQL.AddParam("@ord_void_transaction", cbxOrd_VoidTransaction.Checked);
                                SQL.AddParam("@ord_cancel_transaction", cbxOrd_CancelTransaction.Checked);
                                SQL.AddParam("@ord_refund_transaction", cbxOrd_RefundTransaction.Checked);
                                SQL.AddParam("@ord_keep_transaction", cbxOrd_KeepTransaction.Checked);
                                SQL.AddParam("@ord_return_exchange", cbxOrd_ReturnExchange.Checked);
                                SQL.AddParam("@ord_redeem_item", cbxOrd_RedeemItem.Checked);
                                SQL.AddParam("@home_switch_cashier", cbxHome_SwitchCashier.Checked);
                                SQL.AddParam("@home_more", cbxHome_More.Checked);
                                SQL.AddParam("@more_customer_membership", cbxMore_CustomerMembership.Checked);
                                SQL.AddParam("@more_ejournal", cbxMore_EJournal.Checked);
                                SQL.AddParam("@more_pay_in_out", false);
                                SQL.AddParam("@more_logs", cbxMore_Logs.Checked);
                                SQL.AddParam("@more_redeem_settings", cbxMore_RedeemSettings.Checked);
                                SQL.AddParam("@more_manage_discounts", cbxMore_ManageDiscounts.Checked);
                                SQL.AddParam("@more_manage_products", cbxMore_ManageProducts.Checked);
                                SQL.AddParam("@more_inventory", cbxMore_Inventory.Checked);
                                SQL.AddParam("@more_close_store", cbxMore_CloseStore.Checked);
                                SQL.AddParam("@more_database", cbxMore_Database.Checked);
                                SQL.AddParam("@more_settings", cbxMore_Settings.Checked);
                                SQL.AddParam("@pay_payment_method", cbxPay_PaymentMethod.Checked);
                                SQL.AddParam("@pay_gift_certificate", cbxPay_GiftCertificate.Checked);

                                SQL.Query(@"INSERT INTO role_permission (roleID, ord_payment, ord_customer, ord_discount, ord_void_item, ord_void_transaction, 
                                        ord_cancel_transaction, ord_refund_transaction, ord_keep_transaction, ord_return_exchange, ord_redeem_item, home_switch_cashier, home_more,
                                        more_ejournal,more_customer_membership, more_pay_in_out, more_logs, more_redeem_settings, more_manage_discounts, more_manage_products, more_inventory,
                                        more_close_store, more_database, more_settings, pay_payment_method, pay_gift_certificate) VALUES ((SELECT MAX(roleID) FROM user_role), 
                                        @ord_payment, @ord_customer, @ord_discount, @ord_void_item, @ord_void_transaction,
                                        @ord_cancel_transaction, @ord_refund_transaction, @ord_keep_transaction, @ord_return_exchange, @ord_redeem_item, @home_switch_cashier, @home_more,
                                        @more_ejournal,@more_customer_membership, @more_pay_in_out, @more_logs, @more_redeem_settings, @more_manage_discounts, @more_manage_products, @more_inventory,
                                        @more_close_store, @more_database, @more_settings, @pay_payment_method, @pay_gift_certificate)");

                                if (SQL.HasException(true))
                                    return;

                                new Notification().PopUp("Data saved.", "", "information");
                                ClearFields();
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }

                    default:
                        {
                            SQL.AddParam("@roleID", roleID);
                            SQL.AddParam("@name", txtStaffType.Text);

                            string result = SQL.ReturnResult(@"SELECT IIF((
                SELECT COUNT(*) as duplicatecount FROM user_role WHERE name = @name AND roleID <> @roleID) > 0,
                1, 0) as result");

                            if (SQL.HasException(true))
                                return;


                            if (result == "0")
                            {
                                SQL.AddParam("@roleID", roleID);
                                SQL.AddParam("@name", txtStaffType.Text);

                                SQL.Query("UPDATE user_role SET name = @name WHERE roleID = @roleID");

                                if (SQL.HasException(true))
                                    return;

                                // role permission

                                SQL.AddParam("@roleID", roleID);
                                SQL.AddParam("@ord_payment", cbxOrd_Payment.Checked);
                                SQL.AddParam("@ord_customer", cbxOrd_Customer.Checked);
                                SQL.AddParam("@ord_discount", cbxOrd_Discount.Checked);
                                SQL.AddParam("@ord_void_item", cbxOrd_VoidItem.Checked);
                                SQL.AddParam("@ord_void_transaction", cbxOrd_VoidTransaction.Checked);
                                SQL.AddParam("@ord_cancel_transaction", cbxOrd_CancelTransaction.Checked);
                                SQL.AddParam("@ord_refund_transaction", cbxOrd_RefundTransaction.Checked);
                                SQL.AddParam("@ord_keep_transaction", cbxOrd_KeepTransaction.Checked);
                                SQL.AddParam("@ord_return_exchange", cbxOrd_ReturnExchange.Checked);
                                SQL.AddParam("@ord_redeem_item", cbxOrd_RedeemItem.Checked);
                                SQL.AddParam("@home_switch_cashier", cbxHome_SwitchCashier.Checked);
                                SQL.AddParam("@home_more", cbxHome_More.Checked);
                                SQL.AddParam("@more_customer_membership", cbxMore_CustomerMembership.Checked);
                                SQL.AddParam("@more_ejournal", cbxMore_EJournal.Checked);
                                SQL.AddParam("@more_pay_in_out", false);
                                SQL.AddParam("@more_logs", cbxMore_Logs.Checked);
                                SQL.AddParam("@more_redeem_settings", cbxMore_RedeemSettings.Checked);
                                SQL.AddParam("@more_manage_discounts", cbxMore_ManageDiscounts.Checked);
                                SQL.AddParam("@more_manage_products", cbxMore_ManageProducts.Checked);
                                SQL.AddParam("@more_inventory", cbxMore_Inventory.Checked);
                                SQL.AddParam("@more_close_store", cbxMore_CloseStore.Checked);
                                SQL.AddParam("@more_database", cbxMore_Database.Checked);
                                SQL.AddParam("@more_settings", cbxMore_Settings.Checked);
                                SQL.AddParam("@pay_payment_method", cbxPay_PaymentMethod.Checked);
                                SQL.AddParam("@pay_gift_certificate", cbxPay_GiftCertificate.Checked);

                                SQL.Query(@"UPDATE role_permission SET ord_payment = @ord_payment, ord_customer = @ord_customer, ord_discount = @ord_discount, 
                                        ord_void_item = @ord_void_item, ord_void_transaction = @ord_void_transaction, ord_cancel_transaction = @ord_cancel_transaction, 
                                        ord_refund_transaction = @ord_refund_transaction, ord_keep_transaction = @ord_keep_transaction, ord_return_exchange = @ord_return_exchange, ord_redeem_item = @ord_redeem_item, 
                                        home_switch_cashier = @home_switch_cashier, home_more = @home_more, more_ejournal = @more_ejournal, more_customer_membership = @more_customer_membership, more_pay_in_out = @more_pay_in_out, 
                                        more_logs = @more_logs, more_redeem_settings = @more_redeem_settings, more_manage_discounts = @more_manage_discounts, 
                                        more_manage_products = @more_manage_products, more_inventory = @more_inventory, more_close_store = @more_close_store, more_database = @more_database,
                                        more_settings = @more_settings, pay_payment_method = @pay_payment_method, pay_gift_certificate = @pay_gift_certificate where roleID=@roleID");

                                new Notification().PopUp("Data saved.", "", "information");
                                roleID = "";
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }
                }

                LoadStaffType();
                Staff.Instance.LoadStaffType();

                lblID.Text = "";
            }
            else
                new Notification().PopUp("Please fill all required fields.", "Save failed", "error" );
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvStaffType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@roleID", dgvStaffType.CurrentRow.Cells[0].Value.ToString());

            SQL.Query(@"SELECT *, role_permission.*, user_role.roleID as 'uroleID' FROM user_role INNER JOIN role_permission ON 
                       user_role.roleID = role_permission.roleID WHERE user_role.roleID = @roleID");

            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                roleID = r["uroleID"].ToString();
                txtStaffType.Text = r["name"].ToString();
                lblID.Text = r["uroleID"].ToString();

                // load permission
                cbxOrd_Payment.Checked = Convert.ToBoolean(r["ord_payment"].ToString());
                cbxOrd_Customer.Checked = Convert.ToBoolean(r["ord_customer"].ToString());
                cbxOrd_Discount.Checked = Convert.ToBoolean(r["ord_discount"].ToString());
                cbxOrd_VoidItem.Checked = Convert.ToBoolean(r["ord_void_item"].ToString());
                cbxOrd_VoidTransaction.Checked = Convert.ToBoolean(r["ord_void_transaction"].ToString());
                cbxOrd_CancelTransaction.Checked = Convert.ToBoolean(r["ord_cancel_transaction"].ToString());
                cbxOrd_RefundTransaction.Checked = Convert.ToBoolean(r["ord_refund_transaction"].ToString());
                cbxOrd_KeepTransaction.Checked = Convert.ToBoolean(r["ord_keep_transaction"].ToString());
                cbxOrd_ReturnExchange.Checked = Convert.ToBoolean(r["ord_return_exchange"].ToString());
                cbxOrd_RedeemItem.Checked = Convert.ToBoolean(r["ord_redeem_item"].ToString());
                cbxHome_SwitchCashier.Checked = Convert.ToBoolean(r["home_switch_cashier"].ToString());
                cbxHome_More.Checked = Convert.ToBoolean(r["home_more"].ToString());
                cbxHome_More.Checked = Convert.ToBoolean(r["home_more"].ToString());
                cbxMore_EJournal.Checked = Convert.ToBoolean(r["more_ejournal"].ToString());
                cbxMore_PayInOut.Checked = Convert.ToBoolean(r["more_pay_in_out"].ToString());
                cbxMore_Logs.Checked = Convert.ToBoolean(r["more_logs"].ToString());
                cbxMore_RedeemSettings.Checked = Convert.ToBoolean(r["more_redeem_settings"].ToString());
                cbxMore_ManageDiscounts.Checked = Convert.ToBoolean(r["more_manage_discounts"].ToString());
                cbxMore_ManageProducts.Checked = Convert.ToBoolean(r["more_manage_products"].ToString());
                cbxMore_Inventory.Checked = Convert.ToBoolean(r["more_inventory"].ToString());
                cbxMore_CloseStore.Checked = Convert.ToBoolean(r["more_close_store"].ToString());
                cbxMore_Database.Checked = Convert.ToBoolean(r["more_database"].ToString());
                cbxMore_Settings.Checked = Convert.ToBoolean(r["more_settings"].ToString());
                cbxPay_PaymentMethod.Checked = Convert.ToBoolean(r["pay_payment_method"].ToString());
                cbxPay_GiftCertificate.Checked = Convert.ToBoolean(r["pay_gift_certificate"].ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
