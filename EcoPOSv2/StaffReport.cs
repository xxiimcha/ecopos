﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using EcoPOSControl;
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
    public partial class StaffReport : Form
    {
        public StaffReport()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        FormLoad OL = new FormLoad();
        ExportImport EI = new ExportImport();

        TerminalReport report = new TerminalReport();
        ReportDocument cryRpt = new ReportDocument();

        private void StaffReport_Load(object sender, EventArgs e)
        {
            OL.ComboValues(cmbStaff, "userID", "user_name", "users");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbStaff.Text != "")
            {

                string date_now = string.Format(DateTime.Now.ToString(), "MM-dd-yyyy hh:mm:ss tt");

                report = new TerminalReport();

                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                DataSet ds3 = new DataSet();
                DataSet ds4 = new DataSet();
                DataSet ds5 = new DataSet();
                DataSet ds6 = new DataSet();
                DataSet ds7 = new DataSet();
                DataSet ds8 = new DataSet();
                DataSet ds9 = new DataSet();
                DataSet ds10 = new DataSet();
                DataSet ds11 = new DataSet();
                DataSet ds12 = new DataSet();

                //try
                //{
                CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;


                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time', 
                                                     COUNT(*) as 'no_of_items', SUM(subtotal) as 'subtotal', 
                                                     (SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'disc_amt', 
                                                     SUM(grand_total) as 'grand_total', SUM(less_vat) as 'less_vat', SUM(vatable_sale) as 'vatable_sale',
                                                     SUM(vat_12) as 'vat_12', SUM(vat_exempt_sale) as 'vat_exempt_sale'
                                                     FROM transaction_details WHERE date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND action = 1 AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds1, "transaction_details");

                report.Subreports["Sales"].SetDataSource(ds1);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT (u.first_name + ' ' + u.last_name) as 'user_first_name', SUM(subtotal) as 'subtotal',
                                                     (SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'disc_amt',  
                                                     SUM(grand_total) as 'grand_total' FROM transaction_details as td RIGHT JOIN users as u 
                                                     ON td.userID = u.userID WHERE td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND td.action = 1 AND td.userID = " + cmbStaff.SelectedValue + " GROUP BY (u.first_name + ' ' + u.last_name)", SQL.DBCon);

                SQL.DBDA.Fill(ds2, "transaction_details");
                report.Subreports["StaffSales"].SetDataSource(ds2);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total' 
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 1 AND ti.type = 'R' AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND td.userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds3, "transaction_details");

                report.Subreports["RetailSales"].SetDataSource(ds3);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total' 
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 1 AND ti.type = 'W' AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds4, "transaction_details");

                report.Subreports["WholesaleSales"].SetDataSource(ds4);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     COUNT(*) as 'cus_ID_no',
                                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total'
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 2 AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds5, "transaction_details");

                report.Subreports["Refund"].SetDataSource(ds5);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     COUNT(*) as 'cus_ID_no',
                                                     CONVERT(DECIMAL(18,0), SUM(ti.quantity)) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total'
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 3 AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds6, "transaction_details");

                report.Subreports["Return"].SetDataSource(ds6);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     CONVERT(DECIMAL(18,0), SUM(quantity)) as 'quantity', SUM(static_price_inclusive) as 'static_price_inclusive'
                                                     FROM void_item WHERE date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds7, "void_item");

                report.Subreports["VoidItem"].SetDataSource(ds7);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     COUNT(*) as 'no_of_items', SUM(grand_total) as 'total'
                                                     FROM transaction_details WHERE action = 4 AND date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds8, "transaction_details");

                report.Subreports["VoidTransaction"].SetDataSource(ds8);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     d.disc_name as 'cus_name', COUNT(*) as 'no_of_items', SUM(td.disc_amt) as 'disc_amt'
                                                     FROM transaction_details as td INNER JOIN discount as d ON td.discountID = d.discountID
                                                     WHERE td.discountID <> 0 AND td.action = 1 AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND td.userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, td.date_time)), d.disc_name ORDER BY 'date_time'", SQL.DBCon);
                SQL.DBDA.Fill(ds9, "transaction_details");

                report.Subreports["RegularDiscount"].SetDataSource(ds9);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     (CASE
                                                     WHEN cus_type = 1 THEN 'Senior Citizen'
                                                     WHEN cus_type = 2 THEN 'PWD'
                                                     WHEN cus_type = 3 THEN 'Athlete'
                                                     END) as 'cus_name', 
                                                     COUNT(*) as 'no_of_items', SUM(grand_total) as 'total'
                                                     FROM transaction_details 
                                                     WHERE cus_type IN (1,2,3) AND action = 1 AND date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time)),  cus_type ORDER BY 'date_time'", SQL.DBCon);
                SQL.DBDA.Fill(ds10, "transaction_details");

                report.Subreports["SpecialDiscount"].SetDataSource(ds10);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     payment_method, COUNT(*) as 'no_of_items', SUM(grand_total) as 'grand_total' FROM transaction_details 
                                                     WHERE action = 1 AND date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time)),  payment_method ORDER BY 'date_time' ASC", SQL.DBCon);

                SQL.DBDA.Fill(ds11, "transaction_details");

                report.Subreports["PaymentMethod"].SetDataSource(ds11);



                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     ti.description as 'cus_name', SUM(ti.quantity) as 'no_of_items', SUM(ti.static_price_inclusive) as 'grand_total'
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 1 AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, td.date_time)),  ti.description ORDER BY 'date_time' ASC", SQL.DBCon);
                SQL.DBDA.Fill(ds12, "transaction_details");

                report.Subreports["ItemSold"].SetDataSource(ds12);


                // main report
                report.SetParameterValue("business_name", Main.Instance.sd_business_name);
                report.SetParameterValue("date_from", dtpFrom.Value);
                report.SetParameterValue("date_to", dtpTo.Value);
                report.SetParameterValue("date_now", date_now);
                report.SetParameterValue("staff", cmbStaff.Text);

                // checks
                report.SetParameterValue("check_sales", cbxSales.Checked);
                report.SetParameterValue("check_staffsales", false);
                report.SetParameterValue("check_retailsales", cbxRetailSales.Checked);
                report.SetParameterValue("check_wholesalesales", cbxWholesaleSales.Checked);
                report.SetParameterValue("check_refund", cbxRefund.Checked);
                report.SetParameterValue("check_return", cbxReturnExchange.Checked);
                report.SetParameterValue("check_voiditem", cbxVoidItems.Checked);
                report.SetParameterValue("check_voidtransaction", cbxVoidTransactions.Checked);
                report.SetParameterValue("check_regulardiscount", cbxRegularDiscounts.Checked);
                report.SetParameterValue("check_specialdiscount", cbxSpecialDiscounts.Checked);
                report.SetParameterValue("check_paymentmethod", cbxPaymentMethod.Checked);
                report.SetParameterValue("check_itemsold", cbxItemsSold.Checked);


                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                int count_sales = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1 AND userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders', CONVERT(DECIMAL(18,2), SUM(subtotal)) as 'subtotal',
                        CONVERT(DECIMAL(18,2), (SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted))) as 'discount_deductions',
                        CONVERT(DECIMAL(18,2), SUM(grand_total)) as 'grand_total', CONVERT(DECIMAL(18,2), SUM(less_vat)) as 'less_vat',
                        CONVERT(DECIMAL(18,2), SUM(vatable_sale)) as 'vatable_sale', CONVERT(DECIMAL(18,2), SUM(vat_12)) as 'vat_12', 
                        CONVERT(DECIMAL(18,2), SUM(vat_exempt_sale)) as 'vat_exempt_sale'
                        FROM transaction_details WHERE date_time BETWEEN @from AND @to AND userID = @userID AND action = 1");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal no_of_orders = decimal.Parse(r["no_of_orders"].ToString());
                        decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                        decimal discount_deductions = decimal.Parse(r["discount_deductions"].ToString());
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                        decimal less_vat = decimal.Parse(r["less_vat"].ToString());
                        decimal vatable_sale = decimal.Parse(r["vatable_sale"].ToString());
                        decimal vat_12 = decimal.Parse(r["vat_12"].ToString());
                        decimal vat_exempt_sale = decimal.Parse(r["vat_exempt_sale"].ToString());

                        report.SetParameterValue("no_of_orders", no_of_orders.ToString("N2"), "Sales");
                        report.SetParameterValue("subtotal", subtotal.ToString("N2"), "Sales");
                        report.SetParameterValue("discount_deductions", discount_deductions.ToString("N2"), "Sales");
                        report.SetParameterValue("grand_total", grand_total.ToString("N2"), "Sales");
                        report.SetParameterValue("less_vat", less_vat.ToString("N2"), "Sales");
                        report.SetParameterValue("vatable_sale", vatable_sale.ToString("N2"), "Sales");
                        report.SetParameterValue("vat_12", vat_12.ToString("N2"), "Sales");
                        report.SetParameterValue("vat_exempt_sale", vat_exempt_sale.ToString("N2"), "Sales");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_orders", "0", "Sales");
                    report.SetParameterValue("subtotal", "0.00", "Sales");
                    report.SetParameterValue("discount_deductions", "0.00", "Sales");
                    report.SetParameterValue("grand_total", "0.00", "Sales");
                    report.SetParameterValue("less_vat", "0.00", "Sales");
                    report.SetParameterValue("vatable_sale", "0.00", "Sales");
                    report.SetParameterValue("vat_12", "0.00", "Sales");
                    report.SetParameterValue("vat_exempt_sale", "0.00", "Sales");
                }


                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT CONVERT(DECIMAL(18,2), SUM(subtotal)) as 'subtotal',
                                   CONVERT(DECIMAL(18,2),SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'discount_deductions',  
                                   CONVERT(DECIMAL(18,2),SUM(grand_total)) as 'grand_total' FROM transaction_details WHERE date_time BETWEEN @from AND @to AND userID = @userID AND action = 1");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                        decimal discount_deductions = decimal.Parse(r["discount_deductions"].ToString());
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());

                        report.SetParameterValue("ss_subtotal", subtotal.ToString("N2"), "StaffSales");
                        report.SetParameterValue("ss_discount_deductions", discount_deductions.ToString("N2"), "StaffSales");
                        report.SetParameterValue("ss_grand_total", grand_total.ToString("N2"), "StaffSales");
                    }
                }
                else
                {
                    report.SetParameterValue("ss_subtotal", "0.00", "StaffSales");
                    report.SetParameterValue("ss_discount_deductions", "0.00", "StaffSales");
                    report.SetParameterValue("ss_grand_total", "0.00", "StaffSales");
                }



                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                int count_retailsales = Convert.ToInt32(SQL.ReturnResult(@"SELECT COUNT(*) FROM transaction_items as ti INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref 
                                                                                 WHERE td.date_time BETWEEN @from AND @to AND td.action = 1 AND ti.type = 'R' AND td.userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_retailsales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT  SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'grand_total' FROM transaction_items as ti 
                               INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref WHERE td.date_time BETWEEN @from AND @to AND td.action = 1 AND ti.type = 'R' AND td.userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal total = decimal.Parse(r["total"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());

                        report.SetParameterValue("no_of_items", no_of_items.ToString("N2"), "RetailSales");
                        report.SetParameterValue("total", total.ToString("N2"), "RetailSales");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_items", "0.00", "RetailSales");
                    report.SetParameterValue("total", "0.00", "RetailSales");
                }



                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                int count_wholesalesales = Convert.ToInt32(SQL.ReturnResult(@"SELECT COUNT(*) FROM transaction_items as ti INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref 
                                                                                 WHERE td.date_time BETWEEN @from AND @to AND td.action = 1 AND ti.type = 'W' AND td.userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_wholesalesales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT  SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'grand_total' FROM transaction_items as ti 
                               INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref WHERE td.date_time BETWEEN @from AND @to AND td.action = 1 AND ti.type = 'W' AND td.userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal total = decimal.Parse(r["total"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());

                        report.SetParameterValue("no_of_items", no_of_items.ToString("N2"), "WholesaleSales");
                        report.SetParameterValue("total", total.ToString("N2"), "WholesaleSales");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_items", "0.00", "WholesaleSales");
                    report.SetParameterValue("total", "0.00", "WholesaleSales");
                }



                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                int count_refund = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 2 AND userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_refund > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders',
                               SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total'
                               FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                               WHERE td.action = 2 AND td.date_time BETWEEN @from AND @to AND td.userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("no_of_orders", r["no_of_orders"].ToString(), "Refund");
                        report.SetParameterValue("no_of_items", r["no_of_items"].ToString(), "Refund");
                        decimal total = decimal.Parse(r["total"].ToString());
                        report.SetParameterValue("total", total.ToString("N2"), "Refund");

                    }
                }
                else
                {
                    report.SetParameterValue("no_of_orders", "0.00", "Refund");
                    report.SetParameterValue("no_of_items", "0.00", "Refund");
                    report.SetParameterValue("total", "0.00", "Refund");
                }



                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                int count_return = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 3 AND userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_return > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders',
                               SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total'
                               FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                               WHERE td.action = 3 AND td.date_time BETWEEN @from AND @to AND td.userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("no_of_orders", r["no_of_orders"].ToString(), "Return");
                        report.SetParameterValue("no_of_items", r["no_of_items"].ToString(), "Return");
                        decimal total = decimal.Parse(r["total"].ToString());
                        report.SetParameterValue("total", total.ToString("N2"), "Return");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_orders", "0.00", "Return");
                    report.SetParameterValue("no_of_items", "0.00", "Return");
                    report.SetParameterValue("total", "0.00", "Return");
                }



                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                int count_voiditem = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM void_item WHERE date_time BETWEEN @from AND @to AND userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_voiditem > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT CONVERT(DECIMAL(18,0), SUM(quantity)) as 'no_of_items', SUM(static_price_inclusive) as 'total'
                               FROM void_item WHERE date_time BETWEEN @from AND @to AND userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("no_of_items", r["no_of_items"].ToString(), "VoidItem");
                        decimal total = decimal.Parse(r["total"].ToString());
                        report.SetParameterValue("total", total.ToString("N2"), "VoidItem");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_items", "0.00", "VoidItem");
                    report.SetParameterValue("total", "0.00", "VoidItem");
                }



                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                int count_voidtransaction = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 4 AND userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_voidtransaction > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders', SUM(grand_total) as 'total'
                               FROM transaction_details
                               WHERE action = 4 AND date_time BETWEEN @from AND @to AND userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("no_of_orders", r["no_of_orders"].ToString(), "VoidTransaction");
                        decimal total = decimal.Parse(r["total"].ToString());
                        report.SetParameterValue("total", total.ToString("N2"), "VoidTransaction");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_orders", "0.00", "VoidTransaction");
                    report.SetParameterValue("total", "0.00", "VoidTransaction");
                }



                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);
                int count_regulardiscount = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1 AND discountID <> 0 AND userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_regulardiscount > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders', SUM(disc_amt) as 'total'
                               FROM transaction_details WHERE discountID <> 0 AND action = 1 AND date_time BETWEEN @from AND @to AND userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("no_of_orders", r["no_of_orders"].ToString(), "RegularDiscount");
                        decimal total = decimal.Parse(r["total"].ToString());
                        report.SetParameterValue("total", total.ToString("N2"), "RegularDiscount");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_orders", "0.00", "RegularDiscount");
                    report.SetParameterValue("total", "0.00", "RegularDiscount");
                }



                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                int count_specialdiscount = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1 AND cus_type IN (1,2,3) AND userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_specialdiscount > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query("SELECT COUNT(*) as 'no_of_orders', SUM(grand_total) as 'total' FROM transaction_details WHERE cus_type IN (1,2,3) AND date_time BETWEEN @from AND @to AND userID = @userID AND action = 1");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("no_of_orders", r["no_of_orders"].ToString(), "SpecialDiscount");
                        decimal total = decimal.Parse(r["total"].ToString());
                        report.SetParameterValue("total", total.ToString("N2"), "SpecialDiscount");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_orders", "0.00", "SpecialDiscount");
                    report.SetParameterValue("total", "0.00", "SpecialDiscount");
                }



                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query("SELECT COUNT(*) as 'no_of_orders', SUM(grand_total) as 'total' FROM transaction_details WHERE action = 1 AND date_time BETWEEN @from AND @to AND userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("no_of_orders", r["no_of_orders"].ToString(), "PaymentMethod");
                        decimal total = decimal.Parse(r["total"].ToString());
                        report.SetParameterValue("total", total.ToString("N2"), "PaymentMethod");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_orders", "0.00", "PaymentMethod");
                    report.SetParameterValue("total", "0.00", "PaymentMethod");
                }



                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT SUM(quantity) as 'no_of_items', SUM(static_price_inclusive) as 'total' FROM transaction_items as ti
                               INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref WHERE td.date_time BETWEEN @from AND @to AND td.userID = @userID AND td.action = 1");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("no_of_items", r["no_of_items"].ToString(), "ItemSold");
                        decimal total = decimal.Parse(r["total"].ToString());
                        report.SetParameterValue("total", total.ToString("N2"), "ItemSold");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_items", "0.00", "ItemSold");
                    report.SetParameterValue("total", "0.00", "ItemSold");
                }


                CrystalReportViewer1.ReportSource = report;
                CrystalReportViewer1.Refresh();
                //}
                //catch (Exception ex)
                //{
                //    new Notification().PopUp(ex.ToString(),"","error");
                //    report.Dispose();
                //}
            }
            else
            {
                new Notification().PopUp("Please select staff to proceed.", "", "error");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFilePath = new SaveFileDialog();
            saveFilePath.Filter = "PDF Files (*.pdf*)|*.pdf";

            if (saveFilePath.ShowDialog() == DialogResult.OK)
            {
                cryRpt = report;

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = saveFilePath.FileName;
                CrExportOptions = cryRpt.ExportOptions;
                {
                    var withBlock = CrExportOptions;
                    withBlock.ExportDestinationType = ExportDestinationType.DiskFile;
                    withBlock.ExportFormatType = ExportFormatType.PortableDocFormat;
                    withBlock.DestinationOptions = CrDiskFileDestinationOptions;
                    withBlock.FormatOptions = CrFormatTypeOptions;
                }
                cryRpt.Export();

                cryRpt.Close();
                cryRpt.Dispose();
            }
        }
    }
}
