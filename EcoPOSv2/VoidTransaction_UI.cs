using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class VoidTransaction_UI : Form
    {
        public VoidTransaction_UI()
        {
            InitializeComponent();
        }
        public string order_ref_temp, order_ref;

        SQLControl SQL = new SQLControl();
        decimal currentQuantity = 0;
        PaymentR58 report = new PaymentR58();
        PaymentReceipt80 report80 = new PaymentReceipt80();
        public static VoidTransaction_UI _VoidTransaction_UI;

        public string terminalNo;
        public static VoidTransaction_UI Instance
        {
            get
            {
                if (_VoidTransaction_UI == null)
                {
                    _VoidTransaction_UI = new VoidTransaction_UI();
                }
                return _VoidTransaction_UI;
            }
        }
        //METHODS
        BackgroundWorker workerLoadToVoidItems;

        DataTable dtToBeVoid = new DataTable();
        void LoadToBeVoid()
        {
            DataColumn order_ref1 = new DataColumn();
            DataColumn itemID = new DataColumn();
            DataColumn productID = new DataColumn();
            DataColumn description = new DataColumn();
            DataColumn name = new DataColumn();
            DataColumn quantity = new DataColumn();
            DataColumn sellingprice = new DataColumn();

            order_ref1.ColumnName = "order_ref";
            itemID.ColumnName = "itemID";
            productID.ColumnName = "productID";
            description.ColumnName = "Description";
            name.ColumnName = "Name";
            quantity.ColumnName = "Quantity";
            sellingprice.ColumnName = "SellingPrice";

            dtToBeVoid.Columns.Add(order_ref1);
            dtToBeVoid.Columns.Add(itemID);
            dtToBeVoid.Columns.Add(productID);
            dtToBeVoid.Columns.Add(description);
            dtToBeVoid.Columns.Add(name);
            dtToBeVoid.Columns.Add(quantity);
            dtToBeVoid.Columns.Add(sellingprice);


            dgvVoidList.DataSource = dtToBeVoid;

            dgvVoidList.Columns[0].Visible = false;
            dgvVoidList.Columns[1].Visible = false;
            dgvVoidList.Columns[2].Visible = false;
        }
        void LoadToVoidItems()
        {
            workerLoadToVoidItems = new BackgroundWorker();

            workerLoadToVoidItems.DoWork += WorkerLoadToVoidItems_DoWork;
            workerLoadToVoidItems.RunWorkerAsync();
        }
        private void WorkerLoadToVoidItems_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                SQLControl psql = new SQLControl();

                psql.AddParam("@order_ref", int.Parse(order_ref));
                psql.Query("select order_ref,itemID,productID,description as 'Description',name as 'Name',quantity as 'Quantity', selling_price_inclusive as 'Price' from transaction_items where order_ref = @order_ref");

                if (psql.HasException(true)) return;

                dgvToVoidList.DataSource = psql.DBDT;

                dgvToVoidList.Columns[0].Visible = false;
                dgvToVoidList.Columns[1].Visible = false;
                dgvToVoidList.Columns[2].Visible = false;
            }));
        }


        private void GenerateReceipt()
        {
            bool checkprinter = Main.PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("Printer is offline", "Error", "error");
                return;
            }

            if (Properties.Settings.Default.papersize == "58MM")
            {
                DataSet ds = new DataSet();

                try
                {
                    SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive as static_price_inclusive, selling_price_inclusive as selling_price_inclusive FROM transaction_items    INNER JOIN transaction_details ON transaction_details.order_ref = transaction_items.order_ref  WHERE transaction_details.order_ref_temp = " + order_ref_temp, SQL.DBCon);
                    SQL.DBDA.Fill(ds, "transaction_items");

                    report.SetDataSource(ds);
                    SQL.AddParam("@terminal_id", terminalNo);
                    SQL.AddParam("@order_ref_temp", order_ref_temp);
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
                           transaction_details.order_ref_temp as 'order_ref_temp', 
                           u.first_name as 'user_first_name', 
                           no_of_items, 
                           subtotal, 
                           less_vat, 
                           disc_amt, 
                           cus_pts_deducted, 
                           grand_total,
                           vatable_sale,
                           vat_12,
                           vat_exempt_sale,
                           zero_rated_sale,
                           payment_amt,
                           payment_method,
                           change,
                           giftcard_no, 
                           giftcard_deducted,
                           IIF(cus_name = '', '0', cus_name) as 'cus_name',
                           cus_special_ID_no,
                           transaction_details.terminal_id,transaction_details.referenceNo,
                           vt.void_order_ref_temp as 'void_order_ref_temp'
                           FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                           INNER JOIN void_transaction as vt ON transaction_details.order_ref = vt.order_ref
                           WHERE transaction_details.terminal_id=@terminal_id AND transaction_details.order_ref_temp = @order_ref_temp");

                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("1 Print");
                        return;
                    }

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("Terminal_No", r["terminal_id"].ToString());
                        report.SetParameterValue("date_time", r["date_time"].ToString());
                        report.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        //report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        //report.SetParameterValue("Terminal_No", terminalNo);
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        report.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                        decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                        report.SetParameterValue("subtotal", subtotal.ToString("N2"));
                        decimal less_vat = decimal.Parse(r["less_vat"].ToString());
                        report.SetParameterValue("less_vat", less_vat.ToString("N2"));
                        decimal disc_amt = decimal.Parse(r["disc_amt"].ToString());
                        report.SetParameterValue("discount", disc_amt.ToString("N2"));
                        decimal cus_pts_deducted = decimal.Parse(r["cus_pts_deducted"].ToString());
                        report.SetParameterValue("points_deduct", cus_pts_deducted.ToString("N2"));
                        decimal giftcard_deducted = decimal.Parse(r["giftcard_deducted"].ToString());
                        report.SetParameterValue("giftcard_deduct", giftcard_deducted.ToString("N2"));
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                        report.SetParameterValue("total", grand_total.ToString("N2"));
                        decimal vatable_sale = decimal.Parse(r["vatable_sale"].ToString());
                        report.SetParameterValue("vatable_sales", vatable_sale.ToString("N2"));
                        decimal vat_12 = decimal.Parse(r["vat_12"].ToString());
                        report.SetParameterValue("vat_12", vat_12.ToString("N2"));
                        decimal vat_exempt_sale = decimal.Parse(r["vat_exempt_sale"].ToString());
                        report.SetParameterValue("vat_exempt_sales", vat_exempt_sale.ToString("N2"));
                        decimal zero_rated_sale = decimal.Parse(r["zero_rated_sale"].ToString());
                        report.SetParameterValue("zero_rated_sales", zero_rated_sale.ToString("N2"));
                        decimal giftcard_no = decimal.Parse(r["giftcard_no"].ToString());
                        report.SetParameterValue("giftcard_no", giftcard_no.ToString("N2"));
                        decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                        report.SetParameterValue("cash", payment_amt.ToString("N2"));
                        decimal change = decimal.Parse(r["change"].ToString());
                        report.SetParameterValue("change", change.ToString("N2"));
                        if (r["cus_name"].ToString() == "0" || r["cus_name"].ToString() == "")
                        {
                            report.SetParameterValue("cus_name", "________________________________________________________");
                        }
                        else
                        {
                            report.SetParameterValue("cus_name", r["cus_name"].ToString());
                        }


                        if (r["cus_special_ID_no"].ToString() == "0")
                        {
                            report.SetParameterValue("cus_sc_pwd_id", "________________________________________________________");
                        }
                        else
                        {
                            report.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                        }
                        report.SetParameterValue("payment_method", r["payment_method"].ToString());
                        report.SetParameterValue("note", "VOID # " + r["void_order_ref_temp"].ToString());
                        
                        //Online Payment Reference No
                        report.SetParameterValue("ReferenceNumber", r["referenceNo"].ToString());
                    }


                    report.SetParameterValue("business_name", Main.Instance.sd_business_name);
                    report.SetParameterValue("business_address", Main.Instance.sd_business_address);
                    report.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                    report.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                    report.SetParameterValue("sn", Main.Instance.sd_sn);
                    report.SetParameterValue("min", Main.Instance.sd_min);
                    report.SetParameterValue("footer_text", Main.Instance.sd_footer_text);
                    report.SetParameterValue("ptu_no", Main.Instance.sd_ptu_no);

                    DateTime dateissue = DateTime.Parse(Main.Instance.sd_pn_date_issued);
                    report.SetParameterValue("date_issued", dateissue.ToString("MM/dd/yyyy"));

                    DateTime validuntil = DateTime.Parse(Main.Instance.sd_pn_valid_until);
                    report.SetParameterValue("valid_until", validuntil.ToString("MM/dd/yyyy"));

                    if (Properties.Settings.Default.isBirAccredited)
                    {
                        report.SetParameterValue("is_vatable", true);
                        report.SetParameterValue("txt_footer", "THIS SERVES AS OFFICIAL RECEIPT.");
                    }
                    else
                    {
                        report.SetParameterValue("is_vatable", false);
                        report.SetParameterValue("txt_footer", "THIS SERVES AS DEMO RECEIPT.");
                    }
                }
                catch (Exception ex)
                {
                    new Notification().PopUp(ex.Message, "", "error");
                    report.Dispose();
                }

                if (Main.Instance.pd_receipt_printer == "")
                {
                    new Notification().PopUp("Error printing", "No receipt printer selected.");
                    return;
                }

                report.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                report.PrintOptions.PaperSource = PaperSource.Auto;
                report.PrintToPrinter(1, false, 0, 0);

                new Notification().PopUp("Transaction voided.", "", "information");

                Close();
            }
            else
            {
                DataSet ds = new DataSet();
                report80 = new PaymentReceipt80();

                try
                {
                    SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, (-1 * static_price_inclusive) as static_price_inclusive, 
                                                         (-1 * selling_price_inclusive) as selling_price_inclusive FROM transaction_items
                                                         INNER JOIN transaction_details ON transaction_details.order_ref = transaction_items.order_ref
                                                         WHERE transaction_details.order_ref_temp = " + order_ref_temp, SQL.DBCon);
                    SQL.DBDA.Fill(ds, "transaction_items");

                    report80.SetDataSource(ds);

                    SQL.AddParam("@terminal_id", terminalNo);
                    SQL.AddParam("@order_ref_temp", order_ref_temp);
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
                           transaction_details.order_ref_temp as 'order_ref_temp', 
                           u.first_name as 'user_first_name', 
                           no_of_items, 
                           subtotal, 
                           less_vat, 
                           disc_amt, 
                           cus_pts_deducted, 
                           grand_total,
                           vatable_sale,
                           vat_12,
                           vat_exempt_sale,
                           zero_rated_sale,
                           payment_amt,
                           payment_method,
                           change,
                           giftcard_no, 
                           giftcard_deducted,
                           IIF(cus_name = '', '0', cus_name) as 'cus_name',
                           cus_special_ID_no,
                           transaction_details.terminal_id,transaction_details.referenceNo,
                           vt.void_order_ref_temp as 'void_order_ref_temp'
                           FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                           INNER JOIN void_transaction as vt ON transaction_details.order_ref = vt.order_ref
                           WHERE transaction_details.terminal_id=@terminal_id AND transaction_details.order_ref_temp = @order_ref_temp");

                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("1 Print");
                        return;
                    }

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report80.SetParameterValue("Terminal_No", r["terminal_id"].ToString());
                        report80.SetParameterValue("date_time", r["date_time"].ToString());
                        report80.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        report80.SetParameterValue("user_first_name", Main.Instance.current_username);
                        report80.SetParameterValue("Terminal_No", Properties.Settings.Default.Terminal_id);
                        //report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        //report.SetParameterValue("Terminal_No", terminalNo);
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        report80.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                        decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                        report80.SetParameterValue("subtotal", subtotal.ToString("N2"));
                        decimal less_vat = decimal.Parse(r["less_vat"].ToString());
                        report80.SetParameterValue("less_vat", less_vat.ToString("N2"));
                        decimal disc_amt = decimal.Parse(r["disc_amt"].ToString());
                        report80.SetParameterValue("discount", disc_amt.ToString("N2"));
                        decimal cus_pts_deducted = decimal.Parse(r["cus_pts_deducted"].ToString());
                        report80.SetParameterValue("points_deduct", cus_pts_deducted.ToString("N2"));
                        decimal giftcard_deducted = decimal.Parse(r["giftcard_deducted"].ToString());
                        report80.SetParameterValue("giftcard_deduct", giftcard_deducted.ToString("N2"));
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                        report80.SetParameterValue("total", grand_total.ToString("N2"));
                        decimal vatable_sale = decimal.Parse(r["vatable_sale"].ToString());
                        report80.SetParameterValue("vatable_sales", vatable_sale.ToString("N2"));
                        decimal vat_12 = decimal.Parse(r["vat_12"].ToString());
                        report80.SetParameterValue("vat_12", vat_12.ToString("N2"));
                        decimal vat_exempt_sale = decimal.Parse(r["vat_exempt_sale"].ToString());
                        report80.SetParameterValue("vat_exempt_sales", vat_exempt_sale.ToString("N2"));
                        decimal zero_rated_sale = decimal.Parse(r["zero_rated_sale"].ToString());
                        report80.SetParameterValue("zero_rated_sales", zero_rated_sale.ToString("N2"));
                        report80.SetParameterValue("giftcard_no", r["giftcard_no"].ToString());
                        decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                        report80.SetParameterValue("cash", payment_amt.ToString("N2"));
                        decimal change = decimal.Parse(r["change"].ToString());
                        report80.SetParameterValue("change", change.ToString("N2"));
                        report80.SetParameterValue("cus_name", r["cus_name"].ToString());
                        report80.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                        report80.SetParameterValue("payment_method", r["payment_method"].ToString());

                        report80.SetParameterValue("note", "VOID # " + r["void_order_ref_temp"].ToString());

                        //Online Payment Reference No
                        report80.SetParameterValue("ReferenceNo", r["referenceNo"].ToString());
                    }

                    report80.SetParameterValue("business_name", Main.Instance.sd_business_name);
                    report80.SetParameterValue("business_address", Main.Instance.sd_business_address);
                    report80.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                    report80.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                    report80.SetParameterValue("sn", Main.Instance.sd_sn);
                    report80.SetParameterValue("min", Main.Instance.sd_min);
                    report80.SetParameterValue("footer_text", Main.Instance.sd_footer_text);
                    report80.SetParameterValue("ptu_no", Main.Instance.sd_ptu_no);

                    DateTime dateissue = DateTime.Parse(Main.Instance.sd_pn_date_issued);
                    report80.SetParameterValue("date_issued", dateissue.ToString("MM/dd/yyyy"));

                    DateTime validuntil = DateTime.Parse(Main.Instance.sd_pn_valid_until);
                    report80.SetParameterValue("valid_until", validuntil.ToString("MM/dd/yyyy"));

                    if (Properties.Settings.Default.isBirAccredited)
                    {
                        report80.SetParameterValue("is_vatable", true);
                        report80.SetParameterValue("txt_footer", "This serves as Official Receipt.");
                    }
                    else
                    {
                        report80.SetParameterValue("is_vatable", false);
                        report80.SetParameterValue("txt_footer", "This serves as Demo Receipt.");
                    }
                }
                catch (Exception ex)
                {
                    new Notification().PopUp(ex.Message, "", "error");
                    report80.Dispose();
                }

                if (Main.Instance.pd_receipt_printer == "")
                {
                    new Notification().PopUp("Error printing", "No receipt printer selected.");
                    return;
                }

                report80.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                report80.PrintOptions.PaperSource = PaperSource.Auto;
                report80.PrintToPrinter(1, false, 0, 0);

                new Notification().PopUp("Transaction voided.", "", "information");

                Close();
                //PrintReceipt();
            }
        }
        //METHODS

        private void VoidTransaction_UI_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Are you sure do you want to cancel void transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
                else return;
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            btnVoid.Enabled = true;

            if (dgvVoidList.RowCount > 0)
            {
                // check if item is already chosen
                DataGridViewRow datarow = new DataGridViewRow();
                for (int rows = 0; rows <= dgvToVoidList.Rows.Count - 1; rows++)
                {
                    int counter = 0;
                    for (var i = 0; i <= dgvVoidList.RowCount - 1; i++)
                    {
                        if (dgvToVoidList.Rows[rows].Cells[4].Value.ToString() == dgvVoidList.Rows[i].Cells[4].Value.ToString())
                            counter = 1;
                    }

                    // if not chosen then add
                    if (counter == 0)
                        dtToBeVoid.Rows.Add(dgvToVoidList.Rows[rows].Cells[0].Value, dgvToVoidList.Rows[rows].Cells[1].Value, dgvToVoidList.Rows[rows].Cells[2].Value, dgvToVoidList.CurrentRow.Cells[3].Value, dgvToVoidList.Rows[rows].Cells[4].Value, dgvToVoidList.Rows[rows].Cells[5].Value, dgvToVoidList.Rows[rows].Cells[6].Value);
                }
            }
            else if (dgvVoidList.RowCount == 0)
            {
                foreach(DataGridViewRow dr in dgvToVoidList.Rows)
                {
                    dtToBeVoid.Rows.Add(dr.Cells[0].Value, dr.Cells[1].Value, dr.Cells[2].Value, dr.Cells[3].Value, dr.Cells[4].Value, dr.Cells[5].Value, dr.Cells[6].Value);
                }
            }

            //COMPUTE TOTAL RETURN MONEY

            decimal Total = 0;

            for (int i = 0; i < dgvVoidList.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dgvVoidList.Rows[i].Cells["SellingPrice"].Value);
            }

            lblCashReturn.Text = Total.ToString();
        }

        private void DgvToVoidList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // transfer from DGV VOID List
            if (e.RowIndex == -1)
                return;

            btnVoid.Enabled = true;

            if (dgvVoidList.RowCount > 0)
            {
                for (var i = 0; i <= dgvVoidList.RowCount - 1; i++)
                {
                    if (dgvVoidList.Rows[i].Cells[4].Value.ToString() == dgvToVoidList.CurrentRow.Cells[4].Value.ToString())
                        return;
                }
                dtToBeVoid.Rows.Add(dgvToVoidList.CurrentRow.Cells[0].Value, dgvToVoidList.CurrentRow.Cells[1].Value, dgvToVoidList.CurrentRow.Cells[2].Value, dgvToVoidList.CurrentRow.Cells[3].Value, dgvToVoidList.CurrentRow.Cells[4].Value, dgvToVoidList.CurrentRow.Cells[5].Value, dgvToVoidList.CurrentRow.Cells[6].Value);
            }
            else if (dgvVoidList.RowCount == 0)
            {
                dtToBeVoid.Rows.Add(dgvToVoidList.CurrentRow.Cells[0].Value, dgvToVoidList.CurrentRow.Cells[1].Value, dgvToVoidList.CurrentRow.Cells[2].Value, dgvToVoidList.CurrentRow.Cells[3].Value, dgvToVoidList.CurrentRow.Cells[4].Value, dgvToVoidList.CurrentRow.Cells[5].Value, dgvToVoidList.CurrentRow.Cells[6].Value);
            }

            lblNoOfItemsToVoid.Text = dgvVoidList.Rows.Count.ToString();
            if (lblNoOfItemsToVoid.Text == "0")
                btnVoid.Enabled = false;

            //COMPUTE TOTAL RETURN MONEY
            decimal Total = 0;

            for (int i = 0; i < dgvVoidList.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dgvVoidList.Rows[i].Cells["SellingPrice"].Value);
            }

            lblCashReturn.Text = Total.ToString();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvVoidList.SelectedRows.Count == 0)
                return;
            else
            {
                foreach (DataGridViewRow dr in dgvVoidList.SelectedRows)
                {
                    dgvVoidList.Rows.Remove(dr);
                }
            }

            lblNoOfItemsToVoid.Text = dgvVoidList.Rows.Count.ToString();

            if (lblNoOfItemsToVoid.Text == "0")
                btnVoid.Enabled = false;


            //COMPUTE TOTAL RETURN MONEY
            decimal Total = 0;

            for (int i = 0; i < dgvVoidList.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dgvVoidList.Rows[i].Cells["SellingPrice"].Value);
            }

            lblCashReturn.Text = Total.ToString();
        }

        private void TbSearch_Enter(object sender, EventArgs e)
        {
            if(tbSearch.Text == "Search")
            {
                tbSearch.Text = "";
                tbSearch.ForeColor = Color.Black;
            }
        }

        private void TbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                tbSearch.Text = "Search";
                tbSearch.ForeColor = Color.Gray;
            }
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbSearch.Text == "Search")
                {
                    return;
                }

                (dgvToVoidList.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("description LIKE '{0}%' OR name LIKE '{0}%'", tbSearch.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void GunaControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void VoidTransaction_UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            VoidTransaction.Instance.btnCancel.PerformClick();
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            if (dgvVoidList.Rows.Count == 0)
            {
                MessageBox.Show("Please select item to void in order to proceed.", "Void error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal MinusToTransactionDetails = 0,QuantityMinusToTransactionDetails = 0;

            SQLControl SQL = new SQLControl();

            SQL.AddParam("@order_ref_temp", order_ref_temp);
            SQL.AddParam("@terminal_id", terminalNo);
            SQL.Query("UPDATE transaction_details SET action = 4 WHERE terminal_id=@terminal_id AND order_ref_temp = @order_ref_temp");
            if (SQL.HasException(true))
            {
                MessageBox.Show("1");
                return;
            }
                

            SQL.AddParam("@order_ref", order_ref);
            SQL.AddParam("@terminal_id", terminalNo);
            SQL.Query("INSERT INTO void_transaction (order_ref,terminal_id) VALUES (@order_ref,@terminal_id)");
            if (SQL.HasException(true))
            {
                MessageBox.Show("2");
                return;
            }

            foreach (DataGridViewRow dr in dgvVoidList.Rows)
            {
                //return items to inventory
                SQL.AddParam("@order_ref", order_ref);
                SQL.AddParam("@itemID", dr.Cells[1].Value);
                SQL.AddParam("@terminal_id", terminalNo);

                SQL.Query("SELECT productID, quantity,order_ref FROM transaction_items WHERE terminal_id=@terminal_id AND order_ref = @order_ref AND itemID=@itemID");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("3");
                    return;
                }

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    SQL.AddParam("@productID", r["productID"].ToString());
                    SQL.AddParam("@quantity", r["quantity"].ToString());

                    SQL.Query("UPDATE inventory SET stock_qty = stock_qty + @quantity WHERE productID = @productID");
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("4");
                        return;
                    }

                    // save to void item
                    SQL.AddParam("@productID", r["productID"].ToString());
                    SQL.AddParam("@userID", Main.Instance.current_id);
                    SQL.AddParam("@order_ref", r["order_ref"].ToString());

                    SQL.Query(@"INSERT INTO void_item (itemID, productID, order_no, description, name, type, static_price_exclusive,
                       static_price_vat, static_price_inclusive, quantity, userID) SELECT itemID, productID, 
                       (SELECT order_no FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)), description, 
                       name, type, static_price_exclusive, static_price_vat, static_price_inclusive, quantity, @userID
                       FROM transaction_items WHERE productID = @productID AND order_ref = @order_ref");

                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("5");
                        return;
                    }
                }

                //UPDATE PROFIT
                SQL.AddParam("@order_ref", order_ref);
                SQL.AddParam("@itemID", dr.Cells[1].Value);
                SQL.AddParam("@terminal_id", terminalNo);
                decimal Total_Sales_Per_Transaction = decimal.Parse(SQL.ReturnResult("select SUM(selling_price_inclusive) from transaction_items where terminal_id=@terminal_id AND order_ref=@order_ref AND itemID=@itemID"));
                if (SQL.HasException(true))
                {
                    MessageBox.Show("5.1");
                    return;
                }

                SQL.AddParam("@order_ref", order_ref);
                SQL.AddParam("@itemID", dr.Cells[1].Value);
                SQL.AddParam("@terminal_id", terminalNo);

                decimal Total_Cost_Per_Transaction = decimal.Parse(SQL.ReturnResult("select SUM(cost * quantity) from transaction_items where terminal_id=@terminal_id AND order_ref=@order_ref AND itemID=@itemID"));
                if (SQL.HasException(true))
                {
                    MessageBox.Show("6");
                    return;
                }

                //MessageBox.Show("TotalSalesPerTransaction:"+Total_Sales_Per_Transaction.ToString() +"\n \n TotalCostPerTransaction: "+Total_Cost_Per_Transaction.ToString());

                SQL.AddParam("@Sales", Total_Sales_Per_Transaction);
                SQL.AddParam("@Total_Cost", Total_Cost_Per_Transaction);
                SQL.AddParam("@date", DateTime.Now.ToString("yyy-MM-dd"));
                SQL.AddParam("@terminal_id", terminalNo);
                SQL.Query("UPDATE profit set Sales = Sales-@Sales, Total_Cost= Total_Cost-@Total_Cost where terminal_id=@terminal_id AND date=@date");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("7");
                    return;
                }

                SQL.AddParam("@date", DateTime.Now.ToString("yyy-MM-dd"));
                SQL.AddParam("@terminal_id", terminalNo);
                SQL.Query("UPDATE profit set Gross = Sales-Total_Cost where terminal_id=@terminal_id AND date=@date");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("8");
                    return;
                }
                //END PROFIT


                //TRANSACTION DETAILS AND TRANSACTION ITEMS
                SQL.AddParam("@order_ref", order_ref);
                SQL.AddParam("@itemID", dr.Cells[1].Value);
                SQL.AddParam("@terminal_id", terminalNo);

                SQL.Query("UPDATE transaction_items set static_price_inclusive = -static_price_inclusive, selling_price_exclusive = -selling_price_exclusive,selling_price_inclusive= -selling_price_inclusive,cost=-cost where terminal_id=@terminal_id AND order_ref=@order_ref AND itemID=@itemID");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("9");
                    return;
                }

                //MAKE 0 DISCOUNT OF ORDER REF
                SQL.AddParam("@terminal_id", terminalNo);
                SQL.AddParam("@order_ref", order_ref);

                SQL.Query("UPDATE transaction_items SET discount=0 WHERE terminal_id=@terminal_id AND order_ref=@order_ref");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("9.1");
                    return;
                }

                SQL.AddParam("@order_ref", order_ref);
                SQL.AddParam("@itemID", dr.Cells[1].Value);
                SQL.AddParam("@terminal_id", terminalNo);

                decimal Total_Sales_Per_Transaction2 = decimal.Parse(SQL.ReturnResult("select SUM(selling_price_inclusive) from transaction_items where terminal_id=@terminal_id AND order_ref=@order_ref AND itemID=@itemID"));
                if (SQL.HasException(true))
                {
                    MessageBox.Show("10");
                    return;
                }
                SQL.AddParam("@order_ref", order_ref);
                SQL.AddParam("@itemID", dr.Cells[1].Value);
                currentQuantity = decimal.Parse(SQL.ReturnResult("SELECT quantity FROM transaction_items WHERE order_ref=@order_ref AND itemID=@itemID "));

                SQL.AddParam("@order_ref", order_ref);
                SQL.AddParam("@itemID", dr.Cells[1].Value);
                SQL.AddParam("@terminal_id", terminalNo);
                SQL.Query("UPDATE transaction_items set quantity=(-1 * quantity) where terminal_id=@terminal_id AND order_ref=@order_ref AND itemID=@itemID");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("11");
                    return;
                }
            }
            //MessageBox.Show(MinusToTransactionDetails.ToString() + " Minus to transaction Details");
            //MessageBox.Show(QuantityMinusToTransactionDetails.ToString() + " Quantity to minus to transaction Details");


            SQL.AddParam("@order_ref", order_ref);
            SQL.AddParam("@quantity", lblNoOfItemsToVoid.Text);
            SQL.AddParam("@MainTotal", lblCashReturn.Text);
            SQL.AddParam("@terminal_id", terminalNo);

            SQL.Query("UPDATE transaction_details set subtotal=(subtotal-@MainTotal),total=(total-@MainTotal),grand_total=(grand_total-@MainTotal),payment_amt=(payment_amt-@MainTotal),vat_12=0,vat_exempt_sale=0,disc_amt=0 where terminal_id=@terminal_id AND order_ref=@order_ref");
            if (SQL.HasException(true))
            {
                MessageBox.Show("12");
                return;
            }
            GenerateReceipt();
        }

        private void FontSetter()
        {
            int fontSize_regular = int.Parse(Properties.Settings.Default.RegularTextFont);
            int fontSize_products = int.Parse(Properties.Settings.Default.ProductListFont);
            int fontSize_bname = int.Parse(Properties.Settings.Default.TitleTextFont);
            int fontSize_bheader = int.Parse(Properties.Settings.Default.BusinessDetailsFont);
            int fontSize_transactionDetails = int.Parse(Properties.Settings.Default.TransactionDetailsFont);

            #region Font
            //header

            //Business Name
            ((FieldObject)report.ReportDefinition.ReportObjects["businessname1"]).ApplyFont(new Font("Arial", fontSize_bname, FontStyle.Bold));
            //Business details
            ((FieldObject)report.ReportDefinition.ReportObjects["businessaddress1"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["bcontact"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["btin"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["bsn"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["bmin"]).ApplyFont(new Font("Arial", fontSize_bheader, FontStyle.Regular));

            //Regular
            ((FieldObject)report.ReportDefinition.ReportObjects["rnote"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));

            ((TextObject)report.ReportDefinition.ReportObjects["tdatetitle"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
            ((TextObject)report.ReportDefinition.ReportObjects["tinvoicetitle"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
            ((TextObject)report.ReportDefinition.ReportObjects["tcashier"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
            ((TextObject)report.ReportDefinition.ReportObjects["tterminal"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));

            //Product List
            ((TextObject)report.ReportDefinition.ReportObjects["tqty"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Bold));
            //((TextObject)report.ReportDefinition.ReportObjects["tproducts"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Bold));
            ((TextObject)report.ReportDefinition.ReportObjects["tprice"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Bold));
            //((FieldObject)report.ReportDefinition.ReportObjects["quantity1"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["description1"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["sellingprice"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["txtstaticpriceinclusive"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Regular));

            //Transaction Details
            ((TextObject)report.ReportDefinition.ReportObjects["tnoofitems"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Bold));
            ((FieldObject)report.ReportDefinition.ReportObjects["noofitems1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Bold));

            ((TextObject)report.ReportDefinition.ReportObjects["tsubtotal"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["subtotal1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["tlessvat"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["lessvat1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["tdiscount"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["discount1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["tpoints"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["pointsdeduct1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["tgiftcard"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["giftcarddeduct1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["ttotal"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
            ((FieldObject)report.ReportDefinition.ReportObjects["total1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
            ((TextObject)report.ReportDefinition.ReportObjects["tvatablesales"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["vatablesales1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["tvatamount"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["vat121"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["tvatexempt"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["vatexemptsales1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["tzerorated"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["zeroratedsales1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["tgcno"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["giftcardno1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["tpaymentmethod"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
            ((FieldObject)report.ReportDefinition.ReportObjects["cash1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
            ((TextObject)report.ReportDefinition.ReportObjects["trefno"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["ReferenceNumber1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
            ((TextObject)report.ReportDefinition.ReportObjects["tchange"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
            ((FieldObject)report.ReportDefinition.ReportObjects["change1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));

            //Footer
            ((FieldObject)report.ReportDefinition.ReportObjects["footertext1"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
            ((FieldObject)report.ReportDefinition.ReportObjects["txtfooter1"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
            #endregion
        }

        private void VoidTransaction_UI_Load(object sender, EventArgs e)
        {
            _VoidTransaction_UI = this;

            //Font for reprinting process
            report.Dispose();
            report = new PaymentR58();
            Thread setFont = new Thread(FontSetter);
            setFont.Start();

            LoadToVoidItems();
            LoadToBeVoid();

            lblInvoice.Text = order_ref_temp;
            lblTerminalNo.Text = "Terminal " + terminalNo;
        }
    }
}
