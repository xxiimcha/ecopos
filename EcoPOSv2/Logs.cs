﻿using EcoPOSControl;
using FontAwesome.Sharp;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            dgvAT.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvAT, true, null);

            this.dgvAT.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        }
        public static Logs _Logs;

        DataSet dsCurrent;
        int dgvCountIndex;
        int pagenumber;
        int pagecount = 1;

        int totalrows;
        
        public static Logs Instance
        {
            get
            {
                if (_Logs == null)
                {
                    _Logs = new Logs();
                }
                return _Logs;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public void SetDoubleBuffered(Panel panel)
        {
            typeof(Panel).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               panel,
               new object[] { true });
        }
        private void Logs_Load(object sender, EventArgs e)
        {
            _Logs = this;

            new CreateParams();
            SetDoubleBuffered(pnlParent);


            currentPanel = pnlAT;
            currentBtn = btnAT;

            LoadUserLH();

            dtpAT_From.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpAT_To.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));
            
            //btnAT_SearchDates.PerformClick();


            dtpLH_From.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpLH_To.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));




            //BASTA

            
        }

        private void BtnAT_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlAT, ref currentPanel, btnAT, ref currentBtn);
        }

        private void BtnLH_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlLH, ref currentPanel, btnLH, ref currentBtn);

            btnLH_Search.PerformClick();
        }

        private void BtnUA_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlUA, ref currentPanel, btnUA, ref currentBtn);

        }

        private void BtnAT_SearchDates_Click(object sender, EventArgs e)
        {
            //SQL.AddParam("@from", dtpAT_From.Value);
            //SQL.AddParam("@to", dtpAT_To.Value);
            //SQL.Query(@"SELECT Type, TableName as 'Table', PK as 'Key', FieldName as 'Field', 
            //           OldValue as 'Old Value', NewValue as 'New Value', UpdateDate as 'Date'
            //           FROM Audit where UpdateDate between @from and @to ORDER BY UpdateDate DESC");
            //if (SQL.HasException(true))
            //    return;

            //dsCurrent.Clear();
            //SQL.DBDA.Fill(dsCurrent, dgvCountIndex, 50, "AuditRecords");


            //pagenumber = SQL.DBDT.Rows.Count / 50;
            //totalrows = SQL.DBDT.Rows.Count;



            //SQL.AddParam("@from", dtpAT_From.Value);
            //SQL.AddParam("@to", dtpAT_To.Value);
            //SQL.Query(@"SELECT Type, TableName as 'Table', PK as 'Key', FieldName as 'Field', 
            //           OldValue as 'Old Value', NewValue as 'New Value', UpdateDate as 'Date'
            //           FROM Audit where UpdateDate between @from and @to ORDER BY UpdateDate DESC");
            //if (SQL.HasException(true))
            //    return;

            //dgvAT.DataSource = SQL.DBDT;



            SQL.AddParam("@from", dtpAT_From.Value);
            SQL.AddParam("@to", dtpAT_To.Value);
            SQL.Query(@"SELECT Type, TableName as 'Table', FieldName as 'Field', 
                       OldValue as 'Old Value', NewValue as 'New Value', UpdateDate as 'Date'
                       FROM Audit where UpdateDate between @from and @to ORDER BY UpdateDate DESC");

            //@"SELECT Type, TableName as 'Table', PK as 'Key', FieldName as 'Field', 
            //OldValue as 'Old Value', NewValue as 'New Value', UpdateDate as 'Date'
            //           FROM Audit where UpdateDate between @from and @to ORDER BY UpdateDate DESC"
            if (SQL.HasException(true))
                return;

            dsCurrent = new DataSet();

            SQL.DBDA.Fill(dsCurrent, dgvCountIndex, 50, "audit");

            dgvAT.DataSource = dsCurrent;
            dgvAT.DataMember = "audit";

            pagenumber = SQL.DBDT.Rows.Count / 50;
            totalrows = SQL.DBDT.Rows.Count;

            //lblPageCount.Text = "Page: " + pagecount.ToString() + "-" + pagenumber;

            //MessageBox.Show(pagenumber.ToString() + " " + totalrows);
        }

        private void BtnSortAT_Click(object sender, EventArgs e)
        {
            if (dgvAT.RowCount == 0)
                return;
            if (btnSortAT.IconChar == IconChar.SortAlphaDown)
            {
                dgvAT.Sort(dgvAT.Columns[5], ListSortDirection.Ascending);
                btnSortAT.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvAT.Sort(dgvAT.Columns[5], ListSortDirection.Descending);
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

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dgvCountIndex -= 50;

            if (dgvCountIndex <= 0)
            {
                dgvCountIndex = 0;
                return;
            }

            dsCurrent.Clear();
            SQL.DBDA.Fill(dsCurrent, dgvCountIndex, 50, "audit");

            pagecount--;
            //lblPageCount.Text = "Page: " + pagecount.ToString() + "-" + pagenumber;

            //if (pagecount <= 1)
            //{
            //    btnPrevious.Enabled = false;
            //    return;
            //}

            //if(pagecount < pagenumber)
            //{
            //    btnNext.Enabled = false;
            //    return;
            //}

            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dgvCountIndex += 50;
            if (dgvCountIndex >= totalrows)
            {
                dgvCountIndex -= 50;
                return;
            }
            dsCurrent.Clear();
            SQL.DBDA.Fill(dsCurrent, dgvCountIndex, 50, "audit");

            //dgvCountIndex = dgvCountIndex + 50;
            pagecount++;
            //lblPageCount.Text = "Page: " + pagecount.ToString() + "-" + pagenumber;

            //if (pagecount > 1)
            //{
            //    btnPrevious.Enabled = true;
            //    return;
            //}

            //if (pagecount >= pagenumber)
            //{
            //    btnNext.Enabled = false;
            //    return;
            //}
        }

        private void btnLH_SearchUser_Click(object sender, EventArgs e)
        {
            btnLH_Search.PerformClick();
        }
    }
}
