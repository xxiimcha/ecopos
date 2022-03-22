using EcoPOSControl;
using System;
using System.Windows.Forms;
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class StartingCash : Form
    {
        public StartingCash()
        {
            InitializeComponent();
        }
        SQLControl sql = new SQLControl();
        public string open_by_userID, open_by_user_name;



        //METHODS

        //METHODS
        private void tbCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
        }

        private void StartingCash_Load(object sender, EventArgs e)
        {
            //guna2ShadowForm1.SetShadowForm(this);
            tbCash.Focus();
            //AssignValidation(ref tbCash, ValidationType.Price);
            //AssignValidation(ref tbCash, ValidationType.Int_Only);
        }

        private void tbCash_TextChanged(object sender, EventArgs e)
        {
            tbCash.Text = tbCash.Text.Replace(" ", "");
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbCash_Enter(object sender, EventArgs e)
        {
            if(tbCash.Text == "0")
            {
                tbCash.Text = "";
            }
        }

        private void tbCash_Leave(object sender, EventArgs e)
        {
            if (tbCash.Text == "")
            {
                tbCash.Text = "0";
            }
        }

        private void tbCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }
        bool close = false;
        private void StartingCash_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(close == false)
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(tbCash.Text != "") 
            {
                // generate zreading

                sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                string result = sql.ReturnResult(@"SELECT IIF((SELECT COUNT(*) FROM store_start WHERE terminal_id=@terminal_id AND store_status = 'Open' AND zreading_ref = (SELECT MAX(zreading_ref) FROM store_start)) = 0, 'Close', 
                                                (SELECT store_status FROM store_start WHERE terminal_id=@terminal_id AND zreading_ref = (SELECT MAX(zreading_ref) FROM store_start WHERE terminal_id=@terminal_id)))");

                if (sql.HasException(true))
                {
                    MessageBox.Show("Error in selecting Result");
                    return;
                }

                if (result != "Open")
                {
                    sql.AddParam("@open_by_userID", open_by_userID);
                    sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    sql.Query(@"INSERT INTO store_start (open_by_userID, store_status, terminal_id)
                       VALUES (@open_by_userID, 'Open', @terminal_id)");

                    if (sql.HasException(true))
                    {
                        MessageBox.Show("Error in Insert storeStart");
                        return;
                    }

                    sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                    string zreading_ref = sql.ReturnResult("SELECT zreading_ref FROM store_start WHERE terminal_id=@terminal_id AND zreading_ref = (SELECT MAX(zreading_ref) FROM store_start WHERE terminal_id=@terminal_id)");

                    if (sql.HasException(true))
                    {
                        MessageBox.Show("Error in Selecting ZReading_Ref");
                        return;
                    }

                    // generate z reading no
                    sql.AddParam("@zreading_ref", zreading_ref);
                    sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    sql.Query("INSERT INTO zreading (zreading_ref, terminal_id) VALUES (@zreading_ref, @terminal_id)");

                    if (sql.HasException(true))
                    {
                        MessageBox.Show("Error in Inserting Zreading");
                        return;
                    }

                    // start order no


                    sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                    if (sql.ReturnResult("SELECT COUNT(order_ref) FROM order_no").Equals("0"))
                    {
                        sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                        sql.Query("INSERT INTO order_no (order_no, terminal_id) VALUES (1, @terminal_id)");

                        if (sql.HasException(true))
                        {
                            MessageBox.Show("Error in Start Order no");
                            return;
                        }
                    }
                    else
                    {
                        sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
                        int order_ref = sql.ReturnResult("SELECT MAX(order_ref) FROM order_no WHERE terminal_id = @terminal_id") != "" ? int.Parse(sql.ReturnResult("SELECT MAX(order_ref) FROM order_no WHERE terminal_id = @terminal_id")) : 1;
                        sql.Query("SELECT order_ref FROM transaction_items WHERE order_ref = " + order_ref + " ");
                        if (sql.HasException(true)) return;
                        if (sql.DBDT.Rows.Count == 1)
                        {
                            sql.Query("INSERT INTO order_no (order_no, terminal_id) VALUES (1, @terminal_id)");

                            if (sql.HasException(true))
                            {
                                MessageBox.Show("Error in Start Order no");
                                return;
                            }
                        }
                    }
                   
                }


                sql.AddParam("@userID", open_by_userID);
                sql.AddParam("@user_name", open_by_user_name);
                sql.AddParam("@starting_cash", tbCash.Text);
                sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                sql.Query("INSERT INTO shift (userID, user_name, starting_cash,terminal_id) VALUES (@userID, @user_name, @starting_cash,@terminal_id)");

                if (sql.HasException(true)) return;

                // restart order form
                Main.Instance.pnlChild.Controls.Clear();

                Order frmOrder = new Order();
                Main.Instance.OpenChildForm(frmOrder);
                frmOrder.tbBarcode.Focus();

                close = true;
                Close();
            }
            else
            {
                new Notification().PopUp("Please complete all the field(s)", "Error", "error");
            }
        }
    }
}
