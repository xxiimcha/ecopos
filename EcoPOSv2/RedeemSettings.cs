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
    }
}
