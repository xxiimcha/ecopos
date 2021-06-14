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
    public partial class RedeemSettings : Form
    {
        public RedeemSettings()
        {
            InitializeComponent();
        }
        private FormLoad OL = new FormLoad();
        private SQLControl SQL = new SQLControl();
        private GroupAction GA = new GroupAction();
        private ExportImport EI = new ExportImport();

        private Panel currentPanel;
        private Button currentBtn;

        private string giftcardID = "";
        private string redeemID = "";

        private bool dgvRT_ClickedOnce = false;

        private RedeemTransactionReport report = new RedeemTransactionReport();
        private RedeemReceipt reprint_receipt = new RedeemReceipt();

        private List<Control> allTxt = new List<Control>();
        private List<TextBox> requiredFields = new List<TextBox>();

        //METHODS
        private void GCRF()
        {
            requiredFields = new List<TextBox>();

            requiredFields.Add(txtGC_GCNo);
            requiredFields.Add(txtGC_Amount);
        }

        private void ClearFields_GC()
        {
            GA.DoThis(ref allTxt, TableLayoutPanel8, ControlType.TextBox, GroupAction.Action.Clear);
            lblGC_Status.Text = "";
            giftcardID = "";
        }

        private void LoadGC()
        {
            SQL.Query("SELECT giftcardID, giftcard_no as 'GC No.' FROM giftcard ORDER BY giftcard_no ASC");

            if (SQL.HasException(true))
                return;

            dgvGC.DataSource = SQL.DBDT;
            dgvGC.Columns[0].Visible = false;
        }

        private void ControlBehavior()
        {
            Control gc = new Control();
            gc = txtGC_Search as Control;

            Control si = new Control();
            si = txtRI_SearchItem as Control;

            Control ri = new Control();
            ri = txtRI_SearchRedeem as Control;
            SetBehavior(ref gc, Behavior.ClearSearch);
            SetBehavior(ref si, Behavior.ClearSearch);
            SetBehavior(ref ri, Behavior.ClearSearch);
        }

        private void TextBoxValidation()
        {
            AssignValidation(ref txtRI_Points, ValidationType.Price);
            AssignValidation(ref txtRI_Points, ValidationType.Int_Only);
            AssignValidation(ref txtGC_Amount, ValidationType.Price);
            AssignValidation(ref txtGC_Amount, ValidationType.Int_Only);
            AssignValidation(ref txtGC_GCNo, ValidationType.Int_Only);
        }

        //METHODS

        private void RedeemSettings_Load(object sender, EventArgs e)
        {
            currentPanel = pnlRI;
            currentBtn = btnRI;

            TextBoxValidation();
            ControlBehavior();
            LoadGC();
            LoadRICategory();
            LoadRedeemItems();


            // awarded points transaction
            LoadAPT_Customers();
            dtpAPT_From.Value = DateTime.Parse(string.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 00:00:01"));
            dtpAPT_To.Value = DateTime.Parse(string.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 23:59:59"));
            cmbAPT_Customer.SelectedIndex = 0;

            // redeem transaction
            LoadRT_Customers();
            dtpRT_From.Value = DateTime.Parse(string.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 00:00:01"));
            dtpRT_To.Value = DateTime.Parse(string.Format(DateTime.Now.ToString(), "MMMM dd, yyyy 23:59:59"));
            cmbRT_Customer.SelectedIndex = 0;
        }

        private void btnRT_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlRT, ref currentPanel, btnRT, ref currentBtn);
        }

        private void btnRI_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlRI, ref currentPanel, btnRI, ref currentBtn);
        }

        private void btnAPT_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlAPT, ref currentPanel, btnAPT, ref currentBtn);
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            OL.changePanel(pnlGC, ref currentPanel, btnGC, ref currentBtn);
        }

        private void dgvGC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            SQL.AddParam("@giftcardID", dgvGC.CurrentRow.Cells[0].Value.ToString());

            SQL.Query("SELECT * FROM giftcard WHERE giftcardID = @giftcardID");

            if (SQL.HasException(true))
                return;

            foreach (DataRow r in SQL.DBDT.Rows)
            {
                giftcardID = r["giftcardID"].ToString();
                txtGC_GCNo.Text = r["giftcard_no"].ToString();
                txtGC_Amount.Text = r["amount"].ToString();
                lblGC_Status.Text = r["status"].ToString();
                dtpGC_Expiration.Value = DateTime.Parse(r["expiration"].ToString());
            }
        }

        private void btnGC_Sort_Click(object sender, EventArgs e)
        {
            if (dgvGC.RowCount == 0)
                return;

            if (btnGC_Sort.IconChar == IconChar.SortAlphaDown)
            {
                dgvGC.Sort(dgvGC.Columns[1], ListSortDirection.Ascending);
                btnGC_Sort.IconChar = IconChar.SortAlphaUp;
            }
            else
            {
                dgvGC.Sort(dgvGC.Columns[1], ListSortDirection.Descending);
                btnGC_Sort.IconChar = IconChar.SortAlphaDown;
            }
        }
    }
}
