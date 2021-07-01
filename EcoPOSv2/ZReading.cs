using CrystalDecisions.Shared;
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
    public partial class ZReading : Form
    {
        public ZReading()
        {
            InitializeComponent();
        }

        //VARIABLES AND OTHERS
        SQLControl SQL = new SQLControl();

        ZReadingReport report = new ZReadingReport();

        string store_open_date_time = "";

        string store_open_user_name = "";
        //VARIABLES AND OTHERS


        //METHODS
        private void GenerateReport()
        {
            report = new ZReadingReport();

            DataSet ds = new DataSet();

            try
            {
                string datetime_now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

                SQL.Query(@"SELECT zreading.*, ss.*, zreading.zreading_ref_temp as 'dis_zreading_ref_temp'
                           FROM zreading INNER JOIN store_start as ss ON zreading.zreading_ref = ss.zreading_ref
                           WHERE zreading.zreading_ref = (SELECT MAX(zreading_ref) FROM zreading)");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    report.SetParameterValue("zreading_ref_temp", r["dis_zreading_ref_temp"].ToString());
                    report.SetParameterValue("store_open_date_time", store_open_date_time);
                    report.SetParameterValue("store_open_user_name", store_open_user_name);
                    report.SetParameterValue("store_close_date_time", r["close_date_time"].ToString());
                    report.SetParameterValue("store_close_user_name", Main.Instance.current_username);
                    report.SetParameterValue("beginning_invoice", r["beginning_invoice"].ToString());
                    report.SetParameterValue("ending_invoice", r["ending_invoice"].ToString());
                    report.SetParameterValue("void_beginning_no", r["void_beginning_no"].ToString());
                    report.SetParameterValue("void_ending_no", r["void_ending_no"].ToString());
                    decimal starting_cash = decimal.Parse(r["starting_cash"].ToString());
                    report.SetParameterValue("starting_cash", starting_cash.ToString("N2"));
                    report.SetParameterValue("no_of_transactions", r["no_of_transactions"].ToString());
                    decimal sales = decimal.Parse(r["sales"].ToString());
                    report.SetParameterValue("sales", sales.ToString("N2"));
                    decimal discount_deductions = decimal.Parse(r["discount_deductions"].ToString());
                    report.SetParameterValue("discount_deductions", discount_deductions.ToString("N2"));
                    decimal adjustments = decimal.Parse(r["adjustments"].ToString());
                    report.SetParameterValue("adjustments", adjustments.ToString("N2"));
                    decimal net_sales = decimal.Parse(r["net_sales"].ToString());
                    report.SetParameterValue("net_sales", net_sales.ToString("N2"));
                    decimal accumulated_adjustments = decimal.Parse(r["accumulated_adjustments"].ToString());
                    decimal accumulated_grand_total = decimal.Parse(r["accumulated_grand_total"].ToString());
                    report.SetParameterValue("accumulated_adjustments", accumulated_adjustments.ToString("N2"));
                    report.SetParameterValue("accumulated_grand_total", accumulated_grand_total.ToString("N2"));
                    decimal vatable_sales = decimal.Parse(r["vatable_sales"].ToString());
                    report.SetParameterValue("vatable_sales", vatable_sales.ToString("N2"));
                    decimal vat_amount = decimal.Parse(r["vat_amount"].ToString());
                    report.SetParameterValue("vat_amount", vat_amount.ToString("N2"));
                    decimal vat_exempt_sales = decimal.Parse(r["vat_exempt_sales"].ToString());
                    report.SetParameterValue("vat_exempt_sales", vat_exempt_sales.ToString("N2"));
                    decimal zero_rated_sales = decimal.Parse(r["zero_rated_sales"].ToString());
                    report.SetParameterValue("zero_rated_sales", zero_rated_sales.ToString("N2"));
                    report.SetParameterValue("printed_on", datetime_now);
                }
            }
            catch (Exception ex)
            {
                new Notification().PopUp(ex.Message, "", "error");
                report.Dispose();
            }

            PrintReceipt();
        }

        public void PrintReceipt()
        {
            if (Main.Instance.pd_receipt_printer == "")
            {
                new Notification().PopUp("No receipt printer selected.", "Error printing","error");
                return;
            }


            bool checkprinter = Main.PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("Printer is offline","Error","error");
                return;
            }


            report.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
            report.PrintOptions.PaperSource = PaperSource.Auto;
            report.PrintToPrinter(1, false, 0, 0);
        }
        private void LoadZReadingRecords()
        {
            string datetime_now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                       SELECT * INTO #Temp_users
                       FROM
                       (
                       SELECT ID, user_name, first_name FROM
                       (
                       SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts
                       UNION ALL
                       SELECT userID, user_name, first_name FROM users
                       ) x
                       ) as a;
                       SELECT start_date_time, open_by_userID, u.user_name as 'username' FROM store_start 
                       INNER JOIN #Temp_users as u ON store_start.open_by_userID = u.ID 
                       WHERE zreading_ref = (SELECT MAX(zreading_ref) FROM store_start) AND store_status = 'Open'");

            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                DateTime dates = DateTime.Parse(r["start_date_time"].ToString());
                lblStoreOpen.Text = dates.ToString("MMM dd, yyyy hh:mm:ss tt") + ", " + r["username"].ToString();
                store_open_user_name = r["username"].ToString();
                store_open_date_time = r["start_date_time"].ToString();
            }

            // store open
            SQL.AddParam("@store_open_date_time", store_open_date_time);
            decimal starting_cash = Convert.ToDecimal(SQL.ReturnResult("SELECT SUM(starting_cash) FROM shift WHERE start > @store_open_date_time"));

            if (SQL.HasException(true))
                return;

            lblStartingCash.Text = starting_cash.ToString("N2");



            // transactions
            SQL.AddParam("@from", store_open_date_time);
            SQL.AddParam("@to", datetime_now);
            lblTransactions.Text = SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to");

            if (SQL.HasException(true))
            {
                new Notification().PopUp("11", "", "error");
                //Interaction.MsgBox("11");
                return;
            }

            // sales, discount/deductions, total net sales
            SQL.AddParam("@from", store_open_date_time);
            SQL.AddParam("@to", datetime_now);

            int count_sdt = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1"));
            if (SQL.HasException(true))
                return;

            SQL.AddParam("@from", store_open_date_time);
            SQL.AddParam("@to", datetime_now);
            var adjustments = SQL.ReturnResult(@"SELECT IIF((SELECT COUNT(*) FROM void_transaction WHERE void_date_time BETWEEN @from AND @to) > 0, (SELECT SUM(td.grand_total) FROM void_transaction as vt INNER JOIN transaction_details as td
                                                    ON vt.order_ref = td.order_ref WHERE vt.void_date_time BETWEEN @from AND @to), 0)");
            if (SQL.HasException(true))
                return;

            if (count_sdt > 0)
            {
                SQL.AddParam("@from", store_open_date_time);
                SQL.AddParam("@to", datetime_now);
                SQL.AddParam("@adjustments", adjustments);

                SQL.Query(@"SELECT (SELECT SUM(ABS(subtotal)) FROM transaction_details WHERE date_time BETWEEN @from AND @to) as 'subtotal', 
                           SUM(disc_amt + cus_pts_deducted) as 'discount', SUM(grand_total) as 'netsales', SUM(vatable_sale) as 'vatsales', SUM(vat_12) as 'vatamount',
                           SUM(vat_exempt_sale) as 'vatexempt', SUM(zero_rated_sale) as 'zerorated'
                           FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1");


                if (SQL.HasException(true))
                {
                    new Notification().PopUp("3", "", "error");
                    return;
                }

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                    decimal discount = decimal.Parse(r["discount"].ToString());
                    decimal netsales = decimal.Parse(r["netsales"].ToString());
                    decimal vatsales = decimal.Parse(r["vatsales"].ToString());
                    decimal vatamount = decimal.Parse(r["vatamount"].ToString());
                    decimal vatexempt = decimal.Parse(r["vatexempt"].ToString());
                    decimal zerorated = decimal.Parse(r["zerorated"].ToString());

                    lblSales.Text = subtotal.ToString("N2");
                    lblDiscount.Text = discount.ToString("N2");
                    lblNetSales.Text = netsales.ToString("N2");
                    lblVatableSales.Text = vatsales.ToString("N2");
                    lblVATAmount.Text = vatamount.ToString("N2");
                    lblVATExemptSales.Text = vatexempt.ToString("N2");
                    lblZeroRatedSales.Text = zerorated.ToString("N2");
                }
            }
            else
            {
                lblSales.Text = "0.00";
                lblDiscount.Text = "0.00";
                lblNetSales.Text = "0.00";
                lblVatableSales.Text = "0.00";
                lblVATAmount.Text = "0.00";
                lblVATExemptSales.Text = "0.00";
                lblZeroRatedSales.Text = "0.00";
            }

            // adjustment

            SQL.AddParam("@from", store_open_date_time);
            SQL.AddParam("@to", datetime_now);

            int check_adjustment = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM void_transaction WHERE void_date_time BETWEEN @from AND @to"));
            if (SQL.HasException(true))
                return;

            if (check_adjustment > 0)
            {
                SQL.AddParam("@from", store_open_date_time);
                SQL.AddParam("@to", datetime_now);

                decimal adjustment1 = 0;
                if (SQL.ReturnResult(@"SELECT SUM(td.grand_total) FROM void_transaction as vt INNER JOIN transaction_details as td
                                                    ON vt.order_ref = td.order_ref WHERE vt.void_date_time BETWEEN @from AND @to") != "")
                {
                    adjustment1 = decimal.Parse(SQL.ReturnResult(@"SELECT SUM(td.grand_total) FROM void_transaction as vt INNER JOIN transaction_details as td
                                                    ON vt.order_ref = td.order_ref WHERE vt.void_date_time BETWEEN @from AND @to"));
                }
                else { return; }

                lblAdjustment.Text = adjustment1.ToString("N2");

                if (SQL.HasException(true))
                    return;
            }
            else
                lblAdjustment.Text = "0.00";

            // accumulated total

            int count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details"));
            if (SQL.HasException(true))
                return;

            if (count_records > 0)
            {
                SQL.Query("SELECT SUM(grand_total) as 'grand_total' FROM transaction_details WHERE action = 1");
                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                    lblAGTotal.Text = grand_total.ToString("N2");
                }     
            }
            else
                lblAGTotal.Text = "0.00";

            // accumulated adjustment

            int check_accumulated_adjustment = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM void_transaction"));
            if (SQL.HasException(true))
                return;

            if (check_adjustment > 0)
            {
                decimal adjustments1 = decimal.Parse(SQL.ReturnResult(@"SELECT SUM(td.grand_total) FROM void_transaction as vt INNER JOIN transaction_details as td
                                                    ON vt.order_ref = td.order_ref"));
                lblAAdjustment.Text = adjustments1.ToString("N2");
                if (SQL.HasException(true))
                    return;
            }
            else
                lblAAdjustment.Text = "0.00";

            // void beginning and ending invoice

            SQL.AddParam("@from", store_open_date_time);
            SQL.AddParam("@to", datetime_now);

            int check_void_invoices = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM void_transaction WHERE void_date_time BETWEEN @from AND @to"));

            if (check_void_invoices > 0)
            {
                SQL.AddParam("@from", store_open_date_time);
                SQL.AddParam("@to", datetime_now);

                SQL.Query("SELECT MIN(void_order_ref_temp) as 'beginning', MAX(void_order_ref_temp) as 'ending' FROM void_transaction WHERE void_date_time BETWEEN @from AND @to");
                if (SQL.HasException(true))
                {
                    new Notification().PopUp("45", "", "error");
                    return;
                }

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    lblVoidBeginningInvoice.Text = r["beginning"].ToString();
                    lblVoidEndingInvoice.Text = r["ending"].ToString();
                }
            }

            // beginning and ending invoice

            SQL.AddParam("@from", store_open_date_time);
            SQL.AddParam("@to", datetime_now);

            int check_invoices = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1"));

            if (check_invoices > 0)
            {
                SQL.AddParam("@from", store_open_date_time);
                SQL.AddParam("@to", datetime_now);

                SQL.Query("SELECT MIN(order_ref_temp) as 'beginning', MAX(order_ref_temp) as 'ending' FROM transaction_details WHERE date_time BETWEEN @from AND @to");
                if (SQL.HasException(true))
                {
                    new Notification().PopUp("44", "", "error");
                    return;
                }

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    lblBeginningInvoice.Text = r["beginning"].ToString();
                    lblEndingInvoice.Text = r["ending"].ToString();
                }
            }
            else
            {
                lblBeginningInvoice.Text = "00000000";
                lblEndingInvoice.Text = "00000000";
            }



            SQL.AddParam("@from", store_open_date_time);
            SQL.AddParam("@to", datetime_now);
            SQL.Query(@"SELECT payment_method, CONVERT(DECIMAL(18,2), SUM(payment_amt - change)) FROM transaction_details 
                       WHERE date_time BETWEEN @from AND @to AND action = 1 GROUP BY payment_method ORDER BY CASE WHEN payment_method = 'Cash' THEN 1 Else 2 END ASC");
            if (SQL.HasException(true))
            {
                new Notification().PopUp("6", "", "error");
                return;
            }

            dgvPaymentMethod.DataSource = SQL.DBDT;
        }

        //METHODS
        private void ZReading_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

            LoadZReadingRecords();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrintClose_Click(object sender, EventArgs e)
        {
            int zreading_ref = Convert.ToInt32(SQL.ReturnResult("SELECT zreading_ref FROM store_start WHERE zreading_ref = (SELECT MAX(zreading_ref) FROM store_start) AND store_status = 'Open'"));
            if (SQL.HasException(true))
                return;

            // save z reading

            SQL.AddParam("@zreading_ref", zreading_ref);
            SQL.AddParam("@no_of_transactions", lblTransactions.Text);
            SQL.AddParam("@beginning_invoice", lblBeginningInvoice.Text);
            SQL.AddParam("@ending_invoice", lblEndingInvoice.Text);
            SQL.AddParam("@void_beginning_no", lblVoidBeginningInvoice.Text);
            SQL.AddParam("@void_ending_no", lblVoidEndingInvoice.Text);
            SQL.AddParam("@starting_cash", System.Convert.ToDecimal(lblStartingCash.Text));
            SQL.AddParam("@adjustment", System.Convert.ToDecimal(lblAAdjustment.Text));
            SQL.AddParam("@sales", System.Convert.ToDecimal(lblSales.Text));
            SQL.AddParam("@discount_deductions", System.Convert.ToDecimal(lblDiscount.Text));
            SQL.AddParam("@adjustments", System.Convert.ToDecimal(lblAdjustment.Text));
            SQL.AddParam("@net_sales", System.Convert.ToDecimal(lblNetSales.Text));
            SQL.AddParam("@accumulated_adjustments", System.Convert.ToDecimal(lblAAdjustment.Text));
            SQL.AddParam("@accumulated_grand_total", System.Convert.ToDecimal(lblAGTotal.Text));
            SQL.AddParam("@vatable_sales", System.Convert.ToDecimal(lblVatableSales.Text));
            SQL.AddParam("@vat_amount", System.Convert.ToDecimal(lblVATAmount.Text));
            SQL.AddParam("@vat_exempt_sales", System.Convert.ToDecimal(lblVATExemptSales.Text));
            SQL.AddParam("@zero_rated_sales", System.Convert.ToDecimal(lblZeroRatedSales.Text));

            SQL.Query(@"UPDATE zreading SET no_of_transactions = @no_of_transactions, beginning_invoice = @beginning_invoice, ending_invoice = @ending_invoice,
                       void_beginning_no = @void_beginning_no, void_ending_no = @void_ending_no, starting_cash = @starting_cash, sales = @sales, discount_deductions = @discount_deductions, 
                       adjustments = @adjustments, net_sales = @net_sales, accumulated_adjustments = @accumulated_adjustments, accumulated_grand_total = @accumulated_grand_total,
                       vatable_sales = @vatable_sales, vat_amount = @vat_amount, vat_exempt_sales = @vat_exempt_sales, zero_rated_sales = @zero_rated_sales
                       WHERE zreading_ref = @zreading_ref");

            if (SQL.HasException(true))
                return;


            // log out and close store
            string date_time_now = DateTime.Now.ToString("yyyy-MM-dd 00:00:01");
            SQL.AddParam("@close_by_userID", Main.Instance.current_id);
            SQL.AddParam("date_time_now", date_time_now);
            SQL.Query(@"UPDATE store_start SET close_date_time = (SELECT GETDATE()), close_date_time_temp = @date_time_now, close_by_userID = @close_by_userID, store_status = 'Close'
                       WHERE zreading_ref = (SELECT MAX(zreading_ref) FROM store_start WHERE store_status = 'Open')");
            if (SQL.HasException(true))
                return;

            // generate report
            GenerateReport();

            // log out shift
            SQL.Query("UPDATE shift SET ended = (SELECT GETDATE()) WHERE shiftID = (SELECT MAX(shiftID) FROM shift)");

            if (SQL.HasException(true))
                return;

            Main.Instance.OpenChildForm(Order.Instance);

            //Order.Instance.ActiveControl = Order.Instance.tbBarcode;

            Login frmLogin = new Login();
            frmLogin.Show(Main.Instance);
            Main.Instance.Hide();

            Main.Instance.UpdateMemberCards();
            Main.Instance.UpdateGiftCards();

            Application.Restart();
        }
    }
}
