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
            cmbDesc.SelectedIndex = -1;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
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

            SQL.Query(@"UPDATE order_no SET cus_type = @cus_type, cus_name = @cus_name, 
                       cus_special_ID_no = @cus_special_ID_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)");

            if (SQL.HasException(true))
                return;


            // update cart items if cart not empty
            if (Order.Instance.dgvCart.RowCount > 0)
            {
                switch (cus_type)
                {
                    case 1:
                    case 2:
                        {
                            SQL.Query("SELECT * FROM order_cart ORDER BY itemID ASC");

                            if (SQL.HasException(true))
                                return;

                            foreach (DataRow r in SQL.DBDT.Rows)
                            {
                                SQL.AddParam("@itemID", r["itemID"].ToString());
                                SQL.Query(@"UPDATE oc SET
                                   oc.is_disc_percent = p.s_discPWD_SC,
                                   oc.is_less_vat = IIF(p.s_discPWD_SC = 1 AND p.s_PWD_SC_perc = 20, 1, 0),
                                   oc.disc_percent = s_PWD_SC_perc,
                                   oc.is_vat_exempt = IIF(p.s_discPWD_SC = 1 AND p.s_PWD_SC_perc = 20, 1, 0)
                                   FROM order_cart as oc
                                   INNER JOIN products as p ON oc.productID = p.productID
                                   WHERE oc.itemID = @itemID");

                                if (SQL.HasException(true))
                                    return;
                            }

                            break;
                        }

                    default:
                        {
                            SQL.Query("SELECT * FROM order_cart");

                            if (SQL.HasException(true))
                                return;

                            foreach (DataRow r in SQL.DBDT.Rows)
                            {
                                SQL.AddParam("@itemID", r["itemID"].ToString());
                                SQL.Query(@"UPDATE oc SET
                                oc.is_disc_percent = p.s_discAth,
                                oc.disc_percent = IIF(p.s_discAth = 1, 20, 0)
                                FROM order_cart as oc
                                INNER JOIN products as p ON oc.productID = p.productID
                                WHERE oc.itemID = @itemID");

                                if (SQL.HasException(true))
                                    return;
                            }

                            break;
                        }
                }

                Order.Instance.LoadOrder();
                Order.Instance.GetTotal();
                Order.Instance.lblCustomer.Text = txtName.Text;
                new Notification().PopUp("Discount applied.", "", "success");
                frmDiscountOption.Close();
                Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
