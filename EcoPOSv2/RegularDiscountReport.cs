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
    public partial class RegularDiscountReport : Form
    {
        public RegularDiscountReport()
        {
            InitializeComponent();
        }

        SQLControl SQL = new SQLControl();
        FormLoad OL = new FormLoad();
        ExportImport EI = new ExportImport();

        //METHODS
        private void LoadDiscountCMB()
        {
            OL.ComboValuesQuery(cmbDiscType, @"SELECT discountID, disc_name FROM
                                         (
                                          SELECT 0 as 'discountID', 'All category' as 'disc_name', 1 as ord
                                          UNION ALL
                                          SELECT discountID, disc_name, 2 as ord FROM discount
                                         ) x ORDER BY ord, disc_name ASC", "discountID", "disc_name");
        }
        void LoadData()
        {
            string disc_query = "t.discountID <> 0";

            if (cmbDiscType.SelectedIndex != 0)
                disc_query = "t.discountID = " + cmbDiscType.SelectedIndex;

            SQL.AddParam("@from", dtpFrom.Value);
            SQL.AddParam("@to", dtpTo.Value);

            SQL.Query(@"SELECT t.order_ref as 'ID', t.order_ref_temp as 'Invoice No.', t.date_time as 'Date', d.disc_name as 'Discount', CONVERT(decimal(18,2),t.disc_amt) as 'Disc Amt',
                        CONVERT(decimal(18,2),t.grand_total) as 'Total', CONVERT(decimal(18,2),t.less_vat) as 'Less VAT', CONVERT(decimal(18,2),t.vatable_sale) as 'VATable Sale',
                        CONVERT(decimal(18,2),t.vat_12) as 'VAT', CONVERT(decimal(18,2),t.vat_exempt_sale) as 'VAT Exempt Sale' FROM transaction_details as t
                        INNER JOIN discount as d ON t.discountID = d.discountID WHERE " + disc_query + " AND date_time BETWEEN @from AND @to ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgvRecords.DataSource = SQL.DBDT;
            dgvRecords.Columns[0].Visible = false;
            dgvRecords.Columns[1].Width = 100;
            dgvRecords.Columns[4].Width = 200;
        }
        //METHODS

        private void RegularDiscountReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));

            cmbDiscType.SelectedIndex = 0;

            LoadDiscountCMB();
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Regular Discount Report", dgvRecords);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbDiscType_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
