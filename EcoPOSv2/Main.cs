using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoPOSControl;
using VeryHotKeys.WinForms;

namespace EcoPOSv2
{
    public partial class Main : GlobalHotKeyForm
    {
        public Main()
        {
            InitializeComponent();
            AddHotKeyRegisterer(ClickOrder, HotKeyMods.None, ConsoleKey.F2);
            AddHotKeyRegisterer(OpenCalculator, HotKeyMods.None, ConsoleKey.F9);
            AddHotKeyRegisterer(ClickXReading, HotKeyMods.None, ConsoleKey.F8);
            AddHotKeyRegisterer(ClickMore, HotKeyMods.None, ConsoleKey.F10);
            AddHotKeyRegisterer(ClickSeeItem, HotKeyMods.Control, ConsoleKey.I);
        }

        private void ClickXReading(object sender, EventArgs e)
        {
            btnXReading.PerformClick();
        }

        private void ClickSeeItem(object sender, EventArgs e)
        {
            btnItemChecker.PerformClick();
        }

        private void ClickMore(object sender, EventArgs e)
        {
            btnMore.PerformClick();
        }

        private void OpenCalculator(object sender, EventArgs e)
        {
            btnCalculator.PerformClick();
        }

        private void ClickOrder(object sender, EventArgs e)
        {
            btnOrder.PerformClick();
        }

        public static Main _main;
        public static Main Instance
        {
            get
            {
                if (_main == null)
                {
                    _main = new Main();
                }
                return _main;
            }
        }
        //VARIABLES
        public string current_id, current_username, current_user_first_name;

        Helper Helper = new Helper();
        FormLoad OL = new FormLoad();
        RolePermission RP = new RolePermission();

        public string dynamicDB;

        public Order frmOrder;

        public DataSet ds = new DataSet();
        public Form currentChildForm;

        public string sd_business_name;
        public string sd_business_address;
        public string sd_business_contact_no;
        public string sd_tax_payer;
        public string sd_vat_reg_tin;
        public string sd_min;
        public string sd_sn;
        public string sd_accreditation_no;
        public string sd_an_date_issued;
        public string sd_an_valid_until;
        public string sd_ptu_no;
        public string sd_pn_date_issued;
        public string sd_pn_valid_until;

        public string rl_footer_text = "";

        public string pd_receipt_printer = "";
        public string pd_report_printer = "";
        public bool pd_customer_display_enabled = false;
        public string pd_customer_display_port = "";

        public bool rp_ord_payment = true;
        public bool rp_ord_customer = true;
        public bool rp_ord_discount = true;
        public bool rp_ord_void_item = true;
        public bool rp_ord_void_transaction = true;
        public bool rp_ord_cancel_transaction = true;
        public bool rp_ord_refund_transaction = true;
        public bool rp_ord_return_exchange = true;
        public bool rp_ord_redeem_item = true;
        public bool rp_home_switch_cashier = true;
        public bool rp_home_more = true;
        public bool rp_more_ejournal = true;
        public bool rp_more_customer_membership = true;
        public bool rp_more_pay_in_out = true;
        public bool rp_more_logs = true;
        public bool rp_more_redeem_settings = true;
        public bool rp_more_manage_discounts = true;
        public bool rp_more_manage_products = true;
        public bool rp_more_inventory = true;
        public bool rp_more_close_store = true;
        public bool rp_more_database = true;
        public bool rp_more_settings = true;
        public bool rp_pay_payment_method = true;
        public bool rp_pay_gift_certificate = true;

        public bool by_pass_user = false;
        public int by_pass_userID;
        public string by_pass_user_name = "";

        public bool bp_ord_payment = true;
        public bool bp_ord_customer = true;
        public bool bp_ord_discount = true;
        public bool bp_ord_void_item = true;
        public bool bp_ord_void_transaction = true;
        public bool bp_ord_cancel_transaction = true;
        public bool bp_ord_refund_transaction = true;
        public bool bp_ord_return_exchange = true;
        public bool bp_ord_redeem_item = true;
        public bool bp_home_switch_cashier = true;
        public bool bp_home_more = true;
        public bool bp_more_ejournal = true;
        public bool bp_more_customer_membership = true;
        public bool bp_more_pay_in_out = true;
        public bool bp_more_logs = true;
        public bool bp_more_redeem_settings = true;
        public bool bp_more_manage_discounts = true;
        public bool bp_more_manage_products = true;
        public bool bp_more_inventory = true;
        public bool bp_more_close_store = true;
        public bool bp_more_database = true;
        public bool bp_more_settings = true;
        public bool bp_pay_payment_method = true;
        public bool bp_pay_gift_certificate = true;

        public List<bool> bypass_list = new List<bool>();
        //VARIABLES

        SQLControl sql = new SQLControl();

