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
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.btnclosetemp = new Guna.UI2.WinForms.Guna2Button();
            this.btnMore = new Guna.UI2.WinForms.Guna2Button();
            this.btnCalculator = new Guna.UI2.WinForms.Guna2Button();
            this.btnXReading = new Guna.UI2.WinForms.Guna2Button();
            this.btnOrder = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlChild = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.tmrCurrentDateTime = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.lblDateTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 34);
            this.panel1.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(413, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(359, 32);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "010.";
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
            this.gunaPanel1.Controls.Add(this.guna2Button1);
            this.gunaPanel1.Controls.Add(this.btnclosetemp);
            this.gunaPanel1.Controls.Add(this.btnMore);
            this.gunaPanel1.Controls.Add(this.btnCalculator);
            this.gunaPanel1.Controls.Add(this.btnXReading);
            this.gunaPanel1.Controls.Add(this.btnOrder);
            this.gunaPanel1.Controls.Add(this.panel2);
            this.gunaPanel1.Controls.Add(this.pictureBox1);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 34);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(276, 866);
            this.gunaPanel1.TabIndex = 1;
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
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::EcoPOSv2.Properties.Resources.eco_pos;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pnlChild
            // 
            this.pnlChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChild.Location = new System.Drawing.Point(276, 34);
            this.pnlChild.Name = "pnlChild";
            this.pnlChild.Size = new System.Drawing.Size(1164, 866);
            this.pnlChild.TabIndex = 2;
            // 
            // guna2Button1
            // 
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(45, 45);
            this.guna2Button1.Location = new System.Drawing.Point(0, 744);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(274, 60);
            this.guna2Button1.TabIndex = 11;
            this.guna2Button1.Text = "SEE ITEM (CTRL + I)";
            this.guna2Button1.TextOffset = new System.Drawing.Point(15, 0);
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
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.gunaPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDateTime;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnOrder;
        private Guna.UI2.WinForms.Guna2Button btnclosetemp;
        public System.Windows.Forms.Label lblUser;
        public Guna.UI2.WinForms.Guna2Button btnXReading;
        public Guna.UI2.WinForms.Guna2Button btnCalculator;
        public Guna.UI2.WinForms.Guna2Button btnMore;
        public Guna.UI2.WinForms.Guna2Button guna2Button1;
        public System.Windows.Forms.Panel pnlChild;
        internal System.Windows.Forms.Timer tmrCurrentDateTime;
    }
}