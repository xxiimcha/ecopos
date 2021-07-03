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
    public partial class Terminal : Form
    {
        public Terminal()
        {
            InitializeComponent();
        }

        SQLControl SQL = new SQLControl();

        TerminalReport terminal_report = new TerminalReport();
        EJournalReport report = new EJournalReport();
        ReportDocument cryRpt = new ReportDocument();

        private void btnGenerateEJournal_Click(object sender, EventArgs e)
        {
            report = new EJournalReport();

            DataSet ds = new DataSet();

            try
            {
                SQL.DBDA.SelectCommand = new SqlCommand("SELECT * FROM transaction_details WHERE date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + "'", SQL.DBCon);
                SQL.DBDA.Fill(ds, "transaction_details");

                SQL.DBDA.SelectCommand = new SqlCommand("SELECT * FROM transaction_items", SQL.DBCon);
                SQL.DBDA.Fill(ds, "transaction_items");

                report.SetDataSource(ds);

                report.SetParameterValue("business_name", Main.Instance.sd_business_name);
                report.SetParameterValue("date_from", dtpFrom.Value);
                report.SetParameterValue("date_to", dtpTo.Value);
            }
            catch (Exception ex)
            {
                new Notification().PopUp(ex.Message, "Error", "error");
                //Interaction.MsgBox(ex.ToString());
                report.Dispose();
            }

            // export to pdf
            ReportDocument cryRpt = new ReportDocument();

            SaveFileDialog saveFilePath = new SaveFileDialog();
            saveFilePath.Filter = "RTF Files (*.rtf*)|*.rtf";

            if (saveFilePath.ShowDialog() == DialogResult.OK)
            {
                cryRpt = report;

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                EditableRTFExportFormatOptions CrFormatTypeOptions = new EditableRTFExportFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = saveFilePath.FileName;
                CrExportOptions = cryRpt.ExportOptions;
                {
                    var withBlock = CrExportOptions;
                    withBlock.ExportDestinationType = ExportDestinationType.DiskFile;
                    withBlock.ExportFormatType = ExportFormatType.EditableRTF;
                    withBlock.DestinationOptions = CrDiskFileDestinationOptions;
                    withBlock.FormatOptions = CrFormatTypeOptions;
                }
                cryRpt.Export();

                cryRpt.Close();
                cryRpt.Dispose();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string date_now = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt");
            TerminalReport terminal_report = new TerminalReport();
            var ds1 = new DataSet();
            var ds2 = new DataSet();
            var ds3 = new DataSet();
            var ds4 = new DataSet();
            var ds5 = new DataSet();
            var ds6 = new DataSet();
            var ds7 = new DataSet();
            var ds8 = new DataSet();
            var ds9 = new DataSet();
            var ds10 = new DataSet();
            var ds11 = new DataSet();
            var ds12 = new DataSet();
            //try
            //{
                this.CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;

                #region sales fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time', 
                                                     COUNT(*) as 'no_of_items', SUM(subtotal) as 'subtotal', 
                                                     (SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'disc_amt', 
                                                     SUM(grand_total) as 'grand_total', SUM(less_vat) as 'less_vat', SUM(vatable_sale) as 'vatable_sale',
                                                     SUM(vat_12) as 'vat_12', SUM(vat_exempt_sale) as 'vat_exempt_sale'
                                                     FROM transaction_details WHERE date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     AND action = 1 GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds1, "transaction_details");
                terminal_report.Subreports["Sales"].SetDataSource(ds1);

                #endregion

                #region staff sales fill

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
                                                          ON td.userID = u.ID WHERE td.date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                          AND td.action = 1 GROUP BY (u.first_name + ' ' + u.last_name)", SQL.DBCon);
                SQL.DBDA.Fill(ds2, "transaction_details");
                terminal_report.Subreports["StaffSales"].SetDataSource(ds2);

                #endregion

                #region retail sales fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total' 
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 1 AND ti.type = 'R' AND td.date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds3, "transaction_details");
                terminal_report.Subreports["RetailSales"].SetDataSource(ds3);

                #endregion

                #region wholesale sales fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total' 
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 1 AND ti.type = 'W' AND td.date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds4, "transaction_details");
                terminal_report.Subreports["WholesaleSales"].SetDataSource(ds4);

                #endregion

                #region refund fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     COUNT(*) as 'cus_ID_no',
                                                     SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total'
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 2 AND td.date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds5, "transaction_details");
                terminal_report.Subreports["Refund"].SetDataSource(ds5);

                #endregion

                #region return fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     COUNT(*) as 'cus_ID_no',
                                                     CONVERT(DECIMAL(18,0), SUM(ti.quantity)) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total'
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 3 AND td.date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds6, "transaction_details");
                terminal_report.Subreports["Return"].SetDataSource(ds6);

                #endregion

                #region void item fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     CONVERT(DECIMAL(18,0), SUM(quantity)) as 'quantity', SUM(static_price_inclusive) as 'static_price_inclusive'
                                                     FROM void_item WHERE date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds7, "void_item");
                terminal_report.Subreports["VoidItem"].SetDataSource(ds7);

                #endregion

                #region void transaction fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     COUNT(*) as 'no_of_items', SUM(grand_total) as 'total'
                                                     FROM transaction_details WHERE action = 4 AND date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     GROUP BY dateadd(DAY,0, datediff(day,0, date_time))", SQL.DBCon);
                SQL.DBDA.Fill(ds8, "transaction_details");
                terminal_report.Subreports["VoidTransaction"].SetDataSource(ds8);

                #endregion

                #region regular discount fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     d.disc_name as 'cus_name', COUNT(*) as 'no_of_items', SUM(td.disc_amt) as 'disc_amt'
                                                     FROM transaction_details as td INNER JOIN discount as d ON td.discountID = d.discountID
                                                     WHERE td.discountID <> 0 AND td.action = 1 AND td.date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     GROUP BY dateadd(DAY,0, datediff(day,0, td.date_time)), d.disc_name ORDER BY 'date_time'", SQL.DBCon);
                SQL.DBDA.Fill(ds9, "transaction_details");
                terminal_report.Subreports["RegularDiscount"].SetDataSource(ds9);

                #endregion

                #region special discount fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     (CASE
                                                     WHEN cus_type = 1 THEN 'Senior Citizen'
                                                     WHEN cus_type = 2 THEN 'PWD'
                                                     WHEN cus_type = 3 THEN 'Athlete'
                                                     END) as 'cus_name', 
                                                     COUNT(*) as 'no_of_items', SUM(grand_total) as 'total'
                                                     FROM transaction_details 
                                                     WHERE cus_type IN (1,2,3) AND action = 1 AND date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     GROUP BY dateadd(DAY,0, datediff(day,0, date_time)),  cus_type ORDER BY 'date_time'", SQL.DBCon);
                SQL.DBDA.Fill(ds10, "transaction_details");
                terminal_report.Subreports["SpecialDiscount"].SetDataSource(ds10);

                #endregion

                #region payment method fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, date_time)), 110) as 'date_time',
                                                     payment_method, COUNT(*) as 'no_of_items', SUM(grand_total) as 'grand_total' FROM transaction_details 
                                                     WHERE action = 1 AND date_time BETWEEN '" + this.dtpFrom.Value + "' AND '" + this.dtpTo.Value + @"' 
                                                     GROUP BY dateadd(DAY,0, datediff(day,0, date_time)),  payment_method ORDER BY 'date_time' ASC", SQL.DBCon);
                SQL.DBDA.Fill(ds11, "transaction_details");
                terminal_report.Subreports["PaymentMethod"].SetDataSource(ds11);

                #endregion

                #region item sold fill

                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT convert(varchar, dateadd(DAY,0, datediff(day,0, td.date_time)), 110) as 'date_time',
                                                     ti.description as 'cus_name', SUM(ti.quantity) as 'no_of_items', SUM(ti.static_price_inclusive) as 'grand_total'
                                                     FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                                                     WHERE td.action = 1 AND td.date_time BETWEEN '" + dtpFrom.Value + "' AND '" + dtpTo.Value + @"' 
                                                     GROUP BY dateadd(DAY,0, datediff(day,0, td.date_time)),  ti.description ORDER BY 'date_time' ASC", SQL.DBCon);
                SQL.DBDA.Fill(ds12, "transaction_details");
                terminal_report.Subreports["ItemSold"].SetDataSource(ds12);

                #endregion

                // main report
                terminal_report.SetParameterValue("business_name", Main.Instance.sd_business_name);
                terminal_report.SetParameterValue("date_from", dtpFrom.Value.ToString());
                terminal_report.SetParameterValue("date_to", dtpTo.Value.ToString());
                terminal_report.SetParameterValue("date_now", date_now);
                terminal_report.SetParameterValue("staff", ""); //DAPAT MERON TO.

                // checks
                terminal_report.SetParameterValue("check_sales", cbxSales.Checked);
                terminal_report.SetParameterValue("check_staffsales", cbxStaffSales.Checked);
                terminal_report.SetParameterValue("check_retailsales", cbxRetailSales.Checked);
                terminal_report.SetParameterValue("check_wholesalesales", cbxWholesaleSales.Checked);
                terminal_report.SetParameterValue("check_refund", 0);
                terminal_report.SetParameterValue("check_return", 0);
                terminal_report.SetParameterValue("check_voiditem", cbxVoidItems.Checked);
                terminal_report.SetParameterValue("check_voidtransaction", cbxVoidTransactions.Checked);
                terminal_report.SetParameterValue("check_regulardiscount", cbxRegularDiscounts.Checked);
                terminal_report.SetParameterValue("check_specialdiscount", cbxSpecialDiscounts.Checked);
                terminal_report.SetParameterValue("check_paymentmethod", cbxPaymentMethod.Checked);
                terminal_report.SetParameterValue("check_itemsold", cbxItemsSold.Checked);

                #region sales

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                int count_sales = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1"));
                if (SQL.HasException(true))
                    return;
                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders', CONVERT(DECIMAL(18,2), SUM(subtotal)) as 'subtotal',
                        CONVERT(DECIMAL(18,2), (SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted))) as 'discount_deductions',
                        CONVERT(DECIMAL(18,2), SUM(grand_total)) as 'grand_total', CONVERT(DECIMAL(18,2), SUM(less_vat)) as 'less_vat',
                        CONVERT(DECIMAL(18,2), SUM(vatable_sale)) as 'vatable_sale', CONVERT(DECIMAL(18,2), SUM(vat_12)) as 'vat_12', 
                        CONVERT(DECIMAL(18,2), SUM(vat_exempt_sale)) as 'vat_exempt_sale'
                        FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1");
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

                        terminal_report.SetParameterValue("no_of_orders", no_of_orders.ToString("N2"), "Sales");
                        terminal_report.SetParameterValue("subtotal", subtotal.ToString("N2"), "Sales");
                        terminal_report.SetParameterValue("discount_deductions", discount_deductions.ToString("N2"), "Sales");
                        terminal_report.SetParameterValue("grand_total", grand_total.ToString("N2"), "Sales");
                        terminal_report.SetParameterValue("less_vat", less_vat.ToString("N2"), "Sales");
                        terminal_report.SetParameterValue("vatable_sale", vatable_sale.ToString("N2"), "Sales");
                        terminal_report.SetParameterValue("vat_12", vat_12.ToString("N2"), "Sales");
                        terminal_report.SetParameterValue("vat_exempt_sale", vat_exempt_sale.ToString("N2"), "Sales");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_orders", "0", "Sales");
                    terminal_report.SetParameterValue("subtotal", "0.00", "Sales");
                    terminal_report.SetParameterValue("discount_deductions", "0.00", "Sales");
                    terminal_report.SetParameterValue("grand_total", "0.00", "Sales");
                    terminal_report.SetParameterValue("less_vat", "0.00", "Sales");
                    terminal_report.SetParameterValue("vatable_sale", "0.00", "Sales");
                    terminal_report.SetParameterValue("vat_12", "0.00", "Sales");
                    terminal_report.SetParameterValue("vat_exempt_sale", "0.00", "Sales");
                }
                #endregion

                #region staff sales

                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query(@"SELECT CONVERT(DECIMAL(18,2), SUM(subtotal)) as 'subtotal',
                                   CONVERT(DECIMAL(18,2),SUM(disc_amt) + SUM(cus_pts_deducted) + SUM(giftcard_deducted)) as 'discount_deductions',  
                                   CONVERT(DECIMAL(18,2),SUM(grand_total)) as 'grand_total' FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                        decimal discount_deductions = decimal.Parse(r["discount_deductions"].ToString());
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());

                        terminal_report.SetParameterValue("ss_subtotal", subtotal.ToString("N2"), "StaffSales");
                        terminal_report.SetParameterValue("ss_discount_deductions", discount_deductions.ToString("N2"), "StaffSales");
                        terminal_report.SetParameterValue("ss_grand_total", grand_total.ToString("N2"), "StaffSales");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("ss_subtotal", "0.00", "StaffSales");
                    terminal_report.SetParameterValue("ss_discount_deductions", "0.00", "StaffSales");
                    terminal_report.SetParameterValue("ss_grand_total", "0.00", "StaffSales");
                }

                #endregion

                #region retail sales

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                int count_retailsales = Convert.ToInt32(SQL.ReturnResult(@"SELECT COUNT(*) FROM transaction_items as ti INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref 
                                                                                 WHERE td.date_time BETWEEN @from AND @to AND td.action = 1 AND ti.type = 'R'"));
                if (SQL.HasException(true))
                    return;
                if (count_retailsales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query(@"SELECT  SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'grand_total' FROM transaction_items as ti 
                               INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref WHERE td.date_time BETWEEN @from AND @to AND td.action = 1 AND ti.type = 'R'");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal total = decimal.Parse(r["grand_total"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());

                        terminal_report.SetParameterValue("no_of_items", no_of_items.ToString("N2"), "RetailSales");
                        terminal_report.SetParameterValue("total", total.ToString("N2"), "RetailSales");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_items", "0.00", "RetailSales");
                    terminal_report.SetParameterValue("total", "0.00", "RetailSales");
                }

                #endregion

                #region wholesale sales

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                int count_wholesalesales = Convert.ToInt32(SQL.ReturnResult(@"SELECT COUNT(*) FROM transaction_items as ti INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref 
                                                                                 WHERE td.date_time BETWEEN @from AND @to AND td.action = 1 AND ti.type = 'W'"));
                if (SQL.HasException(true))
                    return;
                if (count_wholesalesales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query(@"SELECT  SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'grand_total' FROM transaction_items as ti 
                               INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref WHERE td.date_time BETWEEN @from AND @to AND td.action = 1 AND ti.type = 'W'");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());

                        terminal_report.SetParameterValue("no_of_items", no_of_items.ToString("N2"), "WholesaleSales");
                        terminal_report.SetParameterValue("total", grand_total.ToString("N2"), "WholesaleSales");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_items", "0.00", "WholesaleSales");
                    terminal_report.SetParameterValue("total", "0.00", "WholesaleSales");
                }

                #endregion

                #region refund

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                int count_refund = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 2"));
                if (SQL.HasException(true))
                    return;
                if (count_refund > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders',
                               SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total'
                               FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                               WHERE td.action = 2 AND td.date_time BETWEEN @from AND @to");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal total = decimal.Parse(r["total"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        decimal no_of_orders = decimal.Parse(r["no_of_orders"].ToString());

                        terminal_report.SetParameterValue("no_of_orders", no_of_orders.ToString("N2"), "Refund");
                        terminal_report.SetParameterValue("no_of_items", no_of_items.ToString("N2"), "Refund");
                        terminal_report.SetParameterValue("total", total.ToString("N2"), "Refund");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_orders", "0.00", "Refund");
                    terminal_report.SetParameterValue("no_of_items", "0.00", "Refund");
                    terminal_report.SetParameterValue("total", "0.00", "Refund");
                }

                #endregion

                #region return

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                int count_return = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 3"));
                if (SQL.HasException(true))
                    return;
                if (count_return > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders',
                               SUM(ti.quantity) as 'no_of_items', SUM(ti.selling_price_inclusive) as 'total'
                               FROM transaction_details as td INNER JOIN transaction_items as ti ON td.order_ref = ti.order_ref
                               WHERE td.action = 3 AND td.date_time BETWEEN @from AND @to");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        decimal total = decimal.Parse(r["total"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        decimal no_of_orders = decimal.Parse(r["no_of_orders"].ToString());

                        terminal_report.SetParameterValue("no_of_orders", no_of_orders.ToString("N2"), "Return");
                        terminal_report.SetParameterValue("no_of_items", no_of_items.ToString("N2"), "Return");
                        terminal_report.SetParameterValue("total", total.ToString("N2"), "Return");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_orders", "0.00", "Return");
                    terminal_report.SetParameterValue("no_of_items", "0.00", "Return");
                    terminal_report.SetParameterValue("total", "0.00", "Return");
                }

                #endregion

                #region void item

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                int count_voiditem = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM void_item WHERE date_time BETWEEN @from AND @to"));
                if (SQL.HasException(true))
                    return;
                if (count_voiditem > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query(@"SELECT CONVERT(DECIMAL(18,0), SUM(quantity)) as 'no_of_items', SUM(static_price_inclusive) as 'total'
                               FROM void_item WHERE date_time BETWEEN @from AND @to");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        terminal_report.SetParameterValue("no_of_items", r["no_of_items"], "VoidItem");
                        decimal total = decimal.Parse(r["total"].ToString());
                        terminal_report.SetParameterValue("total", total.ToString("N2"), "VoidItem");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_items", "0.00", "VoidItem");
                    terminal_report.SetParameterValue("total", "0.00", "VoidItem");
                }


                #endregion

                #region void transaction

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                int count_voidtransaction = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 4"));
                if (SQL.HasException(true))
                    return;
                if (count_voidtransaction > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders', SUM(grand_total) as 'total'
                               FROM transaction_details
                               WHERE action = 4 AND date_time BETWEEN @from AND @to");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        terminal_report.SetParameterValue("no_of_orders", r["no_of_orders"], "VoidTransaction");
                        decimal total = decimal.Parse(r["total"].ToString());
                        terminal_report.SetParameterValue("total",total.ToString("N2"), "VoidTransaction");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_orders", "0.00", "VoidTransaction");
                    terminal_report.SetParameterValue("total", "0.00", "VoidTransaction");
                }

                #endregion

                #region regular discount

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                int count_regulardiscount = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1 AND discountID <> 0"));
                if (SQL.HasException(true))
                    return;
                if (count_regulardiscount > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query(@"SELECT COUNT(*) as 'no_of_orders', SUM(disc_amt) as 'total'
                               FROM transaction_details WHERE discountID <> 0 AND action = 1 AND date_time BETWEEN @from AND @to");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        terminal_report.SetParameterValue("no_of_orders", r["no_of_orders"], "RegularDiscount");
                        decimal total = decimal.Parse(r["total"].ToString());
                        terminal_report.SetParameterValue("total", total.ToString("N2"), "RegularDiscount");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_orders", "0.00", "RegularDiscount");
                    terminal_report.SetParameterValue("total", "0.00", "RegularDiscount");
                }

                #endregion

                #region special discount

                SQL.AddParam("@from", dtpFrom.Value);
                SQL.AddParam("@to", dtpTo.Value);
                int count_specialdiscount = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND action = 1 AND cus_type IN (1,2,3)"));
                if (SQL.HasException(true))
                    return;
                if (count_specialdiscount > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query("SELECT COUNT(*) as 'no_of_orders', SUM(grand_total) as 'total' FROM transaction_details WHERE cus_type IN (1,2,3) AND date_time BETWEEN @from AND @to AND action = 1");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        terminal_report.SetParameterValue("no_of_orders", r["no_of_orders"], "SpecialDiscount");
                        decimal total = decimal.Parse(r["total"].ToString());
                        terminal_report.SetParameterValue("total", total.ToString("N2"), "SpecialDiscount");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_orders", "0.00", "SpecialDiscount");
                    terminal_report.SetParameterValue("total", "0.00", "SpecialDiscount");
                }

                #endregion

                #region payment method

                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query("SELECT COUNT(*) as 'no_of_orders', SUM(grand_total) as 'total' FROM transaction_details WHERE action = 1 AND date_time BETWEEN @from AND @to");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        terminal_report.SetParameterValue("no_of_orders", r["no_of_orders"], "PaymentMethod");
                        decimal total = decimal.Parse(r["total"].ToString());
                        terminal_report.SetParameterValue("total", total.ToString("N2"), "PaymentMethod");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_orders", "0.00", "PaymentMethod");
                    terminal_report.SetParameterValue("total", "0.00", "PaymentMethod");
                }

                #endregion

                #region item sold

                if (count_sales > 0)
                {
                    SQL.AddParam("@from", dtpFrom.Value);
                    SQL.AddParam("@to", dtpTo.Value);
                    SQL.Query(@"SELECT SUM(quantity) as 'no_of_items', SUM(static_price_inclusive) as 'total' FROM transaction_items as ti
                               INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref WHERE td.date_time BETWEEN @from AND @to AND action = 1");
                    if (SQL.HasException(true))
                        return;
                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        terminal_report.SetParameterValue("no_of_items", r["no_of_items"], "ItemSold");
                        decimal total = decimal.Parse(r["total"].ToString());
                        terminal_report.SetParameterValue("total", total.ToString("N2"), "ItemSold");
                    }
                }
                else
                {
                    terminal_report.SetParameterValue("no_of_items", "0.00", "ItemSold");
                    terminal_report.SetParameterValue("total", "0.00", "ItemSold");
                }

                #endregion

                this.CrystalReportViewer1.ReportSource = terminal_report;
                this.CrystalReportViewer1.Refresh();
            //}
            //catch (Exception ex)
            //{
            //    new Notification().PopUp(ex.Message, "", "error");
            //    terminal_report.Dispose();
            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFilePath = new SaveFileDialog();
            saveFilePath.Filter = "PDF Files (*.pdf*)|*.pdf";

            if (saveFilePath.ShowDialog() == DialogResult.OK)
            {
                cryRpt = terminal_report;

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

        private void Terminal_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSelectAll.Checked == true)
            {
                cbxSales.Checked = true;
                cbxStaffSales.Checked = true;
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
                cbxStaffSales.Checked = false;
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
