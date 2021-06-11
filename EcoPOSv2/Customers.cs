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
