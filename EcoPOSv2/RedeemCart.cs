using CrystalDecisions.Shared;
using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EcoPOSv2.ControlBehavior;

namespace EcoPOSv2
{
    public partial class RedeemCart : Form
    {
        public RedeemCart()
        {
            InitializeComponent();
        }
        private SQLControl SQL = new SQLControl();

        private RedeemReceipt58 report = new RedeemReceipt58();
        private RedeemReceipt80 report80 = new RedeemReceipt80();

        public Payment frmPayment;

        public decimal card_balance;
        public int customerID;
        public string card_no;

        public bool clickOnce_dgvRedeemCart = false;

        public static RedeemCart _RedeemCart;
        public static RedeemCart Instance
        {
            get
            {
                if (_RedeemCart == null)
                {
                    _RedeemCart = new RedeemCart();
                }
                return _RedeemCart;
            }
        }
        //METHODS
        private void GenerateReceipt()
        {
            if (Properties.Settings.Default.papersize == "58MM")
            {
                DataSet ds = new DataSet();

                report = new RedeemReceipt58();

                try
                {
                    SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, total_pts FROM redeem_transaction_items WHERE order_ref = (SELECT MAX(order_ref) FROM redeem_transaction)", SQL.DBCon);
                    SQL.DBDA.Fill(ds, "redeem_transaction_items");

                    report.SetDataSource(ds);

                    SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                           SELECT * INTO #Temp_users
                           FROM
                           (
                           SELECT ID, user_name, first_name FROM
                           (
                           SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts
                           UNION ALL
                           SELECT userID, user_name, first_name FROM users
                           ) x
                           ) as a;
                           SELECT date_time,
                           order_ref_temp, 
                           u.first_name as 'user_first_name', 
                           no_of_items, 
                           total_pts as 'total', 
                           card_balance_before as 'balance', 
                           card_balance_after as 'remaining_pts', 
                           c.name as 'cus_name',
                           cus_card_no FROM redeem_transaction as rt
                           INNER JOIN #Temp_users as u ON rt.userID = u.ID
                           INNER JOIN customer as c ON rt.cus_ID_no = c.customerID
                           WHERE order_ref = (SELECT MAX(order_ref) FROM redeem_transaction)");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("date_time", r["date_time"].ToString());
                        report.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        decimal noofitems = decimal.Parse(r["no_of_items"].ToString());
                        report.SetParameterValue("no_of_items", noofitems.ToString("N2"));
                        decimal total = decimal.Parse(r["total"].ToString());
                        report.SetParameterValue("total", total.ToString("N2"));
                        decimal balance = decimal.Parse(r["balance"].ToString());
                        report.SetParameterValue("balance", balance.ToString("N2"));
                        decimal remaining_pts = decimal.Parse(r["remaining_pts"].ToString());
                        report.SetParameterValue("remaining_pts", remaining_pts.ToString("N2"));
                        report.SetParameterValue("cus_name", r["cus_name"].ToString());
                        report.SetParameterValue("cus_card_no", r["cus_card_no"].ToString());
                    }

                    report.SetParameterValue("Terminal_no", Properties.Settings.Default.Terminal_id);
                    report.SetParameterValue("business_name", Main.Instance.sd_business_name);
                    report.SetParameterValue("business_address", Main.Instance.sd_business_address);
                    report.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                    report.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                    report.SetParameterValue("sn", Main.Instance.sd_sn);
                    report.SetParameterValue("min", Main.Instance.sd_min);
                    report.SetParameterValue("footer_text", Main.Instance.sd_footer_text);
                    report.SetParameterValue("note", "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    report.Dispose();
                }


                //for (var i = 1; i <= 2; i++)

                PrintReceipt();
            }
            else
            {
                DataSet ds = new DataSet();

                report80 = new RedeemReceipt80();

                try
                {
                    SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, total_pts FROM redeem_transaction_items WHERE order_ref = (SELECT MAX(order_ref) FROM redeem_transaction)", SQL.DBCon);
                    SQL.DBDA.Fill(ds, "redeem_transaction_items");

                    report80.SetDataSource(ds);

                    SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                           SELECT * INTO #Temp_users
                           FROM
                           (
                           SELECT ID, user_name, first_name FROM
                           (
                           SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts
                           UNION ALL
                           SELECT userID, user_name, first_name FROM users
                           ) x
                           ) as a;
                           SELECT date_time,
                           order_ref_temp, 
                           u.first_name as 'user_first_name', 
                           no_of_items, 
                           total_pts as 'total', 
                           card_balance_before as 'balance', 
                           card_balance_after as 'remaining_pts', 
                           c.name as 'cus_name',
                           cus_card_no FROM redeem_transaction as rt
                           INNER JOIN #Temp_users as u ON rt.userID = u.ID
                           INNER JOIN customer as c ON rt.cus_ID_no = c.customerID
                           WHERE order_ref = (SELECT MAX(order_ref) FROM redeem_transaction)");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report80.SetParameterValue("date_time", r["date_time"].ToString());
                        report80.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        report80.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        decimal noofitems = decimal.Parse(r["no_of_items"].ToString());
                        report80.SetParameterValue("no_of_items", noofitems.ToString("N2"));
                        decimal total = decimal.Parse(r["total"].ToString());
                        report80.SetParameterValue("total", total.ToString("N2"));
                        decimal balance = decimal.Parse(r["balance"].ToString());
                        report80.SetParameterValue("balance", balance.ToString("N2"));
                        decimal remaining_pts = decimal.Parse(r["remaining_pts"].ToString());
                        report80.SetParameterValue("remaining_pts", remaining_pts.ToString("N2"));
                        report80.SetParameterValue("cus_name", r["cus_name"].ToString());
                        report80.SetParameterValue("cus_card_no", r["cus_card_no"].ToString());
                    }

                    report80.SetParameterValue("Terminal_no", Properties.Settings.Default.Terminal_id);
                    report80.SetParameterValue("business_name", Main.Instance.sd_business_name);
                    report80.SetParameterValue("business_address", Main.Instance.sd_business_address);
                    report80.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                    report80.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                    report80.SetParameterValue("sn", Main.Instance.sd_sn);
                    report80.SetParameterValue("min", Main.Instance.sd_min);
                    report80.SetParameterValue("footer_text", Main.Instance.sd_footer_text);
                    report80.SetParameterValue("note", "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    report80.Dispose();
                }


                //for (var i = 1; i <= 2; i++)

                PrintReceipt();
            }

        }
        public static bool PrinterExists(string printerName)
        {
            if (String.IsNullOrEmpty(printerName)) { throw new ArgumentNullException("printerName"); }
            return PrinterSettings.InstalledPrinters.Cast<string>().Any(name => printerName.ToUpper().Trim() == name.ToUpper().Trim());
        }
        public void PrintReceipt()
        {
            if (Main.Instance.pd_receipt_printer == "")
            {
                new Notification().PopUp("No receipt printer selected.", "Error printing", "error");
                return;
            }


            bool checkprinter = PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("Printer is offline", "Error", "error");
                return;
            }

