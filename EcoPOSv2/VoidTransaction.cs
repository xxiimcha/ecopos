﻿using CrystalDecisions.Shared;
using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class VoidTransaction : Form
    {
        public VoidTransaction()
        {
            InitializeComponent();
        }

        SQLControl SQL = new SQLControl();

        PaymentReceipt report = new PaymentReceipt();

        public static VoidTransaction _VoidTransaction;
        public static VoidTransaction Instance
        {
            get
            {
                if (_VoidTransaction == null)
                {
                    _VoidTransaction = new VoidTransaction();
                }
                return _VoidTransaction;
            }
        }

        private void VoidTransaction_Load(object sender, EventArgs e)
        {
            txtORNo.Clear();
            txtORNo.Focus();

            _VoidTransaction = this;

            guna2ShadowForm1.SetShadowForm(this);
            AssignValidation(ref txtORNo, ValidationType.Int_Only);
        }
        //METHODS
        public void PrintReceipt()
        {
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
        private void GenerateReceipt()
        {
            bool checkprinter = Main.PrinterExists(Main.Instance.pd_receipt_printer);

            if (checkprinter == false)
            {
                new Notification().PopUp("Printer is offline", "Error", "error");
                return;
            }


            DataSet ds = new DataSet();

            report = new PaymentReceipt();

            try
            {
                SQL.DBDA.SelectCommand = new SqlCommand(@"SELECT quantity, description, (-1 * static_price_inclusive) as static_price_inclusive, 
                                                         (-1 * selling_price_inclusive) as selling_price_inclusive FROM transaction_items
                                                         INNER JOIN transaction_details ON transaction_details.order_ref = transaction_items.order_ref
                                                         WHERE transaction_details.order_ref_temp = " + txtORNo.Text, SQL.DBCon);
                SQL.DBDA.Fill(ds, "transaction_items");

                report.SetDataSource(ds);


                SQL.AddParam("@order_ref_temp", txtORNo.Text);
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
                           vt.void_order_ref_temp as 'void_order_ref_temp'
                           FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                           INNER JOIN void_transaction as vt ON transaction_details.order_ref = vt.order_ref
                           WHERE transaction_details.order_ref_temp = @order_ref_temp");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    report.SetParameterValue("date_time", r["date_time"].ToString());
                    report.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                    report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
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
                    report.SetParameterValue("giftcard_no", r["giftcard_no"].ToString());
                    decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                    report.SetParameterValue("cash", payment_amt.ToString("N2"));
                    decimal change = decimal.Parse(r["change"].ToString());
                    report.SetParameterValue("change", change.ToString("N2"));
                    report.SetParameterValue("cus_name", r["cus_name"].ToString());
                    report.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                    report.SetParameterValue("payment_method", r["payment_method"].ToString());



                    report.SetParameterValue("note", "VOID # " + r["void_order_ref_temp"].ToString());
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

                if (Properties.Settings.Default.dbName == "EcoPOS")
                {
                    report.SetParameterValue("is_vatable", true);
                    report.SetParameterValue("txt_footer", "This serves as Official Receipt.");
                }
                else
                {
                    report.SetParameterValue("is_vatable", false);
                    report.SetParameterValue("txt_footer", "This serves as Demo Receipt.");
                }
            }
            catch (Exception ex)
            {
                new Notification().PopUp(ex.Message, "", "error");
                report.Dispose();
            }

            PrintReceipt();
        }

        //METHODS
        int result = 0;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // check if within shift
            if(int.Parse(SQL.ReturnResult("select count(*) from shift")) == 1)
            {
                result = 1;
            }
            else
            {
                DateTime current_shift_datetime = DateTime.Parse(SQL.ReturnResult("SELECT MAX(start) FROM shift WHERE ended IS NOT NULL"));
                if (SQL.HasException(true))
                    return;

                SQL.AddParam("@order_ref_temp", txtORNo.Text);
                SQL.AddParam("@last_end_shift", current_shift_datetime);
                result = int.Parse(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE order_ref_temp = @order_ref_temp AND action = 1 AND date_time > @last_end_shift"));
                if (SQL.HasException(true))
                    return;
            }

            if (result == 1)
            {
                SQL.AddParam("@order_ref_temp", txtORNo.Text);
                SQL.Query("UPDATE transaction_details SET action = 4 WHERE order_ref_temp = @order_ref_temp");
                if (SQL.HasException(true))
                    return;

                // save to void_transaction
                SQL.AddParam("@order_ref_temp", txtORNo.Text);
                var order_ref = SQL.ReturnResult("SELECT order_ref FROM transaction_details WHERE order_ref_temp = @order_ref_temp");
                if (SQL.HasException(true))
                    return;

                SQL.AddParam("@order_ref", order_ref);
                SQL.Query("INSERT INTO void_transaction (order_ref) VALUES (@order_ref)");
                if (SQL.HasException(true))
                    return;

                //return items to inventory
                SQL.AddParam("@order_ref", order_ref);
                SQL.Query("SELECT productID, quantity FROM transaction_items WHERE order_ref = @order_ref");
                if (SQL.HasException(true))
                    return;

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
                }

                GenerateReceipt();

              // Close();
               // return;
            }
            else
            {
                new Notification().PopUp("Invoice does not exist or expired", "Error", "error");
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtORNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
        }
    }
}
