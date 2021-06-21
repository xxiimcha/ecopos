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
using VeryHotKeys.WinForms;

namespace EcoPOSv2
{
    public partial class Quantity : GlobalHotKeyForm
    {
        public Quantity()
        {
            InitializeComponent();
            AddHotKeyRegisterer(Escape, HotKeyMods.None, ConsoleKey.Escape);
        }

        private void Escape(object sender, EventArgs e)
        {
            this.Close();
        }

        private SQLControl SQL = new SQLControl();
        public Order frmOrder;
        public string itemID;

        private void Quantity_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "" | txtQuantity.Text == "0")
                return;

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
    }
}
