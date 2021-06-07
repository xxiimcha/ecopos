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
            this.Close();

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
