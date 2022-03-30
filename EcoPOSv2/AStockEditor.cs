using EcoPOSControl;
using Microsoft.VisualBasic;
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
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class AStockEditor : Form
    {
        public AStockEditor()
        {
            InitializeComponent();
        }

        private void AStockEditor_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    btnSearch.Text = "Wait";

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

                    dgvProducts.DataSource = GlobalVariables.dtPurchaseProducts;
                    btnSearch.Text = "Search";
                }));
            })
            { IsBackground = true }.Start();
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
            Task.Run(() =>
            {
                DataColumn productID = new DataColumn();
                DataColumn name = new DataColumn();
                DataColumn qty = new DataColumn();
                DataColumn cost = new DataColumn();
                DataColumn total = new DataColumn();

                name.ColumnName = "Name";
                qty.ColumnName = "Qty";
                cost.ColumnName = "Cost";
                total.ColumnName = "Total";

                dt_purchase.Columns.Add(productID);
                dt_purchase.Columns.Add(name);
                dt_purchase.Columns.Add(qty);
                dt_purchase.Columns.Add(cost);
                dt_purchase.Columns.Add(total);
                Invoke(new MethodInvoker(delegate ()
                {
                    dgvPurchase.DataSource = dt_purchase;

                    dgvPurchase.Columns[0].Visible = false;
                    dgvPurchase.Columns[4].Visible = false;

                    dgvPurchase.Columns[1].ReadOnly = true;
                    //dgvPurchase.Columns[1].Width = 350;
                }));
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex != 0)
            {
                DataView dv = new DataView(GlobalVariables.dtPurchaseProducts);
                dv.RowFilter = "Category = '" + cmbCategory.Text + "'";
                dgvProducts.DataSource = dv;
                dgvProducts.Columns[0].Visible = false;
            }
            else
            {
                dgvProducts.DataSource = GlobalVariables.dtPurchaseProducts;
                dgvProducts.Columns[0].Visible = false;
            }
        }
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
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
                            dt_purchase.Rows.Add(dgvProducts.Rows[rows].Cells[0].Value, dgvProducts.Rows[rows].Cells[1].Value, 0, dgvProducts.CurrentRow.Cells[4].Value);
                    }
                }
                else if (dgvPurchase.RowCount == 0)
                {
                    DataGridViewRow datarow = new DataGridViewRow();
                    for (int rows = 0; rows <= dgvProducts.Rows.Count - 1; rows++)
                        dt_purchase.Rows.Add(dgvProducts.Rows[rows].Cells[0].Value, dgvProducts.Rows[rows].Cells[1].Value, 0, dgvProducts.CurrentRow.Cells[4].Value);
                }
            }
            catch (Exception) { }
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
                dt_purchase.Rows.Add(dgvProducts.CurrentRow.Cells[0].Value, dgvProducts.CurrentRow.Cells[1].Value, 0, dgvProducts.CurrentRow.Cells[4].Value, 0);
            }
            else if (dgvPurchase.RowCount == 0)
                dt_purchase.Rows.Add(dgvProducts.CurrentRow.Cells[0].Value, dgvProducts.CurrentRow.Cells[1].Value, 0, dgvProducts.CurrentRow.Cells[4].Value, 0);
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvPurchase.SelectedRows.Count == 0)
                return;
            else
            {
                foreach (DataGridViewRow dr in dgvPurchase.SelectedRows)
                {
                    dgvPurchase.Rows.Remove(dr);
                }
            }
        }

        private void txtSearchProducts_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearchProducts.Text != "")
            {
                SQL.AddParam("@find", txtSearchProducts.Text + "%");

                SQL.Query(@"SELECT p.productID, p.description as 'Name', c.name as 'Category', 
                       i.stock_qty as 'Stock',p.cost FROM products as p
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
            else
            {
                dgvProducts.DataSource = GlobalVariables.dtPurchaseProducts;
                dgvProducts.Columns[0].Visible = false;
            }

            //MessageBox.Show(dgvProducts.Columns.Count.ToString());
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            dt_purchase.Rows.Clear();

            txtTotalAmount.Text = "0";
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

            if ((e.ColumnIndex == 3))
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

            foreach (DataGridViewRow r in dgvPurchase.Rows)
            {
                decimal cost = Convert.ToDecimal(r.Cells[3].Value);
                decimal quantity = Convert.ToDecimal(r.Cells[2].Value);

                decimal total = cost * quantity;

                r.Cells[4].Value = total;
            }


            decimal Total = 0;

            for (int i = 0; i < dgvPurchase.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dgvPurchase.Rows[i].Cells["Total"].Value);
            }

            txtTotalAmount.Text = Total.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            PurchaseRF();

            int requiredFieldsMet = RequireField(ref requiredFields);

            if (requiredFieldsMet == 1 && cmbSupplier.Text != "" && tbOperationCode.Text != "Operation Code")
            {
                if (dgvPurchase.RowCount == 0)
                    return;

                //DISABLING PURCHASE BUTTON
                btnSave.Enabled = false;

                SQL.AddParam("@operation_code", tbOperationCode.Text);
                if (int.Parse(SQL.ReturnResult("select count(operation) from inventory_operation where operation_code = @operation_code and operation = 'Edit Inventory'")) > 0)
                {
                    new Notification().PopUp("Duplicate operation code found in our system.", "", "error");
                    btnSave.Enabled = true;
                    return;
                }

                /* JEREMY's WAY
                foreach (DataGridViewRow row in dgvPurchase.Rows)
                {
                    if (Convert.ToDecimal(dgvPurchase.Rows[row.Index].Cells[2].Value.ToString()) == 0 | dgvPurchase.Rows[row.Index].Cells[2].Value.ToString() == "")
                    {
                        new Notification().PopUp("Purchase quantity cannot be zero/blank.", "Error", "error");
                        return;
                    }
                }*/

                if (dgvPurchase.RowCount == 0)
                {
                    btnSave.Enabled = true;
                    return;
                }

                // save to inventory_operation
                decimal qty = OL.GetSumColumn(dgvPurchase, 2);

                SQL.AddParam("@operation_code", tbOperationCode.Text);
                SQL.AddParam("@qty", qty);
                SQL.AddParam("@total", txtTotalAmount.Text);
                SQL.AddParam("@supplierID", cmbSupplier.SelectedValue);
                SQL.AddParam("@remarks", txtRemarks.Text);
                SQL.AddParam("@userID", Main.Instance.current_id);

                SQL.Query("INSERT INTO inventory_operation (operation_code,operation, qty, total, supplierID, remarks, date_time, userID) VALUES (@operation_code,'Edit Inventory', @qty, @total, @supplierID, @remarks, (SELECT GETDATE()), @userID)");

                if (SQL.HasException(true))
                {
                    btnSave.Enabled = true;
                    new Notification().PopUp("Something went wrong.", "Error", "error");
                    return;
                }

                int number_of_items_updated = 0;
                //LOOPS THROUGH ALL THE ITEMS ADDED
                foreach (DataGridViewRow row in dgvPurchase.Rows)
                {
                    //CHECKS IF QUANTITY IS BLANK OR ZERO
                    if (dgvPurchase.Rows[row.Index].Cells[2].Value.ToString() != "")
                    {
                        //INSERTS TO OPERATION ITEMS
                        SQL.AddParam("@productID", dgvPurchase.Rows[row.Index].Cells[0].Value.ToString());
                        SQL.AddParam("@product_name", dgvPurchase.Rows[row.Index].Cells[1].Value.ToString());
                        SQL.AddParam("@qty", Convert.ToDecimal(dgvPurchase.Rows[row.Index].Cells[2].Value.ToString()));

                        SQL.Query(@"INSERT INTO inventory_operation_items (operationID, productID, product_name, qty) 
                           VALUES ((SELECT MAX(operationID) FROM inventory_operation), @productID, @product_name, @qty)");

                        if (SQL.HasException(true)) return;

                        //UPDATE COST
                        SQL.AddParam("@productID", dgvPurchase.Rows[row.Index].Cells[0].Value.ToString());
                        SQL.AddParam("@cost", dgvPurchase.Rows[row.Index].Cells[3].Value.ToString());
                        SQL.Query("update products set cost = @cost where productID=@productID");

                        if (SQL.HasException(true))
                            return;


                        if (SQL.HasException(true))
                        {
                            new Notification().PopUp("Something went wrong.", "Error", "error");
                            btnSave.Enabled = true;
                            return;
                        }

                        //UPDATE QUANTITY 
                        SQL.AddParam("@productID", dgvPurchase.Rows[row.Index].Cells[0].Value.ToString());
                        SQL.AddParam("@qty", Convert.ToDecimal(dgvPurchase.Rows[row.Index].Cells[2].Value.ToString()));

                        SQL.Query(@"UPDATE inventory SET stock_qty = @qty
                           WHERE productID = @productID");
                        if (SQL.HasException(true))
                        {
                            new Notification().PopUp("Something went wrong.", "Error", "error");
                            btnSave.Enabled = true;
                            return;
                        }
                        number_of_items_updated++;
                    }
                }

                if (number_of_items_updated > 0)
                {
                    btnSearch.PerformClick();
                    dt_purchase.Rows.Clear();

                    tbOperationCode.Clear();
                    txtRemarks.Clear();
                    txtTotalAmount.Clear();

                    new Notification().PopUp("Item Edit Saved.", "", "information");
                }
                else
                {
                    new Notification().PopUp("Values for the items hasn't been set.", "Save failed", "error");

                    SQL.AddParam("@operation_code", tbOperationCode.Text);
                    SQL.Query(@"DELETE FROM inventory_operation WHERE operation_code = @operation_code AND operation = 'Edit Inventory'");

                    if (SQL.HasException(true))
                    {
                        new Notification().PopUp("Something went wrong.", "Error", "error");
                        btnSave.Enabled = true;
                        return;
                    }
                }

                GlobalVariables.LoadPurchaseProducts();
                dgvProducts.DataSource = GlobalVariables.dtPurchaseProducts;

                //ENABLING PURCHASE BUTTON
                btnSave.Enabled = true;
            }
            else
                new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void TxtTotalAmount_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "0")
            {
                (sender as TextBox).Text = "";
            }
        }

        private void TxtTotalAmount_Leave(object sender, EventArgs e)
        {

        }

        private void TbOperationCode_Enter(object sender, EventArgs e)
        {
            if (tbOperationCode.Text == "Operation Code")
            {
                tbOperationCode.Text = "";
                tbOperationCode.ForeColor = Color.Black;
            }
        }

        private void TbOperationCode_Leave(object sender, EventArgs e)
        {
            if (tbOperationCode.Text == "")
            {
                tbOperationCode.Text = "Operation Code";
                tbOperationCode.ForeColor = Color.Gray;
            }
        }

        private void BtnGenerateOCCode_Click(object sender, EventArgs e)
        {
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string year = DateTime.Now.Year.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string minutes = DateTime.Now.Minute.ToString();
            string seconds = DateTime.Now.Second.ToString();

            tbOperationCode.Text = month + day + year + hour + minutes + seconds;
            tbOperationCode.ForeColor = Color.Black;
        }

        
    }
}
