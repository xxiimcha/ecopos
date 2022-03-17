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
    public partial class ItemsOnKeepView : Form
    {
        SQLControl SQL = new SQLControl();

        public static ItemsOnKeepView _itemsOnKeep;
        public static ItemsOnKeepView Instance
        {
            get
            {
                if (_itemsOnKeep == null)
                {
                    _itemsOnKeep = new ItemsOnKeepView();
                }
                return _itemsOnKeep;
            }
        }

        public ItemsOnKeepView()
        {
            InitializeComponent();
            LoadItemsOnKeep();
        }

        public void LoadItemsOnKeep()
        {
            dgvRecords.Rows.Clear();
            if (txtSearch.Text == "")
            {
                SQL.Query(@"SELECT DISTINCT note, total, dateTime from keep");
                if (SQL.HasException(true))
                    return;
            }
            else
            {
                SQL.AddParam("@find", "%" + txtSearch.Text + "%");
                SQL.Query(@"SELECT DISTINCT note, total, dateTime from keep
                       WHERE note LIKE @find ORDER BY note DESC");
                if (SQL.HasException(true))
                    return;
            }
            
            foreach (DataRow dr in SQL.DBDT.Rows)
            {
                dgvRecords.Rows.Add(dr["note"].ToString(), dr["total"].ToString(), dr["dateTime"].ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void dgvKeep_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowOptions();
        }

        private void ShowOptions()
        {
            String name = "";
            if(dgvRecords.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in dgvRecords.SelectedRows)
                {
                    name = row.Cells[0].Value.ToString();
                }
                new OptionConfirmation(name, "PAY", "DELETE").ShowDialog();
            }
        }

        private void ItemsOnKeepView_Load(object sender, EventArgs e)
        {
            _itemsOnKeep = this;

            this.ActiveControl = txtSearch;
        }

        private void dgvKeep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvRecords.SelectedRows.Count == 1)
            {
                ShowOptions();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadItemsOnKeep();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvRecords.SelectedRows.Count == 1)
            {
                ShowOptions();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void ItemsOnKeepView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
