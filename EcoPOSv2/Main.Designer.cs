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
            this.btnMinimize = new System.Windows.Forms.Button();
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
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
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
            this.btnItemChecker = new Guna.UI2.WinForms.Guna2Button();
            this.btnclosetemp = new Guna.UI2.WinForms.Guna2Button();
            this.pnlChild = new System.Windows.Forms.Panel();
            this.tmrCurrentDateTime = new System.Windows.Forms.Timer(this.components);
            this.gunaTileButton1 = new Guna.UI.WinForms.GunaTileButton();
            this.panel1.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlChild.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnMinimize);
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
            this.btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1217, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(148, 34);
            this.btnMinimize.TabIndex = 13;
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            this.btnMinimize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnMinimize_KeyDown);
            // 
            // lblTraningMode
            // 
            this.lblTraningMode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTraningMode.AutoSize = true;
            this.lblTraningMode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraningMode.ForeColor = System.Drawing.Color.White;
            this.lblTraningMode.Location = new System.Drawing.Point(1005, 5);
            this.lblTraningMode.Name = "lblTraningMode";
            this.lblTraningMode.Size = new System.Drawing.Size(155, 25);
            this.lblTraningMode.TabIndex = 12;
            this.lblTraningMode.Text = "TRAINING MODE";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(11, 0);
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
            this.lblByPassUser.Location = new System.Drawing.Point(15, 119);
            this.lblByPassUser.Name = "lblByPassUser";
            this.lblByPassUser.Size = new System.Drawing.Size(181, 28);
            this.lblByPassUser.TabIndex = 11;
            this.lblByPassUser.Text = "                   ";
            this.lblByPassUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lblUser.Location = new System.Drawing.Point(12, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(184, 60);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Bypassed";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.guna2Panel2.Location = new System.Drawing.Point(-1, 149);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(211, 100);
            this.guna2Panel2.TabIndex = 17;
            // 
            // lblTerminalName
            // 
            this.lblTerminalName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminalName.Location = new System.Drawing.Point(0, 0);
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
            this.lblType.Location = new System.Drawing.Point(35, 34);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(138, 17);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "ECOPOS SERVER TYPE";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(-1, 48);
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
            this.guna2Panel1.Controls.Add(this.gunaLabel1);
            this.guna2Panel1.Controls.Add(this.btnUserRole);
            this.guna2Panel1.Controls.Add(this.lblByPassUser);
            this.guna2Panel1.Controls.Add(this.lblUser);
            this.guna2Panel1.Location = new System.Drawing.Point(-1, -1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(210, 148);
            this.guna2Panel1.TabIndex = 16;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gunaLabel1.Location = new System.Drawing.Point(63, 103);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(95, 19);
            this.gunaLabel1.TabIndex = 4;
            this.gunaLabel1.Text = "BYPASSED BY:";
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
            this.btnUserRole.Image = global::EcoPOSv2.Properties.Resources.OnlineGreenIcon2;
            this.btnUserRole.ImageSize = new System.Drawing.Size(8, 8);
            this.btnUserRole.Location = new System.Drawing.Point(27, 72);
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
            this.btnOrder.CheckedState.Parent = this.btnOrder;
            this.btnOrder.CustomImages.Parent = this.btnOrder;
            this.btnOrder.FillColor = System.Drawing.Color.White;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOrder.ForeColor = System.Drawing.Color.Black;
            this.btnOrder.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOrder.HoverState.Parent = this.btnOrder;
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageSize = new System.Drawing.Size(45, 45);
            this.btnOrder.Location = new System.Drawing.Point(0, 250);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.ShadowDecoration.Parent = this.btnOrder;
            this.btnOrder.Size = new System.Drawing.Size(210, 82);
            this.btnOrder.TabIndex = 6;
            this.btnOrder.Text = "Order (F2)";
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Black;
            this.lblVersion.Location = new System.Drawing.Point(110, 713);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(47, 17);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "ver 2.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(7, 675);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "REMOVE BYPASS (F12)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(10, 642);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "USER BYPASS  (F11)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 602);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "HOTKEY SHORTCUT(S)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnMore
            // 
            this.btnMore.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMore.CheckedState.Parent = this.btnMore;
            this.btnMore.CustomImages.Parent = this.btnMore;
            this.btnMore.FillColor = System.Drawing.Color.White;
            this.btnMore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMore.ForeColor = System.Drawing.Color.Black;
            this.btnMore.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMore.HoverState.Parent = this.btnMore;
            this.btnMore.Image = ((System.Drawing.Image)(resources.GetObject("btnMore.Image")));
            this.btnMore.ImageSize = new System.Drawing.Size(45, 45);
            this.btnMore.Location = new System.Drawing.Point(0, 514);
            this.btnMore.Name = "btnMore";
            this.btnMore.ShadowDecoration.Parent = this.btnMore;
            this.btnMore.Size = new System.Drawing.Size(210, 82);
            this.btnMore.TabIndex = 9;
            this.btnMore.Text = "More (F10)";
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnCalculator
            // 
            this.btnCalculator.CheckedState.Parent = this.btnCalculator;
            this.btnCalculator.CustomImages.Parent = this.btnCalculator;
            this.btnCalculator.FillColor = System.Drawing.Color.White;
            this.btnCalculator.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCalculator.ForeColor = System.Drawing.Color.Black;
            this.btnCalculator.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCalculator.HoverState.Parent = this.btnCalculator;
            this.btnCalculator.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculator.Image")));
            this.btnCalculator.ImageSize = new System.Drawing.Size(45, 45);
            this.btnCalculator.Location = new System.Drawing.Point(0, 426);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.ShadowDecoration.Parent = this.btnCalculator;
            this.btnCalculator.Size = new System.Drawing.Size(210, 82);
            this.btnCalculator.TabIndex = 8;
            this.btnCalculator.Text = "Calculator (F9)";
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // btnXReading
            // 
            this.btnXReading.CheckedState.Parent = this.btnXReading;
            this.btnXReading.CustomImages.Parent = this.btnXReading;
            this.btnXReading.FillColor = System.Drawing.Color.White;
            this.btnXReading.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXReading.ForeColor = System.Drawing.Color.Black;
            this.btnXReading.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXReading.HoverState.Parent = this.btnXReading;
            this.btnXReading.Image = ((System.Drawing.Image)(resources.GetObject("btnXReading.Image")));
            this.btnXReading.ImageSize = new System.Drawing.Size(45, 45);
            this.btnXReading.Location = new System.Drawing.Point(0, 338);
            this.btnXReading.Name = "btnXReading";
            this.btnXReading.ShadowDecoration.Parent = this.btnXReading;
            this.btnXReading.Size = new System.Drawing.Size(210, 82);
            this.btnXReading.TabIndex = 7;
            this.btnXReading.Text = "Switch Cashier (X-Read) (F8)";
            this.btnXReading.Click += new System.EventHandler(this.btnXReading_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbLogo.Image = global::EcoPOSv2.Properties.Resources.eco_pos;
            this.pbLogo.Location = new System.Drawing.Point(4, 698);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(250, 117);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 3;
            this.pbLogo.TabStop = false;
            // 
            // btnItemChecker
            // 
            this.btnItemChecker.CheckedState.Parent = this.btnItemChecker;
            this.btnItemChecker.CustomImages.Parent = this.btnItemChecker;
            this.btnItemChecker.FillColor = System.Drawing.Color.White;
            this.btnItemChecker.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnItemChecker.ForeColor = System.Drawing.Color.Black;
            this.btnItemChecker.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnItemChecker.HoverState.Parent = this.btnItemChecker;
            this.btnItemChecker.Image = ((System.Drawing.Image)(resources.GetObject("btnItemChecker.Image")));
            this.btnItemChecker.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnItemChecker.ImageSize = new System.Drawing.Size(45, 45);
            this.btnItemChecker.Location = new System.Drawing.Point(44, 502);
            this.btnItemChecker.Name = "btnItemChecker";
            this.btnItemChecker.ShadowDecoration.Parent = this.btnItemChecker;
            this.btnItemChecker.Size = new System.Drawing.Size(274, 60);
            this.btnItemChecker.TabIndex = 11;
            this.btnItemChecker.Text = "ITEM CHECKER (CTRL + I)";
            this.btnItemChecker.TextOffset = new System.Drawing.Point(15, 0);
            this.btnItemChecker.Click += new System.EventHandler(this.btnSeeItem_Click);
            // 
            // btnclosetemp
            // 
            this.btnclosetemp.CheckedState.Parent = this.btnclosetemp;
            this.btnclosetemp.CustomImages.Parent = this.btnclosetemp;
            this.btnclosetemp.FillColor = System.Drawing.Color.White;
            this.btnclosetemp.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnclosetemp.ForeColor = System.Drawing.Color.Black;
            this.btnclosetemp.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnclosetemp.HoverState.Parent = this.btnclosetemp;
            this.btnclosetemp.Image = ((System.Drawing.Image)(resources.GetObject("btnclosetemp.Image")));
            this.btnclosetemp.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnclosetemp.ImageSize = new System.Drawing.Size(45, 45);
            this.btnclosetemp.Location = new System.Drawing.Point(255, 603);
            this.btnclosetemp.Name = "btnclosetemp";
            this.btnclosetemp.ShadowDecoration.Parent = this.btnclosetemp;
            this.btnclosetemp.Size = new System.Drawing.Size(274, 60);
            this.btnclosetemp.TabIndex = 10;
            this.btnclosetemp.Text = "Close (Temporary)";
            this.btnclosetemp.TextOffset = new System.Drawing.Point(10, 0);
            this.btnclosetemp.Click += new System.EventHandler(this.btnclosetemp_Click);
            // 
            // pnlChild
            // 
            this.pnlChild.Controls.Add(this.gunaTileButton1);
            this.pnlChild.Controls.Add(this.btnItemChecker);
            this.pnlChild.Controls.Add(this.btnclosetemp);
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
            // gunaTileButton1
            // 
            this.gunaTileButton1.AnimationHoverSpeed = 0.07F;
            this.gunaTileButton1.AnimationSpeed = 0.03F;
            this.gunaTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTileButton1.BaseColor = System.Drawing.Color.Transparent;
            this.gunaTileButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaTileButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaTileButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaTileButton1.Font = new System.Drawing.Font("Segoe UI Light", 15.75F);
            this.gunaTileButton1.ForeColor = System.Drawing.Color.Black;
            this.gunaTileButton1.Image = global::EcoPOSv2.Properties.Resources.order;
            this.gunaTileButton1.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaTileButton1.Location = new System.Drawing.Point(163, 403);
            this.gunaTileButton1.Name = "gunaTileButton1";
            this.gunaTileButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaTileButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaTileButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaTileButton1.OnHoverImage = null;
            this.gunaTileButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaTileButton1.Size = new System.Drawing.Size(188, 93);
            this.gunaTileButton1.TabIndex = 12;
            this.gunaTileButton1.Text = "gunaTileButton1";
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
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlChild.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDateTime;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblType;
        internal System.Windows.Forms.Label lblVersion;
        private Guna.UI2.WinForms.Guna2Button btnclosetemp;
        public System.Windows.Forms.Label lblUser;
        public Guna.UI2.WinForms.Guna2Button btnXReading;
        public Guna.UI2.WinForms.Guna2Button btnCalculator;
        public Guna.UI2.WinForms.Guna2Button btnMore;
        public Guna.UI2.WinForms.Guna2Button btnItemChecker;
        public System.Windows.Forms.Panel pnlChild;
        internal System.Windows.Forms.Timer tmrCurrentDateTime;
        public System.Windows.Forms.PictureBox pbLogo;
        public System.Windows.Forms.Label lblByPassUser;
        public Guna.UI2.WinForms.Guna2Button btnOrder;
        private System.Windows.Forms.Label lblTraningMode;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTerminalName;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI.WinForms.GunaButton btnUserRole;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI.WinForms.GunaTileButton gunaTileButton1;
    }
}