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
                    lblSales.Text = Format(r("subtotal"), "#,##0.00");
                    lblDiscount.Text = Format(r("discount"), "-#,##0.00");
                    lblNetSales.Text = Format(r("netsales"), "#,##0.00");
                    lblVatableSales.Text = Format(r("vatsales"), "#,##0.00");
                    lblVATAmount.Text = Format(r("vatamount"), "#,##0.00");
                    lblVATExemptSales.Text = Format(r("vatexempt"), "#,##0.00");
                    lblZeroRatedSales.Text = Format(r("zerorated"), "#,##0.00");
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

                lblAdjustment.Text = Format(Convert.ToDecimal(SQL.ReturnResult(@"SELECT SUM(td.grand_total) FROM void_transaction as vt INNER JOIN transaction_details as td
                                                    ON vt.order_ref = td.order_ref WHERE vt.void_date_time BETWEEN @from AND @to")), "#,##0.00");
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
                SQL.ExecQuery("SELECT SUM(grand_total) as 'grand_total' FROM transaction_details WHERE action = 1");
                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)

                    lblAGTotal.Text = Format(r("grand_total"), "#,##0.00");
            }
            else
                lblAGTotal.Text = "0.00";

            // accumulated adjustment

            int check_accumulated_adjustment = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM void_transaction"));
            if (SQL.HasException(true))
                return;

            if (check_adjustment > 0)
            {
                lblAAdjustment.Text = Format(Convert.ToDecimal(SQL.ReturnResult(@"SELECT SUM(td.grand_total) FROM void_transaction as vt INNER JOIN transaction_details as td
                                                    ON vt.order_ref = td.order_ref")), "#,##0.00");
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

                SQL.ExecQuery("SELECT MIN(void_order_ref_temp) as 'beginning', MAX(void_order_ref_temp) as 'ending' FROM void_transaction WHERE void_date_time BETWEEN @from AND @to");
                if (SQL.HasException(true))
                {
                    Interaction.MsgBox("45");
                    return;
                }

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    lblVoidBeginningInvoice.Text = r("beginning");
                    lblVoidEndingInvoice.Text = r("ending");
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

                SQL.ExecQuery("SELECT MIN(order_ref_temp) as 'beginning', MAX(order_ref_temp) as 'ending' FROM transaction_details WHERE date_time BETWEEN @from AND @to");
                if (SQL.HasException(true))
                {
                    Interaction.MsgBox("44");
                    return;
                }

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    lblBeginningInvoice.Text = r("beginning");
                    lblEndingInvoice.Text = r("ending");
                }
            }
            else
            {
                lblBeginningInvoice.Text = "00000000";
                lblEndingInvoice.Text = "00000000";
            }



            SQL.AddParam("@from", store_open_date_time);
            SQL.AddParam("@to", datetime_now);
            SQL.ExecQuery(@"SELECT payment_method, CONVERT(DECIMAL(18,2), SUM(payment_amt - change)) FROM transaction_details 
                       WHERE date_time BETWEEN @from AND @to AND action = 1 GROUP BY payment_method ORDER BY CASE WHEN payment_method = 'Cash' THEN 1 Else 2 END ASC");
            if (SQL.HasException(true))
            {
                Interaction.MsgBox("6");
                return;
            }

            dgvPaymentMethod.DataSource = SQL.DBDT;
        }

        //METHODS
        private void ZReading_Load(object sender, EventArgs e)
        {
            LoadZReadingRecords();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
