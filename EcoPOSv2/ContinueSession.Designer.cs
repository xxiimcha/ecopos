namespace EcoPOSv2
{
    partial class ContinueSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContinueSession));
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.tbCSPassword = new System.Windows.Forms.TextBox();
            this.lblCS_Username = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnContinueSession = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnLoginAdmin = new Guna.UI2.WinForms.Guna2TileButton();
            this.label6 = new System.Windows.Forms.Label();
            this.lbLoginCard = new System.Windows.Forms.LinkLabel();
            this.lblLoginCardAdmin = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(405, 2);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(61, 52);
            this.gunaControlBox1.TabIndex = 0;
            this.gunaControlBox1.Click += new System.EventHandler(this.gunaControlBox1_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.Color.White;
            this.tbUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.ForeColor = System.Drawing.Color.Black;
            this.tbUsername.Location = new System.Drawing.Point(121, 396);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(320, 32);
            this.tbUsername.TabIndex = 69;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(27, 436);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 21);
            this.Label5.TabIndex = 68;
            this.Label5.Text = "Password:";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.White;
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.ForeColor = System.Drawing.Color.Black;
            this.tbPassword.Location = new System.Drawing.Point(121, 433);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(320, 32);
            this.tbPassword.TabIndex = 70;
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(27, 400);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(84, 21);
            this.Label7.TabIndex = 67;
            this.Label7.Text = "Username:";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.DimGray;
            this.Label4.Location = new System.Drawing.Point(27, 239);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(414, 141);
            this.Label4.TabIndex = 66;
            this.Label4.Text = resources.GetString("Label4.Text");
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(27, 147);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(79, 21);
            this.Label3.TabIndex = 65;
            this.Label3.Text = "Password:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCSPassword
            // 
            this.tbCSPassword.BackColor = System.Drawing.Color.White;
            this.tbCSPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCSPassword.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCSPassword.ForeColor = System.Drawing.Color.Black;
            this.tbCSPassword.Location = new System.Drawing.Point(121, 144);
            this.tbCSPassword.Name = "tbCSPassword";
            this.tbCSPassword.PasswordChar = '*';
            this.tbCSPassword.Size = new System.Drawing.Size(320, 32);
            this.tbCSPassword.TabIndex = 64;
            this.tbCSPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCSPassword_KeyDown);
            this.tbCSPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbCSPassword_KeyUp);
            // 
            // lblCS_Username
            // 
            this.lblCS_Username.AutoSize = true;
            this.lblCS_Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCS_Username.ForeColor = System.Drawing.Color.Black;
            this.lblCS_Username.Location = new System.Drawing.Point(117, 111);
            this.lblCS_Username.Name = "lblCS_Username";
            this.lblCS_Username.Size = new System.Drawing.Size(40, 21);
            this.lblCS_Username.TabIndex = 63;
            this.lblCS_Username.Text = "user";
            this.lblCS_Username.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(27, 111);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(84, 21);
            this.Label2.TabIndex = 62;
            this.Label2.Text = "Username:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.DimGray;
            this.Label1.Location = new System.Drawing.Point(27, 80);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(384, 21);
            this.Label1.TabIndex = 61;
            this.Label1.Text = "Please provide your password to continue this session";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnContinueSession
            // 
            this.btnContinueSession.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnContinueSession.BorderRadius = 5;
            this.btnContinueSession.BorderThickness = 1;
            this.btnContinueSession.CheckedState.Parent = this.btnContinueSession;
            this.btnContinueSession.CustomImages.Parent = this.btnContinueSession;
            this.btnContinueSession.FillColor = System.Drawing.Color.White;
            this.btnContinueSession.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinueSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnContinueSession.HoverState.Parent = this.btnContinueSession;
            this.btnContinueSession.Location = new System.Drawing.Point(231, 182);
            this.btnContinueSession.Name = "btnContinueSession";
            this.btnContinueSession.ShadowDecoration.Parent = this.btnContinueSession;
            this.btnContinueSession.Size = new System.Drawing.Size(210, 40);
            this.btnContinueSession.TabIndex = 71;
            this.btnContinueSession.Text = "Continue Session";
            this.btnContinueSession.Click += new System.EventHandler(this.btnContinueSession_Click);
            // 
            // btnLoginAdmin
            // 
            this.btnLoginAdmin.BorderColor = System.Drawing.Color.Navy;
            this.btnLoginAdmin.BorderRadius = 5;
            this.btnLoginAdmin.BorderThickness = 1;
            this.btnLoginAdmin.CheckedState.Parent = this.btnLoginAdmin;
            this.btnLoginAdmin.CustomImages.Parent = this.btnLoginAdmin;
            this.btnLoginAdmin.FillColor = System.Drawing.Color.White;
            this.btnLoginAdmin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginAdmin.ForeColor = System.Drawing.Color.Navy;
            this.btnLoginAdmin.HoverState.Parent = this.btnLoginAdmin;
            this.btnLoginAdmin.Location = new System.Drawing.Point(231, 471);
            this.btnLoginAdmin.Name = "btnLoginAdmin";
            this.btnLoginAdmin.ShadowDecoration.Parent = this.btnLoginAdmin;
            this.btnLoginAdmin.Size = new System.Drawing.Size(210, 40);
            this.btnLoginAdmin.TabIndex = 72;
            this.btnLoginAdmin.Text = "Login Administrator";
            this.btnLoginAdmin.Click += new System.EventHandler(this.btnLoginAdmin_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(261, 30);
            this.label6.TabIndex = 73;
            this.label6.Text = "SESSION INTERRUPTION";
            // 
            // lbLoginCard
            // 
            this.lbLoginCard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoginCard.Location = new System.Drawing.Point(45, 187);
            this.lbLoginCard.Name = "lbLoginCard";
            this.lbLoginCard.Size = new System.Drawing.Size(155, 29);
            this.lbLoginCard.TabIndex = 75;
            this.lbLoginCard.TabStop = true;
            this.lbLoginCard.Text = "LOGIN VIA CARD";
            this.lbLoginCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoginCard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbLoginCard_LinkClicked);
            // 
            // lblLoginCardAdmin
            // 
            this.lblLoginCardAdmin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginCardAdmin.Location = new System.Drawing.Point(45, 476);
            this.lblLoginCardAdmin.Name = "lblLoginCardAdmin";
            this.lblLoginCardAdmin.Size = new System.Drawing.Size(155, 29);
            this.lblLoginCardAdmin.TabIndex = 76;
            this.lblLoginCardAdmin.TabStop = true;
            this.lblLoginCardAdmin.Text = "LOGIN VIA CARD";
            this.lblLoginCardAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLoginCardAdmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLoginCardAdmin_LinkClicked);
            // 
            // ContinueSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(468, 535);
            this.Controls.Add(this.lblLoginCardAdmin);
            this.Controls.Add(this.lbLoginCard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnLoginAdmin);
            this.Controls.Add(this.btnContinueSession);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.tbCSPassword);
            this.Controls.Add(this.lblCS_Username);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.gunaControlBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ContinueSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ContinueSession";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContinueSession_FormClosing);
            this.Load += new System.EventHandler(this.ContinueSession_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContinueSession_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblCS_Username;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox tbUsername;
        public System.Windows.Forms.TextBox tbPassword;
        public System.Windows.Forms.TextBox tbCSPassword;
        public Guna.UI2.WinForms.Guna2TileButton btnContinueSession;
        public Guna.UI2.WinForms.Guna2TileButton btnLoginAdmin;
        private System.Windows.Forms.LinkLabel lbLoginCard;
        private System.Windows.Forms.LinkLabel lblLoginCardAdmin;
    }
}