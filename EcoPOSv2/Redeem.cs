using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class Redeem : Form
    {
        public Redeem()
        {
            InitializeComponent();
        }

        private void Escape(object sender, EventArgs e)
        {
            this.Close();
        }

        SQLControl SQL = new SQLControl();
        public Order frmOrder;

        private void Redeem_Load(object sender, EventArgs e)
        {
            AssignValidation(ref txtCardNo, ValidationType.Int_Only);
            this.ActiveControl = txtCardNo;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            SQL.AddParam("@card_no", txtCardNo.Text);
            int check_card = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM member_card WHERE card_no = @card_no AND status = 'Active'"));
            if (SQL.HasException(true))
                return;

            if (check_card == 1)
            {
                SQL.AddParam("@card_no", txtCardNo.Text);

                SQL.Query("SELECT card_no, customerID, customer_name, card_balance FROM member_card WHERE card_no = @card_no");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    RedeemCart frmRedeemCart = new RedeemCart();

                    frmRedeemCart.customerID = Convert.ToInt32(r["customerID"].ToString());
                    frmRedeemCart.card_no = r["card_no"].ToString();
                    frmRedeemCart.lblCardNo.Text = r["card_no"].ToString();
                    decimal card_balance = decimal.Parse(r["card_balance"].ToString());
                    frmRedeemCart.card_balance = decimal.Parse(card_balance.ToString("N2"));
                    frmRedeemCart.lblBalance.Text = r["card_balance"].ToString();
                    frmRedeemCart.lblCustomerName.Text = r["customer_name"].ToString();

                    frmRedeemCart.ShowDialog();

                    Close();
                }
            }
            else
                new Notification().PopUp("Card does not exist.", "Error", "error");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

            Order.Instance.tbBarcode.Focus();
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnProceed.PerformClick();
            }
        }

        private void Redeem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
