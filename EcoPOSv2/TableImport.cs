using EcoPOSControl;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class TableImport : Form
    {
        public TableImport()
        {
            InitializeComponent();
        }

        private SQLControl SQL = new SQLControl();

        public int table_import_type;

        private DataTableCollection tables;

        string file = ""; //variable for the Excel File Location

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtFile.Text = OpenFileDialog1.FileName;
                    using (var stream = File.Open(txtFile.Text, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration { ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = true } });
                            tables = result.Tables;
                            cmbSheet.Items.Clear();
                            foreach (DataTable table in tables)
                                cmbSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

            while (backgroundWorker1.IsBusy)
            {
                btnImport.Enabled = false;
                return;
            }

            btnImport.Enabled = true;
        }

        private void cmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tables[cmbSheet.SelectedItem.ToString()];
            DataGridView1.DataSource = dt;
            //DataTable dt = new DataTable(); //container for our excel data
            //DataRow row;

            //string sheetname = tables[cmbSheet.SelectedItem.ToString()].ToString();
            //sheetname = sheetname.Replace("Sheet", "");


            ////file = txtFile.Text; //get the filename with the location of the file
            //try
            //{
            //    //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file

            //    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            //    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);

            //    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[Convert.ToInt32(sheetname)];

            //    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

            //    int rowCount = excelRange.Rows.Count; //get row count of excel data

            //    int colCount = excelRange.Columns.Count; // get column count of excel data

            //    //Get the first Column of excel file which is the Column Name

            //    for (int i = 1; i <= rowCount; i++)
            //    {
            //        for (int j = 1; j <= colCount; j++)
            //        {
            //            dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
            //        }
            //        break;
            //    }

            //    //Get Row Data of Excel

            //    int rowCounter; //This variable is used for row index number
            //    for (int i = 2; i <= rowCount; i++) //Loop for available row of excel data
            //    {
            //        row = dt.NewRow(); //assign new row to DataTable
            //        rowCounter = 0;
            //        for (int j = 1; j <= colCount; j++) //Loop for available column of excel data
            //        {
            //            //check if cell is empty
            //            if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
            //            {
            //                row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
            //            }
            //            else
            //            {
            //                row[i] = "";
            //            }
            //            rowCounter++;
            //        }
            //        dt.Rows.Add(row); //add row to DataTable
            //    }

            //    DataGridView1.DataSource = dt; //assign DataTable as Datasource for DataGridview

            //    //close and clean excel process
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //    Marshal.ReleaseComObject(excelRange);
            //    Marshal.ReleaseComObject(excelWorksheet);
            //    //quit apps
            //    excelWorkbook.Close();
            //    Marshal.ReleaseComObject(excelWorkbook);
            //    excelApp.Quit();
            //    Marshal.ReleaseComObject(excelApp);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            ////DataTable dt = tables[cmbSheet.SelectedItem.ToString()];
            ////DataGridView1.DataSource = dt;
        }

        private void TableImport_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (table_import_type)
            {
                case 1 // products
               :
                    {
                        SQL.Query("DELETE FROM products");
                        if (SQL.HasException(true))
                            return;

                        SQL.Query("DELETE FROM inventory");
                        if (SQL.HasException(true))
                            return;


                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            var worker = sender as BackgroundWorker;
                            int percentage = (i + 1) * 100 / DataGridView1.Rows.Count;
                            worker.ReportProgress(percentage);

                            int categoryid = 0;
                            int warehouseID = 0;
                            //QUERY
                            SQL.AddParam("@name", DataGridView1.Rows[i].Cells[2].Value.ToString());
                            SQL.Query("Select categoryID from product_category where name=@name");
                            if (SQL.HasException(true)) return;

                            foreach (DataRow dr in SQL.DBDT.Rows)
                            {
                                categoryid = Convert.ToInt32(dr["categoryID"].ToString());
                            }


                            SQL.AddParam("@name", DataGridView1.Rows[i].Cells[7].Value.ToString());
                            SQL.Query("Select warehouseID from warehouse where name=@name");
                            if (SQL.HasException(true)) return;
                            foreach (DataRow dr in SQL.DBDT.Rows)
                            {
                                warehouseID = Convert.ToInt32(dr["warehouseID"].ToString());
                            }

                            SQL.AddParam("@name", DataGridView1.Rows[i].Cells[0].Value.ToString());
                            SQL.AddParam("@description", DataGridView1.Rows[i].Cells[1].Value.ToString());
                            SQL.AddParam("@categoryID", categoryid);
                            SQL.AddParam("@rp_inclusive", DataGridView1.Rows[i].Cells[3].Value.ToString());
                            SQL.AddParam("@wp_inclusive", DataGridView1.Rows[i].Cells[4].Value.ToString());
                            SQL.AddParam("@barcode1", DataGridView1.Rows[i].Cells[5].Value.ToString());
                            SQL.AddParam("@barcode2", DataGridView1.Rows[i].Cells[6].Value.ToString());
                            SQL.AddParam("@warehouseID", warehouseID);
                            SQL.AddParam("@s_discR", DataGridView1.Rows[i].Cells[8].Value.ToString());
                            SQL.AddParam("@s_discPWD_SC", DataGridView1.Rows[i].Cells[9].Value.ToString());
                            SQL.AddParam("@s_PWD_SC_perc", DataGridView1.Rows[i].Cells[10].Value.ToString());
                            SQL.AddParam("@s_discAth", DataGridView1.Rows[i].Cells[11].Value.ToString());
                            SQL.AddParam("@s_ask_qty", DataGridView1.Rows[i].Cells[12].Value.ToString());

                            SQL.Query(@"INSERT INTO products
                                   (description, name, categoryID, rp_inclusive, wp_inclusive, barcode1, barcode2, warehouseID, 
                                    s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty)
                                   VALUES
                                   (@description, @name, @categoryID, @rp_inclusive, @wp_inclusive, @barcode1, @barcode2, @warehouseID, 
                                    @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty)");

                            if (SQL.HasException(true))
                                return;

                            // create inventory

                            SQL.Query("INSERT INTO inventory (productID, stock_qty) VALUES ((SELECT MAX(productID) FROM products), 0)");

                            if (SQL.HasException(true))
                            {
                                MessageBox.Show("Error sa inventory");
                                return;
                            }

                        }

                        new Notification().PopUp("Import success.", "", "information");
                        this.Close();
                        break;
                    }

                case 2 // category
         :
                    {
                        SQL.Query("DELETE FROM product_category");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            var worker = sender as BackgroundWorker;
                            int percentage = (i + 1) * 100 / DataGridView1.Rows.Count;
                            worker.ReportProgress(percentage);


                            SQL.AddParam("@name", DataGridView1.Rows[i].Cells[0].Value.ToString());
                            SQL.AddParam("@s_discR", DataGridView1.Rows[i].Cells[1].Value.ToString());
                            SQL.AddParam("@s_discPWD_SC", DataGridView1.Rows[i].Cells[2].Value.ToString());
                            SQL.AddParam("@s_PWD_SC_perc", DataGridView1.Rows[i].Cells[3].Value.ToString());
                            SQL.AddParam("@s_discAth", DataGridView1.Rows[i].Cells[4].Value.ToString());
                            SQL.AddParam("@s_ask_qty", DataGridView1.Rows[i].Cells[5].Value.ToString());

                            SQL.Query(@"INSERT INTO product_category
                                   (name, s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty)
                                   VALUES
                                   (@name, @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty)
                                  ");

                            if (SQL.HasException(true))
                                return;

                            new Notification().PopUp("Import success.", "", "information");
                        }

                        break;
                    }

                case 3 // customer
         :
                    {
                        SQL.Query("DELETE FROM customer");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            int percentage = (i + 1) * 100 / DataGridView1.Rows.Count;
                            backgroundWorker1.ReportProgress(percentage);


                            SQL.AddParam("@name", DataGridView1.Rows[i].Cells[0].Value.ToString());
                            SQL.AddParam("@contact", DataGridView1.Rows[i].Cells[1].Value.ToString());
                            SQL.AddParam("@birthday", DataGridView1.Rows[i].Cells[2].Value.ToString());
                            SQL.AddParam("@add1", DataGridView1.Rows[i].Cells[3].Value.ToString());
                            SQL.AddParam("@add2", DataGridView1.Rows[i].Cells[4].Value.ToString());
                            SQL.AddParam("@email", DataGridView1.Rows[i].Cells[5].Value.ToString());
                            SQL.AddParam("@member_type_ID", DataGridView1.Rows[i].Cells[6].Value.ToString());
                            SQL.AddParam("@card_no", DataGridView1.Rows[i].Cells[7].Value.ToString());

                            SQL.Query(@"INSERT INTO customer (name, contact, birthday, add1, add2, email, member_type_ID, card_no)
                                      VALUES (@name, @contact, @birthday, @add1, @add2, @email, @member_type_ID, @card_no)");

                            if (SQL.HasException(true))
                                return;

                            new Notification().PopUp("Import success.", "", "information");
                        }

                        break;
                    }

                case 4 // member card
         :
                    {
                        SQL.Query("DELETE FROM member_card");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            int percentage = (i + 1) * 100 / DataGridView1.Rows.Count;
                            backgroundWorker1.ReportProgress(percentage);


                            SQL.AddParam("@card_no", DataGridView1.Rows[i].Cells[0].Value.ToString());

                            SQL.Query(@"INSERT INTO member_card (card_no, member_type_ID, customerID, customer_name, card_balance, status)
                                      VALUES (@card_no, 0, 0, '', 0, 'Available')");
                            if (SQL.HasException(true))
                                return;
                        }

                        new Notification().PopUp("Import success.", "", "information");
                        break;
                    }

                case 5 // membership
         :
                    {
                        SQL.Query("DELETE FROM membership");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            int percentage = (i + 1) * 100 / DataGridView1.Rows.Count;
                            backgroundWorker1.ReportProgress(percentage);

                            SQL.AddParam("@member_type_ID", DataGridView1.Rows[i].Cells[0].Value.ToString());
                            SQL.AddParam("@name", DataGridView1.Rows[i].Cells[1].Value.ToString());
                            SQL.AddParam("@discountable", DataGridView1.Rows[i].Cells[2].Value.ToString());
                            SQL.AddParam("@disc_amt", DataGridView1.Rows[i].Cells[3].Value.ToString());
                            SQL.AddParam("@disc_type", DataGridView1.Rows[i].Cells[4].Value.ToString());
                            SQL.AddParam("@expiration", DataGridView1.Rows[i].Cells[5].Value.ToString());
                            SQL.AddParam("@rewardable", DataGridView1.Rows[i].Cells[6].Value.ToString());
                            SQL.AddParam("@amt_per_pt", DataGridView1.Rows[i].Cells[7].Value.ToString());

                            SQL.Query(@"SET IDENTITY_INSERT membership ON;
                                   INSERT INTO membership (member_type_ID, name, discountable, disc_amt, disc_type, 
                                        expiration, rewardable, amt_per_pt) VALUES (@member_type_ID, @name, @discountable, 
                                        @disc_amt, @disc_type, @expiration, @rewardable, @amt_per_pt)
                                   SET IDENTITY_INSERT membership OFF;");

                            if (SQL.HasException(true))
                                return;
                        }

                        new Notification().PopUp("Import success.", "", "information");
                        break;
                    }

                case 6 // gift card
         :
                    {
                        SQL.Query("DELETE FROM giftcard");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            int percentage = (i + 1) * 100 / DataGridView1.Rows.Count;
                            backgroundWorker1.ReportProgress(percentage);


                            SQL.AddParam("@giftcard_no", DataGridView1.Rows[i].Cells[0].Value.ToString());
                            SQL.AddParam("@amount", DataGridView1.Rows[i].Cells[1].Value.ToString());
                            SQL.AddParam("@status", DataGridView1.Rows[i].Cells[2].Value.ToString());
                            SQL.AddParam("@expiration", DataGridView1.Rows[i].Cells[3].Value.ToString());

                            SQL.Query(@"INSERT INTO giftcard (giftcard_no, amount, status, expiration)
                                       VALUES (@giftcard_no, @amount, @status, @expiration)");

                            if (SQL.HasException(true))
                                return;
                        }

                        new Notification().PopUp("Import success.", "", "information");
                        break;
                    }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Import Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TableImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(progressBar1.Value != 0)
            {
                if(MessageBox.Show("If you close this form. Importing will be cancel. /n /n Are you sure do you want to close it ?", "FormClosing",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    backgroundWorker1.CancelAsync();
                    Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
