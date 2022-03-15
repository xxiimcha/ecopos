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
    public partial class OCustomer : Form
    {


        private SQLControl SQL = new SQLControl();
        public Order frmOrder;

        public OCustomer()
        {
            InitializeComponent();
            
        }

        private void Escape(object sender, EventArgs e)
        {
            this.Close();

            Order.Instance.ActiveControl = Order.Instance.tbBarcode;
        }

        private void LoadCustomer()
        {
            SQL.AddParam("@find", "%" + txtNameCard.Text + "%");
            SQL.Query(@"SELECT customerID, name as 'Customer', card_no as 'Card No.', member_type_ID FROM 
                       customer WHERE name LIKE @find OR card_no LIKE @find ORDER BY name ASC");
            if (SQL.HasException(true))
                return;
            dgvCustomer.DataSource = SQL.DBDT;
            dgvCustomer.Columns[0].Visible = false;
            dgvCustomer.Columns[3].Visible = false;
        }

        private void OCustomer_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtNameCard;

            LoadCustomer();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count == 0)
                return;
            SQL.AddParam("@customerID", dgvCustomer.CurrentRow.Cells[0].Value.ToString());
            SQL.AddParam("@cus_name", dgvCustomer.CurrentRow.Cells[1].Value.ToString());
            SQL.AddParam("@cus_mem_ID", dgvCustomer.CurrentRow.Cells[3].Value.ToString());
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

            SQL.Query(@"UPDATE order_no SET 
                          cus_type = 4, 
                          cus_name = @cus_name, 
                          cus_ID_no = @customerID, 
                          cus_mem_ID = @cus_mem_ID,  
                          disc_amt = IIF(t.disc_type = 1, t.disc_amt, 0), 
                          cus_rewardable = t.rewardable, 
                          cus_amt_per_pt = IIF(t.rewardable = 1, t.amt_per_pt, 0) FROM
                        (SELECT  
                          c.member_type_ID,
                          m.disc_type, 
                          m.disc_amt, 
                          m.rewardable, 
                          m.amt_per_pt
                        FROM customer as c          
                        INNER JOIN membership as m ON c.member_type_ID = m.member_type_ID
                        WHERE c.customerID = @customerID) as t
                        WHERE order_ref = (SELECT MAX(order_ref) FROM order_no WHERE terminal_id=@terminal_id)");
            if (SQL.HasException(true))
                return;

            #region discountable and percent disc

            // check if membership is discountable and percentage type

            SQL.AddParam("@customerID", dgvCustomer.CurrentRow.Cells[0].Value.ToString());
            int result = Convert.ToInt32(SQL.ReturnResult(@"SELECT COUNT(*) FROM membership as m 
                                                    INNER JOIN customer as c ON m.member_type_ID = c.member_type_ID
                                                    WHERE c.customerID = @customerID AND m.discountable = 1 AND disc_type = 2"));
            if (SQL.HasException(true))
                return;
            if (result == 1)
            {
                SQL.AddParam("@customerID", dgvCustomer.CurrentRow.Cells[0].Value.ToString());
                decimal disc_amt = Convert.ToDecimal(SQL.ReturnResult(@"SELECT disc_amt FROM membership as m INNER JOIN customer as c 
                                                             ON m.member_type_ID = c.member_type_ID WHERE c.customerID = @customerID"));
                if (SQL.HasException(true))
                    return;

                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                SQL.Query("SELECT * FROM order_cart WHERE terminal_id = @terminal_id ORDER BY itemID ASC");
                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    SQL.AddParam("@itemID", r["itemID"].ToString());
                    SQL.AddParam("@disc_amt", disc_amt);
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    SQL.Query(@"UPDATE oc SET
                               oc.is_disc_percent = p.s_discR,
                               oc.disc_percent = IIF(p.s_discR = 1, @disc_amt, 0)
                               FROM order_cart as oc
                               INNER JOIN products as p ON oc.productID = p.productID
                               WHERE oc.terminal_id = @terminal_id AND oc.itemID = @itemID");
                    if (SQL.HasException(true))
                        return;

                    //UPDATE DISCOUNT
                    SQL.AddParam("@itemID", r["itemID"].ToString());
                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    SQL.Query("UPDATE order_cart SET discount=(selling_price_inclusive*(disc_percent/100)) where itemID=@itemID AND terminal_id=@terminal_id");

                    if (SQL.HasException(true))
                        return;
                }
            }

            #endregion

            #region discountable and fix amount

            SQL.AddParam("@customerID", dgvCustomer.CurrentRow.Cells[0].Value.ToString());
            int result_fx = Convert.ToInt32(SQL.ReturnResult(@"SELECT COUNT(*) FROM membership as m 
                                                    INNER JOIN customer as c ON m.member_type_ID = c.member_type_ID
                                                    WHERE c.customerID = @customerID AND m.discountable = 1 AND disc_type = 1"));
            if (SQL.HasException(true))
                return;
            if (result_fx == 1)
            {
                SQL.AddParam("@member_type_ID", dgvCustomer.CurrentRow.Cells[3].Value.ToString());
                frmOrder.regular_disc_amt = Convert.ToDecimal(SQL.ReturnResult("SELECT disc_amt FROM membership WHERE member_type_ID = @member_type_ID"));
                if (SQL.HasException(true))
                    return;
                frmOrder.apply_regular_discount_fix_amt = true;
            }


            #endregion

            frmOrder.lblCustomer.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            frmOrder.LoadOrder();
            frmOrder.GetTotal();
            new Notification().PopUp("Discount applied.", "","information");
            frmOrder.apply_member = true;
            Close();
        }

        private void TxtNameCard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            LoadCustomer();
        }

        private void DgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnConfirm.PerformClick();
        }
    }
}
