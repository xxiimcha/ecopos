﻿using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class Devices : Form
    {
        public Devices()
        {
            InitializeComponent();
        }

        SQLControl SQL = new SQLControl();

        //METHODS
        private void InstalledPrinters()
        {
            // find all installed printers in this computer
            foreach (string itemInstalledPrinters in PrinterSettings.InstalledPrinters)
            {
                cmbReceiptPrinter.Items.Add(itemInstalledPrinters);
                cmbReportPrinter.Items.Add(itemInstalledPrinters);
            }
        }

        //METHODS

        private void Devices_Load(object sender, EventArgs e)
        {
            InstalledPrinters();

            int count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM printers_devices"));
            if (SQL.HasException(true))
                return;

            if (count_records == 1)
            {
                SQL.Query("SELECT * FROM printers_devices");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    cmbReceiptPrinter.Text = r["receipt_printer_name"].ToString();
                    cmbReportPrinter.Text = r["report_printer_name"].ToString();
                    cbxEnable_CD.Checked = Convert.ToBoolean(r["customer_display_enabled"].ToString());
                    cmbPort.Text = r["customer_display_port"].ToString();
                }
            }
            else
            {
                cmbReceiptPrinter.SelectedIndex = 0;
                cmbReportPrinter.SelectedIndex = 0;
                cmbPort.SelectedIndex = 0;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            int count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM printers_devices"));
            if (SQL.HasException(true))
                return;

            SQL.AddParam("@receipt_printer_name", cmbReceiptPrinter.Text);
            SQL.AddParam("@report_printer_name", cmbReportPrinter.Text);
            SQL.AddParam("@customer_display_enabled", cbxEnable_CD.Checked);
            SQL.AddParam("@customer_display_port", cmbPort.Text);

            if (count_records == 1)
            {
                SQL.Query(@"UPDATE printers_devices SET receipt_printer_name = @receipt_printer_name, report_printer_name = @report_printer_name, 
                           customer_display_enabled = @customer_display_enabled, customer_display_port = @customer_display_port WHERE configuration_ID = 1");

                if (SQL.HasException(true))
                    return;
            }
            else if (count_records == 0)
            {
                SQL.Query(@"INSERT INTO printers_devices (receipt_printer_name, report_printer_name, customer_display_enabled, customer_display_port) VALUES 
                           (@receipt_printer_name, @report_printer_name, @customer_display_enabled, @customer_display_port)");

                if (SQL.HasException(true))
                    return;
            }
            else
                return;

            // update global variables in main form
            Main.Instance.pd_receipt_printer = cmbReceiptPrinter.Text;
            Main.Instance.pd_report_printer = cmbReportPrinter.Text;
            Main.Instance.pd_customer_display_enabled = cbxEnable_CD.Checked;
            Main.Instance.pd_customer_display_port = cmbPort.Text;

            MessageBox.Show("Settings has been saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
