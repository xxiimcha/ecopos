using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeryHotKeys.WinForms;

namespace EcoPOSv2
{
    public partial class Payment : GlobalHotKeyForm
    {
        public Payment()
        {
            InitializeComponent();
            AddHotKeyRegisterer(Print, HotKeyMods.None, ConsoleKey.Enter);
            AddHotKeyRegisterer(GiftCard, HotKeyMods.None, ConsoleKey.F2);
            AddHotKeyRegisterer(Exact, HotKeyMods.None, ConsoleKey.Spacebar);
            AddHotKeyRegisterer(Remove, HotKeyMods.None, ConsoleKey.F3);
        }

        private void Remove(object sender, EventArgs e)
        {
            btnRemoveGC.PerformClick();
        }

        private void Exact(object sender, EventArgs e)
        {
            btnExact.PerformClick();
        }

        private void GiftCard(object sender, EventArgs e)
        {
            btnGC.PerformClick();
        }

        private void Print(object sender, EventArgs e)
        {
            btnPay.PerformClick();
        }

        //VARIABLES
        private SQLControl SQL = new SQLControl();
        private FormLoad OL = new FormLoad();
        public Order frmOrder;
        public int action;
        public decimal card_balance = 0m;
        public decimal change;
        public decimal grand_total;
        public decimal total;
        private string note = " ";
        public PaymentR report;
        //VARIABLES

        //METHODS
        public static Payment _Payment;
        public static Payment Instance
        {
            get
            {
                if (_Payment == null)
                {
                    _Payment = new Payment();
                }
                return _Payment;
            }
        }

        public void Advance_OrderNo()
        {
            SQL.Query(@"INSERT INTO order_no (order_no)
                       SELECT (order_no + 1) FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)");

            if (SQL.HasException(true))
                return;

            frmOrder.LoadOrderNo();
        }
        private void GenerateReceipt()
        {
            bool checkprinter = Main.PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("Printer is offline", "", "error");
                return;
            }
            else if (checkprinter == true)
            {
                DataSet ds = new DataSet();

                report = new PaymentR();

                try
                {
                    SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, static_price_inclusive, selling_price_inclusive FROM transaction_items WHERE order_ref = (SELECT MAX(order_ref) FROM transaction_details)", SQL.DBCon);
                    SQL.DBDA.Fill(ds, "transaction_items");

                    report.SetDataSource(ds);

                    SQL.Query("IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users SELECT * INTO #Temp_users FROM (SELECT ID, user_name, first_name FROM(SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts UNION ALL SELECT userID, user_name, first_name FROM users ) x ) as a; SELECT date_time,order_ref_temp, u.first_name as 'user_first_name',  no_of_items,  subtotal,  less_vat,  disc_amt,  cus_pts_deducted,  grand_total, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, payment_amt,  change, giftcard_no,giftcard_deducted, IIF(cus_name = '', '0', cus_name) as 'cus_name', cus_special_ID_no, refund_order_ref_temp, return_order_ref_temp, payment_method FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID WHERE order_ref = (SELECT MAX(order_ref) FROM transaction_details)");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("date_time", r["date_time"].ToString());
                        report.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        report.SetParameterValue("no_of_items", r["no_of_items"].ToString());

                        decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                        report.SetParameterValue("subtotal", subtotal.ToString("N2"));

                        decimal less_vat = decimal.Parse(r["less_vat"].ToString());
                        report.SetParameterValue("less_vat", less_vat.ToString("N2"));

                        decimal disc_amt = decimal.Parse(r["disc_amt"].ToString());
                        report.SetParameterValue("discount", disc_amt.ToString("N2"));

                        decimal cus_pts_deducted = decimal.Parse(r["cus_pts_deducted"].ToString());
                        report.SetParameterValue("points_deduct", cus_pts_deducted.ToString("N2"));

                        decimal giftcard_deducted = decimal.Parse(r["giftcard_deducted"].ToString());
                        report.SetParameterValue("giftcard_deduct", giftcard_deducted.ToString("N2"));

                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                        report.SetParameterValue("total", grand_total.ToString("N2"));

                        decimal vatable_sale = decimal.Parse(r["vatable_sale"].ToString());
                        report.SetParameterValue("vatable_sales", vatable_sale.ToString("N2"));

                        decimal vat_12 = decimal.Parse(r["vat_12"].ToString());
                        report.SetParameterValue("vat_12", vat_12.ToString("N2"));

                        decimal vat_exempt_sale = decimal.Parse(r["vat_exempt_sale"].ToString());
                        report.SetParameterValue("vat_exempt_sales", vat_exempt_sale.ToString("N2"));

                        decimal zero_rated_sale = decimal.Parse(r["zero_rated_sale"].ToString());
                        report.SetParameterValue("zero_rated_sales", zero_rated_sale.ToString("N2"));

                        decimal giftcard_no = decimal.Parse(r["giftcard_no"].ToString());
                        report.SetParameterValue("giftcard_no", giftcard_no.ToString("N2"));

                        decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                        report.SetParameterValue("cash", payment_amt.ToString("N2"));

                        decimal change = decimal.Parse(r["change"].ToString());
                        report.SetParameterValue("change", change.ToString("N2"));

                        report.SetParameterValue("cus_name", r["cus_name"].ToString());
                        report.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                        report.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());

                    }

