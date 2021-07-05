using CrystalDecisions.Shared;
using EcoPOSControl;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EcoPOSv2.ControlBehavior;
using static EcoPOSv2.GroupAction;
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class RedeemSettings : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public const byte KEYEVENTF_KEYUP = 0x02;
        public const int VK_CONTROL = 0x11;
        public RedeemSettings()
        {
            InitializeComponent();
        }
        private FormLoad OL = new FormLoad();
        private SQLControl SQL = new SQLControl();
        private GroupAction GA = new GroupAction();
        private ExportImport EI = new ExportImport();

        private Panel currentPanel;
        private Button currentBtn;

        private string giftcardID = "";
        private string redeemID = "";

        private bool dgvRT_ClickedOnce = false;

        private RedeemTransactionReport report = new RedeemTransactionReport();
        private RedeemReceipt reprint_receipt = new RedeemReceipt();

        private List<Control> allTxt = new List<Control>();
        private List<TextBox> requiredFields = new List<TextBox>();

        //METHODS
        private void LoadRT_Customers()
        {
            OL.ComboValuesQuery(cmbRT_Customer, @"SELECT customerID, name FROM
                                         (
                                          SELECT 0 as 'customerID', 'All customers' as 'name', 1 as ord
                                          UNION ALL
                                          SELECT customerID, (name + ' (' + card_no + ')'), 2 as ord FROM customer
                                         ) x ORDER BY ord, name ASC", "customerID", "name");
        }

        private void LoadAPT_Customers()
        {
            OL.ComboValuesQuery(cmbAPT_Customer, @"SELECT customerID, name FROM
                                         (
                                          SELECT 0 as 'customerID', 'All customers' as 'name', 1 as ord
                                          UNION ALL
                                          SELECT customerID, (name + ' (' + card_no + ')'), 2 as ord FROM customer
                                         ) x ORDER BY ord, name ASC", "customerID", "name");
        }

        private void RIRF()
        {
            requiredFields = new List<TextBox>();

            requiredFields.Add(txtRI_Points);
        }

        private void LoadItems()
        {
            string cat_query = "categoryID <> 0 ";

            if (cmbRI_CategoryItems.SelectedIndex != 0)
                cat_query = "categoryID = " + cmbRI_CategoryItems.SelectedValue;

            SQL.Query("SELECT productID, description as 'Description', categoryID, barcode1, barcode2 FROM products WHERE " + cat_query + "ORDER BY description ASC");

            if (SQL.HasException(true))
                return;

            dgvRI_Items.DataSource = SQL.DBDT;
            dgvRI_Items.Columns[0].Visible = false;
            dgvRI_Items.Columns[2].Visible = false;
            dgvRI_Items.Columns[3].Visible = false;
            dgvRI_Items.Columns[4].Visible = false;
        }

        private void LoadRedeemItems()
        {
            string cat_query = "categoryID <> 0 ";

            if (cmbRI_CategoryRedeem.SelectedIndex != 0)
                cat_query = "categoryID = " + cmbRI_CategoryRedeem.SelectedValue;

            SQL.Query("SELECT redeemID, productID, description as 'Description' FROM redeem_items WHERE " + cat_query + " ORDER BY description ASC");

            if (SQL.HasException(true))
                return;

            dgvRI_RedeemItems.DataSource = SQL.DBDT;
            dgvRI_RedeemItems.Columns[0].Visible = false;
            dgvRI_RedeemItems.Columns[1].Visible = false;
        }

        private void LoadRICategory()
        {
            OL.ComboValuesQuery(cmbRI_CategoryItems, @"SELECT categoryID, name FROM
                                         (
                                          SELECT 0 as 'categoryID', 'All category' as 'name', 1 as ord
                                          UNION ALL
                                          SELECT categoryID, name, 2 as ord FROM product_category
                                         ) x ORDER BY ord, name ASC", "categoryID", "name");

            OL.ComboValuesQuery(cmbRI_CategoryRedeem, @"SELECT categoryID, name FROM
                                         (
                                          SELECT 0 as 'categoryID', 'All category' as 'name', 1 as ord
                                          UNION ALL
                                          SELECT categoryID, name, 2 as ord FROM product_category
                                         ) x ORDER BY ord, name ASC", "categoryID", "name");
        }
        private void GCRF()
        {
            requiredFields = new List<TextBox>();

            requiredFields.Add(txtGC_GCNo);
            requiredFields.Add(txtGC_Amount);
        }

        private void ClearFields_GC()
        {
            GA.DoThis(ref allTxt, TableLayoutPanel8, ControlType.TextBox, GroupAction.Action.Clear);
            lblGC_Status.Text = "";
            giftcardID = "";
        }

        private void LoadGC()
        {
            SQL.Query("SELECT giftcardID, giftcard_no as 'GC No.' FROM giftcard ORDER BY giftcard_no ASC");

            if (SQL.HasException(true))
                return;

            dgvGC.DataSource = SQL.DBDT;
            dgvGC.Columns[0].Visible = false;
        }

        private void ControlBehavior()
        {
            Control gc = new Control();
            gc = txtGC_Search as Control;

            Control si = new Control();
            si = txtRI_SearchItem as Control;

            Control ri = new Control();
            ri = txtRI_SearchRedeem as Control;
            SetBehavior(ref gc, Behavior.ClearSearch);
            SetBehavior(ref si, Behavior.ClearSearch);
            SetBehavior(ref ri, Behavior.ClearSearch);
        }

        private void TextBoxValidation()
        {
            AssignValidation(ref txtRI_Points, ValidationType.Price);
            AssignValidation(ref txtRI_Points, ValidationType.Int_Only);
            AssignValidation(ref txtGC_Amount, ValidationType.Price);
            AssignValidation(ref txtGC_Amount, ValidationType.Int_Only);
            AssignValidation(ref txtGC_GCNo, ValidationType.Int_Only);
        }

        //METHODS

        private void RedeemSettings_Load(object sender, EventArgs e)
        {
            currentPanel = pnlRI;
            currentBtn = btnRI;

            TextBoxValidation();
            ControlBehavior();
            LoadGC();
            LoadRICategory();
            LoadRedeemItems();


            // awarded points transaction
            LoadAPT_Customers();
            dtpAPT_From.Value = DateTime.Parse(string.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 00:00:01"));
            dtpAPT_To.Value = DateTime.Parse(string.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 23:59:59"));
            cmbAPT_Customer.SelectedIndex = 0;

            // redeem transaction
            LoadRT_Customers();
            dtpRT_From.Value = DateTime.Parse(string.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 00:00:01"));
            dtpRT_To.Value = DateTime.Parse(string.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 23:59:59"));
            cmbRT_Customer.SelectedIndex = 0;

            btnRI_SearchItems.PerformClick();
            btnRI_SearchRedeem.PerformClick();
        }

        private void btnRT_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlRT, ref currentPanel, btnRT, ref currentBtn);

            btnRT_Search.PerformClick();
        }

        private void btnRI_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlRI, ref currentPanel, btnRI, ref currentBtn);
        }

        private void btnAPT_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlAPT, ref currentPanel, btnAPT, ref currentBtn);

            btnAPT_Search.PerformClick();
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlGC, ref currentPanel, btnGC, ref currentBtn);
        }

        private void dgvGC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@giftcardID", dgvGC.CurrentRow.Cells[0].Value.ToString());

            SQL.Query("SELECT * FROM giftcard WHERE giftcardID = @giftcardID");

            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                giftcardID = r["giftcardID"].ToString();
                txtGC_GCNo.Text = r["giftcard_no"].ToString();
                txtGC_Amount.Text = r["amount"].ToString();
                lblGC_Status.Text = r["status"].ToString();
                dtpGC_Expiration.Value = DateTime.Parse(r["expiration"].ToString());
            }
        }

        private void btnGC_Sort_Click(object sender, EventArgs e)
        {
            if (dgvGC.RowCount == 0)
                return;

            if (btnGC_Sort.IconChar == IconChar.SortAlphaDown)
            {
                dgvGC.Sort(dgvGC.Columns[1], ListSortDirection.Ascending);
                btnGC_Sort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvGC.Sort(dgvGC.Columns[1], ListSortDirection.Descending);
                btnGC_Sort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void btnGC_Add_Click(object sender, EventArgs e)
        {
            ClearFields_GC();
        }

        private void btnGC_Save_Click(object sender, EventArgs e)
        {
            GCRF();
            int requiredFieldsMet = RequireField(ref requiredFields);

            if (requiredFieldsMet == 1)
            {
                string action = "Update";

                if (giftcardID == "")
                    action = "New";

                switch (action)
                {
                    case "New":
                        {
                            // check for duplicate names
                            SQL.AddParam("@giftcard_no", txtGC_GCNo.Text);
                            int result = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM giftcard WHERE giftcard_no = @giftcard_no) > 0,'1', '0') as result"));

                            if (SQL.HasException(true))
                                return;

                            if (result == 0)
                            {
                                SQL.AddParam("@giftcard_no", txtGC_GCNo.Text);
                                SQL.AddParam("@amount", txtGC_Amount.Text);
                                SQL.AddParam("@expiration", dtpGC_Expiration.Value);

                                SQL.Query(@"INSERT INTO giftcard (giftcard_no, amount, status, expiration)
                                       VALUES (@giftcard_no, @amount, 'Available', @expiration)");

                                if (SQL.HasException(true))
                                    return;
                                ClearFields_GC();
                                new Notification().PopUp("Data saved.", "", "success");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }

                    default:
                        {
                            SQL.AddParam("@giftcardID", giftcardID);
                            SQL.AddParam("@giftcard_no", txtGC_GCNo.Text);

                            string result = SQL.ReturnResult(@"SELECT IIF((
                SELECT COUNT(*) as duplicatecount FROM giftcard WHERE giftcard_no = @giftcard_no AND giftcardID <> @giftcardID) > 0,
                1, 0) as result");

                            if (SQL.HasException(true))
                                return;


                            if (result == "0")
                            {
                                SQL.AddParam("@giftcardID", giftcardID);
                                SQL.AddParam("@giftcard_no", txtGC_GCNo.Text);
                                SQL.AddParam("@amount", txtGC_Amount.Text);
                                SQL.AddParam("@expiration", dtpGC_Expiration.Value);

                                SQL.Query(@"UPDATE giftcard SET giftcard_no = @giftcard_no, amount = @amount
                                  , expiration = @expiration WHERE giftcardID = @giftcardID");

                                if (SQL.HasException(true))
                                    return;

                                new Notification().PopUp("Data saved.", "", "information");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }
                }

                LoadGC();
            }
            else
                new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
        }

        private void btnGC_Delete_Click(object sender, EventArgs e)
        {
            DialogResult approval = MessageBox.Show("Delete this item?", "", MessageBoxButtons.YesNo);

            if (approval == DialogResult.Yes)
            {
                if (giftcardID == "")
                {
                    new Notification().PopUp("No item selected.","","error");
                    return;
                }

                SQL.AddParam("@giftcardID", giftcardID);
                SQL.Query("DELETE FROM giftcard WHERE giftcardID = @giftcardID");

                if (SQL.HasException(true))
                    return;

                LoadGC();

                ClearFields_GC();

                new Notification().PopUp("Item deleted.", "", "information");
            }
        }

        private void txtGC_Search_KeyUp(object sender, KeyEventArgs e)
        {
            SQL.AddParam("@find", txtGC_Search.Text + "%");

            SQL.Query("SELECT giftcardID, giftcard_no as 'GC No.' FROM giftcard WHERE giftcard_no LIKE @find ORDER BY giftcard_no ASC");

            if (SQL.HasException(true))
                return;

            dgvGC.DataSource = SQL.DBDT;
            dgvGC.Columns[0].Visible = false;
        }

        private void btnRI_RemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvRI_RedeemItems.SelectedRows.Count == 0)
                return;

            for(int i = 0; i<=dgvRI_RedeemItems.SelectedRows.Count-1; i++)
            {
                SQL.AddParam("@redeemID", dgvRI_RedeemItems.Rows[i].Cells[0].Value.ToString());
                SQL.Query("DELETE FROM redeem_items WHERE redeemID = @redeemID");

                if (SQL.HasException(true))
                    return;
            }


            LoadRedeemItems();

            redeemID = "";
            txtRI_RedeemItem.Clear();
            txtRI_Points.Clear();
        }

        private void btnRI_AddItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dgvRI_Items.SelectedRows.Count.ToString());
            if (dgvRI_Items.SelectedRows.Count == 0)
                return;

            foreach (DataGridViewRow r in dgvRI_Items.SelectedRows)
            {
                SQL.AddParam("@productID", r.Cells[0].Value.ToString());
                int check_item = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM redeem_items WHERE productID = @productID"));
                if (SQL.HasException(true))
                    return;

                if (check_item == 1)
                {
                    SQL.AddParam("@productID", r.Cells[0].Value.ToString());
                    SQL.Query("DELETE FROM redeem_items where productID=@productID");
                }


                SQL.AddParam("@productID", r.Cells[0].Value.ToString());
                SQL.AddParam("@description", r.Cells[1].Value.ToString());
                SQL.AddParam("@categoryID", r.Cells[2].Value.ToString());
                SQL.AddParam("@barcode1", r.Cells[3].Value.ToString());
                SQL.AddParam("@barcode2", r.Cells[4].Value.ToString());

                SQL.Query("INSERT INTO redeem_items (productID, description, pts, categoryID, barcode1, barcode2) VALUES (@productID, @description, 0, @categoryID, @barcode1, @barcode2)");

                if (SQL.HasException(true))
                    return;
            }

            new Notification().PopUp("Edit in the next table.", "Item saved", "information");

            LoadRedeemItems();
        }

        private void dgvRI_RedeemItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@redeemID", dgvRI_RedeemItems.CurrentRow.Cells[0].Value.ToString());
            SQL.Query("SELECT * FROM redeem_items WHERE redeemID = @redeemID");

            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                redeemID = r["redeemID"].ToString();
                txtRI_RedeemItem.Text = r["description"].ToString();
                txtRI_Points.Text = r["pts"].ToString();
            }
        }

        private void btnRI_SortItems_Click(object sender, EventArgs e)
        {
            if (dgvRI_Items.RowCount == 0)
                return;

            if (btnRI_SortItems.IconChar == IconChar.SortAlphaDown)
            {
                dgvRI_Items.Sort(dgvRI_Items.Columns[1], ListSortDirection.Ascending);
                btnRI_SortItems.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvRI_Items.Sort(dgvRI_Items.Columns[1], ListSortDirection.Descending);
                btnRI_SortItems.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void btnRI_SortRedeem_Click(object sender, EventArgs e)
        {
            if (dgvRI_RedeemItems.RowCount == 0)
                return;

            if (btnRI_SortRedeem.IconChar == IconChar.SortAlphaDown)
            {
                dgvRI_RedeemItems.Sort(dgvRI_RedeemItems.Columns[2], ListSortDirection.Ascending);
                btnRI_SortRedeem.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvRI_RedeemItems.Sort(dgvRI_RedeemItems.Columns[2], ListSortDirection.Descending);
                btnRI_SortRedeem.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void btnRI_Save_Click(object sender, EventArgs e)
        {
            if (redeemID == "")
            {
                new Notification().PopUp("No item selected.", "Error", "error");
                return;
            }

            RIRF();
            int requiredFieldsMet = RequireField(ref requiredFields);

            if (requiredFieldsMet == 1)
            {
                SQL.AddParam("@redeemID", redeemID);
                SQL.AddParam("@pts", txtRI_Points.Text);

                SQL.Query("UPDATE redeem_items SET pts = @pts WHERE redeemID = @redeemID");

                if (SQL.HasException(true))
                    return;

                new Notification().PopUp("Data saved.", "", "information");
            }
            else
                new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
        }

        private void txtRI_SearchItem_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRI_SearchItem.Text == "")
                LoadItems();
            else
            {
                SQL.AddParam("@find", txtRI_SearchItem.Text + "%");

                SQL.Query(@"SELECT productID, description as 'Description', categoryID, barcode1, barcode2 FROM products WHERE 
                           description LIKE @find OR barcode1 LIKE @find OR barcode2 LIKE @find ORDER BY description ASC");

                if (SQL.HasException(true))
                    return;

                dgvRI_Items.DataSource = SQL.DBDT;
                dgvRI_Items.Columns[0].Visible = false;
                dgvRI_Items.Columns[2].Visible = false;
                dgvRI_Items.Columns[3].Visible = false;
                dgvRI_Items.Columns[4].Visible = false;
            }
        }

        private void txtRI_SearchRedeem_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRI_SearchRedeem.Text == "")
                LoadRedeemItems();
            else
            {
                SQL.AddParam("@find", txtRI_SearchRedeem.Text + "%");

                SQL.Query(@"SELECT redeemID, productID, description as 'Description' FROM redeem_items WHERE 
                           description LIKE @find OR barcode1 LIKE @find OR barcode2 LIKE @find ORDER BY description ASC");

                if (SQL.HasException(true))
                    return;

                dgvRI_RedeemItems.DataSource = SQL.DBDT;
                dgvRI_RedeemItems.Columns[0].Visible = false;
                dgvRI_RedeemItems.Columns[1].Visible = false;
            }
        }

        private void btnRI_SearchItems_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void btnRI_SearchRedeem_Click(object sender, EventArgs e)
        {
            LoadRedeemItems();
        }

        private void btnAPT_ExportReport_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Awarded Points Transaction", dgvAPT_Records);
        }

        private void btnAPT_Search_Click(object sender, EventArgs e)
        {
            string cus_query = "pa.cus_ID_no <> 0";

            if (cmbAPT_Customer.SelectedIndex != 0)
                cus_query = "pa.cus_ID_no = " + cmbAPT_Customer.SelectedValue;

            SQL.AddParam("@from", dtpAPT_From.Value);
            SQL.AddParam("@to", dtpAPT_To.Value);

            SQL.Query(@"SELECT pa.order_ref as 'ID', pa.order_ref_temp as 'Invoice #', td.date_time as 'Date', c.name as 'Customer', cash_paid as 'Amount Paid', pts_earned as 'Points Earned'
                       FROM points_award as pa INNER JOIN customer as c ON pa.cus_ID_no = c.customerID INNER JOIN transaction_details as td ON pa.order_ref = td.order_ref WHERE 
                       td.date_time BETWEEN @from AND @to AND " + cus_query + " ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgvAPT_Records.DataSource = SQL.DBDT;
            dgvAPT_Records.Columns[0].Visible = false;
        }

        private void btnAPT_Sort_Click(object sender, EventArgs e)
        {
            if (dgvAPT_Records.RowCount == 0)
                return;

            if (btnAPT_Sort.IconChar == IconChar.SortAlphaDown)
            {
                dgvAPT_Records.Sort(dgvAPT_Records.Columns[2], ListSortDirection.Ascending);
                btnAPT_Sort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvAPT_Records.Sort(dgvAPT_Records.Columns[2], ListSortDirection.Descending);
                btnAPT_Sort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void btnRT_Search_Click(object sender, EventArgs e)
        {
            string cus_query = "cus_ID_no <> 0";

            if (cmbRT_Customer.SelectedIndex != 0)
                cus_query = "cus_ID_no = " + cmbRT_Customer.SelectedValue;

            SQL.AddParam("@from", dtpRT_From.Value.ToShortDateString());
            SQL.AddParam("@to", dtpRT_To.Value.ToShortDateString());

            SQL.Query(@"SELECT order_ref as 'ID', order_ref_temp as 'Invoice #', date_time as 'Dates', c.name as 'Customer', cus_card_no 'Card No.',
                       total_pts as 'Total', card_balance_before as 'Previous Balance', card_balance_after as 'Remaining Points' FROM redeem_transaction as rt
                       INNER JOIN customer c ON rt.cus_ID_no = c.customerID WHERE date BETWEEN @from AND @to AND " + cus_query+" ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgvRT_Records.DataSource = SQL.DBDT;
            dgvRT_Records.Columns[0].Visible = false;
        }

        private void btnRT_Sort_Click(object sender, EventArgs e)
        {
            if (dgvRT_Records.RowCount == 0)
                return;

            if (btnRT_Sort.IconChar == IconChar.SortAlphaDown)
            {
                dgvRT_Records.Sort(dgvRT_Records.Columns[2], ListSortDirection.Ascending);
                btnRT_Sort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvRT_Records.Sort(dgvRT_Records.Columns[2], ListSortDirection.Descending);
                btnRT_Sort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void btnRT_ExportReport_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Redeem Transactions", dgvRT_Records);
        }

        private void btnRT_PrintReceipt_Click(object sender, EventArgs e)
        {
            if (dgvRT_ClickedOnce == false)
                return;

            reprint_receipt = new RedeemReceipt();

            DataSet ds = new DataSet();

            try
            {
                SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, total_pts FROM redeem_transaction_items WHERE order_ref = (SELECT MAX(order_ref) FROM redeem_transaction)", SQL.DBCon);
                SQL.DBDA.Fill(ds, "redeem_transaction_items");

                reprint_receipt.SetDataSource(ds);

                SQL.AddParam("@order_ref", dgvRT_Records.CurrentRow.Cells[0].Value.ToString());
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
                           WHERE order_ref = @order_ref");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    reprint_receipt.SetParameterValue("date_time", r["date_time"]);
                    reprint_receipt.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                    reprint_receipt.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                    decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                    reprint_receipt.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                    decimal total = decimal.Parse(r["total"].ToString());
                    reprint_receipt.SetParameterValue("total", total.ToString("N2"));
                    decimal balance = decimal.Parse(r["balance"].ToString());
                    reprint_receipt.SetParameterValue("balance", balance.ToString("N2"));
                    decimal remaining_pts = decimal.Parse(r["remaining_pts"].ToString());
                    reprint_receipt.SetParameterValue("remaining_pts", remaining_pts.ToString("N2"));
                    reprint_receipt.SetParameterValue("cus_name", r["cus_name"].ToString());
                    reprint_receipt.SetParameterValue("cus_card_no", r["cus_card_no"].ToString());
                }

                reprint_receipt.SetParameterValue("business_name", Main.Instance.sd_business_name);
                reprint_receipt.SetParameterValue("business_address", Main.Instance.sd_business_address);
                reprint_receipt.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                reprint_receipt.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                reprint_receipt.SetParameterValue("sn", Main.Instance.sd_sn);
                reprint_receipt.SetParameterValue("min", Main.Instance.sd_min);
                reprint_receipt.SetParameterValue("footer_text", Main.Instance.rl_footer_text);
                reprint_receipt.SetParameterValue("note", "###REPRINT###");
            }
            catch (Exception ex)
            {
                new Notification().PopUp(ex.Message, "Error printing", "error");
                reprint_receipt.Dispose();
            }

            if (Main.Instance.pd_receipt_printer == "")
            {
                new Notification().PopUp("No receipt printer selected.", "Error printing", "error");
                return;
            }


            bool checkprinter = Main.PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("Printer is offline", "Error", "error");
                return;
            }


            reprint_receipt.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
            reprint_receipt.PrintOptions.PaperSource = PaperSource.Auto;
            reprint_receipt.PrintToPrinter(1, false, 0, 0);
        }

        private void dgvRT_Records_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            dgvRT_ClickedOnce = true;

            DataSet ds = new DataSet();

            report = new RedeemTransactionReport();

            try
            {
                CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;
                SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, total_pts FROM redeem_transaction_items WHERE order_ref = " + dgvRT_Records.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                SQL.DBDA.Fill(ds, "redeem_transaction_items");

                report.SetDataSource(ds);

                SQL.AddParam("@order_ref", dgvRT_Records.CurrentRow.Cells[0].Value.ToString());
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
                           WHERE order_ref = @order_ref");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    report.SetParameterValue("date_time", r["date_time"].ToString());
                    report.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                    report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                    decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                    report.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                    decimal total = decimal.Parse(r["total"].ToString());
                    report.SetParameterValue("total", total.ToString("N2"));
                    decimal balance = decimal.Parse(r["balance"].ToString());
                    report.SetParameterValue("balance", balance.ToString("N2"));
                    decimal remaining_pts = decimal.Parse(r["remaining_pts"].ToString());
                    report.SetParameterValue("remaining_pts", remaining_pts.ToString("N2"));
                    report.SetParameterValue("cus_name", r["cus_name"].ToString());
                    report.SetParameterValue("cus_card_no", r["cus_card_no"].ToString());
                }

                CrystalReportViewer1.ReportSource = report;
                CrystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                new Notification().PopUp(ex.Message, "Error", "error");
                report.Dispose();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dgvRI_Items.RowCount > 0)
            {
                dgvRI_Items.SelectAll();
                //// check if item is already chosen
                //DataGridViewRow datarow = new DataGridViewRow();
                //for (int rows = 0; rows <= dgvRI_Items.Rows.Count - 1; rows++)
                //{
                //    int counter = 0;
                //    for (var i = 0; i <= dgvRI_Items.RowCount - 1; i++)
                //    {
                //        if (dgvRI_Items.Rows[rows].Cells[0].Value.ToString() == dgvRI_Items.Rows[i].Cells[0].Value.ToString())
                //            counter = 1;
                //    }

                //    // if not chosen then add
                //    if (counter == 0)
                //        dgvRI_Items.Rows.Add(dgvRI_Items.Rows[rows].Cells[0].Value, dgvRI_Items.Rows[rows].Cells[1].Value, 0);
                //}
            }
            else if (dgvRI_Items.RowCount == 0)
            {
                DataGridViewRow datarow = new DataGridViewRow();
                for (int rows = 0; rows <= dgvRI_Items.Rows.Count - 1; rows++)
                    dgvRI_Items.Rows.Add(dgvRI_Items.Rows[rows].Cells[0].Value, dgvRI_Items.Rows[rows].Cells[1].Value, 0);
            }
        }

        private void dgvRI_Items_MouseEnter(object sender, EventArgs e)
        {
            keybd_event(VK_CONTROL, (byte)0, 0, 0);
        }

        private void dgvRI_Items_MouseLeave(object sender, EventArgs e)
        {
            keybd_event(VK_CONTROL, (byte)0, KEYEVENTF_KEYUP, 0);
        }
    }
}
