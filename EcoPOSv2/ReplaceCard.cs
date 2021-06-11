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
    public partial class ReplaceCard : Form
    {
        public ReplaceCard()
        {
            InitializeComponent();
        }

        private SQLControl SQL = new SQLControl();
        public string old_card;

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string new_card = txtCardNo.Text;

            SQL.AddParam("@new_card", new_card);
            int result = Convert.ToInt32(SQL.ReturnResult(@"SELECT IIF((SELECT COUNT(*) FROM member_card WHERE card_no = @new_card 
                                        AND status = 'Available') > 0, 1, 0) as result"));

            if (SQL.HasException(true))
                return;

            if (result == 1)
            {

                // transfer to new card
                SQL.AddParam("@new_card", new_card);
                SQL.AddParam("@old_card", old_card);

                SQL.Query(@"UPDATE member_card SET
                           customer_name = old_card.customer_name,
                           member_type_ID = old_card.member_type_ID,
                           customerID = old_card.customerID,
                           card_balance = old_card.card_balance,
                           status = old_card.status
                           FROM (SELECT customer_name, member_type_ID, 
                           customerID, card_balance, status FROM member_card 
                           WHERE card_no = @old_card) old_card
                           WHERE card_no = @new_card");

                if (SQL.HasException(true))
                    return;

                // update old card as inactive

                SQL.AddParam("@old_card", old_card);

                SQL.Query(@"UPDATE member_card SET
                           card_balance = 0,
                           customer_name = '', member_type_ID = 0, customerID = 0,
                           status = 'Inactive, Transferred to card # " + new_card + @"' 
                           WHERE card_no = @old_card");

                if (SQL.HasException(true))
                    return;
                Customers.Instance.LoadCustomer();
                Customers.Instance.LoadCard();

                new Notification().PopUp("Transfer success", "", "information");

                Close();
            }
            else
                new Notification().PopUp("Transfer failed", "Card does not exist","error");
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConfirm.PerformClick();
        }
    }
}