                    report.SetParameterValue("business_name", Main.Instance.sd_business_name);
                    report.SetParameterValue("business_address", Main.Instance.sd_business_address);
                    report.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                    report.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                    report.SetParameterValue("sn", Main.Instance.sd_sn);
                    report.SetParameterValue("min", Main.Instance.sd_min);
                    report.SetParameterValue("footer_text", Main.Instance.sd_footer_text);
                    report.SetParameterValue("ptu_no", Main.Instance.sd_ptu_no);

                    DateTime dateissue = DateTime.Parse(Main.Instance.sd_pn_date_issued);
                    report.SetParameterValue("date_issued", dateissue.ToString("MM/dd/yyyy"));

                    DateTime validuntil = DateTime.Parse(Main.Instance.sd_pn_valid_until);
                    report.SetParameterValue("valid_until", validuntil.ToString("MM/dd/yyyy"));


                    if (Properties.Settings.Default.dbName == "EcoPOS")
                    {
                        report.SetParameterValue("is_vatable", true);
                        report.SetParameterValue("txt_footer", "This serves as Official Receipt.");
                    }
                    else
                    {
                        report.SetParameterValue("is_vatable", false);
                        report.SetParameterValue("txt_footer", "This serves as Demo Receipt.");
                    }

                    int no_of_prints = 1;

                    if (frmOrder.apply_regular_discount_fix_amt | frmOrder.apply_special_discount | frmOrder.apply_member)
                        no_of_prints = 2;

                    for (var i = 1; i <= no_of_prints; i++)
                    {
                        if (i == 1)
                            report.SetParameterValue("note", note + "CUSTOMERS COPY");
                        if (i == 2)
                            report.SetParameterValue("note", note + "ACCOUNTING COPY");

                        PrintReceipt();
                    }

                    PChange pchange = new PChange();

                    pchange.lblChange.Text = lblChange.Text;
                    pchange.Show();


