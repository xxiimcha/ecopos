﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
using System.Threading;
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
        FormLoad OL = new FormLoad();
        SQLControl SQL = new SQLControl();
        ExportImport EI = new ExportImport();

        PaymentR58 report = new PaymentR58();
        PaymentR58 reprint_receipt = new PaymentR58();
        PaymentR80 reprint_receipt80 = new PaymentR80();
        bool dgvClickedOnce = false;
        //METHODS

        //METHODS
        private void Transactions_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));

            if (Properties.Settings.Default.servertype)
            {
                cmbTerminalNames.Items.Clear();
                cmbTerminalNames.Items.Add("All");

                SQL.Query(@"SELECT terminal_name FROM terminals ORDER BY terminal_id ASC");
                if (SQL.DBDT.Rows.Count > 0)
                {
                    foreach (DataRow dr in SQL.DBDT.Rows)
                    {
                        cmbTerminalNames.Items.Add(dr["terminal_name"].ToString());
                    }
                }
                cmbTerminalNames.SelectedIndex = 0;
            }
            else
            {
                lblterminal.Visible = false;
                cmbTerminalNames.Visible = false;
            }

            cmbType.SelectedIndex = 0;

            SearchTransactions();
        }

        private void SearchTransactions()
        {
            int action = 0;

            if (cmbType.SelectedIndex == 1)
                action = 1;
            else if (cmbType.SelectedIndex == 2)
                action = 4;

            string where_query = "action <> 5";

            if (cmbType.SelectedIndex != 0)
                where_query = "action = " + action;

            string terminal_query = cmbTerminalNames.Text == "" || cmbTerminalNames.Text == "All" || !Properties.Settings.Default.servertype ? "" : "AND terminal_id = " + cmbTerminalNames.Text;
            

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
                             payment_method as 'Payment Method', CONVERT(DECIMAL(18,2), ABS(disc_amt + cus_pts_deducted + giftcard_deducted)) as 'Deductions', CONVERT(DECIMAL(18,2), grand_total) as 'Total',
                             CONVERT(DECIMAL(18,2), vatable_sale) as 'VATable Sale', CONVERT(DECIMAL(18,2), vat_12) as 'VAT', CONVERT(DECIMAL(18,2), less_vat) as 'Less VAT', 
                             CONVERT(DECIMAL(18,2), vat_exempt_sale) as 'VAT Exempt' FROM transaction_details WHERE " + where_query + " " + terminal_query + " AND date_time BETWEEN @from AND @to ORDER BY date_time DESC");
                if (SQL.HasException(true))
                    return;

            dgvRecords.DataSource = SQL.DBDT;
            dgvRecords.Columns[0].Visible = false;
            dgvRecords.Columns[1].Width = 100;
        }


        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Transactions Report", dgvRecords);
        }

        private void FontSetter()
        {
            int fontSize_regular = int.Parse(Properties.Settings.Default.RegularTextFont);
            int fontSize_products = int.Parse(Properties.Settings.Default.ProductListFont);
            int fontSize_bname = int.Parse(Properties.Settings.Default.TitleTextFont);
            int fontSize_bheader = int.Parse(Properties.Settings.Default.BusinessDetailsFont);
            int fontSize_transactionDetails = int.Parse(Properties.Settings.Default.TransactionDetailsFont);


            if (Properties.Settings.Default.papersize == "58MM")
            {
                #region Font 58
                 //header

                //Business Name
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["businessname1"]).ApplyFont(new Font("Arial", fontSize_bname, FontStyle.Bold));
                //Business details
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["businessaddress1"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["bcontact"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["btin"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["bsn"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["bmin"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));

                //Regular
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["rnote"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));

                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tdatetitle"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tinvoicetitle"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tcashier"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tterminal"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));

                //Product List
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tqty"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Bold));
                //((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tproducts"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tprice"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Bold));
                //((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["quantity1"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["description1"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["sellingprice"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["txtstaticpriceinclusive"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));

                //Transaction Details
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tnoofitems"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Bold));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["noofitems1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Bold));

                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tsubtotal"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["subtotal1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tlessvat"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["lessvat1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tdiscount"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["discount1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tpoints"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["pointsdeduct1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tgiftcard"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["giftcarddeduct1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["ttotal"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["total1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tvatablesales"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["vatablesales1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tvatamount"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["vat121"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tvatexempt"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["vatexemptsales1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tzerorated"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["zeroratedsales1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tgcno"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["giftcardno1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tpaymentmethod"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["cash1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["trefno"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["ReferenceNumber1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tchange"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["change1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["trpoints"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["trpoints1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));

                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["footertext1"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["txtfooter1"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));

                #endregion
            }
            else
            {
                #region Font 80
                //header

                //Business Name
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["businessname1"]).ApplyFont(new Font("Arial", fontSize_bname, FontStyle.Bold));
                //Business details
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["businessaddress1"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["bcontact"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["btin"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["bsn"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["bmin"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));

                //Regular
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["rnote"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));

                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tdatetitle"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tinvoicetitle"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tcashier"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tterminal"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));

                //Product List
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tqty"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Bold));
                //((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tproducts"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Bold));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tprice"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Bold));
                //((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["quantity1"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["description1"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["sellingprice"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["txtstaticpriceinclusive"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));

                //Transaction Details
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tnoofitems"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Bold));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["noofitems1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Bold));

                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tsubtotal"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["subtotal1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tlessvat"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["lessvat1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tdiscount"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["discount1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tpoints"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["pointsdeduct1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tgiftcard"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["giftcarddeduct1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["ttotal"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["total1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tvatablesales"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["vatablesales1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tvatamount"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["vat121"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tvatexempt"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["vatexemptsales1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tzerorated"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["zeroratedsales1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tgcno"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["giftcardno1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tpaymentmethod"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["cash1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["trefno"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["ReferenceNumber1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["tchange"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["change1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((TextObject)reprint_receipt80.ReportDefinition.ReportObjects["trpoints"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["trpoints1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));

                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["footertext1"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
                ((FieldObject)reprint_receipt80.ReportDefinition.ReportObjects["txtfooter1"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));

                #endregion
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (dgvClickedOnce == false)
                return;

            if (Properties.Settings.Default.papersize == "58MM")
            {
                DataSet ds = new DataSet();

                try
                {
                    if (dgvRecords.CurrentRow.Cells[3].Value.ToString() == "Order")
                    {
                        SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive, selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                    }
                    else
                    {
                        SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, (-1 * static_price_inclusive) as static_price_inclusive, (-1 * selling_price_inclusive) as selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                    }

                    //SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, (-1 * static_price_inclusive) as static_price_inclusive, (-1 * selling_price_inclusive) as selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                    SQL.DBDA.Fill(ds, "transaction_items");
                    reprint_receipt.SetDataSource(ds);

                    if (dgvRecords.CurrentRow.Cells[3].Value.ToString() == "Order")
                    {
                        SQL.AddParam("@order_ref", dgvRecords.CurrentRow.Cells[0].Value.ToString());
                        SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users 
                            SELECT * INTO #Temp_users FROM (SELECT ID, user_name, first_name 
                            FROM(SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts 
                            UNION ALL SELECT userID, user_name, first_name FROM users ) x ) as a; 
                            SELECT date_time,transaction_details.order_ref_temp, u.first_name as 'user_first_name',  no_of_items,  subtotal,  less_vat, disc_amt, 
                            cus_pts_deducted, grand_total, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, payment_amt, change, remaining_points, giftcard_no, 
                            giftcard_deducted, IIF(cus_name = '', '0', cus_name) as 'cus_name', cus_special_ID_no, refund_order_ref_temp, return_order_ref_temp, 
                            payment_method, action,referenceNo, terminal_id as 'tid' FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                            WHERE transaction_details.order_ref = @order_ref");

                    }
                    else
                    {
                        SQL.AddParam("@order_ref", dgvRecords.CurrentRow.Cells[0].Value.ToString());
                        SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users 
                            SELECT * INTO #Temp_users FROM (SELECT ID, user_name, first_name 
                            FROM(SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts 
                            UNION ALL SELECT userID, user_name, first_name FROM users ) x ) as a; 
                            SELECT date_time,transaction_details.order_ref_temp, u.first_name as 'user_first_name',  no_of_items,  subtotal,  less_vat, disc_amt, 
                            cus_pts_deducted, grand_total, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, payment_amt, change, remaining_points, giftcard_no, 
                            giftcard_deducted, IIF(cus_name = '', '0', cus_name) as 'cus_name', cus_special_ID_no, refund_order_ref_temp, return_order_ref_temp, 
                            payment_method, action,referenceNo, vt.void_order_ref_temp, transaction_details.terminal_id as 'tid' FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                            INNER JOIN void_transaction as vt ON vt.order_ref = transaction_details.order_ref WHERE transaction_details.order_ref = @order_ref");

                    }


                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {

                        reprint_receipt.SetParameterValue("date_time", r["date_time"].ToString());
                        reprint_receipt.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        reprint_receipt.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        reprint_receipt.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                        reprint_receipt.SetParameterValue("Terminal_No", r["tid"].ToString());
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
                        decimal giftcard_no = decimal.Parse(r["giftcard_no"].ToString());
                        reprint_receipt.SetParameterValue("giftcard_no", giftcard_no.ToString("N0"));
                        decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                        reprint_receipt.SetParameterValue("cash", payment_amt.ToString("N2"));
                        decimal change = decimal.Parse(r["change"].ToString());
                        reprint_receipt.SetParameterValue("change", change.ToString("N2"));
                        decimal remaining_points = decimal.Parse(r["remaining_points"].ToString());
                        reprint_receipt.SetParameterValue("remaining_points", remaining_points.ToString("N2"));

                        //REFERENCE NO
                        reprint_receipt.SetParameterValue("ReferenceNumber", r["referenceNo"].ToString());

                        if (r["cus_name"].ToString() == "0")
                        {
                            reprint_receipt.SetParameterValue("cus_name", "________________________________________________________");
                        }
                        else
                        {
                            reprint_receipt.SetParameterValue("cus_name", r["cus_name"].ToString());
                        }


                        if (r["cus_special_ID_no"].ToString() == "0")
                        {
                            reprint_receipt.SetParameterValue("cus_sc_pwd_id", "________________________________________________________");
                        }
                        else
                        {
                            reprint_receipt.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                        }

                        reprint_receipt.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());
                        string note = "###REPRINT###";

                        if (r["action"].ToString() == "4")
                            note = note + Constants.vbCrLf + "VOID # " + r["void_order_ref_temp"].ToString() + Constants.vbCrLf +
                                "Reason: " + (SQL.ReturnResult("SELECT void_reason FROM void_transaction WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString())) + Constants.vbCrLf +
                                "Voided by: " + (SQL.ReturnResult("SELECT voided_by FROM void_transaction WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString())) + Constants.vbCrLf +
                                (SQL.ReturnResult("SELECT void_date_time FROM void_transaction WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString())).ToString();

                        reprint_receipt.SetParameterValue("note", note);
                    }

                    reprint_receipt.SetParameterValue("business_name", Main.Instance.sd_business_name);
                    reprint_receipt.SetParameterValue("business_address", Main.Instance.sd_business_address);
                    reprint_receipt.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                    reprint_receipt.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                    reprint_receipt.SetParameterValue("sn", Main.Instance.sd_sn);
                    reprint_receipt.SetParameterValue("min", Main.Instance.sd_min);
                    reprint_receipt.SetParameterValue("footer_text", Main.Instance.sd_footer_text);
                    reprint_receipt.SetParameterValue("ptu_no", Main.Instance.sd_ptu_no);

                    DateTime dateissue = DateTime.Parse(Main.Instance.sd_pn_date_issued);
                    reprint_receipt.SetParameterValue("date_issued", dateissue.ToString("MM/dd/yyyy"));

                    DateTime validuntil = DateTime.Parse(Main.Instance.sd_pn_valid_until);
                    reprint_receipt.SetParameterValue("valid_until", validuntil.ToString("MM/dd/yyyy"));

                    if (Properties.Settings.Default.isBirAccredited)
                    {
                        reprint_receipt.SetParameterValue("is_vatable", true);
                        reprint_receipt.SetParameterValue("txt_footer", "THIS SERVES AS OFFICIAL RECEIPT.");
                    }
                    else
                    {
                        reprint_receipt.SetParameterValue("is_vatable", false);
                        reprint_receipt.SetParameterValue("txt_footer", "ORDER RECEIPT.");
                    }
                }
                catch (Exception ex)
                {
                    new Notification().PopUp(ex.Message, "", "error");
                    reprint_receipt.Dispose();
                }

                // print
                if (Main.Instance.pd_reprint_printer == "")
                {
                    new Notification().PopUp("No receipt printer selected.", "Error printing", "error");
                    return;
                }


                bool checkprinter = Main.PrinterExists(Main.Instance.pd_reprint_printer);

                if (checkprinter == false)
                {
                    new Notification().PopUp("Printer is offline", "Error", "error");
                    return;
                }


                reprint_receipt.PrintOptions.PrinterName = Main.Instance.pd_reprint_printer;
                reprint_receipt.PrintOptions.PaperSource = PaperSource.Auto;
                reprint_receipt.PrintToPrinter(1, false, 0, 0);

            }
            else
            {
                DataSet ds = new DataSet();

                try
                {
                    if (dgvRecords.CurrentRow.Cells[3].Value.ToString() == "Order")
                    {
                        SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive, selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                    }
                    else
                    {
                        SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, (-1 * static_price_inclusive) as static_price_inclusive, (-1 * selling_price_inclusive) as selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                    }

                    //SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, (-1 * static_price_inclusive) as static_price_inclusive, (-1 * selling_price_inclusive) as selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                    SQL.DBDA.Fill(ds, "transaction_items");
                    reprint_receipt80.SetDataSource(ds);

                    if (dgvRecords.CurrentRow.Cells[3].Value.ToString() == "Order")
                    {
                        SQL.AddParam("@order_ref", dgvRecords.CurrentRow.Cells[0].Value.ToString());
                        SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users 
                            SELECT * INTO #Temp_users FROM (SELECT ID, user_name, first_name 
                            FROM(SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts 
                            UNION ALL SELECT userID, user_name, first_name FROM users ) x ) as a; 
                            SELECT date_time,transaction_details.order_ref_temp, u.first_name as 'user_first_name',  no_of_items,  subtotal,  less_vat, disc_amt, 
                            cus_pts_deducted, grand_total, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, payment_amt, change, remaining_points, giftcard_no, 
                            giftcard_deducted, IIF(cus_name = '', '0', cus_name) as 'cus_name', cus_special_ID_no, refund_order_ref_temp, return_order_ref_temp, 
                            payment_method, action,referenceNo, terminal_id as 'tid' FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                            WHERE transaction_details.order_ref = @order_ref");

                    }
                    else
                    {
                        SQL.AddParam("@order_ref", dgvRecords.CurrentRow.Cells[0].Value.ToString());
                        SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users 
                            SELECT * INTO #Temp_users FROM (SELECT ID, user_name, first_name 
                            FROM(SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts 
                            UNION ALL SELECT userID, user_name, first_name FROM users ) x ) as a; 
                            SELECT date_time,transaction_details.order_ref_temp, u.first_name as 'user_first_name',  no_of_items,  subtotal,  less_vat, disc_amt, 
                            cus_pts_deducted, grand_total, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, payment_amt, change, remaining_points, giftcard_no, 
                            giftcard_deducted, IIF(cus_name = '', '0', cus_name) as 'cus_name', cus_special_ID_no, refund_order_ref_temp, return_order_ref_temp, 
                            payment_method, action,referenceNo, vt.void_order_ref_temp, transaction_details.terminal_id as 'tid' FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                            INNER JOIN void_transaction as vt ON vt.order_ref = transaction_details.order_ref WHERE transaction_details.order_ref = @order_ref");

                    }


                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {

                        reprint_receipt80.SetParameterValue("date_time", r["date_time"].ToString());
                        reprint_receipt80.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        reprint_receipt80.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        reprint_receipt80.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                        reprint_receipt80.SetParameterValue("Terminal_No", r["tid"].ToString());
                        decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                        reprint_receipt80.SetParameterValue("subtotal", subtotal.ToString("N2"));
                        decimal less_vat = decimal.Parse(r["less_vat"].ToString());
                        reprint_receipt80.SetParameterValue("less_vat", less_vat.ToString("N2"));
                        decimal disc_amt = decimal.Parse(r["disc_amt"].ToString());
                        reprint_receipt80.SetParameterValue("discount", disc_amt.ToString("N2"));
                        decimal cus_pts_deducted = decimal.Parse(r["cus_pts_deducted"].ToString());
                        reprint_receipt80.SetParameterValue("points_deduct", cus_pts_deducted.ToString("N2"));
                        decimal giftcard_deducted = decimal.Parse(r["giftcard_deducted"].ToString());
                        reprint_receipt80.SetParameterValue("giftcard_deduct", giftcard_deducted.ToString("N2"));
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                        reprint_receipt80.SetParameterValue("total", grand_total.ToString("N2"));
                        decimal vatable_sale = decimal.Parse(r["vatable_sale"].ToString());
                        reprint_receipt80.SetParameterValue("vatable_sales", vatable_sale.ToString("N2"));
                        decimal vat_12 = decimal.Parse(r["vat_12"].ToString());
                        reprint_receipt80.SetParameterValue("vat_12", vat_12.ToString("N2"));
                        decimal vat_exempt_sale = decimal.Parse(r["vat_exempt_sale"].ToString());
                        reprint_receipt80.SetParameterValue("vat_exempt_sales", vat_exempt_sale.ToString("N2"));
                        decimal zero_rated_sale = decimal.Parse(r["zero_rated_sale"].ToString());
                        reprint_receipt80.SetParameterValue("zero_rated_sales", zero_rated_sale.ToString("N2"));
                        decimal giftcard_no = decimal.Parse(r["giftcard_no"].ToString());
                        reprint_receipt80.SetParameterValue("giftcard_no", giftcard_no.ToString("N0"));
                        decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                        reprint_receipt80.SetParameterValue("cash", payment_amt.ToString("N2"));
                        decimal change = decimal.Parse(r["change"].ToString());
                        reprint_receipt80.SetParameterValue("change", change.ToString("N2"));
                        decimal remaining_points = decimal.Parse(r["remaining_points"].ToString());
                        reprint_receipt80.SetParameterValue("remaining_points", remaining_points.ToString("N2"));

                        //REFERENCE NO
                        reprint_receipt80.SetParameterValue("ReferenceNumber", r["referenceNo"].ToString());

                        if (r["cus_name"].ToString() == "0")
                        {
                            reprint_receipt80.SetParameterValue("cus_name", "________________________________________________________");
                        }
                        else
                        {
                            reprint_receipt80.SetParameterValue("cus_name", r["cus_name"].ToString());
                        }


                        if (r["cus_special_ID_no"].ToString() == "0")
                        {
                            reprint_receipt80.SetParameterValue("cus_sc_pwd_id", "________________________________________________________");
                        }
                        else
                        {
                            reprint_receipt80.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                        }

                        reprint_receipt80.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());
                        string note = "###REPRINT###";

                        if (r["action"].ToString() == "4")
                            note = note + Constants.vbCrLf + "VOID # " + r["void_order_ref_temp"].ToString() + Constants.vbCrLf +
                                "Reason: " + (SQL.ReturnResult("SELECT void_reason FROM void_transaction WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString())) + Constants.vbCrLf +
                                "Voided by: " + (SQL.ReturnResult("SELECT voided_by FROM void_transaction WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString())) + Constants.vbCrLf +
                                (SQL.ReturnResult("SELECT void_date_time FROM void_transaction WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString())).ToString();

                        reprint_receipt80.SetParameterValue("note", note);
                    }

                    reprint_receipt80.SetParameterValue("business_name", Main.Instance.sd_business_name);
                    reprint_receipt80.SetParameterValue("business_address", Main.Instance.sd_business_address);
                    reprint_receipt80.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                    reprint_receipt80.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                    reprint_receipt80.SetParameterValue("sn", Main.Instance.sd_sn);
                    reprint_receipt80.SetParameterValue("min", Main.Instance.sd_min);
                    reprint_receipt80.SetParameterValue("footer_text", Main.Instance.sd_footer_text);
                    reprint_receipt80.SetParameterValue("ptu_no", Main.Instance.sd_ptu_no);

                    DateTime dateissue = DateTime.Parse(Main.Instance.sd_pn_date_issued);
                    reprint_receipt80.SetParameterValue("date_issued", dateissue.ToString("MM/dd/yyyy"));

                    DateTime validuntil = DateTime.Parse(Main.Instance.sd_pn_valid_until);
                    reprint_receipt80.SetParameterValue("valid_until", validuntil.ToString("MM/dd/yyyy"));

                    if (Properties.Settings.Default.isBirAccredited)
                    {
                        reprint_receipt80.SetParameterValue("is_vatable", true);
                        reprint_receipt80.SetParameterValue("txt_footer", "THIS SERVES AS OFFICIAL RECEIPT.");
                    }
                    else
                    {
                        reprint_receipt80.SetParameterValue("is_vatable", false);
                        reprint_receipt80.SetParameterValue("txt_footer", "ORDER RECEIPT.");
                    }
                }
                catch (Exception ex)
                {
                    new Notification().PopUp(ex.Message, "", "error");
                    reprint_receipt80.Dispose();
                }

                // print
                if (Main.Instance.pd_reprint_printer == "")
                {
                    new Notification().PopUp("No receipt printer selected.", "Error printing", "error");
                    return;
                }


                bool checkprinter = Main.PrinterExists(Main.Instance.pd_reprint_printer);

                if (checkprinter == false)
                {
                    new Notification().PopUp("Printer is offline", "Error", "error");
                    return;
                }


                reprint_receipt80.PrintOptions.PrinterName = Main.Instance.pd_reprint_printer;
                reprint_receipt80.PrintOptions.PaperSource = PaperSource.Auto;
                reprint_receipt80.PrintToPrinter(1, false, 0, 0);

            }
        }


        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            report.Dispose();

            if (Properties.Settings.Default.papersize == "58MM")
            {
                reprint_receipt.Dispose();
                reprint_receipt = new PaymentR58();
            }
            else
            {
                reprint_receipt80.Dispose();
                reprint_receipt80 = new PaymentR80();
            }

            //Font for reprinting process
            Thread setFont = new Thread(FontSetter);
            setFont.Start();


            dgvClickedOnce = true;
            report = new PaymentR58();
            DataSet ds = new DataSet();

            CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;
            if (dgvRecords.CurrentRow.Cells[3].Value.ToString() == "Order")
            {
                SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive, selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
            }
            else
            {
                SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive as static_price_inclusive, selling_price_inclusive as selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
            }

            SQL.DBDA.Fill(ds, "transaction_items");
            report.SetDataSource(ds);

            if (dgvRecords.CurrentRow.Cells[3].Value.ToString() == "Order")
            {
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
                           SELECT td.*, u.first_name as 'user_first_name', td.terminal_id as 'tid'
                           FROM transaction_details as td INNER JOIN #Temp_users as u ON td.userID = u.ID
                           WHERE order_ref = @order_ref");
            }
            else
            {
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
                           SELECT td.*, u.first_name as 'user_first_name', vt.void_order_ref_temp, td.terminal_id as 'tid'
                           FROM transaction_details as td INNER JOIN #Temp_users as u ON td.userID = u.ID 
                           INNER JOIN void_transaction as vt ON vt.order_ref = td.order_ref
                           WHERE td.order_ref = @order_ref");
            }
            

            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                report.SetParameterValue("date_time", r["date_time"].ToString());
                report.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                report.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                report.SetParameterValue("Terminal_No", r["tid"].ToString());
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
                report.SetParameterValue("giftcard_no", giftcard_no.ToString("N0"));
                decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                report.SetParameterValue("cash", payment_amt.ToString("N2"));
                decimal change = decimal.Parse(r["change"].ToString());
                report.SetParameterValue("change", change.ToString("N2"));
                decimal remaining_points = decimal.Parse(r["remaining_points"].ToString());
                report.SetParameterValue("remaining_points", remaining_points.ToString("N2"));

                //REFERENCE NO
                report.SetParameterValue("ReferenceNumber", r["referenceNo"].ToString());

                if (r["cus_name"].ToString() == "0" || r["cus_name"].ToString() == "")
                {
                    report.SetParameterValue("cus_name", "________________________________________________________");
                }
                else
                {
                    report.SetParameterValue("cus_name", r["cus_name"].ToString());
                }


                if (r["cus_special_ID_no"].ToString() == "0")
                {
                    report.SetParameterValue("cus_sc_pwd_id", "________________________________________________________");
                }
                else
                {
                    report.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                }

                report.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());
                string note = "###REPRINT###";

                if (r["action"].ToString() == "4")
                    note = note + Constants.vbCrLf + "VOID # " + r["void_order_ref_temp"].ToString() + Constants.vbCrLf +
                                "Reason: " + (SQL.ReturnResult("SELECT void_reason FROM void_transaction WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString())) + Constants.vbCrLf +
                                "Voided by: " + (SQL.ReturnResult("SELECT voided_by FROM void_transaction WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString())) + Constants.vbCrLf +
                                (SQL.ReturnResult("SELECT void_date_time FROM void_transaction WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString())).ToString();

                report.SetParameterValue("note", note);

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

                if (Properties.Settings.Default.isBirAccredited)
                {
                    report.SetParameterValue("is_vatable", true);
                    report.SetParameterValue("txt_footer", "THIS SERVES AS OFFICIAL RECEIPT.");
                }
                else
                {
                    report.SetParameterValue("is_vatable", false);
                    report.SetParameterValue("txt_footer", "ORDER RECEIPT.");
                }

                CrystalReportViewer1.ReportSource = report;
                CrystalReportViewer1.Refresh();
                CrystalReportViewer1.Zoom(1);
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            SearchTransactions();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            SearchTransactions();
        }

        private void cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchTransactions();
        }

        private void cmbTerminalNames_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTerminalNames.Text != "")
            {
                SearchTransactions();
            }
        }

        private void TableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExportDGVToExcel_Click(object sender, EventArgs e)
        {
            new ExportDGVToExcel().ExportToExcel(new ExportDGVToExcel().DataGridViewToDataTable(dgvRecords), "Transaction Report", "Transaction Report");
        }
    }
}
