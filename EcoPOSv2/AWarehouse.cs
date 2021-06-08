using EcoPOSControl;
using FontAwesome.Sharp;
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
    public partial class AWarehouse : Form
    {
        public AWarehouse()
        {
            InitializeComponent();
        }
        public static AWarehouse _AWarehouse;
        public static AWarehouse Instance
        {
            get
            {
                if (_AWarehouse == null)
                {
                    _AWarehouse = new AWarehouse();
                }
                return _AWarehouse;
            }
        }

        private SQLControl SQL = new SQLControl();
        private FormLoad OL = new FormLoad();
        private string warehouseID = "";
        private bool dgvToWarehouse_runOnlyOnce = true;
        //METHODS
        private void LoadWarehouseCMB()
        {
            OL.ComboValuesQuery(cmbWarehouseFrom, @"SELECT warehouseID, name FROM
                                              (
                                               SELECT 0 as 'warehouseID', 'All warehouse' as 'name', 1 as ord
                                               UNION ALL
                                               SELECT warehouseID, name, 2 as ord FROM warehouse
                                              ) x ORDER BY ord, name ASC", "warehouseID", "name");

            OL.ComboValues(cmbWarehouseTo, "warehouseID", "name", "warehouse");
        }

        public void LoadWarehouse()
        {
            SQL.Query(@"SELECT w.warehouseID, w.name as 'Name', COUNT(p.warehouseID) as 'No. of items' FROM warehouse as w
                       LEFT JOIN products as p ON
                       w.warehouseID = p.warehouseID
                       GROUP BY p.warehouseID,  w.name, w.warehouseID
                       ORDER BY w.name ASC");

            if (SQL.HasException(true))
                return;

            dgvWarehouse.DataSource = SQL.DBDT;
            dgvWarehouse.Columns[0].Visible = false;
        }
        private void LoadToWarehouse()
        {

            // clone dgvFromWarehouse columns to dgvToWarehouse
            if (dgvToWarehouse.Columns.Count == 0)
            {
                for (int i = 0; i <= 3; i++)
                {
                    DataGridViewColumn dgv = dgvFromWarehouse.Columns[i];
                    dgvToWarehouse.Columns.Add(dgv.Clone() as DataGridViewColumn);
                }
            }
        }

        //METHODS
        private void AWarehouse_Load(object sender, EventArgs e)
        {
            _AWarehouse = this;


            LoadWarehouse();
            LoadWarehouseCMB();


            OL.ComboValuesQuery(cmbCategory, @"SELECT categoryID, name FROM
                                         (
                                          SELECT 0 as 'categoryID', 'All category' as 'name', 1 as ord
                                          UNION ALL
                                          SELECT categoryID, name, 2 as ord FROM product_category
                                         ) x ORDER BY ord, name ASC", "categoryID", "name");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditWarehouse frmAddEditWarehouse = new AddEditWarehouse();
            frmAddEditWarehouse.action = "New";
            frmAddEditWarehouse.frmAWarehouse = this;

            frmAddEditWarehouse.ShowDialog();
        }

        private void btnDeleteWarehouse_Click(object sender, EventArgs e)
        {
            DialogResult approval = MessageBox.Show("Delete this item?", "", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (approval == DialogResult.Yes)
            {
                if (dgvWarehouse.SelectedRows.Count == 0)
                {
                    new Notification().PopUp("No item selected.","","error");
                    return;
                }

                if (Convert.ToInt32(dgvWarehouse.CurrentRow.Cells[2].Value.ToString()) > 0)
                {
                    new Notification().PopUp("Error", "There are items in this warehouse, remove items first.");
                    return;
                }

                SQL.AddParam("@warehouseID", dgvWarehouse.CurrentRow.Cells[0].Value.ToString());
                SQL.Query("DELETE FROM warehouse WHERE warehouseID = @warehouseID");

                if (SQL.HasException(true))
                    return;

                LoadWarehouse();
                new Notification().PopUp("Item deleted.","","information");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvWarehouse.SelectedRows.Count == 0)
            {
                new Notification().PopUp("Please select item to proceed", "", "error");
            }
            else
            {
                AddEditWarehouse frmAddEditWarehouse = new AddEditWarehouse();
                frmAddEditWarehouse.action = "Update";
                frmAddEditWarehouse.warehouseID = dgvWarehouse.CurrentRow.Cells[0].Value.ToString();
                frmAddEditWarehouse.txtName.Text = dgvWarehouse.CurrentRow.Cells[1].Value.ToString();
                frmAddEditWarehouse.frmAWarehouse = this;

                frmAddEditWarehouse.ShowDialog();
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (dgvWarehouse.RowCount == 0)
                return;

            if (btnSort.IconChar == IconChar.SortAlphaDown)
            {
                dgvWarehouse.Sort(dgvWarehouse.Columns[1], ListSortDirection.Ascending);
                btnSort.IconChar = IconChar.SortAlphaUp;
                return;
            }
            else
            {
                dgvWarehouse.Sort(dgvWarehouse.Columns[1], ListSortDirection.Descending);
                btnSort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void txtSearchWarehouse_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearchWarehouse.Text == "")
                LoadWarehouse();
            else
            {
                SQL.AddParam("@find", txtSearchWarehouse.Text + "%");

                SQL.Query(@"SELECT w.warehouseID, w.name as 'Name', COUNT(p.warehouseID) as 'No. of items' FROM warehouse as w
                       LEFT JOIN products as p ON
                       w.warehouseID = p.warehouseID WHERE w.name LIKE @find
                       GROUP BY p.warehouseID,  w.name, w.warehouseID
                       ORDER BY w.name ASC");

                if (SQL.HasException(true))
                    return;

                dgvWarehouse.DataSource = SQL.DBDT;
                dgvWarehouse.Columns[0].Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string cat_query = "c.categoryID NOT IN (9999999999)";
            string warehouse_query = "w.warehouseID NOT IN (9999999999)";


            if (cmbCategory.SelectedIndex != 0)
                cat_query = "c.categoryID = " + cmbCategory.SelectedValue;

            if (cmbWarehouseFrom.SelectedIndex != 0)
                warehouse_query = "w.warehouseID = " + cmbWarehouseFrom.SelectedValue;

            SQL.Query(@"SELECT p.productID, p.description as 'Item', c.name as 'Category' , w.name as 'Warehouse' FROM products as p
                       INNER JOIN warehouse as w ON
                       p.warehouseID = w.warehouseID
                       INNER JOIN product_category as c ON
                       p.categoryID = c.categoryID
                       WHERE " + cat_query + " AND " + warehouse_query + " Order BY p.description ASC");

            if (SQL.HasException(true))
                return;

            dgvFromWarehouse.DataSource = SQL.DBDT;
            dgvFromWarehouse.Columns[0].Visible = false;


            if (dgvToWarehouse_runOnlyOnce == true)
            {
                LoadToWarehouse();

                dgvToWarehouse_runOnlyOnce = false;
            }
        }

        private void dgvFromWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // transfer to dgvWarehouseTo

            if (dgvToWarehouse.RowCount > 0)
            {
                for (var i = 0; i <= dgvToWarehouse.RowCount - 1; i++)
                {
                    if (dgvToWarehouse.Rows[i].Cells[0].Value.ToString() == dgvFromWarehouse.CurrentRow.Cells[0].Value.ToString())
                        return;
                }
                dgvToWarehouse.Rows.Add(dgvFromWarehouse.CurrentRow.Cells[0].Value, dgvFromWarehouse.CurrentRow.Cells[1].Value, dgvFromWarehouse.CurrentRow.Cells[2].Value, dgvFromWarehouse.CurrentRow.Cells[3].Value);
            }
            else if (dgvToWarehouse.RowCount == 0)
                dgvToWarehouse.Rows.Add(dgvFromWarehouse.CurrentRow.Cells[0].Value, dgvFromWarehouse.CurrentRow.Cells[1].Value, dgvFromWarehouse.CurrentRow.Cells[2].Value, dgvFromWarehouse.CurrentRow.Cells[3].Value);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dgvToWarehouse.RowCount > 0)
            {

                // check if item is already chosen
                DataGridViewRow datarow = new DataGridViewRow();
                for (int rows = 0; rows <= dgvFromWarehouse.Rows.Count - 1; rows++)
                {
                    int counter = 0;
                    for (var i = 0; i <= dgvToWarehouse.RowCount - 1; i++)
                    {
                        if (dgvFromWarehouse.Rows[rows].Cells[0].Value.ToString() == dgvToWarehouse.Rows[i].Cells[0].Value.ToString())
                            counter = 1;
                    }

                    // if not chosen then add
                    if (counter == 0)
                        dgvToWarehouse.Rows.Add(dgvFromWarehouse.Rows[rows].Cells[0].Value, dgvFromWarehouse.Rows[rows].Cells[1].Value, dgvFromWarehouse.Rows[rows].Cells[2].Value, dgvFromWarehouse.Rows[rows].Cells[3].Value);
                }
            }
            else if (dgvToWarehouse.RowCount == 0)
            {
                DataGridViewRow datarow = new DataGridViewRow();
                for (int rows = 0; rows <= dgvFromWarehouse.Rows.Count - 1; rows++)
                    dgvToWarehouse.Rows.Add(dgvFromWarehouse.Rows[rows].Cells[0].Value, dgvFromWarehouse.Rows[rows].Cells[1].Value, dgvFromWarehouse.Rows[rows].Cells[2].Value, dgvFromWarehouse.Rows[rows].Cells[3].Value);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvToWarehouse.SelectedRows.Count == 0)
                return;
            else
                dgvToWarehouse.Rows.Remove(dgvToWarehouse.CurrentRow);
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            dgvFromWarehouse.Rows.Clear();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (dgvToWarehouse.RowCount == 0)
                new Notification().PopUp("No selected items.","Error","error");
            else if (dgvToWarehouse.RowCount > 0)
            {
                for (int i = 0; i <= dgvToWarehouse.RowCount - 1; i++)
                {
                    SQL.AddParam("@warehouseID", cmbWarehouseTo.SelectedValue);
                    SQL.AddParam("@productID", dgvToWarehouse.Rows[i].Cells[0].Value.ToString());

                    SQL.Query("UPDATE products SET warehouseID = @warehouseID WHERE productID = @productID");

                    if (SQL.HasException(true))
                    {
                        new Notification().PopUp("Something went wrong.", "Error", "error");
                        return;
                    }
                }

                LoadWarehouse();
                btnSearch.PerformClick();
                dgvToWarehouse.Rows.Clear();
                new Notification().PopUp("Item saved.","","information");
            }
        }

        private void txtSearchItem_KeyUp(object sender, KeyEventArgs e)
        {
            SQL.AddParam("@find", txtSearchItem.Text + "%");

            SQL.Query(@"SELECT p.productID, p.description as 'Item', c.name as 'Category' , w.name as 'Warehouse' FROM products as p
                       INNER JOIN warehouse as w ON
                       p.warehouseID = w.warehouseID
                       INNER JOIN product_category as c ON
                       p.categoryID = c.categoryID
                       WHERE p.description LIKE @find
                       ORDER BY p.description ASC");

            if (SQL.HasException(true))
                return;

            dgvFromWarehouse.DataSource = SQL.DBDT;
            dgvFromWarehouse.Columns[0].Visible = false;

            if (dgvToWarehouse_runOnlyOnce == true)
            {
                LoadToWarehouse();

                dgvToWarehouse_runOnlyOnce = false;
            }
        }
    }
}
