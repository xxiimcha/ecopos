using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoPOSControl;

namespace EcoPOSv2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static Login _Login;
        public static Login Instance
        {
            get
            {
                if (_Login == null)
                {
                    _Login = new Login();
                }
                return _Login;
            }
        }
        //DECLARING VARIABLES
        SQLControl sql = new SQLControl();

        bool store_is_closed = false;

        public string current_userID = "0";
        public string current_user_name = "";

        private Helper HP = new Helper();
        //DECLARING VARIABLES

        //METHODS
        void CheckStoreSessionEnded()
        {
            sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id.ToString());
            int check = Convert.ToInt32(sql.ReturnResult("SELECT IIF((SELECT DATEDIFF(day, close_date_time_temp, (SELECT GETDATE())) FROM store_start WHERE terminal_id = @terminal_id AND store_status = 'Close' AND zreading_ref = (SELECT MAX(zreading_ref) FROM store_start where terminal_id=@terminal_id)) = 0, 1, 0)"));

            if (check == 1)
            {
                lblStoreIsClosed.Visible = true;
                btnLogin.Enabled = false;
                tbUsername.Enabled = false;
                tbPassword.Enabled = false;
                store_is_closed = true;
            }
        }

        void CheckUnfinishedSession()
        {
            sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            int check = Convert.ToInt32(sql.ReturnResult("SELECT COUNT(*) FROM shift WHERE terminal_id = @terminal_id AND EnDeD IS NULL AND shiftID = (SELECT MAX(shiftID) FROM shift WHERE terminal_id = @terminal_id)"));

            if (sql.HasException(true))
            {
                MessageBox.Show("Error in check"); 
                return;
            }


            if (check == 1)
            {
                ContinueSession cs = new ContinueSession();
                cs.Show();

                close = true;

                this.Close();
            }
        }
        private void ShiftStart(string userID, string user_name)
        {
            StartingCash frmStartCash = new StartingCash();
            frmStartCash.open_by_userID = userID;
            frmStartCash.open_by_user_name = user_name;
            //frmStartCash.ActiveControl = frmStartCash.tbCash;
            frmStartCash.ShowDialog();
        }

        public void LoadPermissions(int roleID)
        {
            sql.AddParam("@roleID", roleID);

            sql.Query("SELECT * FROM role_permission WHERE roleID = @roleID");

            if (sql.HasException(true))return;

            foreach (DataRow dr in sql.DBDT.Rows)
            {
                Main.Instance.rp_ord_payment = Convert.ToBoolean(dr["ord_payment"].ToString());
                Main.Instance.rp_ord_customer = Convert.ToBoolean(dr["ord_customer"].ToString());
                Main.Instance.rp_ord_discount = Convert.ToBoolean(dr["ord_discount"].ToString());
                Main.Instance.rp_ord_void_item = Convert.ToBoolean(dr["ord_void_item"].ToString());
                Main.Instance.rp_ord_void_transaction = Convert.ToBoolean(dr["ord_void_transaction"].ToString());
                Main.Instance.rp_ord_cancel_transaction = Convert.ToBoolean(dr["ord_cancel_transaction"].ToString());
                Main.Instance.rp_ord_refund_transaction = Convert.ToBoolean(dr["ord_refund_transaction"].ToString());
                Main.Instance.rp_ord_keep_transaction = Convert.ToBoolean(dr["ord_keep_transaction"].ToString());
                Main.Instance.rp_ord_return_exchange = Convert.ToBoolean(dr["ord_return_exchange"].ToString());
                Main.Instance.rp_ord_redeem_item = Convert.ToBoolean(dr["ord_redeem_item"].ToString());
                Main.Instance.rp_home_switch_cashier = Convert.ToBoolean(dr["home_switch_cashier"].ToString());
                Main.Instance.rp_home_more = Convert.ToBoolean(dr["home_more"].ToString());
                Main.Instance.rp_more_ejournal = Convert.ToBoolean(dr["more_ejournal"].ToString());
                Main.Instance.rp_more_customer_membership = Convert.ToBoolean(dr["more_customer_membership"].ToString());
                Main.Instance.rp_more_pay_in_out = Convert.ToBoolean(dr["more_pay_in_out"].ToString());
                Main.Instance.rp_more_logs = Convert.ToBoolean(dr["more_logs"].ToString());
                Main.Instance.rp_more_redeem_settings = Convert.ToBoolean(dr["more_redeem_settings"].ToString());
                Main.Instance.rp_more_manage_discounts = Convert.ToBoolean(dr["more_manage_discounts"].ToString());
                Main.Instance.rp_more_manage_products = Convert.ToBoolean(dr["more_manage_products"].ToString());
                Main.Instance.rp_more_inventory = Convert.ToBoolean(dr["more_inventory"].ToString());
                Main.Instance.rp_more_close_store = Convert.ToBoolean(dr["more_close_store"].ToString());
                Main.Instance.rp_more_database = Convert.ToBoolean(dr["more_database"].ToString());
                Main.Instance.rp_more_settings = Convert.ToBoolean(dr["more_settings"].ToString());
                Main.Instance.rp_pay_payment_method = Convert.ToBoolean(dr["pay_payment_method"].ToString());
                Main.Instance.rp_pay_gift_certificate = Convert.ToBoolean(dr["pay_gift_certificate"].ToString());
            }
        }
        public int roleID = 0;
        void login()
        {
            if(tbUsername.Text == "" || tbPassword.Text == "")
            {
                new Notification().PopUp("Incomplete field(s)", "Error", "error");
            }
            else
            {
                string attempt_status = "";

                sql.AddParam("@user_name", tbUsername.Text);
                string checkuser = sql.ReturnResult("SELECT COUNT(*) as result FROM users WHERE user_name = @user_name");

                if (sql.HasException(true)) return;

                if (checkuser == "0")
                {
                    sql.AddParam("@user_name", tbUsername.Text);
                    sql.AddParam("@password", HP.Encrypt(tbPassword.Text));

                    sql.Query("SELECT * FROM admin_accts WHERE user_name = @user_name AND password = @password");

                    if (sql.HasException(true)) return;

                    if(sql.DBDT.Rows.Count > 0)
                    {
                        attempt_status = "Log In Success";

                        foreach (DataRow dr in sql.DBDT.Rows)
                        {
                            current_userID = dr["adminID"].ToString();
                            current_user_name = dr["user_name"].ToString();
                            Main.Instance.current_id = dr["adminID"].ToString();
                            Main.Instance.current_username = dr["user_name"].ToString();
                            Main.Instance.current_user_first_name = dr["first_name"].ToString();
                            Main.Instance.lblUser.Text = dr["first_name"] + " " + dr["last_name"];
                        }
                        //record Login

                        sql.AddParam("@userID", current_userID);
                        sql.AddParam("@user_name", tbUsername.Text);
                        sql.AddParam("@attempt_status", attempt_status);
                        sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                        sql.Query("INSERT INTO user_logs (userID, user_name, attempt_status, date_time,terminal_id) VALUES (@userID, @user_name, @attempt_status, (SELECT GETDATE()),@terminal_id)");

                        if (sql.HasException(true)) return;

                        //show main form

                        ShiftStart(current_userID, current_user_name);

                        //new Notification().PopUp("Admin login Success!", "Success!", "success");
                        close = true;

                        Main.Instance.Show();
                        this.Close();
                    }
                    else
                    {
                        attempt_status = "Log In Failed";

                        sql.AddParam("@user_name", tbUsername.Text);
                        sql.Query("SELECT * FROM admin_accts WHERE user_name = @user_name");

                        if (sql.HasException(true)) return;

                        foreach (DataRow dr in sql.DBDT.Rows)
                        {
                            current_userID = dr["adminID"].ToString();
                        }
                        //record Login

                        sql.AddParam("@userID", current_userID);
                        sql.AddParam("@user_name", tbUsername.Text);
                        sql.AddParam("@attempt_status", attempt_status);
                        sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                        sql.Query("INSERT INTO user_logs (userID, user_name, attempt_status, date_time,terminal_id) VALUES (@userID, @user_name, @attempt_status, (SELECT GETDATE()),@terminal_id)");

                        if (sql.HasException(true)) return;

                        //LOGIN ERROR MESSAGE & CLEARING
                        new Notification().PopUp("Login failed! Please try again.", "Login Error", "error");

                        tbUsername.Clear();
                        tbPassword.Clear();
                        tbUsername.Focus();
                    }
                }
                else if(checkuser == "1")
                {
                    int roleID = 0;

                    sql.AddParam("@user_name", tbUsername.Text);
                    sql.AddParam("@password", HP.Encrypt(tbPassword.Text));

                    sql.Query("SELECT * FROM users WHERE user_name = @user_name AND password = @password");
                    if (sql.HasException(true))return;

                    if(sql.DBDT.Rows.Count > 0)
                    {
                        attempt_status = "Log In Success";

                        foreach (DataRow dr in sql.DBDT.Rows)
                        {
                            current_userID = dr["userID"].ToString();
                            current_user_name = dr["user_name"].ToString();
                            roleID = Convert.ToInt32(dr["roleID"].ToString());
                            Main.Instance.current_id = dr["userID"].ToString();
                            Main.Instance.current_username = dr["user_name"].ToString();
                            Main.Instance.current_user_first_name = dr["first_name"].ToString();
                            Main.Instance.lblUser.Text = dr["first_name"] + " " + dr["last_name"].ToString();
                        }

                        LoadPermissions(roleID);

                        Main.Instance.roleid = roleID.ToString();

                        //record Login

                        sql.AddParam("@userID", current_userID);
                        sql.AddParam("@user_name", tbUsername.Text);
                        sql.AddParam("@attempt_status", attempt_status);
                        sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                        sql.Query("INSERT INTO user_logs (userID, user_name, attempt_status, date_time,terminal_id) VALUES (@userID, @user_name, @attempt_status, (SELECT GETDATE()),@terminal_id)");

                        if (sql.HasException(true)) return;

                        ShiftStart(current_userID, current_user_name);

                        //new Notification().PopUp("User login Success!", "Success!", "success");
                        close = true;

                        Main.Instance.Show();
                        this.Close();
                    }
                    else
                    {
                        attempt_status = "Log In Failed";

                        sql.AddParam("@user_name", tbUsername.Text);
                        sql.Query("SELECT * FROM users WHERE user_name = @user_name");

                        if (sql.HasException(true)) return;

                        foreach (DataRow dr in sql.DBDT.Rows)
                        {
                            current_userID = dr["userID"].ToString();
                        }
                        //record Login

                        sql.AddParam("@userID", current_userID);
                        sql.AddParam("@user_name", tbUsername.Text);
                        sql.AddParam("@attempt_status", attempt_status);
                        sql.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);

                        sql.Query("INSERT INTO user_logs (userID, user_name, attempt_status, date_time,terminal_id) VALUES (@userID, @user_name, @attempt_status, (SELECT GETDATE()),@terminal_id)");

                        if (sql.HasException(true)) return;

                        //LOGIN ERROR MESSAGE & CLEARING
                        new Notification().PopUp("Login failed! Please try again.", "Login Error", "error");

                        tbUsername.Clear();
                        tbPassword.Clear();
                        tbUsername.Focus();
                    }
                }
                else
                {
                    new Notification().PopUp("This user is not exist in our database. Please try again.", "Error", "error");
                    //MessageBox.Show("This user is not exist in our database. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbUsername.Clear();
                    tbPassword.Clear();
                    tbUsername.Focus();
                }
            }
        }
        //METHODS

        private void Login_Load(object sender, EventArgs e)
        {
            _Login = this;

            //SERVER TYPE OR NOT
            if (Properties.Settings.Default.servertype == true)
            {
                lblTerminal.Visible = true;
            }
            else
            {
                lblTerminal.Visible = false;
            }


            lblTerminal.Text = "Terminal " + Properties.Settings.Default.Terminal_id; 

            //CheckStoreSessionEnded();

            if (store_is_closed == false)
            {
                CheckUnfinishedSession();
            }


            if (Properties.Settings.Default.cardlogin == false)
            {
                lbLoginCard.Visible = false;
            }
            else
            {
                lbLoginCard.Visible = true;
            }

            ////DISABLE KAPAG HINDI TRIAL VERSION
            //if (Properties.Settings.Default.Trial == "Active")
            //{
            //    var span = DateTime.Parse(Properties.Settings.Default.TrialExpiryDate).Subtract(DateTime.Now);

            //    lblVersion.Text = "Trial version " + span.Days + " days remaining";

            //    if (span.Days < 0)
            //    {
            //        Properties.Settings.Default.Trial = "";
            //        Properties.Settings.Default.Save();

            //        close = true;
            //        Application.Exit();
            //    }
            //}
        }
        private void tClock_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("MMM d, yyyy - hh:mm:ss tt");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    sql.AddParam("@username", tbUsername.Text);
                    if (int.Parse(sql.ReturnResult("select COUNT(*) from Shift where user_name=@username AND ended IS NULL")) >= 1)
                    {
                        MessageBox.Show("User is already online", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string connection = sql.CheckConnection();

                    if (sql.HasException(true)) return;

                    if (connection == "success")
                    {
                        int check_records = Convert.ToInt32(sql.ReturnResult("SELECT COUNT(*) FROM store_details"));

                        if (sql.HasException(true)) return;

                        if (check_records == 1)
                        {
                            login();
                        }
                        else
                        {
                            new Notification().PopUp("No store details found.", "Error", "error");
                            //MessageBox.Show("No store details found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }));
            }).Start();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                Prompt.Instance.Pop(1);
                Prompt.Instance.ShowDialog();
            }
        }
        public bool close = false;
        private void btnClose_Click(object sender, EventArgs e)
        {
            close = true;
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(close == false)
            {
                e.Cancel = true;
            }
        }

        private void lbLoginCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CardLogin cl = new CardLogin();

            cl.type = "1";
            cl.ShowDialog();
        }
    }
}
