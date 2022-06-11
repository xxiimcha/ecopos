﻿using EcoPOSControl;
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

        private void VoidReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));
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
                canceled_item as 'Item Voided', quantity as 'Qty', current_order_no as 'Order No.', latest_invoice as 'Lastest Invoice', 
                canceled_amount as 'Amount', terminal_no 'Terminal', cancel_transaction_id as 'Cancel ID', status as 'Status' FROM canceled_items
                        WHERE date_time BETWEEN @from AND @to ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgv_VoidReport.DataSource = SQL.DBDT;
            dgv_VoidReport.Columns[0].Visible = false;
            dgv_VoidReport.Columns[6].Width = 50;
            dgv_VoidReport.Columns[7].Width = 50;
            dgv_VoidReport.Columns[10].Width = 50;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Void Report", dgv_VoidReport);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (cbxMode.Text == "Voided Transaction")
            {
                loadData();
            }
            else
            {
                loadCanceledData();
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (cbxMode.Text == "Voided Transaction")
            {
                loadData();
            }
            else
            {
                loadCanceledData();
            }
        }

        private void btnExportDGVToExcel_Click(object sender, EventArgs e)
        {
            new ExportDGVToExcel().ExportToExcel(new ExportDGVToExcel().DataGridViewToDataTable(dgv_VoidReport), "Void Report", "Void Report");
        }

        private void cbxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMode.Text == "Voided Transaction")
            {
                loadData();
            }
            else
            {
                loadCanceledData();
            }
        }
    }
}
