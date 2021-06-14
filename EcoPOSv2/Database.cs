using EcoPOSControl;
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
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        ExportImport EI = new ExportImport();
        //METHODS

        //METHODS
        private void btnExportProducts_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM products");

            if (SQL.HasException(true)) return;

            EI.ExportDgvToExcel(dgv);
        }

        private void btnImportProducts_Click(object sender, EventArgs e)
        {
            TableImport frmTableImport = new TableImport();

            frmTableImport.table_import_type = 1;
            frmTableImport.ShowDialog();
        }

        private void btnExportCategory_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM product_category");
            if (SQL.HasException(true))
                return;

            dgv.DataSource = SQL.DBDT;

            EI.ExportDgvToExcel(dgv);
        }

        private void btnImportCategory_Click(object sender, EventArgs e)
        {
            TableImport frmTableImport = new TableImport();

            frmTableImport.table_import_type = 2;
            frmTableImport.ShowDialog();
        }

        private void btnExportCustomer_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM customer");
            if (SQL.HasException(true))
                return;

            dgv.DataSource = SQL.DBDT;

            EI.ExportDgvToExcel(dgv);
        }

        private void btnImportCustomer_Click(object sender, EventArgs e)
        {
            TableImport frmTableImport = new TableImport();

            frmTableImport.table_import_type = 3;
            frmTableImport.ShowDialog();
        }

        private void btnExportMC_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM member_card");
            if (SQL.HasException(true))
                return;

            dgv.DataSource = SQL.DBDT;

            EI.ExportDgvToExcel(dgv);
        }

        private void btnImportMC_Click(object sender, EventArgs e)
        {
            TableImport frmTableImport = new TableImport();

            frmTableImport.table_import_type = 4;
            frmTableImport.ShowDialog();
        }

        private void btnExportMembership_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM membership");
            if (SQL.HasException(true))
                return;

            dgv.DataSource = SQL.DBDT;

            EI.ExportDgvToExcel(dgv);
        }

        private void btnImportMembership_Click(object sender, EventArgs e)
        {
            TableImport frmTableImport = new TableImport();

            frmTableImport.table_import_type = 5;
            frmTableImport.ShowDialog();
        }

        private void btnExportGC_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM giftcard");
            if (SQL.HasException(true))
                return;

            dgv.DataSource = SQL.DBDT;

            EI.ExportDgvToExcel(dgv);
        }

        private void btnImportGC_Click(object sender, EventArgs e)
        {
            TableImport frmTableImport = new TableImport();

            frmTableImport.table_import_type = 6;
            frmTableImport.ShowDialog();
        }
    }
}
