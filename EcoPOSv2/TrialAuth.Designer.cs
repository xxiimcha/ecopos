namespace EcoPOSv2
{
    partial class TrialAuth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrialAuth));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnControlBox = new Guna.UI.WinForms.GunaControlBox();
            this.MainFormElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.llFacebook = new System.Windows.Forms.LinkLabel();
            this.tbAuthKey = new System.Windows.Forms.TextBox();
            this.lblStatus = new Guna.UI.WinForms.GunaLabel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.btnControlBox);
            this.guna2Panel1.Location = new System.Drawing.Point(-20, -17);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(788, 56);
            this.guna2Panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "EcoPOS Trial Version";
            // 
            // btnControlBox
            // 
            this.btnControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControlBox.AnimationHoverSpeed = 0.07F;
            this.btnControlBox.AnimationSpeed = 0.03F;
            this.btnControlBox.IconColor = System.Drawing.Color.Black;
            this.btnControlBox.IconSize = 15F;
            this.btnControlBox.Location = new System.Drawing.Point(514, 14);
            this.btnControlBox.Name = "btnControlBox";
            this.btnControlBox.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(97)))));
            this.btnControlBox.OnHoverIconColor = System.Drawing.Color.White;
            this.btnControlBox.OnPressedColor = System.Drawing.Color.Black;
            this.btnControlBox.Size = new System.Drawing.Size(63, 42);
            this.btnControlBox.TabIndex = 1;
            // 
            // MainFormElipse
            // 
            this.MainFormElipse.BorderRadius = 25;
            this.MainFormElipse.TargetControl = this;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel1.Location = new System.Drawing.Point(80, 129);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(394, 15);
            this.gunaLabel1.TabIndex = 2;
            this.gunaLabel1.Text = "If you don\'t have an authentication key. You may contact us on Facebook";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel2.Location = new System.Drawing.Point(106, 218);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(339, 15);
            this.gunaLabel2.TabIndex = 4;
            this.gunaLabel2.Text = "This trial version of EcoPOS requires Internet Connection to use";
            // 
            // llFacebook
            // 
            this.llFacebook.AutoSize = true;
            this.llFacebook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.llFacebook.Location = new System.Drawing.Point(200, 147);
            this.llFacebook.Name = "llFacebook";
            this.llFacebook.Size = new System.Drawing.Size(138, 15);
            this.llFacebook.TabIndex = 5;
            this.llFacebook.TabStop = true;
            this.llFacebook.Text = "Facebook Link Click here";
            this.llFacebook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlFacebook_LinkClicked);
            // 
            // tbAuthKey
            // 
            this.tbAuthKey.ForeColor = System.Drawing.Color.Gray;
            this.tbAuthKey.Location = new System.Drawing.Point(23, 65);
            this.tbAuthKey.Name = "tbAuthKey";
            this.tbAuthKey.Size = new System.Drawing.Size(506, 29);
            this.tbAuthKey.TabIndex = 6;
            this.tbAuthKey.Text = "Authentication Key";
            this.tbAuthKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAuthKey.TextChanged += new System.EventHandler(this.TbAuthKey_TextChanged);
            this.tbAuthKey.Enter += new System.EventHandler(this.TbAuthKey_Enter);
            this.tbAuthKey.Leave += new System.EventHandler(this.TbAuthKey_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(20, 97);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(76, 15);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "                       ";
            // 
            // TrialAuth
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(552, 239);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tbAuthKey);
            this.Controls.Add(this.llFacebook);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrialAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrialAuth";
            this.Load += new System.EventHandler(this.TrialAuth_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Elipse MainFormElipse;
        private Guna.UI.WinForms.GunaControlBox btnControlBox;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private System.Windows.Forms.LinkLabel llFacebook;
        private System.Windows.Forms.TextBox tbAuthKey;
        private Guna.UI.WinForms.GunaLabel lblStatus;
    }
}