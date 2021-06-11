using EcoPOSControl;
using FontAwesome.Sharp;
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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        private FormLoad OL = new FormLoad();
        private SQLControl SQL = new SQLControl();

        Panel currentPanel;
        Button currentBtn;

        private TransactionsReport report = new TransactionsReport();
        private PaymentReceipt reprint_receipt = new PaymentReceipt();


        private bool dgvMT_ClickedOnce = false;

        Boolean clickbtnCustomer, clickMembership, clickMemberTransactions, clickMC = false;

        //METHODS
        private void ClearFields_Mem()
        {
            txtMem_AmtPerPoint.Clear();
            txtMem_DiscAmount.Clear();
            txtMem_Expiration.Clear();
            txtMem_ID.Clear();
            txtMem_Name.Clear();
            txtMem_Search.Clear();
            txtMC_Membership.Clear();

            rbMem_DiscNo.Checked = false;
            rbMem_DiscYes.Checked = false;
            rbMem_RewardableNo.Checked = false;
            rbMem_RewardableYes.Checked = false;
            rbMem_TypeAmount.Checked = false;
            rbMem_TypePercentage.Checked = false;
        }

        public void LoadCard()
        {
            SQL.Query("SELECT cardID, card_no FROM member_card ORDER BY card_no ASC");
            if (SQL.HasException(true))
                return;

            dgvCard.DataSource = SQL.DBDT;
            dgvCard.Columns[0].Visible = false;
        }

        private void LoadMembership()
        {
            SQL.Query("SELECT member_type_ID, name FROM membership ORDER BY name ASC");
            if (SQL.HasException(true))
                return;

            dgvMembership.DataSource = SQL.DBDT;
            dgvMembership.Columns[0].Visible = false;
        }

        void SelectedButtonContainer(Button getButtonCustomer, Button getButtonMembership, Button getButtonMemberTransactions, Button getButtonMC)
        {
            Color col = ColorTranslator.FromHtml("#EB545C");
            if (clickbtnCustomer)
            {
                //back to normal color
                getButtonMembership.BackColor = Color.White;
                getButtonMembership.ForeColor = Color.Black;
                getButtonMemberTransactions.BackColor = Color.White;
                getButtonMemberTransactions.ForeColor = Color.Black;
                getButtonMC.BackColor = Color.White;
                getButtonMC.ForeColor = Color.Black;
                //change color of selected button
                getButtonCustomer.BackColor = col;
                getButtonCustomer.ForeColor = Color.White;
                clickbtnCustomer = false;
            }
            if (clickMembership)
            {
                //back to normal color
                getButtonCustomer.BackColor = Color.White;
                getButtonCustomer.ForeColor = Color.Black;
                getButtonMemberTransactions.BackColor = Color.White;
                getButtonMemberTransactions.ForeColor = Color.Black;
                getButtonMC.BackColor = Color.White;
                getButtonMC.ForeColor = Color.Black;
                //change color of selected button
                getButtonMembership.BackColor = col;
                getButtonMembership.ForeColor = Color.White;

                clickMembership = false;
            }
            if (clickMemberTransactions)
            {
                //back to normal color
                getButtonCustomer.BackColor = Color.White;
                getButtonCustomer.ForeColor = Color.Black;
                getButtonMembership.BackColor = Color.White;
                getButtonMembership.ForeColor = Color.Black;
                getButtonMC.BackColor = Color.White;
                getButtonMC.ForeColor = Color.Black;
                //change color of selected button
                getButtonMemberTransactions.BackColor = col;
                getButtonMemberTransactions.ForeColor = Color.White;
                clickMemberTransactions = false;
            }
            if (clickMC)
            {
                //back to normal color
                getButtonCustomer.BackColor = Color.White;
                getButtonCustomer.ForeColor = Color.Black;
                getButtonMembership.BackColor = Color.White;
                getButtonMembership.ForeColor = Color.Black;
                getButtonMemberTransactions.BackColor = Color.White;
                getButtonMemberTransactions.ForeColor = Color.Black;
                //change color of selected button
                getButtonMC.BackColor = col;
                getButtonMC.ForeColor = Color.White;
                clickMC = false;
            }
        }

        public void LoadCustomer()
        {
            SQL.Query("SELECT customerID, name FROM customer ORDER BY name ASC");
            if (SQL.HasException(true))
                return;

            dgvCustomer.DataSource = SQL.DBDT;
            dgvCustomer.Columns[0].Visible = false;
        }

        public void ClearFields_Cus()
        {
            txtCus_Add1.Clear();
            txtCus_Add2.Clear();
            txtCus_CardNo.Clear();
            txtCus_Contact.Clear();
            txtCus_Email.Clear();
            txtCus_ID.Clear();
            txtCus_Name.Clear();
            txtCus_Search.Clear();
        }

        //METHODS
        private void Customers_Load(object sender, EventArgs e)
        {
            pnlCustomer.BringToFront();
            clickbtnCustomer = true;
            SelectedButtonContainer(btnCustomer, btnMembership, btnMemberTransactions,btnMC);

            LoadCustomer();
            LoadMembership();
            LoadCard();

            OL.ComboValues(cmbCus_Membership, "member_type_ID", "name", "membership");

            // member transaction
            LoadMT_Customers();
            dtpMT_From.Value = DateTime.Now;
            dtpMT_From.Value = DateTime.Now;
            cmbMT_Customer.SelectedIndex = 0;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnlCustomer.BringToFront();
            clickbtnCustomer = true;
            SelectedButtonContainer(btnCustomer, btnMembership, btnMemberTransactions, btnMC);
        }

        private void txtCus_ID_TextChanged(object sender, EventArgs e)
        {
            if (txtCus_ID.Text != "")
                txtCus_CardNo.Enabled = false;
            else
                txtCus_CardNo.Enabled = true;
        }

        private void btnCus_New_Click(object sender, EventArgs e)
        {
            ClearFields_Cus();
        }

        private void btnCus_Save_Click(object sender, EventArgs e)
        {

            if (txtCus_Name.Text != "" || txtCus_Contact.Text != "" || txtCus_Add1.Text != "" || txtCus_Email.Text != "" || txtCus_CardNo.Text != "")
            {
                string action = "Update";
                if (txtCus_ID.Text == "")
                    action = "New";


                // check if card exists
                if (txtCus_CardNo.Text != "")
                {
                    SQL.AddParam("@card_no", txtCus_CardNo.Text);
                    int searchCard = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM member_card WHERE card_no = @card_no AND status = 'Available') > 0,'1', '0') as result"));

                    if (SQL.HasException(true))
                        return;

                    if (searchCard == 0 & action == "New")
                    {
                        new Notification().PopUp("Card does not exist or is already taken", "Save failed", "error");
                        return;
                    }
                    else
                    {
                        switch (action)
                        {
                            case "New":
                                {
                                    SQL.AddParam("@name", txtCus_Name.Text);
                                    SQL.AddParam("@contact", txtCus_Contact.Text);
                                    SQL.AddParam("@birthday", dtpCus_Bday.Value);
                                    SQL.AddParam("@add1", txtCus_Add1.Text);
                                    SQL.AddParam("@add2", txtCus_Add2.Text);
                                    SQL.AddParam("@email", txtCus_Email.Text);
                                    SQL.AddParam("@member_type_ID", cmbCus_Membership.SelectedValue);
                                    SQL.AddParam("@card_no", txtCus_CardNo.Text);

                                    SQL.Query(@"INSERT INTO customer (name, contact, birthday, add1, add2, email, member_type_ID, card_no)
                                       VALUES (@name, @contact, @birthday, @add1, @add2, @email, @member_type_ID, @card_no)");

                                    if (SQL.HasException(true))
                                        return;

                                    // update card status

                                    SQL.AddParam("@card_no", txtCus_CardNo.Text);
                                    int card_expiration_days = Convert.ToInt32(SQL.ReturnResult(@"SELECT m.expiration FROM membership as m INNER JOIN customer as c
                                                                                                    ON m.member_type_ID = c.member_type_ID WHERE c.card_no = @card_no"));
                                    if (SQL.HasException(true))
                                        return;

                                    SQL.AddParam("@card_no", txtCus_CardNo.Text);
                                    SQL.AddParam("@member_type_ID", cmbCus_Membership.SelectedValue);
                                    SQL.AddParam("@customer_name", txtCus_Name.Text);
                                    SQL.AddParam("@activation_span", card_expiration_days);

                                    SQL.Query(@"UPDATE member_card SET member_type_ID = @member_type_ID, 
                                           customerID = (SELECT MAX(customerID) FROM customer), customer_name = @customer_name, status = 'Active',
                                           date_activated = (SELECT GETDATE()), activation_span = @activation_span WHERE card_no = @card_no");

                                    if (SQL.HasException(true))
                                        return;

                                    ClearFields_Cus();
                                    new Notification().PopUp("Data saved.","Saved","information");
                                    break;
                                }

                            default:
                                {
                                    SQL.AddParam("@customerID", txtCus_ID.Text);
                                    SQL.AddParam("@name", txtCus_Name.Text);
                                    SQL.AddParam("@contact", txtCus_Contact.Text);
                                    SQL.AddParam("@birthday", dtpCus_Bday.Value);
                                    SQL.AddParam("@add1", txtCus_Add1.Text);
                                    SQL.AddParam("@add2", txtCus_Add2.Text);
                                    SQL.AddParam("@email", txtCus_Email.Text);
                                    SQL.AddParam("@member_type_ID", cmbCus_Membership.SelectedValue);
                                    SQL.AddParam("@card_no", txtCus_CardNo.Text);

                                    SQL.Query(@"UPDATE customer SET name = @name, contact = @contact, birthday = @birthday, add1 = @add1, 
                                       add2 = @add2, email = @email, member_type_ID = @member_type_ID, card_no = @card_no
                                       WHERE customerID = @customerID");

                                    if (SQL.HasException(true))
                                        return;

                                    new Notification().PopUp("Data saved.","","information");
                                    break;
                                }
                        }
                        LoadCustomer();
                        LoadCard();
                    }
                }
            }
            else
            {
                new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
            }
                
        }

        private void btnCus_Delete_Click(object sender, EventArgs e)
        {
            DialogResult approval = MessageBox.Show("Delete this customer?", "", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (approval == DialogResult.Yes)
            {
                if (txtCus_ID.Text == "")
                {
                    new Notification().PopUp("No customer selected.", "", "error");
                    return;
                }

                SQL.AddParam("@customerID", txtCus_ID.Text);
                SQL.Query("DELETE FROM customer WHERE customerID = @customerID");

                if (SQL.HasException(true))
                    return;

                SQL.AddParam("@customerID", txtCus_ID.Text);
                SQL.Query("UPDATE member_card SET status = 'Owner removed' WHERE customerID = @customerID");

                if (SQL.HasException(true))
                    return;

                LoadCustomer();

                ClearFields_Cus();

                new Notification().PopUp("Item deleted.", "", "information");
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@customerID", dgvCustomer.CurrentRow.Cells[0].Value.ToString());

            SQL.Query("SELECT * FROM customer WHERE customerID = @customerID");
            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                txtCus_ID.Text = r["customerID"].ToString();
                txtCus_Name.Text = r["name"].ToString();
                txtCus_Contact.Text = r["contact"].ToString();
                dtpCus_Bday.Value = DateTime.Parse(r["birthday"].ToString());
                txtCus_Add1.Text = r["add1"].ToString();
                txtCus_Add2.Text = r["add2"].ToString();
                txtCus_Email.Text = r["email"].ToString();
                cmbCus_Membership.SelectedValue = r["member_type_ID"].ToString();
                txtCus_CardNo.Text = r["card_no"].ToString();
            }
        }

        private void txtCus_Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCus_Search.Text == "")
                LoadCustomer();
            else
            {
                SQL.AddParam("@find", txtCus_Search.Text + "%");

                SQL.Query("SELECT customerID, name FROM customer WHERE name LIKE @find ORDER BY name ASC");
                if (SQL.HasException(true))
                    return;

                dgvCustomer.DataSource = SQL.DBDT;
                dgvCustomer.Columns[0].Visible = false;
            }
        }

        private void btnCus_Sort_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.RowCount == 0)
                return;

            if (btnCus_Sort.IconChar == IconChar.SortAlphaDown)
            {
                dgvCustomer.Sort(dgvCustomer.Columns[1], ListSortDirection.Ascending);
                btnCus_Sort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvCustomer.Sort(dgvCustomer.Columns[1], ListSortDirection.Descending);
                btnCus_Sort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void dgvMembership_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                SQL.AddParam("@member_type_ID", dgvMembership.CurrentRow.Cells[0].Value.ToString());
                SQL.Query("SELECT * FROM membership WHERE member_type_ID = @member_type_ID");

                if (SQL.HasException(true)) return;

                foreach (DataRow dr in SQL.DBDT.Rows)
                {
                    txtMem_ID.Text = dr["member_type_ID"].ToString();
                    txtMem_Name.Text = dr["name"].ToString();
                    txtMem_DiscAmount.Text = dr["disc_amt"].ToString();
                    txtMem_Expiration.Text = dr["expiration"].ToString();
                    txtMem_AmtPerPoint.Text = dr["amt_per_pt"].ToString();

                    if (Convert.ToBoolean(dr["discountable"].ToString()))
                    {
                        rbMem_DiscYes.Checked = true;
                    }
                    else
                    {
                        rbMem_DiscYes.Checked = false;
                    }

                    if (Convert.ToInt32(dr["disc_type"].ToString()) == 1)
                    {
                        rbMem_TypeAmount.Checked = true;
                    }
                    else
                    {
                        rbMem_TypePercentage.Checked = false;
                    }


                    if (Convert.ToBoolean(dr["rewardable"].ToString()))
                    {
                        rbMem_RewardableYes.Checked = true;
                    }
                    else
                    {
                        rbMem_RewardableYes.Checked = false;
                    }
                }
            }
        }

        private void btnMem_Save_Click(object sender, EventArgs e)
        {
            if (txtMem_Name.Text != "" || txtMem_DiscAmount.Text != "" || txtMem_Expiration.Text == "" || txtMem_AmtPerPoint.Text == "")
            {
                string action = "Update";
                bool discountable = false;
                int disc_type = 2;
                bool rewardable = false;

                if (txtMem_ID.Text == "")
                    action = "New";



                if (rbMem_DiscYes.Checked)
                    discountable = true;

                if (rbMem_TypeAmount.Checked)
                    disc_type = 1;

                if (rbMem_RewardableYes.Checked)
                    rewardable = true;



                switch (action)
                {
                    case "New":
                        {
                            // check for duplicate names
                            SQL.AddParam("@name", txtMem_Name.Text);
                            int result = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM membership WHERE name = @name) > 0,'1', '0') as result"));

                            if (SQL.HasException(true))
                                return;

                            if (result == 0)
                            {
                                SQL.AddParam("@name", txtMem_Name.Text);
                                SQL.AddParam("@discountable", discountable);
                                SQL.AddParam("@disc_amt", txtMem_DiscAmount.Text);
                                SQL.AddParam("@disc_type", disc_type);
                                SQL.AddParam("@expiration", txtMem_Expiration.Text);
                                SQL.AddParam("@rewardable", rewardable);
                                SQL.AddParam("@amt_per_pt", txtMem_AmtPerPoint.Text);

                                SQL.Query(@"INSERT INTO membership (name, discountable, disc_amt, disc_type, 
                                        expiration, rewardable, amt_per_pt) VALUES (@name, @discountable, 
                                        @disc_amt, @disc_type, @expiration, @rewardable, @amt_per_pt)");

                                if (SQL.HasException(true))
                                    return;
                                ClearFields_Mem();
                                new Notification().PopUp("Data saved.","","information");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }

                    default:
                        {
                            SQL.AddParam("@member_type_ID", txtMem_ID.Text);
                            SQL.AddParam("@name", txtMem_Name.Text);

                            string result = SQL.ReturnResult(@"SELECT IIF((
                SELECT COUNT(*) as duplicatecount FROM membership WHERE name = @name AND member_type_ID <> @member_type_ID) > 0,
                1, 0) as result");

                            if (SQL.HasException(true))
                                return;


                            if (result == "0")
                            {
                                SQL.AddParam("@member_type_ID", txtMem_ID.Text);
                                SQL.AddParam("@name", txtMem_Name.Text);
                                SQL.AddParam("@discountable", discountable);
                                SQL.AddParam("@disc_amt", txtMem_DiscAmount.Text);
                                SQL.AddParam("@disc_type", disc_type);
                                SQL.AddParam("@expiration", txtMem_Expiration.Text);
                                SQL.AddParam("@rewardable", rewardable);
                                SQL.AddParam("@amt_per_pt", txtMem_AmtPerPoint.Text);

                                SQL.Query(@"UPDATE membership SET name = @name, discountable = @discountable, 
                                        disc_amt = @disc_amt, disc_type = @disc_type, expiration = @expiration, 
                                        rewardable = @rewardable, amt_per_pt = @amt_per_pt WHERE member_type_ID = @member_type_ID");

                                if (SQL.HasException(true))
                                    return;

                                new Notification().PopUp("Data saved.", "", "information");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }
                }
                LoadMembership();
                OL.ComboValues(cmbCus_Membership, "member_type_ID", "name", "membership");
            }
            else
                new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
        }

        private void rbMem_DiscYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMem_DiscYes.Checked)
            {
                txtMem_DiscAmount.Enabled = true;
                rbMem_TypeAmount.Enabled = true;
                rbMem_TypePercentage.Enabled = true;
            }
            else
            {
                txtMem_DiscAmount.Text = "0.00";
                txtMem_DiscAmount.Enabled = false;
                rbMem_TypeAmount.Enabled = false;
                rbMem_TypePercentage.Enabled = false;
            }
        }

        private void rbMem_RewardableYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMem_RewardableYes.Checked)
                txtMem_AmtPerPoint.Enabled = true;
            else
            {
                txtMem_AmtPerPoint.Text = "0";
                txtMem_AmtPerPoint.Enabled = false;
            }
        }

        private void txtMem_Search_TextChanged(object sender, EventArgs e)
        {
            if (txtMem_Search.Text == "")
                LoadMembership();
            else
            {
                SQL.AddParam("@find", txtMem_Search.Text + "%");

                SQL.Query("SELECT member_type_ID, name FROM membership WHERE name LIKE @find ORDER BY name ASC");
                if (SQL.HasException(true))
                    return;

                dgvMembership.DataSource = SQL.DBDT;
                dgvMembership.Columns[0].Visible = false;
            }
        }

        private void btnMem_Delete_Click(object sender, EventArgs e)
        {
            DialogResult approval = MessageBox.Show("Delete this member?", "", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (approval == DialogResult.Yes)
            {
                if (txtMem_ID.Text == "")
                {
                    new Notification().PopUp("No item selected.", "", "error");
                    return;
                }

                SQL.AddParam("@member_type_ID", txtMem_ID.Text);
                SQL.Query("DELETE FROM membership WHERE member_type_ID = @member_type_ID");

                if (SQL.HasException(true))
                    return;

                LoadMembership();

                ClearFields_Mem();

                new Notification().PopUp("Item deleted.", "", "information");

                OL.ComboValues(cmbCus_Membership, "member_type_ID", "name", "membership");
            }
        }

        private void btnMem_New_Click(object sender, EventArgs e)
        {
            ClearFields_Mem();
        }

        private void btnMem_Sort_Click(object sender, EventArgs e)
        {
            if (dgvMembership.RowCount == 0)
                return;

            if (btnMem_Sort.IconChar == IconChar.SortAlphaDown)
            {
                dgvMembership.Sort(dgvMembership.Columns[1], ListSortDirection.Ascending);
                btnMem_Sort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvMembership.Sort(dgvMembership.Columns[1], ListSortDirection.Descending);
                btnMem_Sort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void btnMembership_Click(object sender, EventArgs e)
        {
            pnlMembership.BringToFront();
            clickMembership = true;
            SelectedButtonContainer(btnCustomer, btnMembership, btnMemberTransactions, btnMC);
        }

        private void btnMemberTransactions_Click(object sender, EventArgs e)
        {
            pnlMT.BringToFront();
            clickMemberTransactions = true;
            SelectedButtonContainer(btnCustomer, btnMembership, btnMemberTransactions, btnMC);
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            pnlMC.BringToFront();
            clickMC = true;
            SelectedButtonContainer(btnCustomer, btnMembership, btnMemberTransactions, btnMC);
        }
    }
}
