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
        void ExportDgvToExcel(DataGridView dgv)
        {
            if(dgv.Rows.Count == 0)
            {
                new Notification().PopUp("No records found!","error","error");
                return;
            }


            SaveFileDialog savefilepath = new SaveFileDialog();
            savefilepath.Filter = "Excel File (*.xlsx*)|*.xlsx";

            if (savefilepath.ShowDialog() == DialogResult.OK)
            {
                if (dgv.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application apps = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook workbook = apps.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
                    apps.Columns.AutoFit();
                    apps.Visible = false;

                    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

                    for (int i = 1; i < dgv.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    //worksheet.SaveAs(savefilepath.FileName);
                    workbook.SaveAs(savefilepath.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    apps.Quit();

                    new Notification().PopUp("Export success", "", "information");
                }
            }
        }
        private void btnExportProducts_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM products");

            if (SQL.HasException(true)) return;

            ExportDgvToExcel(dgv);
        }
    }
}
