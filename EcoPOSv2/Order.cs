using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoPOSControl;

namespace EcoPOSv2
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();

        private RolePermission RP = new RolePermission();

        public bool apply_regular_discount_fix_amt = false;
        public bool apply_special_discount = false;
        public bool apply_member = false;
        public decimal regular_disc_amt;

        public bool is_refund = false;
        public bool is_return = false;
        //METHODS
        public void LoadOrder()
        {
            SQL.Query(@"SELECT [itemID] as 'ID'
                       ,[productID] 
                       ,[description] as 'Description'
                       ,[name] as 'Name'
                       ,[type] as 'Type'
                       ,[static_price_exclusive] 
                       ,[static_price_vat]
                       ,CONVERT(DECIMAL(18,2),[static_price_inclusive]) as 'Price'
                       ,[selling_price_exclusive]
                       ,[selling_price_vat]
                       ,CONVERT(DECIMAL(18,2),[selling_price_inclusive]) as 'Total'
                       ,[quantity] as 'Qty'
                       ,CONVERT(DECIMAL(18,2),[discount]) as 'Disc'
                        FROM order_cart");

            if (SQL.HasException(true))
                return;

            dgvCart.DataSource = SQL.DBDT;
            dgvCart.Columns[1].Visible = false;
            dgvCart.Columns[5].Visible = false;
            dgvCart.Columns[6].Visible = false;
            dgvCart.Columns[8].Visible = false;
            dgvCart.Columns[9].Visible = false;
            dgvCart.Columns[12].Visible = false;

            dgvCart.Columns[0].Width = 120;
            dgvCart.Columns[2].Width = 200;
            dgvCart.Columns[3].Width = 200;
            dgvCart.Columns[4].Width = 60;
        }
        public void LoadOrderNo()
        {
            lblOrderNumber.Text = SQL.ReturnResult("SELECT order_no FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)");
            if (SQL.HasException(true))return;
        }
        public void GetTotal()
        {
            int count = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM order_cart) > 0, 1, 0)"));

            if (SQL.HasException(true))
                return;

            SQL.AddParam("@count", count);
            SQL.Query(@"SELECT IIF(@count > 0, SUM(quantity), 0.00) as 'Qty',
                              IIF(@count > 0, SUM(static_price_inclusive * quantity), 0.00) as 'Subtotal',
		                      IIF(@count > 0, SUM(discount), 0.00) as 'Discount', 
		                      IIF(@count > 0, SUM(selling_price_inclusive), 0.00) as 'Total',
	                          IIF(@count > 0, SUM(selling_price_exclusive), 0.00) as 'Vatable', 
		                      IIF(@count > 0, SUM(selling_price_vat), 0.00) as 'VAT',
                              IIF(@count > 0, SUM(less_vat), 0.00) as 'LessVAT'
		              FROM order_cart");

            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {



                // check if discount > 1300

                decimal discount;
                int check_if_PWDSC = Convert.ToInt32(SQL.ReturnResult("SELECT cus_type FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)"));
                if (SQL.HasException(true))
                    return;

                discount = Convert.ToDecimal(r["Discount"].ToString());
                if ( Convert.ToInt32(r["Discount"].ToString()) > 1300 & (check_if_PWDSC == 1 | check_if_PWDSC == 2))
                    discount = 1300;


                lblItems.Text = String.Format(r["Qty"].ToString(),"#,##0.00");
                lblSubtotal.Text = String.Format(r["Subtotal"].ToString(), "#,##0.00");
                lblDiscount.Text = discount.ToString();
                lblTotal.Text = String.Format(r["Total"].ToString(), "#,##0.00");
                lblVAT.Text = String.Format(r["VAT"].ToString(), "#,##0.00");
                lblLessVAT.Text = String.Format(r["LessVAT"].ToString(), "#,##0.00");
            }

            lblVATSale.Text = String.Format(Convert.ToDecimal(SQL.ReturnResult(@"SELECT IIF((SELECT COUNT(*) FROM order_cart WHERE is_vat_exempt = 0) > 0,
                                        (SELECT CONVERT(DECIMAL(18,2),SUM(selling_price_exclusive)) FROM order_cart WHERE is_vat_exempt = 0),
                                        0)")).ToString(), "#,##0.00");
            if (SQL.HasException(true))
                return;

            lblVATExempt.Text = String.Format(Convert.ToDecimal(SQL.ReturnResult(@"SELECT IIF((SELECT COUNT(*) FROM order_cart WHERE is_vat_exempt = 1) > 0,
                                        (SELECT CONVERT(DECIMAL(18,2),SUM(selling_price_exclusive)) FROM order_cart WHERE is_vat_exempt = 1),
                                        0)")).ToString(), "#,##0.00");
            if (SQL.HasException(true))
                return;



            if (apply_regular_discount_fix_amt)
            {
                decimal total = 0;
                decimal vat_sale = 0;
                decimal vat = 0;

                total = (decimal)double.Parse(lblTotal.Text, CultureInfo.CreateSpecificCulture("en-US"));
                vat_sale = (decimal)double.Parse(lblVATSale.Text, CultureInfo.CreateSpecificCulture("en-US"));
                vat = (decimal)double.Parse(lblVAT.Text, CultureInfo.CreateSpecificCulture("en-US"));

                lblDiscount.Text = regular_disc_amt.ToString();
                lblTotal.Text = String.Format((total - regular_disc_amt).ToString(), "#,##0.00");
                lblVAT.Text = string.Format(vat - regular_disc_amt - (regular_disc_amt / 1.12M).ToString(), "#,##0.00");
                lblVATSale.Text = String.Format((vat_sale - (regular_disc_amt / 1.12))).ToString(), "#,##0.00");
            }
        }

        //METHODS

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
                return;

            int action = Convert.ToInt32(SQL.ReturnResult("SELECT action FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)"));

            string customerID = SQL.ReturnResult("SELECT cus_ID_No FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)");
            if (SQL.HasException(true)) return;


            SQL.AddParam("@customerID", customerID);
            decimal card_balance = Convert.ToDecimal(SQL.ReturnResult("SELECT IIF(@customerID <> 0, (SELECT card_balance FROM member_card WHERE customerID = @customerID), 0.00)"));
            if (SQL.HasException(true)) return;

            Payment frmPayment = new Payment();
            RP.Payment(frmPayment);
            frmPayment.frmOrder = this;
            frmPayment.lblCustomerID.Text = customerID;
            frmPayment.cbxUsePoints.Text = (card_balance, "#,##0.00");
            frmPayment.card_balance = card_balance;
            frmPayment.lblTotal.Text = lblTotal.Text;
            frmPayment.lblGrandTotal.Text = lblTotal.Text;
            frmPayment.grand_total = double.Parse(lblTotal.Text, CultureInfo.CreateSpecificCulture("en-US"));
            frmPayment.total = double.Parse(lblTotal.Text, CultureInfo.CreateSpecificCulture("en-US"));
            frmPayment.action = action;


            if (action == 1)
            {
                frmPayment.change = System.Convert.ToDecimal("-" + lblTotal.Text);
                frmPayment.lblChange.Text = "-" + lblTotal.Text;
            }
            else if (action == 2)
            {
                frmPayment.change = 0;
                frmPayment.lblChange.Text = "0";


                frmPayment.txtAmount.Enabled = false;
                frmPayment.btn0.Enabled = false;
                frmPayment.btn1.Enabled = false;
                frmPayment.btn2.Enabled = false;
                frmPayment.btn3.Enabled = false;
                frmPayment.btn4.Enabled = false;
                frmPayment.btn5.Enabled = false;
                frmPayment.btn6.Enabled = false;
                frmPayment.btn7.Enabled = false;
                frmPayment.btn8.Enabled = false;
                frmPayment.btn9.Enabled = false;
                frmPayment.btnDot.Enabled = false;
                frmPayment.btnExact.Enabled = false;
                frmPayment.btnGC.Enabled = false;
                frmPayment.btnRemoveGC.Enabled = false;
                frmPayment.cbxUsePoints.Enabled = false;
                frmPayment.cmbMethod.Enabled = false;
            }
            else if (action == 3)
            {
                if (System.Convert.ToDecimal(lblTotal.Text) > 0)
                {
                    Notification.PopUp("Error", "Exchange item cannot be higher than return item.");
                    return;
                }

                frmPayment.change = System.Convert.ToDecimal(lblTotal.Text);
                frmPayment.lblChange.Text = lblTotal.Text;


                frmPayment.txtAmount.Enabled = false;
                frmPayment.btn0.Enabled = false;
                frmPayment.btn1.Enabled = false;
                frmPayment.btn2.Enabled = false;
                frmPayment.btn3.Enabled = false;
                frmPayment.btn4.Enabled = false;
                frmPayment.btn5.Enabled = false;
                frmPayment.btn6.Enabled = false;
                frmPayment.btn7.Enabled = false;
                frmPayment.btn8.Enabled = false;
                frmPayment.btn9.Enabled = false;
                frmPayment.btnDot.Enabled = false;
                frmPayment.btnExact.Enabled = false;
                frmPayment.btnGC.Enabled = false;
                frmPayment.btnRemoveGC.Enabled = false;
                frmPayment.cbxUsePoints.Enabled = false;
                frmPayment.cmbMethod.Enabled = false;
            }
            frmPayment.Show(this);
        }

        private void tbBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            string insert_type_query = " rp_exclusive, rp_tax, rp_inclusive";
            string type = "R";

            if (rbWholesale.Checked)
            {
                type = "W";
                insert_type_query = "wp_exclusive, wp_tax, wp_inclusive";
            }


            if (e.KeyCode == Keys.Enter)
            {
                if (tbBarcode.Text == "")
                    return;


                SQL.AddParam("@barcode", tbBarcode.Text);
                int check_product = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM products WHERE barcode1 = @barcode OR barcode2 = @barcode"));
                if (SQL.HasException(true))
                    return;

                SQL.AddParam("@barcode", tbBarcode.Text);
                SQL.AddParam("@type", type);
                int check_in_cart = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM order_cart WHERE productID = (SELECT productID FROM products WHERE (barcode1 = @barcode OR barcode2 = @barcode) AND type = @type AND is_return = 0)"));
                if (SQL.HasException(true))
                    return;


                if (check_product == 1)
                {
                    SQL.AddParam("@barcode", tbBarcode.Text);
                    string productID = SQL.ReturnResult("SELECT productID FROM products WHERE barcode1 = @barcode OR barcode2 = @barcode");
                    if (SQL.HasException(true))
                        return;

                    if (check_in_cart == 0)
                    {
                        SQL.AddParam("@type", type);
                        SQL.AddParam("@productID", Convert.ToInt32(productID));

                        SQL.Query(@"INSERT INTO order_cart (productID , description, name, type, static_price_exclusive, static_price_vat, static_price_inclusive, quantity, discount) 
                                   SELECT productID, description, name, @type," + insert_type_query + ", 1, 0 FROM products WHERE productID = @productID");

                        if (SQL.HasException(true))
                            return;
                    }
                    else
                    {
                        SQL.AddParam("@barcode", tbBarcode.Text);
                        SQL.AddParam("@productID", productID);
                        SQL.AddParam("@type", type);

                        SQL.Query("UPDATE order_cart SET quantity = quantity + 1 WHERE productID = @productID AND type = @type AND is_return = 0");
                        if (SQL.HasException(true))
                            return;
                    }

                    LoadOrder();
                    GetTotal();
                    txtBarcode.Clear();
                    txtBarcode.Focus();
                }
                else
                {
                    MessageBox.Show("No item found!", "Barcode not registered.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
