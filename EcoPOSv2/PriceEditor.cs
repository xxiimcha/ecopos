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
using Guna.UI2.WinForms;
namespace EcoPOSv2
{
    public partial class PriceEditor : Form
    {
        public PriceEditor()
        {
            InitializeComponent();
        }
        //VARIABLES
        public string itemID, productID,currentPrice;

        SQLControl SQL = new SQLControl();
        //VARIABLES

        //METHODS
        public static PriceEditor _PriceEditor;

        public static PriceEditor Instance
        {
            get
            {
                if (_PriceEditor == null)
                {
                    _PriceEditor = new PriceEditor();
                }
                return _PriceEditor;
            }
        }
        //METHODS


        private void PriceEditor_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbPrice;
        }

        private void tbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
            
            if(e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
        }

        private void TbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as Guna2TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TbPrice_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblItem.Text == "" || tbPrice.Text == "") return;

                SQL.AddParam("@itemID", itemID);
                SQL.AddParam("@static_price_inclusive", tbPrice.Text);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                SQL.Query("UPDATE order_cart SET base_price_inclusive = @static_price_inclusive, base_price_exclusive = @static_price_inclusive WHERE itemID = @itemID AND terminal_id=@terminal_id");

                if (SQL.HasException(true)) return;

                Order.Instance.LoadOrder();
                Order.Instance.GetTotal();
                Close();
            }
            catch (Exception) { }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
