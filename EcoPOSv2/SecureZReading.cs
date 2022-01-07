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
    public partial class SecureZReading : Form
    {

        private SQLControl SQL = new SQLControl();
        private Helper HP = new Helper();

        public SecureZReading()
        {
            InitializeComponent();
        }

        private void BtnProceed_Click(object sender, EventArgs e)
        {
            var encrypt_password = HP.Encrypt(txtPassword.Text);
            SQL.AddParam("@current_userID", Main.Instance.current_id);
            SQL.AddParam("@password", encrypt_password);
            SQL.AddParam("@card_no", txtPassword.Text);
            int check_password = Convert.ToInt32(SQL.ReturnResult(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                                                                          SELECT * INTO #Temp_users
                                                                          FROM
                                                                          (
                                                                          SELECT ID, password,card_no FROM
                                                                          (
                                                                          SELECT adminID as 'ID', password as 'password',card_no FROM admin_accts
                                                                          UNION ALL
                                                                          SELECT userID, password,card_no FROM users
                                                                          ) x
                                                                          ) as a;
                                                                          SELECT COUNT(*) FROM #Temp_users 
                                                                          WHERE ID = @current_userID AND password = @password OR card_no=@card_no"));
            if (SQL.HasException(true))
                return;
            if (check_password == 1)
            {
                this.Close();
                var frmZReading = new ZReading();
                frmZReading.Show();
            }
            else
            {
                new Notification().PopUp("Incorrect password", "","error");
                txtPassword.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SecureZReading_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
            this.ActiveControl = txtPassword;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnProceed.PerformClick();
            }
        }
    }
}
