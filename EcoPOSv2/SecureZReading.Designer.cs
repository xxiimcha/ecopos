namespace EcoPOSv2
{
    partial class SecureZReading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecureZReading));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnProceed = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnCancel = new Guna.UI2.WinForms.Guna2TileButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnProceed);
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Controls.Add(this.txtPassword);
            this.guna2Panel1.Controls.Add(this.Label1);
            this.guna2Panel1.Location = new System.Drawing.Point(2, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(392, 181);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnProceed
            // 
            this.btnProceed.BackColor = System.Drawing.Color.White;
            this.btnProceed.BorderColor = System.Drawing.Color.IndianRed;
            this.btnProceed.BorderRadius = 5;
            this.btnProceed.CheckedState.Parent = this.btnProceed;
            this.btnProceed.CustomImages.Parent = this.btnProceed;
            this.btnProceed.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(96)))), ((int)(((byte)(25)))));
            this.btnProceed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.ForeColor = System.Drawing.Color.White;
            this.btnProceed.HoverState.Parent = this.btnProceed;
            this.btnProceed.Location = new System.Drawing.Point(158, 121);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.ShadowDecoration.Parent = this.btnProceed;
            this.btnProceed.Size = new System.Drawing.Size(205, 45);
            this.btnProceed.TabIndex = 1;
            this.btnProceed.Text = "PROCEED";
            this.btnProceed.Click += new System.EventHandler(this.BtnProceed_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(29, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(123, 45);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(22, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(354, 32);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(17, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(359, 25);
            this.Label1.TabIndex = 21;
            this.Label1.Text = "Please provide your password to proceed";
            // 
            // SecureZReading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 184);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SecureZReading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SecureZReading";
            this.Load += new System.EventHandler(this.SecureZReading_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TileButton btnProceed;
        private Guna.UI2.WinForms.Guna2TileButton btnCancel;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label Label1;
    }
}