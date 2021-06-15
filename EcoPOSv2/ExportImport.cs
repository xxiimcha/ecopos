using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    class ExportImport
    {
        public void ExportDgvToPDF(string title, DataGridView dvg)
        {
            if (dvg.Rows.Count == 0)
            {
                new Notification().PopUp("No records show in grid.", "", "error");
                return;
            }

            SaveFileDialog saveFilePath = new SaveFileDialog();
            saveFilePath.Filter = "PDF Files (*.pdf*)|*.pdf";

            if (saveFilePath.ShowDialog() == DialogResult.OK)
            {
                //Creating iTextSharp Table from the DataTable data
                PdfPTable pdfTable = new PdfPTable(dvg.ColumnCount);
                pdfTable.DefaultCell.Padding = 5;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;

                //Adding Header row
                foreach (DataGridViewColumn column in dvg.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                    pdfTable.AddCell(cell);
                }

                //Adding DataRow
                foreach (DataGridViewRow row in dvg.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                }
                string date = DateTime.Now.ToString("MM-dd-yyyy");
                //Exporting to PDF
                //string folderPath = "C:\\Users\\" + Environment.UserName + "\\Desktop\\";
                //if (!Directory.Exists(folderPath))
                //{
                //    Directory.CreateDirectory(folderPath);
                //}
                using (FileStream stream = new FileStream(title+"-"+Path.GetFullPath(saveFilePath.FileName), FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10, 10, 42, 35);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    Paragraph Header = new Paragraph("Transaction Reports", FontFactory.GetFont(FontFactory.TIMES, 45, iTextSharp.text.Font.NORMAL));
                    Header.Alignment = Element.ALIGN_CENTER;
                    PdfPTable footerTbl = new PdfPTable(1);
                    footerTbl.TotalWidth = 300;
                    Paragraph paragraph = new Paragraph();
                    pdfDoc.Add(Header);
                    Paragraph Space = new Paragraph(" ");
                    pdfDoc.Add(Space);
                    paragraph.Add(title);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    paragraph.SpacingAfter = 5.0F;
                    paragraph.Add(new Paragraph(" "));
                    pdfDoc.Add(paragraph);
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();

                    new Notification().PopUp("Transaction Reports has been Created as PDF", "", "success");
                }
            }
        }

        public void ExportDgvToExcel(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                new Notification().PopUp("No records found!", "error", "error");
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
    }
}