        //METHODS
        public static bool PrinterExists(string printerName)
        {
            if (String.IsNullOrEmpty(printerName)) { throw new ArgumentNullException("printerName"); }
            return PrinterSettings.InstalledPrinters.Cast<string>().Any(name => printerName.ToUpper().Trim() == name.ToUpper().Trim());
        }
        public void store_bypass_list()
        {
            bypass_list.Add(bp_ord_payment);
            bypass_list.Add(bp_ord_customer);
            bypass_list.Add(bp_ord_discount);
            bypass_list.Add(bp_ord_void_item);
            bypass_list.Add(bp_ord_void_transaction);
            bypass_list.Add(bp_ord_cancel_transaction);
            bypass_list.Add(bp_ord_refund_transaction);
            bypass_list.Add(bp_ord_return_exchange);
            bypass_list.Add(bp_ord_redeem_item);
            bypass_list.Add(bp_home_switch_cashier);
            bypass_list.Add(bp_home_more);
            bypass_list.Add(bp_more_ejournal);
            bypass_list.Add(bp_more_customer_membership);
            bypass_list.Add(bp_more_pay_in_out);
            bypass_list.Add(bp_more_logs);
            bypass_list.Add(bp_more_redeem_settings);
            bypass_list.Add(bp_more_manage_discounts);
            bypass_list.Add(bp_more_manage_products);
            bypass_list.Add(bp_more_inventory);
            bypass_list.Add(bp_more_close_store);
            bypass_list.Add(bp_more_database);
            bypass_list.Add(bp_more_settings);
            bypass_list.Add(bp_pay_payment_method);
            bypass_list.Add(bp_pay_gift_certificate);
        }

        public void OpenChildForm(Form childform)
        {

            // close current child form
            if (currentChildForm != null)
                currentChildForm.Close();

            // if current child form is the same then do nothing

            if (currentChildForm == childform)
                return;

            // set new child form
            currentChildForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            pnlChild.Controls.Add(childform);
            pnlChild.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }
        private void BindSD()
        {
            SQLControl SQL = new SQLControl();

            SQL.Query("SELECT * FROM store_details WHERE configuration_ID = 1");
            if (SQL.HasException(true))
                return;

            foreach (DataRow dr in SQL.DBDT.Rows)
            {
                sd_business_name = dr["business_name"].ToString();
                sd_business_address = dr["business_address"].ToString();
                sd_business_contact_no = dr["business_contact_no"].ToString();
                sd_tax_payer = dr["tax_payer"].ToString();
                sd_vat_reg_tin = dr["vat_reg_tin"].ToString();
                sd_min = dr["min"].ToString();
                sd_sn = dr["sn"].ToString();
                sd_accreditation_no = dr["accreditation_no"].ToString();
                sd_an_date_issued = dr["an_date_issued"].ToString();
                sd_an_valid_until = dr["an_valid_until"].ToString();
                sd_ptu_no = dr["ptu_no"].ToString();
                sd_pn_date_issued = dr["pn_date_issued"].ToString();
                sd_pn_valid_until = dr["pn_valid_until"].ToString();
            }
        }
        private void BindPD()
        {
            int count_records = Convert.ToInt32(sql.ReturnResult("SELECT COUNT(*) FROM printers_devices"));
            if (sql.HasException(true))
                return;

            if (count_records == 1)
            {
                sql.Query("SELECT * FROM printers_devices WHERE configuration_ID = 2");
                if (sql.HasException(true))
                    return;

                foreach (DataRow dr in sql.DBDT.Rows)
                {
                    pd_receipt_printer = dr["receipt_printer_name"].ToString();
                    pd_report_printer = dr["receipt_printer_name"].ToString();
                    pd_customer_display_enabled = Convert.ToBoolean(dr["customer_display_enabled"].ToString());
                    pd_customer_display_port = dr["customer_display_port"].ToString();
                }
            }
        }
        private void BindRL()
        {
            SQLControl SQL = new SQLControl();

            int count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM receipt_layout"));
            if (SQL.HasException(true))
                return;

            if (count_records == 1)
            {
                SQL.Query("SELECT * FROM receipt_layout WHERE configuration_ID = 1");
                if (SQL.HasException(true))
                    return;

                foreach (DataRow dr in SQL.DBDT.Rows)
                {
                    rl_footer_text = dr["receipt_footer_text"].ToString();
                }   
            }
        }

        public void UpdateMemberCards()
        {
            SQLControl SQL = new SQLControl();

            SQL.Query(" UPDATE member_card SET status = 'Expired' WHERE date_expired < (SELECT GETDATE()) AND activation_span <> 0");

            if (SQL.HasException(true))
                return;
        }

        public void UpdateGiftCards()
        {
            SQLControl SQL = new SQLControl();

            SQL.Query("UPDATE giftcard SET status = 'Expired' WHERE expiration < (SELECT GETDATE())");

            if (SQL.HasException(true))
                return;
        }
        //METHODS
        private void Main_Load(object sender, EventArgs e)
        {
            _main = this;

            btnOrder.PerformClick();

            Order frmOrder = new Order();
            OL.changeForm(frmOrder, currentChildForm, pnlChild);
            frmOrder.tbBarcode.Focus();

            Order.Instance.GetTotal();

            tmrCurrentDateTime.Start();

            BindSD();
            BindPD();
            BindRL();

            UpdateMemberCards();
            UpdateGiftCards();

            store_bypass_list();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Order frmOrder = new Order();
            RP.Order(frmOrder);
            OL.changeForm(frmOrder, currentChildForm, pnlChild);

            Order.Instance.GetTotal();
        }

        private void btnclosetemp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            Devices d = new Devices();
            d.ShowDialog();
        }

        private void btnSeeItem_Click(object sender, EventArgs e)
        {
            SeeItem frmSeeItem = new SeeItem();
            //frmSeeItem.frmOrder = this;
            frmSeeItem.ShowDialog();
        }

        private void btnXReading_Click(object sender, EventArgs e)
        {
            SecureXReading frmSecureXReading = new SecureXReading();

            frmSecureXReading.ShowDialog();
        }

        private void tmrCurrentDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("hh:mm:ss tt , MMM, dd, yyyy");
        }
        private void btnCalculator_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }
    }
}
