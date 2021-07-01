
namespace EcoPOSv2
{
    partial class Devices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Devices));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTestDisplay = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnSaveSettings = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnCancel = new Guna.UI2.WinForms.Guna2TileButton();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbReportPrinter = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.cbxEnable_CD = new System.Windows.Forms.CheckBox();
            this.cmbReceiptPrinter = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSaveSettings);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.Label4);
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.cmbPort);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.cmbReportPrinter);
            this.panel1.Controls.Add(this.Label8);
            this.panel1.Controls.Add(this.cbxEnable_CD);
            this.panel1.Controls.Add(this.cmbReceiptPrinter);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 637);
            this.panel1.TabIndex = 0;
            // 
            // btnTestDisplay
            // 
            this.btnTestDisplay.BackColor = System.Drawing.Color.Transparent;
            this.btnTestDisplay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTestDisplay.BorderRadius = 5;
            this.btnTestDisplay.BorderThickness = 1;
            this.btnTestDisplay.CheckedState.Parent = this.btnTestDisplay;
            this.btnTestDisplay.CustomImages.Parent = this.btnTestDisplay;
            this.btnTestDisplay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(96)))), ((int)(((byte)(25)))));
            this.btnTestDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestDisplay.ForeColor = System.Drawing.Color.White;
            this.btnTestDisplay.HoverState.Parent = this.btnTestDisplay;
            this.btnTestDisplay.Location = new System.Drawing.Point(3, 410);
            this.btnTestDisplay.Name = "btnTestDisplay";
            this.btnTestDisplay.ShadowDecoration.Parent = this.btnTestDisplay;
            this.btnTestDisplay.Size = new System.Drawing.Size(209, 45);
            this.btnTestDisplay.TabIndex = 80;
            this.btnTestDisplay.Text = "TEST DISPLAY";
            this.btnTestDisplay.Click += new System.EventHandler(this.BtnTestDisplay_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSaveSettings.BorderRadius = 5;
            this.btnSaveSettings.BorderThickness = 1;
            this.btnSaveSettings.CheckedState.Parent = this.btnSaveSettings;
            this.btnSaveSettings.CustomImages.Parent = this.btnSaveSettings;
            this.btnSaveSettings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(96)))), ((int)(((byte)(25)))));
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.HoverState.Parent = this.btnSaveSettings;
            this.btnSaveSettings.Location = new System.Drawing.Point(62, 556);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.ShadowDecoration.Parent = this.btnSaveSettings;
            this.btnSaveSettings.Size = new System.Drawing.Size(209, 45);
            this.btnSaveSettings.TabIndex = 79;
            this.btnSaveSettings.Text = "SAVE SETTINGS";
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.IndianRed;
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(334, 556);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(209, 45);
            this.btnCancel.TabIndex = 78;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(214, 334);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(360, 182);
            this.Label4.TabIndex = 77;
            this.Label4.Text = resources.GetString("Label4.Text");
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(31, 247);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(152, 25);
            this.Label3.TabIndex = 76;
            this.Label3.Text = "Customer Display";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(31, 291);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(44, 25);
            this.Label2.TabIndex = 74;
            this.Label2.Text = "Port";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPort
            // 
            this.cmbPort.BackColor = System.Drawing.Color.White;
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPort.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPort.ForeColor = System.Drawing.Color.Black;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(202, 288);
            this.cmbPort.MaxDropDownItems = 10;
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(372, 31);
            this.cmbPort.TabIndex = 75;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(31, 100);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(121, 25);
            this.Label1.TabIndex = 72;
            this.Label1.Text = "Report Printer";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbReportPrinter
            // 
            this.cmbReportPrinter.BackColor = System.Drawing.Color.White;
            this.cmbReportPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReportPrinter.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportPrinter.ForeColor = System.Drawing.Color.Black;
            this.cmbReportPrinter.FormattingEnabled = true;
            this.cmbReportPrinter.Location = new System.Drawing.Point(202, 97);
            this.cmbReportPrinter.MaxDropDownItems = 10;
            this.cmbReportPrinter.Name = "cmbReportPrinter";
            this.cmbReportPrinter.Size = new System.Drawing.Size(372, 31);
            this.cmbReportPrinter.TabIndex = 73;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(31, 42);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(125, 25);
            this.Label8.TabIndex = 69;
            this.Label8.Text = "Receipt Printer";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxEnable_CD
            // 
            this.cbxEnable_CD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxEnable_CD.AutoSize = true;
            this.cbxEnable_CD.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEnable_CD.ForeColor = System.Drawing.Color.Black;
            this.cbxEnable_CD.Location = new System.Drawing.Point(202, 246);
            this.cbxEnable_CD.Margin = new System.Windows.Forms.Padding(2);
            this.cbxEnable_CD.Name = "cbxEnable_CD";
            this.cbxEnable_CD.Size = new System.Drawing.Size(83, 29);
            this.cbxEnable_CD.TabIndex = 70;
            this.cbxEnable_CD.Text = "Enable";
            this.cbxEnable_CD.UseVisualStyleBackColor = true;
            this.cbxEnable_CD.CheckedChanged += new System.EventHandler(this.CbxEnable_CD_CheckedChanged);
            // 
            // cmbReceiptPrinter
            // 
            this.cmbReceiptPrinter.BackColor = System.Drawing.Color.White;
            this.cmbReceiptPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceiptPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReceiptPrinter.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReceiptPrinter.ForeColor = System.Drawing.Color.Black;
            this.cmbReceiptPrinter.FormattingEnabled = true;
            this.cmbReceiptPrinter.Location = new System.Drawing.Point(202, 38);
            this.cmbReceiptPrinter.MaxDropDownItems = 10;
            this.cmbReceiptPrinter.Name = "cmbReceiptPrinter";
            this.cmbReceiptPrinter.Size = new System.Drawing.Size(372, 31);
            this.cmbReceiptPrinter.TabIndex = 71;
            // 
            // Devices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(614, 647);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Devices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devices";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Devices_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2TileButton btnSaveSettings;
        private Guna.UI2.WinForms.Guna2TileButton btnCancel;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cmbPort;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbReportPrinter;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.CheckBox cbxEnable_CD;
        internal System.Windows.Forms.ComboBox cmbReceiptPrinter;
    }
}