using EcoPOSControl;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EcoPOSv2.ControlBehavior;

namespace EcoPOSv2
{
    public partial class AInventory : Form
    {
        public AInventory()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        FormLoad OL = new FormLoad();
        ExportImport EI = new ExportImport();
        //VARIABLES & ETC

        //VARIABLES & ETC

        //METHODS
        private void LoadCmb()
        {
            OL.ComboValuesQuery(cmbCategory, @"SELECT categoryID, name FROM
                                         (
                                          SELECT 0 as 'categoryID', 'All category' as 'name', 1 as ord
                                          UNION ALL
                                          SELECT categoryID, name, 2 as ord FROM product_category
                                         ) x ORDER BY ord, name ASC", "categoryID", "name");


            OL.ComboValuesQuery(cmbWarehouse, @"SELECT warehouseID, name FROM
                                              (
                                               SELECT 0 as 'warehouseID', 'All warehouse' as 'name', 1 as ord
                                               UNION ALL
                                               SELECT warehouseID, name, 2 as ord FROM warehouse
                                              ) x ORDER BY ord, name ASC", "warehouseID", "name");
        }

        //METHODS
        private void AInventory_Load(object sender, EventArgs e)
        {
            LoadCmb();

            Control c = (Control)txtSearch;

            SetBehavior(ref c, Behavior.ClearSearch);

            btnSearch.PerformClick();
        }
        string query = "";
        string cat_query, warehouse_query, showzero_query;

        BackgroundWorker workerSearchInventory;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            cat_query = "c.categoryID NOT IN (0)";
            warehouse_query = "w.warehouseID NOT IN (0)";
            showzero_query = "AND i.stock_qty = (0)";
            //string query = "";
            //string cat_query = "c.categoryID NOT IN (9999999999)";
            //string warehouse_query = "w.warehouseID NOT IN (9999999999)";
            //string showzero_query = "AND i.stock_qty = (0)";

            if (cmbCategory.SelectedIndex != 0)
            {
                cat_query = "c.categoryID = " + cmbCategory.SelectedValue;
            }

            if (cmbWarehouse.SelectedIndex != 0)
            {
                warehouse_query = "w.warehouseID = " + cmbWarehouse.SelectedValue;
            }

            if (cbxShowZero.Checked == false)
            {
                showzero_query = " AND i.stock_qty <> 0";
            }
            else
            {
                showzero_query = "";
            }

            textBox1.Text = (@"SELECT p.productID, p.description as 'Item', c.name as 'Category', w.name as 'Warehouse', i.stock_qty as 'Stock' FROM products as p
                       INNER JOIN warehouse as w ON
                       p.warehouseID = w.warehouseID
                       INNER JOIN product_category as c ON
                       p.categoryID = c.categoryID 
                       INNER JOIN inventory as i ON 
                       p.productID = i.productID
                       WHERE " + cat_query + " AND " + warehouse_query + showzero_query + " Order BY p.description ASC");


            workerSearchInventory = new BackgroundWorker();
            workerSearchInventory.DoWork += WorkerSearchInventory_DoWork;
            workerSearchInventory.RunWorkerAsync();

            btnSearch.Text = "Loading..";
            btnSearch.Enabled = false;
        }

        private void WorkerSearchInventory_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLControl workerSQL = new SQLControl();

            workerSQL.Query(@"SELECT p.productID, p.description as 'Item', c.name as 'Category', w.name as 'Warehouse', i.stock_qty as 'Stock',p.cost FROM products as p
                       INNER JOIN warehouse as w ON
                       p.warehouseID = w.warehouseID
                       INNER JOIN product_category as c ON
                       p.categoryID = c.categoryID 
                       INNER JOIN inventory as i ON 
                       p.productID = i.productID
                       WHERE " + cat_query + " AND " + warehouse_query + showzero_query + " Order BY p.description ASC");

            if (workerSQL.HasException(true))
                return;

            dgvInventory.Invoke(new Action(() =>
            {
                dgvInventory.DataSource = workerSQL.DBDT;
                dgvInventory.Columns[0].Visible = false;
            }));

            btnSearch.Invoke(new Action(() =>
            {
                btnSearch.Text = "Search";
                btnSearch.Enabled = true;
            }));
            
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (dgvInventory.RowCount == 0)
                return;

            if (btnSort.IconChar == IconChar.SortAlphaDown)
            {
                dgvInventory.Sort(dgvInventory.Columns[1], ListSortDirection.Ascending);
                btnSort.IconChar = IconChar.SortAlphaUp;
                btnSort.Text = "Sort alphabetically ASC";
                return;
            }
            else
            {
                dgvInventory.Sort(dgvInventory.Columns[1], ListSortDirection.Descending);
                btnSort.IconChar = IconChar.SortAlphaDown;
                btnSort.Text = "Sort alphabetically DESC";
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtSearch.Text == "")
            {
                return;
            }



            SQL.AddParam("@find", txtSearch.Text + "%");

            SQL.Query(@"SELECT p.productID, p.description as 'Item', c.name as 'Category', w.name as 'Warehouse', i.stock_qty as 'Stock',p.cost FROM products as p
                       INNER JOIN warehouse as w ON
                       p.warehouseID = w.warehouseID
                       INNER JOIN product_category as c ON
                       p.categoryID = c.categoryID 
                       INNER JOIN inventory as i ON 
                       p.productID = i.productID
                       WHERE p.description LIKE @find or barcode1 LIKE @find or barcode2 LIKE @find
                       ORDER BY p.description ASC");

            if (SQL.HasException(true))
                return;

            dgvInventory.DataSource = SQL.DBDT;
            dgvInventory.Columns[0].Visible = false;
        }
        //CSV WRITER
        public void writeCSV(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(@"C://Users//" + Environment.UserName + "//Desktop" + "//" + outputFile);

                //write header rows to csv
                for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(gridIn.Columns[i].HeaderText);
                }

                swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridIn.Rows[j];

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();
            }
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvInventory.RowCount == 0)
                return;

            //new ExportDGVToExcel().ExportToExcel(new ExportDGVToExcel().DataGridViewToDataTable(dgvInventory), "InventoryReport", "InventoryReport");
            writeCSV(dgvInventory, "InventoryReport-"+ DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString() + "--" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + ".csv");

            MessageBox.Show("Inventory report export success. \n \n You can view your report on Desktop.");
            //EI.ExportDgvToExcel(dgvInventory);
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvInventory.RowCount == 0)
                return;

            EI.ExportDgvToPDF("Inventory", dgvInventory);
        }
    }
}
