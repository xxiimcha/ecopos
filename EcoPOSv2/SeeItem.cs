using EcoPOSControl;
using System;
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
            _SeeItem = this;

            //autosearch enabler
            if (Properties.Settings.Default.AutoSearchEnabled)
            {
                checkBox_Autosearch.Checked = true;
            }
            else
            {
                checkBox_Autosearch.Checked = false;
            }

            //wholesale disabler
            if (Properties.Settings.Default.DisableWholesale)
            {
                checkBox_DisableWholesale.Checked = true;
            }
            else
            {
                checkBox_DisableWholesale.Checked = false;
            }

            if (Properties.Settings.Default.Pricing == "Wholesale")
            {
                cmbPricemode.SelectedIndex = 1;
            }
            else
            {
                cmbPricemode.SelectedIndex = 0;
            }

            if (!autoNonBarcodeSearch && !isDuplicateBarcode)
            {
                this.ActiveControl = txtBarcode;
                txtBarcode.Focus();
            }

            loadTable();

            if (autoNonBarcodeSearch)
            {
                autoNonBarcodeSearch = false;
                this.ActiveControl = dgvProducts;
                dgvProducts.Focus();
            }

            if (isDuplicateBarcode)
            {
                isDuplicateBarcode = false;
                this.ActiveControl = dgvProducts;
                dgvProducts.Focus();
            }
        }
       
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadTable();
                dgvProducts.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public Boolean autoNonBarcodeSearch = false;
        public Boolean isDuplicateBarcode = false;
        //Loads the data in the table
        public void loadTable()
        {
            if (autoNonBarcodeSearch)
            {
                SQL.AddParam("@find", "%" + txtBarcode.Text + "%");
                SQL.Query(@"SELECT TOP 100 p.productID, p.barcode1 as 'Barcode 1', p.barcode2 as 'Barcode 2', p.description as 'Name', p.rp_inclusive as 'SRP', p.wp_inclusive as 'Wholesale', i.stock_qty as 'Stock' FROM products as p 
                       INNER JOIN inventory as i ON p.productID = i.productID
                       WHERE description LIKE @find OR name LIKE @find ORDER BY Difference(name, @find) DESC");
                if (SQL.HasException(true))
                    return; 
            }
            else
            {
                if (isDuplicateBarcode)
                {
                    new Notification().PopUp("There is duplicate barcode found in the products", "", "warning");
                    SQL.AddParam("@find", txtBarcode.Text);
                    SQL.Query(@"SELECT TOP 100 p.productID, p.barcode1 as 'Barcode 1', p.barcode2 as 'Barcode 2', p.description as 'Name', p.rp_inclusive as 'SRP', p.wp_inclusive as 'Wholesale', i.stock_qty as 'Stock' FROM products as p 
                       INNER JOIN inventory as i ON p.productID = i.productID
                       WHERE barcode1 = @find OR barcode2 = @find");
                    if (SQL.HasException(true))
                        return;
                }
                else
                {
                    SQL.AddParam("@find", "%" + txtBarcode.Text + "%");
                    SQL.Query(@"SELECT TOP 100 p.productID, p.barcode1 as 'Barcode 1', p.barcode2 as 'Barcode 2', p.description as 'Name', p.rp_inclusive as 'SRP', p.wp_inclusive as 'Wholesale', i.stock_qty as 'Stock' FROM products as p 
                       INNER JOIN inventory as i ON p.productID = i.productID
                       WHERE barcode1 LIKE @find OR barcode2 LIKE @find OR description LIKE @find OR name LIKE @find ORDER BY Difference(name, @find) DESC");
                    if (SQL.HasException(true))
                        return;
                }
            }

            dgvProducts.DataSource = SQL.DBDT;

            dgvProducts.Columns[0].Visible = false;


            if (dgvProducts.Rows.Count > 0)
            {
                dgvProducts.Rows[0].Selected = true;
            }

            txtBarcode.Clear();
            txtBarcode.Focus();  
        }

        private void dgvProducts_Click(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        decimal totalquantity;
        decimal quantity = 1;

        private void selectProduct()
        {
            //initiates when a product is selected
            if (dgvProducts.SelectedRows.Count == 0)
                return;

            string type_query = "rp_exclusive, rp_tax, rp_inclusive";
            string type = "R";

            if (cmbPricemode.Text == "Wholesale")
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

                    decimal stock = decimal.Parse(SQL.ReturnResult("select stock_qty from inventory where productID=" + r.Cells[0].Value.ToString()));
                    if (SQL.HasException(true)) return;

                    //Check if stock is sufficient
                    if (totalquantity > stock)
                    {
                        new Notification().PopUp("Insufficient stock", "", "error");
                        return;
                    }
                    SQL.AddParam("@productID", Convert.ToInt32(r.Cells[0].Value.ToString()));
                    Order.Instance.isItemScalable = Convert.ToBoolean(SQL.ReturnResult("SELECT isDecimal FROM units WHERE unit_id = (SELECT unit_id FROM products WHERE productID = @productID)"));
                    if (SQL.HasException(true))
                        return;

                    //Adds item to cart
                    SQL.AddParam("@productID", r.Cells[0].Value.ToString());
                    SQL.AddParam("@type", type);
                    SQL.AddParam("@time_updated", DateTime.Now);
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    SQL.Query(@"INSERT INTO order_cart (productID , description, name, type, static_price_exclusive, static_price_vat, static_price_inclusive, quantity, discount,cost,terminal_id,is_vatable, base_price_inclusive, base_price_exclusive, time_updated) 
                       SELECT productID, description, name, @type," + type_query + ", 1, 0,cost,@terminal_id,is_vatable, IIF(@type='R', rp_inclusive, wp_inclusive), IIF(@type='R', rp_exclusive, wp_exclusive), @time_updated FROM products WHERE productID = @productID");
                    if (SQL.HasException(true))
                        return;

                    SQL.AddParam("@productID", Convert.ToInt32(r.Cells[0].Value.ToString()));
                    Boolean has_expiry = Convert.ToBoolean(SQL.ReturnResult(@"SELECT has_expiry FROM products WHERE productID = @productID"));
                    if (SQL.HasException(true))
                        return;
                    if (has_expiry)
                    {
                        SQL.AddParam("@productID", Convert.ToInt32(r.Cells[0].Value.ToString()));
                        DateTime expiration = Convert.ToDateTime(SQL.ReturnResult(@"SELECT expiration_date FROM products WHERE productID = @productID"));
                        if (SQL.HasException(true))
                            return;
                        if (expiration <= DateTime.Now)
                        {                                          
                            new Notification(10).PopUp("The Product scanned is already expired.", "Warning", "error");
                        }
                        else if (expiration <= DateTime.Now.AddDays(7))
                        {
                            new Notification(10).PopUp("The Product scanned is near expiration.", "Warning", "warning");
                        }
                    }
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
                    SQL.AddParam("@time_updated", DateTime.Now);
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    SQL.Query("UPDATE order_cart SET quantity = quantity + 1, time_updated = @time_updated WHERE productID = @productID AND type = @type AND terminal_id=@terminal_id");
                    if (SQL.HasException(true))
                        return;
                }

                Order.Instance.last_item_scanned = r.Cells[0].Value.ToString();
                Close();
            }
        }


        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            selectProduct();
        }

        private void SeeItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtBarcode.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Clear();
        }

        private void dgvProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvProducts.SelectedRows.Count == 1)
                {
                    selectProduct();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                txtBarcode.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox_Autosearch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Autosearch.Checked)
            {
                Properties.Settings.Default.AutoSearchEnabled = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.AutoSearchEnabled = false;
                Properties.Settings.Default.Save();
            }
        }

        private void checkBox_DisableWholesale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DisableWholesale.Checked)
            {
                Properties.Settings.Default.DisableWholesale = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.DisableWholesale = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
