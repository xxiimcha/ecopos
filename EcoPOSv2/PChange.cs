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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
