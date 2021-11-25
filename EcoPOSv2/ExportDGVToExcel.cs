using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    class ExportDGVToExcel
    {
        //Install ClosedXML package via Nuget
        //PM> Install-Package ClosedXML
        public void ExportToExcel(DataTable dt, String sheetName,String Filename)
        {
            try
            {
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(dt, sheetName);

                wb.Worksheet(1).Columns().AdjustToContents();
                //wb.Worksheet(1).Column(3).Hide();
                //wb.Worksheet(1).Column(6).Style.DateFormat.Format = "MMMM dd, yyyy";

                var saveFileDialog = new SaveFileDialog
                {
                    FileName = Filename,
                    Filter = "Excel |*.xlsx",
                    DefaultExt = ".xlsx"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(saveFileDialog.FileName);
                    if (MessageBox.Show("Do you want to view your exported data?", "View Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _ = new Process
                        {
                            StartInfo = new ProcessStartInfo(saveFileDialog.FileName)
                            {
                                UseShellExecute = true
                            }
                        }.Start();
                    }
                }
                wb.Dispose();
            }
            catch (Exception) { }
        }

        public DataTable DataGridViewToDataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            return dt;
        }
    }
}
