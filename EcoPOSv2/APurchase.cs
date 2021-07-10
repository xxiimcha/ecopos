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
using static EcoPOSv2.ControlBehavior;
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class APurchase : Form
    {
        public APurchase()
        {
            InitializeComponent();
        }
        //VARIABLES & ETC
        SQLControl SQL = new SQLControl();
        FormLoad OL = new FormLoad();

        DataTable dt_purchase = new DataTable();
        List<TextBox> requiredFields = new List<TextBox>();
        //VARIABLES & ETC

        //METHODS
        private void PurchaseRF()
        {
            requiredFields = new List<TextBox>();

            requiredFields.Add(txtTotalAmount);
        }

        private void ControlBehavior()
        {
            Control C = (Control)txtSearchProducts;

            SetBehavior(ref C, Behavior.ClearSearch);
        }

        private void TextValidation()
        {
            AssignValidation(ref txtTotalAmount, ValidationType.Price);
            AssignValidation(ref txtTotalAmount, ValidationType.Only_Numbers);
        }

        private void LoadPurchase()
        {
            DataColumn productID = new DataColumn();
            DataColumn name = new DataColumn();
            DataColumn qty = new DataColumn();

            name.ColumnName = "Name";
            qty.ColumnName = "Purchase Qty";

            dt_purchase.Columns.Add(productID);
            dt_purchase.Columns.Add(name);
            dt_purchase.Columns.Add(qty);

            dgvPurchase.DataSource = dt_purchase;
            dgvPurchase.Columns[0].Visible = false;

            dgvPurchase.Columns[1].ReadOnly = true;
            dgvPurchase.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
            dgvPurchase.Columns[1].DefaultCellStyle.ForeColor = Color.DarkGray;
            dgvPurchase.Columns[1].DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvPurchase.Columns[1].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
        }
        //METHODS
        private void APurchase_Load(object sender, EventArgs e)
        {
            TextValidation();
            LoadPurchase();
            ControlBehavior();

            OL.ComboValues(cmbSupplier, "supplierID", "name", "inventory_supplier");

            OL.ComboValuesQuery(cmbCategory, @"SELECT categoryID, name FROM
                                         (
                                          SELECT 0 as 'categoryID', 'All category' as 'name', 1 as ord
                                          UNION ALL
                                          SELECT categoryID, name, 2 as ord FROM product_category
                                         ) x ORDER BY ord, name ASC", "categoryID", "name");

            cmbCategory.SelectedIndex = 0;

            btnSearch.PerformClick();
        }

        string cat_query = "c.categoryID NOT IN (99999999999)";
        BackgroundWorker workerProducts;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string cat_query = "c.categoryID NOT IN (99999999999)";

            if (cmbCategory.SelectedIndex != 0)
                cat_query = "c.categoryID = " + cmbCategory.SelectedValue;

            workerProducts = new BackgroundWorker();
            workerProducts.DoWork += WorkerProducts_DoWork;
            workerProducts.RunWorkerAsync();
        }

        private void WorkerProducts_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLControl privateSQL = new SQLControl();

            privateSQL.Query(@"SELECT p.productID, p.description as 'Name', c.name as 'Category', 
                       i.stock_qty as 'Stock'  FROM products as p
                       INNER JOIN inventory as i 
                       ON p.productID = i.productID
                       INNER JOIN product_category as c 
                       ON p.categoryID = c.categoryID 
                       WHERE " + cat_query + "ORDER BY p.description ASC");

            if (privateSQL.HasException(true))
                return;

            dgvProducts.Invoke(new Action(() =>
            {
                dgvProducts.DataSource = privateSQL.DBDT;
                dgvProducts.Columns[0].Visible = false;
            }));
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dgvPurchase.RowCount > 0)
            {
                // check if item is already chosen
                DataGridViewRow datarow = new DataGridViewRow();
                for (int rows = 0; rows <= dgvProducts.Rows.Count - 1; rows++)
                {
                    int counter = 0;
                    for (var i = 0; i <= dgvPurchase.RowCount - 1; i++)
                    {
                        if (dgvProducts.Rows[rows].Cells[0].Value.ToString() == dgvPurchase.Rows[i].Cells[0].Value.ToString())
                            counter = 1;
                    }

                    // if not chosen then add
                    if (counter == 0)
                        dt_purchase.Rows.Add(dgvProducts.Rows[rows].Cells[0].Value, dgvProducts.Rows[rows].Cells[1].Value, 0);
                }
            }
            else if (dgvPurchase.RowCount == 0)
            {
                DataGridViewRow datarow = new DataGridViewRow();
                for (int rows = 0; rows <= dgvProducts.Rows.Count - 1; rows++)
                    dt_purchase.Rows.Add(dgvProducts.Rows[rows].Cells[0].Value, dgvProducts.Rows[rows].Cells[1].Value, 0);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // transfer to dgvPurchase

            if (e.RowIndex == -1)
                return;

            if (dgvPurchase.RowCount > 0)
            {
                for (var i = 0; i <= dgvPurchase.RowCount - 1; i++)
                {
                    if (dgvPurchase.Rows[i].Cells[0].Value.ToString() == dgvProducts.CurrentRow.Cells[0].Value.ToString())
                        return;
                }
                dt_purchase.Rows.Add(dgvProducts.CurrentRow.Cells[0].Value, dgvProducts.CurrentRow.Cells[1].Value, 0);
            }
            else if (dgvPurchase.RowCount == 0)
                dt_purchase.Rows.Add(dgvProducts.CurrentRow.Cells[0].Value, dgvProducts.CurrentRow.Cells[1].Value, 0);
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvPurchase.SelectedRows.Count == 0)
                return;
            else
            {
                foreach(DataGridViewRow dr in dgvPurchase.SelectedRows)
                {
                    dgvPurchase.Rows.Remove(dr);
                }
            }
        }

        private void txtSearchProducts_KeyUp(object sender, KeyEventArgs e)
        {
            SQL.AddParam("@find", txtSearchProducts.Text + "%");

            SQL.Query(@"SELECT p.productID, p.description as 'Name', c.name as 'Category', 
                       i.stock_qty as 'Stock'  FROM products as p
                       INNER JOIN inventory as i 
                       ON p.productID = i.productID
                       INNER JOIN product_category as c 
                       ON p.categoryID = c.categoryID
                       WHERE p.description LIKE @find OR p.barcode1 LIKE @find OR p.barcode2 LIKE @find
                       ORDER BY p.description ASC");

            if (SQL.HasException(true))
                return;

            dgvProducts.DataSource = SQL.DBDT;
            dgvProducts.Columns[0].Visible = false;
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            dt_purchase.Rows.Clear();
        }

        private void dgvPurchase_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Checking numeric value for Column 2 only
            if ((e.ColumnIndex == 2))
            {
                string value = dgvPurchase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                foreach (char c in value)
                {
                    if (!Information.IsNumeric(value))
                    {
                        new Notification().PopUp("Please enter numeric value.", "", "error");

                        dgvPurchase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
                        return;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // check if qty not zero

            PurchaseRF();

            int requiredFieldsMet = RequireField(ref requiredFields);

            if (requiredFieldsMet == 1 && cmbSupplier.Text != "")
            {
                if (dgvPurchase.RowCount == 0)
                    return;

                foreach (DataGridViewRow row in dgvPurchase.Rows)
                {
                    if (Convert.ToDecimal(dgvPurchase.Rows[row.Index].Cells[2].Value.ToString()) == 0 | dgvPurchase.Rows[row.Index].Cells[2].Value.ToString() == "")
                    {
                        new Notification().PopUp("Purchase quantity cannot be zero/blank.", "Error", "error");
                        return;
                    }
                }

                foreach (DataGridViewRow row in dgvPurchase.Rows)
                {
                    SQL.AddParam("@productID", dgvPurchase.Rows[row.Index].Cells[0].Value.ToString());
                    SQL.AddParam("@qty", Convert.ToDecimal(dgvPurchase.Rows[row.Index].Cells[2].Value.ToString()));

                    SQL.Query(@"UPDATE inventory SET stock_qty = stock_qty + @qty
                           WHERE productID = @productID");

                    if (SQL.HasException(true))
                    {
                        new Notification().PopUp("Something went wrong.","Error","error");
                        return;
                    }
                }

                // save to inventory_operation

                decimal qty = OL.GetSumColumn(dgvPurchase, 2);

                SQL.AddParam("@qty", qty);
                SQL.AddParam("@total", txtTotalAmount.Text);
                SQL.AddParam("@supplierID", cmbSupplier.SelectedValue);
                SQL.AddParam("@remarks", txtRemarks.Text);
                SQL.AddParam("@userID", Main.Instance.current_id);

                SQL.Query("INSERT INTO inventory_operation (operation, qty, total, supplierID, remarks, date_time, userID) VALUES ('Purchase Inventory', @qty, @total, @supplierID, @remarks, (SELECT GETDATE()), @userID)");

                if (SQL.HasException(true))
                {
                    new Notification().PopUp("Something went wrong.", "Error", "error" );
                    return;
                }

                // save to inventory_operation_items

                foreach (DataGridViewRow row in dgvPurchase.Rows)
                {
                    SQL.AddParam("@productID", dgvPurchase.Rows[row.Index].Cells[0].Value.ToString());
                    SQL.AddParam("@product_name", dgvPurchase.Rows[row.Index].Cells[1].Value.ToString());
                    SQL.AddParam("@qty", Convert.ToDecimal(dgvPurchase.Rows[row.Index].Cells[2].Value.ToString()));

                    SQL.Query(@"INSERT INTO inventory_operation_items (operationID, productID, product_name, qty) 
                           VALUES ((SELECT MAX(operationID) FROM inventory_operation), @productID, @product_name, @qty)");

                    if (SQL.HasException(true))
                    {
                        new Notification().PopUp("Something went wrong.", "Error", "error" );
                        return;
                    }
                }

                btnSearch.PerformClick();
                dt_purchase.Rows.Clear();
                new Notification().PopUp("Item saved.", "", "information");

                txtRemarks.Clear();
                txtTotalAmount.Clear();
            }
            else
                new Notification().PopUp("Please fill all required fields.","Save failed", "error");
        }

       
    }
}
