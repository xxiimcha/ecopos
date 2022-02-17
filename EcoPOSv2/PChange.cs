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
    public partial class PChange : Form
    {
        public PChange()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        private int count = 0;
        public static PChange _PChange;
        public static PChange Instance
        {
            get
            {
                if (_PChange == null)
                {
                    _PChange = new PChange();
                }
                return _PChange;
            }
        }

        private void PChange_Load(object sender, EventArgs e)
        {
            _PChange = this;

            tmrClose.Start();
            this.ActiveControl = btnConfirm;

            FormLoad Fl = new FormLoad();
            Fl.CusDisplay("CHANGE:", lblChange.Text);

            Main.Instance.Enabled = false;
            Focus();
        }
        private void btnReprint_Click(object sender, EventArgs e)
        {
            tmrClose.Stop();
            Payment.Instance.report.SetParameterValue("note", "###REPRINT###");
            Payment.Instance.PrintReceipt();

            tmrClose.Start();
        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 2)
            {
                //btnConfirm.PerformClick();
            }
        }
        
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            FormLoad Fl = new FormLoad();
            Fl.CusDisplay("Hello", "Welcome!");

            //Order.Instance.btnDiscount.Enabled = true;
            //Order.Instance.btnCustomer.Enabled = true;
            //Order.Instance.btnQuantity.Enabled = true;

            
            Order.Instance.LoadOrder();
            Order.Instance.GetTotal();
            Order.Instance.LoadOrderNo();
            Order.Instance.tbBarcode.Focus();

            Order.Instance.apply_regular_discount_fix_amt = false;
            Order.Instance.apply_special_discount = false;
            Order.Instance.apply_member = false;
            Order.Instance.tbBarcode.Enabled = true;
            Order.Instance.lblCustomer.Text = "";
            Order.Instance.lblOperation.Text = "Order/Payment";
            Order.Instance.regular_disc_amt = 0;
            Order.Instance.is_refund = false;
            Order.Instance.is_return = false;
            Main.Instance.Enabled = true;

            Dispose();
        }

        private void PChange_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }

            if(e.KeyCode == Keys.Escape)
            {
                btnConfirm.PerformClick();
            }
        }
    }
}
