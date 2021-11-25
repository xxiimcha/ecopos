using CrystalDecisions.Shared;
using EcoPOSControl;
using FontAwesome.Sharp;
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
    public partial class ZReadingRecords : Form
    {
        public ZReadingRecords()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        ExportImport EI = new ExportImport();

        ZReadingReport58 report = new ZReadingReport58();
        ZReadingReport80 report80 = new ZReadingReport80();
        //VARIABLES ETC

        //VARIABLES ETC


        //METHODS
        void loaddata()
        {
            SQL.AddParam("@from", dtpFrom.Value);
            SQL.AddParam("@to", dtpTo.Value);

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
                       SELECT zr.zreading_ref as 'ID', zr.zreading_ref_temp as 'Z-Reading #', 
                       start_date_time as 'Store Opened', u.user_name as 'Opened By',
                       close_date_time as 'Store Closed', ua.user_name as 'Closed By', 
                       zr.net_sales as 'Net Sales' FROM zreading as zr 
                       INNER JOIN store_start as ss ON zr.zreading_ref = ss.zreading_ref
                       INNER JOIN #Temp_users as u ON ss.open_by_userID = u.ID INNER JOIN #Temp_users as ua ON 
                       ss.close_by_userID = ua.ID WHERE no_of_transactions IS NOT NULL
                       AND start_date_time BETWEEN @from AND @to");

            if (SQL.HasException(true))
                return;

            dgvRecords.DataSource = SQL.DBDT;
            dgvRecords.Columns[0].Visible = false;
        }
        //METHODS
        private void ZReadingRecords_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));

            loaddata();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (dgvRecords.RowCount == 0)
                return;

            if (btnSort.IconChar == IconChar.SortAlphaDown)
            {
                dgvRecords.Sort(dgvRecords.Columns[2], ListSortDirection.Ascending);
                btnSort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvRecords.Sort(dgvRecords.Columns[2], ListSortDirection.Descending);
                btnSort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void btnSearchDates_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Z-Reading Reports", dgvRecords);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Main.Instance.pd_receipt_printer == "")
            {
                new Notification().PopUp("Error printing", "No receipt printer selected.");
                return;
            }

            if (Properties.Settings.Default.papersize == "58MM")
            {
                try
                {
                    report.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                    report.PrintOptions.PaperSource = PaperSource.Auto;
                    report.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception)
                {
                    new Notification().PopUp("Please select report to proceed", "Error", "error");
                    return;
                }
            }
            else
            {
                try
                {
                    report80.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                    report80.PrintOptions.PaperSource = PaperSource.Auto;
                    report80.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception)
                {
                    new Notification().PopUp("Please select report to proceed", "Error", "error");
                    return;
                }
            }
        }

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (Properties.Settings.Default.papersize == "58MM")
            {
                report = new ZReadingReport58();

                DataSet ds = new DataSet();

                try
                {
                    CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;

                    string datetime_now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

                    SQL.AddParam("@zreading_ref", dgvRecords.CurrentRow.Cells[0].Value.ToString());
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
                           SELECT zr.*, ss.*, zr.zreading_ref_temp as 'dis_zreading_ref_temp', 
                           u.user_name as 'store_open_user_name', ua.user_name as 'close_open_user_name'
                           FROM zreading as zr INNER JOIN store_start as ss ON zr.zreading_ref = ss.zreading_ref
                           INNER JOIN #Temp_users as u ON ss.open_by_userID = u.ID 
                           INNER JOIN #Temp_users as ua ON ss.close_by_userID = ua.ID
                           WHERE zr.zreading_ref = @zreading_ref");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("zreading_ref_temp", r["dis_zreading_ref_temp"].ToString());
                        report.SetParameterValue("store_open_date_time", r["start_date_time"].ToString());
                        report.SetParameterValue("store_open_user_name", r["store_open_user_name"].ToString());
                        report.SetParameterValue("store_close_date_time", r["close_date_time"].ToString());
                        report.SetParameterValue("store_close_user_name", r["close_open_user_name"].ToString());
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
                        report.SetParameterValue("net_sales", net_sales.ToString());
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

                        CrystalReportViewer1.ReportSource = report;
                        CrystalReportViewer1.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    new Notification().PopUp(ex.Message, "", "error");
                    report.Dispose();
                }
            }
            else
            {
                report80 = new ZReadingReport80();

                DataSet ds = new DataSet();

                try
                {
                    CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;

                    string datetime_now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

                    SQL.AddParam("@zreading_ref", dgvRecords.CurrentRow.Cells[0].Value.ToString());
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
                           SELECT zr.*, ss.*, zr.zreading_ref_temp as 'dis_zreading_ref_temp', 
                           u.user_name as 'store_open_user_name', ua.user_name as 'close_open_user_name'
                           FROM zreading as zr INNER JOIN store_start as ss ON zr.zreading_ref = ss.zreading_ref
                           INNER JOIN #Temp_users as u ON ss.open_by_userID = u.ID 
                           INNER JOIN #Temp_users as ua ON ss.close_by_userID = ua.ID
                           WHERE zr.zreading_ref = @zreading_ref");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report80.SetParameterValue("zreading_ref_temp", r["dis_zreading_ref_temp"].ToString());
                        report80.SetParameterValue("store_open_date_time", r["start_date_time"].ToString());
                        report80.SetParameterValue("store_open_user_name", r["store_open_user_name"].ToString());
                        report80.SetParameterValue("store_close_date_time", r["close_date_time"].ToString());
                        report80.SetParameterValue("store_close_user_name", r["close_open_user_name"].ToString());
                        report80.SetParameterValue("beginning_invoice", r["beginning_invoice"].ToString());
                        report80.SetParameterValue("ending_invoice", r["ending_invoice"].ToString());
                        report80.SetParameterValue("void_beginning_no", r["void_beginning_no"].ToString());
                        report80.SetParameterValue("void_ending_no", r["void_ending_no"].ToString());
                        decimal starting_cash = decimal.Parse(r["starting_cash"].ToString());
                        report80.SetParameterValue("starting_cash", starting_cash.ToString("N2"));
                        report80.SetParameterValue("no_of_transactions", r["no_of_transactions"].ToString());
                        decimal sales = decimal.Parse(r["sales"].ToString());
                        report80.SetParameterValue("sales", sales.ToString("N2"));
                        decimal discount_deductions = decimal.Parse(r["discount_deductions"].ToString());
                        report80.SetParameterValue("discount_deductions", discount_deductions.ToString("N2"));
                        decimal adjustments = decimal.Parse(r["adjustments"].ToString());
                        report80.SetParameterValue("adjustments", adjustments.ToString("N2"));
                        decimal net_sales = decimal.Parse(r["net_sales"].ToString());
                        report80.SetParameterValue("net_sales", net_sales.ToString());
                        decimal accumulated_adjustments = decimal.Parse(r["accumulated_adjustments"].ToString());
                        decimal accumulated_grand_total = decimal.Parse(r["accumulated_grand_total"].ToString());
                        report80.SetParameterValue("accumulated_adjustments", accumulated_adjustments.ToString("N2"));
                        report80.SetParameterValue("accumulated_grand_total", accumulated_grand_total.ToString("N2"));
                        decimal vatable_sales = decimal.Parse(r["vatable_sales"].ToString());
                        report80.SetParameterValue("vatable_sales", vatable_sales.ToString("N2"));
                        decimal vat_amount = decimal.Parse(r["vat_amount"].ToString());
                        report80.SetParameterValue("vat_amount", vat_amount.ToString("N2"));
                        decimal vat_exempt_sales = decimal.Parse(r["vat_exempt_sales"].ToString());
                        report80.SetParameterValue("vat_exempt_sales", vat_exempt_sales.ToString("N2"));
                        decimal zero_rated_sales = decimal.Parse(r["zero_rated_sales"].ToString());
                        report80.SetParameterValue("zero_rated_sales", zero_rated_sales.ToString("N2"));
                        report80.SetParameterValue("printed_on", datetime_now);

                        CrystalReportViewer1.ReportSource = report;
                        CrystalReportViewer1.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    new Notification().PopUp(ex.Message, "", "error");
                    report80.Dispose();
                }
            }
        }
    }
}
