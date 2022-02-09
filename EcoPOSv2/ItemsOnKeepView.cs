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
            dgvKeep.Rows.Clear();
            SQL.Query("SELECT DISTINCT note ,total ,dateTime FROM keep");
            if (SQL.HasException(true)) return;
            foreach (DataRow dr in SQL.DBDT.Rows)
            {
                dgvKeep.Rows.Add(dr["note"].ToString(), Convert.ToDouble(dr["total"].ToString()), dr["dateTime"].ToString());
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
            foreach (DataGridViewRow row in dgvKeep.SelectedRows)
            {
                name = row.Cells[0].Value.ToString();
            }
            new OptionConfirmation(name, "PAY", "DELETE").ShowDialog();
            LoadItemsOnKeep();
        }

        private void ItemsOnKeepView_Load(object sender, EventArgs e)
        {
            _itemsOnKeep = this;
        }

        private void dgvKeep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvKeep.SelectedRows.Count == 1)
            {
                ShowOptions();
            }
        }
    }
}
