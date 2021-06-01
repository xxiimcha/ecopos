using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
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

        //METHODS
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

        //METHODS
        private void Main_Load(object sender, EventArgs e)
        {
            _main = this;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Order frmOrder = new Order();
            RP.Order(frmOrder);
            OL.changeForm(frmOrder, currentChildForm, pnlChild);
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
