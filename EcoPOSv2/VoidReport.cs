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

        private void VoidReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));

            btnSearchDates.PerformClick();
        }

        private void btnSearchDates_Click(object sender, EventArgs e)
        {
            SQL.AddParam("@from", dtpFrom.Value);
            SQL.AddParam("@to", dtpTo.Value);

            SQL.Query(@"SELECT voidID, productID, order_no as 'Order No.', description as 'Description', name as 'Name', type as 'Type', 
                       static_price_exclusive as 'Vatable Sale', static_price_vat as 'VAT', static_price_inclusive as 'Price', 
                       quantity as 'Qty', date_time as 'Date' FROM void_item WHERE date_time BETWEEN @from AND @to ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgv_VoidReport.DataSource = SQL.DBDT;
            dgv_VoidReport.Columns[0].Visible = false;
            dgv_VoidReport.Columns[1].Visible = false;
            dgv_VoidReport.Columns[5].Width = 50;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (dgv_VoidReport.RowCount == 0)
                return;

            if (btnSort.IconChar == IconChar.SortAlphaDown)
            {
                dgv_VoidReport.Sort(dgv_VoidReport.Columns[10], ListSortDirection.Ascending);
                btnSort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgv_VoidReport.Sort(dgv_VoidReport.Columns[10], ListSortDirection.Descending);
                btnSort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Void Report", dgv_VoidReport);
        }
    }
}
