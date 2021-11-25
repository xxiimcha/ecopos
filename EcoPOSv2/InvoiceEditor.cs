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
    public partial class InvoiceEditor : Form
    {
        public InvoiceEditor()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to set your new Invoice ? \n \n Please read the not below before proceed", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQL.Query("DELETE from delete from audit");
                SQL.Query("delete from order_cart");
                SQL.Query("delete from order_no");
                SQL.Query("delete from profit");
                SQL.Query("delete from order_no");
                SQL.Query("delete from transaction_details");
                SQL.Query("delete from void_transaction");

                int newInvoice = int.Parse(tbInvoice.Text) - 1;
                SQL.Query("DBCC CHECKIDENT ('order_no', RESEED, " + newInvoice + ")");
                if (SQL.HasException(true)) return;


                MessageBox.Show("Save Successfully. Application will be restart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Application.Restart();
            }
            else return;
        }

        private void TbInvoice_Enter(object sender, EventArgs e)
        {
            if(tbInvoice.Text == "0")
            {
                tbInvoice.Text = "";
            }
        }

        private void TbInvoice_Leave(object sender, EventArgs e)
        {
            if (tbInvoice.Text == "")
            {
                tbInvoice.Text = "0";
            }
        }

        private void InvoiceEditor_Load(object sender, EventArgs e)
        {
            
        }
    }
}