            if (Properties.Settings.Default.papersize == "58MM")
            {
                report.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                report.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                report.PrintToPrinter(1, false, 0, 0);
            }
            else
            {
                report80.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                report80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                report80.PrintToPrinter(1, false, 0, 0);
            }
        }
        public void Advance_OrderNo()
        {
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query(@"INSERT INTO order_no (order_no, terminal_id)
                       SELECT (order_no + 1), @terminal_id FROM order_no WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no where terminal_id=@terminal_id)");

            if (SQL.HasException(true))
                return;

            Order.Instance.LoadOrderNo();
        }

        private void LoadItems()
        {
            SQL.Query("SELECT productID, description as 'Name', pts as 'Points' FROM redeem_items ORDER BY description ASC");

            if (SQL.HasException(true))
                return;

            dgvRedeemItems.DataSource = SQL.DBDT;
            dgvRedeemItems.Columns[0].Visible = false;
        }
        public void LoadCart()
        {
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query("SELECT itemID, productID, description as 'Name', CONVERT(DECIMAL(18,2), static_pts) as 'Points', quantity as 'Quantity', total_pts as 'Total' FROM redeem_cart WHERE terminal_id=@terminal_id ORDER BY description ASC");

            if (SQL.HasException(true))
                return;

            dgvRedeemCart.DataSource = SQL.DBDT;
            dgvRedeemCart.Columns[0].Visible = false;
            dgvRedeemCart.Columns[1].Visible = false;
        }
        public void GetTotal()
        {
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            int count = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM redeem_cart where terminal_id=@terminal_id) > 0, 1, 0)"));

            if (SQL.HasException(true))
                return;

            SQL.AddParam("@count", count);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query(@"SELECT IIF(@count > 0, SUM(quantity), 0.00) as 'Quantity',
		                      IIF(@count > 0, SUM(total_pts), 0.00) as 'Total'
		              FROM redeem_cart WHERE terminal_id=@terminal_id");

            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                decimal items = decimal.Parse(r["Quantity"].ToString());
                decimal total = decimal.Parse(r["Total"].ToString());

                lblItems.Text = items.ToString("N2");
                lblTotal.Text = total.ToString("N2");

                lblRemainingPoints.Text = (card_balance - total).ToString("N2");
            }
        }

        //METHODS

        private void RedeemCart_Load(object sender, EventArgs e)
        {
            _RedeemCart = this;

            LoadItems();
            Control c = (Control)txtSearchItem;
            ControlBehavior.SetBehavior(ref c, Behavior.ClearSearch);
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            if (clickOnce_dgvRedeemCart == false)
                return;

            if (dgvRedeemCart.SelectedRows.Count == 0)
                return;

            RDMQuantity frmRDMQuantity = new RDMQuantity();
            frmRDMQuantity.itemID = Convert.ToInt32(dgvRedeemCart.CurrentRow.Cells[0].Value.ToString());
            frmRDMQuantity.lblItem.Text = dgvRedeemCart.CurrentRow.Cells[2].Value.ToString();
            frmRDMQuantity.txtQuantity.Text = dgvRedeemCart.CurrentRow.Cells[4].Value.ToString();
            frmRDMQuantity.frmRedeemCart = this;
            frmRDMQuantity.ShowDialog();
        }

        private void dgvRedeemItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var productID = dgvRedeemItems.CurrentRow.Cells[0].Value.ToString();

            SQL.AddParam("@productID", productID);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            int check_item_in_cart = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM redeem_cart WHERE terminal_id=@terminal_id AND productID = @productID"));
            if (SQL.HasException(true))
                return;

            if (check_item_in_cart == 0)
            {
                SQL.AddParam("@productID", productID);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                SQL.Query(@"INSERT INTO redeem_cart (productID, description, categoryID, static_pts, quantity,terminal_id)
                       SELECT productID, description, categoryID, pts, 1,@terminal_id FROM redeem_items WHERE productID = @productID");

                if (SQL.HasException(true))
                    return;
            }
            else
            {
                SQL.AddParam("@productID", productID);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                SQL.Query("UPDATE redeem_cart SET quantity = quantity + 1 WHERE productID = @productID AND terminal_id=@terminal_id");

                if (SQL.HasException(true))
                    return;
            }

            LoadCart();
            GetTotal();
        }

        private void txtSearchItem_KeyUp(object sender, KeyEventArgs e)
        {
            // search
            SQL.AddParam("@find", txtSearchItem.Text + "%");

            SQL.Query(@"SELECT productID, description as 'Name', pts as 'Points' FROM redeem_items WHERE 
                       description LIKE @find OR barcode1 LIKE @find OR barcode2 LIKE @find ORDER BY description ASC");

            if (SQL.HasException(true))
                return;

            dgvRedeemItems.DataSource = SQL.DBDT;
            dgvRedeemItems.Columns[0].Visible = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (clickOnce_dgvRedeemCart == false)
                return;

            if (dgvRedeemCart.SelectedRows.Count == 0)
                return;

            SQL.AddParam("itemID", dgvRedeemCart.CurrentRow.Cells[0].Value.ToString());
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query("DELETE FROM redeem_cart WHERE itemID = @itemID AND terminal_id=@terminal_id");

            if (SQL.HasException(true))
                return;

            LoadCart();
            GetTotal();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (dgvRedeemCart.Rows.Count == 0)
                return;

            decimal remaining_pts = System.Convert.ToDecimal(lblRemainingPoints.Text);

            if (remaining_pts < 0)
            {
                new Notification().PopUp("Insufficient points.", "Error", "error");
                return;
            }

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            int order_ref = Convert.ToInt32(SQL.ReturnResult("SELECT order_ref FROM order_no WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no WHERE terminal_id=@terminal_id)"));
            if (SQL.HasException(true))
                return;


            SQL.AddParam("@order_ref", order_ref);
            SQL.AddParam("@cus_ID_no", customerID);
            SQL.AddParam("@cus_name", lblCustomerName.Text);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query("UPDATE order_no SET action = 5, cus_type = 4, cus_name = @cus_name, cus_ID_no = @cus_ID_no WHERE order_ref = @order_ref AND terminal_id=@terminal_id");

            if (SQL.HasException(true))
                return;


            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            int order_no = Convert.ToInt32(SQL.ReturnResult("SELECT order_no FROM order_no WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no WHERE terminal_id=@terminal_id)"));
            if (SQL.HasException(true))
                return;

            SQL.AddParam("@order_ref", order_ref);
            SQL.AddParam("@order_no", order_no);
            SQL.AddParam("@no_of_items",decimal.Parse(lblItems.Text));
            SQL.AddParam("@total_pts", System.Convert.ToDecimal(lblTotal.Text));
            SQL.AddParam("@cus_ID_no", customerID);
            SQL.AddParam("@cus_card_no", card_no);
            SQL.AddParam("@card_balance_before", System.Convert.ToDecimal(lblBalance.Text));
            SQL.AddParam("@card_balance_after", System.Convert.ToDecimal(lblRemainingPoints.Text));
            SQL.AddParam("@userID", Main.Instance.current_id);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query(@"INSERT INTO redeem_transaction (order_ref, order_no, no_of_items, total_pts, cus_ID_no, cus_card_no, card_balance_before, card_balance_after, userID,terminal_id)
                       VALUES (@order_ref, @order_no, @no_of_items, @total_pts, @cus_ID_no, @cus_card_no, @card_balance_before, @card_balance_after, @userID,@terminal_id)");

            if (SQL.HasException(true))
                return;

            SQL.AddParam("@order_ref", order_ref);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query(@"INSERT INTO redeem_transaction_items (order_ref, itemID, productID, description, categoryID, static_pts, quantity, total_pts,terminal_id)
                       SELECT @order_ref, itemID, productID, description, categoryID, static_pts, quantity, total_pts,@terminal_id FROM redeem_cart");

            if (SQL.HasException(true))
                return;


            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query("SELECT productID, quantity FROM redeem_cart WHERE terminal_id=@terminal_id");
            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                SQL.AddParam("@productID", r["productID"]);
                SQL.AddParam("@quantity", r["quantity"]);

                SQL.Query("UPDATE inventory SET stock_qty = stock_qty - @quantity WHERE productID = @productID");
                if (SQL.HasException(true))
                    return;
            }

            SQL.AddParam("@card_balance", System.Convert.ToDecimal(lblRemainingPoints.Text));
            SQL.AddParam("@customerID", customerID);

            SQL.Query("UPDATE member_card SET card_balance = @card_balance WHERE customerID = @customerID");

            if (SQL.HasException(true))
                return;


            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query("DELETE FROM redeem_cart WHERE terminal_id=@terminal_id");
            if (SQL.HasException(true))
                return;

            Advance_OrderNo();
            GenerateReceipt();
            Close();

            new Notification().PopUp("Redeem success", "", "success");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvRedeemCart.Rows.Count > 0)
            {
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                SQL.Query("DELETE FROM redeem_cart WHERE terminal_id=@terminal_id");

                if (SQL.HasException(true))
                    return;
            }

            Close();
        }

        private void dgvRedeemCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickOnce_dgvRedeemCart = true;
        }

        private void txtSearchItem_KeyDown(object sender, KeyEventArgs e)
        {
            // put to cart
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearchItem.Text == "")
                    return;

                SQL.AddParam("@find", txtSearchItem.Text);
                int check_item = Convert.ToInt32(SQL.ReturnResult(@"SELECT COUNT(*) FROM redeem_items WHERE 
                                                                          description = @find OR barcode1 = @find OR barcode2 = @find"));
                if (SQL.HasException(true))
                    return;

                if (check_item == 1)
                {
                    SQL.AddParam("@find", txtSearchItem.Text);
                    int productID = Convert.ToInt32(SQL.ReturnResult(@"SELECT productID FROM redeem_items WHERE 
                                                                          description = @find OR barcode1 = @find OR barcode2 = @find"));

                    SQL.AddParam("@productID", productID);
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                    int check_item_in_cart = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM redeem_cart WHERE productID = @productID AND terminal_id=@terminal_id"));
                    if (SQL.HasException(true))
                        return;

                    if (check_item_in_cart == 0)
                    {
                        SQL.AddParam("@productID", productID);
                        SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                        SQL.Query(@"INSERT INTO redeem_cart (productID, description, categoryID, static_pts, quantity,terminal_id)
                       SELECT productID, description, categoryID, pts, 1,@terminal_id FROM redeem_items WHERE productID = @productID");

                        if (SQL.HasException(true))
                            return;
                    }
                    else
                    {
                        SQL.AddParam("@productID", productID);
                        SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                        SQL.Query("UPDATE redeem_cart SET quantity = quantity + 1 WHERE productID = @productID AND terminal_id=@terminal_id");

                        if (SQL.HasException(true))
                            return;
                    }

                    LoadCart();
                    GetTotal();
                }
            }
        }
    }
}
