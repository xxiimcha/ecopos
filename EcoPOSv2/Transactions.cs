﻿using CrystalDecisions.Shared;
using EcoPOSControl;
using FontAwesome.Sharp;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        ExportImport EI = new ExportImport();

        TransactionsReport report = new TransactionsReport();
        PaymentReceipt reprint_receipt = new PaymentReceipt();
        bool dgvClickedOnce = false;
        //METHODS

        //METHODS
        private void Transactions_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));
            cmbType.SelectedIndex = 0;


            btnSearch.PerformClick();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int action = 0;

            if (cmbType.SelectedIndex == 1)
                action = 1;
            else if (cmbType.SelectedIndex == 2)
                action = 4;

            string where_query = "action <> 5";

            if (cmbType.SelectedIndex != 0)
                where_query = "action = " + action;

            SQL.AddParam("@from", dtpFrom.Value);
            SQL.AddParam("@to", dtpTo.Value);

            SQL.Query(@"SELECT order_ref as 'ID', order_ref_temp as 'Invoice No.', date_time as 'Date',
				      (CASE WHEN [action] = 1 THEN 'Order'
							 WHEN [action] = 4 THEN 'Void'
					   END) AS 'Transaction',
					   cus_name as 'Customer', 
                       (CASE WHEN cus_type = 0 THEN 'Regular'
                             WHEN cus_type = 1 THEN 'SC'
                             WHEN cus_type = 2 THEN 'PWD'
                             WHEN cus_type = 3 THEN 'Athlete'
                             WHEN cus_type = 0 THEN 'Member' END) AS 'Customer Type', 
                             CONVERT(DECIMAL(18,2), subtotal) as 'Subtotal', CONVERT(DECIMAL(18,2), ABS(disc_amt + cus_pts_deducted + giftcard_deducted)) as 'Deductions', CONVERT(DECIMAL(18,2), grand_total) as 'Total',
                             CONVERT(DECIMAL(18,2), vatable_sale) as 'VATable Sale', CONVERT(DECIMAL(18,2), vat_12) as 'VAT', CONVERT(DECIMAL(18,2), less_vat) as 'Less VAT', 
                             CONVERT(DECIMAL(18,2), vat_exempt_sale) as 'VAT Exempt' FROM transaction_details WHERE " + where_query + " AND date_time BETWEEN @from AND @to ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgvRecords.DataSource = SQL.DBDT;
            dgvRecords.Columns[0].Visible = false;
            dgvRecords.Columns[1].Width = 100;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (dgvRecords.RowCount == 0)
                return;

            if (btnSort.IconChar == IconChar.SortAlphaDown)
            {
                dgvRecords.Sort(dgvRecords.Columns[1], ListSortDirection.Ascending);
                btnSort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvRecords.Sort(dgvRecords.Columns[1], ListSortDirection.Descending);
                btnSort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Transactions Report", dgvRecords);
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (dgvClickedOnce == false)
                return;

            reprint_receipt = new PaymentReceipt();

            DataSet ds = new DataSet();


            try
            {
                SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, static_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                SQL.DBDA.Fill(ds, "transaction_items");

                reprint_receipt.SetDataSource(ds);

                SQL.AddParam("@order_ref", dgvRecords.CurrentRow.Cells[0].Value.ToString());

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
                           SELECT date_time,
                           order_ref_temp, 
                           u.first_name as 'user_first_name', 
                           no_of_items, 
                           subtotal, 
                           less_vat, 
                           disc_amt, 
                           cus_pts_deducted, 
                           grand_total,
                           vatable_sale,
                           vat_12,
                           vat_exempt_sale,
                           zero_rated_sale,
                           payment_amt, 
                           change,
                           giftcard_no, 
                           giftcard_deducted,
                           IIF(cus_name = '', '0', cus_name) as 'cus_name',
                           cus_special_ID_no,
                           vt.void_order_ref_temp as 'void_order_ref_temp'
                           action 
                           FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                           INNER JOIN void_transaction ON transaction_details.order_ref = void_transaction.order_ref
                           WHERE order_ref = @order_ref");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    reprint_receipt.SetParameterValue("date_time", r["date_time"].ToString());
                    reprint_receipt.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                    reprint_receipt.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                    decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                    reprint_receipt.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                    decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                    reprint_receipt.SetParameterValue("subtotal", subtotal.ToString("N2"));
                    decimal less_vat = decimal.Parse(r["less_vat"].ToString());
                    reprint_receipt.SetParameterValue("less_vat", less_vat.ToString("N2"));
                    decimal disc_amt = decimal.Parse(r["disc_amt"].ToString());
                    reprint_receipt.SetParameterValue("discount", disc_amt.ToString("N2"));
                    decimal cus_pts_deducted = decimal.Parse(r["cus_pts_deducted"].ToString());
                    reprint_receipt.SetParameterValue("points_deduct", cus_pts_deducted.ToString("N2"));
                    decimal giftcard_deducted = decimal.Parse(r["giftcard_deducted"].ToString());
                    reprint_receipt.SetParameterValue("giftcard_deduct", giftcard_deducted.ToString("N2"));
                    decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                    reprint_receipt.SetParameterValue("total", grand_total.ToString("N2"));
                    decimal vatable_sale = decimal.Parse(r["vatable_sale"].ToString());
                    reprint_receipt.SetParameterValue("vatable_sales", vatable_sale.ToString("N2"));
                    decimal vat_12 = decimal.Parse(r["vat_12"].ToString());
                    reprint_receipt.SetParameterValue("vat_12", vat_12.ToString("N2"));
                    decimal vat_exempt_sale = decimal.Parse(r["vat_exempt_sale"].ToString());
                    reprint_receipt.SetParameterValue("vat_exempt_sales", vat_exempt_sale.ToString("N2"));
                    decimal zero_rated_sale = decimal.Parse(r["zero_rated_sale"].ToString());
                    reprint_receipt.SetParameterValue("zero_rated_sales", zero_rated_sale.ToString("N2"));
                    reprint_receipt.SetParameterValue("giftcard_no", r["giftcard_no"].ToString());
                    decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                    reprint_receipt.SetParameterValue("cash", payment_amt.ToString("N2"));
                    decimal change = decimal.Parse(r["change"].ToString());
                    reprint_receipt.SetParameterValue("change", change.ToString("N2"));
                    reprint_receipt.SetParameterValue("cus_name", r["cus_name"].ToString());
                    reprint_receipt.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                    reprint_receipt.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());

                    string note = "###REPRINT###";

                    if (r["action"].ToString() == "4")
                        note = note + Constants.vbCrLf + "VOID # " + r["void_order_ref_temp"].ToString();

                    reprint_receipt.SetParameterValue("note", note);
                }

                reprint_receipt.SetParameterValue("business_name", Main.Instance.sd_business_name);
                reprint_receipt.SetParameterValue("business_address", Main.Instance.sd_business_address);
                reprint_receipt.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                reprint_receipt.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                reprint_receipt.SetParameterValue("sn", Main.Instance.sd_sn);
                reprint_receipt.SetParameterValue("min", Main.Instance.sd_min);
                reprint_receipt.SetParameterValue("footer_text", Main.Instance.rl_footer_text);
            }
            catch (Exception ex)
            {
                new Notification().PopUp(ex.Message, "", "error");
                reprint_receipt.Dispose();
            }

            // print
            if (Main.Instance.pd_receipt_printer == "")
            {
                new Notification().PopUp("No receipt printer selected.", "Error printing", "error");
                return;
            }


            bool checkprinter = Main.PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("Printer is offline", "Error", "error");
                return;
            }


            reprint_receipt.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
            reprint_receipt.PrintOptions.PaperSource = PaperSource.Auto;
            reprint_receipt.PrintToPrinter(1, false, 0, 0);
        }

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            dgvClickedOnce = true;

            report = new TransactionsReport();

            DataSet ds = new DataSet();

            //try
            //{
                CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;
                SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, static_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                SQL.DBDA.Fill(ds, "transaction_items");

                report.SetDataSource(ds);

                SQL.AddParam("@order_ref", dgvRecords.CurrentRow.Cells[0].Value.ToString());

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
                           SELECT td.*, u.first_name as 'user_first_name' 
                           FROM transaction_details as td INNER JOIN #Temp_users as u ON td.userID = u.ID
                           WHERE order_ref = @order_ref");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    report.SetParameterValue("date_time", r["date_time"].ToString());
                    report.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                    report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                    decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                    report.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                    decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                    report.SetParameterValue("subtotal", subtotal.ToString("N2"));
                    decimal less_vat = decimal.Parse(r["less_vat"].ToString());
                    report.SetParameterValue("less_vat", less_vat.ToString("N2"));
                    decimal disc_amt = decimal.Parse(r["disc_amt"].ToString());
                    report.SetParameterValue("discount", disc_amt.ToString("N2"));
                    decimal cus_pts_deducted = decimal.Parse(r["cus_pts_deducted"].ToString());
                    report.SetParameterValue("points_deduct", cus_pts_deducted.ToString("N2"));
                    decimal giftcard_deducted = decimal.Parse(r["giftcard_deducted"].ToString());
                    report.SetParameterValue("gift_card_deduct", giftcard_deducted.ToString("N2"));
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
                    report.SetParameterValue("gift_card_no", r["giftcard_no"].ToString());
                    decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                    report.SetParameterValue("cash", payment_amt.ToString("N2"));
                    decimal change = decimal.Parse(r["change"].ToString());
                    report.SetParameterValue("change", change.ToString("N2"));
                    report.SetParameterValue("cus_name", r["cus_name"].ToString());
                    report.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                    report.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());


                CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.Refresh();
                }
            //}
            //catch (Exception ex)
            //{
            //    new Notification().PopUp(ex.Message,"","error");
            //    report.Dispose();
            //}
        }
    }
}
