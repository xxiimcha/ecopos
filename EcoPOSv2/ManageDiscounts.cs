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
    public partial class ManageDiscounts : Form
    {
        SQLControl SQL = new SQLControl();
        GroupAction GA = new GroupAction();
        string discountID = "";
        List<TextBox> requiredFields = new List<TextBox>();
        List<Control> allTxt = new List<Control>();

        public ManageDiscounts()
        {
            InitializeComponent();
        }

        private void ManageDiscounts_Load(object sender, EventArgs e)
        {
            LoadDiscounts();
            ControlBehavior();

            TextBoxValidation.AssignValidation(ref txtAmount, ValidationType.Price);
            TextBoxValidation.AssignValidation(ref txtAmount, ValidationType.Int_Only);
        }
        private void ControlBehavior()
        {
            Control c = (Control)txtSearch;
            SetBehavior(ref c, Behavior.ClearSearch);
        }


        private void LoadDiscounts()
        {
            SQL.Query("SELECT discountID, disc_name FROM discount ORDER BY disc_name ASC");
            if (SQL.HasException(true))
                return;
            dgvDiscount.DataSource = SQL.DBDT;
            dgvDiscount.Columns[0].Visible = false;
        }

        private void DiscountRF()
        {
            requiredFields = new List<TextBox>();

            requiredFields.Add(txtName);
            requiredFields.Add(txtAmount);
        }

        private void ClearFields()
        {
            discountID = "";
            GA.DoThis(ref allTxt, TableLayoutPanel1, ControlType.TextBox, GroupAction.Action.Clear);
        }

        private void BtnProduct_Delete_Click(object sender, EventArgs e)
        {
            DialogResult approval = MessageBox.Show("Delete this item?", "", MessageBoxButtons.YesNo);
            if (approval == DialogResult.Yes)
            {
                if (discountID == "")
                {
                    new Notification().PopUp("No item selected.", "","error");
                    return;
                }

                SQL.AddParam("@discountID", discountID);
                SQL.Query("DELETE FROM discount WHERE discountID = @discountID");
                if (SQL.HasException(true))
                    return;
                LoadDiscounts();
                ClearFields();
                new Notification().PopUp("Item Deleted", "", "success");
            }
        }

        private void BtnProduct_Save_Click(object sender, EventArgs e)
        {
            DiscountRF();
            int requiredFieldsMet = RequireField(ref requiredFields);

            if (requiredFieldsMet == 1)
            {
                string action = "Update";
                int disc_type = 0;
                if (discountID == "")
                    action = "New";


                if (rbAmount.Checked)
                    disc_type = 1;
                else if (rbPercentage.Checked)
                    disc_type = 2;



                switch (action)
                {
                    case "New":
                        {
                            // check for duplicate names
                            SQL.AddParam("@disc_name", txtName.Text);
                            int result = Convert.ToInt32(SQL.ReturnResult("SELECT IIF((SELECT COUNT(*) FROM discount WHERE disc_name = @disc_name) > 0,'1', '0') as result"));

                            if (SQL.HasException(true))
                                return;

                            if (result == 0)
                            {
                                SQL.AddParam("@disc_name", txtName.Text);
                                SQL.AddParam("@disc_amt", txtAmount.Text);
                                SQL.AddParam("@disc_type", disc_type);

                                SQL.Query("INSERT INTO discount (disc_name, disc_amt, disc_type) VALUES (@disc_name, @disc_amt, @disc_type)");

                                if (SQL.HasException(true))
                                    return;
                                ClearFields();
                                new Notification().PopUp("Data saved.", "", "success");
                            }
                            else

                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }

                    default:
                        {
                            SQL.AddParam("@discountID", discountID);
                            SQL.AddParam("@disc_name", txtName.Text);

                            string result = SQL.ReturnResult(@"SELECT IIF((
                SELECT COUNT(*) as duplicatecount FROM discount WHERE disc_name = @disc_name AND discountID <> @discountID) > 0,
                1, 0) as result");

                            if (SQL.HasException(true))
                                return;


                            if (result == "0")
                            {
                                SQL.AddParam("@discountID", discountID);
                                SQL.AddParam("@disc_name", txtName.Text);
                                SQL.AddParam("@disc_amt", txtAmount.Text);
                                SQL.AddParam("@disc_type", disc_type);

                                SQL.Query(@"UPDATE discount SET disc_name = @disc_name, disc_amt = @disc_amt, 
                                       disc_type = @disc_type WHERE discountID = @discountID");

                                if (SQL.HasException(true))
                                    return;


                                new Notification().PopUp("Data saved.", "", "success");
                            }
                            else
                                new Notification().PopUp("Duplicate name found.", "Save failed", "error");
                            break;
                        }
                }

                LoadDiscounts();
            }
            else
                new Notification().PopUp("Please fill all required fields.", "Save failed", "error");
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            if (dgvDiscount.RowCount == 0)
                return;

            if (btnSort.IconChar == IconChar.SortAlphaDown)
            {
                dgvDiscount.Sort(dgvDiscount.Columns[1], ListSortDirection.Ascending);
                btnSort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvDiscount.Sort(dgvDiscount.Columns[1], ListSortDirection.Descending);
                btnSort.IconChar = IconChar.SortAlphaDown;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text == "")
                LoadDiscounts();
            else
            {
                SQL.AddParam("@find", txtSearch.Text + "%");

                SQL.Query("SELECT discountID, disc_name FROM discount WHERE disc_name LIKE @find ORDER BY disc_name ASC");

                if (SQL.HasException(true))
                    return;

                dgvDiscount.DataSource = SQL.DBDT;
                dgvDiscount.Columns[0].Visible = false;
            }
        }

        private void dgvDiscount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@discountID", dgvDiscount.CurrentRow.Cells[0].Value.ToString());

            SQL.Query("SELECT * FROM discount WHERE discountID = @discountID");
            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                discountID = r["discountID"].ToString();
                txtName.Text = r["disc_name"].ToString();
                txtAmount.Text = r["disc_amt"].ToString();

                if (Convert.ToInt32(r["disc_type"].ToString()) == 1)
                    rbAmount.Checked = true;
                else
                    rbPercentage.Checked = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
