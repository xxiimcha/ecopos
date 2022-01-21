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
    public partial class OptionConfirmation : Form
    {
        string message, buttonText1, buttonText2;
        SQLControl SQL = new SQLControl();
        int customerID = 0;

        private void btn1_Click(object sender, EventArgs e)
        {
            

            SQL.Query("Delete FROM order_cart WHERE terminal_id = " + Properties.Settings.Default.Terminal_id);
            if (SQL.HasException(true)) return;

            SQL.Query("SELECT * FROM keep WHERE note = '" + message + "'");
            if (SQL.HasException(true)) return;

            foreach (DataRow dr in SQL.DBDT.Rows)
            {
                string type_query = "";
                string type = dr["type"].ToString();

                if (type.Equals("W")) //Checks and sets if item is wholesale or retail
                {
                    type_query = "wp_exclusive, wp_tax, wp_inclusive";
                }
                else
                {
                    type_query = " rp_exclusive, rp_tax, rp_inclusive";
                }

                if (!dr["customerID"].ToString().Equals("0")) //Check if customer was set
                {
                    customerID = Convert.ToInt32(dr["customerID"].ToString());
                    SQL.Query("SELECT * FROM customer WHERE customerID=" + dr["customerID"]);
                    if (SQL.HasException(true)) return;

                    foreach (DataRow dr2 in SQL.DBDT.Rows)
                    {
                        
                        SQL.AddParam("@cus_name", dr2["name"]);
                        SQL.AddParam("@cus_mem_ID", dr2["member_type_ID"]);
                        Order.Instance.lblCustomer.Text = dr2["name"].ToString();
                    }
                    SQL.AddParam("@customerID", dr["customerID"]);
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
                }

                //Overwrites cart with items on keep
                SQL.AddParam("@productID", dr["productID"]);
                SQL.AddParam("@type", type);
                SQL.AddParam("@quantity", dr["quantity"]);
                SQL.AddParam("@discount", dr["discount"]);
                SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                SQL.Query(@"INSERT INTO order_cart (productID , description, name, type, static_price_exclusive, static_price_vat, static_price_inclusive, quantity, discount,cost,terminal_id,is_vatable) 
                       SELECT productID, description, name, @type," + type_query + ", @quantity, @discount, cost, @terminal_id,is_vatable FROM products WHERE productID = @productID");
                if (SQL.HasException(true)) return;
            }

            //Deletes the items from keep table
                SQL.Query("DELETE FROM keep WHERE note = '" + message + "'");
                if (SQL.HasException(true)) return;

            #region discountable and percent disc

            // check if membership is discountable and percentage type

            SQL.AddParam("@customerID", customerID);
            int result = Convert.ToInt32(SQL.ReturnResult(@"SELECT COUNT(*) FROM membership as m 
                                                    INNER JOIN customer as c ON m.member_type_ID = c.member_type_ID
                                                    WHERE c.customerID = @customerID AND m.discountable = 1 AND disc_type = 2"));
            if (SQL.HasException(true))
                return;
            if (result == 1)
            {
                SQL.AddParam("@customerID", customerID);
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

            Order.Instance.LoadOrder();
            Order.Instance.GetTotal();
            ItemsOnKeepView.Instance.Close();
            Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SQL.Query("DELETE FROM keep WHERE note = '" + message + "'");
            if (SQL.HasException(true)) return;
            Close();
        }

        private void OptionConfirmation_Load(object sender, EventArgs e)
        {
            btn1.Text = buttonText1;
            btn2.Text = buttonText2;
        }

        public OptionConfirmation(string message, string buttonText1, string buttonText2)
        {
            InitializeComponent();
            this.message = message;
            this.buttonText1 = buttonText1;
            this.buttonText2 = buttonText2;
        }

       

    }
}
