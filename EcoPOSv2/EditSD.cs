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
    public partial class EditSD : Form
    {
        public EditSD()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();

        int close_count = 0;

        private void btnSave_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM store_details");

            if (SQL.HasException(true))
                return;

            SQL.AddParam("@business_name", txtName.Text);
            SQL.AddParam("@business_address", txtAddress.Text);
            SQL.AddParam("@business_contact_no", txtContactNo.Text);
            SQL.AddParam("@tax_payer", txtTaxPayer.Text);
            SQL.AddParam("@vat_reg_tin", txtVATRegTin.Text);
            SQL.AddParam("@min", txtMIN.Text);
            SQL.AddParam("@sn", txtSN.Text);
            SQL.AddParam("@an", txtAN.Text);
            SQL.AddParam("@an_date_issued", dtpAN_DateIssued.Value);
            SQL.AddParam("@an_valid_until", dtpAN_ValidUntil.Value);
            SQL.AddParam("@ptu_no", txtPTUNo.Text);
            SQL.AddParam("@ptu_date_issued", dtpPTU_DateIssued.Value);
            SQL.AddParam("@ptu_valid_until", dtpPTU_ValidUntil.Value);

            if (SQL.RecordCount == 0)
            {
                SQL.Query(@"INSERT INTO store_details (business_name, business_address, business_contact_no, tax_payer, vat_reg_tin, min, sn, accreditation_no, 
                           an_date_issued, an_valid_until, ptu_no, pn_date_issued, pn_valid_until) VALUES (@business_name, @business_address, 
                           @business_contact_no, @tax_payer, @vat_reg_tin, @min, @sn, @an, 
                           @an_date_issued, @an_valid_until, @ptu_no, @ptu_date_issued, @ptu_valid_until)");

                if (SQL.HasException(true))
                    return;
            }
            else
            {
                SQL.Query(@"UPDATE store_details SET business_name = @business_name,
                        business_address = @business_address, 
                        business_contact_no = @business_contact_no,
                        tax_payer = @tax_payer,
                        vat_reg_tin = @vat_reg_tin,
                        min = @min,
                        sn = @sn, 
                        accreditation_no = @an,
                        an_date_issued = @an_date_issued,
                        an_valid_until = @an_valid_until,
                        ptu_no = @ptu_no,
                        pn_date_issued = @ptu_date_issued,
                        pn_valid_until = @ptu_valid_until
                        WHERE configuration_ID = (select max(configuration_ID) from store_details)");

                if (SQL.HasException(true))
                    return;
            }

            MessageBox.Show("Store details saved. System will restart after you clicked ok","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //Application.Restart();
            this.Close();
        }

        private void EditSD_Load(object sender, EventArgs e)
        {
            int count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM store_details"));
            if (SQL.HasException(true))
                return;

            if (count_records == 1)
            {
                SQL.Query("SELECT * FROM store_details WHERE configuration_ID = (select max(configuration_ID) from store_details)");
                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)
                {
                    txtName.Text = r["business_name"].ToString();
                    txtAddress.Text = r["business_address"].ToString();
                    txtContactNo.Text = r["business_contact_no"].ToString();
                    txtTaxPayer.Text = r["tax_payer"].ToString();
                    txtVATRegTin.Text = r["vat_reg_tin"].ToString();
                    txtMIN.Text = r["min"].ToString();
                    txtSN.Text = r["sn"].ToString();
                    txtAN.Text = r["accreditation_no"].ToString();
                    dtpAN_DateIssued.Value = DateTime.Parse(r["an_date_issued"].ToString());
                    dtpAN_ValidUntil.Value = DateTime.Parse(r["an_valid_until"].ToString());
                    txtPTUNo.Text = r["ptu_no"].ToString();
                    dtpPTU_DateIssued.Value = DateTime.Parse(r["pn_date_issued"].ToString());
                    dtpPTU_ValidUntil.Value = DateTime.Parse(r["pn_valid_until"].ToString());
                }
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
