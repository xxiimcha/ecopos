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
    public partial class MemberCardPointsAdder : Form
    {
        public MemberCardPointsAdder()
        {
            InitializeComponent();
        }

        private SQLControl SQL = new SQLControl();

        public String memberName;
        public String memberCard;
        public String currentPoints;

        private void MemberCardPointsAdder_Load(object sender, EventArgs e)
        {
            lblMember.Text = memberName + " (" + memberCard + ")";
            lblCurrentPoints.Text = currentPoints;
        }

        DateTime dtnow;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPoints.Text == "" || txtPoints.Text == null)
            {

                return;
            }

            //Updates the card's balance
            SQL.AddParam("@points", Decimal.Parse(txtPoints.Text));
            SQL.AddParam("@card_no", memberCard);
            SQL.Query("UPDATE member_card SET card_balance = card_balance + @points WHERE card_no = @card_no");
            if (SQL.HasException(true))
            {
                return;
            }

            dtnow = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss"));
            String user_id = Main.Instance.by_pass_user ? Main.Instance.by_pass_userID.ToString() : Main.Instance.current_id;

            //Add to topup transaction
            SQL.AddParam("@points", Decimal.Parse(txtPoints.Text));
            SQL.AddParam("@card_no", memberCard);
            SQL.AddParam("@currentPoints", Decimal.Parse(currentPoints));
            SQL.AddParam("@date_time", dtnow);
            SQL.AddParam("@terminal_id", Properties.Settings.Default.Terminal_id);
            SQL.AddParam("@cashierID", user_id);
            SQL.AddParam("@payment_by", txtPaymentby.Text);
            SQL.Query("INSERT INTO topup_transaction(topup_cardNo, topup_cusID, topup_amount, topup_beggining_amount, topup_ending_amount, topup_datetime, terminal_id, cashierID, payment_by) " +
                "VALUES(@card_no, (SELECT customerID FROM member_card WHERE card_no = @card_no), @points, @currentPoints, (@currentPoints + @points), @date_time, @terminal_id, @cashierID, @payment_by)");
            if (SQL.HasException(true))
            {
                return;
            }
            else
            {
                new Notification().PopUp("Points Added", "", "success");
                PrintPointsAddedReceipt();
                Close();
            }
        }

        TopupReceipt58 topupreport58 = new TopupReceipt58();
        TopupReceipt80 topupreport80 = new TopupReceipt80();
        private void PrintPointsAddedReceipt()
        {
            string invoice_no = SQL.ReturnResult("SELECT TOP 1 topupID FROM topup_transaction ORDER BY topupID DESC");

            if(Properties.Settings.Default.papersize == "58MM")
            {
                topupreport58 = new TopupReceipt58();
                topupreport58.SetParameterValue("invoice_no", invoice_no);
                topupreport58.SetParameterValue("date_time", dtnow);
                topupreport58.SetParameterValue("user_first_name", Main.Instance.lblUser.Text);
                topupreport58.SetParameterValue("Terminal_no", Properties.Settings.Default.Terminal_id);
                topupreport58.SetParameterValue("member_name", memberName);
                topupreport58.SetParameterValue("card_no", memberCard);
                topupreport58.SetParameterValue("paid_by", txtPaymentby.Text);
                topupreport58.SetParameterValue("total", Decimal.Parse(txtPoints.Text));
                topupreport58.SetParameterValue("beggining_points", Decimal.Parse(currentPoints));
                topupreport58.SetParameterValue("final_points", Decimal.Parse(currentPoints) + Decimal.Parse(txtPoints.Text));

                topupreport58.SetParameterValue("business_name", Main.Instance.sd_business_name);
                topupreport58.SetParameterValue("business_address", Main.Instance.sd_business_address);
                topupreport58.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);

                try
                {
                    topupreport58.PrintOptions.NoPrinter = false;
                    topupreport58.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                    topupreport58.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                    topupreport58.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    topupreport58.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception)
                {
                    topupreport58.PrintOptions.NoPrinter = false;
                    topupreport58.PrintOptions.PrinterName = "Microsoft Print to PDF";
                    topupreport58.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                    topupreport58.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    topupreport58.PrintToPrinter(0, false, 0, 0);
                }
            }
            else
            {
                topupreport80 = new TopupReceipt80();
                topupreport80.SetParameterValue("invoice_no", invoice_no);
                topupreport80.SetParameterValue("date_time", dtnow);
                topupreport80.SetParameterValue("user_first_name", Main.Instance.lblUser.Text);
                topupreport80.SetParameterValue("Terminal_no", Properties.Settings.Default.Terminal_id);
                topupreport80.SetParameterValue("member_name", memberName);
                topupreport80.SetParameterValue("card_no", memberCard);
                topupreport80.SetParameterValue("paid_by", txtPaymentby.Text);
                topupreport80.SetParameterValue("total", Decimal.Parse(txtPoints.Text));
                topupreport80.SetParameterValue("beggining_points", Decimal.Parse(currentPoints));
                topupreport80.SetParameterValue("final_points", Decimal.Parse(currentPoints) + Decimal.Parse(txtPoints.Text));

                topupreport80.SetParameterValue("business_name", Main.Instance.sd_business_name);
                topupreport80.SetParameterValue("business_address", Main.Instance.sd_business_address);
                topupreport80.SetParameterValue("business_contact_no", Main.Instance.sd_business_contact_no);

                try
                {
                    topupreport80.PrintOptions.NoPrinter = false;
                    topupreport80.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                    topupreport80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                    topupreport80.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    topupreport80.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception)
                {
                    topupreport80.PrintOptions.NoPrinter = false;
                    topupreport80.PrintOptions.PrinterName = "Microsoft Print to PDF";
                    topupreport80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                    topupreport80.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    topupreport80.PrintToPrinter(0, false, 0, 0);
                }
            }
        }

        private void txtPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow number input
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as Guna.UI2.WinForms.Guna2TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPoints_KeyUp(object sender, KeyEventArgs e)
        {
            string[] wholenumber = txtPoints.Text.Split('.');
            if (wholenumber[0].Length < 10)
            {
                decimal points = txtPoints.Text != "" && txtPoints.Text != "." ? Convert.ToDecimal(txtPoints.Text) : 0;
                lblPointsAfter.Text = (Decimal.Parse(currentPoints) + points).ToString("N2");
                lblPointsAfter.ForeColor = Color.Black;
            }
            else
            {
                lblPointsAfter.Text = "Quantity is too high";
                lblPointsAfter.ForeColor = Color.Red;
            }
        }

        private void txtPaymentby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }
    }
}
