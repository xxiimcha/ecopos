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
    public partial class Quantity : Form
    {
        public Quantity()
        {
            InitializeComponent();
        }

        private SQLControl SQL = new SQLControl();
        public Order frmOrder;
        public string itemID;
        public string productID;
        public decimal currentQty;

        private void Quantity_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "" | txtQuantity.Text == "0")
                return;

            SQL.AddParam("@productID", productID);
            SQL.AddParam("@currentQty", currentQty);
            SQL.AddParam("@newQty", decimal.Parse(txtQuantity.Text));
            int checkqty = int.Parse(SQL.ReturnResult("SELECT IIF((SELECT ((SUM(quantity) - @currentQty) + @newQty) FROM order_cart WHERE productID = @productID) > (SELECT stock_qty FROM inventory WHERE productID = @productID), 1, 0)"));
            if (SQL.HasException(true)) return;
            if (checkqty == 1)
            {
                new Notification().PopUp("Insufficient stock", "", "error");
                return;
            }

            SQL.AddParam("@itemID", itemID);
            SQL.AddParam("@quantity", txtQuantity.Text);

            SQL.Query("UPDATE order_cart SET quantity = @quantity WHERE itemID = @itemID");

            if (SQL.HasException(true))
                return;

            frmOrder.LoadOrder();
            frmOrder.GetTotal();
            Close();
            frmOrder.tbBarcode.Focus();
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConfirm.PerformClick();
        }

        private void Quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
