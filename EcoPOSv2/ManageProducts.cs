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
        //METHODS
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
            SQL.Query("SELECT productID, description, name FROM products ORDER BY description ASC");
            if (SQL.HasException(true))
                return;

            dgvProducts.DataSource = SQL.DBDT;
            dgvProducts.Columns[0].Visible = false;
            dgvProducts.Columns[1].Width = 300;
            
        }
        private void ReloadProducts()
        {
            if ((dgvCategory.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0))
            {
                if (Convert.ToInt32(dgvCategory.CurrentRow.Cells[0].Value.ToString()) != 0)
                {
                    SQL.AddParam("@categoryID", (dgvCategory.CurrentRow.Cells[0].Value.ToString()));

                    SQL.Query("SELECT productID, description, name FROM products WHERE categoryID = @categoryID ORDER BY description ASC");
                    if (SQL.HasException(true))
                        return;

                    dgvProducts.DataSource = SQL.DBDT;
                    dgvProducts.Columns[0].Visible = false;
                    dgvProducts.Columns[1].Width = 300;

                    return;
                }
            }

            SQL.Query("SELECT productID, description, name FROM products ORDER BY description ASC");
            if (SQL.HasException(true))
                return;

            dgvProducts.DataSource = SQL.DBDT;
            dgvProducts.Columns[0].Visible = false;
            dgvProducts.Columns[1].Width = 300;
        }
        private void LoadCategory()
        {
            SQL.Query(@"SELECT catID, catName FROM
                       (
                       SELECT 0 as catID, 'All Categories' as catName
                       UNION ALL 
                       SELECT categoryID as catID, name as catName FROM product_category 
                       ) x ORDER BY 
                       CASE WHEN catName = 'All Categories' then 1
                       ELSE 5
                       END,
                       catname ASC");
            if (SQL.HasException(true))
                return;

            dgvCategory.DataSource = SQL.DBDT;
            dgvCategory.Columns[0].Visible = false;
        }
        private void TextValidation()
        {
            AssignValidation(ref txtRPInclusive, ValidationType.Price);
            AssignValidation(ref txtRPInclusive, ValidationType.Only_Numbers);
            AssignValidation(ref txtWPInclusive, ValidationType.Price);
            AssignValidation(ref txtWPInclusive, ValidationType.Only_Numbers);
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
            loadCat_Category();
            OL.ComboValues(cmbCategory, "categoryID", "name", "product_category");
            OL.ComboValues(cmbWarehouse, "warehouseID", "name", "warehouse");
            LoadProducts();
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
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@productID", dgvProducts.CurrentRow.Cells[0].Value.ToString());

            SQL.Query("SELECT * FROM products WHERE productID = @productID");
            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
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
                cbxAskQuantity.Checked = Convert.ToBoolean(r["s_ask_qty"].ToString());

                if (cbxDiscPWD.Checked == true)
                {
                    if (decimal.Parse(r["s_PWD_SC_perc"].ToString()) == 5)
                        rb5PWD.Checked = true;
                    else
                        rb20PWD.Checked = true;
                }
            }
        }

        private void btnProduct_New_Click(object sender, EventArgs e)
        {
            ClearFields_Pr();

            this.ActiveControl = txtDescription;
        }

        private void btnProduct_Save_Click(object sender, EventArgs e)
        {
            ProductsRF();
            int requiredFieldsMet = RequireField(ref requiredFields);

            if (requiredFieldsMet == 1) 
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
                            // check for duplicate names
                            SQL.AddParam("@name", txtName.Text);
                            int result = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM products WHERE name = @name) > 0,'1', '0') as result"));

                            if (SQL.HasException(true))
                                return;

                            if (result == 0)
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
                                SQL.AddParam("@s_ask_qty", cbxAskQuantity.CheckState);

                                SQL.Query(@"INSERT INTO products
                                   (description, name, categoryID, rp_inclusive, wp_inclusive, barcode1, barcode2, warehouseID, 
                                    s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty)
                                   VALUES
                                   (@description, @name, @categoryID, @rp_inclusive, @wp_inclusive, @barcode1, @barcode2, @warehouseID, 
                                    @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty)");

                                if (SQL.HasException(true))
                                    return;

                                // create inventory

                                SQL.Query("INSERT INTO inventory (productID, stock_qty) VALUES ((SELECT MAX(productID) FROM products), 0)");

                                if (SQL.HasException(true))
                                    return;

                                ClearFields_Pr();
                                new Notification().PopUp("Item saved.", "", "success");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }

                    default:
                        {

                            // check for duplicate names other than itself
                            SQL.AddParam("@productID", txtProductID.Text);
                            SQL.AddParam("@name", txtName.Text);

                            string result = SQL.ReturnResult(@"SELECT IIF((
                SELECT COUNT(*) as duplicatecount FROM products WHERE name = @name AND productID <> @productID) > 0,
                1, 0) as result");

                            if (SQL.HasException(true))
                                return;

                            if (result == "0")
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
                                SQL.AddParam("@s_ask_qty", cbxAskQuantity.CheckState);

                                SQL.Query(@"UPDATE products SET
                                   description = @description, name = @name, categoryID = @categoryID, rp_inclusive = @rp_inclusive,
                                   wp_inclusive = @wp_inclusive, barcode1 = @barcode1, barcode2 = @barcode2, warehouseID = @warehouseID, 
                                   s_discR = @s_discR, s_discPWD_SC = @s_discPWD_SC, s_PWD_SC_perc = @s_PWD_SC_perc,
                                   s_discAth = @s_discAth, s_ask_qty = @s_ask_qty
                                   WHERE productID = @productID");

                                if (SQL.HasException(true))
                                    return;
                                new Notification().PopUp("Item saved.", "","success");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }
                }

                ReloadProducts();
            }
            else if(requiredFieldsMet == 1 && cmbWarehouse.Text == "")
            {
                new Notification().PopUp("Please add warehouse to proceed.", "Save failed", "error");
            }
            else
                new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
        }

        private void btnProduct_Delete_Click(object sender, EventArgs e)
        {
            DialogResult approval = MessageBox.Show("Delete this item?", "", MessageBoxButtons.YesNo);

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

                new Notification().PopUp("Item deleted.", "", "information");
            }
        }

        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchCategory.Text == "")
            {
                SQL.Query(@"SELECT catID, catName FROM
                           (
                           SELECT 0 as catID, 'All Categories' as catName
                           UNION ALL 
                           SELECT categoryID as catID, name as catName FROM product_category 
                           ) x ORDER BY 
                           CASE WHEN catName = 'All Categories' then 1
                           ELSE 5
                           END,
                           catname ASC");
                if (SQL.HasException(true))
                    return;
            }
            else
            {
                SQL.AddParam("@find", txtSearchCategory.Text + "%");

                SQL.Query("Select categoryID, Name FROM product_category WHERE name Like @find ORDER BY name ASC");
                if (SQL.HasException(true))
                    return;
            }

            dgvCategory.DataSource = SQL.DBDT;
            dgvCategory.Columns[0].Visible = false;
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            SQL.AddParam("@find", txtSearchProduct.Text + "%");

            SQL.Query(@"SELECT productID, description, Name FROM products WHERE name LIKE @find OR description LIKE @find 
                       OR barcode1 LIKE @find OR barcode2 LIKE @find ORDER BY description ASC");
            if (SQL.HasException(true))
                return;

            dgvProducts.DataSource = SQL.DBDT;
            dgvProducts.Columns[0].Visible = false;
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
                    if (r["s_PWD_SC_perc"].ToString() == "5")
                        rb5PWD.Checked = true;
                    else
                        rb20PWD.Checked = true;
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
                                new Notification().PopUp("Item saved.","","success");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.","","error");

                            if (Convert.ToInt32(lblCat_ItemCount.Text) > 0)
                            {

                                // update items in this category

                                SQL.AddParam("@categoryID", txtCategoryID.Text);
                                SQL.AddParam("@s_discR", cbxCat_DiscRegular.CheckState);
                                SQL.AddParam("@s_discPWD_SC", cbxCat_DiscPWD.CheckState);
                                SQL.AddParam("@s_PWD_SC_perc", pwd_perc);
                                SQL.AddParam("@s_discAth", cbxCat_DiscAthlete.CheckState);
                                SQL.AddParam("@s_ask_qty", cbxCat_AskQuantity.CheckState);

                                SQL.Query(@"UPDATE products SET 
                           s_discR = @s_discR, s_discPWD_SC = @s_discPWD_SC, s_PWD_SC_perc = @s_PWD_SC_perc,
                           s_discAth = @s_discAth, s_ask_qty = @s_ask_qty
                           WHERE categoryID = @categoryID");

                                if (SQL.HasException(true))
                                    return;
                                new Notification().PopUp("Item saved.","","success");
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
        }

        private void btnCat_Delete_Click(object sender, EventArgs e)
        {
            DialogResult approval = MessageBox.Show("Deleting this category will delete the " + lblCat_ItemCount.Text + " items in it. Continue?", "Delete category", MessageBoxButtons.YesNo);

            if ((approval == DialogResult.Yes))
            {
                if (txtCategoryID.Text == "")
                {
                    new Notification().PopUp("No item selected.","","error");
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

                new  Notification().PopUp("Item deleted.", "", "information");
            }
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
