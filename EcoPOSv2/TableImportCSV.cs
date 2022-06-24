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

        Boolean overwrite = false;
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblTotalNumberOfItems.Text) > 1)
            {
                switch (table_import_type)
                {
                    case 1 // products
                   :
                        {
                            if (MessageBox.Show("Are you sure you want to import the products in the CSV file?", "Products and Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                if (MessageBox.Show("Do you want to overwrite your current products and inventory? Doing so will remove all current products and replace it with the data in the CSV file.", "Overwrite Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    SQL.Query("DELETE FROM inventory");
                                    if (SQL.HasException(true))
                                        return;

                                    SQL.Query("DELETE FROM products");
                                    if (SQL.HasException(true))
                                        return;

                                    overwrite = true;
                                }
                                else
                                {
                                    overwrite = false;
                                }

                                
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
                            workerCategory = new BackgroundWorker();
                            workerCategory.WorkerReportsProgress = true;
                            workerCategory.DoWork += WorkerMembers_DoWork;
                            workerCategory.RunWorkerCompleted += WorkerMembers_RunWorkerCompleted;

                            workerCategory.RunWorkerAsync();

                            btnBrowse.Enabled = false;
                            btnImport.Enabled = false;
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
                new Notification().PopUp("Please enter a valid CSV file with more than 1 data.", "Error", "error");
            }
        }

        #region category
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

                lblImportedProducts.Invoke(new System.Action(() =>
                {
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
                    continue;
            }
            isImporting = false;
        }
        #endregion

        #region products
        private void WorkerCSV_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Import Product(s) successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnImport.Enabled = true;
            this.Close();
        }
        private void WorkerCSV_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime currentDT = DateTime.Now;
            SQLControl Psql = new SQLControl();
            int numberOfItemsFailed = 0;
            isImporting = true;
            for (int i = 0; i < dgItems.Rows.Count - 1; i++)
            {
                if (toClose)
                {
                    break;
                }

                lblImportedProducts.Invoke(new System.Action(() =>
                {
                    int total = i + 1;
                    lblImportedProducts.Text = total.ToString();
                    pbLoad.Value = total;
                }));

                numberOfItemsFailed++;

                int categoryid = 0;
                int warehouseID = 0;

                //Checks if user wants to overwrite
                if (!overwrite)
                {
                    string name = dgItems.Rows[i].Cells[0].Value.ToString();
                    string description = dgItems.Rows[i].Cells[1].Value.ToString();

                    Psql.AddParam("@name", name);
                    int nameExistence = int.Parse(Psql.ReturnResult("SELECT COUNT(*) FROM products WHERE name = @name"));
                    Psql.AddParam("@description", description);
                    int descriptionExistence = int.Parse(Psql.ReturnResult("SELECT COUNT(*) FROM products WHERE description = @description"));

                    if (nameExistence == 0 && descriptionExistence == 0)
                    {
                        //do nothing
                    }
                    else
                    {
                        //skip item
                        continue;
                    }
                }

                //Checks if category name exists in database
                Psql.AddParam("@name", dgItems.Rows[i].Cells[2].Value.ToString());
                int categoryExistence = int.Parse(Psql.ReturnResult("SELECT COUNT(categoryID) FROM product_category WHERE name=@name"));
                if (Psql.HasException(true)) continue;

                if (categoryExistence > 0)
                {
                    //Do nothing
                }
                else
                {
                    //Automatically creates category that does not exist in database
                    Psql.AddParam("@name", dgItems.Rows[i].Cells[2].Value.ToString());
                    Psql.Query(@"INSERT INTO product_category
                                   (name, s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty)
                                   VALUES
                                   (@name, 0, 0, 0, 0, 0)
                                  ");
                    if (Psql.HasException(true)) continue;
                }

                //Sets the ID of the category when adding the product
                Psql.AddParam("@name", dgItems.Rows[i].Cells[2].Value.ToString());
                Psql.Query("Select categoryID from product_category where name=@name");
                if (Psql.HasException(true)) continue;

                foreach (DataRow dr in Psql.DBDT.Rows)
                {
                    categoryid = Convert.ToInt32(dr["categoryID"].ToString());
                }

                //Checks if warehouse name exists in database
                Psql.AddParam("@name", dgItems.Rows[i].Cells[7].Value.ToString());
                int warehouseExistence = int.Parse(Psql.ReturnResult("SELECT COUNT(warehouseID) FROM warehouse WHERE name=@name"));
                if (Psql.HasException(true)) continue;

                if (warehouseExistence > 0)
                {
                    //Do nothing
                }
                else
                {
                    //Automatically creates warehouse that does not exist in database
                    Psql.AddParam("@name", dgItems.Rows[i].Cells[7].Value.ToString());
                    Psql.Query("INSERT INTO warehouse (name) VALUES (@name)");
                    if (Psql.HasException(true)) continue;
                }

                //Sets the ID of the warehouse when adding the product
                Psql.AddParam("@name", dgItems.Rows[i].Cells[7].Value.ToString());
                Psql.Query("Select warehouseID from warehouse where name=@name");
                if (Psql.HasException(true)) continue;
                foreach (DataRow dr in Psql.DBDT.Rows)
                {
                    warehouseID = Convert.ToInt32(dr["warehouseID"].ToString());
                }

                Psql.AddParam("@name", dgItems.Rows[i].Cells[0].Value.ToString().Trim());
                Psql.AddParam("@description", dgItems.Rows[i].Cells[1].Value.ToString().Trim());
                Psql.AddParam("@categoryID", categoryid);
                Psql.AddParam("@rp_inclusive", dgItems.Rows[i].Cells[3].Value.ToString() != "" ? dgItems.Rows[i].Cells[3].Value.ToString() : "0");
                Psql.AddParam("@wp_inclusive", dgItems.Rows[i].Cells[4].Value.ToString() != "" ? dgItems.Rows[i].Cells[4].Value.ToString() : "0");
                Psql.AddParam("@barcode1", dgItems.Rows[i].Cells[5].Value.ToString());
                Psql.AddParam("@barcode2", dgItems.Rows[i].Cells[6].Value.ToString());
                Psql.AddParam("@warehouseID", warehouseID);
                Psql.AddParam("@s_discR", dgItems.Rows[i].Cells[8].Value.ToString() != "" ? dgItems.Rows[i].Cells[8].Value.ToString() : "FALSE");
                Psql.AddParam("@s_discPWD_SC", dgItems.Rows[i].Cells[9].Value.ToString() != "" ? dgItems.Rows[i].Cells[9].Value.ToString() : "FALSE");
                Psql.AddParam("@s_PWD_SC_perc", dgItems.Rows[i].Cells[10].Value.ToString() != "" ? dgItems.Rows[i].Cells[10].Value.ToString() : "FALSE");
                Psql.AddParam("@s_discAth", dgItems.Rows[i].Cells[11].Value.ToString() != "" ? dgItems.Rows[i].Cells[11].Value.ToString() : "FALSE");
                Psql.AddParam("@s_ask_qty", dgItems.Rows[i].Cells[12].Value.ToString() != "" ? dgItems.Rows[i].Cells[12].Value.ToString() : "FALSE");
                Psql.AddParam("@cost", dgItems.Rows[i].Cells[14].Value.ToString() != "" ? dgItems.Rows[i].Cells[14].Value.ToString() : "0");
                Psql.AddParam("@has_expiry", dgItems.Rows[i].Cells[15].Value.ToString() != "" ? dgItems.Rows[i].Cells[15].Value.ToString() : "FALSE");
                Psql.AddParam("@unit_id", 1);
                Psql.AddParam("@expiration_date", DateTime.Parse(dgItems.Rows[i].Cells[16].Value.ToString() != "" ? dgItems.Rows[i].Cells[16].Value.ToString() : currentDT.ToString()));

                //INSERT INTO DATABASE
                Psql.Query(@"INSERT INTO products
                                   (description, name, categoryID, rp_inclusive, wp_inclusive, barcode1, barcode2, warehouseID, 
                                    s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty,cost,has_expiry,expiration_date, unit_id)
                                   VALUES
                                   (@description, @name, @categoryID, @rp_inclusive, @wp_inclusive, @barcode1, @barcode2, @warehouseID, 
                                    @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty,@cost,@has_expiry,@expiration_date, @unit_id)");

                if (Psql.HasException(true))
                    continue;

                // create inventory
                Psql.AddParam("@stock_qty", dgItems.Rows[i].Cells[13].Value.ToString());
                Psql.Query("INSERT INTO inventory (productID, stock_qty) VALUES ((SELECT MAX(productID) FROM products), @stock_qty)");

                if (Psql.HasException(true))
                {
                    MessageBox.Show("Inventory Error");
                    continue;
                }

                numberOfItemsFailed--;
            }

            if (numberOfItemsFailed > 0)
            {
                MessageBox.Show($"{numberOfItemsFailed} items were not imported due to: Duplicate name/description, Incomplete fields");
            }

            isImporting = false;
            GlobalVariables.LoadPurchaseProducts();
        }
        #endregion

        #region members
        private void WorkerMembers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Import Members successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnImport.Enabled = true;
            this.Close();
        }

        private void WorkerMembers_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> duplicateName = new List<string>();

            SQLControl sql = new SQLControl();
            isImporting = true;

            for (int i = 0; i < dgItems.Rows.Count - 1; i++)
            {
                if (toClose)
                {
                    break;
                }

                string name = dgItems.Rows[i].Cells[0].Value.ToString();
                string membership = dgItems.Rows[i].Cells[6].Value.ToString();
                string cardno = dgItems.Rows[i].Cells[7].Value.ToString();
                int existingNameCount = int.Parse(SQL.ReturnResult($"SELECT COUNT(name) FROM customer WHERE name = '{name}'"));

                int existingMembership = int.Parse(SQL.ReturnResult($"SELECT COUNT(name) FROM membership WHERE name = '{membership}'"));
                int existingCard = int.Parse(SQL.ReturnResult($"SELECT COUNT(*) FROM member_card WHERE card_no = '{cardno}'"));
                int existingAvailableCard = int.Parse(SQL.ReturnResult($"SELECT IIF((SELECT COUNT(*) FROM member_card WHERE card_no = '{cardno}' AND status = 'Available') > 0,'1', '0')"));

                if (SQL.HasException(true))
                {
                    continue;
                }

                if (name == "" || name == null)
                {
                    continue;
                }
                else if (existingNameCount > 0)
                {
                    duplicateName.Add(name);
                    continue;
                }

                if (existingMembership > 0)
                {
                    membership = SQL.ReturnResult($"SELECT member_type_ID FROM membership WHERE name = '{membership}'");
                }
                else
                {
                    SQL.AddParam("@name", membership);
                    SQL.AddParam("@discountable", false);
                    SQL.AddParam("@disc_amt", 0.00);
                    SQL.AddParam("@disc_type", 2);
                    SQL.AddParam("@expiration", 0);
                    SQL.AddParam("@rewardable", false);
                    SQL.AddParam("@amt_per_pt", 0);

                    SQL.Query(@"INSERT INTO membership (name, discountable, disc_amt, disc_type, 
                                        expiration, rewardable, amt_per_pt) VALUES (@name, @discountable, 
                                        @disc_amt, @disc_type, @expiration, @rewardable, @amt_per_pt)");
                    if (SQL.HasException(true))
                        continue;

                    membership = SQL.ReturnResult($"SELECT member_type_ID FROM membership WHERE name = '{membership}'");
                    if (SQL.HasException(true))
                        continue;
                }

                if (existingAvailableCard == 0 && existingCard > 0)
                {
                    duplicateName.Add(name);
                    continue;
                }
                else if (existingAvailableCard == 0 && existingCard == 0)
                {
                    SQL.Query($@"INSERT INTO member_card (card_no, member_type_ID, customerID, customer_name, card_balance, status)
                                       VALUES ('{cardno}', 0, 0, '', 0, 'Available')");
                    if (SQL.HasException(true))
                        continue;
                }

                //required fields for importing customer
                SQL.AddParam("@name", name);
                SQL.AddParam("@contact", dgItems.Rows[i].Cells[1].Value.ToString());
                SQL.AddParam("@birthday", dgItems.Rows[i].Cells[2].Value.ToString() == "" ? "01/01/2000 0:00" : dgItems.Rows[i].Cells[2].Value.ToString());
                SQL.AddParam("@add1", dgItems.Rows[i].Cells[3].Value.ToString());
                SQL.AddParam("@add2", dgItems.Rows[i].Cells[4].Value.ToString());
                SQL.AddParam("@email", dgItems.Rows[i].Cells[5].Value.ToString());
                SQL.AddParam("@member_type_ID", membership);
                SQL.AddParam("@card_no", cardno);
                SQL.Query(@"INSERT INTO customer (name, contact, birthday, add1, add2, email, member_type_ID, card_no)
                                       VALUES (@name, @contact, @birthday, @add1, @add2, @email, @member_type_ID, @card_no)");
                if (SQL.HasException(true))
                    continue;

                int card_expiration_days = int.Parse(SQL.ReturnResult($@"SELECT m.expiration FROM membership as m INNER JOIN customer as c
                                                                                                    ON m.member_type_ID = c.member_type_ID WHERE c.card_no = '{cardno}'"));
                if (SQL.HasException(true))
                    continue;

                SQL.AddParam("@card_no", cardno);
                SQL.AddParam("@member_type_ID", membership);
                SQL.AddParam("@customer_name", name);
                SQL.AddParam("@activation_span", card_expiration_days);
                SQL.Query(@"UPDATE member_card SET member_type_ID = @member_type_ID, 
                                           customerID = (SELECT MAX(customerID) FROM customer), customer_name = @customer_name, status = 'Active',
                                           date_activated = (SELECT GETDATE()), activation_span = @activation_span WHERE card_no = @card_no");
                if (SQL.HasException(true))
                    continue;

                lblImportedProducts.Invoke(new System.Action(() =>
                { //adds a number
                    int total = i + 1;
                    lblImportedProducts.Text = total.ToString();
                    pbLoad.Value = total;

                }));
            }

            if (duplicateName.Count > 0)
            {
                MessageBox.Show("Unable to import the following names: \n(" + String.Join(", ", duplicateName) + ")");
            }

            isImporting = false;
        }
        #endregion
    }
}
