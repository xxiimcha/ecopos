using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
