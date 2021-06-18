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
    public partial class Inventory : Form
    {
        FormLoad OL = new FormLoad();
        Form currentChildForm;
        Button currentButton;
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            currentChildForm = new AInventory();
            currentButton = btnInventory;

            OL.changeFormWithButton(new AInventory(), ref currentChildForm, btnInventory, ref currentButton, ref pnlChild);
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new AInventory(), ref currentChildForm, btnInventory, ref currentButton, ref pnlChild);
        }

        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new APurchase(), ref currentChildForm, btnPurchase, ref currentButton, ref pnlChild);
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new AReturn(), ref currentChildForm, btnReturn, ref currentButton, ref pnlChild);
        }

        private void BtnSupplier_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new ASupplier(), ref currentChildForm, btnSupplier, ref currentButton, ref pnlChild);
        }

        private void BtnWarehouse_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new AWarehouse(), ref currentChildForm, btnWarehouse, ref currentButton, ref pnlChild);
        }

        private void BtnOR_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new AOperation(), ref currentChildForm, btnOR, ref currentButton, ref pnlChild);
        }
    }
}
