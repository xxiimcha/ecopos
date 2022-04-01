using EcoPOSControl;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    LoadCmb();

                    Control c = (Control)txtSearch;

                    SetBehavior(ref c, Behavior.ClearSearch);

                    btnSearch.PerformClick();
                }));
            })
            { IsBackground = true }.Start();
        }
        string query = "";
        string cat_query, warehouse_query, showzero_query;

        BackgroundWorker workerSearchInventory;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            cat_query = "c.categoryID NOT IN (0)";
            warehouse_query = "w.warehouseID NOT IN (0)";
            showzero_query = "AND i.stock_qty = (0)";


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

            workerSearchInventory = new BackgroundWorker();
            workerSearchInventory.DoWork += WorkerSearchInventory_DoWork;
            workerSearchInventory.RunWorkerAsync();

            btnSearch.Text = "Loading..";
            btnSearch.Enabled = false;
        }

        private void WorkerSearchInventory_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLControl workerSQL = new SQLControl();

            workerSQL.Query(@"SELECT p.productID, p.description as 'Item', c.name as 'Category', w.name as 'Warehouse', i.stock_qty as 'Stock',p.cost as 'Cost', p.rp_inclusive as 'SRP', p.wp_inclusive as 'WSP' FROM products as p
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
                //dgvInventory.Columns[1].Width = 400;
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

            SQL.Query(@"SELECT p.productID, p.description as 'Item', c.name as 'Category', w.name as 'Warehouse', i.stock_qty as 'Stock',p.cost as 'Cost', p.rp_inclusive as 'SRP', p.wp_inclusive as 'WSP' FROM products as p
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
            //dgvInventory.Columns[1].Width = 400;
        }

        private void DgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Properties.Settings.Default.inventoryproductview == true)
            {
                InventoryProduct_View.Instance.lblProductName.Text = dgvInventory.CurrentRow.Cells[1].Value.ToString() + "|" + dgvInventory.CurrentRow.Cells[2].Value.ToString();
                InventoryProduct_View.Instance.productID = dgvInventory.CurrentRow.Cells[0].Value.ToString();
                InventoryProduct_View.Instance.ShowDialog();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvInventory.RowCount == 0)
                return;
            //new ExportDGVToExcel().ExportToExcel(new ExportDGVToExcel().DataGridViewToDataTable(dgvInventory), "InventoryReport", "InventoryReport");

            EI.ExportDgvToExcel(dgvInventory,"Inventory");
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvInventory.RowCount == 0)
                return;

            EI.ExportDgvToPDF("Inventory", dgvInventory);
        }
    }
}
