using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Guna.UI2.WinForms;

namespace EcoPOSv2
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        //VARIABLES
        private SQLControl SQL = new SQLControl();
        private FormLoad OL = new FormLoad();
        public Order frmOrder;
        public int action;
        public decimal card_balance = 0m;
        public decimal change;
        public decimal grand_total;
        public decimal total;
        private string note = " ";
        public PaymentR58 report;
        public PaymentR80 report80;
        //VARIABLES

        //METHODS
        public static Payment _Payment;
        public static Payment Instance
        {
            get
            {
                if (_Payment == null)
                {
                    _Payment = new Payment();
                }
                return _Payment;
            }
        }

        public void Advance_OrderNo()
        {
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query(@"INSERT INTO order_no (order_no, terminal_id)
                       SELECT (order_no + 1), @terminal_id FROM order_no
            WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no where terminal_id=@terminal_id)");

            if (SQL.HasException(true))
                return;

            Order.Instance.LoadOrderNo();
        }

        private void GenerateReceipt()
        {
            bool checkprinter = Main.PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("Printer is offline", "", "error");
                return;
            }
            else if (checkprinter == true)
            {
                if (Properties.Settings.Default.papersize == "58MM")
                {
                    DataSet ds = new DataSet();

                    try
                    {
                        SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive, selling_price_inclusive FROM transaction_items WHERE terminal_id=" + Properties.Settings.Default.Terminal_id + " and order_ref = (SELECT MAX(order_ref) FROM transaction_details where terminal_id=" + Properties.Settings.Default.Terminal_id + ")", SQL.DBCon);
                        SQL.DBDA.Fill(ds, "transaction_items");

                        report.SetDataSource(ds);

                        SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                        SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users SELECT * INTO #Temp_users FROM (SELECT ID, user_name, first_name FROM(SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts UNION ALL SELECT userID, user_name, first_name FROM users ) x ) as a; SELECT date_time,order_ref_temp, u.first_name as 'user_first_name',  no_of_items,  subtotal,  less_vat,  disc_amt,  cus_pts_deducted,  grand_total, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, payment_amt,  change, remaining_points, giftcard_no,giftcard_deducted, IIF(cus_name = '', '0', cus_name) as 'cus_name', cus_special_ID_no, refund_order_ref_temp, return_order_ref_temp, payment_method, terminal_id FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM transaction_details where terminal_id=@terminal_id)");

                        if (SQL.HasException(true))
                            return;

                        foreach (DataRow r in SQL.DBDT.Rows)
                        {
                            report.SetParameterValue("date_time", r["date_time"].ToString());
                            report.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                            report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                            report.SetParameterValue("no_of_items", r["no_of_items"].ToString());
                            report.SetParameterValue("Terminal_No", r["terminal_id"].ToString());

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
                            report.SetParameterValue("giftcard_no", giftcard_no.ToString("N0"));

                            decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                            report.SetParameterValue("cash", payment_amt.ToString("N2"));

                            decimal change = decimal.Parse(r["change"].ToString());
                            report.SetParameterValue("change", change.ToString("N2"));

                            decimal remaining_points = decimal.Parse(r["remaining_points"].ToString());
                            report.SetParameterValue("remaining_points", remaining_points.ToString("N2"));

                            if (r["cus_name"].ToString() == "0")
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



                            report.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());

                        }
                        //Online Payment Reference No
                        report.SetParameterValue("ReferenceNumber", tbReferenceNo.Text);

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
                            report.SetParameterValue("txt_footer", "THIS SERVES AS OFFCIAL RECEIPT.");
                        }
                        else
                        {
                            report.SetParameterValue("is_vatable", false);
                            report.SetParameterValue("txt_footer", "THIS SERVES AS DEMO RECEIPT.");
                        }


                        int no_of_prints = 1;

                        //Sets number of copies to print
                        int print_count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM receipt_layout"));
                        if (SQL.HasException(true))
                            return;

                        if (print_count_records == 1)
                        {
                            no_of_prints = Convert.ToInt32(SQL.ReturnResult("SELECT number_of_copies FROM receipt_layout WHERE configuration_ID = 1"));
                            if (SQL.HasException(true))
                                return;
                        }

                        //if (Properties.Settings.Default.ShowAccountingReceipt)
                        //    no_of_prints = 2;
                        if (no_of_prints == 0) 
                        {
                            OpenDrawer();
                        }
                        for (var i = 1; i <= no_of_prints; i++)
                        {
                            if (i == 1)
                                report.SetParameterValue("note", note + "CUSTOMER COPY");
                                
                            if (i == 2)
                                report.SetParameterValue("note", note + "ACCOUNTING COPY");
                           
                            try
                            {
                                PrintReceipt();
                            }
                            catch (Exception) { }
                        }

                      
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        report.Dispose();
                    }
                }
                else
                {
                    DataSet ds = new DataSet();

                    report80 = new PaymentR80();

                    try
                    {
                        //SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, static_price_inclusive, selling_price_inclusive FROM transaction_items WHERE order_ref = (SELECT MAX(order_ref) FROM transaction_details)", SQL.DBCon);
                        //SQL.DBDA.Fill(ds, "transaction_items");

                        SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive, selling_price_inclusive FROM transaction_items WHERE terminal_id=" + Properties.Settings.Default.Terminal_id + " and order_ref = (SELECT MAX(order_ref) FROM transaction_details where terminal_id=" + Properties.Settings.Default.Terminal_id + ")", SQL.DBCon);
                        SQL.DBDA.Fill(ds, "transaction_items");

                        report80.SetDataSource(ds);

                        SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                        SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users SELECT * INTO #Temp_users FROM (SELECT ID, user_name, first_name FROM(SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts UNION ALL SELECT userID, user_name, first_name FROM users ) x ) as a; SELECT date_time,order_ref_temp, u.first_name as 'user_first_name',  no_of_items,  subtotal,  less_vat,  disc_amt,  cus_pts_deducted,  grand_total, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, payment_amt,  change, giftcard_no,giftcard_deducted, IIF(cus_name = '', '0', cus_name) as 'cus_name', cus_special_ID_no, refund_order_ref_temp, return_order_ref_temp, payment_method FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM transaction_details where terminal_id=@terminal_id)");

                        if (SQL.HasException(true))
                            return;

                        foreach (DataRow r in SQL.DBDT.Rows)
                        {
                            report80.SetParameterValue("date_time", r["date_time"].ToString());
                            report80.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                            report80.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                            report80.SetParameterValue("no_of_items", r["no_of_items"].ToString());
                            report80.SetParameterValue("Terminal_No", Properties.Settings.Default.Terminal_name);

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

                            decimal giftcard_no = decimal.Parse(r["giftcard_no"].ToString());
                            report80.SetParameterValue("giftcard_no", giftcard_no.ToString("N2"));

                            decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                            report80.SetParameterValue("cash", payment_amt.ToString("N2"));

                            decimal change = decimal.Parse(r["change"].ToString());
                            report80.SetParameterValue("change", change.ToString("N2"));

                            if (r["cus_name"].ToString() == "0")
                            {
                                report80.SetParameterValue("cus_name", "________________________________________________________");
                            }
                            else
                            {
                                report80.SetParameterValue("cus_name", r["cus_name"].ToString());
                            }


                            if (r["cus_special_ID_no"].ToString() == "0")
                            {
                                report80.SetParameterValue("cus_sc_pwd_id", "________________________________________________________");
                            }
                            else
                            {
                                report80.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                            }

                            report80.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());

                        }

                        //Online Payment Reference No
                        report80.SetParameterValue("ReferenceNumber", tbReferenceNo.Text);

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

                        int no_of_prints = 1;

                        if (frmOrder.apply_regular_discount_fix_amt | frmOrder.apply_special_discount | frmOrder.apply_member)
                            no_of_prints = 2;

                        for (var i = 1; i <= no_of_prints; i++)
                        {
                            if (i == 1)
                                report80.SetParameterValue("note", note + "CUSTOMERS COPY");
                            if (i == 2)
                                report80.SetParameterValue("note", note + "ACCOUNTING COPY");

                            try
                            {
                                PrintReceipt();
                            }
                            catch (Exception) { }
                        }

                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        report.Dispose();
                    }
                }
            }
        }

        public void OpenDrawer()
        {
            EmptyReceipt receipt = new EmptyReceipt();
            try
            {
                receipt.PrintOptions.NoPrinter = false;
                receipt.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                receipt.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                receipt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                receipt.PrintToPrinter(0, false, 0, 0);
            }
            catch (Exception)
            {
                receipt.PrintOptions.NoPrinter = false;
                receipt.PrintOptions.PrinterName = "Microsoft Print to PDF";
                receipt.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                receipt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                receipt.PrintToPrinter(0, false, 0, 0);
            }
            finally
            {
                if (receipt.IsLoaded)
                {
                    receipt.Close();
                }
            }
        }

        public void PrintReceipt()
        {
            if (Main.Instance.pd_receipt_printer == "")
            {
                MessageBox.Show("No receipt printer selected.", "Error printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Properties.Settings.Default.papersize == "58MM")
                {
                    try
                    {
                        report.PrintOptions.NoPrinter = false;
                        if (PChange.Instance.isRePrint)
                        {
                            report.PrintOptions.PrinterName = Main.Instance.pd_reprint_printer;
                            PChange.Instance.isRePrint = false;
                        }
                        else
                        {
                            report.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                        }
                        report.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                        report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        report.PrintToPrinter(1, false, 0, 0);
                    }
                    catch (Exception) {
                        report.PrintOptions.NoPrinter = false;
                        report.PrintOptions.PrinterName ="Microsoft Print to PDF";
                        report.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                        report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        report.PrintToPrinter(1, false, 0, 0);
                    }
                   
                }
                else
                {
                    try
                    {
                        report80.PrintOptions.NoPrinter = false;
                        if (PChange.Instance.isRePrint)
                        {
                            report80.PrintOptions.PrinterName = Main.Instance.pd_reprint_printer;
                            PChange.Instance.isRePrint = false;
                        }
                        else
                        {
                            report80.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                        }
                        report80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                        report80.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        report80.PrintToPrinter(1, false, 0, 0);
                    }
                    catch (Exception) {
                        report80.PrintOptions.NoPrinter = false;
                        report80.PrintOptions.PrinterName = "Microsoft Print to PDF";
                        report80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                        report80.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        report80.PrintToPrinter(1, false, 0, 0);
                    }
                   
                }
            }
        }

        private void FontSetter()
        {
            int fontSize_regular = int.Parse(Properties.Settings.Default.RegularTextFont);
            int fontSize_products = int.Parse(Properties.Settings.Default.ProductListFont);
            int fontSize_bname = int.Parse(Properties.Settings.Default.TitleTextFont);
            int fontSize_bheader = int.Parse(Properties.Settings.Default.BusinessDetailsFont);
            int fontSize_transactionDetails = int.Parse(Properties.Settings.Default.TransactionDetailsFont);


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

            ((TextObject)report.ReportDefinition.ReportObjects["tprice"]).ApplyFont(new Font("Arial", fontSize_products, FontStyle.Bold));
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
            ((TextObject)report.ReportDefinition.ReportObjects["trpoints"]).ApplyFont(new Font("Arial", fontSize_transactionDetails , FontStyle.Regular));
            ((FieldObject)report.ReportDefinition.ReportObjects["trpoints1"]).ApplyFont(new Font("Arial", fontSize_transactionDetails, FontStyle.Regular));

            ((FieldObject)report.ReportDefinition.ReportObjects["footertext1"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
            ((FieldObject)report.ReportDefinition.ReportObjects["txtfooter1"]).ApplyFont(new Font("Arial", fontSize_regular, FontStyle.Bold));
           
            FontDone = true;
        }

        bool rewardable;
        int check;
        decimal Total_Sales_Per_Transaction, Total_Total_Cost_Transaction, Total_Discount_Transaction;
        string inventory_query = "";
        private void LoadData()
        {
            #region remove/add to inventory
            inventory_query = "";
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query("SELECT productID, quantity, is_return, is_refund FROM order_cart where terminal_id=@terminal_id;");
            if (SQL.HasException(true))
            {
                MessageBox.Show("Inventory Error");
                return;
            }

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                if (Convert.ToBoolean(r["is_return"].ToString()) || Convert.ToBoolean(r["is_refund"].ToString()))
                {
                    inventory_query = inventory_query + "UPDATE inventory SET stock_qty = stock_qty + " + r["quantity"].ToString() + " WHERE productID = " + r["productID"].ToString() + "; ";
                }
                else
                {
                    inventory_query = inventory_query + "UPDATE inventory SET stock_qty = stock_qty - " + r["quantity"].ToString() + " WHERE productID = " + r["productID"].ToString() + "; ";
                }
            }
            #endregion

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            Total_Sales_Per_Transaction = decimal.Parse(SQL.ReturnResult("select SUM(selling_price_inclusive) from order_cart where terminal_id=@terminal_id"));
            if (SQL.HasException(true))
            {
                MessageBox.Show("5.0.2");
                return;
            }

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            Total_Total_Cost_Transaction = decimal.Parse(SQL.ReturnResult("select SUM(cost * quantity) from order_cart where terminal_id=@terminal_id"));
            if (SQL.HasException(true))
            {
                MessageBox.Show("5.0.3");
                return;
            }

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            Total_Discount_Transaction = decimal.Parse(SQL.ReturnResult("select sum(discount) from order_cart where terminal_id=@terminal_id"));
            if (SQL.HasException(true))
            {
                MessageBox.Show("5.0.4");
                return;
            }

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            rewardable = Convert.ToBoolean(SQL.ReturnResult("SELECT cus_rewardable FROM order_no WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no where terminal_id=@terminal_id)".ToString()));
            if (SQL.HasException(true))
            {
                return;
            }

            SQL.AddParam("@date", currentDate.ToString("yyy-MM-dd"));
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            check = int.Parse(SQL.ReturnResult("select count(*) from profit where date=@date and terminal_id=@terminal_id"));
            if (SQL.HasException(true))
            {
                MessageBox.Show("5.0");
                return;
            }

            ValidateExpiration();

            DataDone = true;
        }

        DateTime currentDate;
        Boolean FontDone, DataDone = false;
        //METHODS
        private void Payment_Load(object sender, EventArgs e)
        {
            currentDate = DateTime.Now;
            report = new PaymentR58();

            Thread setFont = new Thread(FontSetter);
            setFont.Start();

            Thread loadData = new Thread(LoadData);
            loadData.Start();

            _Payment = this;

            cmbMethod.SelectedIndex = 0;
            this.ActiveControl = txtAmount;
        }

        List<string> expiredProductList = new List<string>();
        private void ValidateExpiration()
        {
            expiredProductList.Clear();

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query("SELECT productID, description FROM order_cart WHERE terminal_id = @terminal_id");
            foreach (DataRow r in SQL.DBDT.Rows)
            {
                SQL.AddParam("@productID", r["productID"].ToString());
                Boolean has_expiry = Convert.ToBoolean(SQL.ReturnResult(@"SELECT has_expiry FROM products WHERE productID = @productID"));
                if (SQL.HasException(true))
                    return;

                if (has_expiry)
                {
                    SQL.AddParam("@productID", r["productID"].ToString());
                    DateTime expiration = Convert.ToDateTime(SQL.ReturnResult(@"SELECT expiration_date FROM products WHERE productID = @productID"));
                    if (SQL.HasException(true))
                        return;
                    if (expiration <= DateTime.Now)
                    {
                        expiredProductList.Add(r["description"].ToString());
                    }
                }
            }
        }

        private void btnExact_Click(object sender, EventArgs e)
        {
            txtAmount.Text = lblGrandTotal.Text;
            txtAmount.Focus();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //Warns that data are still being loaded by the system
            if (!DataDone || !FontDone)
            {
                new Notification().PopUp("Data still being loaded.", "Loading...", "information");
                txtAmount.Focus();
                return;
            }

            //CHECKS IF AMOUNT TENDERED IS LOWER THAN NEEDED
            if(txtAmount.Text == "")
            {
                new Notification().PopUp("Please enter a valid amount.", "Error", "error");
                txtAmount.Focus();
                return;
            }

            if (action == 1)
            {
                if (change < 0)
                {
                    new Notification().PopUp("Insufficient Amount.", "Error", "error");
                    txtAmount.Focus();
                    return;
                }
            }

            //Warns the user if the amount tendered is higher than 100,000 (To avoid scanning of barcode)
            string[] wholenumber = txtAmount.Text.Split('.');
            if (wholenumber[0].Length > (wholenumber[0].Contains(',') ? 6 : 5))
            {
                DialogResult dialogResult = MessageBox.Show("You have entered a price higher than 100,000. Would you like to proceed?", "High Amount Tendered", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            //Validates if user still wants to procceed even if there are expired products.
            if (expiredProductList.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Expired Products: " + string.Join(", ", expiredProductList) + ".\nDo you still want to procceed?", "Expiration Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //proceed
                }
                else if (dialogResult == DialogResult.No)
                {
                    txtAmount.Focus();
                    return;
                }
            }

            #region transaction_details and transaction_items
            btnPay.Enabled = false;

            //SQL SERVER BLOCKING FOR TRANSACTION
            int retryCount = 5;
            bool success = false;
            while (retryCount > 0 && !success)
            {
                try
                {
                    SQL.AddParam("@no_of_items", Convert.ToDecimal(frmOrder.lblItems.Text));
                    SQL.AddParam("@cus_pts_deducted", lblDeductPoints.Text);
                    SQL.AddParam("@giftcard_deducted", lblDeductGC.Text);
                    SQL.AddParam("@subtotal", Convert.ToDecimal(frmOrder.lblSubtotal.Text));
                    SQL.AddParam("@fix_discount", Convert.ToDecimal(frmOrder.regular_disc_amt));
                    SQL.AddParam("@total", Convert.ToDecimal(frmOrder.lblTotal.Text));
                    SQL.AddParam("@grand_total", Convert.ToDecimal(lblGrandTotal.Text));
                    SQL.AddParam("@payment_amt", Convert.ToDecimal(txtAmount.Text));
                    SQL.AddParam("@change", change);
                    SQL.AddParam("@payment_method", cmbMethod.Text);
                    SQL.AddParam("@giftcard_no", lblGCNo.Text);
                    SQL.AddParam("@less_vat", Convert.ToDecimal(frmOrder.lblLessVAT.Text));
                    SQL.AddParam("@vatable_sale", Convert.ToDecimal(frmOrder.lblVATSale.Text));
                    SQL.AddParam("@vat_12", Convert.ToDecimal(frmOrder.lblVAT.Text));
                    SQL.AddParam("@vat_exempt_sale", Convert.ToDecimal(frmOrder.lblVATExempt.Text));
                    SQL.AddParam("@zero_rated_sale", Convert.ToDecimal(frmOrder.lblZeroRated.Text));
                    SQL.AddParam("@remaining_points", Convert.ToDecimal(lblRemainingPoints.Text));
                    SQL.AddParam("@userID", Main.Instance.current_id);
                    SQL.AddParam("@user_first_name", Main.Instance.current_user_first_name);
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    //ReferenceNo
                    SQL.AddParam("@ReferenceNo", tbReferenceNo.Text);
                    SQL.AddParam("@date", currentDate);
                    SQL.Query(@"BEGIN TRAN

                        INSERT INTO transaction_details 
                           (order_ref, order_no, action, discountID, cus_ID_no, cus_special_ID_no, cus_type, cus_name, cus_mem_ID, cus_rewardable, cus_amt_per_pt, refund_order_ref, return_order_ref, 
                           no_of_items, subtotal, disc_amt, total, cus_pts_deducted, giftcard_deducted, grand_total, payment_amt, change, payment_method, giftcard_no, 
                           less_vat, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, remaining_points, userID, user_first_name,terminal_id,referenceNo) 
                           SELECT order_ref, order_no, action, discountID, cus_ID_no, cus_special_ID_no, cus_type, cus_name, cus_mem_ID, cus_rewardable, cus_amt_per_pt, refund_order_ref, return_order_ref,  
                           @no_of_items, @subtotal, IIF((SELECT SUM(discount) + @fix_discount FROM order_cart WHERE terminal_id = @terminal_id) > 1300, 1300, (SELECT SUM(discount) + @fix_discount FROM order_cart WHERE terminal_id = @terminal_id)), @total, @cus_pts_deducted, 
                           @giftcard_deducted, @grand_total, @payment_amt, @change, @payment_method, @giftcard_no, @less_vat, @vatable_sale, @vat_12, @vat_exempt_sale, 
                           @zero_rated_sale, @remaining_points, @userID, @user_first_name,@terminal_id,@ReferenceNo FROM order_no WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no where terminal_id=@terminal_id);

                        INSERT INTO transaction_items (order_ref, itemID, productID, description, name, type, static_price_exclusive,
                           static_price_vat, static_price_inclusive, selling_price_exclusive, selling_price_vat, selling_price_inclusive,
                           quantity, discount, is_less_vat, less_vat, is_vat_exempt, is_disc_percent, disc_percent, is_refund, is_return,cost,terminal_id, unit)
                           SELECT (SELECT MAX(order_ref) FROM transaction_details where terminal_id=@terminal_id), itemID, productID, description, name, type, static_price_exclusive,
                           static_price_vat, static_price_inclusive, selling_price_exclusive, selling_price_vat, selling_price_inclusive,
                           quantity, discount, is_less_vat, less_vat, is_vat_exempt, is_disc_percent, disc_percent, is_refund, is_return,cost,terminal_id,(SELECT unit_name FROM units WHERE unit_id = (SELECT unit_id FROM products WHERE products.productID = order_cart.productID)) FROM order_cart where terminal_id=@terminal_id;

                        " + inventory_query + " COMMIT;");
                    success = true;
                }
                catch (SqlException exception)
                {
                    if (exception.Number != 1205)
                    {
                        new Notification().PopUp("Transaction Failed", "Error", "error");
                        throw;
                    }
                    
                    Thread.Sleep(1000);
                    retryCount--;
                    if (retryCount == 0) throw;
                }
            }

            if (!success)
            {
                new Notification().PopUp("Transaction Failed", "Error", "error");
                return;
            }
            #endregion

            #region calculate profit
            if (check == 0)
            {
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                SQL.AddParam("@date", currentDate.ToString("yyy-MM-dd"));
                SQL.Query("Insert into profit (Sales,Total_Cost,Gross,date,terminal_id) VALUES (0,0,0,@date,@terminal_id) ");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("5.0.1");
                    return;
                }
            }

            //SQL SERVER BLOCKING FOR PROFIT COMPUTATION
            int ProfitRetryCount = 5;
            bool ProfitSuccess = false;
            while (ProfitRetryCount > 0 && !ProfitSuccess)
            {
                try
                {
                    SQL.AddParam("@Sales", Total_Sales_Per_Transaction);
                    SQL.AddParam("@Total_Cost", Total_Total_Cost_Transaction);
                    SQL.AddParam("@date", currentDate.ToString("yyy-MM-dd"));
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                    SQL.Query(@"BEGIN TRAN
                        UPDATE profit set 
                        Sales = Sales + @Sales, 
                        Total_Cost = Total_Cost + @Total_Cost,
                        Gross = (Sales + @Sales) - (Total_Cost + @Total_Cost)
                        WHERE date = @date AND terminal_id=@terminal_id; 
                        COMMIT;");
                    ProfitSuccess = true;
                }
                catch (SqlException exception)
                {
                    if (exception.Number != 1205)
                    {
                        new Notification().PopUp("Profit Computation Failed", "Error", "error");
                        throw;
                    }

                    Thread.Sleep(1000);
                    ProfitRetryCount--;
                    if (ProfitRetryCount == 0) throw;
                }
            }

            if (!ProfitSuccess)
            {
                new Notification().PopUp("Profit Computation Failed", "Error", "error");
                return;
            }
            #endregion

            #region increase customer points
            if (action == 1 && lblCustomerID.Text != "0" && cbxUsePoints.Checked == false)
            {
                if (rewardable)
                {
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                    decimal cus_amt_per_pt = Convert.ToDecimal(SQL.ReturnResult("SELECT cus_amt_per_pt FROM order_no WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no where terminal_id=@terminal_id)").ToString());
                    if (SQL.HasException(true))
                        return;
                    SQL.AddParam("@customerID", lblCustomerID.Text);
                    SQL.AddParam("@cash_paid", Convert.ToDecimal(txtAmount.Text));
                    SQL.AddParam("@cus_amt_per_pt", cus_amt_per_pt);
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    SQL.Query(@"INSERT INTO points_award (order_ref, cus_ID_no, cash_paid, pts_earned)
                           SELECT MAX(order_ref), @customerID, @cash_paid, (@cash_paid / @cus_amt_per_pt) FROM transaction_details where terminal_id=@terminal_id");
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("6");
                        return;
                    }

                    // update card balance
                    SQL.AddParam("@customerID", lblCustomerID.Text);
                    SQL.AddParam("@cash_paid", Convert.ToDecimal(txtAmount.Text));
                    SQL.AddParam("@cus_amt_per_pt", cus_amt_per_pt);
                    SQL.Query("UPDATE member_card SET card_balance = card_balance + (@cash_paid / @cus_amt_per_pt) WHERE customerID = @customerID");
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("7");
                        return;
                    }
                }
            }

            if (action == 1 && cbxUsePoints.Checked == true)
            {
                if(Convert.ToDecimal(cbxUsePoints.Text) <= Convert.ToDecimal(lblTotal.Text))
                {
                    SQL.AddParam("@customerID", lblCustomerID.Text);
                    SQL.Query("UPDATE member_card SET card_balance = card_balance - card_balance WHERE customerID = @customerID");
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("8");
                        return;
                    }
                }
                else
                {
                    SQL.AddParam("@customerID", lblCustomerID.Text);
                    SQL.AddParam("@points_used", lblTotal.Text);
                    SQL.Query("UPDATE member_card SET card_balance = card_balance - @points_used WHERE customerID = @customerID");
                    if (SQL.HasException(true))
                    {
                        MessageBox.Show("8");
                        return;
                    }
                }
                // update card balance
                
            }
            #endregion

            #region gift card
            if (lblGCNo.Text != "0")
            {
                SQL.AddParam("@giftcard_no", lblGCNo.Text);
                SQL.Query("UPDATE giftcard SET status = 'Used' WHERE giftcard_no = @giftcard_no");
                if (SQL.HasException(true))
                {
                    MessageBox.Show("9");
                    return;
                }
            }
            #endregion

            #region clear cart

            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query("DELETE FROM order_cart where terminal_id=@terminal_id");
            if (SQL.HasException(true))
            {
                MessageBox.Show("Clear cart error");
                return;
            }

            #endregion

            GenerateReceipt();
            Advance_OrderNo();

            #region reset values

            //frmOrder.apply_regular_discount_fix_amt = false;
            //frmOrder.apply_special_discount = false;
            //frmOrder.apply_member = false;
            //frmOrder.tbBarcode.Enabled = true;
            //frmOrder.lblCustomer.Text = "";
            //frmOrder.lblOperation.Text = "Order/Payment";
            //frmOrder.regular_disc_amt = 0;
            //frmOrder.is_refund = false;
            //frmOrder.is_return = false;

            #endregion

            PChange pchange = new PChange();
            pchange.lblChange.Text = lblChange.Text;
            pchange.ShowDialog();
            this.Close();
        }


        private void btnRemoveGC_Click(object sender, EventArgs e)
        {
            //Resets the Gift Card to 0 and re-enables other buttons
            lblGCNo.Text = "0";
            lblDeductGC.Text = "0.00";

            btnExact.Enabled = true;
            txtAmount.Enabled = true;
            cbxUsePoints.Enabled = true;

            lblGrandTotal.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblDeductPoints.Text)).ToString("N2");
            lblChange.Text = "-" + lblGrandTotal.Text;

            //Focuses back to the amount text field / payment button
            if (txtAmount.Enabled)
            {
                txtAmount.Focus();
            }
            else
            {
                btnPay.Focus();
            }
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            PGiftCard frmPGiftCard = new PGiftCard();
            frmPGiftCard.frmPayment = this;
            frmPGiftCard.ShowDialog();

            //Disables the use point button when the grand total is 0
            if (Convert.ToDecimal(lblGrandTotal.Text) <= 0)
            {
                cbxUsePoints.Enabled = false;
            }

            //Focuses back to the amount text field / payment button
            if (txtAmount.Enabled)
            {
                txtAmount.Focus();
            }
            else
            {
                btnPay.Focus();
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            decimal deductpoints = decimal.Parse(lblDeductPoints.Text);
            decimal deductGC = decimal.Parse(lblDeductGC.Text);

            if (txtAmount.Text == "")
            {
                txtAmount.SelectAll();
                decimal total = 0M;

                decimal amount = total;

                change = (amount + deductGC) - grand_total;
                lblChange.Text = change.ToString("N2");

            }
            else
            {
                try
                {
                    decimal amount = decimal.Parse(txtAmount.Text);

                    change = (amount + deductpoints + deductGC) - grand_total;

                    lblChange.Text = change.ToString("N2");
                }
                catch (Exception) { }
            }

            txtAmount.Text = txtAmount.Text.Replace(" ", "");
            txtAmount.SelectionStart = txtAmount.Text.Length;
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if(e.KeyCode == Keys.Space)
            {
                if (btnExact.Enabled)
                {
                    btnExact.PerformClick();
                }
                
            }
        }

        private void Payment_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void cbxUsePoints_CheckedChanged(object sender, EventArgs e)
        {
            txtAmount.Text = "";

            decimal total = Convert.ToDecimal(lblTotal.Text);
            decimal available_points = Convert.ToDecimal(cbxUsePoints.Text);

            if (cbxUsePoints.Checked == true)
            {
                lblDeductPoints.Text = available_points <= Convert.ToDecimal(lblGrandTotal.Text) ? cbxUsePoints.Text : lblGrandTotal.Text;
                lblGrandTotal.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblDeductGC.Text) - Convert.ToDecimal(lblDeductPoints.Text)).ToString("N2");
                lblChange.Text = "-" + lblGrandTotal.Text;
                lblRemainingPoints.Text = (Convert.ToDecimal(cbxUsePoints.Text) - Convert.ToDecimal(lblDeductPoints.Text)).ToString("N2");
            }
            else if (cbxUsePoints.Checked == false)
            {
                txtAmount.Enabled = true;
                btnExact.Enabled = true;

                lblGrandTotal.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblDeductGC.Text)).ToString("N2");
                lblChange.Text = "-"+lblGrandTotal.Text;
                lblDeductPoints.Text = "0.00";
                lblRemainingPoints.Text = "0.00";
            }

            //Focuses back to the amount text field / payment button
            if (txtAmount.Enabled)
            {
                txtAmount.Focus();
            }
            else
            {
                btnPay.Focus();
            }
        }
        private void lblDeductPoints_TextChanged_1(object sender, EventArgs e)
        {
            decimal deduct_points = decimal.Parse(lblDeductPoints.Text);
            decimal total = decimal.Parse(lblTotal.Text);

            if (cbxUsePoints.Checked)
            {
                //grand_total = grand_total - deduct_points;

                if(deduct_points >= total)
                {
                    deduct_points = deduct_points - total;
                    lblGrandTotal.Text = "0.00";

                    lblChange.Text = "0.00";
                    change = 0;
                    lblRemainingPoints.Text = deduct_points.ToString("N2");
                    txtAmount.Text = "0";
                    txtAmount.Enabled = false;
                    btnExact.Enabled = false;
                }
                else
                {
                    btnExact.Enabled = true;
                    txtAmount.Enabled = true;

                    total = total - deduct_points;
                    lblGrandTotal.Text = total.ToString("N2");
                }

                //lblGrandTotal.Text = grand_total.ToString("N2");
            }
        }

        private void lblDeductGC_TextChanged(object sender, EventArgs e)
        {
            decimal deduct_gc = decimal.Parse(lblDeductGC.Text);
            decimal total = decimal.Parse(lblTotal.Text);

            if (deduct_gc != 0)
            {
                cmbMethod.Text = "Gift Certificate";
                //grand_total = grand_total - deduct_gc;

                if (deduct_gc >= total)
                {
                    deduct_gc = deduct_gc - total;
                    lblGrandTotal.Text = "0.00";
                    
                    txtAmount.Text = "0";
                    txtAmount.Enabled = false;
                    btnExact.Enabled = false;

                    change = 0;
                    lblChange.Text = "0.00";
                }
                else if(total > deduct_gc)
                {
                    btnExact.Enabled = true;
                    txtAmount.Enabled = true;

                    total = total - deduct_gc;

                    //change = total;

                    lblGrandTotal.Text = total.ToString("N2");

                    lblChange.Text = "-" + lblGrandTotal.Text;
              
                }
          
                //lblGrandTotal.Text = grand_total.ToString("N2");
            }
            else
            {
                btnExact.Enabled = true;
                txtAmount.Enabled = true;

                total = total - deduct_gc;
                lblGrandTotal.Text = total.ToString("N2");

                lblChange.Text = "-" + lblGrandTotal.Text;

                cmbMethod.Text = "Cash";
            }
        }

        private void Payment_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                if (btnExact.Enabled)
                {
                    btnExact.PerformClick();
                }
            }

            if (e.KeyCode == Keys.F2)
            {
                if(btnGC.Enabled)
                btnGC.PerformClick();
            }

            if (e.KeyCode == Keys.F3)
            {
                if (btnRemoveGC.Enabled)
                    btnRemoveGC.PerformClick();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (btnPay.Enabled)
                    btnPay.PerformClick();
            }
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as Guna2TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void CmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMethod.Text == "Cash" || cmbMethod.Text == "Membership Points" || cmbMethod.Text == "Gift Certificate")
            {
                lblReferenceNo.Visible = false;
                tbReferenceNo.Visible = false;

                lblReferenceNo.Enabled = false;
                tbReferenceNo.Enabled = false;
            }
            else
            {
                lblReferenceNo.Visible = true;
                tbReferenceNo.Visible = true;

                lblReferenceNo.Enabled = true;
                tbReferenceNo.Enabled = true;
            }
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void btnExact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPay.PerformClick();
            }
        }
    }
}
