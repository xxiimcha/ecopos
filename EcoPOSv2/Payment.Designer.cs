namespace EcoPOSv2
{
    partial class Payment
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment));
            this.Label9 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblReferenceNo = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI.WinForms.GunaControlBox();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.btnRemoveGC = new Guna.UI2.WinForms.Guna2Button();
            this.btnGC = new Guna.UI2.WinForms.Guna2Button();
            this.btnExact = new Guna.UI2.WinForms.Guna2Button();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.tbReferenceNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlChange = new Guna.UI2.WinForms.Guna2Panel();
            this.cmbMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.lblRemainingPoints = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblDeductPoints = new System.Windows.Forms.Label();
            this.lblDeductGC = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbxUsePoints = new System.Windows.Forms.CheckBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblGCNo = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Panel1.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.pnlChange.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.Label9.Location = new System.Drawing.Point(3, 116);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(197, 39);
            this.Label9.TabIndex = 85;
            this.Label9.Text = "GRAND TOTAL";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblGrandTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(206, 116);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(373, 39);
            this.lblGrandTotal.TabIndex = 88;
            this.lblGrandTotal.Text = "0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGrandTotal.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(170)))), ((int)(((byte)(31)))));
            this.Label4.Location = new System.Drawing.Point(19, 7);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(198, 39);
            this.Label4.TabIndex = 89;
            this.Label4.Text = "CHANGE";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChange
            // 
            this.lblChange.BackColor = System.Drawing.Color.Transparent;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(170)))), ((int)(((byte)(31)))));
            this.lblChange.Location = new System.Drawing.Point(232, 7);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(367, 39);
            this.lblChange.TabIndex = 90;
            this.lblChange.Text = "0.00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceNo.Location = new System.Drawing.Point(361, 428);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(216, 26);
            this.lblReferenceNo.TabIndex = 20;
            this.lblReferenceNo.Text = "REFERENCE NO.";
            this.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReferenceNo.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.AnimationHoverSpeed = 0.07F;
            this.btnClose.AnimationSpeed = 0.03F;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.IconColor = System.Drawing.Color.Black;
            this.btnClose.IconSize = 15F;
            this.btnClose.Location = new System.Drawing.Point(577, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.OnHoverIconColor = System.Drawing.Color.White;
            this.btnClose.OnPressedColor = System.Drawing.Color.Black;
            this.btnClose.Size = new System.Drawing.Size(42, 35);
            this.btnClose.TabIndex = 102;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 28);
            this.label5.TabIndex = 103;
            this.label5.Text = "AMOUNT TENDERED:";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.pnlTitle);
            this.guna2Panel1.Controls.Add(this.btnRemoveGC);
            this.guna2Panel1.Controls.Add(this.btnGC);
            this.guna2Panel1.Controls.Add(this.btnExact);
            this.guna2Panel1.Controls.Add(this.btnPay);
            this.guna2Panel1.Controls.Add(this.tbReferenceNo);
            this.guna2Panel1.Controls.Add(this.pnlChange);
            this.guna2Panel1.Controls.Add(this.cmbMethod);
            this.guna2Panel1.Controls.Add(this.tableLayoutPanel1);
            this.guna2Panel1.Controls.Add(this.lblReferenceNo);
            this.guna2Panel1.Controls.Add(this.txtAmount);
            this.guna2Panel1.Controls.Add(this.cbxUsePoints);
            this.guna2Panel1.Controls.Add(this.Label6);
            this.guna2Panel1.Controls.Add(this.lblCustomerID);
            this.guna2Panel1.Controls.Add(this.lblGCNo);
            this.guna2Panel1.Controls.Add(this.Label3);
            this.guna2Panel1.Controls.Add(this.Label2);
            this.guna2Panel1.Controls.Add(this.Label1);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(619, 686);
            this.guna2Panel1.TabIndex = 0;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlTitle.BorderThickness = 1;
            this.pnlTitle.Controls.Add(this.btnClose);
            this.pnlTitle.Controls.Add(this.gunaLabel1);
            this.pnlTitle.CustomBorderColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.ShadowDecoration.Depth = 40;
            this.pnlTitle.ShadowDecoration.Enabled = true;
            this.pnlTitle.ShadowDecoration.Parent = this.pnlTitle;
            this.pnlTitle.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlTitle.Size = new System.Drawing.Size(619, 35);
            this.pnlTitle.TabIndex = 128;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel1.Location = new System.Drawing.Point(10, 7);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(78, 21);
            this.gunaLabel1.TabIndex = 103;
            this.gunaLabel1.Text = "PAYMENT";
            this.gunaLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRemoveGC
            // 
            this.btnRemoveGC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveGC.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveGC.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveGC.BorderRadius = 3;
            this.btnRemoveGC.BorderThickness = 1;
            this.btnRemoveGC.CheckedState.Parent = this.btnRemoveGC;
            this.btnRemoveGC.CustomImages.Parent = this.btnRemoveGC;
            this.btnRemoveGC.FillColor = System.Drawing.Color.White;
            this.btnRemoveGC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveGC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnRemoveGC.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.btnRemoveGC.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveGC.HoverState.Parent = this.btnRemoveGC;
            this.btnRemoveGC.Location = new System.Drawing.Point(20, 608);
            this.btnRemoveGC.Name = "btnRemoveGC";
            this.btnRemoveGC.ShadowDecoration.BorderRadius = 3;
            this.btnRemoveGC.ShadowDecoration.Depth = 50;
            this.btnRemoveGC.ShadowDecoration.Enabled = true;
            this.btnRemoveGC.ShadowDecoration.Parent = this.btnRemoveGC;
            this.btnRemoveGC.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnRemoveGC.Size = new System.Drawing.Size(283, 56);
            this.btnRemoveGC.TabIndex = 127;
            this.btnRemoveGC.Text = "REMOVE GC (F3)";
            this.btnRemoveGC.Click += new System.EventHandler(this.btnRemoveGC_Click);
            // 
            // btnGC
            // 
            this.btnGC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGC.BackColor = System.Drawing.Color.Transparent;
            this.btnGC.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGC.BorderRadius = 3;
            this.btnGC.BorderThickness = 1;
            this.btnGC.CheckedState.Parent = this.btnGC;
            this.btnGC.CustomImages.Parent = this.btnGC;
            this.btnGC.FillColor = System.Drawing.Color.White;
            this.btnGC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnGC.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.btnGC.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnGC.HoverState.Parent = this.btnGC;
            this.btnGC.Location = new System.Drawing.Point(20, 546);
            this.btnGC.Name = "btnGC";
            this.btnGC.ShadowDecoration.BorderRadius = 3;
            this.btnGC.ShadowDecoration.Depth = 50;
            this.btnGC.ShadowDecoration.Enabled = true;
            this.btnGC.ShadowDecoration.Parent = this.btnGC;
            this.btnGC.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnGC.Size = new System.Drawing.Size(283, 56);
            this.btnGC.TabIndex = 126;
            this.btnGC.Text = "GIFT CARD (F2)";
            this.btnGC.Click += new System.EventHandler(this.btnGC_Click);
            // 
            // btnExact
            // 
            this.btnExact.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExact.BackColor = System.Drawing.Color.Transparent;
            this.btnExact.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExact.BorderRadius = 3;
            this.btnExact.BorderThickness = 1;
            this.btnExact.CheckedState.Parent = this.btnExact;
            this.btnExact.CustomImages.Parent = this.btnExact;
            this.btnExact.FillColor = System.Drawing.Color.White;
            this.btnExact.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnExact.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.btnExact.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnExact.HoverState.Parent = this.btnExact;
            this.btnExact.Location = new System.Drawing.Point(315, 546);
            this.btnExact.Name = "btnExact";
            this.btnExact.ShadowDecoration.BorderRadius = 3;
            this.btnExact.ShadowDecoration.Depth = 50;
            this.btnExact.ShadowDecoration.Enabled = true;
            this.btnExact.ShadowDecoration.Parent = this.btnExact;
            this.btnExact.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnExact.Size = new System.Drawing.Size(283, 56);
            this.btnExact.TabIndex = 125;
            this.btnExact.Text = "EXACT (SPACE)";
            this.btnExact.Click += new System.EventHandler(this.btnExact_Click);
            this.btnExact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnExact_KeyDown);
            // 
            // btnPay
            // 
            this.btnPay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPay.BackColor = System.Drawing.Color.White;
            this.btnPay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnPay.BorderRadius = 5;
            this.btnPay.BorderThickness = 2;
            this.btnPay.CheckedState.Parent = this.btnPay;
            this.btnPay.CustomImages.Parent = this.btnPay;
            this.btnPay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.HoverState.BorderColor = System.Drawing.Color.Green;
            this.btnPay.HoverState.FillColor = System.Drawing.Color.Green;
            this.btnPay.HoverState.Parent = this.btnPay;
            this.btnPay.Location = new System.Drawing.Point(315, 608);
            this.btnPay.Name = "btnPay";
            this.btnPay.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPay.ShadowDecoration.Depth = 50;
            this.btnPay.ShadowDecoration.Parent = this.btnPay;
            this.btnPay.Size = new System.Drawing.Size(283, 56);
            this.btnPay.TabIndex = 124;
            this.btnPay.Text = "PAY (ENTER)";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // tbReferenceNo
            // 
            this.tbReferenceNo.BorderColor = System.Drawing.Color.Gray;
            this.tbReferenceNo.BorderRadius = 3;
            this.tbReferenceNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbReferenceNo.DefaultText = "";
            this.tbReferenceNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbReferenceNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbReferenceNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbReferenceNo.DisabledState.Parent = this.tbReferenceNo;
            this.tbReferenceNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbReferenceNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.tbReferenceNo.FocusedState.Parent = this.tbReferenceNo;
            this.tbReferenceNo.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReferenceNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.tbReferenceNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbReferenceNo.HoverState.Parent = this.tbReferenceNo;
            this.tbReferenceNo.Location = new System.Drawing.Point(361, 455);
            this.tbReferenceNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbReferenceNo.Name = "tbReferenceNo";
            this.tbReferenceNo.PasswordChar = '\0';
            this.tbReferenceNo.PlaceholderText = "";
            this.tbReferenceNo.SelectedText = "";
            this.tbReferenceNo.ShadowDecoration.Parent = this.tbReferenceNo;
            this.tbReferenceNo.Size = new System.Drawing.Size(238, 36);
            this.tbReferenceNo.TabIndex = 123;
            this.tbReferenceNo.Visible = false;
            // 
            // pnlChange
            // 
            this.pnlChange.BackColor = System.Drawing.Color.Transparent;
            this.pnlChange.Controls.Add(this.Label4);
            this.pnlChange.Controls.Add(this.lblChange);
            this.pnlChange.CustomBorderColor = System.Drawing.Color.Silver;
            this.pnlChange.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.pnlChange.Location = new System.Drawing.Point(0, 291);
            this.pnlChange.Name = "pnlChange";
            this.pnlChange.ShadowDecoration.Parent = this.pnlChange;
            this.pnlChange.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlChange.Size = new System.Drawing.Size(619, 55);
            this.pnlChange.TabIndex = 122;
            // 
            // cmbMethod
            // 
            this.cmbMethod.BackColor = System.Drawing.Color.Transparent;
            this.cmbMethod.BorderColor = System.Drawing.Color.Gray;
            this.cmbMethod.BorderRadius = 3;
            this.cmbMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FocusedColor = System.Drawing.Color.Fuchsia;
            this.cmbMethod.FocusedState.BorderColor = System.Drawing.Color.Fuchsia;
            this.cmbMethod.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbMethod.FocusedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMethod.FocusedState.Parent = this.cmbMethod;
            this.cmbMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.HoverState.Parent = this.cmbMethod;
            this.cmbMethod.ItemHeight = 30;
            this.cmbMethod.Items.AddRange(new object[] {
            "Cash",
            "Membership Points",
            "Gift Certificate",
            "GCash",
            "PayMaya",
            "Lyka Gem(s)",
            "ShopeePay",
            "Salary Deduction",
            "PayPal",
            "American Express",
            "BancNet",
            "China UnionPay",
            "JCB",
            "Mastercard",
            "Visa ",
            "Cheque"});
            this.cmbMethod.ItemsAppearance.Parent = this.cmbMethod;
            this.cmbMethod.Location = new System.Drawing.Point(361, 382);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.ShadowDecoration.Parent = this.cmbMethod;
            this.cmbMethod.Size = new System.Drawing.Size(238, 36);
            this.cmbMethod.StartIndex = 0;
            this.cmbMethod.TabIndex = 121;
            this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.CmbMethod_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.Label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRemainingPoints, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDeductPoints, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDeductGC, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTotal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblGrandTotal, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 132);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 155);
            this.tableLayoutPanel1.TabIndex = 120;
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Label8.Location = new System.Drawing.Point(3, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(197, 29);
            this.Label8.TabIndex = 111;
            this.Label8.Text = "Total";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label10
            // 
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Label10.Location = new System.Drawing.Point(3, 29);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(197, 29);
            this.Label10.TabIndex = 115;
            this.Label10.Text = "Deduct by gift card";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemainingPoints
            // 
            this.lblRemainingPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblRemainingPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRemainingPoints.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblRemainingPoints.Location = new System.Drawing.Point(206, 87);
            this.lblRemainingPoints.Name = "lblRemainingPoints";
            this.lblRemainingPoints.Size = new System.Drawing.Size(373, 29);
            this.lblRemainingPoints.TabIndex = 118;
            this.lblRemainingPoints.Text = "0.00";
            this.lblRemainingPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Label7.Location = new System.Drawing.Point(3, 58);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(197, 29);
            this.Label7.TabIndex = 112;
            this.Label7.Text = "Deduct by points";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeductPoints
            // 
            this.lblDeductPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblDeductPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeductPoints.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeductPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblDeductPoints.Location = new System.Drawing.Point(206, 58);
            this.lblDeductPoints.Name = "lblDeductPoints";
            this.lblDeductPoints.Size = new System.Drawing.Size(373, 29);
            this.lblDeductPoints.TabIndex = 114;
            this.lblDeductPoints.Text = "0.00";
            this.lblDeductPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDeductPoints.TextChanged += new System.EventHandler(this.lblDeductPoints_TextChanged_1);
            // 
            // lblDeductGC
            // 
            this.lblDeductGC.BackColor = System.Drawing.Color.Transparent;
            this.lblDeductGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeductGC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeductGC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblDeductGC.Location = new System.Drawing.Point(206, 29);
            this.lblDeductGC.Name = "lblDeductGC";
            this.lblDeductGC.Size = new System.Drawing.Size(373, 29);
            this.lblDeductGC.TabIndex = 116;
            this.lblDeductGC.Text = "0.00";
            this.lblDeductGC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDeductGC.TextChanged += new System.EventHandler(this.lblDeductGC_TextChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.label12.Location = new System.Drawing.Point(3, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(197, 29);
            this.label12.TabIndex = 117;
            this.label12.Text = "Remaining Points";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblTotal.Location = new System.Drawing.Point(206, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(373, 29);
            this.lblTotal.TabIndex = 113;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmount
            // 
            this.txtAmount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.txtAmount.BorderRadius = 3;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.DefaultText = "";
            this.txtAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmount.DisabledState.Parent = this.txtAmount;
            this.txtAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmount.FocusedState.Parent = this.txtAmount;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmount.HoverState.Parent = this.txtAmount;
            this.txtAmount.Location = new System.Drawing.Point(18, 76);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(15, 7, 15, 7);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.PlaceholderText = "";
            this.txtAmount.SelectedText = "";
            this.txtAmount.ShadowDecoration.Parent = this.txtAmount;
            this.txtAmount.ShortcutsEnabled = false;
            this.txtAmount.Size = new System.Drawing.Size(583, 46);
            this.txtAmount.TabIndex = 119;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAmount_KeyPress);
            // 
            // cbxUsePoints
            // 
            this.cbxUsePoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxUsePoints.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxUsePoints.ForeColor = System.Drawing.Color.Black;
            this.cbxUsePoints.Location = new System.Drawing.Point(24, 493);
            this.cbxUsePoints.Name = "cbxUsePoints";
            this.cbxUsePoints.Size = new System.Drawing.Size(268, 27);
            this.cbxUsePoints.TabIndex = 110;
            this.cbxUsePoints.Text = "0.00";
            this.cbxUsePoints.UseVisualStyleBackColor = true;
            this.cbxUsePoints.CheckedChanged += new System.EventHandler(this.cbxUsePoints_CheckedChanged);
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(20, 471);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(136, 25);
            this.Label6.TabIndex = 109;
            this.Label6.Text = "USE POINTS";
            this.Label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerID.Location = new System.Drawing.Point(19, 379);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(273, 25);
            this.lblCustomerID.TabIndex = 108;
            this.lblCustomerID.Text = "0";
            this.lblCustomerID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGCNo
            // 
            this.lblGCNo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGCNo.ForeColor = System.Drawing.Color.Black;
            this.lblGCNo.Location = new System.Drawing.Point(19, 439);
            this.lblGCNo.Name = "lblGCNo";
            this.lblGCNo.Size = new System.Drawing.Size(273, 22);
            this.lblGCNo.TabIndex = 107;
            this.lblGCNo.Text = "0";
            this.lblGCNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(20, 356);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(195, 25);
            this.Label3.TabIndex = 106;
            this.Label3.Text = "CUSTOMER ID";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(20, 415);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(195, 25);
            this.Label2.TabIndex = 105;
            this.Label2.Text = "GC NO.";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(361, 355);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(216, 26);
            this.Label1.TabIndex = 104;
            this.Label1.Text = "PAYMENT METHOD";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.pnlTitle;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(619, 686);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Payment_FormClosing);
            this.Load += new System.EventHandler(this.Payment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Payment_KeyDown);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlChange.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label lblGrandTotal;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblChange;
        private Guna.UI.WinForms.GunaControlBox btnClose;
        internal System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        internal System.Windows.Forms.Label lblDeductGC;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label lblDeductPoints;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.CheckBox cbxUsePoints;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblCustomerID;
        internal System.Windows.Forms.Label lblGCNo;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblRemainingPoints;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblReferenceNo;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        public Guna.UI2.WinForms.Guna2TextBox txtAmount;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel pnlChange;
        public Guna.UI2.WinForms.Guna2ComboBox cmbMethod;
        private Guna.UI2.WinForms.Guna2TextBox tbReferenceNo;
        public Guna.UI2.WinForms.Guna2Button btnPay;
        public Guna.UI2.WinForms.Guna2Button btnRemoveGC;
        public Guna.UI2.WinForms.Guna2Button btnGC;
        public Guna.UI2.WinForms.Guna2Button btnExact;
        private Guna.UI2.WinForms.Guna2Panel pnlTitle;
    }
}