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

        public static RedeemCart _RedeemCart;
        public static RedeemCart Instance
        {
            get
            {
                if (_RedeemCart == null)
                {
                    _RedeemCart = new RedeemCart();
                }
                return _RedeemCart;
            }
        }
        //METHODS
        private void LoadItems()
        {
            SQL.Query("SELECT productID, description as 'Name', pts as 'Points' FROM redeem_items ORDER BY description ASC");

            if (SQL.HasException(true))
                return;

            dgvRedeemItems.DataSource = SQL.DBDT;
            dgvRedeemItems.Columns[0].Visible = false;
        }
        public void LoadCart()
        {
            SQL.Query("SELECT itemID, productID, description as 'Name', CONVERT(DECIMAL(18,2), static_pts) as 'Points', quantity as 'Quantity', total_pts as 'Total' FROM redeem_cart ORDER BY description ASC");

            if (SQL.HasException(true))
                return;

            dgvRedeemCart.DataSource = SQL.DBDT;
            dgvRedeemCart.Columns[0].Visible = false;
            dgvRedeemCart.Columns[1].Visible = false;
        }
        public void GetTotal()
        {
            int count = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM redeem_cart) > 0, 1, 0)"));

            if (SQL.HasException(true))
                return;

            SQL.AddParam("@count", count);
            SQL.Query(@"SELECT IIF(@count > 0, SUM(quantity), 0.00) as 'Quantity',
		                      IIF(@count > 0, SUM(total_pts), 0.00) as 'Total'
		              FROM redeem_cart");

            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                decimal items = decimal.Parse(r["Quantity"].ToString());
                decimal total = decimal.Parse(r["Total"].ToString());

                lblItems.Text = items.ToString("N2");
                lblTotal.Text = total.ToString("N2");

                lblRemainingPoints.Text = (card_balance - total).ToString("N2");
            }
        }

        //METHODS

        private void RedeemCart_Load(object sender, EventArgs e)
        {
            _RedeemCart = this;

            LoadItems();
            Control c = (Control)txtSearchItem;
            ControlBehavior.SetBehavior(ref c, Behavior.ClearSearch);
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            if (clickOnce_dgvRedeemCart == false)
                return;

            if (dgvRedeemCart.SelectedRows.Count == 0)
                return;

            RDMQuantity frmRDMQuantity = new RDMQuantity();
            frmRDMQuantity.itemID = dgvRedeemCart.CurrentRow.Cells[0].Value.ToString();
            frmRDMQuantity.lblItem.Text = dgvRedeemCart.CurrentRow.Cells[2].Value.ToString();
            frmRDMQuantity.txtQuantity.Text = dgvRedeemCart.CurrentRow.Cells[4].Value.ToString();
            frmRDMQuantity.frmRedeemCart = this;
            frmRDMQuantity.ShowDialog();
        }
    }
}
