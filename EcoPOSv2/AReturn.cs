using EcoPOSControl;
using Microsoft.VisualBasic;
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
    public partial class AReturn : Form
    {
        public AReturn()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        FormLoad OL = new FormLoad();

        DataTable dt_return = new DataTable();
        string purchase_order = "";
        string supplierID = "";
        //METHODS
        private void LoadPurchaseOrder()
        {
            SQL.Query("SELECT operationID as 'ID', supplierID FROM inventory_operation WHERE operation = 'Purchase Inventory' ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgvPurchaseOrder.DataSource = SQL.DBDT;
            dgvPurchaseOrder.Columns[0].Visible = false;
            dgvPurchaseOrder.Columns[1].Visible = false;
        }
        private void LoadReturn()
        {
            DataColumn productID = new DataColumn();
            DataColumn name = new DataColumn();
            DataColumn return_qty = new DataColumn();
            DataColumn stock_qty = new DataColumn();
            DataColumn purchase_qty = new DataColumn();

            name.ColumnName = "Name";
            return_qty.ColumnName = "Return Qty";

            dt_return.Columns.Add(productID);
            dt_return.Columns.Add(name);
            dt_return.Columns.Add(return_qty);
            dt_return.Columns.Add(stock_qty);

            dgvReturn.DataSource = dt_return;
            dgvReturn.Columns[0].Visible = false;
            dgvReturn.Columns[3].Visible = false;

            dgvReturn.Columns[1].ReadOnly = true;
            dgvReturn.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
            dgvReturn.Columns[1].DefaultCellStyle.ForeColor = Color.DarkGray;
            dgvReturn.Columns[1].DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvReturn.Columns[1].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
        }
        //METHODS


        private void AReturn_Load(object sender, EventArgs e)
        {
            LoadPurchaseOrder();
            LoadReturn();
        }

        private void txtSearchProducts_KeyUp(object sender, KeyEventArgs e)
        {
            SQL.AddParam("@find", txtSearchProducts.Text + "%");

            SQL.Query("SELECT operationID as 'ID', supplierID FROM inventory_operation WHERE operationID LIKE @find ORDER BY purchase_order ASC");

            if (SQL.HasException(true))
                return;

            dgvPurchaseOrder.DataSource = SQL.DBDT;
            dgvPurchaseOrder.Columns[0].Visible = false;
            dgvPurchaseOrder.Columns[1].Visible = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvReturn.RowCount == 0)
                return;

            foreach (DataGridViewRow row in dgvReturn.Rows)
            {
                if (dgvReturn.Rows[row.Index].Cells[2].Value.ToString() == "" | dgvReturn.Rows[row.Index].Cells[2].Value.ToString() == "0" | Convert.ToDecimal(dgvReturn.Rows[row.Index].Cells[2].Value.ToString()) > Convert.ToDecimal(dgvReturn.Rows[row.Index].Cells[3].Value.ToString()))
                {
                    new Notification().PopUp("Purchase quantity cannot be zero, blank or greater than stock/purchase.", "Error", "error");
                    return;
                }

                foreach (DataGridViewRow r in dgvReturn.Rows)
                {
                    SQL.AddParam("@productID", dgvReturn.Rows[r.Index].Cells[0].Value.ToString());
                    SQL.AddParam("@return_qty", dgvReturn.Rows[r.Index].Cells[2].Value.ToString());

                    SQL.Query("UPDATE inventory SET stock_qty = stock_qty - @return_qty WHERE productID = @productID");

                    if (SQL.HasException(true))
                        return;

                    if (SQL.HasException(true))
                    {
                        new Notification().PopUp("Something went wrong.", "Error","error");
                        return;
                    }
                }
            }

            // save to inventory_operation

            decimal return_qty = OL.GetSumColumn(dgvReturn, 2);

            SQL.AddParam("@return_qty", return_qty);
            SQL.AddParam("@supplierID", supplierID);
            SQL.AddParam("@remarks", txtRemarks.Text);
            SQL.AddParam("@total", txtTotal.Text);
            SQL.AddParam("@userID", Main.Instance.current_id);

            SQL.Query(@"INSERT INTO inventory_operation (operation, qty, total, supplierID, remarks, 
                              date_time, userID) VALUES ('Return Inventory', @return_qty, @total, @supplierID, 
                              @remarks, (SELECT GETDATE()), @userID)");

            if (SQL.HasException(true))
            {
                new Notification().PopUp("Something went wrong.", "Error", "error");
                return;
            }

            // save to inventory_operation_items

            foreach (DataGridViewRow r in dgvReturn.Rows)
            {
                SQL.AddParam("@productID", dgvReturn.Rows[r.Index].Cells[0].Value.ToString());
                SQL.AddParam("@product_name", dgvReturn.Rows[r.Index].Cells[1].Value.ToString());
                SQL.AddParam("@return_qty", Convert.ToDecimal(dgvReturn.Rows[r.Index].Cells[2].Value.ToString()));

                SQL.Query(@"INSERT INTO inventory_operation_items (operationID, productID, product_name, qty) 
                          VALUES ((SELECT MAX(operationID) FROM inventory_operation), @productID, @product_name, @return_qty)");

                if (SQL.HasException(true))
                {
                    new Notification().PopUp("Something went wrong.", "Error","error");
                    return;
                }
            }

            dt_return.Rows.Clear();
            new Notification().PopUp("Item saved.","","information");
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dgvReturn.RowCount > 0)
            {
                // check if item is already chosen
                DataGridViewRow datarow = new DataGridViewRow();
                for (int rows = 0; rows <= dgvProducts.Rows.Count - 1; rows++)
                {
                    int counter = 0;
                    for (var i = 0; i <= dgvReturn.RowCount - 1; i++)
                    {
                        if (dgvProducts.Rows[rows].Cells[0].Value.ToString() == dgvReturn.Rows[i].Cells[0].Value.ToString())
                            counter = 1;
                    }

                    // if not chosen then add
                    if (counter == 0)
                        dt_return.Rows.Add(dgvProducts.Rows[rows].Cells[0].Value, dgvProducts.Rows[rows].Cells[1].Value, 0, dgvProducts.Rows[rows].Cells[3].Value, dgvProducts.Rows[rows].Cells[2].Value);
                }
            }
            else if (dgvReturn.RowCount == 0)
            {
                DataGridViewRow datarow = new DataGridViewRow();
                for (int rows = 0; rows <= dgvProducts.Rows.Count - 1; rows++)
                    dt_return.Rows.Add(dgvProducts.Rows[rows].Cells[0].Value, dgvProducts.Rows[rows].Cells[1].Value, 0, dgvProducts.Rows[rows].Cells[3].Value, dgvProducts.Rows[rows].Cells[2].Value);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvReturn.SelectedRows.Count == 0)
                return;
            else
                dgvReturn.Rows.Remove(dgvReturn.CurrentRow);
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // transfer to dgvReturn

            if (dgvReturn.RowCount > 0)
            {
                for (var i = 0; i <= dgvReturn.RowCount - 1; i++)
                {
                    if (dgvReturn.Rows[i].Cells[0].Value.ToString() == dgvProducts.CurrentRow.Cells[0].Value.ToString())
                        return;
                }
                dt_return.Rows.Add(dgvProducts.CurrentRow.Cells[0].Value, dgvProducts.CurrentRow.Cells[1].Value, 0, dgvProducts.CurrentRow.Cells[3].Value);
            }
            else if (dgvReturn.RowCount == 0)
                dt_return.Rows.Add(dgvProducts.CurrentRow.Cells[0].Value, dgvProducts.CurrentRow.Cells[1].Value, 0, dgvProducts.CurrentRow.Cells[3].Value);
        }

        private void dgvPurchaseOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dt_return.Rows.Clear();

            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@operationID", dgvPurchaseOrder.CurrentRow.Cells[0].Value.ToString());
            SQL.Query(@"SELECT ioi.productID, ioi.product_name as 'Name', qty as 'Return Qty', ioi.qty
                       FROM inventory_operation_items as ioi INNER JOIN inventory as i ON
                       ioi.productID = i.productID WHERE operationID = @operationID ORDER BY product_name ASC");

            if (SQL.HasException(true))
                return;

            dgvProducts.DataSource = SQL.DBDT;
            dgvProducts.Columns[0].Visible = false;
            dgvProducts.Columns[3].Visible = false;

            supplierID = dgvPurchaseOrder.CurrentRow.Cells[1].Value.ToString();
        }

        private void dgvReturn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Checking numeric value for Column 2 only
            if ((e.ColumnIndex == 2))
            {
                string value = dgvReturn.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                foreach (char c in value)
                {
                    if (!Information.IsNumeric(value))
                    {
                        MessageBox.Show("Please enter numeric value.");

                        dgvReturn.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
                        return;
                    }
                }
            }
        }
    }
}
