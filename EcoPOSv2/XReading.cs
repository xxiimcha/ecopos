using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class XReading : Form
    {
        public XReading()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        XReadingReport58 report = new XReadingReport58();
        XReadingReport80 report80 = new XReadingReport80();

        string store_open_date_time = "";
        string shift_start_date_time = "";

        int store_open_userID;
        int shift_start_userID;

        private void XReading_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

            LoadXReadingRecords();
            TextboxValidation();
        }
        private void TextboxValidation()
        {
            AssignValidation(ref txt1000, ValidationType.Int_Only);
            AssignValidation(ref txt500, ValidationType.Int_Only);
            AssignValidation(ref txt200, ValidationType.Int_Only);
            AssignValidation(ref txt100, ValidationType.Int_Only);
            AssignValidation(ref txt50, ValidationType.Int_Only);
            AssignValidation(ref txt20, ValidationType.Int_Only);
            AssignValidation(ref txt10, ValidationType.Int_Only);
            AssignValidation(ref txt5, ValidationType.Int_Only);
            AssignValidation(ref txt1, ValidationType.Int_Only);
            AssignValidation(ref txt25c, ValidationType.Int_Only);
            AssignValidation(ref txt10c, ValidationType.Int_Only);
            AssignValidation(ref txt5c, ValidationType.Int_Only);
            AssignValidation(ref txt1c, ValidationType.Int_Only);
            AssignValidation(ref txtGC, ValidationType.Int_Only);
            AssignValidation(ref txtCredit, ValidationType.Int_Only);
            AssignValidation(ref txtDebit, ValidationType.Int_Only);
            AssignValidation(ref txtCheque, ValidationType.Int_Only);
            AssignValidation(ref txtGCash, ValidationType.Int_Only);
            AssignValidation(ref txtPayMaya, ValidationType.Int_Only);
            AssignValidation(ref txtGC, ValidationType.Price);
            AssignValidation(ref txtCredit, ValidationType.Price);
            AssignValidation(ref txtDebit, ValidationType.Price);
            AssignValidation(ref txtCheque, ValidationType.Price);
            AssignValidation(ref txtGCash, ValidationType.Price);
            AssignValidation(ref txtPayMaya, ValidationType.Price);
        }

        private void LoadXReadingRecords()
        {
            //string datetime_now = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            string datetime_now = DateTime.Now.ToString("MM/d/yyyy HH:mm:ss tt");

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            decimal starting_cash = Convert.ToDecimal(SQL.ReturnResult("SELECT starting_cash FROM shift WHERE shiftID = (SELECT MAX(shiftID) FROM shift WHERE terminal_id=@terminal_id) AND ended IS NULL"));

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
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
                       SELECT start_date_time, open_by_userID, u.user_name as 'username' 
                       FROM store_start INNER JOIN #Temp_users as u ON store_start.open_by_userID = u.ID 
                       WHERE zreading_ref = (SELECT MAX(zreading_ref) FROM store_start WHERE terminal_id=@terminal_id)");

            if (SQL.HasException(true))
            {
                MessageBox.Show("Load1");
                return;
            }

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                lblStoreOpen.Text = DateTime.Parse(r["start_date_time"].ToString()).ToString("MMM dd, yyyy hh:mm:ss tt") + ", " + r["username"].ToString(); ;
                lblStartingCash.Text = starting_cash.ToString();
                store_open_userID = Convert.ToInt32(r["open_by_userID"].ToString());
                store_open_date_time = r["start_date_time"].ToString();
            }

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query("SELECT * FROM shift WHERE shiftID = (SELECT MAX(shiftID) FROM shift WHERE terminal_id=@terminal_id)");
            if (SQL.HasException(true))
            {
                MessageBox.Show("Load2");
                return;
            }

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                shift_start_date_time = r["start"].ToString();
                lblStartShift.Text = DateTime.Parse(r["start"].ToString()).ToString("MMM dd, yyyy hh:mm:ss tt") + ", " + r["user_name"].ToString();
                shift_start_userID = Convert.ToInt32(r["userID"].ToString());
            }



            // transactions
            SQL.AddParam("@from", shift_start_date_time);
            SQL.AddParam("@to", datetime_now);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            lblTransactions.Text = SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE terminal_id=@terminal_id AND date_time BETWEEN @from AND @to");
            if (SQL.HasException(true))
            {
                MessageBox.Show("Load3");
                return;
            }

            // sales, discount/deductions, total net sales
            SQL.AddParam("@from", shift_start_date_time);
            SQL.AddParam("@to", datetime_now);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            int count_sdt = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE terminal_id=@terminal_id AND date_time BETWEEN @from AND @to AND (action = 1 OR action = 4)"));
            if (SQL.HasException(true))
            {
                MessageBox.Show("Load4");
                return;
            }
            if (count_sdt > 0)
            {
                SQL.AddParam("@from", shift_start_date_time);
                SQL.AddParam("@to", datetime_now);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                decimal adjustments = 0M;
                string adjustments123 = SQL.ReturnResult(@"SELECT ABS(SUM(ti.selling_price_inclusive)) FROM transaction_items as ti INNER JOIN void_transaction as vt
                                                                     ON vt.order_ref = ti.order_ref WHERE ti.selling_price_inclusive < 0 AND vt.void_date_time BETWEEN @from AND @to AND ti.terminal_id=@terminal_id");

                if(adjustments123 == "")
                {
                    adjustments = 0;
                }
                else
                {
                    adjustments = decimal.Parse(adjustments123.ToString());
                }

                if (SQL.HasException(true))
                {
                    MessageBox.Show("Load5");
                    return;
                }

                SQL.AddParam("@from", shift_start_date_time);
                SQL.AddParam("@to", datetime_now);
                SQL.AddParam("@adjustment", adjustments);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                SQL.Query(@"SELECT (SELECT SUM(ABS(subtotal))+@adjustment FROM transaction_details WHERE date_time BETWEEN @from AND @to) as 'subtotal', 
                           SUM(disc_amt + cus_pts_deducted) as 'discount', SUM(grand_total) as 'netsales' 
                           FROM transaction_details WHERE date_time BETWEEN @from AND @to AND (action = 1 OR action = 4) AND terminal_id=@terminal_id");

                if (SQL.HasException(true))
                {
                    MessageBox.Show("Load6");
                    return;
                }

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    lblSales.Text = Math.Round(decimal.Parse(r["subtotal"].ToString()),2).ToString();
                    lblDiscount.Text = Math.Round(decimal.Parse(r["discount"].ToString()), 2).ToString();
                    lblNetSales.Text = Math.Round(decimal.Parse(r["netsales"].ToString()), 2).ToString();
                }
            }
            else
            {
                lblSales.Text = "0.00";
                lblDiscount.Text = "0.00";
                lblNetSales.Text = "0.00";
            }

            // adjustment
            SQL.AddParam("@from", shift_start_date_time);
            SQL.AddParam("@to", datetime_now);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            int check_adjustment = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM void_transaction WHERE terminal_id=@terminal_id AND void_date_time BETWEEN @from AND @to"));
            if (SQL.HasException(true))
            {
                MessageBox.Show("Load7");
                return;
            }

            if (check_adjustment > 0)
            {
                SQL.AddParam("@from", shift_start_date_time);
                SQL.AddParam("@to", DateTime.Now);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                decimal adjustment1 = 0M;
                string adjustment123 = SQL.ReturnResult(@"SELECT ABS(SUM(ti.selling_price_inclusive)) FROM transaction_items as ti INNER JOIN void_transaction as vt
                                                                     ON vt.order_ref = ti.order_ref WHERE ti.selling_price_inclusive < 0 AND vt.void_date_time BETWEEN @from AND @to AND ti.terminal_id=@terminal_id").ToString();

                if(adjustment123 == "")
                {
                    adjustment1 = 0;
                }
                else
                {
                    adjustment1 = decimal.Parse(adjustment123);
                }

                lblAdjustments.Text = adjustment1.ToString("N2");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("Load8");
                    return;
                }
            }
            else
            {
                lblAdjustments.Text = "0.00";
            }
                

            // beginning and ending invoice
            SQL.AddParam("@from", shift_start_date_time);
            SQL.AddParam("@to", datetime_now);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            int check_invoices = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE terminal_id=@terminal_id AND date_time BETWEEN @from AND @to AND (action = 1 OR action = 4)"));

            if (SQL.HasException(true))
            {
                MessageBox.Show("Load9");
                return;
            }

            if (check_invoices > 0)
            {
                SQL.AddParam("@from", shift_start_date_time);
                SQL.AddParam("@to", datetime_now);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                SQL.Query("SELECT MIN(order_ref_temp) as 'beginning', MAX(order_ref_temp) as 'ending' FROM transaction_details WHERE terminal_id=@terminal_id AND date_time BETWEEN @from AND @to");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("Load10");
                    return;
                }

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    lblBeginningInvoice.Text = r["beginning"].ToString();
                    lblEndingInvoice.Text = r["ending"].ToString();
                }
            }
            else
            {
                lblBeginningInvoice.Text = "00000000";
                lblEndingInvoice.Text = "00000000";
            }

            // void beginning and ending invoice
            SQL.AddParam("@from", shift_start_date_time);
            SQL.AddParam("@to", datetime_now);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            int check_void_invoices = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM void_transaction WHERE terminal_id=@terminal_id AND void_date_time BETWEEN @from AND @to"));

            if (SQL.HasException(true))
            {
                MessageBox.Show("Load11");
                return;
            }

            if (check_void_invoices > 0)
            {
                SQL.AddParam("@from", shift_start_date_time);
                SQL.AddParam("@to", datetime_now);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                SQL.Query(@"SELECT MIN(void_order_ref_temp) as 'beginning', MAX(void_order_ref_temp) as 'ending' 
                            FROM void_transaction WHERE terminal_id=@terminal_id AND void_date_time BETWEEN @from AND @to");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("Load12");
                    return;
                }

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    lblVoidBeginningNo.Text = r["beginning"].ToString();
                    lblVoidEndingNo.Text = r["ending"].ToString();
                }
            }
            else
            {
                lblVoidBeginningNo.Text = "00000000";
                lblVoidEndingNo.Text = "00000000";
            }

            // expected drawer
            SQL.AddParam("@from", shift_start_date_time);
            SQL.AddParam("@to", datetime_now);
            SQL.AddParam("@starting_cash", System.Convert.ToDecimal(lblStartingCash.Text));
            SQL.AddParam("@adjustments", System.Convert.ToDecimal(lblAdjustments.Text));
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            double expectdrawer = double.Parse(SQL.ReturnResult(@"SELECT IIF((SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND terminal_id=@terminal_id) > 0,
                                                                            (SELECT (SUM(payment_amt - change) + @starting_cash) 
                                                                            FROM transaction_details WHERE date_time BETWEEN @from AND @to AND terminal_id=@terminal_id), 
                                                                            (@starting_cash))"));

            //double expectdrawer = double.Parse(SQL.ReturnResult(@"SELECT IIF((SELECT COUNT(*) FROM transaction_details WHERE date_time BETWEEN @from AND @to AND terminal_id=@terminal_id) > 0,
            //                                                                (SELECT (SUM(payment_amt - change) + @starting_cash - @adjustments) 
            //                                                                FROM transaction_details WHERE date_time BETWEEN @from AND @to AND terminal_id=@terminal_id), 
            //                                                                (@starting_cash))"));

            if (expectdrawer > 0)
            {
                lblExpectedDrawer.Text = expectdrawer.ToString("N2");
            }
            else
            {
                lblExpectedDrawer.Text = "0.00";
            }

            if (SQL.HasException(true))
            {
                MessageBox.Show("Load13");
                return;
            }


            SQL.AddParam("@from", shift_start_date_time);
            SQL.AddParam("@to", datetime_now);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query("SELECT payment_method, CONVERT(DECIMAL(18,2), SUM(payment_amt - change)) FROM transaction_details WHERE terminal_id=@terminal_id AND date_time BETWEEN @from AND @to AND (action = 1 OR action = 4) GROUP BY payment_method ORDER BY CASE WHEN payment_method = 'Cash' THEN 1 Else 2 END ASC");
            if (SQL.HasException(true))
            {
                MessageBox.Show("Load14");
                return;
            }
            dgvPaymentMethod.DataSource = SQL.DBDT;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //check xreading ref
            int xreading_ref = 1;
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            if (int.Parse(SQL.ReturnResult("SELECT COUNT(*) FROM xreading WHERE terminal_id = @terminal_id")) != 0)
            {
                if (SQL.HasException(true)) return;

                //add + 1 to xreading_ref
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                if (SQL.HasException(true)) return;
                xreading_ref = int.Parse(SQL.ReturnResult("SELECT MAX(xreading_ref) FROM xreading WHERE terminal_id=@terminal_id")) + 1;
            }

            SQL.AddParam("@store_open_date_time", store_open_date_time);
            SQL.AddParam("@store_open_userID", store_open_userID);
            SQL.AddParam("@shift_start_date_time", shift_start_date_time);
            SQL.AddParam("@shift_start_userID", shift_start_userID);
            SQL.AddParam("@no_of_transactions", lblTransactions.Text);
            SQL.AddParam("@beginning_invoice", lblBeginningInvoice.Text);
            SQL.AddParam("@ending_invoice", lblEndingInvoice.Text);
            SQL.AddParam("@void_beginning_no", lblVoidBeginningNo.Text);
            SQL.AddParam("@void_ending_no", lblVoidEndingNo.Text);
            SQL.AddParam("@starting_cash", Convert.ToDecimal(lblStartingCash.Text));
            SQL.AddParam("@sales", Convert.ToDecimal(lblSales.Text));
            SQL.AddParam("@discount_deductions", Convert.ToDecimal(lblDiscount.Text));
            SQL.AddParam("@adjustments", Convert.ToDecimal(lblAdjustments.Text));
            SQL.AddParam("@net_sales", Convert.ToDecimal(lblNetSales.Text));
            SQL.AddParam("@expected_drawer", Convert.ToDecimal(lblExpectedDrawer.Text));
            SQL.AddParam("@declared_drawer", Convert.ToDecimal(lblDeclaredDrawer.Text));
            SQL.AddParam("@short_over", Convert.ToDecimal(lblShortOver.Text));
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query(@"INSERT INTO xreading (store_open_date_time, store_open_userID, shift_start_date_time, shift_start_userID, shift_end_date_time, no_of_transactions, 
                       beginning_invoice, ending_invoice, void_beginning_no, void_ending_no, starting_cash, sales, adjustments, discount_deductions, net_sales, 
                       expected_drawer, declared_drawer, short_over, terminal_id) VALUES (@store_open_date_time, @store_open_userID, @shift_start_date_time, 
                       @shift_start_userID, (SELECT GETDATE()), @no_of_transactions, @beginning_invoice, @ending_invoice, @void_beginning_no, @void_ending_no, 
                       @starting_cash, @sales, @adjustments, @discount_deductions, @net_sales, @expected_drawer, @declared_drawer, @short_over, @terminal_id)");

            if (SQL.HasException(true))
            {
                MessageBox.Show("1");
                return;
            }
                
            // save cashier declaration

            decimal GC = 0;
            decimal debit = 0;
            decimal credit = 0;
            decimal cheque = 0;
            decimal gcash = 0;
            decimal paymaya = 0;

            if (txtGC.Text != "")
                GC = System.Convert.ToDecimal(txtGC.Text);
            if (txtDebit.Text != "")
                debit = System.Convert.ToDecimal(txtDebit.Text);
            if (txtCredit.Text != "")
                credit = System.Convert.ToDecimal(txtCredit.Text);
            if (txtCheque.Text != "")
                cheque = System.Convert.ToDecimal(txtCheque.Text);
            if (txtGCash.Text != "")
                gcash = System.Convert.ToDecimal(txtGCash.Text);
            if (txtPayMaya.Text != "")
                paymaya = System.Convert.ToDecimal(txtPayMaya.Text);


            SQL.AddParam("@bill_1000", txt1000.Text);
            SQL.AddParam("@bill_500", txt500.Text);
            SQL.AddParam("@bill_200", txt200.Text);
            SQL.AddParam("@bill_100", txt100.Text);
            SQL.AddParam("@bill_50", txt50.Text);
            SQL.AddParam("@bill_20", txt20.Text);
            SQL.AddParam("@coin_10", txt10.Text);
            SQL.AddParam("@coin_5", txt5.Text);
            SQL.AddParam("@coin_1", txt1.Text);
            SQL.AddParam("@coin_25c", txt25c.Text);
            SQL.AddParam("@coin_10c", txt10c.Text);
            SQL.AddParam("@coin_5c", txt5c.Text);
            SQL.AddParam("@coin_1c", txt1c.Text);
            SQL.AddParam("@gift_card", GC);
            SQL.AddParam("@debit_card", debit);
            SQL.AddParam("@credit_card", credit);
            SQL.AddParam("@cheque", cheque);
            SQL.AddParam("@gcash", gcash);
            SQL.AddParam("@paymaya", paymaya);
            SQL.AddParam("@total", System.Convert.ToDecimal(lblTotalAmount.Text));
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query(@"INSERT INTO cashier_declaration (reading_ref_temp, reading_type, bill_1000, bill_500, bill_200, bill_100, bill_50, bill_20, coin_10, 
                       coin_5, coin_1, coin_25c, coin_10c, coin_5c, coin_1c, gift_card, debit_card, credit_card, cheque, gcash, paymaya, total) VALUES 
                       ((SELECT MAX(xreading_ref_temp) FROM xreading WHERE terminal_id=@terminal_id), 'X', @bill_1000, @bill_500, @bill_200, @bill_100, @bill_50, @bill_20, @coin_10, @coin_5, 
                       @coin_1, @coin_25c, @coin_10c, @coin_5c, @coin_1c, @gift_card, @debit_card, @credit_card, @cheque, @gcash, @paymaya, @total)");

            if (SQL.HasException(true))
            {
                MessageBox.Show("2");
                return;
            }


            // generate report
            GenerateReport();

            // log out
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query("UPDATE shift SET ended = (SELECT GETDATE()) WHERE shiftID = (SELECT MAX(shiftID) FROM shift WHERE terminal_id=@terminal_id)");
            if (SQL.HasException(true))
            {
                MessageBox.Show("3");
                return;
            }

            Main.Instance.close = true;
            Main.Instance.Close();

            //Main.Instance.UpdateMemberCards();
            //Main.Instance.UpdateGiftCards();
            SQLControl sql = new SQLControl();
            Boolean EnableSaveByTime = Boolean.Parse(sql.ReturnResult("SELECT backup_by_end_shift FROM backup_setting"));
            if (EnableSaveByTime)
            {
                DatabaseManagement.Instance.BackupDatabaseInFolder();
            }

            Environment.Exit(0);
            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }
        private void GenerateReport()
        {
            if (Properties.Settings.Default.papersize == "58MM")
            {
                report = new XReadingReport58();

                DataSet ds = new DataSet();

                string datetime_now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
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
                           SELECT xreading.*, u.user_name as 'store_userID', 
                           us.user_name as 'shift_userID' FROM xreading INNER JOIN #Temp_users as u
                           ON xreading.store_open_userID = u.ID INNER JOIN
                           #Temp_users as us ON xreading.shift_start_userID = us.ID WHERE 
                           xreading_ref = (SELECT MAX(xreading_ref) FROM xreading WHERE terminal_id=@terminal_id)");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    ////ORIGINAL
                    //report.SetParameterValue("xreading_ref_temp", r["xreading_ref_temp"].ToString());
                    //report.SetParameterValue("store_open_date_time", r["store_open_date_time"].ToString());
                    //report.SetParameterValue("store_open_userID", r["store_userID"].ToString());
                    //report.SetParameterValue("shift_start_date_time", r["shift_start_date_time"].ToString());
                    //report.SetParameterValue("shift_start_userID", r["shift_userID"].ToString());
                    //report.SetParameterValue("beginning_invoice", r["beginning_invoice"].ToString());
                    //report.SetParameterValue("ending_invoice", r["ending_invoice"].ToString());
                    //report.SetParameterValue("void_beginning_no", r["void_beginning_no"].ToString());
                    //report.SetParameterValue("void_ending_no", r["void_ending_no"].ToString());
                    //report.SetParameterValue("starting_cash", Math.Round(decimal.Parse(r["starting_cash"].ToString()), 2).ToString("N2"));
                    //report.SetParameterValue("no_of_transactions", r["no_of_transactions"].ToString());
                    //report.SetParameterValue("sales", Math.Round(decimal.Parse(r["sales"].ToString()), 2).ToString("N2"));
                    //report.SetParameterValue("discount_deductions", Math.Round(decimal.Parse(r["discount_deductions"].ToString()), 2).ToString("N2"));
                    //report.SetParameterValue("adjustments", Math.Round(decimal.Parse(r["adjustments"].ToString()), 2).ToString("N2"));
                    //report.SetParameterValue("net_sales", Math.Round(decimal.Parse(r["net_sales"].ToString()), 2).ToString("N2"));
                    //report.SetParameterValue("expected_drawer", Math.Round(decimal.Parse(r["expected_drawer"].ToString()), 2).ToString("N2"));
                    //report.SetParameterValue("terminal_No", Properties.Settings.Default.Terminal_id);
                    //report.SetParameterValue("declared_drawer", Math.Round(decimal.Parse(r["declared_drawer"].ToString()), 2).ToString("N2"));
                    //report.SetParameterValue("short_over", Math.Round(decimal.Parse(r["short_over"].ToString()), 2).ToString("N2"));
                    //report.SetParameterValue("printed_on", datetime_now);

                    report.SetParameterValue("xreading_ref_temp", r["xreading_ref_temp"].ToString());
                    report.SetParameterValue("store_open_date_time", store_open_date_time);
                    report.SetParameterValue("store_open_userID", r["store_userID"].ToString());
                    report.SetParameterValue("shift_start_date_time", shift_start_date_time);
                    report.SetParameterValue("shift_start_userID", shift_start_userID);
                    report.SetParameterValue("beginning_invoice", lblBeginningInvoice.Text);
                    report.SetParameterValue("ending_invoice", lblEndingInvoice.Text);
                    report.SetParameterValue("void_beginning_no", lblVoidBeginningNo.Text);
                    report.SetParameterValue("void_ending_no", lblVoidEndingNo.Text);
                    report.SetParameterValue("starting_cash", lblStartingCash.Text);
                    report.SetParameterValue("no_of_transactions", lblTransactions.Text);
                    report.SetParameterValue("sales", lblSales.Text);
                    report.SetParameterValue("discount_deductions", lblDiscount.Text);
                    report.SetParameterValue("adjustments", lblAdjustments.Text);
                    report.SetParameterValue("net_sales", lblNetSales.Text);
                    report.SetParameterValue("expected_drawer", lblExpectedDrawer.Text);
                    report.SetParameterValue("terminal_No", Properties.Settings.Default.Terminal_id);
                    report.SetParameterValue("declared_drawer", lblDeclaredDrawer.Text);
                    report.SetParameterValue("short_over", lblShortOver.Text);
                    report.SetParameterValue("printed_on", datetime_now);
                }

                PrintReceipt();
            }
            else
            {
                report80 = new XReadingReport80();

                DataSet ds = new DataSet();

                string datetime_now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
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
                           SELECT xreading.*, u.user_name as 'store_userID', 
                           us.user_name as 'shift_userID' FROM xreading INNER JOIN #Temp_users as u
                           ON xreading.store_open_userID = u.ID INNER JOIN
                           #Temp_users as us ON xreading.shift_start_userID = us.ID WHERE 
                           xreading_ref = (SELECT MAX(xreading_ref) FROM xreading WHERE terminal_id=@terminal_id)");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    //report80.SetParameterValue("xreading_ref_temp", r["xreading_ref_temp"].ToString());
                    //report80.SetParameterValue("store_open_date_time", r["store_open_date_time"].ToString());
                    //report80.SetParameterValue("store_open_userID", r["store_userID"].ToString());
                    //report80.SetParameterValue("shift_start_date_time", r["shift_start_date_time"].ToString());
                    //report80.SetParameterValue("shift_start_userID", r["shift_userID"].ToString());
                    //report80.SetParameterValue("beginning_invoice", r["beginning_invoice"].ToString());
                    //report80.SetParameterValue("ending_invoice", r["ending_invoice"].ToString());
                    //report80.SetParameterValue("void_beginning_no", r["void_beginning_no"].ToString());
                    //report80.SetParameterValue("void_ending_no", r["void_ending_no"].ToString());
                    //report80.SetParameterValue("starting_cash", Math.Round(decimal.Parse(r["starting_cash"].ToString()), 2).ToString("N2"));
                    //report80.SetParameterValue("no_of_transactions", r["no_of_transactions"].ToString());
                    //report80.SetParameterValue("sales", Math.Round(decimal.Parse(r["sales"].ToString()), 2).ToString("N2"));
                    //report80.SetParameterValue("discount_deductions", Math.Round(decimal.Parse(r["discount_deductions"].ToString()), 2).ToString("N2"));
                    //report80.SetParameterValue("adjustments", Math.Round(decimal.Parse(r["adjustments"].ToString()), 2).ToString("N2"));
                    //report80.SetParameterValue("net_sales", Math.Round(decimal.Parse(r["net_sales"].ToString()), 2).ToString("N2"));
                    //report80.SetParameterValue("expected_drawer", Math.Round(decimal.Parse(r["expected_drawer"].ToString()), 2).ToString("N2"));
                    //report80.SetParameterValue("terminal_No", Properties.Settings.Default.Terminal_id);
                    //report80.SetParameterValue("declared_drawer", Math.Round(decimal.Parse(r["declared_drawer"].ToString()), 2).ToString("N2"));
                    //report80.SetParameterValue("short_over", Math.Round(decimal.Parse(r["short_over"].ToString()), 2).ToString("N2"));
                    //report80.SetParameterValue("printed_on", datetime_now);

                    report80.SetParameterValue("xreading_ref_temp", r["xreading_ref_temp"].ToString());
                    report80.SetParameterValue("store_open_date_time", store_open_date_time);
                    report80.SetParameterValue("store_open_userID", r["store_userID"].ToString());
                    report80.SetParameterValue("shift_start_date_time", shift_start_date_time);
                    report80.SetParameterValue("shift_start_userID", shift_start_userID);
                    report80.SetParameterValue("beginning_invoice", lblBeginningInvoice.Text);
                    report80.SetParameterValue("ending_invoice", lblEndingInvoice.Text);
                    report80.SetParameterValue("void_beginning_no", lblVoidBeginningNo.Text);
                    report80.SetParameterValue("void_ending_no", lblVoidEndingNo.Text);
                    report80.SetParameterValue("starting_cash", lblStartingCash.Text);
                    report80.SetParameterValue("no_of_transactions", lblTransactions.Text);
                    report80.SetParameterValue("sales", lblSales.Text);
                    report80.SetParameterValue("discount_deductions", lblDiscount.Text);
                    report80.SetParameterValue("adjustments", lblAdjustments.Text);
                    report80.SetParameterValue("net_sales", lblNetSales.Text);
                    report80.SetParameterValue("expected_drawer", lblExpectedDrawer.Text);
                    report80.SetParameterValue("terminal_No", Properties.Settings.Default.Terminal_id);
                    report80.SetParameterValue("declared_drawer", lblDeclaredDrawer.Text);
                    report80.SetParameterValue("short_over", lblShortOver.Text);
                    report80.SetParameterValue("printed_on", datetime_now);
                }

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
                new Notification().PopUp("No receipt printer selected.", "Error printing","error");
                return;
            }

            bool checkprinter = PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("Printer is offline", "Error","error");
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlCD.BringToFront();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            lblDeclaredDrawer.Text = lblTotalAmount.Text;

            // short/over
            decimal declared_drawer = Math.Round(decimal.Parse(lblDeclaredDrawer.Text));
            decimal expected_drawer = Math.Round(decimal.Parse(lblExpectedDrawer.Text));

            lblShortOver.Text = (declared_drawer - expected_drawer).ToString("N2");

            pnlPreview.BringToFront();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt1000_TextChanged(object sender, EventArgs e)
        {
            string denomination = (sender as TextBox).Name;
            denomination =  (sender as TextBox).Name.Replace("txt", "");

            object FindControl_Amount = Controls.Find("lbl_" + denomination, true).FirstOrDefault();
            Label lblAmount = new Label();
            lblAmount = (Label)FindControl_Amount;

            object FindControl_Total = Controls.Find("lbl" + denomination, true).FirstOrDefault();
            Label lblTotal = new Label();
            lblTotal = (Label)FindControl_Total;

            if ((sender as TextBox).Text != "")
            {
                decimal amount1 = Convert.ToDecimal(lblAmount.Text);
                decimal amount2 = Convert.ToDecimal((sender as TextBox).Text);
                decimal amounttotal = amount1 * amount2;
                lblTotal.Text = amounttotal.ToString();
            }

            else if ((sender as TextBox).Text == "")
                lblTotal.Text = "0.00";

            Label[] Label_Total = new[] { lbl1000, lbl500, lbl200, lbl100, lbl50, lbl20, lbl10, lbl5, lbl1, lbl25c, lbl10c, lbl5c, lbl1c };
            TextBox[] Other_PM = new[] { txtGC, txtDebit, txtCredit, txtCheque, txtGCash, txtPayMaya };

            decimal total = 0;

            foreach (Label formLabel in Label_Total)
            {
                decimal label = Convert.ToDecimal(formLabel.Text);
                total = total + label;
            }


            foreach (TextBox textbox in Other_PM)
            {
                if (textbox.Text != "")
                {
                    decimal tb = Convert.ToDecimal(textbox.Text);
                    total = total + tb;
                }
            }

            lblTotalAmount.Text = String.Format("{0:n}", total);
        }

        private void txt1000_Enter(object sender, EventArgs e)
        {
            if((sender as TextBox).Text == "0")
            {
                (sender as TextBox).Text = "";
            }
        }

        private void txt1000_Leave(object sender, EventArgs e)
        {
            if((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "0";
            }
        }
    }
}
