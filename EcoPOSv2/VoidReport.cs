using CrystalDecisions.Windows.Forms;
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
    public partial class VoidReport : Form
    {
        public VoidReport()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        ExportImport EI = new ExportImport();
        CancelReceipt58 cancel_receipt = new CancelReceipt58();
        CancelReceipt80 cancel_receipt80 = new CancelReceipt80();
        Boolean print58mm { get; set; }
        Boolean print80mm { get; set; }
        private void VoidReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));
            cbxMode.SelectedIndex = 0;
            CrystalReportViewer1.ReportSource = null;
            print58mm = false;
            print80mm = false;
        }

        private void loadData()
        {

            SQL.AddParam("@from", dtpFrom.Value);
            SQL.AddParam("@to", dtpTo.Value);

            SQL.Query(@"SELECT vi.voidID, vi.productID, vt.void_order_ref_temp as 'Void No.', 
						vt.cashier_online as 'Cashier Online', vt.voided_by as 'Voided By',
                        td.order_ref_temp as 'Invoice No.', vi.description as 'Description',vi. name as 'Name', vi.type as 'Type', 
                        vi.static_price_exclusive as 'Vatable Sale', vi.static_price_vat as 'VAT', vi.static_price_inclusive as 'Price', 
                        vi.quantity as 'Qty', vi.date_time as 'Date' , vt.void_reason as 'Reason'
                        FROM void_item as vi 
                        INNER JOIN transaction_items as ti ON vi.itemID = ti.itemID
                        INNER JOIN transaction_details as td ON ti.order_ref = td.order_ref
                        INNER JOIN void_transaction as vt ON ti.order_ref = vt.order_ref
                        WHERE vi.date_time BETWEEN @from AND @to ORDER BY vi.date_time DESC");

            if (SQL.HasException(true))
                return;

            dgv_VoidReport.DataSource = SQL.DBDT;
            dgv_VoidReport.Columns[0].Visible = false;
            dgv_VoidReport.Columns[1].Visible = false;
            dgv_VoidReport.Columns[8].Width = 50;
        }

        private void loadCanceledData()
        {
            SQL.AddParam("@from", dtpFrom.Value);
            SQL.AddParam("@to", dtpTo.Value);

            SQL.Query(@"SELECT cancel_id, cashier_name as 'Cashier Online', canceled_by as 'Canceled By', cancel_reason as 'Reason', date_time as 'Date',
                canceled_item as 'Item Canceled', quantity as 'Qty', current_order_no as 'Order No.', latest_invoice as 'Latest Invoice', 
                canceled_amount as 'Amount', terminal_no 'Terminal', cancel_transaction_id as 'Cancel ID', status as 'Status' FROM canceled_items
                        WHERE date_time BETWEEN @from AND @to and status = 'Canceled_Order' ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgv_VoidReport.DataSource = SQL.DBDT;
            dgv_VoidReport.Columns[0].Visible = false;
            dgv_VoidReport.Columns[6].Width = 50;
            dgv_VoidReport.Columns[7].Width = 50;
            dgv_VoidReport.Columns[10].Width = 50;
        }
        private void loadVoidItemData()
        {
            SQL.AddParam("@from", dtpFrom.Value);
            SQL.AddParam("@to", dtpTo.Value);

            SQL.Query(@"SELECT cancel_id, cashier_name as 'Cashier Online', canceled_by as 'Voided By', cancel_reason as 'Reason', date_time as 'Date',
                canceled_item as 'Item Voided', quantity as 'Qty', current_order_no as 'Order No.', latest_invoice as 'Latest Invoice', 
                canceled_amount as 'Amount', terminal_no 'Terminal', cancel_transaction_id as 'Cancel ID', status as 'Status' FROM canceled_items
                        WHERE date_time BETWEEN @from AND @to and status = 'Void_Order' ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgv_VoidReport.DataSource = SQL.DBDT;
            dgv_VoidReport.Columns[0].Visible = false;
            dgv_VoidReport.Columns[6].Width = 50;
            dgv_VoidReport.Columns[7].Width = 50;
            dgv_VoidReport.Columns[10].Width = 50;
        }
        CancelReceipt58 DisplaySelectedData58(CrystalReportViewer viewer, String canceledID)
        {

            viewer.ReuseParameterValuesOnRefresh = false;
            CancelReceipt58 cancelReceipt58 = new CancelReceipt58();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ds.Tables.Add(dt);
            dt.Columns.Add("Qty", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            decimal sum = 0;
            //Load Items
            SQL.Query("SELECT quantity, canceled_item, canceled_amount FROM canceled_items where cancel_transaction_id = " + canceledID + " ");
            if (SQL.DBDT.Rows.Count > 0)
            {
                foreach (DataRow dr in SQL.DBDT.Rows)
                {
                    dt.Rows.Add(dr["quantity"].ToString(), dr["canceled_item"].ToString(), dr["canceled_amount"].ToString());
                    sum += decimal.Parse(dr["canceled_amount"].ToString());
                }
            }
            cancelReceipt58.SetDataSource(dt);
            if (cbxMode.Text == "Canceled Transaction")
            {
                cancelReceipt58.SetParameterValue("title", "CANCEL TRANSACTION RECEIPT");
            }
            else
            {
                cancelReceipt58.SetParameterValue("title", "VOID TRANSACTION RECEIPT");
            }
            //Load Parameters
            SQL.Query($"select TOP 1 * FROM canceled_items where cancel_transaction_id = {canceledID} ");
            foreach (DataRow dr in SQL.DBDT.Rows)
            {
                cancelReceipt58.SetParameterValue("date_time", DateTime.Parse(dr["date_time"].ToString()));
                cancelReceipt58.SetParameterValue("Terminal_No", dr["terminal_no"].ToString());
                cancelReceipt58.SetParameterValue("cashierName", dr["cashier_name"].ToString());
                cancelReceipt58.SetParameterValue("canceled_by", dr["canceled_by"].ToString());
                cancelReceipt58.SetParameterValue("cancelReason", dr["cancel_reason"].ToString());
                cancelReceipt58.SetParameterValue("currentOrderNumber", dr["current_order_no"].ToString());
                cancelReceipt58.SetParameterValue("latest_invoice", dr["latest_invoice"].ToString());
            }
            cancelReceipt58.SetParameterValue("total", sum.ToString("N2"));
            viewer.ReportSource = cancelReceipt58;
            viewer.Refresh();
            viewer.Zoom(2);
            return cancelReceipt58;
        }
        CancelReceipt80 DisplaySelectedData80(CrystalReportViewer viewer, String canceledID)
        {

            viewer.ReuseParameterValuesOnRefresh = false;
            CancelReceipt80 cancelReceipt58 = new CancelReceipt80();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ds.Tables.Add(dt);
            dt.Columns.Add("Qty", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            decimal sum = 0;
            //Load Items
            SQL.Query("SELECT quantity, canceled_item, canceled_amount FROM canceled_items where cancel_transaction_id = " + canceledID + " ");
            if (SQL.DBDT.Rows.Count > 0)
            {
                foreach (DataRow dr in SQL.DBDT.Rows)
                {
                    dt.Rows.Add(dr["quantity"].ToString(), dr["canceled_item"].ToString(), dr["canceled_amount"].ToString());
                    sum += decimal.Parse(dr["canceled_amount"].ToString());
                }
            }
            cancelReceipt58.SetDataSource(dt);
            if (cbxMode.Text == "Canceled Transaction")
            {
                cancelReceipt58.SetParameterValue("title", "CANCEL TRANSACTION RECEIPT");
            }
            else
            {
                cancelReceipt58.SetParameterValue("title", "VOID TRANSACTION RECEIPT");
            }
            //Load Parameters
            SQL.Query($"select TOP 1 * FROM canceled_items where cancel_transaction_id = {canceledID} ");
            foreach (DataRow dr in SQL.DBDT.Rows)
            {
                cancelReceipt58.SetParameterValue("date_time", DateTime.Parse(dr["date_time"].ToString()));
                cancelReceipt58.SetParameterValue("Terminal_No", dr["terminal_no"].ToString());
                cancelReceipt58.SetParameterValue("cashierName", dr["cashier_name"].ToString());
                cancelReceipt58.SetParameterValue("canceled_by", dr["canceled_by"].ToString());
                cancelReceipt58.SetParameterValue("cancelReason", dr["cancel_reason"].ToString());
                cancelReceipt58.SetParameterValue("currentOrderNumber", dr["current_order_no"].ToString());
                cancelReceipt58.SetParameterValue("latest_invoice", dr["latest_invoice"].ToString());
            }
            cancelReceipt58.SetParameterValue("total", sum.ToString("N2"));
            viewer.ReportSource = cancelReceipt58;
            viewer.Refresh();
            viewer.Zoom(2);
            return cancelReceipt58;
        }
        void RePrint(CancelReceipt58 cancelReceipt, CancelReceipt80 cancelReceipt80)
        {
            if (print58mm)
            {
                if (cancelReceipt == null)
                {
                    MessageBox.Show(this, "No Cancel/Void Transaction Selected!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        cancelReceipt.PrintOptions.NoPrinter = false;
                        cancelReceipt.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                        cancelReceipt.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                        cancelReceipt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        cancelReceipt.PrintToPrinter(1, false, 0, 0);
                    }
                    catch (Exception)
                    {
                        cancelReceipt.PrintOptions.NoPrinter = false;
                        cancelReceipt.PrintOptions.PrinterName = "Microsoft Print to PDF";
                        cancelReceipt.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                        cancelReceipt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        cancelReceipt.PrintToPrinter(1, false, 0, 0);
                    }
                    finally
                    {
                        if (cancelReceipt.IsLoaded)
                        {
                            //cancelReceipt.Close();
                            //rpt.Dispose();
                        }
                    }
                }
            }
            if (print80mm)
            {
                if (cancelReceipt80 == null)
                {
                    MessageBox.Show(this, "No Cancel/Void Transaction Selected!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        cancelReceipt80.PrintOptions.NoPrinter = false;
                        cancelReceipt80.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                        cancelReceipt80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                        cancelReceipt80.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        cancelReceipt80.PrintToPrinter(1, false, 0, 0);
                    }
                    catch (Exception)
                    {
                        cancelReceipt.PrintOptions.NoPrinter = false;
                        cancelReceipt80.PrintOptions.PrinterName = "Microsoft Print to PDF";
                        cancelReceipt80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                        cancelReceipt80.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        cancelReceipt80.PrintToPrinter(1, false, 0, 0);
                    }
                    finally
                    {
                        if (cancelReceipt80.IsLoaded)
                        {
                            //cancelReceipt80.Close();
                            //rpt.Dispose();
                        }
                    }
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Void/Cancel Report", dgv_VoidReport);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            CrystalReportViewer1.ReportSource = null;
            print58mm = false;
            print80mm = false;
            if (cbxMode.Text == "Voided Transaction")
            {
                loadData();
            }
            else if (cbxMode.Text == "Canceled Transaction")
            {
                loadCanceledData();
            }
            else
            {
                loadVoidItemData();
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            CrystalReportViewer1.ReportSource = null;
            print58mm = false;
            print80mm = false;
            if (cbxMode.Text == "Voided Transaction")
            {
                loadData();
            }
            else if (cbxMode.Text == "Canceled Transaction")
            {
                loadCanceledData();
            }
            else
            {
                loadVoidItemData();
            }
        }

        private void btnExportDGVToExcel_Click(object sender, EventArgs e)
        {
            new ExportDGVToExcel().ExportToExcel(new ExportDGVToExcel().DataGridViewToDataTable(dgv_VoidReport), "Void/Cancel Report", "Void/Cancel Report");
        }

        private void cbxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrystalReportViewer1.ReportSource = null;
            print58mm = false;
            print80mm = false;
            if (cbxMode.Text == "Voided Transaction")
            {
                loadData();
                TableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent;
                TableLayoutPanel1.ColumnStyles[0].Width = 100;
                TableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent;
                TableLayoutPanel1.ColumnStyles[1].Width = 0;
                btnGenerateRprt.Visible = true;
                btnExportExcel.Visible = true;
            }
            else if (cbxMode.Text == "Canceled Transaction")
            {
                loadCanceledData();
                TableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent;
                TableLayoutPanel1.ColumnStyles[0].Width = 75;
                TableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent;
                TableLayoutPanel1.ColumnStyles[1].Width = 25;
                btnGenerateRprt.Visible = false;
                btnExportExcel.Visible = false;
            }
            else
            {
                loadVoidItemData();
                TableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent;
                TableLayoutPanel1.ColumnStyles[0].Width = 75;
                TableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent;
                TableLayoutPanel1.ColumnStyles[1].Width = 25;
                btnGenerateRprt.Visible = false;
                btnExportExcel.Visible = false;
            }
        }

     

        private void dgv_VoidReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (cbxMode.Text == "Voided Items" || cbxMode.Text == "Canceled Transaction")
            {
                if (Properties.Settings.Default.papersize == "58MM")
                {
                    cancel_receipt.Dispose();
                    cancel_receipt = DisplaySelectedData58(CrystalReportViewer1, dgv_VoidReport.Rows[e.RowIndex].Cells[11].Value.ToString());
                    print58mm = true;
                }
                else
                {
                    cancel_receipt80.Dispose();
                    cancel_receipt80 = DisplaySelectedData80(CrystalReportViewer1, dgv_VoidReport.Rows[e.RowIndex].Cells[11].Value.ToString());
                    print80mm = true;
                }
            }
           
        }
      
        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (!print58mm && !print80mm)
            {
                MessageBox.Show(this, "No Cancel/Void Transaction Selected!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (print58mm)
                {
                    RePrint(cancel_receipt, cancel_receipt80);

                }
                if (print80mm)
                {
                    RePrint(cancel_receipt, cancel_receipt80);
                }
            }
           
        }
    }
}
