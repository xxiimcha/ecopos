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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        private FormLoad OL = new FormLoad();
        private SQLControl SQL = new SQLControl();

        private Panel currentPanel;
        private Button currentBtn;

        private TransactionsReport report = new TransactionsReport();
        private PaymentReceipt reprint_receipt = new PaymentReceipt();

        private bool dgvMT_ClickedOnce = false;
        private void btnCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}
