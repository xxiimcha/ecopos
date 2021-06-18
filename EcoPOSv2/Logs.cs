using EcoPOSControl;
using FontAwesome.Sharp;
using Microsoft.VisualBasic;
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
    public partial class Logs : Form
    {
        private SQLControl SQL = new SQLControl();
        private FormLoad OL = new FormLoad();

        private Panel currentPanel;
        private Button currentBtn;
        public Logs()
        {
            InitializeComponent();
        }

        private void Logs_Load(object sender, EventArgs e)
        {
            currentPanel = pnlAT;
            currentBtn = btnAT;

            LoadUserLH();

            dtpAT_From.Value = DateTime.Parse(String.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 00:00:01"));
            dtpAT_To.Value = DateTime.Parse(String.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 23:59:59"));

            dtpLH_From.Value = DateTime.Parse(String.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 00:00:01"));
            dtpLH_To.Value = DateTime.Parse(String.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 23:59:59"));
        }

        private void BtnAT_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlAT, ref currentPanel, btnAT, ref currentBtn);
        }

        private void BtnLH_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlLH, ref currentPanel, btnLH, ref currentBtn);

        }

        private void BtnUA_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlUA, ref currentPanel, btnUA, ref currentBtn);

        }

        private void BtnAT_SearchDates_Click(object sender, EventArgs e)
        {
            SQL.AddParam("@from", dtpAT_From.Value);
            SQL.AddParam("@to", dtpAT_To.Value);
            SQL.Query(@"SELECT Type, TableName as 'Table', PK as 'Key', FieldName as 'Field', 
                       OldValue as 'Old Value', NewValue as 'New Value', UpdateDate as 'Date'
                       FROM Audit ORDER BY UpdateDate DESC");
            if (SQL.HasException(true))
                return;
            dgvAT.DataSource = SQL.DBDT;
        }

        private void BtnSortAT_Click(object sender, EventArgs e)
        {
            if (dgvAT.RowCount == 0)
                return;
            if (btnSortAT.IconChar == IconChar.SortAlphaDown)
            {
                dgvAT.Sort(dgvAT.Columns[6], ListSortDirection.Ascending);
                btnSortAT.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvAT.Sort(dgvAT.Columns[6], ListSortDirection.Descending);
                btnSortAT.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void BtnLH_Search_Click(object sender, EventArgs e)
        {
            string user_query = "userID <> 0";
            if (cmbLH_User.SelectedIndex != 0)
                user_query = "userID = '" + cmbLH_User.SelectedValue + "'";
            SQL.AddParam("@from", dtpLH_From.Value);
            SQL.AddParam("@to", dtpLH_To.Value);
            SQL.Query(@"SELECT userID as 'ID', user_name as 'Username', start as 'Log in', ended as 'Log out' FROM shift
                       WHERE start BETWEEN @from AND @to AND " + user_query + " ORDER BY start DESC");
            if (SQL.HasException(true))
                return;
            dgvLH.DataSource = SQL.DBDT;
        }

        private void BtnLH_Sort_Click(object sender, EventArgs e)
        {
            if (dgvLH.RowCount == 0)
                return;
            if (btnLH_Sort.IconChar == IconChar.SortAlphaDown)
            {
                dgvLH.Sort(dgvLH.Columns[2], ListSortDirection.Ascending);
                btnLH_Sort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvLH.Sort(dgvLH.Columns[2], ListSortDirection.Descending);
                btnLH_Sort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void LoadUserLH()
        {
            OL.ComboValuesQuery(cmbLH_User, @"SELECT userID, user_name FROM
                                         (
                                          SELECT 0 as 'userID', 'All users' as 'user_name', 1 as ord
                                          UNION ALL
                                          SELECT userID, user_name, 2 as ord FROM users
                                         ) x ORDER BY ord, user_name ASC", "userID", "user_name");
        }
    }
}
