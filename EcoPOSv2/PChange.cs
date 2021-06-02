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
        public Payment frmPayment;

        private int count = 0;

        private void PChange_Load(object sender, EventArgs e)
        {
            tmrClose.Start();
        }

        private void PChange_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            frmPayment.report.SetParameterValue("note", "###REPRINT###");
            frmPayment.PrintReceipt();
        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            if (count == 5)
                Close();
            else
                count = count + 1;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
