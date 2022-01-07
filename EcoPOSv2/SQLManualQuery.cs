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
    public partial class SQLManualQuery : Form
    {
        public SQLManualQuery()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        private void SQLManualQuery_Load(object sender, EventArgs e)
        {
            SQL.Query(@"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES");

            if (SQL.HasException(true)) return;

            foreach(DataRow dr in SQL.DBDT.Rows)
            {
                lbTables.Items.Add(dr["TABLE_NAME"].ToString());
            }
        }

        private void LbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQL.Query("select * from " + lbTables.SelectedItem.ToString());

            if (SQL.HasException(true)) return;

            dgv.DataSource = SQL.DBDT;
        }

        private void TbQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SQL.Query(tbQuery.Text);
                if (SQL.HasException(true)) return;


                //SQL.Query("select * from " + lbTables.SelectedItem.ToString());
                //if (SQL.HasException(true)) return;

                dgv.DataSource = SQL.DBDT;
            }
        }
    }
}
