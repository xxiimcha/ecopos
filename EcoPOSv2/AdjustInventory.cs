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
    public partial class AdjustInventory : Form
    {
        public AdjustInventory()
        {
            InitializeComponent();
        }
        private SQLControl SQL = new SQLControl();
        private FormLoad OL = new FormLoad();
        public AOperation frmAOperation;
        public string operationID;
        public string supplierID;

        private void AdjustInventory_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

            SQL.AddParam("@operationID", operationID);

            SQL.Query(@"SELECT productID, product_name as 'Name', 0 as 'Adjust Qty' FROM inventory_operation_items
                       WHERE operationID = @operationID");

            if (SQL.HasException(true))
                return;

            dgvAdjInventory.DataSource = SQL.DBDT;
            dgvAdjInventory.Columns[0].Visible = false;

            dgvAdjInventory.Columns[1].ReadOnly = true;
            dgvAdjInventory.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
            dgvAdjInventory.Columns[1].DefaultCellStyle.ForeColor = Color.DarkGray;
            dgvAdjInventory.Columns[1].DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvAdjInventory.Columns[1].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvAdjInventory.Rows)
            {
                SQL.AddParam("@productID", dgvAdjInventory.Rows[row.Index].Cells[0].Value.ToString());
                SQL.AddParam("@adjust_qty", dgvAdjInventory.Rows[row.Index].Cells[2].Value.ToString());
                SQL.AddParam("@operationID", operationID);

                SQL.Query("UPDATE inventory_operation_items SET qty = qty + @adjust_qty WHERE operationID = @operationID AND productID = @productID");

                if (SQL.HasException(true))
                {
                    new Notification().PopUp("Something went wrong.", "Error", "error");
                    return;
                }

                // update inventory

                SQL.AddParam("@productID", dgvAdjInventory.Rows[row.Index].Cells[0].Value.ToString());
                SQL.AddParam("@adjust_qty", dgvAdjInventory.Rows[row.Index].Cells[2].Value.ToString());

                SQL.Query("UPDATE inventory SET stock_qty = stock_qty + @adjust_qty WHERE productID = @productID");

                if (SQL.HasException(true))
                {
                    new Notification().PopUp("Something went wrong.", "Error","error");
                    return;
                }
            }

            // insert to inventory_operations

            decimal qty = OL.GetSumColumn(dgvAdjInventory, 2);

            SQL.AddParam("@qty", qty);
            SQL.AddParam("@supplierID", supplierID);
            SQL.AddParam("@remarks", txtRemarks.Text);
            SQL.AddParam("@userID", Main.Instance.current_id);

            SQL.Query(@"INSERT INTO inventory_operation (operation, qty, total, supplierID, remarks, date_time, userID) 
                           VALUES ('Adjust Inventory', @qty, 0, @supplierID, @remarks, (SELECT GETDATE()), @userID)");

            if (SQL.HasException(true))
            {
                new Notification().PopUp("Something went wrong.", "Error","error");
                return;
            }

            // save to inventory_operation_items
            foreach (DataGridViewRow row in dgvAdjInventory.Rows)
            {
                SQL.AddParam("@productID", dgvAdjInventory.Rows[row.Index].Cells[0].Value.ToString());
                SQL.AddParam("@product_name", dgvAdjInventory.Rows[row.Index].Cells[1].Value.ToString());
                SQL.AddParam("@qty", Convert.ToDecimal(dgvAdjInventory.Rows[row.Index].Cells[2].Value.ToString()));

                SQL.Query(@"INSERT INTO inventory_operation_items (operationID, productID, product_name, qty) 
                           VALUES ((SELECT MAX(operationID) FROM inventory_operation), @productID, @product_name, @qty)");

                if (SQL.HasException(true))
                {
                    new Notification().PopUp("Something went wrong.", "Error","error");
                    return;
                }
            }

            new Notification().PopUp("Item saved.","","information");
            frmAOperation.LoadOperation();
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAdjInventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Checking numeric value for Column 2 only
            if ((e.ColumnIndex == 2))
            {
                string value = dgvAdjInventory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                foreach (char c in value)
                {
                    if (!Information.IsNumeric(value))
                    {
                        MessageBox.Show("Please enter numeric value.");

                        dgvAdjInventory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
                        return;
                    }
                }
            }
        }
    }
}
