using EcoPOSControl;
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
    public partial class SeeItem : Form
    {
        public SeeItem()
        {
            InitializeComponent();
        }
        public static SeeItem _SeeItem;
        public static SeeItem Instance
        {
            get
            {
                if (_SeeItem == null)
                {
                    _SeeItem = new SeeItem();
                }
                return _SeeItem;
            }
        }




        SQLControl SQL = new SQLControl();

        public Order frmOrder;
 
        private void SeeItem_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBarcode;
            txtBarcode.Focus();

            _SeeItem = this;
        }
        public static string seeitemsearch;
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SQL.AddParam("@find", "%" + txtBarcode.Text + "%");

                SQL.Query(@"SELECT p.productID, p.barcode1 as 'Barcode 1', p.barcode2 as 'Barcode 2', p.description as 'Name', p.rp_inclusive as 'SRP', p.wp_inclusive as 'Wholesale', CAST(i.stock_qty AS INT) as 'Stock' FROM products as p 
                       INNER JOIN inventory as i ON p.productID = i.productID
                       WHERE barcode1 LIKE @find OR barcode2 LIKE @find OR description LIKE @find OR name LIKE @find ORDER BY name ASC");

                if (SQL.HasException(true))
                    return;

                dgvProducts.DataSource = SQL.DBDT;

                dgvProducts.Columns[0].Visible = false;


                if(dgvProducts.Rows.Count > 0)
                {
                    dgvProducts.Rows[0].Selected = true;
                }


                txtBarcode.Clear();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            //(dgvProducts.DataSource as DataTable).DefaultView.RowFilter =
            //            string.Format("Barcode1 LIKE '{0}%'", "");

            //txtBarcode.Clear();
            //txtBarcode.Focus();
            //txtBarcode.Text = txtBarcode.Text.Replace(" ", "");
        }

        private void dgvProducts_Click(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }
        string quantitytalaga;
        decimal totalquantity;
        decimal quantity = 1;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
                return;

            string type_query = " rp_exclusive, rp_tax, rp_inclusive";
            string type = "R";

            if (rbWholesale.Checked)
            {
                type = "W";
                type_query = "wp_exclusive, wp_tax, wp_inclusive";
            }


            foreach (DataGridViewRow r in dgvProducts.SelectedRows)
            {
                SQL.AddParam("@productID", r.Cells[0].Value.ToString());
                SQL.AddParam("@type", type);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                int check_in_cart = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM order_cart WHERE productID = @productID AND type = @type AND terminal_id=@terminal_id"));
                if (SQL.HasException(true))
                    return;

                if (check_in_cart == 0)
                {
                    totalquantity = 0 + quantity;

                    decimal stock = decimal.Parse(SQL.ReturnResult("select stock_qty from inventory where productID="+ r.Cells[0].Value.ToString()));
                    if (SQL.HasException(true)) return;

                    //Check if stock is sufficient
                    if (totalquantity > stock)
                    {
                        new Notification().PopUp("Insufficient stock", "", "error");
                        return;
                    }

                    //Adds item to cart
                    SQL.AddParam("@productID", r.Cells[0].Value.ToString());
                    SQL.AddParam("@type", type);
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    SQL.Query(@"INSERT INTO order_cart (productID , description, name, type, static_price_exclusive, static_price_vat, static_price_inclusive, quantity, discount,cost,terminal_id,is_vatable) 
                       SELECT productID, description, name, @type," + type_query + ", 1, 0,cost,@terminal_id,is_vatable FROM products WHERE productID = @productID");
                    if (SQL.HasException(true))
                        return;
                }
                else
                {
                    //check if still in stock (retail and wholesale)
                    SQL.AddParam("@productID", r.Cells[0].Value.ToString());
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    if (int.Parse(SQL.ReturnResult("SELECT IIF((SELECT SUM(quantity) FROM order_cart WHERE terminal_id=@terminal_id AND productID = @productID) >= (SELECT stock_qty FROM inventory WHERE productID = @productID), 1, 0)")) == 1)
                    {
                        new Notification().PopUp("Insufficient stock", "", "error");
                        return;
                    }

                    //Checks if quantity is greater than stock
                    SQL.AddParam("@productID", r.Cells[0].Value.ToString());
                    decimal stock = decimal.Parse(SQL.ReturnResult("select stock_qty from inventory where productID=@productID"));

                    if (SQL.HasException(true)) return;

                    if (quantity > stock)
                    {
                        new Notification().PopUp("Insufficient stock", "", "error");
                        return;
                    }

                    SQL.AddParam("@productID", r.Cells[0].Value.ToString());
                    SQL.AddParam("@type", type);
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    SQL.Query("UPDATE order_cart SET quantity = quantity + 1 WHERE productID = @productID AND type = @type AND terminal_id=@terminal_id");
                    if (SQL.HasException(true))
                        return;
                }

                Order.Instance.LoadOrder();
                Order.Instance.GetTotal();

                Order.Instance.ActiveControl = Order.Instance.tbBarcode;

                Close();
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text == "")
            {
                return;
            }
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            btnConfirm.PerformClick();
        }

        private void SeeItem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
