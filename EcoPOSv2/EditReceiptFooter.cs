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
    public partial class EditReceiptFooter : Form
    {
        public EditReceiptFooter()
        {
            InitializeComponent();
        }

        SQLControl SQL = new SQLControl();

        private void EditReceiptFooter_Load(object sender, EventArgs e)
        {
            cmbTitleText.Text = Properties.Settings.Default.TitleTextFont;
            cmbRegularText.Text = Properties.Settings.Default.RegularTextFont;
            cmbTransactionText.Text = Properties.Settings.Default.TransactionDetailsFont;
            cmbBusinessDetails.Text = Properties.Settings.Default.BusinessDetailsFont;
            cmbProducts.Text = Properties.Settings.Default.ProductListFont;

            int count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM receipt_layout"));
            if (SQL.HasException(true))
                return;

            if (count_records == 1)
            {
                SQL.Query("SELECT * FROM receipt_layout");

                if (SQL.HasException(true))
                    return;

                foreach (DataRow r in SQL.DBDT.Rows)

                    txtReceiptFooter.Text = r["receipt_footer_text"].ToString();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TitleTextFont = cmbTitleText.Text;
            Properties.Settings.Default.RegularTextFont = cmbRegularText.Text;
            Properties.Settings.Default.TransactionDetailsFont = cmbTransactionText.Text;
            Properties.Settings.Default.BusinessDetailsFont = cmbBusinessDetails.Text;
            Properties.Settings.Default.ProductListFont = cmbProducts.Text;
            Properties.Settings.Default.Save();

            int count_records = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM receipt_layout"));
            if (SQL.HasException(true))
                return;

            SQL.AddParam("@receipt_footer_text", txtReceiptFooter.Text);

            if (count_records == 1)
            {
                SQL.Query("UPDATE receipt_layout SET receipt_footer_text = @receipt_footer_text WHERE configuration_ID = 1");

                if (SQL.HasException(true))
                    return;
            }
            else if (count_records == 0)
            {
                SQL.Query("INSERT INTO receipt_layout (configuration_ID, receipt_footer_text, number_of_copies) VALUES (1, @receipt_footer_text, 1)");

                if (SQL.HasException(true))
                    return;
            }
            else
                return;

            new Notification().PopUp("Data saved.","Success","information");
            Main.Instance.sd_footer_text = txtReceiptFooter.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
