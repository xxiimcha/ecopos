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
    public partial class XReadingRecords : Form
    {
        public XReadingRecords()
        {
            InitializeComponent();
        }
        //VARIABLES AND OTHERS
        SQLControl SQL = new SQLControl();
        ExportImport EI = new ExportImport();

        XReadingReport58 report = new XReadingReport58();
        XReadingReport80 report80 = new XReadingReport80();

        //VARIABLES AND OTHERS

        //METHODS
        void loadData()
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
                       SELECT xreading_ref as 'ID', xreading_ref_temp as 'X-Reading #', store_open_date_time as 'Store Opened', 
                       ua.user_name as 'Store Opened by', shift_start_date_time as 'Shift Started', shift_end_date_time as 'Shift Ended', 
                       ub.user_name as 'User', net_sales as 'Net Sales', short_over as 'Short/Over' FROM xreading as xr INNER JOIN #Temp_users as ua
                       ON xr.store_open_userID = ua.ID INNER JOIN #Temp_users as ub ON xr.shift_start_userID = ub.ID 
                       WHERE shift_start_date_time BETWEEN @from AND @to ORDER BY shift_start_date_time ASC");

            if (SQL.HasException(true))
                return;

            dgvRecords.DataSource = SQL.DBDT;
            dgvRecords.Columns[0].Visible = false;
        }

        //METHODS
        private void XReadingRecords_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));

            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("X-Reading Reports", dgvRecords);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
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

            if (Properties.Settings.Default.papersize == "58MM")
            {
                try
                {
                    report.PrintOptions.PrinterName = Main.Instance.pd_reprint_printer;
                    report.PrintOptions.PaperSource = PaperSource.Auto;
                    report.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception)
                {
                    new Notification().PopUp("Please select report to proceed", "Error", "error");
                }
            }
            else
            {
                try
                {
                    report80.PrintOptions.PrinterName = Main.Instance.pd_reprint_printer;
                    report80.PrintOptions.PaperSource = PaperSource.Auto;
                    report80.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception)
                {
                    new Notification().PopUp("Please select report to proceed", "Error", "error");
                }
            }
        }

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (Properties.Settings.Default.papersize == "58MM")
            {
                report = new XReadingReport58();

                DataSet ds = new DataSet();

                try
                {
                    CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;

                    string datetime_now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

                    SQL.AddParam("@xreading_ref", dgvRecords.CurrentRow.Cells[0].Value.ToString());
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
                           SELECT xreading.*, u.user_name as 'store_userID', us.user_name as 'shift_userID', terminal_id 
                           FROM xreading INNER JOIN #Temp_users as u
                           ON xreading.store_open_userID = u.ID INNER JOIN
                           #Temp_users as us ON xreading.shift_start_userID = us.ID WHERE 
                           xreading_ref = @xreading_ref");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("Terminal_No", r["terminal_id"].ToString());

                        report.SetParameterValue("xreading_ref_temp", r["xreading_ref_temp"].ToString());
                        report.SetParameterValue("store_open_date_time", r["store_open_date_time"].ToString());
                        report.SetParameterValue("store_open_userID", r["store_userID"].ToString());
                        report.SetParameterValue("shift_start_date_time", r["shift_start_date_time"].ToString());
                        report.SetParameterValue("shift_start_userID", r["shift_userID"].ToString());
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
                        decimal expected_drawer = decimal.Parse(r["expected_drawer"].ToString());
                        report.SetParameterValue("expected_drawer", expected_drawer.ToString("N2"));
                        decimal declared_drawer = decimal.Parse(r["declared_drawer"].ToString());
                        report.SetParameterValue("declared_drawer", declared_drawer.ToString("N2"));
                        decimal short_over = decimal.Parse(r["short_over"].ToString());
                        report.SetParameterValue("short_over", short_over.ToString("N2"));
                        report.SetParameterValue("printed_on", datetime_now);
                    }

                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.Refresh();
                    CrystalReportViewer1.Zoom(2);
                }
                catch (Exception ex)
                {
                    new Notification().PopUp(ex.Message, "error", "error");
                    report.Dispose();
                }
            }
            else
            {
                report80 = new XReadingReport80();

                DataSet ds = new DataSet();

                try
                {
                    CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;

                    string datetime_now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

                    SQL.AddParam("@xreading_ref", dgvRecords.CurrentRow.Cells[0].Value.ToString());
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
                           SELECT xreading.*, u.user_name as 'store_userID', us.user_name as 'shift_userID', terminal_id 
                           FROM xreading INNER JOIN #Temp_users as u
                           ON xreading.store_open_userID = u.ID INNER JOIN
                           #Temp_users as us ON xreading.shift_start_userID = us.ID WHERE 
                           xreading_ref = @xreading_ref");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report80.SetParameterValue("xreading_ref_temp", r["xreading_ref_temp"].ToString());
                        report80.SetParameterValue("store_open_date_time", r["store_open_date_time"].ToString());
                        report80.SetParameterValue("store_open_userID", r["store_userID"].ToString());
                        report80.SetParameterValue("shift_start_date_time", r["shift_start_date_time"].ToString());
                        report80.SetParameterValue("shift_start_userID", r["shift_userID"].ToString());
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
                        report80.SetParameterValue("net_sales", net_sales.ToString("N2"));
                        decimal expected_drawer = decimal.Parse(r["expected_drawer"].ToString());
                        report80.SetParameterValue("expected_drawer", expected_drawer.ToString("N2"));
                        decimal declared_drawer = decimal.Parse(r["declared_drawer"].ToString());
                        report80.SetParameterValue("declared_drawer", declared_drawer.ToString("N2"));
                        decimal short_over = decimal.Parse(r["short_over"].ToString());
                        report80.SetParameterValue("short_over", short_over.ToString("N2"));
                        report80.SetParameterValue("printed_on", datetime_now);
                    }

                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.Refresh();
                    CrystalReportViewer1.Zoom(2);
                }
                catch (Exception ex)
                {
                    new Notification().PopUp(ex.Message, "error", "error");
                    report80.Dispose();
                }
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
