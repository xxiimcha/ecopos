using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoPOSControl;

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
        public string current_id, current_username, current_user_first_name,roleid;

        Helper Helper = new Helper();
        public FormLoad OL = new FormLoad();
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
        public string sd_footer_text = "";

        public string pd_receipt_printer = "";
        public string pd_report_printer = "";
        public bool pd_customer_display_enabled = false;
        public string pd_customer_display_port = "";

        //AUTOBACKUP
        public bool endOfShift, endOfDay, bytime;

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
            try
            {
                if (String.IsNullOrEmpty(printerName)) { throw new ArgumentNullException("printerName"); }
            }
            catch (Exception) { }

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

            SQL.Query("SELECT * FROM store_details WHERE configuration_ID = (select max(configuration_ID) from store_details)");
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
            sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            int count_records = Convert.ToInt32(sql.ReturnResult("SELECT COUNT(*) FROM printers_devices where terminal_id=@terminal_id"));
            if (sql.HasException(true))
                return;

            if (count_records == 1)
            {
                sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                sql.Query("SELECT * FROM printers_devices where terminal_id=@terminal_id");
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
                SQL.Query("SELECT * FROM receipt_layout WHERE configuration_ID = (select max(configuration_ID) from receipt_layout)");
                if (SQL.HasException(true))
                    return;

                foreach (DataRow dr in SQL.DBDT.Rows)
                {
                    sd_footer_text = dr["receipt_footer_text"].ToString();
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
        void CreateProfit()
        {
            Thread td = new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    //string userfirstname = Main.Instance.current_user_first_name.ToString();
                    SQLControl SQL = new SQLControl();
                    SQL.AddParam("@date", DateTime.Now.ToString("yyy-MM-dd"));
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                    //SQL.AddParam("@user_first_name", userfirstname);
                    int check = int.Parse(SQL.ReturnResult("select count(*) from profit where date=@date AND terminal_id=@terminal_id"));
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("Main profit error 1");
                        return;
                    }

                    if (check == 0)
                    {
                        SQL.AddParam("@date", DateTime.Now.ToString("yyy-MM-dd"));
                        SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                        //SQL.AddParam("@user_first_name", userfirstname);
                        SQL.Query("Insert into profit (Sales,Total_Cost,Gross,date,terminal_id) VALUES (0,0,0,@date,@terminal_id)");
                        if (SQL.HasException(true))
                        {
                            MessageBox.Show("Main Profit error 2");
                            return;
                        }
                    }
                }));
            });

            td.IsBackground = true;
            td.Start();
        }
        //METHODS
        private void Main_Load(object sender, EventArgs e)
        {
            lblTerminalName.Text = "Terminal Name: " + Properties.Settings.Default.Terminal_id;

            //SERVER TYPE OR NOT
            if (Properties.Settings.Default.servertype == true)
            {
                lblTerminalName.Visible = true;
                lblType.Text = "ECOPOS SERVER-TYPE";
            }
            else
            {
                lblTerminalName.Visible = false;
                lblType.Text = "ECOPOS STAND-ALONE";
            }

            FormLoad Fl = new FormLoad();
            Fl.CusDisplay("Hello", "Welcome!");

            CreateProfit();

            lblVersion.Text = SplashScreen.Instance.lblVersion.Text;

            if (Properties.Settings.Default.isBirAccredited)
            {
                lblTraningMode.Visible = false;
            }
            else
            {
                lblTraningMode.Visible = true;
            }

            _main = this;

            btnOrder.PerformClick();

            //Order frmOrder = new Order();
            //OL.changeForm(frmOrder, currentChildForm, pnlChild);
            //frmOrder.tbBarcode.Focus();

            //Order.Instance.GetTotal();

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
            btnItemChecker.Enabled = true;
            
            Order frmOrder = new Order();
            RP.Order(frmOrder);
            OL.changeForm(frmOrder, currentChildForm, pnlChild);
        }

        private void btnclosetemp_Click(object sender, EventArgs e)
        {
            if(lblUser.Text == "Bypassed")
            {
                this.close = true;
                Close();
                return;
            }


            close = true;
            Application.Exit();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            btnItemChecker.Enabled = false;
            
            More m = new More();

            RP.More(m);
            OL.changeForm(m, currentChildForm, pnlChild);

            Order.Instance.Close();
        }

        private void btnSeeItem_Click(object sender, EventArgs e)
        {
            if (lblUser.Text == "Bypassed")
            {
                MessageBox.Show("Please login properly to proceed.", "Error(No user found)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Order.Instance.CheckOpened("SeeItem") == true)
            {
                return;
            }
            Order.Instance.dgvCart.ClearSelection();

            new SeeItem().ShowDialog();

            SeeItem.Instance.ActiveControl = SeeItem.Instance.txtBarcode;
        }

        private void btnXReading_Click(object sender, EventArgs e)
        {
            if(lblUser.Text == "Bypassed")
            {
                MessageBox.Show("Please login properly to proceed.", "Error(No user found)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Order.Instance.dgvCart.Rows.Count > 0)
            {
                new Notification().PopUp("Please clear the cart first to proceed", "Error", "error");
                return;
            }

            SecureXReading frmSecureXReading = new SecureXReading();

            frmSecureXReading.ShowDialog();
        }
        public bool close = false;
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(close == false)
            {
                e.Cancel = true;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true;
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                try
                {
                    Login.Instance.LoadPermissions(int.Parse(roleid));
                    RP.Home(Main.Instance);
                    btnOrder.PerformClick();
                }
                catch (Exception) { }
            }

            if (e.KeyCode == Keys.F2)
            {
                if (btnOrder.Enabled == true)
                    btnOrder.PerformClick();
                else return;
            }

            if(e.KeyCode == Keys.F8)
            {
                if (btnXReading.Enabled == true)
                    btnXReading.PerformClick();
                else return;
            }

            if(e.KeyCode == Keys.F9)
            {
                if (btnCalculator.Enabled == true)
                    btnCalculator.PerformClick();
                else return;
            }

            if (e.KeyCode == Keys.F10)
            {
                if (btnMore.Enabled == true)
                    btnMore.PerformClick();
                else return;
            }

            if(e.Control && e.KeyCode == Keys.I)
            {
                if (btnItemChecker.Enabled == true)
                    btnItemChecker.PerformClick();
                else return;
            }

            if(e.KeyCode == Keys.F11)
            {
                UserBypass frmUserBypass = new UserBypass();
                frmUserBypass.fromOrder = true;
                frmUserBypass.ShowDialog();
            }

            if(e.KeyCode == Keys.F12)
            {
                for (int i = 0; i < Main.Instance.bypass_list.Count; i++)
                {
                    Main.Instance.bypass_list[i] = false;
                }

                Main.Instance.by_pass_user = false;
                Main.Instance.by_pass_userID = 0;
                Main.Instance.by_pass_user_name = "";
                Main.Instance.lblByPassUser.Text = "";


                if(roleid != "")
                {
                    Login.Instance.LoadPermissions(int.Parse(roleid));
                    RP.Home(Main.Instance);

                    Main.Instance.btnOrder.PerformClick();
                }
            }
        }

        private void tmrCurrentDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("hh:mm:ss tt , MMM, dd, yyyy");

            if (lblDateTime.Text.Contains(sql.ReturnResult("SELECT backup_time FROM backup_setting")))
            {
                try
                {
                    Boolean EnableSaveByTime = Boolean.Parse(sql.ReturnResult("SELECT backup_by_time FROM backup_setting"));
                    if (EnableSaveByTime)
                    {
                        DatabaseManagement.Instance.BackupDatabaseInFolder();
                    }
                }
                catch (Exception) { }
            }
        }
        private void btnCalculator_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
            //if (Order.Instance.CheckOpened("Calculator") == true)
            //{
            //    return;
            //}

            //new Calculator().Show();
        }
    }
}
