
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
            this.label6 = new System.Windows.Forms.Label();
            this.cmbReceiptCopies = new System.Windows.Forms.ComboBox();
            this.moreOptionContainer = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPaperSize = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cbxEnable_CD = new System.Windows.Forms.CheckBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2ImageButton2 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnSaveSettings = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnCancel = new Guna.UI2.WinForms.Guna2TileButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbReportPrinter = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.cmbReceiptPrinter = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRePrintPrinter = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.moreOptionContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbRePrintPrinter);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbReceiptCopies);
            this.panel1.Controls.Add(this.moreOptionContainer);
            this.panel1.Controls.Add(this.guna2ImageButton1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.guna2ImageButton2);
            this.panel1.Controls.Add(this.btnSaveSettings);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.cmbReportPrinter);
            this.panel1.Controls.Add(this.Label8);
            this.panel1.Controls.Add(this.cmbReceiptPrinter);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 637);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(31, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 25);
            this.label6.TabIndex = 96;
            this.label6.Text = "Receipt Copy";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbReceiptCopies
            // 
            this.cmbReceiptCopies.BackColor = System.Drawing.Color.White;
            this.cmbReceiptCopies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceiptCopies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReceiptCopies.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReceiptCopies.ForeColor = System.Drawing.Color.Black;
            this.cmbReceiptCopies.FormattingEnabled = true;
            this.cmbReceiptCopies.Items.AddRange(new object[] {
            "Don\'t print a receipt",
            "Customer copy only",
            "Customer and Accounting copy"});
            this.cmbReceiptCopies.Location = new System.Drawing.Point(202, 179);
            this.cmbReceiptCopies.MaxDropDownItems = 10;
            this.cmbReceiptCopies.Name = "cmbReceiptCopies";
            this.cmbReceiptCopies.Size = new System.Drawing.Size(372, 31);
            this.cmbReceiptCopies.TabIndex = 97;
            // 
            // moreOptionContainer
            // 
            this.moreOptionContainer.Controls.Add(this.label4);
            this.moreOptionContainer.Controls.Add(this.cmbPaperSize);
            this.moreOptionContainer.Controls.Add(this.label19);
            this.moreOptionContainer.Controls.Add(this.cmbPort);
            this.moreOptionContainer.Controls.Add(this.cbxEnable_CD);
            this.moreOptionContainer.Controls.Add(this.Label2);
            this.moreOptionContainer.Controls.Add(this.Label3);
            this.moreOptionContainer.Location = new System.Drawing.Point(7, 284);
            this.moreOptionContainer.Name = "moreOptionContainer";
            this.moreOptionContainer.Size = new System.Drawing.Size(590, 203);
            this.moreOptionContainer.TabIndex = 95;
            this.moreOptionContainer.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 25);
            this.label4.TabIndex = 92;
            this.label4.Text = "Receipt Paper Size:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPaperSize
            // 
            this.cmbPaperSize.BackColor = System.Drawing.Color.White;
            this.cmbPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaperSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPaperSize.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaperSize.ForeColor = System.Drawing.Color.Black;
            this.cmbPaperSize.FormattingEnabled = true;
            this.cmbPaperSize.Items.AddRange(new object[] {
            "58MM",
            "80MM"});
            this.cmbPaperSize.Location = new System.Drawing.Point(195, 99);
            this.cmbPaperSize.MaxDropDownItems = 10;
            this.cmbPaperSize.Name = "cmbPaperSize";
            this.cmbPaperSize.Size = new System.Drawing.Size(372, 31);
            this.cmbPaperSize.TabIndex = 93;
            this.cmbPaperSize.SelectedIndexChanged += new System.EventHandler(this.cmbPaperSize_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(28, 150);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(539, 38);
            this.label19.TabIndex = 91;
            this.label19.Text = "Note: before changing the size of receipt. Check first the width of receipt that " +
    "can print of your printer driver.";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPort
            // 
            this.cmbPort.BackColor = System.Drawing.Color.White;
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPort.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPort.ForeColor = System.Drawing.Color.Black;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(195, 57);
            this.cmbPort.MaxDropDownItems = 10;
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(372, 31);
            this.cmbPort.TabIndex = 75;
            // 
            // cbxEnable_CD
            // 
            this.cbxEnable_CD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxEnable_CD.AutoSize = true;
            this.cbxEnable_CD.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEnable_CD.ForeColor = System.Drawing.Color.Black;
            this.cbxEnable_CD.Location = new System.Drawing.Point(180, 9);
            this.cbxEnable_CD.Margin = new System.Windows.Forms.Padding(2);
            this.cbxEnable_CD.Name = "cbxEnable_CD";
            this.cbxEnable_CD.Size = new System.Drawing.Size(83, 29);
            this.cbxEnable_CD.TabIndex = 70;
            this.cbxEnable_CD.Text = "Enable";
            this.cbxEnable_CD.UseVisualStyleBackColor = true;
            this.cbxEnable_CD.CheckedChanged += new System.EventHandler(this.CbxEnable_CD_CheckedChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(141, 59);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(48, 25);
            this.Label2.TabIndex = 74;
            this.Label2.Text = "Port:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(9, 10);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(152, 25);
            this.Label3.TabIndex = 76;
            this.Label3.Text = "Customer Display";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.CheckedState.Parent = this.guna2ImageButton1;
            this.guna2ImageButton1.HoverState.Parent = this.guna2ImageButton1;
            this.guna2ImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton1.Image")));
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2ImageButton1.Location = new System.Drawing.Point(147, 240);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2ImageButton1.PressedState.Parent = this.guna2ImageButton1;
            this.guna2ImageButton1.Size = new System.Drawing.Size(39, 38);
            this.guna2ImageButton1.TabIndex = 94;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(32, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 23);
            this.label5.TabIndex = 93;
            this.label5.Text = "More Option";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2ImageButton2
            // 
            this.guna2ImageButton2.CheckedState.Parent = this.guna2ImageButton2;
            this.guna2ImageButton2.HoverState.Parent = this.guna2ImageButton2;
            this.guna2ImageButton2.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2ImageButton2.Location = new System.Drawing.Point(144, 339);
            this.guna2ImageButton2.Name = "guna2ImageButton2";
            this.guna2ImageButton2.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2ImageButton2.PressedState.Parent = this.guna2ImageButton2;
            this.guna2ImageButton2.Size = new System.Drawing.Size(39, 38);
            this.guna2ImageButton2.TabIndex = 92;
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
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(31, 135);
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
            this.cmbReportPrinter.Location = new System.Drawing.Point(202, 132);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(31, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 25);
            this.label7.TabIndex = 98;
            this.label7.Text = "Re-Print Printer";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbRePrintPrinter
            // 
            this.cmbRePrintPrinter.BackColor = System.Drawing.Color.White;
            this.cmbRePrintPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRePrintPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRePrintPrinter.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRePrintPrinter.ForeColor = System.Drawing.Color.Black;
            this.cmbRePrintPrinter.FormattingEnabled = true;
            this.cmbRePrintPrinter.Location = new System.Drawing.Point(202, 84);
            this.cmbRePrintPrinter.MaxDropDownItems = 10;
            this.cmbRePrintPrinter.Name = "cmbRePrintPrinter";
            this.cmbRePrintPrinter.Size = new System.Drawing.Size(372, 31);
            this.cmbRePrintPrinter.TabIndex = 99;
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
            this.moreOptionContainer.ResumeLayout(false);
            this.moreOptionContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2TileButton btnSaveSettings;
        private Guna.UI2.WinForms.Guna2TileButton btnCancel;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbReportPrinter;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.ComboBox cmbReceiptPrinter;
        private System.Windows.Forms.Panel moreOptionContainer;
        internal System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbPaperSize;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.ComboBox cmbPort;
        internal System.Windows.Forms.CheckBox cbxEnable_CD;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        internal System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton2;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbReceiptCopies;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cmbRePrintPrinter;
    }
}