                    //temporary
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    report.Dispose();
                }
            }
        }
        public void PrintReceipt()
        {
            if (Main.Instance.pd_receipt_printer == "")
            {
                MessageBox.Show("No receipt printer selected.", "Error printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                report.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                report.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                report.PrintToPrinter(1, false, 0, 0);
            }
        }
        //METHODS


        private void Payment_Load(object sender, EventArgs e)
        {
            _Payment = this;

            cmbMethod.SelectedIndex = 0;
        }
        private void btnExact_Click(object sender, EventArgs e)
        {
            txtAmount.Text = lblGrandTotal.Text;
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            #region transaction_details

            if (action == 1)
            {
                if (change < 0)
                    return;
            }

            btnPay.Enabled = false;

            SQL.AddParam("@no_of_items", Convert.ToDecimal(frmOrder.lblItems.Text));
            SQL.AddParam("@cus_pts_deducted", lblDeductPoints.Text);
            SQL.AddParam("@giftcard_deducted", lblDeductGC.Text);
            SQL.AddParam("@subtotal", Convert.ToDecimal(frmOrder.lblSubtotal.Text));
            SQL.AddParam("@fix_discount", Convert.ToDecimal(frmOrder.regular_disc_amt));
            SQL.AddParam("@total", Convert.ToDecimal(frmOrder.lblTotal.Text));
            SQL.AddParam("@grand_total", Convert.ToDecimal(lblGrandTotal.Text));
            SQL.AddParam("@payment_amt", Convert.ToDecimal(txtAmount.Text));
            SQL.AddParam("@change", change);
            SQL.AddParam("@payment_method", cmbMethod.Text);
            SQL.AddParam("@giftcard_no", lblGCNo.Text);
            SQL.AddParam("@less_vat", Convert.ToDecimal(frmOrder.lblLessVAT.Text));
            SQL.AddParam("@vatable_sale", Convert.ToDecimal(frmOrder.lblVATSale.Text));
            SQL.AddParam("@vat_12", Convert.ToDecimal(frmOrder.lblVAT.Text));
            SQL.AddParam("@vat_exempt_sale", Convert.ToDecimal(frmOrder.lblVATExempt.Text));
            SQL.AddParam("@zero_rated_sale", Convert.ToDecimal(frmOrder.lblZeroRated.Text));
            SQL.AddParam("@userID", Main.Instance.current_id);
            SQL.AddParam("@user_first_name", Main.Instance.current_user_first_name);
            SQL.Query(@"INSERT INTO transaction_details 
                       (order_ref, order_no, action, discountID, cus_ID_no, cus_special_ID_no, cus_type, cus_name, cus_mem_ID, cus_rewardable, cus_amt_per_pt, refund_order_ref, return_order_ref, 
                       no_of_items, subtotal, disc_amt, total, cus_pts_deducted, giftcard_deducted, grand_total, payment_amt, change, payment_method, giftcard_no, 
                       less_vat, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, userID, user_first_name) 
                       SELECT order_ref, order_no, action, discountID, cus_ID_no, cus_special_ID_no, cus_type, cus_name, cus_mem_ID, cus_rewardable, cus_amt_per_pt, refund_order_ref, return_order_ref,  
                       @no_of_items, @subtotal, IIF((SELECT SUM(discount) + @fix_discount FROM order_cart) > 1300, 1300, (SELECT SUM(discount) + @fix_discount FROM order_cart)), @total, @cus_pts_deducted, 
                       @giftcard_deducted, @grand_total, @payment_amt, @change, @payment_method, @giftcard_no, @less_vat, @vatable_sale, @vat_12, @vat_exempt_sale, 
                       @zero_rated_sale, @userID, @user_first_name FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)");
            if (SQL.HasException(true))
            {
                MessageBox.Show("1");
                return;
            }
               


            #endregion

            #region transaction_items

            SQL.Query(@"INSERT INTO transaction_items (order_ref, itemID, productID, description, name, type, static_price_exclusive,
                           static_price_vat, static_price_inclusive, selling_price_exclusive, selling_price_vat, selling_price_inclusive,
                           quantity, discount, is_less_vat, less_vat, is_vat_exempt, is_disc_percent, disc_percent, is_refund, is_return)
                           SELECT (SELECT MAX(order_ref) FROM transaction_details), itemID, productID, description, name, type, static_price_exclusive,
                           static_price_vat, static_price_inclusive, selling_price_exclusive, selling_price_vat, selling_price_inclusive,
                           quantity, discount, is_less_vat, less_vat, is_vat_exempt, is_disc_percent, disc_percent, is_refund, is_return FROM order_cart");
            if (SQL.HasException(true))
            {
                MessageBox.Show("2");
                return;
            }
                

            #endregion

            #region remove/add to inventory

            SQL.Query("SELECT productID, quantity, is_return, is_refund FROM order_cart");
            if (SQL.HasException(true))
            {
                MessageBox.Show("3");
                return;
            }
            foreach (DataRow r in SQL.DBDT.Rows)
            {
                SQL.AddParam("@productID", r["productID"].ToString());
                SQL.AddParam("@quantity", r["quantity"].ToString());
                if (Convert.ToBoolean(r["is_return"].ToString()) || Convert.ToBoolean(r["is_refund"].ToString()))
                {
                    SQL.Query("UPDATE inventory SET stock_qty = stock_qty + @quantity WHERE productID = @productID");
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("4");
                        return;
                    }
                }
                else
                {
                    SQL.Query("UPDATE inventory SET stock_qty = stock_qty - @quantity WHERE productID = @productID");
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("5");
                        return;
                    }
                }
            }

            #endregion

            #region increase customer points

            if (action == 1 && lblCustomerID.Text != "0" && cbxUsePoints.Checked == false)
            {
                bool rewardable = Convert.ToBoolean(SQL.ReturnResult("SELECT cus_rewardable FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)".ToString()));
                if (SQL.HasException(true))
                    return;
                if (rewardable)
                {
                    decimal cus_amt_per_pt = Convert.ToDecimal(SQL.ReturnResult("SELECT cus_amt_per_pt FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)").ToString());
                    if (SQL.HasException(true))
                        return;
                    SQL.AddParam("@customerID", lblCustomerID.Text);
                    SQL.AddParam("@cash_paid", decimal.Parse(txtAmount.Text));
                    SQL.AddParam("@cus_amt_per_pt", cus_amt_per_pt);
                    SQL.Query(@"INSERT INTO points_award (order_ref, cus_ID_no, cash_paid, pts_earned)
                           SELECT MAX(order_ref), @customerID, @cash_paid, (@cash_paid / @cus_amt_per_pt) FROM transaction_details");
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("6");
                        return;
                    }

                    // update card balance

                    SQL.AddParam("@customerID", lblCustomerID.Text);
                    SQL.AddParam("@cash_paid", decimal.Parse(txtAmount.Text));
                    SQL.AddParam("@cus_amt_per_pt", cus_amt_per_pt);
                    SQL.Query("UPDATE member_card SET card_balance = card_balance + (@cash_paid / @cus_amt_per_pt) WHERE customerID = @customerID");
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("7");
                        return;
                    }
                }
            }

            if (action == 1 && cbxUsePoints.Checked == true)
            {
                // update card balance

                SQL.AddParam("@customerID", lblCustomerID.Text);
                SQL.AddParam("@cash_paid", lblGrandTotal.Text);
                SQL.Query("UPDATE member_card SET card_balance = card_balance - @cash_paid WHERE customerID = @customerID");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("8");
                    return;
                }
            }

            #endregion

            #region gift card

            if (lblGCNo.Text != "0")
            {
                SQL.AddParam("@giftcard_no", lblGCNo.Text);
                SQL.Query("UPDATE giftcard SET status = 'Used' WHERE giftcard_no = @giftcard_no");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("9");
                    return;
                }
            }

            #endregion

            #region clear cart

            SQL.Query("DELETE FROM order_cart");
            if (SQL.HasException(true))
                return;

            #endregion

            GenerateReceipt();

            #region reset values

            //frmOrder.apply_regular_discount_fix_amt = false;
            //frmOrder.apply_special_discount = false;
            //frmOrder.apply_member = false;
            //frmOrder.tbBarcode.Enabled = true;
            //frmOrder.lblCustomer.Text = "";
            //frmOrder.lblOperation.Text = "Order/Payment";
            //frmOrder.regular_disc_amt = 0;
            //frmOrder.is_refund = false;
            //frmOrder.is_return = false;

            #endregion

            //this.Close();
        }

        private void btnRemoveGC_Click(object sender, EventArgs e)
        {
            decimal deduct_gc = decimal.Parse(lblDeductGC.Text);
            //grand_total = grand_total + deduct_gc;
            lblGrandTotal.Text = grand_total.ToString("N2");
            lblGCNo.Text = "0";
            lblDeductGC.Text = "0.00";
            btnExact.Enabled = true;
            txtAmount.Enabled = true;
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            PGiftCard frmPGiftCard = new PGiftCard();
            frmPGiftCard.frmPayment = this;
            frmPGiftCard.ShowDialog();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            decimal deductpoints = decimal.Parse(lblDeductPoints.Text);
            decimal deductGC = decimal.Parse(lblDeductGC.Text);

            if (txtAmount.Text == "")
            {
                txtAmount.SelectAll();
                decimal total = 0M;

                decimal amount = total;

                change = (amount + deductGC) - grand_total;
                lblChange.Text = change.ToString("N2");

            }
            else
            {
                try
                {
                    decimal amount = decimal.Parse(txtAmount.Text);

                    change = (amount + deductpoints + deductGC) - grand_total;

                    lblChange.Text = change.ToString("N2");
                }
                catch (Exception) { }
            }

            txtAmount.Text = txtAmount.Text.Replace(" ", "");
            txtAmount.SelectionStart = txtAmount.Text.Length;
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if(e.KeyCode == Keys.Space)
            {
                btnExact.PerformClick();
            }
        }

        private void Payment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Order.Instance.ActiveControl = Order.Instance.tbBarcode;
        }

        private void cbxUsePoints_CheckedChanged(object sender, EventArgs e)
        {
            decimal deduct_points = decimal.Parse(lblDeductPoints.Text);
            decimal total = decimal.Parse(lblTotal.Text);

            if (cbxUsePoints.Checked == true)
            {
                lblDeductPoints.Text = cbxUsePoints.Text;
                lblChange.Text = "-" + lblGrandTotal.Text;
            }
            else if (cbxUsePoints.Checked == false/* && total > deduct_points*/)
            {
                txtAmount.Enabled = true;
                btnExact.Enabled = true;

                //grand_total = grand_total + deduct_points;

                lblRemainingPoints.Text = "0.00";
                lblGrandTotal.Text = total.ToString("N2");
                lblChange.Text = "-" + lblGrandTotal.Text;
                lblDeductPoints.Text = "0.00";
                txtAmount.Text = "";
            }
            //else
            //{
            //    txtAmount.Enabled = true;
            //    btnExact.Enabled = true;

            //    lblRemainingPoints.Text = "0.00";
            //    lblGrandTotal.Text = lblTotal.Text;
            //    lblDeductPoints.Text = "0.00";
            //}
        }
        private void lblDeductPoints_TextChanged_1(object sender, EventArgs e)
        {
            decimal deduct_points = decimal.Parse(lblDeductPoints.Text);
            decimal total = decimal.Parse(lblTotal.Text);

            if (cbxUsePoints.Checked)
            {
                //grand_total = grand_total - deduct_points;

                if(deduct_points > total)
                {
                    deduct_points = deduct_points - total;
                    lblGrandTotal.Text = "0.00";

                    lblChange.Text = "0.00";

                    lblRemainingPoints.Text = deduct_points.ToString("N2");

                    txtAmount.Enabled = false;
                    btnExact.Enabled = false;
                }
                else
                {
                    btnExact.Enabled = true;
                    txtAmount.Enabled = true;

                    total = total - deduct_points;
                    lblGrandTotal.Text = total.ToString("N2");
                }

                //lblGrandTotal.Text = grand_total.ToString("N2");
            }
        }

        private void lblDeductGC_TextChanged(object sender, EventArgs e)
        {
            decimal deduct_gc = decimal.Parse(lblDeductGC.Text);
            decimal total = decimal.Parse(lblTotal.Text);

            if (deduct_gc != 0)
            {
                cmbMethod.Text = "Gift Certificate";
                //grand_total = grand_total - deduct_gc;

                if (deduct_gc > total)
                {
                    deduct_gc = deduct_gc - total;
                    lblGrandTotal.Text = "0.00";
                    
                    txtAmount.Text = "0";
                    txtAmount.Enabled = false;
                    btnExact.Enabled = false;

                    change = 0;
                    lblChange.Text = "0.00";
                }
                else if(total > deduct_gc)
                {
                    btnExact.Enabled = true;
                    txtAmount.Enabled = true;

                    total = total - deduct_gc;

                    //change = total;

                    lblGrandTotal.Text = total.ToString("N2");

                    lblChange.Text = "-" + lblGrandTotal.Text;
                }

                //lblGrandTotal.Text = grand_total.ToString("N2");
            }
            else
            {
                btnExact.Enabled = true;
                txtAmount.Enabled = true;

                total = total - deduct_gc;
                lblGrandTotal.Text = total.ToString("N2");

                lblChange.Text = "-" + lblGrandTotal.Text;

                cmbMethod.Text = "Cash";
            }
        }
    }
}
