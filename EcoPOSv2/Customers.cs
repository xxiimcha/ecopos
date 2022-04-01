using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using EcoPOSControl;
using FontAwesome.Sharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EcoPOSv2.ControlBehavior;
using static EcoPOSv2.GroupAction;
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class Customers : Form
    {
        //SELECTED ID
        string card_id = "";
        string membership_id = "";
        

        public Customers()
        {
            InitializeComponent();
        }
        private FormLoad OL = new FormLoad();
        private GroupAction GA = new GroupAction();
        private SQLControl SQL = new SQLControl();
        private ExportImport EI = new ExportImport();

        private Panel currentPanel;
        private Button currentBtn;

        private PaymentR58 report = new PaymentR58();
        private PaymentR58 reprint_receipt = new PaymentR58();

        private TransactionsReport80 report80 = new TransactionsReport80();
        private PaymentReceipt80 reprint_receipt80 = new PaymentReceipt80();

        private bool dgvMT_ClickedOnce = false;

        private List<Control> allTxt = new List<Control>();
        private List<TextBox> requiredFields = new List<TextBox>();

        Boolean clickbtnCustomer, clickMembership, clickMemberTransactions, clickMC = false;

        public static Customers _Customers;
        public static Customers Instance
        {
            get
            {
                if (_Customers == null)
                {
                    _Customers = new Customers();
                }
                return _Customers;
            }
        }
        //METHODS
        private void CardRF()
        {
            requiredFields = new List<TextBox>();
        }

        private void ClearFields_Card()
        {
            card_id = "";
            txtMC_CardNo.Text = "";
            txtMC_Membership.Text = "";
            txtMC_Owner.Text = "";
            txtMC_Balance.Text = "";
            txtMC_Status.Text = "";
        }
        public static bool PrinterExists(string printerName)
        {
            if (String.IsNullOrEmpty(printerName)) { throw new ArgumentNullException("printerName"); }
            return PrinterSettings.InstalledPrinters.Cast<string>().Any(name => printerName.ToUpper().Trim() == name.ToUpper().Trim());
        }

        private void LoadMT_Customers()
        {
            OL.ComboValuesQuery(cmbMT_Customer, @"SELECT customerID, name FROM
                                         (
                                          SELECT 0 as 'customerID', 'All customers' as 'name', 1 as ord
                                          UNION ALL
                                          SELECT customerID, (name + ' (' + card_no + ')'), 2 as ord FROM customer
                                         ) x ORDER BY ord, name ASC", "customerID", "name");
        }

        private void ClearCard_Mem()
        {
            txtMC_Status.Clear();
            txtMC_Search.Clear();
            txtMC_Owner.Clear();
            txtMC_Membership.Clear();
            txtMC_CardNo.Clear();
            txtMC_Balance.Clear();

            LoadCard();
        }
        private void ClearFields_Mem()
        {
            txtMem_AmtPerPoint.Clear();
            txtMem_DiscAmount.Clear();
            txtMem_Expiration.Clear();
            txtMem_Name.Clear();
            txtMem_Search.Clear();
            txtMC_Membership.Clear();
            membership_id = "";

            rbMem_DiscNo.Checked = false;
            rbMem_DiscYes.Checked = false;
            rbMem_RewardableNo.Checked = false;
            rbMem_RewardableYes.Checked = false;
            rbMem_TypeAmount.Checked = false;
            rbMem_TypePercentage.Checked = false;

            LoadMembership();
        }
        public void LoadCard()
        {
            SQL.Query("SELECT cardID, card_no AS 'CARD NUMBER' FROM member_card ORDER BY card_no ASC");
            if (SQL.HasException(true))
                return;

            dgvCard.DataSource = SQL.DBDT;
            dgvCard.Columns[0].Visible = false;
        }

        private void LoadMembership()
        {
            SQL.Query("SELECT member_type_ID, name as 'Memberships' FROM membership ORDER BY name ASC");
            if (SQL.HasException(true))
                return;

            dgvMembership.DataSource = SQL.DBDT;
            dgvMembership.Columns[0].Visible = false;
        }

        void SelectedButtonContainer(Button getButtonCustomer, Button getButtonMembership, Button getButtonMemberTransactions, Button getButtonMC)
        {
            Color col = ColorTranslator.FromHtml("#383838");
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
            SQL.Query(@"SELECT customer.customerID, customer.name as 'Members', customer.card_no as 'CARD NO.', membership.name as 'Membership' FROM customer
                            INNER JOIN membership ON customer.member_type_ID = membership.member_type_ID
                            ORDER BY customer.name ASC");
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
            guna2TextBox6.Clear();
            txtCus_ID.Clear();
            txtCus_Name.Clear();
            txtCus_Search.Clear();

            LoadCustomer();
        }
        private void TextboxValidation()
        {
            AssignValidation(ref txtCus_CardNo, ValidationType.Int_Only);
            AssignValidation(ref txtCus_Contact, ValidationType.Int_Only);
            AssignValidation(ref txtMC_CardNo, ValidationType.Int_Only);
            AssignValidation(ref txtMem_DiscAmount, ValidationType.Price);
            AssignValidation(ref txtMem_AmtPerPoint, ValidationType.Price);
            AssignValidation(ref txtMem_Expiration, ValidationType.Int_Only);
        }
        private void ControlBehavior()
        {
            Control ms = (Control)txtMem_Search;
            Control cs = (Control)txtCus_Search;
            Control mcs = (Control)txtMC_Search;

            SetBehavior(ref ms, Behavior.ClearSearch);
            SetBehavior(ref cs, Behavior.ClearSearch);
            SetBehavior(ref mcs, Behavior.ClearSearch);
        }

        //METHODS
        private void Customers_Load(object sender, EventArgs e)
        {
            _Customers = this;

            pnlCustomer.BringToFront();
            clickbtnCustomer = true;
            currentBtn = btnMC;
            currentPanel = pnlMC;
            SelectedButtonContainer(btnCustomer, btnMembership, btnMemberTransactions, btnMC);

            currentBtn = btnCustomer;
            currentPanel = pnlCustomer;

            ControlBehavior();

            LoadCustomer();
            LoadMembership();
            LoadCard();

            OL.ComboValues(cmbCus_Membership, "member_type_ID", "name", "membership");

            // member transaction
            LoadMT_Customers();
            dtpMT_From.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpMT_To.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));
            cmbMT_Customer.SelectedIndex = 0;

            TextboxValidation();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnlCustomer.BringToFront();
            clickbtnCustomer = true;
            SelectedButtonContainer(btnCustomer, btnMembership, btnMemberTransactions, btnMC);

            LoadCustomer();
            OL.changePanel(pnlCustomer, ref currentPanel, btnCustomer, ref currentBtn);
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
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    if (cmbCus_Membership.Text == "")
                    {
                        new Notification().PopUp("Please create membership first.", "Save failed", "error");
                        return;
                    }

                    if (txtCus_Name.Text != "" || txtCus_Contact.Text != "" || txtCus_Add1.Text != "" || guna2TextBox6.Text != "" || txtCus_CardNo.Text != "" || cmbCus_Membership.Text != "")
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
                                            SQL.AddParam("@email", guna2TextBox6.Text);
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
                                            new Notification().PopUp("Data saved.", "Saved", "information");
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
                                            SQL.AddParam("@email", guna2TextBox6.Text);
                                            SQL.AddParam("@member_type_ID", cmbCus_Membership.SelectedValue);
                                            SQL.AddParam("@card_no", txtCus_CardNo.Text);

                                            SQL.Query(@"UPDATE customer SET name = @name, contact = @contact, birthday = @birthday, add1 = @add1, 
                                       add2 = @add2, email = @email, member_type_ID = @member_type_ID, card_no = @card_no
                                       WHERE customerID = @customerID");

                                            if (SQL.HasException(true))
                                                return;

                                            new Notification().PopUp("Data saved.", "", "information");
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
                }));
            }).Start();
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
                guna2TextBox6.Text = r["email"].ToString();
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

                SQL.Query("SELECT customerID, name as 'Customers / Members' FROM customer WHERE name LIKE @find ORDER BY name ASC");
                if (SQL.HasException(true))
                    return;

                dgvCustomer.DataSource = SQL.DBDT;
                dgvCustomer.Columns[0].Visible = false;
            }
        }

        private void dgvMembership_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@member_type_ID", dgvMembership.CurrentRow.Cells[0].Value.ToString());

            SQL.Query("SELECT * FROM membership WHERE member_type_ID = @member_type_ID");
            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                membership_id = r["member_type_ID"].ToString();
                txtMem_Name.Text = r["name"].ToString();
                txtMem_DiscAmount.Text = r["disc_amt"].ToString();
                txtMem_Expiration.Text = r["expiration"].ToString();
                txtMem_AmtPerPoint.Text = r["amt_per_pt"].ToString();

                if (Convert.ToBoolean(r["discountable"]))
                    rbMem_DiscYes.Checked = true;
                else
                    rbMem_DiscNo.Checked = true;

                if (Convert.ToInt32(r["disc_type"]) == 1)
                    rbMem_TypeAmount.Checked = true;
                else
                    rbMem_TypePercentage.Checked = true;

                if (Convert.ToBoolean(r["rewardable"]))
                    rbMem_RewardableYes.Checked = true;
                else
                    rbMem_RewardableNo.Checked = true;
            }
        }

        private void btnMem_Save_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    if (txtMem_Name.Text != "" || txtMem_DiscAmount.Text != "" || txtMem_Expiration.Text == "" || txtMem_AmtPerPoint.Text == "")
                    {
                        string action = "Update";
                        bool discountable = false;
                        int disc_type = 2;
                        bool rewardable = false;

                        if (membership_id == "")
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
                                        new Notification().PopUp("Data saved.", "", "information");
                                    }
                                    else
                                        new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                                    break;
                                }

                            default:
                                {
                                    SQL.AddParam("@member_type_ID", membership_id);
                                    SQL.AddParam("@name", txtMem_Name.Text);

                                    string result = SQL.ReturnResult(@"SELECT IIF((
                SELECT COUNT(*) as duplicatecount FROM membership WHERE name = @name AND member_type_ID <> @member_type_ID) > 0,
                1, 0) as result");

                                    if (SQL.HasException(true))
                                        return;


                                    if (result == "0")
                                    {
                                        SQL.AddParam("@member_type_ID", membership_id);
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
                }));
            }).Start();
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

        private void btnMem_Delete_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    DialogResult approval = MessageBox.Show("Delete this member?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (approval == DialogResult.Yes)
                    {
                        if (membership_id == "")
                        {
                            new Notification().PopUp("No item selected.", "", "error");
                            return;
                        }

                        SQL.AddParam("@member_type_ID", membership_id);
                        SQL.Query("DELETE FROM membership WHERE member_type_ID = @member_type_ID");

                        if (SQL.HasException(true))
                            return;

                        LoadMembership();

                        ClearFields_Mem();

                        new Notification().PopUp("Item deleted.", "", "information");

                        OL.ComboValues(cmbCus_Membership, "member_type_ID", "name", "membership");
                    }
                }));
            }).Start();
        }

        private void btnMem_New_Click(object sender, EventArgs e)
        {
            ClearFields_Mem();
        }

        private void dgvCard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@cardID", dgvCard.CurrentRow.Cells[0].Value.ToString());

            SQL.Query(@"SELECT member_card.cardID, member_card.card_no, membership.name, member_card.customer_name, member_card.card_balance, member_card.status FROM member_card
                        INNER JOIN membership ON member_card.member_type_ID = membership.member_type_ID
                        WHERE member_card.cardID = @cardID");
            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                card_id = r["cardID"].ToString();
                txtMC_CardNo.Text = r["card_no"].ToString();
                txtMC_Membership.Text = r["name"].ToString();
                txtMC_Owner.Text = r["customer_name"].ToString();
                txtMC_Balance.Text = r["card_balance"].ToString();
                txtMC_Status.Text = r["status"].ToString();
            }
        }

        private void btnMC_RegisterCard_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    CardRF();

                    int requiredFieldsMet = RequireField(ref requiredFields);

                    if (requiredFieldsMet == 1)
                    {

                        // check for duplicate names
                        SQL.AddParam("@card_no", txtMC_CardNo.Text);
                        int result = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM member_card WHERE card_no = @card_no) > 0,'1', '0') as result"));

                        if (SQL.HasException(true))
                            return;

                        if (result == 0)
                        {
                            SQL.AddParam("@card_no", txtMC_CardNo.Text);

                            SQL.Query(@"INSERT INTO member_card (card_no, member_type_ID, customerID, customer_name, card_balance, status)
                                       VALUES (@card_no, 0, 0, '', 0, 'Available')");
                            if (SQL.HasException(true))
                                return;

                            ClearFields_Card();
                            LoadCard();
                            new Notification().PopUp("Data saved.", "", "information");
                        }
                        else
                            new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                    }
                }));
            }).Start();
        }

        private void btnMC_LostReplaceCard_Click(object sender, EventArgs e)
        {
            DialogResult approval = MessageBox.Show("Replace this card? Details of this card will be transferred to a new card", "Lost/Replacement", MessageBoxButtons.YesNo);

            if (txtMC_Status.Text == "Owner removed")
            {
                new Notification().PopUp("This card is unavailable", "Replacement failed", "error");
                return;
            }


            if (approval == DialogResult.Yes)
            {
                ReplaceCard frmReplaceCard = new ReplaceCard();
                frmReplaceCard.old_card = txtMC_CardNo.Text;
                frmReplaceCard.ShowDialog();
            }
        }

        private void btnMC_ReactivateCard_Click(object sender, EventArgs e)
        {
            if (txtMC_Status.Text == "Active")
                new Notification().PopUp("Card is already active", "", "error");
            else if (txtMC_Status.Text == "Expired")
            {
                DialogResult approval = MessageBox.Show("Activate this card?", "Re-Activation Card", MessageBoxButtons.YesNo);

                if (approval == DialogResult.Yes)
                {
                    SQL.AddParam("@card_no", txtMC_CardNo.Text);

                    SQL.Query("UPDATE member_card SET Status = 'Active' WHERE card_no = @card_no");
                    if (SQL.HasException(true))
                        return;
                }
            }
            else
                new Notification().PopUp("This card is unavailable", "Re-activation failed", "error");
        }

        private void btnMC_NewCard_Click(object sender, EventArgs e)
        {
            ClearCard_Mem();
        }

        private void txtMC_Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMC_Search.Text == "")
                LoadCard();
            else
            {
                SQL.AddParam("@find", txtMC_Search.Text + "%");

                SQL.Query(@"SELECT cardID, card_no as 'CARD NUMBER' FROM member_card WHERE card_no LIKE @find 
                           OR customer_name LIKE @find ORDER BY card_no ASC");

                if (SQL.HasException(true))
                    return;

                dgvCard.DataSource = SQL.DBDT;
                dgvCard.Columns[0].Visible = false;
            }
        }

        private void btnMT_PrintReceipt_Click(object sender, EventArgs e)
        {
            if (dgvMT_ClickedOnce == false)
                return;

            if (Properties.Settings.Default.papersize == "58MM")
            {
                reprint_receipt = new PaymentR58();

                int fontSize_regular = int.Parse(Properties.Settings.Default.RegularTextFont);
                int fontSize_products = int.Parse(Properties.Settings.Default.ProductListFont);
                int fontSize_bname = int.Parse(Properties.Settings.Default.TitleTextFont);
                int fontSize_bheader = int.Parse(Properties.Settings.Default.BusinessDetailsFont);
                int fontSize_transactionDetails = int.Parse(Properties.Settings.Default.TransactionDetailsFont);

                #region Font
                //header

                //Business Name
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["businessname1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_bname, FontStyle.Bold));
                //Business details
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["businessaddress1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["bcontact"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["btin"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["bsn"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_bheader, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["bmin"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_bheader, FontStyle.Regular));

                //Regular
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["rnote"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_regular, FontStyle.Bold));

                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tdatetitle"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_regular, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tinvoicetitle"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_regular, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tcashier"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_regular, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tterminal"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_regular, FontStyle.Bold));

                //Product List
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tqty"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_products, FontStyle.Bold));
                //((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tproducts"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_products, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tprice"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_products, FontStyle.Bold));
                //((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["quantity1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_products, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["description1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_products, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["sellingprice"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_products, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["txtstaticpriceinclusive"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_products, FontStyle.Regular));

                //Transaction Details
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tnoofitems"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Bold));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["noofitems1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Bold));

                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tsubtotal"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["subtotal1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tlessvat"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["lessvat1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tdiscount"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["discount1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tpoints"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["pointsdeduct1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tgiftcard"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["giftcarddeduct1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["ttotal"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["total1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tvatablesales"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["vatablesales1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tvatamount"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["vat121"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tvatexempt"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["vatexemptsales1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tzerorated"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["zeroratedsales1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tgcno"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["giftcardno1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tpaymentmethod"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["cash1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["trefno"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["ReferenceNumber1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails, FontStyle.Regular));
                ((TextObject)reprint_receipt.ReportDefinition.ReportObjects["tchange"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["change1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_transactionDetails + 1, FontStyle.Bold));

                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["footertext1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_regular, FontStyle.Bold));
                ((FieldObject)reprint_receipt.ReportDefinition.ReportObjects["txtfooter1"]).ApplyFont(new System.Drawing.Font("Arial", fontSize_regular, FontStyle.Bold));

                #endregion



                DataSet ds = new DataSet();
                
                try
                {
                    string order = SQL.ReturnResult("SELECT action FROM transaction_details WHERE order_ref = " + dgvMT_Records.CurrentRow.Cells[0].Value.ToString());
                    if (SQL.HasException(true))
                        return;

                    if (order == "1")
                    {
                        SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive, selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvMT_Records.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                        if (SQL.HasException(true))
                            return;
                    }
                    else
                    {
                        SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, (-1 * static_price_inclusive) as static_price_inclusive, (-1 * selling_price_inclusive) as selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvMT_Records.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                        if (SQL.HasException(true))
                            return;
                    }

                    //SQL.DBDA.SelectCommand = new SqlCommand("SELECT quantity, description, (-1 * static_price_inclusive) as static_price_inclusive, (-1 * selling_price_inclusive) as selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvRecords.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                    SQL.DBDA.Fill(ds, "transaction_items");
                    reprint_receipt.SetDataSource(ds);

                    if (order == "1")
                    {
                        SQL.AddParam("@order_ref", dgvMT_Records.CurrentRow.Cells[0].Value.ToString());
                        SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users 
                            SELECT * INTO #Temp_users FROM (SELECT ID, user_name, first_name 
                            FROM(SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts 
                            UNION ALL SELECT userID, user_name, first_name FROM users ) x ) as a; 
                            SELECT date_time,transaction_details.order_ref_temp, u.first_name as 'user_first_name',  no_of_items,  subtotal,  less_vat, disc_amt, 
                            cus_pts_deducted, grand_total, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, payment_amt, change, giftcard_no, 
                            giftcard_deducted, IIF(cus_name = '', '0', cus_name) as 'cus_name', cus_special_ID_no, refund_order_ref_temp, return_order_ref_temp, 
                            payment_method, action,referenceNo, terminal_id as 'tid' FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                            WHERE transaction_details.order_ref = @order_ref");
                        if (SQL.HasException(true))
                            return;
                    }
                    else
                    {
                        SQL.AddParam("@order_ref", dgvMT_Records.CurrentRow.Cells[0].Value.ToString());
                        SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users 
                            SELECT * INTO #Temp_users FROM (SELECT ID, user_name, first_name 
                            FROM(SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts 
                            UNION ALL SELECT userID, user_name, first_name FROM users ) x ) as a; 
                            SELECT date_time,transaction_details.order_ref_temp, u.first_name as 'user_first_name',  no_of_items,  subtotal,  less_vat, disc_amt, 
                            cus_pts_deducted, grand_total, vatable_sale, vat_12, vat_exempt_sale, zero_rated_sale, payment_amt, change, giftcard_no, 
                            giftcard_deducted, IIF(cus_name = '', '0', cus_name) as 'cus_name', cus_special_ID_no, refund_order_ref_temp, return_order_ref_temp, 
                            payment_method, action,referenceNo, vt.void_order_ref_temp, transaction_details.terminal_id as 'tid' FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                            INNER JOIN void_transaction as vt ON vt.order_ref = transaction_details.order_ref WHERE transaction_details.order_ref = @order_ref");
                        if (SQL.HasException(true))
                            return;
                    }

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {

                        reprint_receipt.SetParameterValue("date_time", r["date_time"].ToString());
                        reprint_receipt.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        reprint_receipt.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        reprint_receipt.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                        reprint_receipt.SetParameterValue("Terminal_No", r["tid"].ToString());
                        decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                        reprint_receipt.SetParameterValue("subtotal", subtotal.ToString("N2"));
                        decimal less_vat = decimal.Parse(r["less_vat"].ToString());
                        reprint_receipt.SetParameterValue("less_vat", less_vat.ToString("N2"));
                        decimal disc_amt = decimal.Parse(r["disc_amt"].ToString());
                        reprint_receipt.SetParameterValue("discount", disc_amt.ToString("N2"));
                        decimal cus_pts_deducted = decimal.Parse(r["cus_pts_deducted"].ToString());
                        reprint_receipt.SetParameterValue("points_deduct", cus_pts_deducted.ToString("N2"));
                        decimal giftcard_deducted = decimal.Parse(r["giftcard_deducted"].ToString());
                        reprint_receipt.SetParameterValue("giftcard_deduct", giftcard_deducted.ToString("N2"));
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                        reprint_receipt.SetParameterValue("total", grand_total.ToString("N2"));
                        decimal vatable_sale = decimal.Parse(r["vatable_sale"].ToString());
                        reprint_receipt.SetParameterValue("vatable_sales", vatable_sale.ToString("N2"));
                        decimal vat_12 = decimal.Parse(r["vat_12"].ToString());
                        reprint_receipt.SetParameterValue("vat_12", vat_12.ToString("N2"));
                        decimal vat_exempt_sale = decimal.Parse(r["vat_exempt_sale"].ToString());
                        reprint_receipt.SetParameterValue("vat_exempt_sales", vat_exempt_sale.ToString("N2"));
                        decimal zero_rated_sale = decimal.Parse(r["zero_rated_sale"].ToString());
                        reprint_receipt.SetParameterValue("zero_rated_sales", zero_rated_sale.ToString("N2"));
                        decimal giftcard_no = decimal.Parse(r["giftcard_no"].ToString());
                        reprint_receipt.SetParameterValue("giftcard_no", giftcard_no.ToString("N2"));
                        decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                        reprint_receipt.SetParameterValue("cash", payment_amt.ToString("N2"));
                        decimal change = decimal.Parse(r["change"].ToString());
                        reprint_receipt.SetParameterValue("change", change.ToString("N2"));

                        //REFERENCE NO
                        reprint_receipt.SetParameterValue("ReferenceNumber", r["referenceNo"].ToString());

                        if (r["cus_name"].ToString() == "0")
                        {
                            reprint_receipt.SetParameterValue("cus_name", "________________________________________________________");
                        }
                        else
                        {
                            reprint_receipt.SetParameterValue("cus_name", r["cus_name"].ToString());
                        }


                        if (r["cus_special_ID_no"].ToString() == "0")
                        {
                            reprint_receipt.SetParameterValue("cus_sc_pwd_id", "________________________________________________________");
                        }
                        else
                        {
                            reprint_receipt.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                        }

                        reprint_receipt.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());
                        string note = "###REPRINT###";

                        if (r["action"].ToString() == "4")
                            note = note + Constants.vbCrLf + "VOID # " + r["void_order_ref_temp"].ToString();

                        reprint_receipt.SetParameterValue("note", note);
                    }

                    reprint_receipt.SetParameterValue("business_name", Main.Instance.sd_business_name);
                    reprint_receipt.SetParameterValue("business_address", Main.Instance.sd_business_address);
                    reprint_receipt.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                    reprint_receipt.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                    reprint_receipt.SetParameterValue("sn", Main.Instance.sd_sn);
                    reprint_receipt.SetParameterValue("min", Main.Instance.sd_min);
                    reprint_receipt.SetParameterValue("footer_text", Main.Instance.sd_footer_text);
                    reprint_receipt.SetParameterValue("ptu_no", Main.Instance.sd_ptu_no);

                    DateTime dateissue = DateTime.Parse(Main.Instance.sd_pn_date_issued);
                    reprint_receipt.SetParameterValue("date_issued", dateissue.ToString("MM/dd/yyyy"));

                    DateTime validuntil = DateTime.Parse(Main.Instance.sd_pn_valid_until);
                    reprint_receipt.SetParameterValue("valid_until", validuntil.ToString("MM/dd/yyyy"));

                    if (Properties.Settings.Default.isBirAccredited)
                    {
                        reprint_receipt.SetParameterValue("is_vatable", true);
                        reprint_receipt.SetParameterValue("txt_footer", "THIS SERVES AS OFFICIAL RECEIPT.");
                    }
                    else
                    {
                        reprint_receipt.SetParameterValue("is_vatable", false);
                        reprint_receipt.SetParameterValue("txt_footer", "THIS SERVES AS DEMO RECEIPT.");
                    }
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.Message);
                    reprint_receipt.Dispose();
                }

                // print
                if (Main.Instance.pd_receipt_printer == "")
                {
                    new Notification().PopUp("No receipt printer selected.", "Error printing", "error");
                    return;
                }


                bool checkprinter = PrinterExists(Main.Instance.pd_receipt_printer);

                if (checkprinter == false)
                {
                    new Notification().PopUp("Printer is offline", "error", "error");
                    return;
                }


                reprint_receipt.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                reprint_receipt.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                reprint_receipt.PrintToPrinter(1, false, 0, 0);
            }
            else
            {
                reprint_receipt80 = new PaymentReceipt80();

                DataSet ds = new DataSet();

                try
                {
                    SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive FROM transaction_items WHERE order_ref = " + dgvMT_Records.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                    SQL.DBDA.Fill(ds, "transaction_items");

                    reprint_receipt80.SetDataSource(ds);

                    SQL.AddParam("@order_ref", dgvMT_Records.CurrentRow.Cells[0].Value.ToString());

                    SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                           SELECT * INTO #Temp_users
                           FROM
                           (
                           SELECT ID, user_name, first_name FROM
                           (
                           SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts
                           UNION ALL
                           SELECT userID, user_name, first_name FROM users
                           ) x
                           ) as a;
                           SELECT date_time,
                           order_ref_temp, 
                           u.first_name as 'user_first_name', 
                           no_of_items, 
                           subtotal, 
                           less_vat, 
                           disc_amt, 
                           cus_pts_deducted, 
                           grand_total,
                           vatable_sale,
                           vat_12,
                           vat_exempt_sale,
                           zero_rated_sale,
                           payment_amt, 
                           change,
                           giftcard_no, 
                           giftcard_deducted,
                           IIF(cus_name = '', '0', cus_name) as 'cus_name',
                           cus_special_ID_no,
                           refund_order_ref_temp, 
                           return_order_ref_temp, 
                           action,
                           payment_method 
                           FROM transaction_details INNER JOIN #Temp_users as u ON transaction_details.userID = u.ID
                           WHERE order_ref = @order_ref");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        reprint_receipt80.SetParameterValue("date_time", r["date_time"].ToString());
                        reprint_receipt80.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        reprint_receipt80.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        reprint_receipt80.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                        reprint_receipt80.SetParameterValue("Terminal_No", Properties.Settings.Default.Terminal_id);
                        decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                        reprint_receipt80.SetParameterValue("subtotal", subtotal.ToString("N2"));
                        decimal less_vat = decimal.Parse(r["less_vat"].ToString());
                        reprint_receipt80.SetParameterValue("less_vat", less_vat.ToString("N2"));
                        decimal disc_amt = decimal.Parse(r["disc_amt"].ToString());
                        reprint_receipt80.SetParameterValue("discount", disc_amt.ToString("N2"));
                        decimal cus_pts_deducted = decimal.Parse(r["cus_pts_deducted"].ToString());
                        reprint_receipt80.SetParameterValue("points_deduct", cus_pts_deducted.ToString("N2"));
                        decimal giftcard_deducted = decimal.Parse(r["giftcard_deducted"].ToString());
                        reprint_receipt80.SetParameterValue("giftcard_deduct", giftcard_deducted.ToString("N2"));
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                        reprint_receipt80.SetParameterValue("total", grand_total.ToString("N2"));
                        decimal vatable_sale = decimal.Parse(r["vatable_sale"].ToString());
                        reprint_receipt80.SetParameterValue("vatable_sales", vatable_sale.ToString("N2"));
                        decimal vat_12 = decimal.Parse(r["vat_12"].ToString());
                        reprint_receipt80.SetParameterValue("vat_12", vat_12.ToString("N2"));
                        decimal vat_exempt_sale = decimal.Parse(r["vat_exempt_sale"].ToString());
                        reprint_receipt80.SetParameterValue("vat_exempt_sales", vat_exempt_sale.ToString("N2"));
                        decimal zero_rated_sale = decimal.Parse(r["zero_rated_sale"].ToString());
                        reprint_receipt80.SetParameterValue("zero_rated_sales", zero_rated_sale.ToString("N2"));
                        reprint_receipt80.SetParameterValue("giftcard_no", r["giftcard_no"].ToString());
                        decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                        reprint_receipt80.SetParameterValue("cash", payment_amt.ToString("N2"));
                        decimal change = decimal.Parse(r["change"].ToString());
                        reprint_receipt80.SetParameterValue("change", change.ToString("N2"));
                        reprint_receipt80.SetParameterValue("cus_name", r["cus_name"].ToString());
                        reprint_receipt80.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                        reprint_receipt80.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());

                        string note = "###REPRINT###";

                        if (Convert.ToInt32(r["action"].ToString()) == 2)
                            note = note + Constants.vbCrLf + "REFUND FROM INVOICE # " + r["refund_order_ref_temp"].ToString();
                        else if (Convert.ToInt32(r["action"].ToString()) == 3)
                            note = note + Constants.vbCrLf + "RETURN ITEM FROM INVOICE # " + r["return_order_ref_temp"].ToString();
                        else if (Convert.ToInt32(r["action"].ToString()) == 4)
                            note = note + Constants.vbCrLf + "VOID TRANSACTION";

                        reprint_receipt80.SetParameterValue("note", note);
                    }

                    reprint_receipt80.SetParameterValue("business_name", Main.Instance.sd_business_name);
                    reprint_receipt80.SetParameterValue("business_address", Main.Instance.sd_business_address);
                    reprint_receipt80.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                    reprint_receipt80.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                    reprint_receipt80.SetParameterValue("sn", Main.Instance.sd_sn);
                    reprint_receipt80.SetParameterValue("min", Main.Instance.sd_min);
                    reprint_receipt80.SetParameterValue("footer_text", Main.Instance.sd_footer_text);
                    reprint_receipt80.SetParameterValue("ptu_no", Main.Instance.sd_ptu_no);

                    DateTime dateissue = DateTime.Parse(Main.Instance.sd_pn_date_issued);
                    reprint_receipt80.SetParameterValue("date_issued", dateissue.ToString("MM/dd/yyyy"));

                    DateTime validuntil = DateTime.Parse(Main.Instance.sd_pn_valid_until);
                    reprint_receipt80.SetParameterValue("valid_until", validuntil.ToString("MM/dd/yyyy"));

                    if (Properties.Settings.Default.isBirAccredited)
                    {
                        reprint_receipt80.SetParameterValue("is_vatable", true);
                        reprint_receipt80.SetParameterValue("txt_footer", "This serves as Official Receipt.");
                    }
                    else
                    {
                        reprint_receipt80.SetParameterValue("is_vatable", false);
                        reprint_receipt80.SetParameterValue("txt_footer", "This serves as Demo Receipt.");
                    }
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.Message);
                    reprint_receipt80.Dispose();
                }

                // print
                if (Main.Instance.pd_receipt_printer == "")
                {
                    new Notification().PopUp("No receipt printer selected.", "Error printing", "error");
                    return;
                }


                bool checkprinter = PrinterExists(Main.Instance.pd_receipt_printer);

                if (checkprinter == false)
                {
                    new Notification().PopUp("Printer is offline", "error", "error");
                    return;
                }


                reprint_receipt80.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                reprint_receipt80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                reprint_receipt80.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void btnMT_ExportReport_Click(object sender, EventArgs e)
        {
            EI.ExportDgvToPDF("Member Transactions", dgvMT_Records);
        }

        private void loadDGVdata()
        {
            string cus_query = "cus_ID_no <> 0";

            if (cmbMT_Customer.SelectedIndex != 0)
                cus_query = "cus_ID_no = " + cmbMT_Customer.SelectedValue;

            SQL.AddParam("@from", dtpMT_From.Value);
            SQL.AddParam("@to", dtpMT_To.Value);

            SQL.Query(@"SELECT order_ref as 'ID', order_ref_temp as 'Invoice #', date_time as 'Date', cus_name as 'Customer', 
                       mc.card_no as 'Card #', CONVERT(DECIMAL(18,2), grand_total) as 'Total' FROM transaction_details INNER JOIN member_card as mc ON transaction_details.cus_ID_no = mc.customerID
                       WHERE date_time BETWEEN @from AND @to AND cus_type = 4 AND " + cus_query + " ORDER BY date_time DESC");

            if (SQL.HasException(true))
                return;

            dgvMT_Records.DataSource = SQL.DBDT;
            dgvMT_Records.Columns[0].Visible = false;
        }

        private void dgvMT_Records_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            dgvMT_ClickedOnce = true;

            if (Properties.Settings.Default.papersize == "58MM")
            {
                report = new PaymentR58();

                DataSet ds = new DataSet();

                try
                {
                    CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;

                    string order = SQL.ReturnResult("SELECT action FROM transaction_details WHERE order_ref = " + dgvMT_Records.CurrentRow.Cells[0].Value.ToString());
                    if (order == "1")
                    {
                        SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive, selling_price_inclusive FROM transaction_items WHERE order_ref =  " + dgvMT_Records.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                    }
                    else
                    {
                        SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive as static_price_inclusive, selling_price_inclusive as selling_price_inclusive FROM transaction_items WHERE order_ref = " + dgvMT_Records.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);

                    }

                    SQL.DBDA.Fill(ds, "transaction_items");
                    report.SetDataSource(ds);

                    if (order == "1")
                    {
                        SQL.AddParam("@order_ref", dgvMT_Records.CurrentRow.Cells[0].Value.ToString());
                        SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                           SELECT * INTO #Temp_users
                           FROM
                           (
                           SELECT ID, user_name, first_name FROM
                           (
                           SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts
                           UNION ALL
                           SELECT userID, user_name, first_name FROM users
                           ) x
                           ) as a;
                           SELECT td.*, u.first_name as 'user_first_name', td.terminal_id as 'tid'
                           FROM transaction_details as td INNER JOIN #Temp_users as u ON td.userID = u.ID
                           WHERE order_ref = @order_ref");
                    }
                    else
                    {
                        SQL.AddParam("@order_ref", dgvMT_Records.CurrentRow.Cells[0].Value.ToString());
                        SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                           SELECT * INTO #Temp_users
                           FROM
                           (
                           SELECT ID, user_name, first_name FROM
                           (
                           SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts
                           UNION ALL
                           SELECT userID, user_name, first_name FROM users
                           ) x
                           ) as a;
                           SELECT td.*, u.first_name as 'user_first_name', vt.void_order_ref_temp, td.terminal_id as 'tid'
                           FROM transaction_details as td INNER JOIN #Temp_users as u ON td.userID = u.ID 
                           INNER JOIN void_transaction as vt ON vt.order_ref = td.order_ref
                           WHERE td.order_ref = @order_ref");
                    }

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report.SetParameterValue("date_time", r["date_time"].ToString());
                        report.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        report.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        decimal no_of_items = decimal.Parse(r["no_of_items"].ToString());
                        report.SetParameterValue("no_of_items", no_of_items.ToString("N2"));
                        report.SetParameterValue("Terminal_No", r["tid"].ToString());
                        decimal subtotal = decimal.Parse(r["subtotal"].ToString());
                        report.SetParameterValue("subtotal", subtotal.ToString("N2"));
                        decimal less_vat = decimal.Parse(r["less_vat"].ToString());
                        report.SetParameterValue("less_vat", less_vat.ToString("N2"));
                        decimal disc_amt = decimal.Parse(r["disc_amt"].ToString());
                        report.SetParameterValue("discount", disc_amt.ToString("N2"));
                        decimal cus_pts_deducted = decimal.Parse(r["cus_pts_deducted"].ToString());
                        report.SetParameterValue("points_deduct", cus_pts_deducted.ToString("N2"));
                        decimal giftcard_deducted = decimal.Parse(r["giftcard_deducted"].ToString());
                        report.SetParameterValue("giftcard_deduct", giftcard_deducted.ToString("N2"));
                        decimal grand_total = decimal.Parse(r["grand_total"].ToString());
                        report.SetParameterValue("total", grand_total.ToString("N2"));
                        decimal vatable_sale = decimal.Parse(r["vatable_sale"].ToString());
                        report.SetParameterValue("vatable_sales", vatable_sale.ToString("N2"));
                        decimal vat_12 = decimal.Parse(r["vat_12"].ToString());
                        report.SetParameterValue("vat_12", vat_12.ToString("N2"));
                        decimal vat_exempt_sale = decimal.Parse(r["vat_exempt_sale"].ToString());
                        report.SetParameterValue("vat_exempt_sales", vat_exempt_sale.ToString("N2"));
                        decimal zero_rated_sale = decimal.Parse(r["zero_rated_sale"].ToString());
                        report.SetParameterValue("zero_rated_sales", zero_rated_sale.ToString("N2"));
                        decimal giftcard_no = decimal.Parse(r["giftcard_no"].ToString());
                        report.SetParameterValue("giftcard_no", giftcard_no.ToString("N2"));
                        decimal payment_amt = decimal.Parse(r["payment_amt"].ToString());
                        report.SetParameterValue("cash", payment_amt.ToString("N2"));
                        decimal change = decimal.Parse(r["change"].ToString());
                        report.SetParameterValue("change", change.ToString("N2"));

                        //REFERENCE NO
                        report.SetParameterValue("ReferenceNumber", r["referenceNo"].ToString());

                        if (r["cus_name"].ToString() == "0" || r["cus_name"].ToString() == "")
                        {
                            report.SetParameterValue("cus_name", "________________________________________________________");
                        }
                        else
                        {
                            report.SetParameterValue("cus_name", r["cus_name"].ToString());
                        }


                        if (r["cus_special_ID_no"].ToString() == "0")
                        {
                            report.SetParameterValue("cus_sc_pwd_id", "________________________________________________________");
                        }
                        else
                        {
                            report.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                        }

                        report.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());
                        string note = "###REPRINT###";

                        if (r["action"].ToString() == "4")
                            note = note + Constants.vbCrLf + "VOID # " + r["void_order_ref_temp"].ToString();

                        report.SetParameterValue("note", note);

                        report.SetParameterValue("business_name", Main.Instance.sd_business_name);
                        report.SetParameterValue("business_address", Main.Instance.sd_business_address);
                        report.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);
                        report.SetParameterValue("vat_reg_tin", Main.Instance.sd_vat_reg_tin);
                        report.SetParameterValue("sn", Main.Instance.sd_sn);
                        report.SetParameterValue("min", Main.Instance.sd_min);
                        report.SetParameterValue("footer_text", Main.Instance.sd_footer_text);
                        report.SetParameterValue("ptu_no", Main.Instance.sd_ptu_no);

                        DateTime dateissue = DateTime.Parse(Main.Instance.sd_pn_date_issued);
                        report.SetParameterValue("date_issued", dateissue.ToString("MM/dd/yyyy"));

                        DateTime validuntil = DateTime.Parse(Main.Instance.sd_pn_valid_until);
                        report.SetParameterValue("valid_until", validuntil.ToString("MM/dd/yyyy"));

                        if (Properties.Settings.Default.isBirAccredited)
                        {
                            report.SetParameterValue("is_vatable", true);
                            report.SetParameterValue("txt_footer", "THIS SERVES AS OFFICIAL RECEIPT.");
                        }
                        else
                        {
                            report.SetParameterValue("is_vatable", false);
                            report.SetParameterValue("txt_footer", "THIS SERVES AS DEMO RECEIPT.");
                        }

                        CrystalReportViewer1.ReportSource = report;
                        CrystalReportViewer1.Refresh();
                        CrystalReportViewer1.Zoom(1);
                    }
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.ToString());
                    report.Dispose();
                }
            }
            else
            {
                report80 = new TransactionsReport80();

                DataSet ds = new DataSet();

                try
                {
                    CrystalReportViewer1.ReuseParameterValuesOnRefresh = false;

                    SQL.DBDA.SelectCommand = new SqlCommand("SELECT CAST(IIF((SELECT isDecimal FROM units WHERE unit_name = unit) = 0, CAST(CAST(ROUND(quantity,0) as int) AS varchar(20)), CAST(quantity AS varchar(20)) + unit) AS varchar(20)) as 'quantity', description, static_price_inclusive FROM transaction_items WHERE order_ref = " + dgvMT_Records.CurrentRow.Cells[0].Value.ToString(), SQL.DBCon);
                    SQL.DBDA.Fill(ds, "transaction_items");

                    report80.SetDataSource(ds);

                    SQL.AddParam("@order_ref", dgvMT_Records.CurrentRow.Cells[0].Value.ToString());

                    SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                           SELECT * INTO #Temp_users
                           FROM
                           (
                           SELECT ID, user_name, first_name FROM
                           (
                           SELECT adminID as 'ID', user_name as 'user_name', first_name as 'first_name' FROM admin_accts
                           UNION ALL
                           SELECT userID, user_name, first_name FROM users
                           ) x
                           ) as a;
                           SELECT td.*, u.first_name as 'user_first_name' FROM transaction_details as td 
                           INNER JOIN #Temp_users as u ON td.userID = u.ID
                           WHERE order_ref = @order_ref");

                    if (SQL.HasException(true))
                        return;

                    foreach (DataRow r in SQL.DBDT.Rows)
                    {
                        report80.SetParameterValue("date_time", r["date_time"].ToString());
                        report80.SetParameterValue("invoice_no", r["order_ref_temp"].ToString());
                        report80.SetParameterValue("user_first_name", r["user_first_name"].ToString());
                        report80.SetParameterValue("no_of_items", r["no_of_items"].ToString());
                        report80.SetParameterValue("subtotal", Math.Round(decimal.Parse(r["subtotal"].ToString()), 2).ToString());
                        report80.SetParameterValue("less_vat", Math.Round(decimal.Parse(r["less_vat"].ToString()), 2).ToString());
                        report80.SetParameterValue("discount", Math.Round(decimal.Parse(r["disc_amt"].ToString()), 2).ToString());
                        report80.SetParameterValue("points_deduct", Math.Round(decimal.Parse(r["cus_pts_deducted"].ToString()), 2).ToString());
                        report80.SetParameterValue("gift_card_deduct", Math.Round(decimal.Parse(r["giftcard_deducted"].ToString()), 2).ToString());
                        report80.SetParameterValue("total", Math.Round(decimal.Parse(r["grand_total"].ToString()), 2).ToString());
                        report80.SetParameterValue("vatable_sales", Math.Round(decimal.Parse(r["vatable_sale"].ToString()), 2).ToString());
                        report80.SetParameterValue("vat_12", Math.Round(decimal.Parse(r["vat_12"].ToString()), 2).ToString());
                        report80.SetParameterValue("vat_exempt_sales", Math.Round(decimal.Parse(r["vat_exempt_sale"].ToString()), 2).ToString());
                        report80.SetParameterValue("zero_rated_sales", Math.Round(decimal.Parse(r["zero_rated_sale"].ToString()), 2).ToString());
                        report80.SetParameterValue("gift_card_no", Math.Round(decimal.Parse(r["giftcard_no"].ToString()), 2).ToString());
                        report80.SetParameterValue("cash", Math.Round(decimal.Parse(r["payment_amt"].ToString()), 2).ToString());
                        report80.SetParameterValue("change", Math.Round(decimal.Parse(r["change"].ToString()), 2).ToString());
                        report80.SetParameterValue("cus_name", r["cus_name"].ToString());
                        report80.SetParameterValue("cus_sc_pwd_id", r["cus_special_ID_no"].ToString());
                        report80.SetParameterValue("payment_method", r["payment_method"].ToString().ToUpper());


                        CrystalReportViewer1.ReportSource = report80;
                        CrystalReportViewer1.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.ToString());
                    report80.Dispose();
                }
            }
        }

        private void txtMem_Search_KeyUp(object sender, KeyEventArgs e)
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

        private void DgvCard_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Do you want to delete this Card ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQLControl psql = new SQLControl();

                    psql.AddParam("@cardID", dgvCard.CurrentRow.Cells[0].Value.ToString());
                    psql.Query("DELETE FROM member_card WHERE cardID = @cardID");

                    if (psql.HasException(true)) return;

                    ClearCard_Mem();
                }
                else return;
            }
        }

        private void cmbMT_Customer_SelectedValueChanged(object sender, EventArgs e)
        {
            loadDGVdata();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            loadDGVdata();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            loadDGVdata();
        }

        private void btnExportDGVToExcel_Click(object sender, EventArgs e)
        {
            new ExportDGVToExcel().ExportToExcel(new ExportDGVToExcel().DataGridViewToDataTable(dgvMT_Records), "Customer Report", "Customer Report");
        }

        private void btnMembership_Click(object sender, EventArgs e)
        {
            clickMembership = true;
            SelectedButtonContainer(btnCustomer, btnMembership, btnMemberTransactions, btnMC);

            LoadMembership();

            OL.changePanel(pnlMembership, ref currentPanel, btnMembership, ref currentBtn);
        }


        private void btnMemberTransactions_Click(object sender, EventArgs e)
        {
            clickMemberTransactions = true;
            SelectedButtonContainer(btnCustomer, btnMembership, btnMemberTransactions, btnMC);

            LoadMT_Customers();
            OL.changePanel(pnlMT, ref currentPanel, btnMemberTransactions, ref currentBtn);
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            clickMC = true;
            SelectedButtonContainer(btnCustomer, btnMembership, btnMemberTransactions, btnMC);

            LoadCard();
            OL.changePanel(pnlMC, ref currentPanel, btnMC, ref currentBtn);
        }
    }
}
