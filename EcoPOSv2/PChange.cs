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
    public partial class PChange : GlobalHotKeyForm
    {
        public PChange()
        {
            InitializeComponent();
            //GLOBAL HOTKEY
            //AddHotKeyRegisterer(CloseForm, HotKeyMods.Control, ConsoleKey.Insert);
            AddHotKeyRegisterer(CloseForm, HotKeyMods.None,ConsoleKey.Enter);
            //GLOBAL HOTKEY
        }
        SQLControl SQL = new SQLControl();
        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        public Payment frmPayment;

        private int count = 0;

        private void PChange_Load(object sender, EventArgs e)
        {
            //tmrClose.Start();
            btnConfirm.Focus();

            FormLoad Fl = new FormLoad();
            Fl.CusDisplay("CHANGE:", lblChange.Text);
        }
        private void btnReprint_Click(object sender, EventArgs e)
        {
            frmPayment.report.SetParameterValue("note", "###REPRINT###");
            frmPayment.PrintReceipt();
        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 5)
            {
                Close();
            }
        }
        public void Advance_OrderNo()
        {
            SQL.Query(@"INSERT INTO order_no (order_no)
                       SELECT (order_no + 1) FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)");

            if (SQL.HasException(true))
                return;

            Order.Instance.LoadOrderNo();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            FormLoad Fl = new FormLoad();
            Fl.CusDisplay("Hello", "Welcome!");

            this.Close();

            Order.Instance.btnDiscount.Enabled = true;
            Order.Instance.btnCustomer.Enabled = true;
            Order.Instance.btnQuantity.Enabled = true;

            Advance_OrderNo();
            Order.Instance.LoadOrder();
            Order.Instance.GetTotal();
            Order.Instance.LoadOrderNo();
            Order.Instance.tbBarcode.Focus();


            //Order.Instance.LoadOrder();
            //Order.Instance.GetTotal();
        }
    }
}
