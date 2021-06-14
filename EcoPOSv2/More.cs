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
    public partial class More : Form
    {

        RolePermission RP = new RolePermission();

        public More()
        {
            InitializeComponent();
        }

        private void BtnEJournal_Click(object sender, EventArgs e)
        {
            Main.Instance.OpenChildForm(new E_Journal());
        }

        private void BtnLogs_Click(object sender, EventArgs e)
        {
            Main.Instance.OpenChildForm(new Logs());
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            Main.Instance.OpenChildForm(new Customers());
        }

        private void BtnRedeemSettings_Click(object sender, EventArgs e)
        {
            Main.Instance.OpenChildForm(new RedeemSettings());
        }

        private void BtnManageDiscounts_Click(object sender, EventArgs e)
        {
            Main.Instance.OpenChildForm(new ManageDiscounts());
        }

        private void BtnManageProducts_Click(object sender, EventArgs e)
        {
            Main.Instance.OpenChildForm(new ManageProducts());
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            Main.Instance.OpenChildForm(new Inventory());
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            Main.Instance.OpenChildForm(new SecureZReading());
        }

        private void BtnDatabase_Click(object sender, EventArgs e)
        {
            Main.Instance.OpenChildForm(new Database());
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            Main.Instance.OpenChildForm(new Settings());
        }
    }
}
