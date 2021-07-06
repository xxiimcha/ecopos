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
                SQL.Query("INSERT INTO receipt_layout (receipt_footer_text) VALUES (@receipt_footer_text)");

                if (SQL.HasException(true))
                    return;
            }
            else
                return;

            new Notification().PopUp("Data saved.","Success","information");
            Main.Instance.rl_footer_text = txtReceiptFooter.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
