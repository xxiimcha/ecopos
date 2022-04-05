﻿using EcoPOSControl;
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
        Boolean toClose = false;
        Boolean isImporting = false;

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
                    pbLoad.Maximum = numberofitems > 0 ? numberofitems : 100;
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

        private void TableImportCSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnImport.Enabled == false)
            {
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isImporting)
            {
                toClose = true;
            }
            else
            {
                Close();
            }
            
        }

        private void bulkImport()
        {
            SQL.AddParam("@dir", txtFile.Text);
            SQL.Query(@"BULK INSERT products FROM @dir WITH (
                        FORMAT = 'CSV',
                        FIRSTROW = 2,
                        FIELDTERMINATOR = ',',
                        ROWTERMINATOR = '\n'
                    )");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if(int.Parse(lblTotalNumberOfItems.Text) > 1)
            {
                switch (table_import_type)
                {
                    case 1 // products
                   :
                        {
                            if (MessageBox.Show("Do you want to overwrite your current products and inventory?", "Products and Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
                            }
                            break;
                        }

                    case 2 // category
                    :
                        {
                            if (MessageBox.Show("Do you want to overwrite your current categories?", "Category", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
                            }
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
            else
            {
                new Notification().PopUp("Please enter a valid CSV file with atleast 1 data.", "Error", "error");
            }
        }

        private void WorkerCategory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Import Categories successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnImport.Enabled = true;
            this.Close();
        }

        private void WorkerCategory_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLControl sql = new SQLControl();
            isImporting = true;
            for (int i = 0; i < dgItems.Rows.Count - 1; i++)
            {
                if (toClose)
                {
                    break;
                }

                lblImportedProducts.Invoke(new System.Action(() => {
                    int total = i + 1;
                    lblImportedProducts.Text = total.ToString();
                    pbLoad.Value = total;

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
            isImporting = false;
        }

        private void WorkerCSV_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Import Product(s) successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnImport.Enabled = true;
            this.Close();
        }
        private void WorkerCSV_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLControl Psql = new SQLControl();
            isImporting = true;
            for (int i = 0; i < dgItems.Rows.Count -1; i++)
            {
                if (toClose)
                {
                    break;
                }

                lblImportedProducts.Invoke(new System.Action(() => {
                    int total = i + 1;
                    lblImportedProducts.Text = total.ToString();
                    pbLoad.Value = total;
                }));


                int categoryid = 0;
                int warehouseID = 0;

                //Checks if category name exists in database
                Psql.AddParam("@name", dgItems.Rows[i].Cells[2].Value.ToString());
                int categoryExistence = int.Parse(Psql.ReturnResult("SELECT COUNT(categoryID) FROM product_category WHERE name=@name"));
                if (Psql.HasException(true)) return;

                if (categoryExistence > 0)
                {
                    //do nothing
                }else
                {
                    //Automatically creates category that does not exist in database
                    Psql.AddParam("@name", dgItems.Rows[i].Cells[2].Value.ToString());
                    Psql.Query(@"INSERT INTO product_category
                                   (name, s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty)
                                   VALUES
                                   (@name, 0, 0, 0, 0, 0)
                                  ");
                    if (Psql.HasException(true)) return;
                }

                //Sets the ID of the category when adding the product
                Psql.AddParam("@name", dgItems.Rows[i].Cells[2].Value.ToString());
                Psql.Query("Select categoryID from product_category where name=@name");
                if (Psql.HasException(true)) return;

                foreach (DataRow dr in Psql.DBDT.Rows)
                {
                    categoryid = Convert.ToInt32(dr["categoryID"].ToString());
                }



                //Checks if warehouse name exists in database
                Psql.AddParam("@name", dgItems.Rows[i].Cells[7].Value.ToString());
                int warehouseExistence = int.Parse(Psql.ReturnResult("SELECT COUNT(warehouseID) FROM warehouse WHERE name=@name"));
                if (Psql.HasException(true)) return;

                if (warehouseExistence > 0)
                {
                    //Do nothing
                }else
                {
                    //Automatically creates warehouse that does not exist in database
                    Psql.AddParam("@name", dgItems.Rows[i].Cells[7].Value.ToString());
                    Psql.Query("INSERT INTO warehouse (name) VALUES (@name)");
                    if (Psql.HasException(true)) return;
                }

                //Sets the ID of the warehouse when adding the product
                Psql.AddParam("@name", dgItems.Rows[i].Cells[7].Value.ToString());
                Psql.Query("Select warehouseID from warehouse where name=@name");
                if (Psql.HasException(true)) return;
                foreach (DataRow dr in Psql.DBDT.Rows)
                {
                    warehouseID = Convert.ToInt32(dr["warehouseID"].ToString());
                }


                Psql.AddParam("@name", dgItems.Rows[i].Cells[0].Value.ToString());
                Psql.AddParam("@description", dgItems.Rows[i].Cells[1].Value.ToString());
                Psql.AddParam("@categoryID", categoryid);
                Psql.AddParam("@rp_inclusive", dgItems.Rows[i].Cells[3].Value.ToString());
                Psql.AddParam("@wp_inclusive", dgItems.Rows[i].Cells[4].Value.ToString());
                Psql.AddParam("@barcode1", dgItems.Rows[i].Cells[5].Value.ToString());
                Psql.AddParam("@barcode2", dgItems.Rows[i].Cells[6].Value.ToString());
                Psql.AddParam("@warehouseID", warehouseID);
                Psql.AddParam("@s_discR", dgItems.Rows[i].Cells[8].Value.ToString());
                Psql.AddParam("@s_discPWD_SC", dgItems.Rows[i].Cells[9].Value.ToString());
                Psql.AddParam("@s_PWD_SC_perc", dgItems.Rows[i].Cells[10].Value.ToString());
                Psql.AddParam("@s_discAth", dgItems.Rows[i].Cells[11].Value.ToString());
                Psql.AddParam("@s_ask_qty", dgItems.Rows[i].Cells[12].Value.ToString());
                Psql.AddParam("@cost", dgItems.Rows[i].Cells[14].Value.ToString());
                Psql.AddParam("@has_expiry", dgItems.Rows[i].Cells[15].Value.ToString());
                Psql.AddParam("@unit_id", 1);
                Psql.AddParam("@expiration_date", DateTime.Parse(dgItems.Rows[i].Cells[16].Value.ToString()));
                //INSERT INTO DATABASE

                Psql.Query(@"INSERT INTO products
                                   (description, name, categoryID, rp_inclusive, wp_inclusive, barcode1, barcode2, warehouseID, 
                                    s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty,cost,has_expiry,expiration_date, unit_id)
                                   VALUES
                                   (@description, @name, @categoryID, @rp_inclusive, @wp_inclusive, @barcode1, @barcode2, @warehouseID, 
                                    @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty,@cost,@has_expiry,@expiration_date, @unit_id)");

                if (Psql.HasException(true))
                    return;

                // create inventory

                Psql.AddParam("@stock_qty", dgItems.Rows[i].Cells[13].Value.ToString());
                Psql.Query("INSERT INTO inventory (productID, stock_qty) VALUES ((SELECT MAX(productID) FROM products), @stock_qty)");

                if (Psql.HasException(true))
                {
                    MessageBox.Show("Inventory Error");
                    return;
                }
            }
            isImporting = false;
            GlobalVariables.LoadPurchaseProducts();
        }
    }
}
