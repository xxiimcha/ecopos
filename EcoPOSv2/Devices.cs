using EcoPOSControl;
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
using System.IO.Ports;

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
                cmbRePrintPrinter.Items.Add(itemInstalledPrinters);
            }
        }

        //METHODS

        private void Devices_Load(object sender, EventArgs e)
        {
            InstalledPrinters();

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            int count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM printers_devices where terminal_id=@terminal_id"));
            if (SQL.HasException(true))
                return;
            if (count_records == 1)
            {
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                SQL.Query("SELECT * FROM printers_devices where terminal_id=@terminal_id");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    cmbReceiptPrinter.Text = r["receipt_printer_name"].ToString();
                    cmbReportPrinter.Text = r["report_printer_name"].ToString();
                    cmbRePrintPrinter.Text = r["reprint_printer_name"].ToString();
                    cbxEnable_CD.Checked = Convert.ToBoolean(r["customer_display_enabled"].ToString());
                    cmbPort.Text = r["customer_display_port"].ToString();
                }
            }
            else
            {
                cmbReceiptPrinter.SelectedIndex = 0;
                cmbRePrintPrinter.SelectedIndex = 0;
                cmbReportPrinter.SelectedIndex = 0;
                cmbPort.SelectedIndex = -1;
            }

            cmbPaperSize.Text = Properties.Settings.Default.papersize;

            //Sets number of copies to print
            int print_count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM receipt_layout"));
            if (SQL.HasException(true))
                return;

            if (print_count_records == 1)
            {
                int printCopies = Convert.ToInt32(SQL.ReturnResult("SELECT number_of_copies FROM receipt_layout WHERE configuration_ID = 1"));
                if (SQL.HasException(true))
                    return;

                if (printCopies==0)
                {
                    cmbReceiptCopies.SelectedIndex = 0;
                }
                else if (printCopies == 1)
                {
                    cmbReceiptCopies.SelectedIndex = 1;
                }
                else if (printCopies == 2)
                {
                    cmbReceiptCopies.SelectedIndex = 2;
                }
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            //Receipt number of copies to print
            int printCopies = 0;
            int print_count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM receipt_layout"));
            if (SQL.HasException(true))
                return;
            if (print_count_records == 1)
            {
                if (cmbReceiptCopies.SelectedIndex == 0)
                {
                    printCopies = 0;
                }else if (cmbReceiptCopies.SelectedIndex == 1)
                {
                    printCopies = 1;
                }
                else if (cmbReceiptCopies.SelectedIndex == 2)
                {
                    printCopies = 2;
                }

                SQL.AddParam("@printCopies", printCopies);
                SQL.Query("UPDATE receipt_layout SET number_of_copies = @printCopies");
                if (SQL.HasException(true))
                    return;
            }

            
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            int count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM printers_devices where terminal_id=@terminal_id"));
            if (SQL.HasException(true))
                return;

            SQL.AddParam("@receipt_printer_name", cmbReceiptPrinter.Text);
            SQL.AddParam("@report_printer_name", cmbReportPrinter.Text);
            SQL.AddParam("@reprint_printer_name", cmbRePrintPrinter.Text);

            SQL.AddParam("@customer_display_enabled", cbxEnable_CD.Checked);
            SQL.AddParam("@customer_display_port", cmbPort.Text);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            if (count_records == 1)
            {
                SQL.Query(@"UPDATE printers_devices SET receipt_printer_name = @receipt_printer_name, report_printer_name = @report_printer_name, 
                           customer_display_enabled = @customer_display_enabled, customer_display_port = @customer_display_port, reprint_printer_name = @reprint_printer_name where terminal_id=@terminal_id");

                if (SQL.HasException(true))
                    return;
            }
            else if (count_records == 0)
            {
                SQL.Query(@"INSERT INTO printers_devices (reprint_printer_name,receipt_printer_name, report_printer_name, customer_display_enabled, customer_display_port,terminal_id) VALUES 
                           (@reprint_printer_name,@receipt_printer_name, @report_printer_name, @customer_display_enabled, @customer_display_port,@terminal_id)");

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

            new Notification().PopUp("Settings has been saved.", "Success", "success");
            this.Close();
            //MessageBox.Show("Settings has been saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnTestDisplay_Click(object sender, EventArgs e)
        {
            FormLoad FL = new FormLoad();
            try
            {
                FL.CusDisplay("test", "test2");
            }
            catch (Exception)
            {

            }
           
        }

        private void CbxEnable_CD_CheckedChanged(object sender, EventArgs e)
        {
            cmbPort.Items.Clear();

            if(cbxEnable_CD.Checked == true)
            {
                cmbPort.Enabled = true;

                // Get a list of serial port names.
                string[] ports = SerialPort.GetPortNames();

                // Display each port name to the console.
                foreach (string port in ports)
                {
                    cmbPort.Items.Add(port);
                }

                try
                {
                    FormLoad Fl = new FormLoad();
                    Fl.CusDisplay("Customer Display", "Sample");
                }
                catch (Exception)
                {
                }
            }
            else
            {
                cmbPort.SelectedIndex = -1;
                cmbPort.Enabled = false;
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (moreOptionContainer.Visible == false)
            {
                moreOptionContainer.Visible = true;
            }
            else
            {
                moreOptionContainer.Visible = false;
            }
        }

        private void cmbPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbPaperSize.Text == "58MM")
            {
                Properties.Settings.Default.papersize = "58MM";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.papersize = "80MM";
                Properties.Settings.Default.Save();
            }
        }
    }
}
