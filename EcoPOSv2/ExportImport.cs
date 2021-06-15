using EcoPOSControl;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;
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

        public void ExportDgvToPDF(string title, DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                new Notification().PopUp("No records show in grid.", "Error","error");
                return;
            }

            var saveFilePath = new SaveFileDialog();
            saveFilePath.Filter = "PDF Files (*.pdf*)|*.pdf";
            if (saveFilePath.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var SQL = new SQLControl();
                    var Paragraph = new Paragraph(); // declaration for new paragraph
                    var PdfFile = new Document(PageSize.A4.Rotate(), 10, 10, 42, 35); // set pdf page size
                                                                                      // PdfFile.AddTitle(title) ' set our pdf title
                    PdfWriter Write = PdfWriter.GetInstance(PdfFile, new FileStream(saveFilePath.FileName, FileMode.Create));
                    PdfFile.Open();

                    // declaration font type
                    var pTitle = new Font(Font.FontFamily.TIMES_ROMAN, 14, Font.BOLD, BaseColor.BLACK);
                    var pTable = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.BLACK);

                    // insert title into pdf file
                    Paragraph = new Paragraph(new Chunk(title + Constants.vbCrLf));
                    Paragraph.Alignment = Element.ALIGN_CENTER;
                    Paragraph.SpacingAfter = 5.0f;

                    // set and add page with current settings
                    PdfFile.Add(Paragraph);

                    // create data into table
                    var PdfTable = new PdfPTable(dgv.Columns.Count);
                    // setting width of table
                    PdfTable.TotalWidth = PdfFile.PageSize.Width - 25;
                    PdfTable.LockedWidth = true;
                    var widths = new float[dgv.Columns.Count];
                    for (int i = 0, loopTo = dgv.Columns.Count - 1; i <= loopTo; i++)
                        widths[i] = 1.0f;
                    PdfTable.SetWidths(widths);
                    PdfTable.HorizontalAlignment = 0;
                    PdfTable.SpacingBefore = 5.0f;

                    // declaration pdf cells
                    var pdfcell = new PdfPCell();

                    // create pdf header
                    for (int i = 0, loopTo1 = dgv.Columns.Count - 1; i <= loopTo1; i++)
                    {
                        pdfcell = new PdfPCell(new Phrase(new Chunk(dgv.Columns[i].HeaderText, pTable)));
                        // alignment header table
                        pdfcell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        // add cells into pdf table
                        PdfTable.AddCell(pdfcell);
                    }

                    // add data into pdf table
                    for (int i = 0, loopTo2 = dgv.Rows.Count - 1; i <= loopTo2; i++)
                    {
                        for (int j = 0, loopTo3 = dgv.Columns.Count - 1; j <= loopTo3; j++)
                        {
                            pdfcell = new PdfPCell(new Phrase(dgv[j, i].Value.ToString(), pTable));
                            PdfTable.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            PdfTable.AddCell(pdfcell);
                        }
                    }

                    // add pdf table into pdf document
                    PdfFile.Add(PdfTable);
                    PdfFile.Close(); // close all sessions
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }

                new Notification().PopUp("File Exported", "","success");
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
