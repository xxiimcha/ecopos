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
using static EcoPOSv2.ControlBehavior;

namespace EcoPOSv2
{
    public partial class RedeemCart : Form
    {
        public RedeemCart()
        {
            InitializeComponent();
        }
        private SQLControl SQL = new SQLControl();

        private RedeemReceipt report = new RedeemReceipt();

        public Payment frmPayment;

        public decimal card_balance;
        public int customerID;
        public string card_no;

        public bool clickOnce_dgvRedeemCart = false;

        //METHODS
        private void LoadItems()
        {
            SQL.Query("SELECT productID, description as 'Name', pts as 'Points' FROM redeem_items ORDER BY description ASC");

            if (SQL.HasException(true))
                return;

            dgvRedeemItems.DataSource = SQL.DBDT;
            dgvRedeemItems.Columns[0].Visible = false;
        }
        //METHODS

        private void RedeemCart_Load(object sender, EventArgs e)
        {
            LoadItems();
            Control c = (Control)txtSearchItem;
            ControlBehavior.SetBehavior(ref c, Behavior.ClearSearch);
        }
    }
}
