namespace EcoPOSv2
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnclosetemp = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblTraningMode = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblByPassUser = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTerminalName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBypassedBy = new Guna.UI.WinForms.GunaLabel();
            this.btnUserRole = new Guna.UI.WinForms.GunaButton();
            this.btnOrder = new Guna.UI2.WinForms.Guna2Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMore = new Guna.UI2.WinForms.Guna2Button();
            this.btnCalculator = new Guna.UI2.WinForms.Guna2Button();
            this.btnXReading = new Guna.UI2.WinForms.Guna2Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlChild = new System.Windows.Forms.Panel();
            this.tmrCurrentDateTime = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnclosetemp);
            this.panel1.Controls.Add(this.lblTraningMode);
            this.panel1.Controls.Add(this.lblDateTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 34);
            this.panel1.TabIndex = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HoverState.Parent = this.btnMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1275, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.PressedColor = System.Drawing.Color.Gray;
            this.btnMinimize.ShadowDecoration.Parent = this.btnMinimize;
            this.btnMinimize.Size = new System.Drawing.Size(45, 34);
            this.btnMinimize.TabIndex = 15;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click_1);
            // 
            // btnclosetemp
            // 
            this.btnclosetemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclosetemp.BackColor = System.Drawing.Color.Transparent;
            this.btnclosetemp.FillColor = System.Drawing.Color.Transparent;
            this.btnclosetemp.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnclosetemp.HoverState.Parent = this.btnclosetemp;
            this.btnclosetemp.IconColor = System.Drawing.Color.White;
            this.btnclosetemp.Location = new System.Drawing.Point(1320, 0);
            this.btnclosetemp.Name = "btnclosetemp";
            this.btnclosetemp.PressedColor = System.Drawing.Color.Firebrick;
            this.btnclosetemp.ShadowDecoration.Parent = this.btnclosetemp;
            this.btnclosetemp.Size = new System.Drawing.Size(46, 34);
            this.btnclosetemp.TabIndex = 14;
            this.btnclosetemp.Click += new System.EventHandler(this.btnclosetemp_Click_1);
            // 
            // lblTraningMode
            // 
            this.lblTraningMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTraningMode.AutoSize = true;
            this.lblTraningMode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraningMode.ForeColor = System.Drawing.Color.White;
            this.lblTraningMode.Location = new System.Drawing.Point(601, 4);
            this.lblTraningMode.Name = "lblTraningMode";
            this.lblTraningMode.Size = new System.Drawing.Size(165, 25);
            this.lblTraningMode.TabIndex = 12;
            this.lblTraningMode.Text = "TRAINING MODE";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(11, 2);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(359, 32);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "Current Date and Time";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblByPassUser
            // 
            this.lblByPassUser.BackColor = System.Drawing.Color.Transparent;
            this.lblByPassUser.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblByPassUser.ForeColor = System.Drawing.Color.Red;
            this.lblByPassUser.Location = new System.Drawing.Point(16, 112);
            this.lblByPassUser.Name = "lblByPassUser";
            this.lblByPassUser.Size = new System.Drawing.Size(181, 32);
            this.lblByPassUser.TabIndex = 11;
            this.lblByPassUser.Text = "                   ";
            this.lblByPassUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lblUser.Location = new System.Drawing.Point(5, 3);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(201, 55);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Bypassed";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gunaPanel1.Controls.Add(this.guna2Panel2);
            this.gunaPanel1.Controls.Add(this.guna2Panel1);
            this.gunaPanel1.Controls.Add(this.btnOrder);
            this.gunaPanel1.Controls.Add(this.lblVersion);
            this.gunaPanel1.Controls.Add(this.label6);
            this.gunaPanel1.Controls.Add(this.label2);
            this.gunaPanel1.Controls.Add(this.label1);
            this.gunaPanel1.Controls.Add(this.btnMore);
            this.gunaPanel1.Controls.Add(this.btnCalculator);
            this.gunaPanel1.Controls.Add(this.btnXReading);
            this.gunaPanel1.Controls.Add(this.pbLogo);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 34);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(210, 734);
            this.gunaPanel1.TabIndex = 1;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.DimGray;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.lblTerminalName);
            this.guna2Panel2.Controls.Add(this.lblType);
            this.guna2Panel2.Controls.Add(this.Label3);
            this.guna2Panel2.Location = new System.Drawing.Point(-1, 151);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(211, 90);
            this.guna2Panel2.TabIndex = 17;
            // 
            // lblTerminalName
            // 
            this.lblTerminalName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminalName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lblTerminalName.Location = new System.Drawing.Point(1, -7);
            this.lblTerminalName.Name = "lblTerminalName";
            this.lblTerminalName.Size = new System.Drawing.Size(209, 31);
            this.lblTerminalName.TabIndex = 15;
            this.lblTerminalName.Text = "Terminal";
            this.lblTerminalName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.Black;
            this.lblType.Location = new System.Drawing.Point(36, 27);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(138, 17);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "ECOPOS SERVER TYPE";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(0, 39);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(210, 50);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "Provided By:\r\nWNO ELECTRONICS TRADING";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.DimGray;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.lblBypassedBy);
            this.guna2Panel1.Controls.Add(this.btnUserRole);
            this.guna2Panel1.Controls.Add(this.lblByPassUser);
            this.guna2Panel1.Controls.Add(this.lblUser);
            this.guna2Panel1.Location = new System.Drawing.Point(-1, -1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(210, 146);
            this.guna2Panel1.TabIndex = 16;
            // 
            // lblBypassedBy
            // 
            this.lblBypassedBy.BackColor = System.Drawing.Color.Transparent;
            this.lblBypassedBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBypassedBy.Location = new System.Drawing.Point(58, 96);
            this.lblBypassedBy.Name = "lblBypassedBy";
            this.lblBypassedBy.Size = new System.Drawing.Size(95, 19);
            this.lblBypassedBy.TabIndex = 4;
            this.lblBypassedBy.Text = "BYPASSED BY:";
            this.lblBypassedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUserRole
            // 
            this.btnUserRole.Animated = true;
            this.btnUserRole.AnimationHoverSpeed = 0.07F;
            this.btnUserRole.AnimationSpeed = 0.03F;
            this.btnUserRole.BackColor = System.Drawing.Color.Transparent;
            this.btnUserRole.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(129)))), ((int)(((byte)(255)))));
            this.btnUserRole.BorderColor = System.Drawing.Color.Black;
            this.btnUserRole.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUserRole.FocusedColor = System.Drawing.Color.Empty;
            this.btnUserRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserRole.ForeColor = System.Drawing.Color.White;
            this.btnUserRole.Image = global::EcoPOSv2.Properties.Resources.OnlineGreenIcon;
            this.btnUserRole.ImageSize = new System.Drawing.Size(8, 8);
            this.btnUserRole.Location = new System.Drawing.Point(28, 64);
            this.btnUserRole.Name = "btnUserRole";
            this.btnUserRole.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnUserRole.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnUserRole.OnHoverForeColor = System.Drawing.Color.White;
            this.btnUserRole.OnHoverImage = null;
            this.btnUserRole.OnPressedColor = System.Drawing.Color.Black;
            this.btnUserRole.Radius = 5;
            this.btnUserRole.Size = new System.Drawing.Size(150, 28);
            this.btnUserRole.TabIndex = 3;
            this.btnUserRole.Text = "SUPERVISOR";
            this.btnUserRole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOrder
            // 
            this.btnOrder.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnOrder.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(119)))), ((int)(((byte)(252)))));
            this.btnOrder.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnOrder.CheckedState.Image = global::EcoPOSv2.Properties.Resources.cart_white;
            this.btnOrder.CheckedState.Parent = this.btnOrder;
            this.btnOrder.CustomImages.Parent = this.btnOrder;
            this.btnOrder.FillColor = System.Drawing.Color.Transparent;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnOrder.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.btnOrder.HoverState.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.HoverState.Parent = this.btnOrder;
            this.btnOrder.Image = global::EcoPOSv2.Properties.Resources.cart_black;
            this.btnOrder.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOrder.ImageSize = new System.Drawing.Size(32, 32);
            this.btnOrder.Location = new System.Drawing.Point(-1, 241);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.btnOrder.ShadowDecoration.Parent = this.btnOrder;
            this.btnOrder.Size = new System.Drawing.Size(210, 60);
            this.btnOrder.TabIndex = 6;
            this.btnOrder.Text = "Order (F2)";
            this.btnOrder.TextOffset = new System.Drawing.Point(5, 0);
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Black;
            this.lblVersion.Location = new System.Drawing.Point(81, 708);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(47, 17);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "ver 2.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.label6.Location = new System.Drawing.Point(15, 580);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "REMOVE BYPASS    (F12)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.label2.Location = new System.Drawing.Point(15, 553);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "USER BYPASS          (F11)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label1.Location = new System.Drawing.Point(15, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "HOTKEY SHORTCUT(S)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnMore
            // 
            this.btnMore.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMore.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(119)))), ((int)(((byte)(252)))));
            this.btnMore.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnMore.CheckedState.Image = global::EcoPOSv2.Properties.Resources.more_white;
            this.btnMore.CheckedState.Parent = this.btnMore;
            this.btnMore.CustomImages.Parent = this.btnMore;
            this.btnMore.FillColor = System.Drawing.Color.Transparent;
            this.btnMore.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnMore.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.btnMore.HoverState.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.HoverState.Parent = this.btnMore;
            this.btnMore.Image = global::EcoPOSv2.Properties.Resources.more_black;
            this.btnMore.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMore.ImageSize = new System.Drawing.Size(32, 32);
            this.btnMore.Location = new System.Drawing.Point(0, 421);
            this.btnMore.Name = "btnMore";
            this.btnMore.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.btnMore.ShadowDecoration.Parent = this.btnMore;
            this.btnMore.Size = new System.Drawing.Size(210, 60);
            this.btnMore.TabIndex = 9;
            this.btnMore.Text = "More (F10)";
            this.btnMore.TextOffset = new System.Drawing.Point(5, 0);
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnCalculator
            // 
            this.btnCalculator.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(119)))), ((int)(((byte)(252)))));
            this.btnCalculator.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculator.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnCalculator.CheckedState.Image = global::EcoPOSv2.Properties.Resources.calculator_white;
            this.btnCalculator.CheckedState.Parent = this.btnCalculator;
            this.btnCalculator.CustomImages.Parent = this.btnCalculator;
            this.btnCalculator.FillColor = System.Drawing.Color.Transparent;
            this.btnCalculator.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnCalculator.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.btnCalculator.HoverState.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculator.HoverState.Parent = this.btnCalculator;
            this.btnCalculator.Image = global::EcoPOSv2.Properties.Resources.calculator_black;
            this.btnCalculator.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCalculator.ImageSize = new System.Drawing.Size(30, 30);
            this.btnCalculator.Location = new System.Drawing.Point(-1, 361);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.btnCalculator.ShadowDecoration.Parent = this.btnCalculator;
            this.btnCalculator.Size = new System.Drawing.Size(210, 60);
            this.btnCalculator.TabIndex = 8;
            this.btnCalculator.Text = "Calculator (F9)";
            this.btnCalculator.TextOffset = new System.Drawing.Point(5, 0);
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // btnXReading
            // 
            this.btnXReading.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(119)))), ((int)(((byte)(252)))));
            this.btnXReading.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXReading.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnXReading.CheckedState.Image = global::EcoPOSv2.Properties.Resources.switchcashier_white;
            this.btnXReading.CheckedState.Parent = this.btnXReading;
            this.btnXReading.CustomImages.Parent = this.btnXReading;
            this.btnXReading.FillColor = System.Drawing.Color.Transparent;
            this.btnXReading.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXReading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnXReading.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.btnXReading.HoverState.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXReading.HoverState.Parent = this.btnXReading;
            this.btnXReading.Image = global::EcoPOSv2.Properties.Resources.switchcashier_black;
            this.btnXReading.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnXReading.ImageSize = new System.Drawing.Size(32, 32);
            this.btnXReading.Location = new System.Drawing.Point(-1, 301);
            this.btnXReading.Name = "btnXReading";
            this.btnXReading.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.btnXReading.ShadowDecoration.Parent = this.btnXReading;
            this.btnXReading.Size = new System.Drawing.Size(210, 60);
            this.btnXReading.TabIndex = 7;
            this.btnXReading.Text = "Switch Cashier (F8)";
            this.btnXReading.TextOffset = new System.Drawing.Point(20, 0);
            this.btnXReading.Click += new System.EventHandler(this.btnXReading_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbLogo.Image = global::EcoPOSv2.Properties.Resources.eco_pos;
            this.pbLogo.Location = new System.Drawing.Point(0, 628);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(210, 105);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 3;
            this.pbLogo.TabStop = false;
            // 
            // pnlChild
            // 
            this.pnlChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChild.Location = new System.Drawing.Point(210, 34);
            this.pnlChild.Name = "pnlChild";
            this.pnlChild.Size = new System.Drawing.Size(1156, 734);
            this.pnlChild.TabIndex = 2;
            // 
            // tmrCurrentDateTime
            // 
            this.tmrCurrentDateTime.Enabled = true;
            this.tmrCurrentDateTime.Tick += new System.EventHandler(this.tmrCurrentDateTime_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pnlChild);
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDateTime;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblType;
        internal System.Windows.Forms.Label lblVersion;
        public System.Windows.Forms.Label lblUser;
        public Guna.UI2.WinForms.Guna2Button btnXReading;
        public Guna.UI2.WinForms.Guna2Button btnCalculator;
        public Guna.UI2.WinForms.Guna2Button btnMore;
        public System.Windows.Forms.Panel pnlChild;
        internal System.Windows.Forms.Timer tmrCurrentDateTime;
        public System.Windows.Forms.PictureBox pbLogo;
        public System.Windows.Forms.Label lblByPassUser;
        public Guna.UI2.WinForms.Guna2Button btnOrder;
        private System.Windows.Forms.Label lblTraningMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTerminalName;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI.WinForms.GunaButton btnUserRole;
        public Guna.UI.WinForms.GunaLabel lblBypassedBy;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ControlBox btnclosetemp;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
    }
}