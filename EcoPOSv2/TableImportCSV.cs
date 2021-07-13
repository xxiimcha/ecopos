using EcoPOSControl;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class TableImportCSV : Form
    {
        public TableImportCSV()
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
                //Open file dialog, allows you to select a csv file
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        dgItems.DataSource = GetDataTableFromCSVFile(ofd.FileName);

                    txtFile.Text = ofd.FileName;

                    int numberofitems = dgItems.Rows.Count - 1;
                    lblTotalNumberOfItems.Text = numberofitems.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static DataTable GetDataTableFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {

                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {

                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn dataColumn = new DataColumn(column);
                        dataColumn.AllowDBNull = true;
                        csvData.Columns.Add(dataColumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return csvData;
        }
        BackgroundWorker workerProducts, workerCategory, workerCustomer, workerMember, workerMembership, workerGiftCard;
        private void btnImport_Click(object sender, EventArgs e)
        {
            switch (table_import_type)
            {
                case 1 // products
               :
                    {
                        SQL.Query("DELETE FROM inventory");
                        if (SQL.HasException(true))
                            return;

                        SQL.Query("DELETE FROM products");
                        if (SQL.HasException(true))
                            return;

                        workerProducts = new BackgroundWorker();
                        workerProducts.WorkerReportsProgress = true;
                        workerProducts.DoWork += WorkerCSV_DoWork;
                        workerProducts.RunWorkerCompleted += WorkerCSV_RunWorkerCompleted;
                        workerProducts.RunWorkerAsync();

                        btnBrowse.Enabled = false;
                        btnImport.Enabled = false;
                        break;
                    }

                case 2 // category
                :
                    {
                        SQL.Query("DELETE FROM product_category");
                        if (SQL.HasException(true))
                            return;

                        workerCategory = new BackgroundWorker();
                        workerCategory.WorkerReportsProgress = true;
                        workerCategory.DoWork += WorkerCategory_DoWork;
                        workerCategory.RunWorkerCompleted += WorkerCategory_RunWorkerCompleted;

                        workerCategory.RunWorkerAsync();

                        btnBrowse.Enabled = false;
                        btnImport.Enabled = false;
                        break;
                    }

                case 3 // customer
                :
                    {
                        break;
                    }

                case 4 // member card
                :
                    {
                        break;
                    }

                case 5 // membership
                :
                    {
                        
                        break;
                    }

                case 6 // gift card
                :
                    {
                        
                        break;
                    }
            }
        }

        private void WorkerCategory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Import Categories successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void WorkerCategory_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLControl sql = new SQLControl();

            for (int i = 0; i < dgItems.Rows.Count - 1; i++)
            {
                lblImportedProducts.Invoke(new System.Action(() => {
                    int total = i + 1;
                    lblImportedProducts.Text = total.ToString();
                }));


                SQL.AddParam("@name", dgItems.Rows[i].Cells[0].Value.ToString());
                SQL.AddParam("@s_discR", dgItems.Rows[i].Cells[1].Value.ToString());
                SQL.AddParam("@s_discPWD_SC", dgItems.Rows[i].Cells[2].Value.ToString());
                SQL.AddParam("@s_PWD_SC_perc", dgItems.Rows[i].Cells[3].Value.ToString());
                SQL.AddParam("@s_discAth", dgItems.Rows[i].Cells[4].Value.ToString());
                SQL.AddParam("@s_ask_qty", dgItems.Rows[i].Cells[5].Value.ToString());

                SQL.Query(@"INSERT INTO product_category
                                   (name, s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty)
                                   VALUES
                                   (@name, @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty)
                                  ");

                if (SQL.HasException(true))
                    return;
            }
        }

        private void WorkerCSV_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Import Product(s) successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void WorkerCSV_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLControl sql = new SQLControl();

            for (int i = 0; i < dgItems.Rows.Count -1; i++)
            {
                lblImportedProducts.Invoke(new System.Action(() => {
                    int total = i + 1;
                    lblImportedProducts.Text = total.ToString();
                }));


                int categoryid = 0;
                int warehouseID = 0;
                //QUERY
                SQL.AddParam("@name", dgItems.Rows[i].Cells[2].Value.ToString());
                SQL.Query("Select categoryID from product_category where name=@name");
                if (SQL.HasException(true)) return;

                foreach (DataRow dr in SQL.DBDT.Rows)
                {
                    categoryid = Convert.ToInt32(dr["categoryID"].ToString());
                }


                SQL.AddParam("@name", dgItems.Rows[i].Cells[7].Value.ToString());
                SQL.Query("Select warehouseID from warehouse where name=@name");
                if (SQL.HasException(true)) return;
                foreach (DataRow dr in SQL.DBDT.Rows)
                {
                    warehouseID = Convert.ToInt32(dr["warehouseID"].ToString());
                }

                SQL.AddParam("@name", dgItems.Rows[i].Cells[0].Value.ToString());
                SQL.AddParam("@description", dgItems.Rows[i].Cells[1].Value.ToString());
                SQL.AddParam("@categoryID", categoryid);
                SQL.AddParam("@rp_inclusive", dgItems.Rows[i].Cells[3].Value.ToString());
                SQL.AddParam("@wp_inclusive", dgItems.Rows[i].Cells[4].Value.ToString());
                SQL.AddParam("@barcode1", dgItems.Rows[i].Cells[5].Value.ToString());
                SQL.AddParam("@barcode2", dgItems.Rows[i].Cells[6].Value.ToString());
                SQL.AddParam("@warehouseID", warehouseID);
                SQL.AddParam("@s_discR", dgItems.Rows[i].Cells[8].Value.ToString());
                SQL.AddParam("@s_discPWD_SC", dgItems.Rows[i].Cells[9].Value.ToString());
                SQL.AddParam("@s_PWD_SC_perc", dgItems.Rows[i].Cells[10].Value.ToString());
                SQL.AddParam("@s_discAth", dgItems.Rows[i].Cells[11].Value.ToString());
                SQL.AddParam("@s_ask_qty", dgItems.Rows[i].Cells[12].Value.ToString());

                //INSERT INTO DATABASE

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
        }
    }
}
