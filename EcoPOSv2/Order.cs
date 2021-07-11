using Guna.UI2.WinForms;
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
using VeryHotKeys.WinForms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace EcoPOSv2
{
    public partial class Order : GlobalHotKeyForm
    {
        public static Order _order;
        public static Order Instance
        {
            get
            {
                if (_order == null)
                {
                    _order = new Order();
                }
                return _order;
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public const byte KEYEVENTF_KEYUP = 0x02;
        public const int VK_CONTROL = 0x11;

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


        public bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }
        public Order()
        {
            InitializeComponent();
            AddHotKeyRegisterer(ClickCustomer, HotKeyMods.Control, ConsoleKey.C);
            AddHotKeyRegisterer(OpenPayment, HotKeyMods.Control, ConsoleKey.P);
            AddHotKeyRegisterer(OpenDiscount, HotKeyMods.Control, ConsoleKey.D);
            AddHotKeyRegisterer(Openquantity, HotKeyMods.Control, ConsoleKey.Q);
            AddHotKeyRegisterer(OpenVoidItem, HotKeyMods.Control, ConsoleKey.V);
            AddHotKeyRegisterer(ClickCancelTransaction, HotKeyMods.None, ConsoleKey.F4);
            AddHotKeyRegisterer(AccessUserByPass, HotKeyMods.Control, ConsoleKey.G);
            AddHotKeyRegisterer(CancelUserByPass, HotKeyMods.Control, ConsoleKey.F);
        }

        SQLControl SQL = new SQLControl();

        private RolePermission RP = new RolePermission();

        public bool apply_regular_discount_fix_amt = false;
        public bool apply_special_discount = false;
        public bool apply_member = false;
        public decimal regular_disc_amt;

        public bool is_refund = false;
        public bool is_return = false;

        string type, insert_type_query;
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
            dgvCart.Columns[0].Visible = false;
            dgvCart.Columns[1].Visible = false;
            dgvCart.Columns[5].Visible = false;
            dgvCart.Columns[6].Visible = false;
            dgvCart.Columns[8].Visible = false;
            dgvCart.Columns[9].Visible = false;
            dgvCart.Columns[12].Visible = false;

            dgvCart.Columns[2].Width = 200;
            dgvCart.Columns[3].Width = 200;
            dgvCart.Columns[4].Width = 60;
        }
        public void LoadOrderNo()
        {
            //lblOrderNumber.Text = SQL.ReturnResult("SELECT order_no,regulardiscountamount FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)");
            //if (SQL.HasException(true))return;
            if(SQL.ReturnResult("select count(*) from order_no") == "0")
            {
                // start order no
                SQL.Query("INSERT INTO order_no (order_no) VALUES (1)");

                if (SQL.HasException(true))
                {
                    return;
                }
            }


            SQL.Query("SELECT order_no,disc_amt FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)");

            if (SQL.HasException(true)) return;

            foreach(DataRow dr in SQL.DBDT.Rows)
            {
                lblOrderNumber.Text = dr["order_no"].ToString();
                regular_disc_amt = decimal.Parse(dr["disc_amt"].ToString());
            }

            if (regular_disc_amt != 0M)
            {
                apply_regular_discount_fix_amt = true;
            }
            else return;
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
                if ( Convert.ToDecimal(r["Discount"].ToString()) > 1300M & (check_if_PWDSC == 1 | check_if_PWDSC == 2))
                    discount = 1300M;


                lblItems.Text = r["Qty"].ToString();
                decimal subtotal = decimal.Parse(r["Subtotal"].ToString());
                lblSubtotal.Text = subtotal.ToString("N2");
                lblDiscount.Text = discount.ToString();
                decimal Total = decimal.Parse(r["Total"].ToString());
                lblTotal.Text = Total.ToString("N2");
                //lblTotal.Text = r["Total"].ToString();
                decimal VAT = decimal.Parse(r["VAT"].ToString());
                lblVAT.Text = VAT.ToString("N2");
                lblLessVAT.Text = r["LessVAT"].ToString();
            }

            decimal vatsale = decimal.Parse(SQL.ReturnResult(@"SELECT IIF((SELECT COUNT(*) FROM order_cart WHERE is_vat_exempt = 0) > 0,(SELECT CONVERT(DECIMAL(18,2),SUM(selling_price_exclusive)) FROM order_cart WHERE is_vat_exempt = 0),0)".ToString()));

            lblVATSale.Text = vatsale.ToString("N2");
            if (SQL.HasException(true))
                return;

            decimal vatexempt = decimal.Parse(SQL.ReturnResult(@"SELECT IIF((SELECT COUNT(*) FROM order_cart WHERE is_vat_exempt = 1) > 0,(SELECT CONVERT(DECIMAL(18,2),SUM(selling_price_exclusive)) FROM order_cart WHERE is_vat_exempt = 1),0)".ToString()));

            lblVATExempt.Text = vatexempt.ToString("N2");

            if (SQL.HasException(true))
                return;



            if (apply_regular_discount_fix_amt)
            {
                decimal total = 0;
                decimal vat_sale = 0;
                decimal vat = 0;

                total = decimal.Parse(lblTotal.Text);
                vat_sale = decimal.Parse(lblVATSale.Text);
                vat = decimal.Parse(lblVAT.Text);

                lblDiscount.Text = regular_disc_amt.ToString();

                decimal totaldisc = total - regular_disc_amt;
                lblTotal.Text = totaldisc.ToString("N2");

                decimal vatdisc = vat - regular_disc_amt - (regular_disc_amt / 1.12M);
                lblVAT.Text = vatdisc.ToString("N2");

                decimal vatsaledisc = vat_sale - (regular_disc_amt / 1.12M);
                lblVATSale.Text = vatsaledisc.ToString("N2");
            }
        }

        //METHODS

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (Main.Instance.lblUser.Text == "Bypassed")
            {
                MessageBox.Show("Please login properly to proceed.", "Error(No user found)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            bool checkprinter = Main.PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("No printer device selected.", "", "error");

                Devices d = new Devices();
                d.Show();
                return;
            }
            else
            {
                if (dgvCart.Rows.Count == 0)
                {
                    new Notification().PopUp("Orders cart is empty.", "Error", "error");
                    return;
                }

                if(Convert.ToInt32(SQL.ReturnResult("select count(*) from transaction_details")) != 0)
                {
                    int orderreftransac = Convert.ToInt32(SQL.ReturnResult("select max(order_ref) from transaction_details"));
                    int orderreforderno = Convert.ToInt32(SQL.ReturnResult("select max(order_ref) from order_no"));

                    if (orderreftransac == orderreforderno)
                    {
                        SQL.AddParam("@orderref", orderreftransac);
                        SQL.Query("DELETE FROM transaction_details WHERE order_ref=@orderref");

                        if (SQL.HasException(true))
                        {
                            return;
                        }
                    }
                }

                int action = Convert.ToInt32(SQL.ReturnResult("SELECT action FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)"));

                string customerID = SQL.ReturnResult("SELECT cus_ID_No FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)");
                if (SQL.HasException(true)) return;


                SQL.AddParam("@customerID", customerID);
                decimal card_balance = Convert.ToDecimal(SQL.ReturnResult("SELECT IIF(@customerID <> 0, (SELECT card_balance FROM member_card WHERE customerID = @customerID), 0.00)"));
                if (SQL.HasException(true)) return;

                if(CheckOpened("Payment") == true)
                {
                    return;
                }

                Payment frmPayment = new Payment();
                RP.Payment(frmPayment);
                frmPayment.frmOrder = this;
                frmPayment.lblCustomerID.Text = customerID;
                frmPayment.cbxUsePoints.Text = card_balance.ToString("N2");
                frmPayment.card_balance = card_balance;

                decimal total = decimal.Parse(lblTotal.Text);
                frmPayment.lblTotal.Text = total.ToString("N2");


                frmPayment.lblGrandTotal.Text = total.ToString("N2");
                frmPayment.grand_total = decimal.Parse(lblTotal.Text);
                frmPayment.total = decimal.Parse(lblTotal.Text);
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
                        new Notification().PopUp("Exchange item cannot be higher than return item.", "Error", "error");
                    }

                    frmPayment.change = System.Convert.ToDecimal(lblTotal.Text);
                    frmPayment.lblChange.Text = lblTotal.Text;


                    frmPayment.txtAmount.Enabled = false;
                    frmPayment.btnExact.Enabled = false;
                    frmPayment.btnGC.Enabled = false;
                    frmPayment.btnRemoveGC.Enabled = false;
                    frmPayment.cbxUsePoints.Enabled = false;
                    frmPayment.cmbMethod.Enabled = false;
                }
                frmPayment.Show(this);

                FormLoad Fl = new FormLoad();
                Fl.CusDisplay("TOTAL:", frmPayment.lblGrandTotal.Text);

            }
        }

        String[] hybrid;
        decimal quantitytalaga;
        private void tbBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbBarcode.Text == "")
                {
                    return;
                }
                int check_product;
                string barcode;
                int quantity = 1;

                if (tbBarcode.Text.Contains("*"))
                {
                    hybrid = tbBarcode.Text.Split('*');
                    try
                    {
                        quantity = int.Parse(hybrid[0]);
                    }
                    catch (Exception)
                    {
                        quantity = 1;
                    }

                    barcode = hybrid[1];
                }
                else
                {
                    barcode = tbBarcode.Text;
                }


                SQL.AddParam("@barcode", barcode);
                check_product = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM products WHERE barcode1 = @barcode OR barcode2 = @barcode"));
                if (SQL.HasException(true))
                    return;

                SQL.AddParam("@barcode", barcode);
                SQL.AddParam("@type", type);
                int check_in_cart = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM order_cart WHERE productID = (SELECT productID FROM products WHERE (barcode1 = @barcode OR barcode2 = @barcode) AND type = @type AND is_return = 0)"));
                if (SQL.HasException(true))
                    return;

                if (check_product == 1)
                {
                    //CHECKER KUNG TAMA BA YUNG QUANTITY AT STOCK
                    SQL.AddParam("@barcode", barcode);
                    string productID1 = SQL.ReturnResult("SELECT productID FROM products WHERE barcode1 = @barcode OR barcode2 = @barcode");
                    if (SQL.HasException(true))
                        return;

                    if (int.Parse(SQL.ReturnResult("select count(*)from order_cart")) != 0)
                    {
                        SQL.AddParam("@productID", productID1);
                        quantitytalaga = decimal.Parse(SQL.ReturnResult("select quantity from order_cart where productID=@productID"));

                        decimal totalquantity = quantitytalaga + quantity;

                        //MessageBox.Show("No of quantity: "+ totalquantity.ToString());

                        //CHECKER KUNG MAS MATAAS ANG QUANTITY
                        SQL.AddParam("@productID", productID1);
                        decimal stock = decimal.Parse(SQL.ReturnResult("select stock_qty from inventory where productID=@productID"));

                        if (SQL.HasException(true)) return;

                        //MessageBox.Show("No of stock: "+stock.ToString());

                        if (totalquantity > stock)
                        {
                            new Notification().PopUp("Insufficient stock", "", "error");
                            tbBarcode.Clear();
                            tbBarcode.Focus();
                            return;
                        }
                    }
                    //END OF THE CHECKER

                    SQL.AddParam("@barcode", barcode);
                    string productID = SQL.ReturnResult("SELECT productID FROM products WHERE barcode1 = @barcode OR barcode2 = @barcode");
                    if (SQL.HasException(true))
                        return;

                    string prod_description = "";
                    string prod_price = "";
                  
                    if (check_in_cart == 0)
                    {
                        //check if still in stock
                        SQL.AddParam("@productID", Convert.ToInt32(productID));
                        int check1 = int.Parse(SQL.ReturnResult("SELECT IIF((SELECT SUM(quantity) FROM order_cart WHERE productID = @productID) >= (SELECT stock_qty FROM inventory WHERE productID = @productID), 1, 0)"));
                        if (SQL.HasException(true)) return;
                        SQL.AddParam("@productID", Convert.ToInt32(productID));
                        int check2 = int.Parse(SQL.ReturnResult("SELECT IIF((SELECT stock_qty FROM INVENTORY WHERE productID = @productID) = 0, 1, 0)"));
                        if (SQL.HasException(true)) return;

                        if (check1 == 1 || check2 == 1)
                        {
                            new Notification().PopUp("Insufficient stock", "", "error");
                            tbBarcode.Clear();
                            tbBarcode.Focus();
                            return;
                        }

                        //CHECKER KUNG MAS MATAAS ANG QUANTITY
                        SQL.AddParam("@productID", productID);
                        decimal stock = decimal.Parse(SQL.ReturnResult("select stock_qty from inventory where productID=@productID"));

                        if (SQL.HasException(true)) return;

                        if(quantity > stock)
                        {
                            new Notification().PopUp("Insufficient stock", "", "error");
                            tbBarcode.Clear();
                            tbBarcode.Focus();
                            return;
                        }



                        SQL.AddParam("@type", type);
                        SQL.AddParam("@productID", Convert.ToInt32(productID));
                        SQL.AddParam("@quantity", quantity);

                        SQL.Query(@"INSERT INTO order_cart (productID , description, name, type, static_price_exclusive, static_price_vat, static_price_inclusive, quantity, discount) 
                                   SELECT productID, description, name, @type," + insert_type_query + ", @quantity, 0 FROM products WHERE productID = @productID");

                        if (SQL.HasException(true))
                            return;
                        #region "customer display"
                        //customer display
                        SQL.Query("SELECT name, static_price_inclusive FROM order_cart WHERE itemID = (SELECT MAX(itemID) FROM order_cart)");
                        if (SQL.HasException(true))
                            return;

                        foreach (DataRow r in SQL.DBDT.Rows)
                        {
                            prod_description = r["name"].ToString();
                            prod_price = r["static_price_inclusive"].ToString();

                        }

                        FormLoad Fl = new FormLoad();
                        Fl.CusDisplay(prod_description, prod_price);
                        #endregion
                    }
                    else
                    {

                        //check if still in stock (retail and wholesale)
                        SQL.AddParam("@productID", Convert.ToInt32(productID));
                        if (int.Parse(SQL.ReturnResult("SELECT IIF((SELECT SUM(quantity) FROM order_cart WHERE productID = @productID) >= (SELECT stock_qty FROM inventory WHERE productID = @productID), 1, 0)")) == 1)
                        {
                            new Notification().PopUp("Insufficient stock", "", "error");
                            tbBarcode.Clear();
                            tbBarcode.Focus();
                            return;
                        }

                        //CHECKER KUNG MAS MATAAS ANG QUANTITY
                        SQL.AddParam("@productID", productID);
                        decimal stock = decimal.Parse(SQL.ReturnResult("select stock_qty from inventory where productID=@productID"));

                        if (SQL.HasException(true)) return;

                        if (quantity > stock)
                        {
                            new Notification().PopUp("Insufficient stock", "", "error");
                            tbBarcode.Clear();
                            tbBarcode.Focus();
                            return;
                        }


                        SQL.AddParam("@barcode", tbBarcode.Text);
                        SQL.AddParam("@productID", productID);
                        SQL.AddParam("@type", type);
                        SQL.AddParam("@quantity", quantity);

                        SQL.Query("UPDATE order_cart SET quantity = quantity + @quantity WHERE productID = @productID AND type = @type AND is_return = 0");
                        if (SQL.HasException(true))
                            return;

                        #region "customer display"
                        //customer display
                        SQL.AddParam("@barcode", tbBarcode.Text);
                        SQL.AddParam("@productID", productID);
                        SQL.AddParam("@type", type);
                        SQL.Query("SELECT name, static_price_inclusive from order_cart WHERE productID = @productID AND type = @type AND is_return = 0");
                        if (SQL.HasException(true)) return;

                        foreach (DataRow r in SQL.DBDT.Rows)
                        {
                            prod_description = r["name"].ToString();
                            prod_price = r["static_price_inclusive"].ToString();

                        }
                        FormLoad Fl = new FormLoad();
                        Fl.CusDisplay(prod_description, prod_price);
                        #endregion
                    }

                    LoadOrder();
                    GetTotal();
                    tbBarcode.Clear();
                    tbBarcode.Focus();

                }
                else if(check_product > 1)
                {
                    new Notification().PopUp("There is duplicate barcode found in the products", "Please try again", "error");
                    return;
                }

                else
                {
                    new Notification().PopUp("No item found!", "Barcode not registered.", "error");
                    //MessageBox.Show("No item found!", "Barcode not registered.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    tbBarcode.Clear();
                    tbBarcode.Focus();
                }
            }
        }

        private void btnWholeSale_Click(object sender, EventArgs e)
        {
            type = "W";
            insert_type_query = "wp_exclusive, wp_tax, wp_inclusive";
        }

        private void Order_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode != Keys.Modifiers == Keys.D && e.Modifiers == Keys.Control)
            //    btnDiscount.PerformClick();
            //else if ((e.KeyCode & !Keys.Modifiers) == Keys.C && e.Modifiers == Keys.Control)
            //    btnCustomer.PerformClick();
            //else if ((e.KeyCode & !Keys.Modifiers) == Keys.Q && e.Modifiers == Keys.Control)
            //    btnQuantity.PerformClick();
            //else if ((e.KeyCode & !Keys.Modifiers) == Keys.I && e.Modifiers == Keys.Control)
            //    btnSeeItem.PerformClick();
            //else if ((e.KeyCode & !Keys.Modifiers) == Keys.V && e.Modifiers == Keys.Control)
            //    btnVoidItem.PerformClick();
            //else if ((e.KeyCode & !Keys.Modifiers) == Keys.P && e.Modifiers == Keys.Control)
            //    btnPayment.PerformClick();
            //else if (e.KeyCode == Keys.F3)
            //    btnVoid.PerformClick();
            //else if (e.KeyCode == Keys.F4)
            //    btnCancel.PerformClick();
            //else if (e.KeyCode == Keys.F7)
            //    btnRedeem.PerformClick();
            //else if (e.KeyCode == Keys.F11)
            //{
            //    UserBypass frmUserBypass = new UserBypass();
            //    frmUserBypass.frmOrder = this;
            //    frmUserBypass.fromOrder = true;
            //    frmUserBypass.ShowDialog();
            //}
            //else if (e.KeyCode == Keys.F12)
            //{
            //    foreach (var item in Main.Instance.bypass_list)

            //        item = false;

            //    Main.Instance.by_pass_user = false;
            //    Main.Instance.by_pass_userID = 0;
            //    Main.Instance.by_pass_user_name = "";
            //    Main.Instance.lblByPassUser.Text = "";

            //    RP.Order(this);
            //    RP.Home(Main.Instance);
            //}
            //else if ((e.KeyCode & !Keys.Modifiers) == Keys.X && e.Modifiers == Keys.Control)
            //{
            //    Form2 frmForm2 = new Form2();
            //    frmForm2.frmOrder = this;
            //    frmForm2.ShowDialog();
            //}
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            if(dgvCart.Rows.Count == 0)
            {
                tbBarcode.Clear();
                this.ActiveControl = tbBarcode;
                
                new Notification().PopUp("Please select an item first", "Error", "error");
                return;
            }

            if(lblDiscount.Text != "0.00")
            {
                if (MessageBox.Show("Would you like to cancel applied discounts?", "Discount Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQL.Query("UPDATE order_cart SET discount=0.00,is_less_vat='False',less_vat=0.00,is_vat_exempt='False',is_disc_percent='False',disc_percent=0.00,zero_vat=1");
                    if (SQL.HasException(true)) return;

                    SQL.Query("UPDATE order_no SET discountID=0,disc_amt=0.00 where order_ref = (SELECT MAX(order_ref) FROM order_no)");
                    if (SQL.HasException(true)) return;

                    LoadOrderNo();
                    LoadOrder();
                    GetTotal();

                    return;
                }
                else return;
            }

            //int discountvalue = Convert.ToInt32(SQL.ReturnResult("select discountID from order_no where order_ref = (SELECT MAX(order_ref) FROM order_no)"));

            //if (discount != "0.00")
            //{
            //    if (MessageBox.Show("You've already added discount to this product. \n \n Do you want to cancel it ?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        SQL.Query("UPDATE order_cart SET discount=0.00,is_less_vat='False',less_vat=0.00,is_vat_exempt='False',is_disc_percent='False',disc_percent=0.00,zero_vat=1");
            //        if (SQL.HasException(true)) return;
            //        LoadOrder();
            //        GetTotal();

            //        return;
            //    }
            //    else return;
            //}


            //if (discountvalue != 0)
            //{
            //    if (MessageBox.Show("You've already added discount to this product. \n \n Do you want to cancel it ?", "Error in regular discount", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        SQL.Query("UPDATE order_no SET discountID=0,disc_amt=0.00 where order_ref = (SELECT MAX(order_ref) FROM order_no)");
            //        if (SQL.HasException(true)) return;

            //        apply_regular_discount_fix_amt = false;

            //        LoadOrder();
            //        GetTotal();

            //        return;
            //    }
            //    else return;
            //}

            if (CheckOpened("DiscountOption") == true)
            {
                return;
            }

            DiscountOption frmDiscountOption = new DiscountOption();
            frmDiscountOption.frmOrder = this;
            frmDiscountOption.ShowDialog();


            tbBarcode.Clear();
            this.ActiveControl = tbBarcode;
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            if(CheckOpened("Quantity") == true)
            {
                return;
            }

            if (dgvCart.SelectedRows.Count > 0)
            {
                Quantity frmQuantity = new Quantity();
                frmQuantity.frmOrder = this;
                frmQuantity.itemID = dgvCart.CurrentRow.Cells[0].Value.ToString();
                frmQuantity.productID = dgvCart.CurrentRow.Cells[1].Value.ToString();
                frmQuantity.lblItem.Text = dgvCart.CurrentRow.Cells[2].Value.ToString();
                frmQuantity.txtQuantity.Text = dgvCart.CurrentRow.Cells[11].Value.ToString();
                decimal x = decimal.Parse(dgvCart.CurrentRow.Cells[11].Value.ToString());
                frmQuantity.currentQty = x;
                frmQuantity.ShowDialog();
            }

            tbBarcode.Clear();
            this.ActiveControl = tbBarcode;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbBarcode.Clear();
            this.ActiveControl = tbBarcode;

            apply_regular_discount_fix_amt = false;
            apply_special_discount = false;
            apply_member = false;
            regular_disc_amt = 0;

            is_refund = false;
            is_return = false;

            lblCustomer.Text = "";
            lblOperation.Text = "Order/Payment";
            tbBarcode.Enabled = true;

            if (dgvCart.Rows.Count == 0)
                return;

            SQL.Query("DELETE FROM order_cart");

            if (SQL.HasException(true))
                return;

            SQL.Query(@"UPDATE order_no SET action = 1, discountID = 0, cus_type = 0, cus_name = '',
                       cus_ID_no = 0, cus_mem_ID = 0, disc_amt = 0, cus_rewardable = 0, cus_amt_per_pt = 0, 
                       return_order_ref = 0, refund_order_ref = 0 WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)");

            if (SQL.HasException(true))
                return;

            LoadOrder();
            GetTotal();

            btnDiscount.Enabled = true;
            btnCustomer.Enabled = true;
            btnQuantity.Enabled = true;
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            VoidTransaction.Instance.ActiveControl = VoidTransaction.Instance.txtORNo;

            VoidTransaction frmVT = new VoidTransaction();
            frmVT.ShowDialog();

            tbBarcode.Clear();
            this.ActiveControl = tbBarcode;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if(CheckOpened("OCustomer") == true)
            {
                return;
            }
            OCustomer frmOCustomer = new OCustomer();
            frmOCustomer.frmOrder = this;
            frmOCustomer.ShowDialog();

            tbBarcode.Clear();
            this.ActiveControl = tbBarcode;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            _order = this;

            new CreateParams();
            SetDoubleBuffered(OrderPanel);

            btnRetail.PerformClick();
            LoadOrderNo();
            LoadOrder();
            GetTotal();

            tbBarcode.Clear();
            this.ActiveControl = tbBarcode;


            //tbBarcode.Focus();
            //tbBarcode.Clear();

            //TEMPORARY
          //  btnVoid.Enabled = false;
        }

        private void btnVoidItem_Click(object sender, EventArgs e)
        {
            try
            {
                tbBarcode.Clear();
                this.ActiveControl = tbBarcode;
            }
            catch (Exception) { }

            if (dgvCart.SelectedRows.Count == 0)
                return;

            // save to void item
            SQL.AddParam("@productID", dgvCart.CurrentRow.Cells[1].Value.ToString());
            SQL.AddParam("@userID", Main.Instance.current_id);

            SQL.Query(@"INSERT INTO void_item (itemID, productID, order_no, description, name, type, static_price_exclusive,
                       static_price_vat, static_price_inclusive, quantity, userID) SELECT itemID, productID, 
                       (SELECT order_no FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)), description, 
                       name, type, static_price_exclusive, static_price_vat, static_price_inclusive, quantity, @userID
                       FROM order_cart WHERE productID = @productID");

            if (SQL.HasException(true))
                return;

            SQL.AddParam("@itemID", dgvCart.CurrentRow.Cells[0].Value.ToString());
            SQL.Query("DELETE FROM order_cart WHERE itemID = @itemID");

            if (SQL.HasException(true))
                return;

            LoadOrder();
            GetTotal();
        }
        private void btnRetail_Click(object sender, EventArgs e)
        {
            insert_type_query = " rp_exclusive, rp_tax, rp_inclusive";
            type = "R";
        }

        //GLOBAL HOTKEYS
        private void ClickCancelTransaction(object sender, EventArgs e)
        {
            Order.Instance.btnCancel.PerformClick();
        }

        private void OpenVoidItem(object sender, EventArgs e)
        {
            Order.Instance.btnVoidItem.PerformClick();
        }

        private void Openquantity(object sender, EventArgs e)
        {
            Order.Instance.btnQuantity.PerformClick();
        }

        private void OpenDiscount(object sender, EventArgs e)
        {
            Order.Instance.btnDiscount.PerformClick();
        }
        private void ClickCustomer(object sender, EventArgs e)
        {
            //Order.Instance.btnCustomer.PerformClick();
        }
        private void AccessUserByPass(object sender, EventArgs e)
        {
            UserBypass frmUserBypass = new UserBypass();
            frmUserBypass.frmOrder = this;
            frmUserBypass.fromOrder = true;
            frmUserBypass.ShowDialog();
        }
        private void CancelUserByPass(object sender, EventArgs e)
        {
            for (int i = 0; i < Main.Instance.bypass_list.Count; i++)
            {
                Main.Instance.bypass_list[i] = false;
            }

             Main.Instance.by_pass_user = false;
             Main.Instance.by_pass_userID = 0;
             Main.Instance.by_pass_user_name = "";
             Main.Instance.lblByPassUser.Text = "";
           
             RP.Order(this);
             RP.Home(Main.Instance);
            Main.Instance.btnOrder.PerformClick();
        }
        //GLOBAL HOTKEYS

        private void btnRedeem_Click(object sender, EventArgs e)
        {
            if(CheckOpened("Redeem") == true)
            {
                return;
            }


            if (dgvCart.RowCount > 0)
            {
                new Notification().PopUp("Clear cart first.", "Error", "error");
                return;
            }

            Redeem frmRedeem = new Redeem();
            frmRedeem.frmOrder = this;
            frmRedeem.ShowDialog();

            tbBarcode.Clear();
            this.ActiveControl = tbBarcode;
        }

        private void tbBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void dgvCart_Click(object sender, EventArgs e)
        {
            if(dgvCart.Rows.Count == 0)
            {
                tbBarcode.Clear();
                this.ActiveControl = tbBarcode;
            }
        }

        private void dgvCart_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                tbBarcode.Clear();
                this.ActiveControl = tbBarcode;
            }
        }

        private void OpenPayment(object sender, EventArgs e)
        {
            Order.Instance.btnPayment.PerformClick();
        }
    }
}
