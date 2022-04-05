using EcoPOSControl;
using FontAwesome.Sharp;
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
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class ASupplier : Form
    {
        public ASupplier()
        {
            InitializeComponent();
        }

        private SQLControl SQL = new SQLControl();
        private GroupAction GA = new GroupAction();

        private string supplierID = "";
        private List<Control> allTxt = new List<Control>();
        private List<TextBox> requiredFields = new List<TextBox>();

        //METHODS
        private void LoadSupplier()
        {
            SQL.Query("SELECT supplierID, name FROM inventory_supplier ORDER BY name ASC");

            if (SQL.HasException(true))
                return;

            dgvSupplier.DataSource = SQL.DBDT;
            dgvSupplier.Columns[0].Visible = false;
        }
        private void ClearFields()
        {
            GA.DoThis(ref allTxt, guna2Panel1, ControlType.TextBox, GroupAction.Action.Clear);
            supplierID = "";
        }
        private void TextValidation()
        {
            AssignValidation(ref txtContactNo, ValidationType.Only_Numbers);
        }
        private void ControlBehavior()
        {
            Control c = (Control)txtSearch;
            SetBehavior(ref c, Behavior.ClearSearch);
        }
        private void SupplierRF()
        {
            requiredFields = new List<TextBox>();

            requiredFields.Add(txtSupplierName);
            requiredFields.Add(txtAddress);
            requiredFields.Add(txtContactNo);
            requiredFields.Add(txtContactPerson);
            requiredFields.Add(txtContactPersonNo);
        }

        //METHODS
        private void ASupplier_Load(object sender, EventArgs e)
        {
            LoadSupplier();
            TextValidation();
            ControlBehavior();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            btnDelete.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SupplierRF();
            int requiredFieldsMet = RequireField(ref requiredFields);


            if (requiredFieldsMet == 1)
            {
                string action = "Update";
                if (supplierID == "")
                    action = "New";



                switch (action)
                {
                    case "New":
                        {
                            // check for duplicate names
                            SQL.AddParam("@name", txtSupplierName.Text);
                            int result = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM inventory_supplier WHERE name = @name) > 0,'1', '0') as result"));

                            if (SQL.HasException(true))
                                return;

                            if (result == 0)
                            {
                                SQL.AddParam("@name", txtSupplierName.Text);
                                SQL.AddParam("@address", txtAddress.Text);
                                SQL.AddParam("@contact_no", txtContactNo.Text);
                                SQL.AddParam("@contact_person", txtContactPerson.Text);
                                SQL.AddParam("@contact_person_no", txtContactPersonNo.Text);

                                SQL.Query(@"INSERT INTO inventory_supplier (name, address, contact_no, contact_person, contact_person_no) 
                                      VALUES (@name, @address, @contact_no, @contact_person, @contact_person_no)");

                                if (SQL.HasException(true))
                                    return;
                                ClearFields();
                                new Notification().PopUp("Data saved.", "", "information");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }

                    default:
                        {
                            SQL.AddParam("@supplierID", supplierID);
                            SQL.AddParam("@name", txtSupplierName.Text);

                            string result = SQL.ReturnResult(@"SELECT IIF((
                SELECT COUNT(*) as duplicatecount FROM inventory_supplier WHERE name = @name AND supplierID <> @supplierID) > 0,
                1, 0) as result");

                            if (SQL.HasException(true))
                                return;

                            if (result == "0")
                            {
                                SQL.AddParam("@supplierID", supplierID);
                                SQL.AddParam("@name", txtSupplierName.Text);
                                SQL.AddParam("@address", txtAddress.Text);
                                SQL.AddParam("@contact_no", txtContactNo.Text);
                                SQL.AddParam("@contact_person", txtContactPerson.Text);
                                SQL.AddParam("@contact_person_no", txtContactPersonNo.Text);

                                SQL.Query(@"UPDATE inventory_supplier SET name = @name, address = @address, contact_no = @contact_no, 
                                  contact_person = @contact_person, contact_person_no = @contact_person_no
                                  WHERE supplierID = @supplierID");

                                if (SQL.HasException(true))
                                    return;

                                new Notification().PopUp("Data saved.", "", "information");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }
                }
                LoadSupplier();

                btnDelete.Enabled = true;
            }
            else
                new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult approval = MessageBox.Show("Delete this item?", "", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (approval == DialogResult.Yes)
            {
                if (supplierID == "")
                {
                    new Notification().PopUp("No item selected.", "", "error");
                    return;
                }

                SQL.AddParam("@supplierID", supplierID);
                SQL.Query("DELETE FROM inventory_supplier WHERE supplierID = @supplierID");

                if (SQL.HasException(true))
                    return;

                LoadSupplier();

                ClearFields();

                new Notification().PopUp("Item deleted.", "", "information");
            }
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@supplierID", dgvSupplier.CurrentRow.Cells[0].Value.ToString());

            SQL.Query("SELECT * FROM inventory_supplier WHERE supplierID = @supplierID");
            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                supplierID = r["supplierID"].ToString();
                txtSupplierName.Text = r["name"].ToString();
                txtAddress.Text = r["address"].ToString();
                txtContactNo.Text = r["contact_no"].ToString();
                txtContactPerson.Text = r["contact_person"].ToString();
                txtContactPersonNo.Text = r["contact_person_no"].ToString();
            }


            SQL.AddParam("@SupplierID", supplierID);
            int count = Convert.ToInt32(SQL.ReturnResult("SELECT count(*) from inventory_operation where supplierID=@SupplierID"));
            if (SQL.HasException(true)) return;

            if(count > 0)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.RowCount == 0)
                return;

            if (btnSort.IconChar == IconChar.SortAlphaDown)
            {
                dgvSupplier.Sort(dgvSupplier.Columns[1], ListSortDirection.Ascending);
                btnSort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvSupplier.Sort(dgvSupplier.Columns[1], ListSortDirection.Descending);
                btnSort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text == "")
                LoadSupplier();
            else
            {
                SQL.AddParam("@find", txtSearch.Text + "%");

                SQL.Query("SELECT supplierID, name FROM inventory_supplier WHERE name LIKE @find ORDER BY name ASC");
                if (SQL.HasException(true))
                    return;

                dgvSupplier.DataSource = SQL.DBDT;
                dgvSupplier.Columns[0].Visible = false;
            }
        }
    }
}
