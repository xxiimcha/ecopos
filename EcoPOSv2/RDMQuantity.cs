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
    public partial class RDMQuantity : Form
    {
        private SQLControl SQL = new SQLControl();
        public int itemID;

        public RDMQuantity()
        {
            InitializeComponent();
        }

        private void RDMQuantity_Load(object sender, EventArgs e)
        {
            AssignValidation(ref txtQuantity, ValidationType.Int_Only);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "0" | txtQuantity.Text == "")
                return;
            SQL.AddParam("@itemID", itemID);
            SQL.AddParam("@quantity", txtQuantity.Text);
            SQL.Query("UPDATE redeem_cart SET quantity = @quantity WHERE itemID = @itemID");
            if (SQL.HasException(true))
                return;
            RedeemCart.Instance.LoadCart();
            RedeemCart.Instance.GetTotal();
            Close();
        }

        private void BtnQuantity_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
