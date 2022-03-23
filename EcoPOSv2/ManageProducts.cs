using EcoPOSControl;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EcoPOSv2.ControlBehavior;
using static EcoPOSv2.GroupAction;
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class ManageProducts : Form
    {
        public ManageProducts()
        {
            InitializeComponent();
            dgvCategory.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvCategory, true, null);
            dgvProducts.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvCategory, true, null);
            dgvCat_Category.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvCategory, true, null);


            this.dgvCategory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCat_Category.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        }

        SQLControl SQL = new SQLControl();
        FormLoad OL = new FormLoad();
        GroupAction GA = new GroupAction();
        Panel currentPanel;
        Button currentButton;
        List<Control> allTxt = new List<Control>();
        List<TextBox> requiredFields = new List<TextBox>();
        string cat_query;
        //METHODS
        private void LoadExpirationDate()
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    cat_query = "products.categoryID NOT IN (0)";

                    if (cmbECategory.SelectedIndex != 0)
                    {
                        cat_query = "products.categoryID = " + cmbECategory.SelectedValue;
                    }


                    SQLControl psql = new SQLControl();

                    psql.Query("select products.barcode1 as 'Barcode1',products.barcode2 as 'Barcode2',products.description as 'Description',products.name as 'ProductName',product_category.name as 'CategoryName',products.expiration_date as 'Expiry Date' from products JOIN product_category ON products.categoryID = product_category.categoryID and products.has_expiry = 'true' AND " + cat_query + " ORDER BY products.expiration_date asc");
                    if (psql.HasException(true)) return;

                    dgvExpirationDate.DataSource = psql.DBDT;

                    dgvExpirationDate.Columns[0].Visible = false;
                    dgvExpirationDate.Columns[1].Visible = false;


                    foreach (DataGridViewRow row in dgvExpirationDate.Rows)
                    {
                        var now = DateTime.Now;
                        var expirationDate = DateTime.Parse(row.Cells[5].Value.ToString());
                        var sevenDayBefore = expirationDate.AddDays(-7);

                        if (now >= sevenDayBefore && now < expirationDate)
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else if (now >= expirationDate)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }

                    dgvExpirationDate.ClearSelection();
                }));
            }).Start();
        }
        private void ClearFields_Cat()
        {
            GA.DoThis(ref allTxt, TableLayoutPanel4, ControlType.TextBox, GroupAction.Action.Clear);
            cbxCat_DiscPWD.Checked = false;
            GA.DoThis(ref allTxt, TableLayoutPanel4, ControlType.CheckBox, GroupAction.Action.Uncheck);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public void SetDoubleBuffered(Panel panel)
        {
            typeof(Panel).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               panel,
               new object[] { true });
        }
        private void loadCat_Category()
        {
            SQL.Query("Select categoryID, Name FROM product_category ORDER BY name ASC");
            if (SQL.HasException(true))
                return;

            dgvCat_Category.DataSource = SQL.DBDT;

            dgvCat_Category.Columns[0].Visible = false;
        }
        private void CategoryRF()
        {
            requiredFields = new List<TextBox>();

            requiredFields.Add(txtCategoryName);
        }
        private void ClearFields_Pr()
        {
            GA.DoThis(ref allTxt, TableLayoutPanel1, ControlType.TextBox, GroupAction.Action.Clear);
            cbxDiscPWD.Checked = false;
            GA.DoThis(ref allTxt, TableLayoutPanel1, ControlType.CheckBox, GroupAction.Action.Uncheck);


            txtRPInclusive.Text = "0.00";
            txtWPInclusive.Text = "0.00";
            txtProductStock.Text = "0";
            tbProductCost.Text = "0";

            dtpExpiry.Value = DateTime.Now;

            if (Properties.Settings.Default.vatnonvat == true && Properties.Settings.Default.nonvat_registered == false)
            {
                cbxVatable.Checked = true;
            }
            else if (Properties.Settings.Default.vatnonvat == true && Properties.Settings.Default.nonvat_registered == false)
            {
                cbxVatable.Checked = false;
            }
        }

        private void ProductsRF()
        {
            requiredFields = new List<TextBox>();

            requiredFields.Add(txtDescription);
            requiredFields.Add(txtName);
            requiredFields.Add(txtRPInclusive);
            requiredFields.Add(txtWPInclusive);
        }

        private void LoadProducts()
        {
            BackgroundWorker workerloadproducts = new BackgroundWorker();
            workerloadproducts.DoWork += Workerloadproducts_DoWork;
            workerloadproducts.RunWorkerAsync();
        }

        private void Workerloadproducts_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLControl pSQL = new SQLControl();

            pSQL.Query("SELECT TOP 150 productID, description, name FROM products ORDER BY description ASC");
            if (SQL.HasException(true))
                return;

            dgvProducts.Invoke(new System.Action(() =>
            {
                dgvProducts.DataSource = pSQL.DBDT;
                dgvProducts.Columns[0].Visible = false;
                dgvProducts.Columns[1].Width = 300;
            }));
        }

        private void ReloadProducts()
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    SQLControl PSQL = new SQLControl();

                    dgvCategory.Invoke(new System.Action(() =>
                    {
                        if ((dgvCategory.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0))
                        {
                            dgvCategory.Select();
                            if (Convert.ToInt32(dgvCategory.CurrentRow.Cells[0].Value.ToString()) != 0)
                            {
                                PSQL.AddParam("@categoryID", (dgvCategory.CurrentRow.Cells[0].Value.ToString()));

                                PSQL.Query("SELECT productID, description, name FROM products WHERE categoryID = @categoryID ORDER BY description ASC");
                                if (PSQL.HasException(true))
                                    return;

                                dgvProducts.Invoke(new System.Action(() =>
                                {
                                    dgvProducts.DataSource = PSQL.DBDT;
                                    dgvProducts.Columns[0].Visible = false;
                                    dgvProducts.Columns[1].Width = 300;
                                }));

                                return;
                            }

                            PSQL.Query("SELECT 150 productID, description, name FROM products ORDER BY description ASC");
                            if (PSQL.HasException(true))
                                return;

                            dgvProducts.Invoke(new System.Action(() =>
                            {
                                dgvProducts.DataSource = PSQL.DBDT;
                                dgvProducts.Columns[0].Visible = false;
                                dgvProducts.Columns[1].Width = 300;
                            }));
                        }
                    }));
                }));
            }).Start();
        }
        private void LoadExpirationCategory()
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    OL.ComboValuesQuery(cmbECategory, @"SELECT categoryID, name FROM
                                         (
                                          SELECT 0 as 'categoryID', 'All category' as 'name', 1 as ord
                                          UNION ALL
                                          SELECT categoryID, name, 2 as ord FROM product_category
                                         ) x ORDER BY ord, name ASC", "categoryID", "name");
                }));
            }).Start();
        }
        private void LoadCategory()
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    SQLControl pSQL = new SQLControl();

                    //pSQL.Query(@"SELECT catID, catName FROM
                    //       (
                    //       SELECT 0 as catID, 'All Categories' as catName
                    //       UNION ALL 
                    //       SELECT categoryID as catID, name as catName FROM product_category 
                    //       ) x ORDER BY 
                    //       CASE WHEN catName = 'All Categories' then 1
                    //       ELSE 5
                    //       END,
                    //       catname ASC");

                    pSQL.Query("Select categoryID as catID, Name FROM product_category ORDER BY name ASC");

                    if (pSQL.HasException(true))
                        return;

                    dgvCategory.Invoke(new System.Action(() =>
                    {
                        dgvCategory.DataSource = pSQL.DBDT;
                        dgvCategory.Columns[0].Visible = false;
                    }));
                }));
            }).Start();
        }

        private void TextValidation()
        {
            AssignValidation(ref txtRPInclusive, ValidationType.Price);
            AssignValidation(ref txtRPInclusive, ValidationType.Only_Numbers);
            AssignValidation(ref txtWPInclusive, ValidationType.Price);
            AssignValidation(ref txtWPInclusive, ValidationType.Only_Numbers);

            AssignValidation(ref txtProductStock, ValidationType.Price);
            AssignValidation(ref txtProductStock, ValidationType.Only_Numbers);

            AssignValidation(ref tbProductCost, ValidationType.Price);
            AssignValidation(ref tbProductCost, ValidationType.Only_Numbers);
        }

        private void ControlBehavior()
        {
            Control sp = (Control)txtSearchProduct;
            Control sc = (Control)txtSearchCategory;
            Control csc = (Control)txtCat_SearchCategory;

            SetBehavior(ref sp, Behavior.ClearSearch);
            SetBehavior(ref sc, Behavior.ClearSearch);
            SetBehavior(ref csc, Behavior.ClearSearch);
        }
        //METHODS
        private void ManageProducts_Load(object sender, EventArgs e)
        {
            currentPanel = pnlProducts;
            currentButton = btnProduct;

            new CreateParams();
            SetDoubleBuffered(guna2Panel1);

            TextValidation();
            ControlBehavior();

            LoadCategory();
            //LoadProducts();
            loadCat_Category();

            OL.ComboValues(cmbCategory, "categoryID", "name", "product_category");
            OL.ComboValues(cmbWarehouse, "warehouseID", "name", "warehouse");

            //VAT-NONVAT
            if (Properties.Settings.Default.vatnonvat == true && Properties.Settings.Default.nonvat_registered == false)
            {
                cbxVatable.Enabled = true;
                cbxVatable.Visible = true;


                cbxCat_DiscPWD.Enabled = true;
                cbxCat_DiscAthlete.Enabled = true;
                cbxCat_AskQuantity.Enabled = true;
            }
            else if (Properties.Settings.Default.vatnonvat == true && Properties.Settings.Default.nonvat_registered == true)
            {
                cbxVatable.Enabled = false;
                cbxVatable.Visible = true;


                cbxCat_DiscPWD.Enabled = false;
                cbxCat_DiscAthlete.Enabled = false;
                cbxCat_AskQuantity.Enabled = false;
            }
            else
            {
                cbxVatable.Enabled = false;
                cbxVatable.Visible = false;

                cbxDiscAthlete.Enabled = true;
                cbxDiscPWD.Enabled = true;
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlCategory, ref currentPanel, btnCategory, ref currentButton);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlProducts, ref currentPanel, btnProduct, ref currentButton);
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (txtProductID.Text == "" & dgvCategory.CurrentRow.Cells[0].Value.ToString() != "0")
                cmbCategory.SelectedValue = dgvCategory.CurrentRow.Cells[0].Value.ToString();

            ReloadProducts();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    cbxVatable.Checked = false;
                    //VATABLE OR NON-VAT
                    //if(Properties.Settings.Default.vatnonvat == false)
                    //{
                    //    cbxVatable.Checked = false;
                    //}

                    if (e.RowIndex == -1)
                        return;

                    SQL.AddParam("@productID", dgvProducts.CurrentRow.Cells[0].Value.ToString());

                    SQL.Query("SELECT * FROM products WHERE productID = @productID");
                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        //FOR UPDATE
                        description = r["description"].ToString();
                        name = r["name"].ToString();

                        txtProductID.Text = r["productID"].ToString();
                        txtDescription.Text = r["description"].ToString();
                        txtName.Text = r["name"].ToString();
                        cmbCategory.SelectedValue = r["categoryID"].ToString();
                        txtRPInclusive.Text = r["rp_inclusive"].ToString();
                        txtWPInclusive.Text = r["wp_inclusive"].ToString();
                        txtBarcode1.Text = r["barcode1"].ToString();
                        txtBarcode2.Text = r["barcode2"].ToString();
                        cmbWarehouse.SelectedValue = r["warehouseID"].ToString();
                        cbxDiscRegular.Checked = Convert.ToBoolean(r["s_discR"].ToString());
                        cbxDiscPWD.Checked = Convert.ToBoolean(r["s_discPWD_SC"].ToString());
                        cbxDiscAthlete.Checked = Convert.ToBoolean(r["s_discAth"].ToString());
                        cbxVatable.Checked = Convert.ToBoolean(r["s_ask_qty"].ToString());
                        tbProductCost.Text = r["cost"].ToString();
                        cbxHasExpiry.Checked = Convert.ToBoolean(r["has_expiry"].ToString());
                        cbxVatable.Checked = Convert.ToBoolean(r["is_vatable"].ToString());

                        if (Convert.ToBoolean(r["has_expiry"].ToString()) == true)
                        {
                            dtpExpiry.Value = DateTime.Parse(r["expiration_date"].ToString());
                        }
                        else
                        {
                            dtpExpiry.Value = DateTime.Now;
                        }

                        if (cbxDiscPWD.Checked == true)
                        {
                            if (decimal.Parse(r["s_PWD_SC_perc"].ToString()) == 5)
                                rb5PWD.Checked = true;
                            else
                                rb20PWD.Checked = true;
                        }


                        lblStock.Visible = false;
                        txtProductStock.Clear();
                        txtProductStock.Visible = false;

                        //lblCost.Visible = false;
                        //tbProductCost.Clear();
                        //tbProductCost.Visible = false;
                    }
                }));
            }).Start();
        }

        private void btnProduct_New_Click(object sender, EventArgs e)
        {
            ClearFields_Pr();
            //VISIBLE ON IN PRODUCT INVENTORY QUANTITY
            lblStock.Visible = true;
            txtProductStock.Visible = true;

            //lblCost.Visible = true;
            //tbProductCost.Visible = true;

            dgvCategory.Select();

            try
            {
                cmbCategory.Text = dgvCategory.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception)
            {
            }

            this.ActiveControl = txtDescription;
        }
        string description, name;
        int checkerforduplicateB1 = 0, checkerforduplicateB2 = 0;
        private void btnProduct_Save_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    ProductsRF();
                    int requiredFieldsMet = RequireField(ref requiredFields);

                    if (requiredFieldsMet == 1 || cmbCategory.Text != "" || cmbWarehouse.Text != "")
                    {
                        string action = "Update";
                        decimal pwd_perc = 0;
                        decimal sc_perc = 0;

                        if (txtProductID.Text == "")
                            action = "New";


                        if (rb5PWD.Checked)
                            pwd_perc = 5;
                        else if (rb20PWD.Checked)
                            pwd_perc = 20;


                        switch (action)
                        {
                            case "New":
                                {
                                    if (txtDescription.Text == "" || txtName.Text == "")
                                    {
                                        new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
                                        return;
                                    }

                                    // check for duplicate names
                                    SQL.AddParam("@name", txtName.Text);
                                    int result = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM products WHERE name = @name) > 0,'1', '0') as result"));

                                    if (SQL.HasException(true))
                                        return;

                                    if (txtBarcode1.Text != "")
                                    {
                                        SQL.AddParam("@barcode1", txtBarcode1.Text);
                                        checkerforduplicateB1 = int.Parse(SQL.ReturnResult("SELECT COUNT(*) FROM products WHERE(barcode1 = @barcode1 OR barcode2 = @barcode1)"));
                                        if (SQL.HasException(true)) return;
                                    }
                                    else
                                    {
                                        checkerforduplicateB1 = 0;
                                    }


                                    if (txtBarcode2.Text != "")
                                    {
                                        SQL.AddParam("@barcode2", txtBarcode2.Text);
                                        checkerforduplicateB2 = int.Parse(SQL.ReturnResult("SELECT COUNT(*) FROM products WHERE(barcode1 = @barcode2 OR barcode2 = @barcode2)"));

                                        if (SQL.HasException(true)) return;
                                    }
                                    else
                                    {
                                        checkerforduplicateB2 = 0;
                                    }

                                    if (result == 0 && checkerforduplicateB1 == 0 && checkerforduplicateB2 == 0)
                                    {
                                        if (Properties.Settings.Default.vatnonvat == true)
                                        {
                                            SQL.AddParam("@name", txtName.Text);
                                            SQL.AddParam("@description", txtDescription.Text);
                                            SQL.AddParam("@categoryID", cmbCategory.SelectedValue);
                                            SQL.AddParam("@rp_inclusive", txtRPInclusive.Text);
                                            SQL.AddParam("@wp_inclusive", txtWPInclusive.Text);
                                            SQL.AddParam("@barcode1", txtBarcode1.Text);
                                            SQL.AddParam("@barcode2", txtBarcode2.Text);
                                            SQL.AddParam("@warehouseID", cmbWarehouse.SelectedValue);
                                            SQL.AddParam("@s_discR", cbxDiscRegular.CheckState);
                                            SQL.AddParam("@s_discPWD_SC", cbxDiscPWD.CheckState);
                                            SQL.AddParam("@s_PWD_SC_perc", pwd_perc);
                                            SQL.AddParam("@s_discAth", cbxDiscAthlete.CheckState);
                                            SQL.AddParam("@s_ask_qty", cbxVatable.CheckState);
                                            SQL.AddParam("@is_vatable", cbxVatable.CheckState);
                                            SQL.AddParam("@cost", tbProductCost.Text);
                                            SQL.AddParam("@has_expiry", cbxHasExpiry.CheckState);
                                            SQL.AddParam("@expiration_date", dtpExpiry.Value.ToShortDateString());

                                            SQL.Query(@"INSERT INTO products
                                   (description, name, categoryID, rp_inclusive, wp_inclusive, barcode1, barcode2, warehouseID, 
                                    s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth,is_vatable, s_ask_qty,cost,has_expiry,expiration_date)
                                   VALUES
                                   (@description, @name, @categoryID, @rp_inclusive, @wp_inclusive, @barcode1, @barcode2, @warehouseID, 
                                    @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty,@is_vatable,@cost,@has_expiry,@expiration_date)");

                                            if (SQL.HasException(true))
                                                return;
                                        }
                                        else
                                        {
                                            SQL.AddParam("@name", txtName.Text);
                                            SQL.AddParam("@description", txtDescription.Text);
                                            SQL.AddParam("@categoryID", cmbCategory.SelectedValue);
                                            SQL.AddParam("@rp_inclusive", txtRPInclusive.Text);
                                            SQL.AddParam("@wp_inclusive", txtWPInclusive.Text);
                                            SQL.AddParam("@barcode1", txtBarcode1.Text);
                                            SQL.AddParam("@barcode2", txtBarcode2.Text);
                                            SQL.AddParam("@warehouseID", cmbWarehouse.SelectedValue);
                                            SQL.AddParam("@s_discR", cbxDiscRegular.CheckState);
                                            SQL.AddParam("@s_discPWD_SC", cbxDiscPWD.CheckState);
                                            SQL.AddParam("@s_PWD_SC_perc", pwd_perc);
                                            SQL.AddParam("@s_discAth", cbxDiscAthlete.CheckState);
                                            SQL.AddParam("@s_ask_qty", cbxVatable.CheckState);
                                            SQL.AddParam("@cost", tbProductCost.Text);
                                            SQL.AddParam("@has_expiry", cbxHasExpiry.CheckState);
                                            SQL.AddParam("@expiration_date", dtpExpiry.Value.ToShortDateString());

                                            SQL.Query(@"INSERT INTO products
                                   (description, name, categoryID, rp_inclusive, wp_inclusive, barcode1, barcode2, warehouseID, 
                                    s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty,cost,has_expiry,expiration_date)
                                   VALUES
                                   (@description, @name, @categoryID, @rp_inclusive, @wp_inclusive, @barcode1, @barcode2, @warehouseID, 
                                    @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty,@cost,@has_expiry,@expiration_date)");

                                            if (SQL.HasException(true))
                                                return;
                                        }

                                        // create inventory

                                        SQL.AddParam("@stock_qty", txtProductStock.Text);
                                        SQL.Query("INSERT INTO inventory (productID, stock_qty) VALUES ((SELECT MAX(productID) FROM products), @stock_qty)");

                                        if (SQL.HasException(true))
                                            return;

                                        ClearFields_Pr();
                                        new Notification().PopUp("Item saved.", "", "success");


                                        lblStock.Visible = false;
                                        txtProductStock.Clear();
                                        txtProductStock.Visible = false;
                                    }
                                    else
                                    {
                                        new Notification().PopUp("Duplicate name/barcode found.", "Save failed", "error");
                                        return;
                                    }
                                    break;
                                }

                            default:
                                {
                                    if (txtDescription.Text == "" || txtName.Text == "")
                                    {
                                        new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
                                        return;
                                    }

                                    // check for duplicate names other than itself
                                    SQL.AddParam("@productID", txtProductID.Text);
                                    SQL.AddParam("@name", txtName.Text);

                                    string result = SQL.ReturnResult(@"SELECT IIF((
                SELECT COUNT(*) as duplicatecount FROM products WHERE name = @name AND productID <> @productID) > 0,
                1, 0) as result");

                                    if (SQL.HasException(true))
                                        return;



                                    if (txtBarcode1.Text != "")
                                    {
                                        SQL.AddParam("@productid", txtProductID.Text);
                                        SQL.AddParam("@barcode1", txtBarcode1.Text);
                                        checkerforduplicateB1 = int.Parse(SQL.ReturnResult("SELECT COUNT(*) FROM products WHERE(barcode1 = @barcode1 OR barcode2 = @barcode1) AND ProductID <>@productid"));
                                        if (SQL.HasException(true)) return;
                                    }
                                    else
                                    {
                                        checkerforduplicateB1 = 0;
                                    }


                                    if (txtBarcode2.Text != "")
                                    {
                                        SQL.AddParam("@productid", txtProductID.Text);
                                        SQL.AddParam("@barcode2", txtBarcode2.Text);
                                        checkerforduplicateB2 = int.Parse(SQL.ReturnResult("SELECT COUNT(*) FROM products WHERE(barcode1 = @barcode2 OR barcode2 = @barcode2) AND ProductID <> @productid"));

                                        if (SQL.HasException(true)) return;
                                    }
                                    else
                                    {
                                        checkerforduplicateB2 = 0;
                                    }

                                    //MessageBox.Show(checkerforduplicateB1 + " " + checkerforduplicateB2);

                                    if (result == "0" && checkerforduplicateB1 == 0 && checkerforduplicateB2 == 0)
                                    {
                                        if (Properties.Settings.Default.vatnonvat == true)
                                        {
                                            SQL.AddParam("@productID", txtProductID.Text);
                                            SQL.AddParam("@name", txtName.Text);
                                            SQL.AddParam("@description", txtDescription.Text);
                                            SQL.AddParam("@categoryID", cmbCategory.SelectedValue);
                                            SQL.AddParam("@rp_inclusive", txtRPInclusive.Text);
                                            SQL.AddParam("@wp_inclusive", txtWPInclusive.Text);
                                            SQL.AddParam("@barcode1", txtBarcode1.Text);
                                            SQL.AddParam("@barcode2", txtBarcode2.Text);
                                            SQL.AddParam("@warehouseID", cmbWarehouse.SelectedValue);
                                            SQL.AddParam("@s_discR", cbxDiscRegular.CheckState);
                                            SQL.AddParam("@s_discPWD_SC", cbxDiscPWD.CheckState);
                                            SQL.AddParam("@s_PWD_SC_perc", pwd_perc);
                                            SQL.AddParam("@s_discAth", cbxDiscAthlete.CheckState);
                                            SQL.AddParam("@s_ask_qty", cbxVatable.CheckState);
                                            SQL.AddParam("@is_vatable", cbxVatable.CheckState);
                                            SQL.AddParam("@cost", tbProductCost.Text);
                                            SQL.AddParam("@has_expiry", cbxHasExpiry.Checked);
                                            SQL.AddParam("@expiration_date", dtpExpiry.Value.ToShortDateString());

                                            SQL.Query(@"UPDATE products SET
                                   description = @description, name = @name, categoryID = @categoryID, rp_inclusive = @rp_inclusive,
                                   wp_inclusive = @wp_inclusive, barcode1 = @barcode1, barcode2 = @barcode2, warehouseID = @warehouseID, 
                                   s_discR = @s_discR, s_discPWD_SC = @s_discPWD_SC, s_PWD_SC_perc = @s_PWD_SC_perc,
                                   s_discAth = @s_discAth, s_ask_qty = @s_ask_qty,is_vatable=@is_vatable, cost = @cost, has_expiry=@has_expiry,expiration_date=@expiration_date
                                   WHERE productID = @productID");

                                            if (SQL.HasException(true))
                                                return;
                                        }
                                        else
                                        {
                                            SQL.AddParam("@productID", txtProductID.Text);
                                            SQL.AddParam("@name", txtName.Text);
                                            SQL.AddParam("@description", txtDescription.Text);
                                            SQL.AddParam("@categoryID", cmbCategory.SelectedValue);
                                            SQL.AddParam("@rp_inclusive", txtRPInclusive.Text);
                                            SQL.AddParam("@wp_inclusive", txtWPInclusive.Text);
                                            SQL.AddParam("@barcode1", txtBarcode1.Text);
                                            SQL.AddParam("@barcode2", txtBarcode2.Text);
                                            SQL.AddParam("@warehouseID", cmbWarehouse.SelectedValue);
                                            SQL.AddParam("@s_discR", cbxDiscRegular.CheckState);
                                            SQL.AddParam("@s_discPWD_SC", cbxDiscPWD.CheckState);
                                            SQL.AddParam("@s_PWD_SC_perc", pwd_perc);
                                            SQL.AddParam("@s_discAth", cbxDiscAthlete.CheckState);
                                            SQL.AddParam("@s_ask_qty", cbxVatable.CheckState);
                                            SQL.AddParam("@is_vatable", true);
                                            SQL.AddParam("@cost", tbProductCost.Text);
                                            SQL.AddParam("@has_expiry", cbxHasExpiry.Checked);
                                            SQL.AddParam("@expiration_date", dtpExpiry.Value.ToShortDateString());

                                            SQL.Query(@"UPDATE products SET
                                   description = @description, name = @name, categoryID = @categoryID, rp_inclusive = @rp_inclusive,
                                   wp_inclusive = @wp_inclusive, barcode1 = @barcode1, barcode2 = @barcode2, warehouseID = @warehouseID, 
                                   s_discR = @s_discR, s_discPWD_SC = @s_discPWD_SC, s_PWD_SC_perc = @s_PWD_SC_perc,
                                   s_discAth = @s_discAth, s_ask_qty = @s_ask_qty,is_vatable=@is_vatable, cost = @cost, has_expiry=@has_expiry,expiration_date=@expiration_date
                                   WHERE productID = @productID");

                                            if (SQL.HasException(true))
                                                return;
                                        }

                                        new Notification().PopUp("Item saved.", "", "success");

                                    }
                                    else
                                    {
                                        new Notification().PopUp("Duplicate name/barcode found.", "Save failed", "error");
                                        return;
                                    }

                                    break;
                                }
                        }

                        if (description != txtDescription.Text || name != txtName.Text)
                        {
                            ReloadProducts();
                            description = "";
                            name = "";
                        }
                        if (txtProductID.Text == "")
                        {
                            ReloadProducts();
                            description = "";
                            name = "";
                        }

                        btnProduct_New.PerformClick();

                        //GLOBAL VARIABLES LOAD
                        GlobalVariables.LoadPurchaseProducts();
                    }
                    else if (requiredFieldsMet == 1 && cmbWarehouse.Text == "")
                    {
                        new Notification().PopUp("Please add warehouse to proceed.", "Save failed", "error");
                    }
                    else
                    {
                        new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
                    }
                }));
            }).Start();
        }

        private void btnProduct_Delete_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    DialogResult approval = MessageBox.Show("Delete this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (approval == DialogResult.Yes)
                    {
                        if (txtProductID.Text == "")
                        {
                            new Notification().PopUp("No item selected.", "", "error");
                            return;
                        }

                        SQL.AddParam("@productID", txtProductID.Text);
                        SQL.Query("DELETE FROM products WHERE productID = @productID");

                        if (SQL.HasException(true))
                            return;

                        ReloadProducts();

                        ClearFields_Pr();

                        btnProduct_New.PerformClick();

                        new Notification().PopUp("Item deleted.", "", "information");
                    }
                }));
            }).Start();
        }

        private void cbxDiscPWD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDiscPWD.Checked == true)
            {
                GA.DoThis(ref allTxt, TableLayoutPanel8, ControlType.RadioButton, GroupAction.Action.Enable);
                rb5PWD.Checked = true;
            }
            else
            {
                GA.DoThis(ref allTxt, TableLayoutPanel8, ControlType.RadioButton, GroupAction.Action.Uncheck);
                GA.DoThis(ref allTxt, TableLayoutPanel8, ControlType.RadioButton, GroupAction.Action.Disable);
            }
        }

        private void btnSortProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.RowCount == 0)
                return;

            if (btnSortProduct.IconChar == IconChar.SortAlphaDown)
            {
                dgvProducts.Sort(dgvProducts.Columns[1], ListSortDirection.Ascending);
                btnSortProduct.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvProducts.Sort(dgvProducts.Columns[1], ListSortDirection.Descending);
                btnSortProduct.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void btnSortCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategory.RowCount == 0)
                return;

            if (btnSortCategory.IconChar == IconChar.SortAlphaDown)
            {
                dgvCategory.Sort(dgvCategory.Columns[1], ListSortDirection.Ascending);
                btnSortCategory.IconChar = IconChar.SortAlphaUp;
                return;
            }
            else
            {
                dgvCategory.Sort(dgvCategory.Columns[1], ListSortDirection.Descending);
                btnSortCategory.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void dgvCat_Category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@categoryID", dgvCat_Category.CurrentRow.Cells[0].Value.ToString());
            SQL.Query("Select * FROM product_category WHERE categoryID = @categoryID");
            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                txtCategoryID.Text = r["categoryID"].ToString();
                txtCategoryName.Text = r["name"].ToString();
                cbxCat_DiscRegular.Checked = Convert.ToBoolean(r["s_discR"].ToString());
                cbxCat_DiscPWD.Checked = Convert.ToBoolean(r["s_discPWD_SC"].ToString());
                cbxCat_DiscAthlete.Checked = Convert.ToBoolean(r["s_discAth"].ToString());
                cbxCat_AskQuantity.Checked = Convert.ToBoolean(r["s_ask_qty"].ToString());

                if (cbxCat_DiscPWD.Checked == true)
                {
                    if (r["s_PWD_SC_perc"].ToString() == "5.00")
                        rbCat_5PWD.Checked = true;
                    else
                        rbCat_20PWD.Checked = true;
                }
            }

            SQL.AddParam("@categoryID", dgvCat_Category.CurrentRow.Cells[0].Value.ToString());
            lblCat_ItemCount.Text = SQL.ReturnResult("SELECT COUNT(*) FROM products WHERE categoryID = @categoryID");
            if (SQL.HasException(true))
                return;
        }

        private void btnCat_New_Click(object sender, EventArgs e)
        {
            ClearFields_Cat();
        }

        private void cbxCat_DiscPWD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCat_DiscPWD.Checked == true)
            {
                GA.DoThis(ref allTxt, TableLayoutPanel5, ControlType.RadioButton, GroupAction.Action.Enable);
                rbCat_5PWD.Checked = true;
            }
            else
            {
                GA.DoThis(ref allTxt, TableLayoutPanel5, ControlType.RadioButton, GroupAction.Action.Uncheck);
                GA.DoThis(ref allTxt, TableLayoutPanel5, ControlType.RadioButton, GroupAction.Action.Disable);
            }
        }

        private void btnCat_Save_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    CategoryRF();

                    var requiredFieldsMet = RequireField(ref requiredFields);

                    if (requiredFieldsMet == 1)
                    {
                        string action = "Update";
                        decimal pwd_perc = 0;
                        decimal sc_perc = 0;

                        if (txtCategoryID.Text == "")
                            action = "New";


                        if (rbCat_5PWD.Checked)
                            pwd_perc = 5;
                        else if (rbCat_20PWD.Checked)
                            pwd_perc = 20;


                        switch (action)
                        {
                            case "New":
                                {
                                    // check for duplicate names
                                    SQL.AddParam("@name", txtCategoryName.Text);
                                    int result = Convert.ToInt32(SQL.ReturnResult("Select IIF((Select COUNT(*) FROM product_category WHERE name = @name) > 0,'1', '0') as result"));

                                    if (SQL.HasException(true))
                                        return;

                                    if (result == 0)
                                    {
                                        SQL.AddParam("@name", txtCategoryName.Text);
                                        SQL.AddParam("@s_discR", cbxCat_DiscRegular.CheckState);
                                        SQL.AddParam("@s_discPWD_SC", cbxCat_DiscPWD.CheckState);
                                        SQL.AddParam("@s_PWD_SC_perc", pwd_perc);
                                        SQL.AddParam("@s_discAth", cbxCat_DiscAthlete.CheckState);
                                        SQL.AddParam("@s_ask_qty", cbxCat_AskQuantity.CheckState);

                                        SQL.Query(@"INSERT INTO product_category
                                   (name, s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty)
                                   VALUES
                                   (@name, @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty)
                                  ");

                                        if (SQL.HasException(true))
                                            return;
                                        ClearFields_Cat();
                                        new Notification().PopUp("Item saved.", "", "success");
                                    }
                                    else
                                        new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                                    break;
                                }

                            default:
                                {

                                    // check for duplicate names other than itself
                                    SQL.AddParam("@categoryID", txtCategoryID.Text);
                                    SQL.AddParam("@name", txtCategoryName.Text);

                                    string result = SQL.ReturnResult(@"SELECT IIF((
                SELECT COUNT(*) as duplicatecount FROM product_category WHERE name = @name AND categoryID <> @categoryID) > 0,
                1, 0) as result");

                                    if (SQL.HasException(true))
                                        return;

                                    if (result == "0")
                                    {
                                        SQL.AddParam("@categoryID", txtCategoryID.Text);
                                        SQL.AddParam("@name", txtCategoryName.Text);
                                        SQL.AddParam("@s_discR", cbxCat_DiscRegular.CheckState);
                                        SQL.AddParam("@s_discPWD_SC", cbxCat_DiscPWD.CheckState);
                                        SQL.AddParam("@s_PWD_SC_perc", pwd_perc);
                                        SQL.AddParam("@s_discAth", cbxCat_DiscAthlete.CheckState);
                                        SQL.AddParam("@s_ask_qty", cbxCat_AskQuantity.CheckState);

                                        SQL.Query(@"UPDATE product_category SET
                                   name = @name, s_discR = @s_discR, s_discPWD_SC = @s_discPWD_SC, s_PWD_SC_perc = @s_PWD_SC_perc,
                                   s_discAth = @s_discAth, s_ask_qty = @s_ask_qty
                                   WHERE categoryID = @categoryID
                                  ");

                                        if (SQL.HasException(true))
                                            return;
                                        new Notification().PopUp("Item saved.", "", "success");
                                    }
                                    else
                                        new Notification().PopUp("Duplicate name found.", "", "error");

                                    if (Convert.ToInt32(lblCat_ItemCount.Text) > 0)
                                    {

                                        // update items in this category
                                        SQL.AddParam("@categoryID", txtCategoryID.Text);
                                        SQL.AddParam("@s_discR", cbxCat_DiscRegular.CheckState);

                                        SQL.Query(@"UPDATE products SET s_discR = @s_discR
                                        WHERE categoryID = @categoryID");
                                        if (SQL.HasException(true))
                                        {
                                            MessageBox.Show("Update Products 1");
                                        }

                                        SQL.AddParam("@categoryID", txtCategoryID.Text);
                                        SQL.AddParam("@s_discPWD_SC", cbxCat_DiscPWD.CheckState);
                                        SQL.AddParam("@s_PWD_SC_perc", pwd_perc);
                                        SQL.AddParam("@s_discAth", cbxCat_DiscAthlete.CheckState);
                                        SQL.AddParam("@s_ask_qty", cbxCat_AskQuantity.CheckState);

                                        SQL.Query(@"UPDATE products SET 
                                        s_discPWD_SC = @s_discPWD_SC, s_PWD_SC_perc = @s_PWD_SC_perc,
                                        s_discAth = @s_discAth, s_ask_qty = @s_ask_qty
                                        WHERE categoryID = @categoryID AND is_vatable='True'");

                                        if (SQL.HasException(true))
                                        {
                                            MessageBox.Show("Update Products 2");
                                        }
                                        new Notification().PopUp("Item saved.", "", "success");
                                    }

                                    break;
                                }
                        }
                        loadCat_Category();
                        LoadCategory();
                        OL.ComboValues(cmbCategory, "categoryID", "name", "product_category");
                    }
                    else
                        new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
                }));
            }).Start();
        }

        private void btnCat_Delete_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    DialogResult approval = MessageBox.Show("Deleting this category will delete the " + lblCat_ItemCount.Text + " items in it. Continue?", "Delete category", MessageBoxButtons.YesNo);

                    if ((approval == DialogResult.Yes))
                    {
                        if (txtCategoryID.Text == "")
                        {
                            new Notification().PopUp("No item selected.", "", "error");
                            return;
                        }

                        SQL.AddParam("@categoryID", txtCategoryID.Text);
                        SQL.Query("DELETE FROM product_category WHERE categoryID = @categoryID");

                        if (SQL.HasException(true))
                            return;

                        loadCat_Category();
                        LoadCategory();
                        ReloadProducts();
                        OL.ComboValues(cmbCategory, "categoryID", "name", "product_category");

                        ClearFields_Cat();

                        new Notification().PopUp("Item deleted.", "", "information");
                    }
                }));
            }).Start();
        }

        private void btnCat_Sort_Click(object sender, EventArgs e)
        {
            if (dgvCat_Category.RowCount == 0)
                return;

            if (btnCat_Sort.IconChar == IconChar.SortAlphaDown)
            {
                dgvCat_Category.Sort(dgvCat_Category.Columns[1], ListSortDirection.Ascending);
                btnCat_Sort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvCat_Category.Sort(dgvCat_Category.Columns[1], ListSortDirection.Descending);
                btnCat_Sort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void txtSearchCategory_KeyUp(object sender, KeyEventArgs e)
        {
            SQLControl psql = new SQLControl();
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    if (txtSearchCategory.Text == "")
                    {
                        //SQL.Query(@"SELECT catID, catName FROM
                        //   (
                        //   SELECT 0 as catID, 'All Categories' as catName
                        //   UNION ALL 
                        //   SELECT categoryID as catID, name as catName FROM product_category 
                        //   ) x ORDER BY 
                        //   CASE WHEN catName = 'All Categories' then 1
                        //   ELSE 5
                        //   END,
                        //   catname ASC");

                        psql.Query("Select categoryID as catID, Name FROM product_category ORDER BY name ASC");

                        if (psql.HasException(true))
                            return;
                    }
                    else
                    {
                        psql.AddParam("@find", txtSearchCategory.Text + "%");

                        psql.Query("Select categoryID, Name FROM product_category WHERE name Like @find ORDER BY name ASC");
                        if (psql.HasException(true))
                            return;
                    }

                    dgvCategory.DataSource = psql.DBDT;
                    dgvCategory.Columns[0].Visible = false;
                }));
            }).Start();
        }

        private void txtSearchProduct_KeyUp(object sender, KeyEventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    if (txtSearchProduct.Text != "")
                    {
                        SQL.AddParam("@find", txtSearchProduct.Text + "%");

                        SQL.Query(@"SELECT productID, description, Name FROM products WHERE name LIKE @find OR description LIKE @find 
                       OR barcode1 LIKE @find OR barcode2 LIKE @find ORDER BY description ASC");
                        if (SQL.HasException(true))
                            return;

                        dgvProducts.DataSource = SQL.DBDT;
                        dgvProducts.Columns[0].Visible = false;
                    }
                    else ReloadProducts();
                }));
            }).Start();
        }

        private void txtRPInclusive_Enter(object sender, EventArgs e)
        {
            if (txtRPInclusive.Text == "0.00")
            {
                txtRPInclusive.Clear();
                txtRPInclusive.Focus();
            }

        }

        private void txtWPInclusive_Enter(object sender, EventArgs e)
        {
            if (txtWPInclusive.Text == "0.00")
            {
                txtWPInclusive.Clear();
                txtWPInclusive.Focus();
            }
        }

        private void txtRPInclusive_Leave(object sender, EventArgs e)
        {
            if (txtRPInclusive.Text == "")
            {
                txtRPInclusive.Text = "0.00";
            }
        }

        private void txtWPInclusive_Leave(object sender, EventArgs e)
        {
            if (txtWPInclusive.Text == "")
            {
                txtWPInclusive.Text = "0.00";
            }
        }

        private void txtProductStock_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "0";
            }
        }

        private void txtProductStock_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "0")
            {
                (sender as TextBox).Text = "";
            }
        }

        private void CbxHasExpiry_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxHasExpiry.Checked == true)
            {
                dtpExpiry.Enabled = true;
            }
            else
            {
                dtpExpiry.Enabled = false;
            }
        }

        private void BtnExpirationDate_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlExpiration, ref currentPanel, btnExpirationDate, ref currentButton);

            LoadExpirationCategory();

            LoadExpirationDate();

        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //new Thread(() =>
            //{
            //    Invoke(new MethodInvoker(delegate ()
            //    {
            //        if (txtSearch.Text != "")
            //        {
            //            SQL.AddParam("@find", txtSearch.Text + "%");
            //            SQL.Query(@"select products.description as 'Description',products.name as 'Product Name',product_category.name as 'Category Name',
            //                        products.expiration_date as 'Expiry Date' from products JOIN product_category ON products.categoryID = product_category.categoryID 
            //                        AND products.has_expiry  = 'true' AND products.barcode1 LIKE @find OR products.barcode2 LIKE @find OR products.description LIKE @find OR products.name LIKE @find 
            //                        ORDER BY products.expiration_date asc");

            //            if (SQL.HasException(true))
            //                return;

            //            dgvExpirationDate.DataSource = SQL.DBDT;
            //        }
            //        else LoadExpirationDate();
            //    }));
            //}).Start();
        }

        private void CmbECategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    cat_query = "products.categoryID NOT IN (0)";

                    if (cmbECategory.SelectedIndex != 0)
                    {
                        cat_query = "products.categoryID = " + cmbECategory.SelectedValue;
                    }


                    SQLControl psql = new SQLControl();

                    psql.Query("select products.barcode1 as 'Barcode1',products.barcode2 as 'Barcode2',products.description as 'Description',products.name as 'ProductName',product_category.name as 'CategoryName',products.expiration_date as 'Expiry Date' from products JOIN product_category ON products.categoryID = product_category.categoryID and products.has_expiry = 'true' AND " + cat_query + " ORDER BY products.expiration_date asc");
                    if (psql.HasException(true)) return;

                    dgvExpirationDate.DataSource = psql.DBDT;

                    dgvExpirationDate.Columns[0].Visible = false;
                    dgvExpirationDate.Columns[1].Visible = false;


                    foreach (DataGridViewRow row in dgvExpirationDate.Rows)
                    {
                        var now = DateTime.Now;
                        var expirationDate = DateTime.Parse(row.Cells[5].Value.ToString());
                        var sevenDayBefore = expirationDate.AddDays(-7);

                        if (now >= sevenDayBefore && now < expirationDate)
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else if (now >= expirationDate)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }

                    dgvExpirationDate.ClearSelection();
                }));
            }).Start();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == "Search description, Name or Barcode")
                {
                    LoadExpirationDate();
                    return;
                }

                (dgvExpirationDate.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("Barcode1 LIKE '{0}%' OR Barcode2 LIKE '{0}%' OR Description LIKE '{0}%' OR ProductName LIKE '{0}%'", txtSearch.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search description, Name or Barcode")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search description, Name or Barcode";
                txtSearch.ForeColor = Color.Black;
            }
        }
        ExportImport EI = new ExportImport();
        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvExpirationDate.RowCount == 0)
                return;

            EI.ExportDgvToPDF("Products with Expiry Dates", dgvExpirationDate);
        }

        private void BtnESearchByDate_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    cat_query = "products.categoryID NOT IN (0)";

                    if (cmbECategory.SelectedIndex != 0)
                    {
                        cat_query = "products.categoryID = " + cmbECategory.SelectedValue;
                    }


                    SQLControl psql = new SQLControl();

                    psql.AddParam("@from", dtpFrom.Value);
                    psql.AddParam("@to", dtpTo.Value);
                    psql.Query("select products.barcode1 as 'Barcode1',products.barcode2 as 'Barcode2',products.description as 'Description',products.name as 'ProductName',product_category.name as 'CategoryName',products.expiration_date as 'Expiry Date' from products JOIN product_category ON products.categoryID = product_category.categoryID and products.has_expiry = 'true' AND " + cat_query + " AND products.expiration_date BETWEEN @from AND @to ORDER BY products.expiration_date asc");
                    if (psql.HasException(true)) return;

                    dgvExpirationDate.DataSource = psql.DBDT;

                    dgvExpirationDate.Columns[0].Visible = false;
                    dgvExpirationDate.Columns[1].Visible = false;


                    foreach (DataGridViewRow row in dgvExpirationDate.Rows)
                    {
                        var now = DateTime.Now;
                        var expirationDate = DateTime.Parse(row.Cells[5].Value.ToString());
                        var sevenDayBefore = expirationDate.AddDays(-7);

                        if (now >= sevenDayBefore && now < expirationDate)
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else if (now >= expirationDate)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }

                    dgvExpirationDate.ClearSelection();
                }));
            }).Start();
        }

        private void BtnEShowAll_Click(object sender, EventArgs e)
        {
            LoadExpirationCategory();
            LoadExpirationDate();
        }

        private void txtProductStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnProduct_Save.PerformClick();
            }
        }

        private void CbxVatable_CheckedChanged(object sender, EventArgs e)
        {
            //if(Properties.Settings.Default.vatnonvat == true)
            //{
            //    if (cbxVatable.Checked == false)
            //    {
            //        cbxDiscPWD.Checked = false;
            //        cbxDiscPWD.Enabled = false;

            //        cbxDiscAthlete.Checked = false;
            //        cbxDiscAthlete.Enabled = false;
            //    }
            //    else
            //    {
            //        cbxDiscPWD.Enabled = true;
            //        cbxDiscAthlete.Enabled = true;
            //    }
            //}
        }

        private void txtCat_SearchCategory_KeyUp(object sender, KeyEventArgs e)
        {
            SQL.AddParam("@find", txtCat_SearchCategory.Text + "%");

            SQL.Query("SELECT categoryID, name FROM product_category WHERE name LIKE @find ORDER BY name ASC");

            if (SQL.HasException(true))
                return;

            dgvCat_Category.DataSource = SQL.DBDT;

            dgvCat_Category.Columns[0].Visible = false;
        }
    }
}