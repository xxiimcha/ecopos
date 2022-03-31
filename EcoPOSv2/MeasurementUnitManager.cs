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
    public partial class MeasurementUnitManager : Form
    {
        SQLControl SQL = new SQLControl();

        public MeasurementUnitManager()
        {
            InitializeComponent();
        }

        private void MeasurementUnitManager_Load(object sender, EventArgs e)
        {
            loadUnit();
            clearUnit();
        }

        //UNIT
        string unit_id = "";
        private void btnUnitSave_Click(object sender, EventArgs e)
        {
            if (txtUnitName.Text == "")
            {
                return;
            }

            if (unit_id == "")
            {
                SQL.AddParam("@name", txtUnitName.Text);
                SQL.Query("SELECT * FROM units WHERE unit_name = @name");
                if (SQL.DBDT.Rows.Count > 0)
                {
                    new Notification().PopUp("Name already exists.", "", "error");
                    return;
                }

                SQL.AddParam("@name", txtUnitName.Text);
                SQL.AddParam("@isDecimal", radioUnitYes.Checked);
                SQL.Query("INSERT INTO units(unit_name,isDecimal) VALUES(@name, @isDecimal)");
                if (SQL.HasException(true))
                    return;
                new Notification().PopUp("Unit Added.", "", "success");
            }
            else
            {
                if (int.Parse(unit_id) <= 2)
                {
                    new Notification().PopUp("Unit Cannot be Edited.", "", "error");
                    clearUnit();
                    return;
                }

                SQL.AddParam("@unit_id", unit_id);
                SQL.AddParam("@name", txtUnitName.Text);
                SQL.AddParam("@isDecimal", radioUnitYes.Checked);
                SQL.Query("UPDATE units SET unit_name = @name, isDecimal = @isDecimal WHERE unit_id = @unit_id");
                if (SQL.HasException(true))
                    return;
                new Notification().PopUp("Unit saved.", "", "success");
            }

            clearUnit();
            loadUnit();
        }

        private void btnUnitNew_Click(object sender, EventArgs e)
        {
            clearUnit();
            radioUnitNo.Select();
            txtUnitName.Focus();
        }

        private void txtUnitName_TextChanged(object sender, EventArgs e)
        {
            char[] originalText = txtUnitName.Text.ToCharArray();
            foreach (char c in originalText)
            {
                if ((Char.IsNumber(c)))
                {
                    txtUnitName.Text = txtUnitName.Text.Remove(txtUnitName.Text.IndexOf(c));
                }
            }
            txtUnitName.Select(txtUnitName.Text.Length, 0);
        }

        private void dgvUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            unit_id = dgvUnit.SelectedRows[0].Cells[0].Value.ToString();
            txtUnitName.Text = dgvUnit.SelectedRows[0].Cells[1].Value.ToString();
            if (dgvUnit.SelectedRows[0].Cells[2].Value.ToString() == "True")
            {
                radioUnitYes.Select();
            }
            else
            {
                radioUnitNo.Select();
            }
        }

        private void btnUnitDelete_Click(object sender, EventArgs e)
        {
            if (unit_id == "")
            {
                new Notification().PopUp("No item selected.", "", "error");
                clearUnit();
                return;
            }

            if (int.Parse(unit_id) <= 2)
            {
                new Notification().PopUp("Unit Cannot be Deleted.", "", "error");
                clearUnit();
                return;
            }

            SQL.AddParam("@unit_id", unit_id);
            SQL.Query("DELETE FROM units WHERE unit_id = @unit_id");
            if (SQL.HasException(true))
                return;
            new Notification().PopUp("Unit Deleted.", "", "success");
            clearUnit();
            loadUnit();
        }

        private void clearUnit()
        {
            unit_id = "";
            txtUnitName.Text = "";
            radioUnitNo.Select();
        }

        private void loadUnit()
        {
            SQL.Query("SELECT unit_id, unit_name as 'UNIT NAME', isDecimal from units");
            if (SQL.HasException(true))
                return;

            dgvUnit.DataSource = SQL.DBDT;

            dgvUnit.Columns[0].Visible = false;
            dgvUnit.Columns[2].Visible = false;
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
