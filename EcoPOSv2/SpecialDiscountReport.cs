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
    public partial class SpecialDiscountReport : Form
    {
        public SpecialDiscountReport()
        {
            InitializeComponent();
        }

        SQLControl SQL = new SQLControl();
        ExportImport EI = new ExportImport();
        //METHODS
        void LoadSpecialDiscount()
        {
            string cus_query = "cus_type <> 0 AND cus_type <> 4";

            if (cmbCusType.SelectedIndex != 0)
                cus_query = "cus_type = " + cmbCusType.SelectedIndex;

            SQL.AddParam("@from", dtpFrom.Value);
            SQL.AddParam("@to", dtpTo.Value);

            SQL.Query(@"SELECT order_ref as 'ID', order_ref_temp as 'Invoice No.', date_time as 'Date', cus_name as 'Name', 
                       cus_special_ID_no as 'ID No.', CONVERT(decimal(18,2),grand_total) as 'Total', CONVERT(decimal(18,2),disc_amt) as 'Discount', 
                       CONVERT(decimal(18,2),less_vat) as 'Less VAT', CONVERT(decimal(18,2),vatable_sale) as 'VATable Sale', CONVERT(decimal(18,2),vat_12) as 'VAT', 
                       CONVERT(decimal(18,2),vat_exempt_sale) as 'VAT Exempt Sale' FROM transaction_details WHERE " + cus_query + " AND date_time BETWEEN @from AND @to ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgvRecords.DataSource = SQL.DBDT;
            dgvRecords.Columns[0].Visible = false;
            dgvRecords.Columns[1].Width = 100;
            dgvRecords.Columns[4].Width = 200;
        }
        //METHODS
        private void SpecialDiscountReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Parse(string.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(string.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 23:59:59"));
            cmbCusType.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSpecialDiscount();
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

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Special Discount Report", dgvRecords);
        }
    }
}
