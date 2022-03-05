using CrystalDecisions.CrystalReports.Engine;
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
            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));

            //  OL.ComboValues(cmbStaff, "userID", "user_name", "users");

            OL.ComboValuesQuery(cmbStaff, @"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                                            SELECT * INTO #Temp_users
                                            FROM
                                            (
                                            SELECT ID, user_name, first_name, last_name FROM
                                            (
                                            SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name', last_name as 'last_name' FROM admin_accts
                                            UNION ALL
                                            SELECT userID, user_name, first_name, last_name FROM users
                                            ) x
                                            ) as a;
                                            SELECT ID, (first_name + ' ' + last_name) as 'user_full_name' FROM #Temp_users",
                                            "ID", "user_full_name");

            if (cmbStaff.Items.Count > 0)
            {
                cmbStaff.SelectedIndex = 0;

                //PWEDE RIN MAY GANTO.

                //btnSearch.PerformClick();
            }
            else return;
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
                DataSet ds13 = new DataSet();
                //try
                //{
                CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;

                #region sales fill
                //SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time', 
                //                                     COUNT(*) as 'no_of_items', SUM(subtotal) as 'subtotal', 
                //                                     (SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'disc_amt', 
                //                                     SUM(grand_total) as 'grand_total', SUM(less_vat) as 'less_vat', SUM(vatable_sale) as 'vatable_sale',
                //                                     SUM(vat_12) as 'vat_12', SUM(vat_exempt_sale) as 'vat_exempt_sale'
                //                                     FROM transaction_details WHERE date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                //                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time', 
                                                     COUNT(*) as 'no_of_items', SUM(total) as 'subtotal', 
                                                     (SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'disc_amt', 
                                                     SUM(grand_total) as 'grand_total', SUM(less_vat) as 'less_vat', SUM(vatable_sale) as 'vatable_sale',
                                                     SUM(vat_12) as 'vat_12', SUM(vat_exempt_sale) as 'vat_exempt_sale'
                                                     FROM transaction_details WHERE (action = 1 OR Action = 4) AND date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " AND grand_total > 0 GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);

                SQL.DBDA.Fill(ds1, "transaction_details");

                report.Subreports["Sales"].SetDataSource(ds1);

                #endregion

                #region Staff Sales Fill

                //SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT (u.first_name + ' ' + u.last_name) as 'user_first_name', SUM(subtotal) as 'subtotal',
                //                                     (SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'disc_amt',  
                //                                     SUM(grand_total) as 'grand_total' FROM transaction_details as td RIGHT JOIN users as u 
                //                                     ON td.userID = u.userID WHERE td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                //                                     AND td.userID = " + cmbStaff.SelectedValue + " GROUP BY (u.first_name + ' ' + u.last_name)", SQL.DBCon);

                SQL.DBDA.SelectCommand = new SqlCommand(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                                                          SELECT * INTO #Temp_users
                                                          FROM
                                                          (
                                                          SELECT ID, user_name, first_name, last_name FROM
                                                          (
                                                          SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name', last_name as 'last_name' FROM admin_accts
                                                          UNION ALL
                                                          SELECT userID, user_name, first_name, last_name FROM users
                                                          ) x
                                                          ) as a;
                                                          SELECT (u.first_name + ' ' + u.last_name) as 'user_first_name', SUM(subtotal) as 'subtotal',
                                                          (SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'disc_amt',  
                                                          SUM(grand_total) as 'grand_total' FROM transaction_details as td INNER JOIN #Temp_users as u 
                                                          ON td.userID = u.ID WHERE (td.action=1 or td.action=4) and td.date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                          AND td.userID = " + cmbStaff.SelectedValue + " GROUP BY (u.first_name + ' ' + u.last_name)", SQL.DBCon);

                SQL.DBDA.Fill(ds2, "transaction_details");
                report.Subreports["StaffSales"].SetDataSource(ds2);

                #endregion

                #region Retail Sales Fill

                //SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                //                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total' 
                //                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                //                                     WHERE ti.type = 'R' AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                //                                     AND td.userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total' 
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     AND (td.action=1 or td.action=4) AND ti.type = 'R' AND td.date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     AND td.userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);


                SQL.DBDA.Fill(ds3, "transaction_details");

                report.Subreports["RetailSales"].SetDataSource(ds3);

                #endregion

                #region Whole Sales Fill

                //SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                //                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total' 
                //                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                //                                     WHERE ti.type = 'W' AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                //                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total' 
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     AND (td.action=1 OR td.action=4) AND ti.type = 'W' AND td.date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);

                SQL.DBDA.Fill(ds4, "transaction_details");

                report.Subreports["WholesaleSales"].SetDataSource(ds4);

                #endregion

                #region Refund Fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     COUNT(*) as 'cus_ID_no',
                                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total'
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 2 AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds5, "transaction_details");

                report.Subreports["Refund"].SetDataSource(ds5);

                #endregion

                #region Return fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     COUNT(*) as 'cus_ID_no',
                                                     CONVERT(DECIMAL(18,0), SUM(ti.quantity)) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total'
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 3 AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds6, "transaction_details");

                report.Subreports["Return"].SetDataSource(ds6);

                #endregion

                #region Void Item Fill

                //SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                //                                     CONVERT(DECIMAL(18,0), SUM(quantity)) as 'quantity', SUM(static_price_inclusive) as 'static_price_inclusive'
                //                                     FROM void_item WHERE date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                //                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     CONVERT(DECIMAL(18,0), SUM(quantity)) as 'quantity', SUM(static_price_inclusive) as 'static_price_inclusive'
                                                     FROM void_item WHERE date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);


                SQL.DBDA.Fill(ds7, "void_item");

                report.Subreports["VoidItem"].SetDataSource(ds7);

                #endregion

                #region Void Transaction Fill

                //SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                //                                     COUNT(*) as 'no_of_items', SUM(grand_total) as 'total'
                //                                     FROM transaction_details WHERE action = 4 AND date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                //                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     COUNT(*) as 'no_of_items', SUM(selling_price_inclusive)*-1 as 'total'
                                                     FROM transaction_details as td JOIN transaction_items as ti ON td.action = 4 AND td.order_ref=ti.order_ref AND ti.selling_price_inclusive < 0 AND date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);


                SQL.DBDA.Fill(ds8, "transaction_details");

                report.Subreports["VoidTransaction"].SetDataSource(ds8);

                #endregion

                #region Regular Discount Fill

                //SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                //                                     d.disc_name as 'cus_name', COUNT(*) as 'no_of_items', SUM(td.disc_amt) as 'disc_amt'
                //                                     FROM transaction_details as td INNER JOIN discount as d ON td.discountID = d.discountID
                //                                     WHERE td.discountID <> 0 AND td.action = 1 AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                //                                     AND td.userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, td.date_time)), d.disc_name ORDER BY 'date_time'", SQL.DBCon);

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     d.disc_name as 'cus_name', COUNT(*) as 'no_of_items', SUM(td.disc_amt) as 'disc_amt'
                                                     FROM transaction_details as td INNER JOIN discount as d ON td.discountID = d.discountID
                                                     WHERE td.discountID <> 0 AND (td.action = 1 or td.action = 4) AND td.date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     AND td.userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, td.date_time)), d.disc_name ORDER BY 'date_time'", SQL.DBCon);


                SQL.DBDA.Fill(ds9, "transaction_details");

                report.Subreports["RegularDiscount"].SetDataSource(ds9);

                #endregion

                #region Special Discount Fill

                //SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                //                                     (CASE
                //                                     WHEN cus_type = 1 THEN 'Senior Citizen'
                //                                     WHEN cus_type = 2 THEN 'PWD'
                //                                     WHEN cus_type = 3 THEN 'Athlete'
                //                                     END) as 'cus_name', 
                //                                     COUNT(*) as 'no_of_items', SUM(grand_total) as 'total'
                //                                     FROM transaction_details 
                //                                     WHERE cus_type IN (1,2,3) AND action = 1 AND date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                //                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time)),  cus_type ORDER BY 'date_time'", SQL.DBCon);

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     (CASE
                                                     WHEN cus_type = 1 THEN 'Senior Citizen'
                                                     WHEN cus_type = 2 THEN 'PWD'
                                                     WHEN cus_type = 3 THEN 'Athlete'
                                                     END) as 'cus_name', 
                                                     COUNT(*) as 'no_of_items', SUM(grand_total) as 'total'
                                                     FROM transaction_details 
                                                     WHERE cus_type IN (1,2,3) AND (action = 1 or action = 4) AND date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time)),  cus_type ORDER BY 'date_time'", SQL.DBCon);


                SQL.DBDA.Fill(ds10, "transaction_details");

                report.Subreports["SpecialDiscount"].SetDataSource(ds10);

                #endregion

                #region Payment Method

                //SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                //                                     payment_method, COUNT(*) as 'no_of_items', SUM(grand_total) as 'grand_total' FROM transaction_details 
                //                                     WHERE action = 1 AND date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                //                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time)),  payment_method ORDER BY 'date_time' ASC", SQL.DBCon);

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     payment_method, COUNT(*) as 'no_of_items', SUM(grand_total) as 'grand_total' FROM transaction_details 
                                                     WHERE date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, date_time)),  payment_method ORDER BY 'date_time' ASC", SQL.DBCon);



                SQL.DBDA.Fill(ds11, "transaction_details");

                report.Subreports["PaymentMethod"].SetDataSource(ds11);

                #endregion

                #region ItemSold Fill

                //SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT DISTINCT ti.description as 'cus_name', SUM(ti.quantity) as 'no_of_items', SUM(selling_price_inclusive) as 'grand_total'
                //                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                //                                     WHERE td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                //                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY dateadd(DAY,0, datediff(day,0, td.date_time)),  ti.description ORDER BY 'date_time' ASC", SQL.DBCon);
                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT DISTINCT ti.description as 'cus_name', SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'grand_total'
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' AND selling_price_inclusive > 0
                                                     AND userID = " + cmbStaff.SelectedValue + " GROUP BY ti.description ORDER BY 'no_of_items' DESC", SQL.DBCon);


                SQL.DBDA.Fill(ds12, "transaction_details");

                report.Subreports["ItemSold"].SetDataSource(ds12);

                #endregion

                #region profit fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"select * from profit where date between '" + dtpFrom.Value + "' and '" + dtpTo.Value + "' ORDER BY date ASC", SQL.DBCon);
                SQL.DBDA.Fill(ds13, "Table1");
                report.Subreports["Profit"].SetDataSource(ds13);

                #endregion


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
                report.SetParameterValue("check_refund", 0);
                report.SetParameterValue("check_return", 0);
                report.SetParameterValue("check_voiditem", cbxVoidItems.Checked);
                report.SetParameterValue("check_voidtransaction", cbxVoidTransactions.Checked);
                report.SetParameterValue("check_regulardiscount", cbxRegularDiscounts.Checked);
                report.SetParameterValue("check_specialdiscount", cbxSpecialDiscounts.Checked);
                report.SetParameterValue("check_paymentmethod", cbxPaymentMethod.Checked);
                report.SetParameterValue("check_itemsold", cbxItemsSold.Checked);
                report.SetParameterValue("check_profit", false);

                #region Sales
                int count_sales = 0;
                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                //count_sales = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE terminal_id=@terminal_id AND date_time BETWEEN @from AND @to AND (action = 1 or action=4)"));
                count_sales = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND (action = 1 or action=4)"));
                if (SQL.HasException(true))
                {
                    MessageBox.Show("Sales");
                    return;
                }
                if (count_sales > 0)
                {
                    //SQL.AddParam("@terminal_id", cmbTerminalNames.Text);
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders', CONVERT(DECIMAL(18,2), SUM(total)) as 'subtotal',
                        CONVERT(DECIMAL(18,2), (SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted))) as 'discount_deductions',
                        CONVERT(DECIMAL(18,2), SUM(grand_total)) as 'grand_total', CONVERT(DECIMAL(18,2), SUM(less_vat)) as 'less_vat',
                        CONVERT(DECIMAL(18,2), SUM(vatable_sale)) as 'vatable_sale', CONVERT(DECIMAL(18,2), SUM(vat_12)) as 'vat_12', 
                        CONVERT(DECIMAL(18,2), SUM(vat_exempt_sale)) as 'vat_exempt_sale'
                        FROM transaction_details WHERE grand_total > 0 AND date_time BETWEEN @from AND @to AND userID=@userID AND (action = 1 OR action = 4)");
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("Sales 1");
                        return;
                    }
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal no_of_orders, subtotal, discount_deductions, grand_total, less_vat, vatable_sale, vat_12, vat_exempt_sale;
                        if (r["no_of_orders"].ToString() == "")
                        {
                            no_of_orders = 0;
                        }
                        else
                        {
                            no_of_orders = decimal.Parse(r["no_of_orders"].ToString());
                        }

                        if (r["subtotal"].ToString() == "")
                        {
                            subtotal = 0;
                        }
                        else
                        {
                            subtotal = decimal.Parse(r["subtotal"].ToString());
                        }

                        if (r["discount_deductions"].ToString() == "")
                        {
                            discount_deductions = 0;
                        }
                        else
                        {
                            discount_deductions = decimal.Parse(r["discount_deductions"].ToString());
                        }

                        if (r["grand_total"].ToString() == "")
                        {
                            grand_total = 0;
                        }
                        else
                        {
                            grand_total = decimal.Parse(r["grand_total"].ToString());
                        }

                        if (r["less_vat"].ToString() == "")
                        {
                            less_vat = 0;
                        }
                        else
                        {
                            less_vat = decimal.Parse(r["less_vat"].ToString());
                        }

                        if (r["vatable_sale"].ToString() == "")
                        {
                            vatable_sale = 0;
                        }
                        else
                        {
                            vatable_sale = decimal.Parse(r["vatable_sale"].ToString());
                        }

                        if (r["vat_12"].ToString() == "")
                        {
                            vat_12 = 0;
                        }
                        else
                        {
                            vat_12 = decimal.Parse(r["vat_12"].ToString());
                        }

                        if (r["vat_exempt_sale"].ToString() == "")
                        {
                            vat_exempt_sale = 0;
                        }
                        else
                        {
                            vat_exempt_sale = decimal.Parse(r["vat_exempt_sale"].ToString());
                        }


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

                #endregion

                #region Staff Sales
                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    //SQL.Query(@"SELECT CONVERT(DECIMAL(18,2), SUM(subtotal)) as 'subtotal',
                    //               CONVERT(DECIMAL(18,2),SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'discount_deductions',  
                    //               CONVERT(DECIMAL(18,2),SUM(grand_total)) as 'grand_total' FROM transaction_details WHERE date_time BETWEEN @from AND @to AND userID = @userID AND (action = 1 OR action=4)");

                    SQL.Query(@"SELECT CONVERT(DECIMAL(18,2), SUM(total)) as 'subtotal',
                                   CONVERT(DECIMAL(18,2),SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'discount_deductions',  
                                   CONVERT(DECIMAL(18,2),SUM(grand_total)) as 'grand_total' FROM transaction_details WHERE date_time BETWEEN @from AND @to AND userID = @userID AND (action = 1 OR action=4)");

                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("Staff Sales");
                        return;
                    }
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal subtotal = r["subtotal"].ToString() != "" ? decimal.Parse(r["subtotal"].ToString()) : 0;
                        decimal discount_deductions = r["discount_deductions"].ToString() != "" ? decimal.Parse(r["discount_deductions"].ToString()) : 0;
                        decimal grand_total = r["grand_total"].ToString() != "" ? decimal.Parse(r["grand_total"].ToString()) : 0;

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

                #endregion

                #region Retail Sales

                int count_retailsales;

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                count_retailsales = Convert.ToInt32(SQL.ReturnResult(@"SELECT COUNT(*) FROM transaction_items as ti INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref 
                                                                                 WHERE td.date_time BETWEEN @from AND @to AND (td.action = 1 or td.action=4) AND ti.type = 'R' AND td.userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_retailsales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT  SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'grand_total' FROM transaction_items as ti 
                               INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref WHERE td.date_time BETWEEN @from AND @to AND (td.action = 1 or td.action=4) AND ti.type = 'R' AND td.userID = @userID");

                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("Retail Sale 1");
                        return;
                    }
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal total, no_of_items;

                        if (r["grand_total"].ToString() == "")
                        {
                            total = 0;
                        }
                        else
                        {
                            total = decimal.Parse(r["grand_total"].ToString());
                        }

                        if (r["no_of_items"].ToString() == "")
                        {
                            no_of_items = 0;
                        }
                        else
                        {
                            no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        }


                        report.SetParameterValue("no_of_items", no_of_items.ToString("N2"), "RetailSales");
                        report.SetParameterValue("total", total.ToString("N2"), "RetailSales");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_items", "0.00", "RetailSales");
                    report.SetParameterValue("total", "0.00", "RetailSales");
                }

                #endregion

                #region Whole Sales

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);

                int count_wholesalesales = Convert.ToInt32(SQL.ReturnResult(@"SELECT COUNT(*) FROM transaction_items as ti INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref 
                                                                                 WHERE td.date_time BETWEEN @from AND @to AND (td.action = 1 or td.action=4) AND ti.type = 'W' AND td.userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_wholesalesales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT  SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'grand_total' FROM transaction_items as ti 
                               INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref WHERE td.date_time BETWEEN @from AND @to AND (td.action = 1 OR td.action=4) AND ti.type = 'W' AND td.userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());

                        report.SetParameterValue("no_of_items", no_of_items.ToString("N2"), "WholesaleSales");
                        report.SetParameterValue("total", grand_total.ToString("N2"), "WholesaleSales");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_items", "0.00", "WholesaleSales");
                    report.SetParameterValue("total", "0.00", "WholesaleSales");
                }

                #endregion

                #region Refund

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

                #endregion

                #region Return

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

                #endregion

                #region Void Item

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

                #endregion

                #region Void Transaction

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

                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders', SUM(selling_price_inclusive)*-1 as 'total'
                               FROM transaction_details as td JOIN transaction_items as ti
                               ON td.action = 4 AND td.order_ref=ti.order_ref AND selling_price_inclusive < 0 AND td.date_time BETWEEN @from AND @to AND userID = @userID");

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

                #endregion

                #region Regular Discount

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                SQL.AddParam("@userID", cmbStaff.SelectedValue);
                int count_regulardiscount = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND (action = 1 or action = 4) AND discountID <> 0 AND userID = @userID"));
                if (SQL.HasException(true))
                    return;

                if (count_regulardiscount > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders', SUM(disc_amt) as 'total'
                               FROM transaction_details WHERE discountID <> 0 AND (action = 1 OR action=4) AND date_time BETWEEN @from AND @to AND userID = @userID");

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

                #endregion

                #region Special Discounts

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

                    SQL.Query("SELECT COUNT(*) as 'no_of_orders', SUM(grand_total) as 'total' FROM transaction_details WHERE cus_type IN (1,2,3) AND date_time BETWEEN @from AND @to AND action = 1 AND userID=@userID");

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

                #endregion

                #region Payment Method

                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query("SELECT COUNT(*) as 'no_of_orders', SUM(grand_total) as 'total' FROM transaction_details WHERE (action = 1 or action = 4) AND date_time BETWEEN @from AND @to AND userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("no_of_orders", r["no_of_orders"].ToString(), "PaymentMethod");
                        decimal total = r["total"].ToString() != "" ? decimal.Parse(r["total"].ToString()) : 0;
                        report.SetParameterValue("total", total.ToString("N2"), "PaymentMethod");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_orders", "0.00", "PaymentMethod");
                    report.SetParameterValue("total", "0.00", "PaymentMethod");
                }

                #endregion

                #region Item Sold

                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.AddParam("@userID", cmbStaff.SelectedValue);

                    SQL.Query(@"SELECT SUM(quantity) as 'no_of_items', SUM(selling_price_inclusive) as 'total',SUM(discount) as 'Deductions' FROM transaction_items as ti
                               INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref WHERE selling_price_inclusive >= 0 AND td.date_time BETWEEN @from AND @to AND td.userID = @userID");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal no_of_items, total, deductions;
                        if (r["no_of_items"].ToString() == "")
                        {
                            no_of_items = 0;
                        }
                        else
                        {
                            no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        }

                        if (r["total"].ToString() == "")
                        {
                            total = 0;
                        }
                        else
                        {
                            total = decimal.Parse(r["total"].ToString());
                        }

                        if (r["Deductions"].ToString() == null || r["Deductions"].ToString() == "NULL" || r["Deductions"].ToString() == "")
                        {
                            deductions = 0;
                        }
                        else
                        {
                            deductions = decimal.Parse(r["Deductions"].ToString());
                        }

                        report.SetParameterValue("Deductions", deductions.ToString("N2"), "ItemSold");
                        report.SetParameterValue("no_of_items", no_of_items, "ItemSold");
                        report.SetParameterValue("total", total.ToString("N2"), "ItemSold");
                    }
                }
                else
                {
                    report.SetParameterValue("no_of_items", "0.00", "ItemSold");
                    report.SetParameterValue("total", "0.00", "ItemSold");
                    report.SetParameterValue("Deductions", "0.00", "ItemSold");
                }

                #endregion

                #region profit
                SQL.AddParam("@from", dtpFrom.Value.ToShortDateString());
                SQL.AddParam("@to", dtpTo.Value.ToShortDateString());
                int count_profit = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM profit WHERE date BETWEEN @from AND @to"));
                if (SQL.HasException(true))
                    return;

                if (count_profit > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value.ToShortDateString());
                    SQL.AddParam("@to", dtpTo.Value.ToShortDateString());
                    SQL.Query(@"select sum(Sales) as 'TotalSales',sum(Total_Cost) as 'TotalCost',sum(Gross) as 'TotalGross' from profit WHERE date BETWEEN @from AND @to");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("Profit_Total_Sales", r["TotalSales"].ToString() != "" ? r["TotalSales"].ToString() : "0.00", "Profit");
                        report.SetParameterValue("Profit_Total_Cost", r["TotalCost"].ToString(), "Profit");
                        report.SetParameterValue("Profit_Total_Gross", r["TotalGross"].ToString(), "Profit");
                    }
                }
                else
                {
                    report.SetParameterValue("Profit_Total_Sales", "0.00", "Profit");
                    report.SetParameterValue("Profit_Total_Cost", "0.00", "Profit");
                    report.SetParameterValue("Profit_Total_Gross", "0.00", "Profit");
                }

                #endregion

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

        private void cbxSelectall_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxSelectall.Checked == true)
            {
                cbxSales.Checked = true;
                cbxRetailSales.Checked = true;
                cbxWholesaleSales.Checked = true;
                cbxVoidItems.Checked = true;
                cbxVoidTransactions.Checked = true;
                cbxRegularDiscounts.Checked = true;
                cbxSpecialDiscounts.Checked = true;
                cbxPaymentMethod.Checked = true;
                cbxItemsSold.Checked = true;
            }
            else
            {
                cbxSales.Checked = false;
                cbxRetailSales.Checked = false;
                cbxWholesaleSales.Checked = false;
                cbxVoidItems.Checked = false;
                cbxVoidTransactions.Checked = false;
                cbxRegularDiscounts.Checked = false;
                cbxSpecialDiscounts.Checked = false;
                cbxPaymentMethod.Checked = false;
                cbxItemsSold.Checked = false;
            }
        }
    }
}
