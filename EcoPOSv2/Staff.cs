﻿using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EcoPOSv2.ControlBehavior;
using static EcoPOSv2.GroupAction;
using Guna.UI2.WinForms;

namespace EcoPOSv2
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        FormLoad OL = new FormLoad();
        SQLControl SQL = new SQLControl();
        GroupAction GA = new GroupAction();
        Helper HP = new Helper();

        string userID = "";
        List<Control> allTxt = new List<Control>();
        List<Guna2TextBox> requiredFields = new List<Guna2TextBox>();

        //METHODS
        public static Staff _Staff;
        public static Staff Instance
        {
            get
            {
                if (_Staff == null)
                {
                    _Staff = new Staff();
                }
                return _Staff;
            }
        }
        private void ControlBehavior()
        {
            Control c = new Control();
            c = txtSearchUser as Control;
            SetBehavior(ref c, Behavior.ClearSearch);
        }

        public void LoadStaffType()
        {
            OL.ComboValues(cmbStaffType, "roleID", "name", "user_role");
        }

        private void ClearFields()
        {
            GA.DoThis(ref allTxt, Panel4, ControlType.GunaTextBox, GroupAction.Action.Clear);
            GA.DoThis(ref allTxt, Panel4, ControlType.CheckBox, GroupAction.Action.Uncheck);

            userID = "";
        }

        private void StaffRF()
        {
            requiredFields = new List<Guna2TextBox>();

            requiredFields.Add(txtUsername);
            requiredFields.Add(txtPassword);
            requiredFields.Add(txtFirstName);
            requiredFields.Add(txtLastName);
        }

        private void LoadStaff()
        {
            SQL.Query(@"SELECT userID, user_name as 'Username', first_name as 'First Name', last_name as 'Last Name', user_role.name as 'Role'
                       FROM users INNER JOIN user_role ON users.roleID = user_role.roleID WHERE acc_status = 'Active'");

            if (SQL.HasException(true))
                return;

            dgvStaff.DataSource = SQL.DBDT;
            dgvStaff.Columns[0].Visible = false;
        }

        private void LoadAdministrator()
        {
            SQL.Query(@"SELECT adminID, user_name as 'Username', first_name as 'First Name', last_name as 'Last Name' 
                       FROM admin_accts");

            if (SQL.HasException(true))
                return;

            dgvAdministrator.DataSource = SQL.DBDT;
            dgvAdministrator.Columns[0].Visible = false;
        }
        //METHODS
        private void Staff_Load(object sender, EventArgs e)
        {
            _Staff = this;

            ControlBehavior();
            LoadStaff();
            LoadStaffType();
            LoadAdministrator();

            if(Properties.Settings.Default.cardlogin == true)
            {
                tbCardNo.Visible = true;
                lblCardNo.Visible = true;
            }
            else
            {
                tbCardNo.Visible = false;
                lblCardNo.Visible = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //ClearFields();

            ClearFields();
            cmbStaffType.Enabled = true;
            cbxAllow.Enabled = true;
            btnDelete.Enabled = true;

            cmbStaffType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStaffType.SelectedIndex = -1;
        }

        private void btnStaffType_Click(object sender, EventArgs e)
        {
            StaffType.Instance.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StaffRF();

            int requiredFieldsMet = GunaRequireField(ref requiredFields);

            if (requiredFieldsMet == 1 && cmbStaffType.Text != "")
            {
                string action = "Update";
                if (userID == "")
                    action = "New";


                switch (action)
                {
                    case "New":
                        {

                            // check if username exists

                            SQL.AddParam("@user_name", txtUsername.Text);
                            int result = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM users WHERE user_name = @user_name) > 0,'1', '0') as result"));

                            SQL.AddParam("@user_name", txtUsername.Text);
                            int adminresult = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM admin_accts WHERE user_name = @user_name) > 0,'1', '0') as result"));

                            if (SQL.HasException(true))
                                return;

                            if (result == 0 && adminresult==0)
                            {
                                string encrypt_password = HP.Encrypt(txtPassword.Text);

                                SQL.AddParam("@user_name", txtUsername.Text);
                                SQL.AddParam("@password", encrypt_password);
                                SQL.AddParam("@first_name", txtFirstName.Text);
                                SQL.AddParam("@last_name", txtLastName.Text);
                                SQL.AddParam("@roleID", cmbStaffType.SelectedValue);
                                SQL.AddParam("@allow_keycode", cbxAllow.Checked);
                                SQL.AddParam("@keycode", txtKeyPass.Text);
                                SQL.AddParam("@card_no", tbCardNo.Text);

                                SQL.Query(@"INSERT INTO users (user_name, password, first_name, last_name, roleID, allow_keycode, keycode, card_no, acc_status) VALUES
                              (@user_name, @password, @first_name, @last_name, @roleID, @allow_keycode, @keycode, @card_no, 'Active')");

                                if (SQL.HasException(true))
                                    return;
                                ClearFields();
                                new Notification().PopUp("Data saved.", "","information");
                            }
                            else
                                new Notification().PopUp("Duplicate username found.", "Save failed", "error");
                            break;
                        }

                    default:
                        {
                            SQL.AddParam("@userID", userID);
                            SQL.AddParam("@user_name", txtUsername.Text);

                            string result = Convert.ToInt32(SQL.ReturnResult(@"SELECT IIF((
                                SELECT COUNT(*) as duplicatecount FROM users WHERE user_name = @user_name AND userID <> @userID) > 0,
                                1, 0) as result")).ToString();

                            if (SQL.HasException(true))
                                return;

                            if (result == "0")
                            {
                                string encrypt_password = HP.Encrypt(txtPassword.Text);

                                // update administrator

                                if (cmbStaffType.Text == "Administrator")
                                {
                                    SQL.AddParam("@user_name", txtUsername.Text);
                                    SQL.AddParam("@password", encrypt_password);
                                    SQL.AddParam("@first_name", txtFirstName.Text);
                                    SQL.AddParam("@last_name", txtLastName.Text);
                                    SQL.AddParam("@keycode", txtKeyPass.Text);
                                    SQL.AddParam("@card_no", tbCardNo.Text);

                                    SQL.Query(@"UPDATE admin_accts SET user_name = @user_name, password = @password, first_name = @first_name, 
                                           last_name = @last_name, keycode = @keycode , card_no=@card_no");

                                    if (SQL.HasException(true))
                                        return;
                                }
                                else
                                {
                                    SQL.AddParam("@userID", userID);
                                    SQL.AddParam("@user_name", txtUsername.Text);
                                    SQL.AddParam("@password", encrypt_password);
                                    SQL.AddParam("@first_name", txtFirstName.Text);
                                    SQL.AddParam("@last_name", txtLastName.Text);
                                    SQL.AddParam("@roleID", cmbStaffType.SelectedValue);
                                    SQL.AddParam("@allow_keycode", cbxAllow.Checked);
                                    SQL.AddParam("@keycode", txtKeyPass.Text);
                                    SQL.AddParam("@card_no", tbCardNo.Text);

                                    SQL.Query(@"UPDATE users SET user_name = @user_name, password = @password, 
                                      first_name = @first_name, last_name = @last_name, roleID = @roleID, allow_keycode = @allow_keycode, keycode = @keycode, card_no=@card_no 
                                      WHERE userID = @userID");

                                    if (SQL.HasException(true))
                                        return;
                                }


                                ClearFields();
                                new Notification().PopUp("Data saved.", "", "information");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }
                }

                LoadStaff();
                LoadStaffType();
                LoadAdministrator();
            }
            else
                new Notification().PopUp("Please fill all required fields.","","error");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Main.Instance.current_id == userID.ToString() || Main.Instance.by_pass_userID.ToString() == userID.ToString())
            {
                new Notification(5).PopUp("You cannot delete a user that is currently logged in.", "Error", "error");
                return;
            }

            DialogResult approval = MessageBox.Show("Are you sure that you want to delete this user? Doing so will disable the account permanently.", "DELETE WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (approval == DialogResult.Yes)
            {
                if (userID == "")
                {
                    new Notification().PopUp("No item selected.","","error");
                    return;
                }

                SQL.AddParam("@userID", userID);
                SQL.Query("UPDATE users SET acc_status = 'Disabled', user_name = '', password = '' WHERE userID = @userID");

                if (SQL.HasException(true))
                    return;

                LoadStaff();
                LoadStaffType();
                LoadAdministrator();

                ClearFields();

                new Notification().PopUp("Item deleted.","","information");
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@userID", dgvStaff.CurrentRow.Cells[0].Value.ToString());

            SQL.Query("SELECT * FROM users WHERE userID = @userID");
            if (SQL.HasException(true))
                return;

            cmbStaffType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStaffType.SelectedIndex = 0;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                r["keycode"].ToString();
                userID = r["userID"].ToString();
                txtUsername.Text = r["user_name"].ToString();
                txtPassword.Text = HP.Decrypt(r["password"].ToString());
                txtFirstName.Text = r["first_name"].ToString();
                txtLastName.Text = r["last_name"].ToString();
                cmbStaffType.SelectedValue = r["roleID"].ToString();
                cbxAllow.Checked = Convert.ToBoolean(r["allow_keycode"].ToString());
                txtKeyPass.Text = r["keycode"].ToString();
                tbCardNo.Text = r["card_no"].ToString();
            }

            cmbStaffType.Enabled = true;
            cbxAllow.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void txtSearchUser_KeyUp(object sender, KeyEventArgs e)
        {
            SQL.AddParam("@find", txtSearchUser.Text + "%");

            SQL.Query(@"SELECT userID, user_name as 'Username', first_name as 'First Name', last_name as 'Last Name', user_role.name as 'Role'
                       FROM users INNER JOIN user_role ON users.roleID = user_role.roleID
                       WHERE acc_status = 'Active' AND (user_name LIKE @find OR first_name LIKE @find OR last_name LIKE @find)");

            if (SQL.HasException(true))
                return;

            dgvStaff.DataSource = SQL.DBDT;
            dgvStaff.Columns[0].Visible = false;
        }

        private void dgvAdministrator_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@adminID", dgvAdministrator.CurrentRow.Cells[0].Value.ToString());


            SQL.Query("SELECT * FROM admin_accts WHERE adminID = @adminID");
            if (SQL.HasException(true))
                return;

            cmbStaffType.DropDownStyle = ComboBoxStyle.DropDown;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                //r["keycode"].ToString();
                userID = r["adminID"].ToString();
                txtUsername.Text = r["user_name"].ToString();
                txtPassword.Text = HP.Decrypt(r["password"].ToString());
                txtFirstName.Text = r["first_name"].ToString();
                txtLastName.Text = r["last_name"].ToString();
                cmbStaffType.Text = "Administrator";
                cbxAllow.Checked = true;
                txtKeyPass.Text = r["keycode"].ToString();
                tbCardNo.Text = r["card_no"].ToString();
            }

            cmbStaffType.Enabled = false;
            cbxAllow.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
