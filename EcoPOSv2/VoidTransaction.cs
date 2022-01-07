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

        //PaymentReceipt report = new PaymentReceipt();

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
            AssignValidation(ref txtORNo, ValidationType.Int_Only);

            //SERVER TYPE OR NOT
            if (Properties.Settings.Default.servertype == true)
            {
                tbTerminalNo.ReadOnly = false;
                tbTerminalNo.Focus();
                this.ActiveControl = tbTerminalNo;
            }
            else
            {
                tbTerminalNo.Text = Properties.Settings.Default.Terminal_id;

                tbTerminalNo.ReadOnly = true;
                txtORNo.Focus();
                this.ActiveControl = txtORNo;
            }

            _VoidTransaction = this;
        }
        int result = 0;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtORNo.Text == "")
            {
                return;
            }

            //// check if within shift
            //if(int.Parse(SQL.ReturnResult("select count(*) from shift")) == 1)
            //{
            //    result = 1;
            //}
            //else
            //{
            //    DateTime current_shift_datetime = DateTime.Parse(SQL.ReturnResult("SELECT MAX(start) FROM shift WHERE ended IS NOT NULL"));
            //    if (SQL.HasException(true))
            //        return;

            //    SQL.AddParam("@order_ref_temp", txtORNo.Text);
            //    SQL.AddParam("@last_end_shift", current_shift_datetime);
            //    result = int.Parse(SQL.ReturnResult("SELECT COUNT(*) FROM transaction_details WHERE order_ref_temp = @order_ref_temp AND action = 1 AND date_time > @last_end_shift"));
            //    if (SQL.HasException(true))
            //        return;
            //}

            //if (result == 1)
            //{
            //SQL.AddParam("@order_ref_temp", txtORNo.Text);
            //SQL.Query("UPDATE transaction_details SET action = 4 WHERE order_ref_temp = @order_ref_temp");
            //if (SQL.HasException(true))
            //    return;

            // save to void_transaction
            SQL.AddParam("@order_ref_temp", txtORNo.Text);
            SQL.AddParam("@terminal_id", tbTerminalNo.Text);
            SQL.Query("SELECT order_ref FROM transaction_details WHERE terminal_id=@terminal_id AND order_ref_temp = @order_ref_temp AND action=1");

            if (SQL.HasException(true))
            {
                MessageBox.Show("1");
                return;
            }
            if(SQL.DBDT.Rows.Count == 0)
            {
                new Notification().PopUp("This OR no is not valid.", "Error", "error");
                tbTerminalNo.Focus();
                return;
            }
            else
            {
                SQL.AddParam("@order_ref_temp", txtORNo.Text);
                SQL.AddParam("@terminal_id", tbTerminalNo.Text);
                var order_ref = SQL.ReturnResult("SELECT order_ref FROM transaction_details WHERE terminal_id=@terminal_id AND order_ref_temp = @order_ref_temp");
                if (SQL.HasException(true))
                    return;

                VoidTransaction_UI vtu = new VoidTransaction_UI();

                vtu.terminalNo = tbTerminalNo.Text;
                vtu.order_ref = order_ref.ToString();
                vtu.order_ref_temp = txtORNo.Text;
                vtu.Show();
            }

            //    SQL.AddParam("@order_ref", order_ref);
            //    SQL.Query("INSERT INTO void_transaction (order_ref) VALUES (@order_ref)");
            //    if (SQL.HasException(true))
            //        return;

            //    //return items to inventory
            //    SQL.AddParam("@order_ref", order_ref);
            //    SQL.Query("SELECT productID, quantity FROM transaction_items WHERE order_ref = @order_ref");
            //    if (SQL.HasException(true))
            //        return;

            //    foreach (DataRow r in SQL.DBDT.Rows)
            //    {
            //        SQL.AddParam("@productID", r["productID"].ToString());
            //        SQL.AddParam("@quantity", r["quantity"].ToString());

            //        SQL.Query("UPDATE inventory SET stock_qty = stock_qty + @quantity WHERE productID = @productID");
            //        if (SQL.HasException(true))
            //        {
            //            MessageBox.Show("4");
            //            return;
            //        }
            //    }

            ////UPDATE PROFIT
            //SQL.AddParam("@order_ref", order_ref);
            //SQL.Query("UPDATE transaction_items set static_price_inclusive = -static_price_inclusive, selling_price_exclusive = -selling_price_exclusive,selling_price_inclusive= -selling_price_inclusive,cost=-cost where order_ref=@order_ref");

            //SQL.AddParam("@order_ref", order_ref);
            //decimal Total_Sales_Per_Transaction = decimal.Parse(SQL.ReturnResult("select SUM(selling_price_inclusive) from transaction_items where order_ref=@order_ref"));

            //SQL.AddParam("@order_ref", order_ref);
            //decimal Total_Total_Cost_Transaction = decimal.Parse(SQL.ReturnResult("select SUM(cost * quantity) from transaction_items where order_ref=@order_ref"));
            //if (SQL.HasException(true))
            //{
            //    MessageBox.Show("5.1");
            //    return;
            //}

            //SQL.AddParam("@Sales", Total_Sales_Per_Transaction);
            //SQL.AddParam("@Total_Cost", Total_Total_Cost_Transaction);
            //SQL.AddParam("@date", DateTime.Now.ToString("yyy-MM-dd"));
            //SQL.Query("UPDATE profit set Sales = Sales + @Sales, Total_Cost=Total_Cost + @Total_Cost where date=@date");
            //if (SQL.HasException(true))
            //{
            //    MessageBox.Show("5.2");
            //    return;
            //}

            //SQL.AddParam("@date", DateTime.Now.ToString("yyy-MM-dd"));
            //SQL.Query("UPDATE profit set Gross = Sales-Total_Cost where date=@date");
            //if (SQL.HasException(true))
            //{
            //    MessageBox.Show("5.3");
            //    return;
            //}

            //GenerateReceipt();

              // Close();
            //   // return;
            //}
            //else
            //{
            //    new Notification().PopUp("Invoice does not exist or expired", "Error", "error");
            //    Close();
            //}
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

        private void tbTerminalNo_Click(object sender, EventArgs e)
        {
            //SERVER TYPE OR NOT
            if (Properties.Settings.Default.servertype == true)
            {
                tbTerminalNo.Focus();
                this.ActiveControl = tbTerminalNo;
            }
            else
            {
                txtORNo.Focus();
                this.ActiveControl = txtORNo;
            }
        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            //SERVER TYPE OR NOT
            if (Properties.Settings.Default.servertype == true)
            {
                tbTerminalNo.Focus();
                this.ActiveControl = tbTerminalNo;
            }
            else
            {
                txtORNo.Focus();
                this.ActiveControl = txtORNo;
            }
        }
    }
}
