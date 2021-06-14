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
    public partial class E_Journal : Form
    {
        public E_Journal()
        {
            InitializeComponent();
        }

        private FormLoad OL = new FormLoad();
        private Form currentChildForm;
        private Form openChildForm;
        private Button currentButton;

        private void E_Journal_Load(object sender, EventArgs e)
        {
            currentButton = btnTerminal;
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new VoidReport(), ref currentChildForm, btnVoid, ref currentButton, ref pnlChild);
        }

        private void btnRD_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new RegularDiscountReport(), ref currentChildForm, btnVoid, ref currentButton, ref pnlChild);
        }

        private void btnSD_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new SpecialDiscount(), ref currentChildForm, btnVoid, ref currentButton, ref pnlChild);
        }

        private void btnZReading_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new ZReadingRecords(), ref currentChildForm, btnVoid, ref currentButton, ref pnlChild);
        }

        private void btnXReading_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new XReadingRecords(), ref currentChildForm, btnVoid, ref currentButton, ref pnlChild);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new StaffReport(), ref currentChildForm, btnVoid, ref currentButton, ref pnlChild);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new Transactions(), ref currentChildForm, btnVoid, ref currentButton, ref pnlChild);
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new Terminal(), ref currentChildForm, btnVoid, ref currentButton, ref pnlChild);
        }
    }
}
