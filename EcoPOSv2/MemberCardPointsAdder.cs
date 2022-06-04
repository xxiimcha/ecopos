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
    public partial class MemberCardPointsAdder : Form
    {
        public MemberCardPointsAdder()
        {
            InitializeComponent();
        }

        private SQLControl SQL = new SQLControl();

        public String memberName;
        public String memberCard;
        public String currentPoints;

        private void MemberCardPointsAdder_Load(object sender, EventArgs e)
        {
            lblMember.Text = memberName + " (" + memberCard + ")";
            lblCurrentPoints.Text = currentPoints;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPoints.Text == "" || txtPoints.Text == null)
            {

                return;
            }

            //Updates the card's balance
            SQL.AddParam("@points", Decimal.Parse(txtPoints.Text));
            SQL.AddParam("@card_no", memberCard);
            SQL.Query("UPDATE member_card SET card_balance = card_balance + @points WHERE card_no = @card_no");
            if (SQL.HasException(true))
            {
                return;
            }

            //Add to topup transaction
            SQL.AddParam("@points", Decimal.Parse(txtPoints.Text));
            SQL.AddParam("@card_no", memberCard);
            SQL.AddParam("@currentPoints", Decimal.Parse(currentPoints));
            SQL.AddParam("@date_time", DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss")));
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.Query("INSERT INTO topup_transaction(topup_cardNo, topup_cusID, topup_amount, topup_beggining_amount, topup_ending_amount, topup_datetime, terminal_id) " +
                "VALUES(@card_no, (SELECT customerID FROM member_card WHERE card_no = @card_no), @points, @currentPoints, (@currentPoints + @points), @date_time, @terminal_id)");
            if (SQL.HasException(true))
            {
                return;
            }
            else
            {
                new Notification().PopUp("Points Added ", "", "success");
                Close();
            }
        }

        private void txtPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow number input
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as Guna.UI2.WinForms.Guna2TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPoints_KeyUp(object sender, KeyEventArgs e)
        {
            string[] wholenumber = txtPoints.Text.Split('.');
            if (wholenumber[0].Length < 10)
            {
                decimal points = txtPoints.Text != "" && txtPoints.Text != "." ? Convert.ToDecimal(txtPoints.Text) : 0;
                lblPointsAfter.Text = (Decimal.Parse(currentPoints) + points).ToString("N2");
                lblPointsAfter.ForeColor = Color.Black;
            }
            else
            {
                lblPointsAfter.Text = "Quantity is too high";
                lblPointsAfter.ForeColor = Color.Red;
            }
        }
    }
}
