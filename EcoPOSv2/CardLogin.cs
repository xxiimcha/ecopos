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
    public partial class CardLogin : Form
    {
        public CardLogin()
        {
            InitializeComponent();
        }
        public string type = "";

        //VOID TRANSACTION VARIABLES
        public string ItemID, ProductID;

        public static CardLogin _CardLogin;
        public static CardLogin Instance
        {
            get
            {
                if (_CardLogin == null)
                {
                    _CardLogin = new CardLogin();
                }
                return _CardLogin;
            }
        }

        private Helper HP = new Helper();
        SQLControl SQL = new SQLControl();

        private void CardLogin_Load(object sender, EventArgs e)
        {
            _CardLogin = this;

            tbCardNo.Focus();


            if(type == "Void")
            {
                this.Text = "Void Transaction Security";
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (lblTapCard.Visible == true)
            {
                lblTapCard.Visible = false;
                tbCardNo.Focus();
            }
            else
            {
                lblTapCard.Visible = true;
                tbCardNo.Focus();
            }
        }

        private void lblTapCard_Click(object sender, EventArgs e)
        {
            tbCardNo.Focus();
        }

        private void CardLogin_Click(object sender, EventArgs e)
        {
            tbCardNo.Focus();
        }

        private void tbCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (type)
                {
                    case "1":
                        SQL.AddParam("@card_no", tbCardNo.Text);
                        string checkuser = SQL.ReturnResult("SELECT COUNT(*) as result FROM users WHERE card_no = @card_no");

                        if (SQL.HasException(true))
                        {
                            MessageBox.Show("1");
                            return;
                        }

                        if (checkuser == "0")
                        {
                            SQL.AddParam("@card_no", tbCardNo.Text);
                            SQL.Query("SELECT * FROM admin_accts WHERE card_no=@card_no");
                            if (SQL.HasException(true))
                            {
                                MessageBox.Show("2");
                                return;
                            }

                            //MessageBox.Show(SQL.DBDT.Rows.Count.ToString());

                            if (SQL.DBDT.Rows.Count > 0)
                            {
                                foreach (DataRow dr in SQL.DBDT.Rows)
                                {
                                    Login.Instance.tbUsername.Text = dr["user_name"].ToString();
                                    Login.Instance.tbPassword.Text = HP.Decrypt(dr["password"].ToString());

                                    this.Close();
                                }
                            }
                            else
                            {
                                new Notification().PopUp("Invalid card No", "Error", "error");
                                tbCardNo.Clear();
                                return;
                            }
                        }
                        else
                        {
                            SQL.AddParam("@card_no", tbCardNo.Text);
                            SQL.Query("SELECT * FROM users WHERE card_no=@card_no");
                            if (SQL.HasException(true))
                            {
                                MessageBox.Show("3");
                                return;
                            }

                            if (SQL.DBDT.Rows.Count > 0)
                            {
                                foreach (DataRow dr in SQL.DBDT.Rows)
                                {
                                    Login.Instance.tbUsername.Text = dr["user_name"].ToString();
                                    Login.Instance.tbPassword.Text = HP.Decrypt(dr["password"].ToString());

                                    this.Close();
                                }
                            }
                            else
                            {
                                new Notification().PopUp("Invalid card No", "Error", "error");
                                tbCardNo.Clear();
                                return;
                            }
                        }
                        break;

                    case "2":
                        //SQLControl SQL = new SQLControl();

                        SQL.AddParam("@card_no", tbCardNo.Text);
                        string checkuser1 = SQL.ReturnResult("SELECT COUNT(*) as result FROM users WHERE card_no = @card_no");

                        if (SQL.HasException(true))
                        {
                            MessageBox.Show("1");
                            return;
                        }

                        if (checkuser1 == "0")
                        {
                            SQL.AddParam("@card_no", tbCardNo.Text);
                            SQL.Query("SELECT * FROM admin_accts WHERE card_no=@card_no");
                            if (SQL.HasException(true))
                            {
                                MessageBox.Show("2");
                                return;
                            }

                            //MessageBox.Show(SQL.DBDT.Rows.Count.ToString());

                            if (SQL.DBDT.Rows.Count > 0)
                            {
                                foreach (DataRow dr in SQL.DBDT.Rows)
                                {
                                    //Login.Instance.tbUsername.Text = dr["user_name"].ToString();
                                    ContinueSession.Instance.tbCSPassword.Text = HP.Decrypt(dr["password"].ToString());

                                    this.Close();
                                }
                            }
                            else
                            {
                                new Notification().PopUp("Invalid card No", "Error", "error");
                                tbCardNo.Clear();
                                return;
                            }
                        }
                        else
                        {
                            SQL.AddParam("@card_no", tbCardNo.Text);
                            SQL.Query("SELECT * FROM users WHERE card_no=@card_no");
                            if (SQL.HasException(true))
                            {
                                MessageBox.Show("3");
                                return;
                            }

                            if (SQL.DBDT.Rows.Count > 0)
                            {
                                foreach (DataRow dr in SQL.DBDT.Rows)
                                {
                                    Login.Instance.tbUsername.Text = dr["user_name"].ToString();
                                    Login.Instance.tbPassword.Text = HP.Decrypt(dr["password"].ToString());

                                    this.Close();
                                }
                            }
                            else
                            {
                                new Notification().PopUp("Invalid card No", "Error", "error");
                                tbCardNo.Clear();
                                return;
                            }
                        }
                        break;


                    case "3":
                        SQL.AddParam("@card_no", tbCardNo.Text);
                        string checkuser3 = SQL.ReturnResult("SELECT COUNT(*) as result FROM admin_accts WHERE card_no = @card_no");

                        if (SQL.HasException(true))
                        {
                            MessageBox.Show("1");
                            return;
                        }

                        if (checkuser3 == "1")
                        {
                            SQL.AddParam("@card_no", tbCardNo.Text);
                            SQL.Query("SELECT * FROM admin_accts WHERE card_no=@card_no");
                            if (SQL.HasException(true))
                            {
                                MessageBox.Show("2");
                                return;
                            }

                            //MessageBox.Show(SQL.DBDT.Rows.Count.ToString());

                            if (SQL.DBDT.Rows.Count > 0)
                            {
                                foreach (DataRow dr in SQL.DBDT.Rows)
                                {
                                    ContinueSession.Instance.tbUsername.Text = dr["user_name"].ToString();
                                    ContinueSession.Instance.tbPassword.Text = HP.Decrypt(dr["password"].ToString());

                                    this.Close();
                                }
                            }
                            else
                            {
                                new Notification().PopUp("Invalid card No", "Error", "error");
                                tbCardNo.Clear();
                                return;
                            }
                        }
                        else
                        {
                            new Notification().PopUp("Invalid admin card No", "Error", "error");
                            tbCardNo.Clear();
                            return;
                        }
                        break;

                    case "Void":
                        SQL.AddParam("@card_no", tbCardNo.Text);
                        string Voidcheckuser = SQL.ReturnResult("SELECT COUNT(*) as result FROM users WHERE card_no = @card_no");

                        if (SQL.HasException(true))
                        {
                            MessageBox.Show("1");
                            return;
                        }

                        if (Voidcheckuser == "0")
                        {
                            SQL.AddParam("@card_no", tbCardNo.Text);
                            SQL.Query("SELECT * FROM admin_accts WHERE card_no=@card_no");
                            if (SQL.HasException(true))
                            {
                                MessageBox.Show("2");
                                return;
                            }

                            //MessageBox.Show(SQL.DBDT.Rows.Count.ToString());

                            if (SQL.DBDT.Rows.Count > 0)
                            {
                                foreach (DataRow dr in SQL.DBDT.Rows)
                                {
                                    //VOID PROCESS ADMIN ACCOUNT
                                    // save to void item
                                    SQL.AddParam("@productID", ProductID);
                                    SQL.AddParam("@userID", Main.Instance.current_id);
                                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                                    SQL.Query(@"INSERT INTO void_item (itemID, productID, order_no, description, name, type, static_price_exclusive,
                       static_price_vat, static_price_inclusive, quantity, userID, terminal_id) SELECT itemID, productID, 
                       (SELECT order_no FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)), description, 
                       name, type, static_price_exclusive, static_price_vat, static_price_inclusive, quantity, @userID, @terminal_id
                       FROM order_cart WHERE terminal_id=@terminal_id and productID = @productID");

                                    if (SQL.HasException(true))
                                    {
                                        MessageBox.Show("Error In Inserting VoidItem");
                                        return;
                                    }

                                    SQL.AddParam("@itemID", ItemID);
                                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                                    SQL.Query("DELETE FROM order_cart WHERE itemID = @itemID AND terminal_id=@terminal_id");

                                    if (SQL.HasException(true))
                                        return;

                                    Order.Instance.LoadOrder();
                                    Order.Instance.GetTotal();

                                    this.Close();
                                }
                            }
                            else
                            {
                                new Notification().PopUp("Invalid card No", "Error", "error");
                                tbCardNo.Clear();
                                return;
                            }
                        }
                        else
                        {
                            SQL.AddParam("@card_no", tbCardNo.Text);
                            SQL.Query("SELECT * FROM users WHERE card_no=@card_no");
                            if (SQL.HasException(true))
                            {
                                MessageBox.Show("3");
                                return;
                            }

                            if (SQL.DBDT.Rows.Count > 0)
                            {
                                foreach (DataRow dr in SQL.DBDT.Rows)
                                {
                                    //VOID PROCESS USER ACCOUNT
                                    // save to void item
                                    SQL.AddParam("@productID", ProductID);
                                    SQL.AddParam("@userID", Main.Instance.current_id);
                                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                                    SQL.Query(@"INSERT INTO void_item (itemID, productID, order_no, description, name, type, static_price_exclusive,
                       static_price_vat, static_price_inclusive, quantity, userID, terminal_id) SELECT itemID, productID, 
                       (SELECT order_no FROM order_no WHERE order_ref = (SELECT MAX(order_ref) FROM order_no)), description, 
                       name, type, static_price_exclusive, static_price_vat, static_price_inclusive, quantity, @userID, @terminal_id
                       FROM order_cart WHERE terminal_id=@terminal_id and productID = @productID");

                                    if (SQL.HasException(true))
                                    {
                                        MessageBox.Show("Error In Inserting VoidItem");
                                        return;
                                    }

                                    SQL.AddParam("@itemID", ItemID);
                                    SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                                    SQL.Query("DELETE FROM order_cart WHERE itemID = @itemID AND terminal_id=@terminal_id");

                                    if (SQL.HasException(true))
                                        return;

                                    Order.Instance.LoadOrder();
                                    Order.Instance.GetTotal();


                                    this.Close();
                                }
                            }
                            else
                            {
                                new Notification().PopUp("Invalid card No", "Error", "error");
                                tbCardNo.Clear();
                                return;
                            }
                        }
                        break;
                }
            }
        }

        private void CardLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (type == "1")
            {
                Login.Instance.btnLogin.PerformClick();
            }
            else if (type == "2")
            {
                ContinueSession.Instance.btnContinueSession.PerformClick();
            }
            else if (type == "3")
            {
                ContinueSession.Instance.btnLoginAdmin.PerformClick();
            }
        }
    }
}
