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

namespace EcoPOSv2
{
    public partial class PGiftCard : Form
    {
        public PGiftCard()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        public Payment frmPayment;

        decimal giftcard_amount;

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SQL.AddParam("@giftcard_no", txtGCNo.Text);
            int check_gc = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM giftcard WHERE giftcard_no = @giftcard_no AND status = 'Available'"));
            if (SQL.HasException(true))
                return;

            if (check_gc == 1)
            {
                SQL.AddParam("@giftcard_no", txtGCNo.Text);

                giftcard_amount = Convert.ToDecimal(SQL.ReturnResult("SELECT amount FROM giftcard WHERE giftcard_no = @giftcard_no"));

                if (SQL.HasException(true))
                    return;

                frmPayment.lblGCNo.Text = txtGCNo.Text;
                frmPayment.lblDeductGC.Text = giftcard_amount.ToString();

                Close();
            }
            else
            {
                MessageBox.Show("Gift card does not exist or has been used.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PGiftCard_Load(object sender, EventArgs e)
        {

        }
    }
}
