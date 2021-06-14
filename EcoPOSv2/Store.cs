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
    public partial class Store : Form
    {
        public Store()
        {
            InitializeComponent();
        }

        private void BtnEditReceiptFooter_Click(object sender, EventArgs e)
        {
            var frmEditReceiptFooter = new EditReceiptFooter();
            frmEditReceiptFooter.ShowDialog();
        }

        private void BtnSeeStoreDetails_Click(object sender, EventArgs e)
        {
            var frmEditSD = new EditSD();
            frmEditSD.btnSave.Enabled = false;
            frmEditSD.ShowDialog();
        }

        private void BtnPrintersDevices_Click(object sender, EventArgs e)
        {
            var frmDevices = new Devices();
            frmDevices.ShowDialog();
        }
    }
}
