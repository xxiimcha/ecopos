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
            guna2ShadowForm1.SetShadowForm(this);
            AssignValidation(ref tbCash, ValidationType.Price);
            AssignValidation(ref tbCash, ValidationType.Int_Only);
        }

        private void tbCash_TextChanged(object sender, EventArgs e)
        {
            tbCash.Text = tbCash.Text.Replace(" ", "");
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(tbCash.Text != "") 
            {
                // generate zreading

                string result = sql.ReturnResult(@"SELECT IIF((SELECT COUNT(*) FROM store_start WHERE store_status = 'Open' AND zreading_ref = (SELECT MAX(zreading_ref) FROM store_start)) = 0, 'Close', 
                                                (SELECT store_status FROM store_start WHERE zreading_ref = (SELECT MAX(zreading_ref) FROM store_start)))");

                if (sql.HasException(true))
                    return;

                if (result != "Open")
                {
                    sql.AddParam("@open_by_userID", open_by_userID);

                    sql.Query(@"INSERT INTO store_start (open_by_userID, store_status)
                       VALUES (@open_by_userID, 'Open')");

                    if (sql.HasException(true))
                        return;

                    string zreading_ref = sql.ReturnResult("SELECT zreading_ref FROM store_start WHERE zreading_ref = (SELECT MAX(zreading_ref) FROM store_start)");

                    if (sql.HasException(true))
                        return;

                    // generate z reading no
                    sql.AddParam("@zreading_ref", zreading_ref);
                    sql.Query("INSERT INTO zreading (zreading_ref) VALUES (@zreading_ref)");

                    if (sql.HasException(true))
                        return;

                    // start order no
                    sql.Query("INSERT INTO order_no (order_no) VALUES (1)");

                    if (sql.HasException(true))
                        return;
                }


                sql.AddParam("@userID", open_by_userID);
                sql.AddParam("@user_name", open_by_user_name);
                sql.AddParam("@starting_cash", tbCash.Text);

                sql.Query("INSERT INTO shift (userID, user_name, starting_cash) VALUES (@userID, @user_name, @starting_cash)");

                if (sql.HasException(true)) return;

                // restart order form
                Main.Instance.pnlChild.Controls.Clear();

                Order frmOrder = new Order();
                Main.Instance.OpenChildForm(frmOrder);
                frmOrder.tbBarcode.Focus();

                Close();
            }
            else
            {
                new Notification().PopUp("Please complete all the field(s)", "Error", "error");
            }
        }
    }
}
