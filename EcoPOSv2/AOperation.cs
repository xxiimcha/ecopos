using CrystalDecisions.CrystalReports.Engine;
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
    public partial class AOperation : Form
    {
        public AOperation()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        //ORItems report = new ORItems();
        ReportDocument cryRpt = new ReportDocument();

        bool clickedOnce = false;
        public static AOperation _AOperation;
        public static AOperation Instance
        {
            get
            {
                if (_AOperation == null)
                {
                    _AOperation = new AOperation();
                }
                return _AOperation;
            }
        }

        public void LoadOperation()
        {
            SQL.AddParam("@from", dtpFrom.Value);
            SQL.AddParam("@to", dtpTo.Value);

            SQL.Query(@"IF OBJECT_ID('tempdb..#Temp_users') IS NOT NULL DROP TABLE #Temp_users
                       SELECT * INTO #Temp_users
                       FROM
                       (
                       SELECT ID, user_name FROM
                       (
                       SELECT adminID as 'ID', user_name as 'user_name' FROM admin_accts
                       UNION ALL
                       SELECT userID, user_name FROM users
                       ) x
                       ) as a;
                       SELECT operationID as 'ID', operation as 'Operation', 
                       isu.name as 'Supplier', 
                       remarks as 'Remarks', total as 'Total_Amount', 
                       qty as 'Qty', date_time as 'Date', 
                       u.user_name as 'Username', 
                       io.supplierID FROM inventory_operation as io
                       INNER JOIN inventory_supplier as isu ON io.supplierID = isu.supplierID INNER JOIN #Temp_users as u ON
                       u.ID = io.userID WHERE 
                       io.date_time BETWEEN @from AND @to");

            if (SQL.HasException(true))
                return;

            dgvOR.DataSource = SQL.DBDT;
            dgvOR.Columns[0].Visible = false;
            dgvOR.Columns[8].Visible = false;
        }

        private void AOperation_Load(object sender, EventArgs e)
        {
            _AOperation = this;
        }
    }
}
