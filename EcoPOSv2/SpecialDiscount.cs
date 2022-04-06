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
    public partial class SpecialDiscount : Form
    {
        public SpecialDiscount()
        {
            InitializeComponent();
        }

        private SQLControl SQL = new SQLControl();

        public Order frmOrder;
        public DiscountOption frmDiscountOption;

        private void SpecialDiscount_Load(object sender, EventArgs e)
        {
            cmbDesc.SelectedIndex = 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtIDNo.Text == "" || txtName.Text == "")
            {
                new Notification().PopUp("Please complete all the field(s)","Error","error");
                cmbDesc.Focus();
                return;
            }

            frmOrder.apply_special_discount = true;

            int cus_type;

            if (cmbDesc.SelectedIndex == 0)
                cus_type = 1;
            else if (cmbDesc.SelectedIndex == 1)
                cus_type = 2;
            else
                cus_type = 3;

            SQL.AddParam("@cus_name", txtName.Text);
            SQL.AddParam("@cus_special_ID_no", txtIDNo.Text);
            SQL.AddParam("@cus_type", cus_type);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query(@"UPDATE order_no SET cus_type = @cus_type, cus_name = @cus_name, 
                       cus_special_ID_no = @cus_special_ID_no WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no WHERE terminal_id=@terminal_id)");

            if (SQL.HasException(true))
                return;


            // update cart items if cart not empty
            if (frmOrder.dgvCart.RowCount > 0)
            {
                switch (cus_type)
                {
                    case 1:
                    case 2:
                        {
                            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                            SQL.Query("SELECT * FROM order_cart WHERE terminal_id=@terminal_id ORDER BY itemID ASC");

                            if (SQL.HasException(true))
                                return;

                            foreach (DataRow r in SQL.DBDT.Rows)
                            {
                                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                                SQL.AddParam("@itemID", r["itemID"]);
                                SQL.Query(@"UPDATE oc SET
                                   oc.is_disc_percent = p.s_discPWD_SC,
                                   oc.is_less_vat = 1,
                                   oc.disc_percent = s_PWD_SC_perc,
                                   oc.is_vat_exempt = 1
                                   FROM order_cart as oc
                                   INNER JOIN products as p ON oc.productID = p.productID
                                   WHERE oc.itemID = @itemID AND oc.type='R' AND oc.terminal_id=@terminal_id");

                                if (SQL.HasException(true))
                                    return;
                            }

                            break;
                        }

                    default:
                        {
                            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                            SQL.Query("SELECT * FROM order_cart WHERE terminal_id=@terminal_id");

                            if (SQL.HasException(true))
                                return;

                            foreach (DataRow r in SQL.DBDT.Rows)
                            {
                                SQL.AddParam("@itemID", r["itemID"]);
                                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                                SQL.Query(@"UPDATE oc SET
                                oc.is_disc_percent = p.s_discAth,
                                oc.disc_percent = 1
                                FROM order_cart as oc
                                INNER JOIN products as p ON oc.productID = p.productID
                                WHERE oc.itemID = @itemID AND oc.terminal_id=@terminal_id");

                                if (SQL.HasException(true))
                                    return;
                            }

                            break;
                        }
                }

                frmOrder.LoadOrder();
                frmOrder.GetTotal();
                frmOrder.lblCustomer.Text = txtName.Text;
                new Notification().PopUp("Discount applied.","","success");
                frmDiscountOption.Close();
                Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIDNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
        }

        private void cmbDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
    }
}
