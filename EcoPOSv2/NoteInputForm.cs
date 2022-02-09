using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class NoteInputForm : Form
    {
        SQLControl SQL = new SQLControl();
        public NoteInputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           }

        private void btnKeep_Click(object sender, EventArgs e)
        {

            if (!txtInputNote.Text.Equals(""))
            {
                List<KeepItem> itemToKeep = new List<KeepItem>();

                //Selects all items from cart per terminal
                SQL.Query("SELECT * FROM order_cart where terminal_id = " + Properties.Settings.Default.Terminal_id);
                if (SQL.HasException(true)) return;
                string note = txtInputNote.Text;
                if (SQL.DBDT.Rows.Count != 0)
                {
                    foreach (DataRow dr in SQL.DBDT.Rows)
                    {
                        int customerID = 0;
                        if (!Order.Instance.lblCustomer.Text.Equals("Name"))
                        {
                            //Gets current customer ID
                            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                            customerID = Convert.ToInt32(SQL.ReturnResult("SELECT cus_ID_no FROM order_no WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no where terminal_id=@terminal_id)"));
                            if (SQL.HasException(true)) return;
                            //Removes customer details on cart
                            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                            SQL.Query(@"UPDATE order_no SET action = 1, discountID = 0, cus_type = 0, cus_name = '',
                            cus_ID_no = 0, cus_mem_ID = 0, disc_amt = 0, cus_rewardable = 0, cus_amt_per_pt = 0, 
                            return_order_ref = 0, refund_order_ref = 0 WHERE terminal_id=@terminal_id AND order_ref = (SELECT MAX(order_ref) FROM order_no where terminal_id=@terminal_id)");
                            if (SQL.HasException(true))
                                return;

                            Order.Instance.lblCustomer.Text = "Name";
                        }
                        KeepItem keepItem = new KeepItem(int.Parse(dr["terminal_id"].ToString()), int.Parse(dr["productID"].ToString()), dr["type"].ToString(), Convert.ToInt32(Convert.ToDouble(dr["quantity"].ToString())), Convert.ToDecimal(dr["disc_percent"].ToString()), customerID);
                        itemToKeep.Add(keepItem);
                    }

                    SQL.Query("SELECT * FROM keep WHERE note ='" + note + "'");
                    if (SQL.HasException(true)) return;
                    if (SQL.DBDT.Rows.Count == 0)
                    {
                        if (itemToKeep.Count > 0)
                        {
                            foreach (KeepItem item in itemToKeep)
                            {
                                SQL.Query("INSERT INTO keep (terminalID, productID, type, quantity, discount, total, customerID, note, dateTime) VALUES (" + item.TerminalID + "," + item.ProductID + ",'" + item.Type + "'," + item.Quantity + "," + item.Discount + "," + Convert.ToDouble(Order.Instance.lblTotal.Text) + "," + item.CustomerID + ",'" + note + "','" + DateTime.Now.ToString() + "')");
                                if (SQL.HasException(true)) return;
                            }
                        }
                        SQL.Query("DELETE FROM order_cart WHERE terminal_id = " + Properties.Settings.Default.Terminal_id);
                        if (SQL.HasException(true)) return;
                        Order.Instance.LoadOrder();
                        Order.Instance.GetTotal();
                        Close();
                    }
                    else
                    {
                        new Notification().PopUp("Name already listed on keep.", "Error", "error");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnKeep_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnKeep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnKeep.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void NoteInputForm_Load(object sender, EventArgs e)
        {
            txtInputNote.Focus();
        }
    }
}
