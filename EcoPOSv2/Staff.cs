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
using static EcoPOSv2.ControlBehavior;
using static EcoPOSv2.GroupAction;

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
        List<TextBox> requiredFields = new List<TextBox>();

        //METHODS
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
            GA.DoThis(ref allTxt, TableLayoutPanel1, ControlType.TextBox, GroupAction.Action.Clear);
            GA.DoThis(ref allTxt, TableLayoutPanel1, ControlType.CheckBox, GroupAction.Action.Uncheck);

            userID = "";
        }

        private void StaffRF()
        {
            requiredFields = new List<TextBox>();

            requiredFields.Add(txtUsername);
            requiredFields.Add(txtPassword);
            requiredFields.Add(txtFirstName);
            requiredFields.Add(txtLastName);
        }

        private void LoadStaff()
        {
            SQL.Query(@"SELECT userID, user_name as 'Username', first_name as 'First Name', last_name as 'Last Name', user_role.name as 'Role'
                       FROM users INNER JOIN user_role ON users.roleID = user_role.roleID");

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
            ControlBehavior();
            LoadStaff();
            LoadStaffType();
            LoadAdministrator();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnStaffType_Click(object sender, EventArgs e)
        {
            StaffType
        }
    }
}
