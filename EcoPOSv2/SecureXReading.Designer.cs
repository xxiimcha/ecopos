namespace EcoPOSv2
{
    partial class SecureXReading
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnReset = new Guna.UI2.WinForms.Guna2TileButton();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(24, 62);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(354, 32);
            this.txtPassword.TabIndex = 18;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(359, 25);
            this.Label1.TabIndex = 17;
            this.Label1.Text = "Please provide your password to proceed";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.White;
            this.btnSaveSettings.BorderColor = System.Drawing.Color.IndianRed;
            this.btnSaveSettings.BorderRadius = 5;
            this.btnSaveSettings.CheckedState.Parent = this.btnSaveSettings;
            this.btnSaveSettings.CustomImages.Parent = this.btnSaveSettings;
            this.btnSaveSettings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSaveSettings.HoverState.Parent = this.btnSaveSettings;
            this.btnSaveSettings.Location = new System.Drawing.Point(31, 127);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.ShadowDecoration.Parent = this.btnSaveSettings;
            this.btnSaveSettings.Size = new System.Drawing.Size(205, 45);
            this.btnSaveSettings.TabIndex = 19;
            this.btnSaveSettings.Text = "PROCEED";
            // 
            // btnReset
            // 
            this.btnReset.BorderColor = System.Drawing.Color.IndianRed;
            this.btnReset.BorderRadius = 5;
            this.btnReset.BorderThickness = 1;
            this.btnReset.CheckedState.Parent = this.btnReset;
            this.btnReset.CustomImages.Parent = this.btnReset;
            this.btnReset.FillColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.HoverState.Parent = this.btnReset;
            this.btnReset.Location = new System.Drawing.Point(242, 127);
            this.btnReset.Name = "btnReset";
            this.btnReset.ShadowDecoration.Parent = this.btnReset;
            this.btnReset.Size = new System.Drawing.Size(123, 45);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "CANCEL";
            // 
            // SecureXReading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 184);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SecureXReading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SecureXReading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label Label1;
        private Guna.UI2.WinForms.Guna2TileButton btnSaveSettings;
        private Guna.UI2.WinForms.Guna2TileButton btnReset;
    }
}