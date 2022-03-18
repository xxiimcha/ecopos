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
    public partial class RegularDiscount : Form
    {
        public RegularDiscount()
        {
            InitializeComponent();
        }

        private SQLControl SQL = new SQLControl();

        public Order frmOrder;
        public DiscountOption frmDiscountOption;

        //METHODS
        private void LoadDiscount()
        {
            SQL.Query("SELECT discountID, disc_name as 'Discount', disc_amt as 'Amount', disc_type as 'Discount Type' FROM discount ORDER BY disc_name ASC");

            if (SQL.HasException(true))
                return;

            dgvDiscount.DataSource = SQL.DBDT;
            dgvDiscount.Columns[0].Visible = false;
        }

        //METHODS
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvDiscount.SelectedRows.Count == 0)
                return;

            int discountID = Convert.ToInt32(dgvDiscount.SelectedRows[0].Cells[0].Value.ToString());
            int disc_type = Convert.ToInt32(dgvDiscount.SelectedRows[0].Cells[3].Value.ToString());
            decimal disc_amt = decimal.Parse(dgvDiscount.SelectedRows[0].Cells[2].Value.ToString());

            SQL.AddParam("@discountID", discountID);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query("UPDATE order_no SET discountID = @discountID WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no WHERE terminal_id=@terminal_id)");
            

            if (SQL.HasException(true))
                return;

            if (disc_type == 1)
            {
                frmOrder.apply_regular_discount_fix_amt = true;

                SQL.AddParam("@disc_amt", disc_amt);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                SQL.Query("UPDATE order_no SET disc_amt = @disc_amt WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no WHERE terminal_id=@terminal_id)");


                if (SQL.HasException(true))
                    return;

                frmOrder.regular_disc_amt = disc_amt;
            }
            else if (disc_type == 2)
            {
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                SQL.Query("SELECT * FROM order_cart WHERE terminal_id=@terminal_id ORDER BY itemID ASC");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    SQL.AddParam("@itemID", r["itemID"]);
                    SQL.AddParam("@disc_amt", disc_amt);
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    SQL.Query(@"UPDATE oc SET
                               oc.is_disc_percent = p.s_discR,
                               oc.disc_percent = IIF(p.s_discR = 1, @disc_amt, 0)
                               FROM order_cart as oc
                               INNER JOIN products as p ON oc.productID = p.productID
                               WHERE oc.itemID = @itemID AND oc.type='R' AND oc.terminal_id=@terminal_id");

                    if (SQL.HasException(true))
                        return;


                    //UPDATE DISCOUNT
                    SQL.AddParam("@itemID", r["itemID"]);
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    SQL.Query("UPDATE order_cart SET discount=(selling_price_inclusive*(disc_percent/100)) where itemID=@itemID AND type='R' AND terminal_id=@terminal_id");

                    if (SQL.HasException(true))
                        return;
                }
            }

            Main.Instance.btnOrder.PerformClick();
            new Notification().PopUp("Discount applied.","","success");
            frmDiscountOption.Close();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegularDiscount_Load(object sender, EventArgs e)
        {
            LoadDiscount();
        }

        private void dgvDiscount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnConfirm.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
