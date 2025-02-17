﻿using EcoPOSControl;
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
    public partial class AdjustCost : Form
    {
        public AdjustCost()
        {
            InitializeComponent();
        }

        private SQLControl SQL = new SQLControl();
        public AOperation frmAOperation;
        public string operationID = "";
        public string supplierID;

        private List<TextBox> requiredFields = new List<TextBox>();


        private void AdjustCost_Load(object sender, EventArgs e)
        {
            TextBoxValidation.AssignValidation(ref txtNewCost, ValidationType.Only_Numbers);
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtNewCost.Text == "" || txtRemarks.Text == "")
            {
                SQL.AddParam("@operationID", operationID);
                SQL.AddParam("@total", txtNewCost.Text);

                SQL.Query("UPDATE inventory_operation SET total = @total WHERE operationID = @operationID");

                if (SQL.HasException(true))
                {
                    new Notification().PopUp("Something went wrong.", "Error", "error");
                    return;
                }

                // save to inventory_operation

                SQL.AddParam("@supplierID", supplierID);
                SQL.AddParam("@remarks", txtRemarks.Text);
                SQL.AddParam("@total", txtNewCost.Text);
                SQL.AddParam("@userID", Main.Instance.current_id);

                SQL.Query(@"INSERT INTO inventory_operation (operation, qty, total, supplierID, remarks, date_time, userID) 
                           VALUES ('Adjust Cost', 0, @total, @supplierID, @remarks, (SELECT GETDATE()), @userID)");

                if (SQL.HasException(true))
                {
                    new Notification().PopUp("Error", "Something went wrong.");
                    return;
                }


                AOperation.Instance.LoadOperation();
                frmAOperation.LoadOperation();
            }
            else
            {
                new Notification().PopUp("Please fill all required fields.", "", "error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
