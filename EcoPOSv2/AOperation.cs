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
    public partial class AOperation : Form
    {
        public AOperation()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        ORItems report = new ORItems();
        ReportDocument cryRpt = new ReportDocument();

        bool clickedOnce = false;
        public static AOperation _AOperation;
        public static AOperation Instance
        {
            get
            {
                if (_AOperation == null)
                {
                    _AOperation = new AOperation();
                }
                return _AOperation;
            }
        }

        public void LoadOperation()
        {
            SQL.AddParam("@from", dtpFrom.Value);
            SQL.AddParam("@to", dtpTo.Value);

            SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                       SELECT * INTO #Temp_users
                       FROM
                       (
                       SELECT ID, user_name FROM
                       (
                       SELECT adminID as 'ID', user_name as 'user_name' FROM admin_accts
                       UNION ALL
                       SELECT userID, user_name FROM users
                       ) x
                       ) as a;
                       SELECT operationID as 'ID', operation as 'Operation', 
                       isu.name as 'Supplier', 
                       remarks as 'Remarks', total as 'Total_Amount', 
                       qty as 'Qty', date_time as 'Date', 
                       u.user_name as 'Username', 
                       io.supplierID FROM inventory_operation as io
                       INNER JOIN inventory_supplier as isu ON io.supplierID = isu.supplierID INNER JOIN #Temp_users as u ON
                       u.ID = io.userID WHERE 
                       io.date_time BETWEEN @from AND @to");

            if (SQL.HasException(true))
                return;

            dgvOR.DataSource = SQL.DBDT;
            dgvOR.Columns[0].Visible = false;
            dgvOR.Columns[8].Visible = false;
        }

        private void AOperation_Load(object sender, EventArgs e)
        {
            _AOperation = this;

            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));

            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadOperation();
        }

        private void btnAdjCost_Click(object sender, EventArgs e)
        {
            if (clickedOnce == false)
                return;

            if (dgvOR.SelectedRows.Count > 0)
            {
                if (dgvOR.CurrentRow.Cells[1].Value.ToString() == "Purchase Inventory")
                {
                    AdjustCost frmAdjustCost = new AdjustCost();

                    frmAdjustCost.operationID = dgvOR.CurrentRow.Cells[0].Value.ToString();
                    frmAdjustCost.txtNewCost.Text = dgvOR.CurrentRow.Cells[4].Value.ToString();
                    frmAdjustCost.supplierID = dgvOR.CurrentRow.Cells[8].Value.ToString();
                    frmAdjustCost.frmAOperation = this;

                    frmAdjustCost.ShowDialog();
                }
            }
            else
                new Notification().PopUp("No selected row.", "Error", "error");
        }

        private void btnAdjInventory_Click(object sender, EventArgs e)
        {
            if (clickedOnce == false)
                return;

            if (dgvOR.SelectedRows.Count > 0)
            {
                if (dgvOR.CurrentRow.Cells[1].Value.ToString() == "Purchase Inventory")
                {
                    AdjustInventory frmAdjustInventory = new AdjustInventory();
                    frmAdjustInventory.operationID = dgvOR.CurrentRow.Cells[0].Value.ToString();
                    frmAdjustInventory.supplierID = dgvOR.CurrentRow.Cells[8].Value.ToString();
                    frmAdjustInventory.frmAOperation = this;

                    frmAdjustInventory.ShowDialog();
                }
            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            if (clickedOnce == false)
                return;

            if (dgvOR.SelectedRows.Count > 0)
            {
                OREditInfo frmOREditInfo = new OREditInfo();

                frmOREditInfo.operationID = dgvOR.CurrentRow.Cells[0].Value.ToString();
                frmOREditInfo.txtRemarks.Text = dgvOR.CurrentRow.Cells[3].Value.ToString();
                frmOREditInfo.txtTotal.Text = dgvOR.CurrentRow.Cells[4].Value.ToString();
                frmOREditInfo.frmAOperation = this;
                frmOREditInfo.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (clickedOnce == false)
                return;


            bool checkprinter = Main.PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("Printer Is offline", "Error", "error");
                return;
            }
            
            report.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
            report.PrintOptions.PaperSource = PaperSource.Auto;
            report.PrintToPrinter(1, false, 0, 0);

            this.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clickedOnce == false)
                return;

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

        private void dgvOR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            clickedOnce = true;

            DataSet ds = new DataSet();

            //try
            //{
                CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;
                SQL.Query("Select product_name, qty FROM inventory_operation_items WHERE operationID = " + dgvOR.CurrentRow.Cells[0].Value.ToString());
                //SQL.DBDA.SelectCommand = new SqlCommand("Select product_name, qty FROM inventory_operation_items WHERE operationID = " + dgvOR.CurrentRow.Cells[0].Value.ToString() + "", SQL.DBCon);
                SQL.DBDA.Fill(ds, "inventory_operation_items");

                report.SetDataSource(ds);

                SQL.AddParam("@operationID", dgvOR.CurrentRow.Cells[0].Value.ToString());
                SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                           SELECT * INTO #Temp_users
                           FROM
                           (
                           SELECT ID, user_name FROM
                           (
                           SELECT adminID as 'ID', user_name as 'user_name' FROM admin_accts
                           UNION ALL
                           SELECT userID, user_name FROM users
                           ) x
                           ) as a;
                           SELECT operationID, operation, isu.name As 'supplier', 
                           remarks, total, qty, date_time, t.user_name as 'username' FROM inventory_operation as io
                           INNER JOIN inventory_supplier as isu ON io.supplierID = isu.supplierID INNER JOIN #Temp_users as t ON
                           t.ID = io.userID WHERE io.operationID = @operationID");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    report.SetParameterValue("operationID", r["operationID"].ToString());
                    report.SetParameterValue("operation", r["operation"].ToString());
                    report.SetParameterValue("supplier", r["supplier"].ToString());
                    report.SetParameterValue("date", r["date_time"].ToString());
                    report.SetParameterValue("user", r["username"].ToString());
                    report.SetParameterValue("qty", r["qty"].ToString());
                    report.SetParameterValue("amount", r["total"].ToString());
                    report.SetParameterValue("remarks", r["remarks"].ToString());

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
