using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private Button currentButton;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public void SetDoubleBuffered(Panel panel)
        {
            typeof(Panel).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               panel,
               new object[] { true });
        }
        private void E_Journal_Load(object sender, EventArgs e)
        {
            currentButton = btnTerminal;

            new CreateParams();
            SetDoubleBuffered(TableLayoutPanel2);
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new VoidReport(), ref currentChildForm, btnVoid, ref currentButton, ref pnlChild);
        }

        private void btnRD_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new RegularDiscountReport(), ref currentChildForm, btnRD, ref currentButton, ref pnlChild);
        }

        private void btnSD_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new SpecialDiscountReport(), ref currentChildForm, btnSD, ref currentButton, ref pnlChild);
        }

        private void btnZReading_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new ZReadingRecords(), ref currentChildForm, btnZReading, ref currentButton, ref pnlChild);
        }

        private void btnXReading_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new XReadingRecords(), ref currentChildForm, btnXReading, ref currentButton, ref pnlChild);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new StaffReport(), ref currentChildForm, btnStaff, ref currentButton, ref pnlChild);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new Transactions(), ref currentChildForm, btnTransactions, ref currentButton, ref pnlChild);
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new Terminal(), ref currentChildForm, btnTerminal, ref currentButton, ref pnlChild);
        }
    }
}
