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
                    SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, static_price_inclusive FROM transaction_items WHERE order_ref = (SELECT MAX(order_ref) FROM transaction_details)", SQL.DBCon);
                    SQL.DBDA.Fill(ds, "transaction_items");

                    report.SetDataSource(ds);

                    SQL.Query("IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users SELECT * INTO #Temp_users FROM (SELECT ID, user_name, first_name FROM(SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts UNION ALL SELECT userID, user_name, first_name FROM users ) x ) as a; SELECT date_time,order_ref_temp, u.first_name as 'user_first_name',  no_of_items,  subtotal,  less_vat,  disc_amt,  cus_pts_deducted,  grand_total, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, payment_amt,  change, giftcard_no,giftcard_deducted, IIF(cus_name = '', '0', cus_name) as 'cus_name', cus_special_ID_no, refund_order_ref_temp, return_order_ref_temp FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID WHERE order_ref = (SELECT MAX(order_ref) FROM transaction_details)");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("date_time", r["date_time"].ToString());
                        report.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        report.SetParameterValue("no_of_items", r["no_of_items"].ToString());
                        report.SetParameterValue("subtotal", Math.Round(decimal.Parse(r["subtotal"].ToString()), 2).ToString());
                        report.SetParameterValue("less_vat", Math.Round(decimal.Parse(r["less_vat"].ToString()), 2).ToString());
                        report.SetParameterValue("discount", Math.Round(decimal.Parse(r["disc_amt"].ToString()), 2).ToString());
                        report.SetParameterValue("points_deduct", Math.Round(decimal.Parse(r["cus_pts_deducted"].ToString()), 2).ToString());
                        report.SetParameterValue("giftcard_deduct", Math.Round(decimal.Parse(r["giftcard_deducted"].ToString()), 2).ToString());
                        report.SetParameterValue("total", Math.Round(decimal.Parse(r["grand_total"].ToString()), 2).ToString());
                        report.SetParameterValue("vatable_sales", Math.Round(decimal.Parse(r["vatable_sale"].ToString()), 2).ToString());
                        report.SetParameterValue("vat_12", Math.Round(decimal.Parse(r["vat_12"].ToString()), 2).ToString());
                        report.SetParameterValue("vat_exempt_sales", Math.Round(decimal.Parse(r["vat_exempt_sale"].ToString()), 2).ToString());
                        report.SetParameterValue("zero_rated_sales", Math.Round(decimal.Parse(r["zero_rated_sale"].ToString()), 2).ToString());
                        report.SetParameterValue("giftcard_no", Math.Round(decimal.Parse(r["giftcard_no"].ToString()), 2).ToString());
                        report.SetParameterValue("cash", Math.Round(decimal.Parse(r["payment_amt"].ToString()), 2).ToString());
                        report.SetParameterValue("change", Math.Round(decimal.Parse(r["change"].ToString()), 2).ToString());
                        report.SetParameterValue("cus_name", r["cus_name"].ToString());
                        report.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());

                    }

                    report.SetParameterValue("business_name", Main.Instance.sd_business_name);
                    report.SetParameterValue("business_address", Main.Instance.sd_business_address);
                    report.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                    report.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                    report.SetParameterValue("sn", Main.Instance.sd_sn);
                    report.SetParameterValue("min", Main.Instance.sd_min);
                    report.SetParameterValue("footer_text", Main.Instance.rl_footer_text);

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

                    PChange frmPChange = new PChange();
                    frmPChange.frmPayment = this;
                    frmPChange.lblChange.Text = lblChange.Text;
                    frmPChange.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    report.Dispose();
                }
            }
        }

        //private void GenerateReceipt()
        //{
        //    bool checkprinter = PrinterExists(Main.Instance.pd_receipt_printer);

        //    if (checkprinter == false)
        //    {
        //        MessageBox.Show("Printer is offline", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }


        //    DataSet ds = new DataSet();

        //    report = new PaymentR();

        //    SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, static_price_inclusive FROM transaction_items WHERE order_ref = (SELECT MAX(order_ref) FROM transaction_details)", SQL.DBCon);
        //    SQL.DBDA.Fill(ds, "transaction_items");

        //    report.SetDataSource(ds);

        //    SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
        //                   SELECT * INTO #Temp_users
        //                   FROM
        //                   (
        //                   SELECT ID, user_name, first_name FROM
        //                   (
        //                   SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts
        //                   UNION ALL
        //                   SELECT userID, user_name, first_name FROM users
        //                   ) x
        //                   ) as a;
        //                   SELECT date_time,
        //                   order_ref_temp, 
        //                   u.first_name as 'user_first_name', 
        //                   no_of_items, 
        //                   subtotal, 
        //                   less_vat, 
        //                   disc_amt, 
        //                   cus_pts_deducted, 
        //                   grand_total,
        //                   vatable_sale,
        //                   vat_12,
        //                   vat_exempt_sale,
        //                   zero_rated_sale,
        //                   payment_amt, 
        //                   change,
        //                   giftcard_no, 
        //                   giftcard_deducted,
        //                   IIF(cus_name = '', '0', cus_name) as 'cus_name',
        //                   cus_special_ID_no,
        //                   refund_order_ref_temp,
        //                   return_order_ref_temp
        //                   FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
        //                   WHERE order_ref = (SELECT MAX(order_ref) FROM transaction_details)");

        //    if (SQL.HasException(true))
        //        return;

        //    foreach (DataRow r in SQL.DBDT.Rows)
        //    {
        //        report.SetParameterValue("date_time", r["date_time"]);
        //        report.SetParameterValue("invoice_no", r["order_ref_temp"]);
        //        report.SetParameterValue("user_first_name", r["user_first_name"]);
        //        report.SetParameterValue("no_of_items", r["no_of_items"]);
        //        report.SetParameterValue("subtotal", String.Format(r["subtotal"].ToString(), "#,##0.00"));
        //        report.SetParameterValue("less_vat", String.Format(r["less_vat"].ToString(), "-#,##0.00"));
        //        report.SetParameterValue("discount", String.Format(r["disc_amt"].ToString(), "-#,##0.00"));
        //        report.SetParameterValue("points_deduct", String.Format(r["cus_pts_deducted"].ToString(), "-#,##0.00"));
        //        report.SetParameterValue("giftcard_deduct", String.Format(r["giftcard_deducted"].ToString(), "-#,##0.00"));
        //        report.SetParameterValue("total", String.Format(r["grand_total"].ToString()), "#,##0.00");
        //        report.SetParameterValue("vatable_sales", String.Format(r["vatable_sale"].ToString(), "#,##0.00"));
        //        report.SetParameterValue("vat_12", String.Format(r["vat_12"].ToString(), "#,##0.00").ToString());
        //        report.SetParameterValue("vat_exempt_sales", String.Format(r["vat_exempt_sale"].ToString(), "#,##0.00"));
        //        report.SetParameterValue("zero_rated_sales", String.Format(r["zero_rated_sale"].ToString(), "#,##0.00").ToString());
        //        report.SetParameterValue("giftcard_no", r["giftcard_no"]);
        //        report.SetParameterValue("cash", String.Format(r["payment_amt"].ToString(), "#,##0.00"));
        //        report.SetParameterValue("change", String.Format(r["change"].ToString(), "#,##0.00"));
        //        report.SetParameterValue("cus_name", r["cus_name"]);
        //        report.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"]);

        //        report.SetParameterValue("note", "");
        //    }

        //    report.SetParameterValue("business_name", Main.Instance.sd_business_name);
        //    report.SetParameterValue("business_address", Main.Instance.sd_business_address);
        //    report.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
        //    report.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
        //    report.SetParameterValue("sn", Main.Instance.sd_sn);
        //    report.SetParameterValue("min", Main.Instance.sd_min);
        //    report.SetParameterValue("footer_text", Main.Instance.rl_footer_text);

        //    int no_of_prints = 1;

        //    if (frmOrder.apply_regular_discount_fix_amt || frmOrder.apply_special_discount || frmOrder.apply_member)
        //    {
        //        no_of_prints = 2;
        //    }


        //    if (no_of_prints == 1)
        //    {
        //        report.SetParameterValue("note", note + "CUSTOMERS COPY");

        //        PrintReceipt();
        //    }
        //    else if (no_of_prints == 2)
        //    {
        //        report.SetParameterValue("note", note + "ACCOUNTING COPY");

        //        PrintReceipt();
        //    }
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
                return;

            #endregion

            #region transaction_items

            SQL.Query(@"INSERT INTO transaction_items (order_ref, itemID, productID, description, name, type, static_price_exclusive,
                           static_price_vat, static_price_inclusive, selling_price_exclusive, selling_price_vat, selling_price_inclusive,
                           quantity, discount, is_less_vat, less_vat, is_vat_exempt, is_disc_percent, disc_percent, is_refund, is_return)
                           SELECT (SELECT MAX(order_ref) FROM transaction_details), itemID, productID, description, name, type, static_price_exclusive,
                           static_price_vat, static_price_inclusive, selling_price_exclusive, selling_price_vat, selling_price_inclusive,
                           quantity, discount, is_less_vat, less_vat, is_vat_exempt, is_disc_percent, disc_percent, is_refund, is_return FROM order_cart");
            if (SQL.HasException(true))
                return;

            #endregion

            #region remove/add to inventory

            SQL.Query("SELECT productID, quantity, is_return, is_refund FROM order_cart");
            if (SQL.HasException(true))
                return;
            foreach (DataRow r in SQL.DBDT.Rows)
            {
                SQL.AddParam("@productID", r["productID"].ToString());
                SQL.AddParam("@quantity", r["quantity"].ToString());
                if (Convert.ToBoolean(r["is_return"].ToString()) || Convert.ToBoolean(r["is_refund"].ToString()))
                {
                    SQL.Query("UPDATE inventory SET stock_qty = stock_qty + @quantity WHERE productID = @productID");
                    if (SQL.HasException(true))
                        return;
                }
                else
                {
                    SQL.Query("UPDATE inventory SET stock_qty = stock_qty - @quantity WHERE productID = @productID");
                    if (SQL.HasException(true))
                        return;
                }
            }

            #endregion

            #region increase customer points

            if (action == 1)
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
                    SQL.AddParam("@cash_paid", txtAmount.Text);
                    SQL.AddParam("@cus_amt_per_pt", cus_amt_per_pt);
                    SQL.Query(@"INSERT INTO points_award (order_ref, cus_ID_no, cash_paid, pts_earned)
                           SELECT MAX(order_ref), @customerID, @cash_paid, (@cash_paid / @cus_amt_per_pt) FROM transaction_details");
                    if (SQL.HasException(true))
                        return;

                    // update card balance

                    SQL.AddParam("@customerID", lblCustomerID.Text);
                    SQL.AddParam("@cash_paid", txtAmount.Text);
                    SQL.AddParam("@cus_amt_per_pt", cus_amt_per_pt);
                    SQL.Query("UPDATE member_card SET card_balance = card_balance + (@cash_paid / @cus_amt_per_pt) WHERE customerID = @customerID");
                    if (SQL.HasException(true))
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
                    return;
            }

            #endregion

            #region clear cart

            SQL.Query("DELETE FROM order_cart");
            if (SQL.HasException(true))
                return;

            #endregion

            GenerateReceipt();

            

            #region reset values

            frmOrder.apply_regular_discount_fix_amt = false;
            frmOrder.apply_special_discount = false;
            frmOrder.apply_member = false;
            frmOrder.tbBarcode.Enabled = true;
            frmOrder.lblCustomer.Text = "";
            frmOrder.lblOperation.Text = "Order/Payment";
            frmOrder.regular_disc_amt = 0;
            frmOrder.is_refund = false;
            frmOrder.is_return = false;

            #endregion

            this.Close();
        }

        private void btnRemoveGC_Click(object sender, EventArgs e)
        {
            decimal deduct_gc = decimal.Parse(lblDeductGC.Text);
            grand_total = grand_total + deduct_gc;
            lblGrandTotal.Text = grand_total.ToString("N2");
            lblGCNo.Text = "0";
            lblDeductGC.Text = "0.00";
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            PGiftCard frmPGiftCard = new PGiftCard();
            frmPGiftCard.frmPayment = this;
            frmPGiftCard.ShowDialog();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
            {
                txtAmount.SelectAll();
                decimal total = 0M;

                decimal amount = Math.Round(total, 2);

                change = amount - grand_total;
                lblChange.Text = Math.Round(change, 2).ToString();
            }
            else
            {
                try
                {
                    decimal amount = Math.Round(decimal.Parse(txtAmount.Text), 2);

                    change = amount - grand_total;
                    lblChange.Text = Math.Round(change, 2).ToString();
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
            if (cbxUsePoints.Checked)
            {
                lblDeductPoints.Text = cbxUsePoints.Text;

                lblChange.Text = "Remaining points";
                lblChange.ForeColor = Color.FromArgb(122, 185, 80);
            }
            else if (cbxUsePoints.Checked == false)
            {
                //decimal deduct_points = decimal.Parse(lblDeductPoints.Text);

                //grand_total = grand_total + deduct_points;
                //lblGrandTotal.Text = grand_total.ToString("N2");
                lblChange.Text = "Change";
                lblChange.ForeColor = Color.FromArgb(204, 23, 46);
                lblDeductPoints.Text = "0.00";
            }
        }

        private void lblDeductPoints_TextChanged(object sender, EventArgs e)
        {
            decimal deduct_points = decimal.Parse(lblDeductPoints.Text);

            if (cbxUsePoints.Checked)
            {
                grand_total = deduct_points - grand_total;
                
                lblChange.Text = grand_total.ToString("N2");
            }
        }
    }
}
