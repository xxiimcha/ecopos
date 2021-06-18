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
using EcoPOSv2;

namespace EcoPOSv2
{
    public partial class AddEditWarehouse : Form
    {
        public AddEditWarehouse()
        {
            InitializeComponent();
        }

        SQLControl SQL = new SQLControl();
        List<TextBox> requiredFields = new List<TextBox>();

        public AWarehouse frmAWarehouse;

        public string action;
        public string warehouseID;

        private void WarehouseRF()
        {
            requiredFields = new List<TextBox>();

            requiredFields.Add(txtName);
        }

        private void ClearFields()
        {
            txtName.Clear();
            warehouseID = "";
        }

        public void LoadWarehouse()
        {
            SQL.Query(@"SELECT w.warehouseID, w.name as 'Name', COUNT(p.warehouseID) as 'No. of items' FROM warehouse as w
                       LEFT JOIN products as p ON
                       w.warehouseID = p.warehouseID
                       GROUP BY p.warehouseID,  w.name, w.warehouseID
                       ORDER BY w.name ASC");

            if (SQL.HasException(true))
                return;

            AWarehouse.Instance.dgvWarehouse.DataSource = SQL.DBDT; 
            AWarehouse.Instance.dgvWarehouse.Columns[0].Visible = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "")
            {
                new Notification().PopUp("Please complete all the field(s)", "Error", "error");
            }
            else
            {
                switch (action)
                {
                    case "New":
                        {
                            // check for duplicate names
                            SQL.AddParam("@name", txtName.Text);
                            int result = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM warehouse WHERE name = @name) > 0,'1', '0') as result"));

                            if (SQL.HasException(true))
                                return;

                            if (result == 0)
                            {
                                SQL.AddParam("@name", txtName.Text);

                                SQL.Query("INSERT INTO warehouse (name) VALUES (@name)");
                                if (SQL.HasException(true))
                                    return;


                                ClearFields();
                                //frmAWarehouse.LoadWarehouse(); /////TEMPORARY COMMENT
                                new Notification().PopUp("Item saved", "Success!", "success");
                            }
                            else
                            {
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                                return;
                            }

                            break;
                        }

                    case "Update":
                        {

                            // check for duplicate names other than itself
                            SQL.AddParam("@warehouseID", warehouseID);
                            SQL.AddParam("@name", txtName.Text);

                            string result = SQL.ReturnResult(@"SELECT IIF((
                SELECT COUNT(*) as duplicatecount FROM warehouse WHERE name = @name AND warehouseID <> @warehouseID) > 0,
                1, 0) as result");

                            if (SQL.HasException(true))
                                return;

                            if (result == "0")
                            {
                                SQL.AddParam("@warehouseID", warehouseID);
                                SQL.AddParam("@name", txtName.Text);

                                SQL.Query("UPDATE warehouse SET name = @name WHERE warehouseID = @warehouseID");
                                if (SQL.HasException(true))
                                    return;

                                frmAWarehouse.LoadWarehouse();
                                new Notification().PopUp("Item saved.", "", "information");
                            }
                            else
                            {
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                                return;
                            }

                            break;
                        }

                    default:
                        {
                            new Notification().PopUp("Something went wrong, please try again.", "Error", "error");
                            return;
                        }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
        }

        private void AddEditWarehouse_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtName;
        }
    }
}
