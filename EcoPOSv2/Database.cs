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

        }
    }
}
