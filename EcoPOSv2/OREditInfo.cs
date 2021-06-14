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
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class OREditInfo : Form
    {
        private SQLControl SQL = new SQLControl();
        public AOperation frmAOperation;
        public string operationID;
        public OREditInfo()
        {
            InitializeComponent();
        }

        private void OREditInfo_Load(object sender, EventArgs e)
        {
            AssignValidation(ref txtTotal, ValidationType.Price);
            AssignValidation(ref txtTotal, ValidationType.Only_Numbers);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            SQL.AddParam("operationID", operationID);
            SQL.AddParam("remarks", txtRemarks.Text);
            SQL.AddParam("total", txtTotal.Text);
            SQL.Query(@"UPDATE inventory_operation SET remarks = @remarks, total = @total
                       WHERE operationID = @operationID");
            if (SQL.HasException(true))
            {
                new Notification().PopUp("Something went wrong.", "","error");
                return;
            }

            frmAOperation.LoadOperation();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
