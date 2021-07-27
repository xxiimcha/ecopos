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
            this.lblByPassUser = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnItemChecker = new Guna.UI2.WinForms.Guna2Button();
            this.btnclosetemp = new Guna.UI2.WinForms.Guna2Button();
            this.btnMore = new Guna.UI2.WinForms.Guna2Button();
            this.btnCalculator = new Guna.UI2.WinForms.Guna2Button();
            this.btnXReading = new Guna.UI2.WinForms.Guna2Button();
            this.btnOrder = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlChild = new System.Windows.Forms.Panel();
            this.tmrCurrentDateTime = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.lblTraningMode);
            this.panel1.Controls.Add(this.lblByPassUser);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.lblDateTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 34);
            this.panel1.TabIndex = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1292, 0);
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
            this.lblTraningMode.AutoSize = true;
            this.lblTraningMode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraningMode.ForeColor = System.Drawing.Color.White;
            this.lblTraningMode.Location = new System.Drawing.Point(1131, 2);
            this.lblTraningMode.Name = "lblTraningMode";
            this.lblTraningMode.Size = new System.Drawing.Size(155, 25);
            this.lblTraningMode.TabIndex = 12;
            this.lblTraningMode.Text = "TRAINING MODE";
            // 
            // lblByPassUser
            // 
            this.lblByPassUser.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblByPassUser.ForeColor = System.Drawing.Color.Red;
            this.lblByPassUser.Location = new System.Drawing.Point(689, 0);
            this.lblByPassUser.Name = "lblByPassUser";
            this.lblByPassUser.Size = new System.Drawing.Size(294, 34);
            this.lblByPassUser.TabIndex = 11;
            this.lblByPassUser.Text = "                   ";
            this.lblByPassUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(413, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(270, 32);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Bypassed";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // gunaPanel1
            // 
            this.gunaPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gunaPanel1.Controls.Add(this.label6);
            this.gunaPanel1.Controls.Add(this.label2);
            this.gunaPanel1.Controls.Add(this.label1);
            this.gunaPanel1.Controls.Add(this.btnItemChecker);
            this.gunaPanel1.Controls.Add(this.btnclosetemp);
            this.gunaPanel1.Controls.Add(this.btnMore);
            this.gunaPanel1.Controls.Add(this.btnCalculator);
            this.gunaPanel1.Controls.Add(this.btnXReading);
            this.gunaPanel1.Controls.Add(this.btnOrder);
            this.gunaPanel1.Controls.Add(this.panel2);
            this.gunaPanel1.Controls.Add(this.pbLogo);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 34);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(276, 866);
            this.gunaPanel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(48, 628);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "F12 = Removing Bypass";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(67, 602);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "F11 = User Bypass";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(47, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Hotkey Shortcut(s)";
            // 
            // btnItemChecker
            // 
            this.btnItemChecker.CheckedState.Parent = this.btnItemChecker;
            this.btnItemChecker.CustomImages.Parent = this.btnItemChecker;
            this.btnItemChecker.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnItemChecker.FillColor = System.Drawing.Color.White;
            this.btnItemChecker.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnItemChecker.ForeColor = System.Drawing.Color.Black;
            this.btnItemChecker.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnItemChecker.HoverState.Parent = this.btnItemChecker;
            this.btnItemChecker.Image = ((System.Drawing.Image)(resources.GetObject("btnItemChecker.Image")));
            this.btnItemChecker.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnItemChecker.ImageSize = new System.Drawing.Size(45, 45);
            this.btnItemChecker.Location = new System.Drawing.Point(0, 744);
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
            this.btnclosetemp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnclosetemp.FillColor = System.Drawing.Color.White;
            this.btnclosetemp.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnclosetemp.ForeColor = System.Drawing.Color.Black;
            this.btnclosetemp.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnclosetemp.HoverState.Parent = this.btnclosetemp;
            this.btnclosetemp.Image = ((System.Drawing.Image)(resources.GetObject("btnclosetemp.Image")));
            this.btnclosetemp.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnclosetemp.ImageSize = new System.Drawing.Size(45, 45);
            this.btnclosetemp.Location = new System.Drawing.Point(0, 804);
            this.btnclosetemp.Name = "btnclosetemp";
            this.btnclosetemp.ShadowDecoration.Parent = this.btnclosetemp;
            this.btnclosetemp.Size = new System.Drawing.Size(274, 60);
            this.btnclosetemp.TabIndex = 10;
            this.btnclosetemp.Text = "Close (Temporary)";
            this.btnclosetemp.TextOffset = new System.Drawing.Point(10, 0);
            this.btnclosetemp.Click += new System.EventHandler(this.btnclosetemp_Click);
            // 
            // btnMore
            // 
            this.btnMore.CheckedState.Parent = this.btnMore;
            this.btnMore.CustomImages.Parent = this.btnMore;
            this.btnMore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMore.FillColor = System.Drawing.Color.White;
            this.btnMore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMore.ForeColor = System.Drawing.Color.Black;
            this.btnMore.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMore.HoverState.Parent = this.btnMore;
            this.btnMore.Image = ((System.Drawing.Image)(resources.GetObject("btnMore.Image")));
            this.btnMore.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMore.ImageSize = new System.Drawing.Size(45, 45);
            this.btnMore.Location = new System.Drawing.Point(0, 435);
            this.btnMore.Name = "btnMore";
            this.btnMore.ShadowDecoration.Parent = this.btnMore;
            this.btnMore.Size = new System.Drawing.Size(274, 60);
            this.btnMore.TabIndex = 9;
            this.btnMore.Text = "More (F10)";
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnCalculator
            // 
            this.btnCalculator.CheckedState.Parent = this.btnCalculator;
            this.btnCalculator.CustomImages.Parent = this.btnCalculator;
            this.btnCalculator.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCalculator.FillColor = System.Drawing.Color.White;
            this.btnCalculator.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCalculator.ForeColor = System.Drawing.Color.Black;
            this.btnCalculator.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCalculator.HoverState.Parent = this.btnCalculator;
            this.btnCalculator.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculator.Image")));
            this.btnCalculator.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCalculator.ImageSize = new System.Drawing.Size(45, 45);
            this.btnCalculator.Location = new System.Drawing.Point(0, 375);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.ShadowDecoration.Parent = this.btnCalculator;
            this.btnCalculator.Size = new System.Drawing.Size(274, 60);
            this.btnCalculator.TabIndex = 8;
            this.btnCalculator.Text = "Calculator (F9)";
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // btnXReading
            // 
            this.btnXReading.CheckedState.Parent = this.btnXReading;
            this.btnXReading.CustomImages.Parent = this.btnXReading;
            this.btnXReading.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXReading.FillColor = System.Drawing.Color.White;
            this.btnXReading.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXReading.ForeColor = System.Drawing.Color.Black;
            this.btnXReading.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXReading.HoverState.Parent = this.btnXReading;
            this.btnXReading.Image = ((System.Drawing.Image)(resources.GetObject("btnXReading.Image")));
            this.btnXReading.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnXReading.ImageSize = new System.Drawing.Size(45, 45);
            this.btnXReading.Location = new System.Drawing.Point(0, 315);
            this.btnXReading.Name = "btnXReading";
            this.btnXReading.ShadowDecoration.Parent = this.btnXReading;
            this.btnXReading.Size = new System.Drawing.Size(274, 60);
            this.btnXReading.TabIndex = 7;
            this.btnXReading.Text = "Switch Cashier (X-Read) (F8)";
            this.btnXReading.TextOffset = new System.Drawing.Point(20, 0);
            this.btnXReading.Click += new System.EventHandler(this.btnXReading_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.CheckedState.Parent = this.btnOrder;
            this.btnOrder.CustomImages.Parent = this.btnOrder;
            this.btnOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrder.FillColor = System.Drawing.Color.White;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOrder.ForeColor = System.Drawing.Color.Black;
            this.btnOrder.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOrder.HoverState.Parent = this.btnOrder;
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOrder.ImageSize = new System.Drawing.Size(45, 45);
            this.btnOrder.Location = new System.Drawing.Point(0, 255);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.ShadowDecoration.Parent = this.btnOrder;
            this.btnOrder.Size = new System.Drawing.Size(274, 60);
            this.btnOrder.TabIndex = 6;
            this.btnOrder.Text = "Order (F2)";
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 79);
            this.panel2.TabIndex = 4;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(3, 53);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(257, 22);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "Provided By WNO ELECTRONICS TRADING";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(2, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "ECOPOS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "ver 2.0";
            // 
            // pbLogo
            // 
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLogo.Image = global::EcoPOSv2.Properties.Resources.eco_pos;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(274, 176);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 3;
            this.pbLogo.TabStop = false;
            // 
            // pnlChild
            // 
            this.pnlChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChild.Location = new System.Drawing.Point(276, 34);
            this.pnlChild.Name = "pnlChild";
            this.pnlChild.Size = new System.Drawing.Size(1164, 866);
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
            this.ClientSize = new System.Drawing.Size(1440, 900);
            this.Controls.Add(this.pnlChild);
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDateTime;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
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
    }
}