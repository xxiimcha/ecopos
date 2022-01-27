namespace EcoPOSv2
{
    partial class CodePlayGround
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodePlayGround));
            this.MainFormElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.Panel1Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.p1 = new System.Windows.Forms.Panel();
            this.tbEncryptedText = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbTextToEncrypt = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbDecryptedText = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbTextToDecrypt = new Guna.UI2.WinForms.Guna2TextBox();
            this.p1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormElipse
            // 
            this.MainFormElipse.BorderRadius = 25;
            this.MainFormElipse.TargetControl = this;
            // 
            // Panel1Elipse
            // 
            this.Panel1Elipse.BorderRadius = 20;
            this.Panel1Elipse.TargetControl = this.p1;
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.tbEncryptedText);
            this.p1.Controls.Add(this.tbTextToEncrypt);
            this.p1.Location = new System.Drawing.Point(34, 73);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(376, 129);
            this.p1.TabIndex = 0;
            // 
            // tbEncryptedText
            // 
            this.tbEncryptedText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEncryptedText.BorderRadius = 5;
            this.tbEncryptedText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbEncryptedText.DefaultText = "";
            this.tbEncryptedText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbEncryptedText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbEncryptedText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEncryptedText.DisabledState.Parent = this.tbEncryptedText;
            this.tbEncryptedText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEncryptedText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.tbEncryptedText.FocusedState.Parent = this.tbEncryptedText;
            this.tbEncryptedText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEncryptedText.ForeColor = System.Drawing.Color.Black;
            this.tbEncryptedText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEncryptedText.HoverState.Parent = this.tbEncryptedText;
            this.tbEncryptedText.Location = new System.Drawing.Point(22, 68);
            this.tbEncryptedText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbEncryptedText.Name = "tbEncryptedText";
            this.tbEncryptedText.PasswordChar = '\0';
            this.tbEncryptedText.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbEncryptedText.PlaceholderText = "Encrypted Text";
            this.tbEncryptedText.SelectedText = "";
            this.tbEncryptedText.ShadowDecoration.Parent = this.tbEncryptedText;
            this.tbEncryptedText.Size = new System.Drawing.Size(331, 34);
            this.tbEncryptedText.TabIndex = 2;
            // 
            // tbTextToEncrypt
            // 
            this.tbTextToEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTextToEncrypt.BorderRadius = 5;
            this.tbTextToEncrypt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTextToEncrypt.DefaultText = "";
            this.tbTextToEncrypt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTextToEncrypt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTextToEncrypt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTextToEncrypt.DisabledState.Parent = this.tbTextToEncrypt;
            this.tbTextToEncrypt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTextToEncrypt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.tbTextToEncrypt.FocusedState.Parent = this.tbTextToEncrypt;
            this.tbTextToEncrypt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTextToEncrypt.ForeColor = System.Drawing.Color.Black;
            this.tbTextToEncrypt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTextToEncrypt.HoverState.Parent = this.tbTextToEncrypt;
            this.tbTextToEncrypt.Location = new System.Drawing.Point(22, 24);
            this.tbTextToEncrypt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTextToEncrypt.Name = "tbTextToEncrypt";
            this.tbTextToEncrypt.PasswordChar = '\0';
            this.tbTextToEncrypt.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbTextToEncrypt.PlaceholderText = "Text to Encrypt";
            this.tbTextToEncrypt.SelectedText = "";
            this.tbTextToEncrypt.ShadowDecoration.Parent = this.tbTextToEncrypt;
            this.tbTextToEncrypt.Size = new System.Drawing.Size(331, 34);
            this.tbTextToEncrypt.TabIndex = 1;
            this.tbTextToEncrypt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbTextToEncrypt_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programmers Testing Form";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.gunaControlBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, -27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 75);
            this.panel1.TabIndex = 1;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(847, 27);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.Gray;
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(64, 48);
            this.gunaControlBox1.TabIndex = 2;
            this.gunaControlBox1.Click += new System.EventHandler(this.GunaControlBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tbDecryptedText);
            this.panel2.Controls.Add(this.tbTextToDecrypt);
            this.panel2.Location = new System.Drawing.Point(475, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 129);
            this.panel2.TabIndex = 3;
            // 
            // tbDecryptedText
            // 
            this.tbDecryptedText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDecryptedText.BorderRadius = 5;
            this.tbDecryptedText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDecryptedText.DefaultText = "";
            this.tbDecryptedText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbDecryptedText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbDecryptedText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDecryptedText.DisabledState.Parent = this.tbDecryptedText;
            this.tbDecryptedText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDecryptedText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.tbDecryptedText.FocusedState.Parent = this.tbDecryptedText;
            this.tbDecryptedText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDecryptedText.ForeColor = System.Drawing.Color.Black;
            this.tbDecryptedText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDecryptedText.HoverState.Parent = this.tbDecryptedText;
            this.tbDecryptedText.Location = new System.Drawing.Point(22, 68);
            this.tbDecryptedText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDecryptedText.Name = "tbDecryptedText";
            this.tbDecryptedText.PasswordChar = '\0';
            this.tbDecryptedText.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbDecryptedText.PlaceholderText = "Decrypted Text";
            this.tbDecryptedText.SelectedText = "";
            this.tbDecryptedText.ShadowDecoration.Parent = this.tbDecryptedText;
            this.tbDecryptedText.Size = new System.Drawing.Size(331, 34);
            this.tbDecryptedText.TabIndex = 2;
            // 
            // tbTextToDecrypt
            // 
            this.tbTextToDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTextToDecrypt.BorderRadius = 5;
            this.tbTextToDecrypt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTextToDecrypt.DefaultText = "";
            this.tbTextToDecrypt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTextToDecrypt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTextToDecrypt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTextToDecrypt.DisabledState.Parent = this.tbTextToDecrypt;
            this.tbTextToDecrypt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTextToDecrypt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.tbTextToDecrypt.FocusedState.Parent = this.tbTextToDecrypt;
            this.tbTextToDecrypt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTextToDecrypt.ForeColor = System.Drawing.Color.Black;
            this.tbTextToDecrypt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTextToDecrypt.HoverState.Parent = this.tbTextToDecrypt;
            this.tbTextToDecrypt.Location = new System.Drawing.Point(22, 24);
            this.tbTextToDecrypt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTextToDecrypt.Name = "tbTextToDecrypt";
            this.tbTextToDecrypt.PasswordChar = '\0';
            this.tbTextToDecrypt.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbTextToDecrypt.PlaceholderText = "Text to Decrypt";
            this.tbTextToDecrypt.SelectedText = "";
            this.tbTextToDecrypt.ShadowDecoration.Parent = this.tbTextToDecrypt;
            this.tbTextToDecrypt.Size = new System.Drawing.Size(331, 34);
            this.tbTextToDecrypt.TabIndex = 1;
            this.tbTextToDecrypt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbTextToDecrypt_KeyUp);
            // 
            // CodePlayGround
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(899, 245);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.p1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CodePlayGround";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodePlayGround";
            this.Load += new System.EventHandler(this.CodePlayGround_Load);
            this.p1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse MainFormElipse;
        private Guna.UI2.WinForms.Guna2Elipse Panel1Elipse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private System.Windows.Forms.Panel p1;
        private Guna.UI2.WinForms.Guna2TextBox tbTextToEncrypt;
        private Guna.UI2.WinForms.Guna2TextBox tbEncryptedText;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2TextBox tbDecryptedText;
        private Guna.UI2.WinForms.Guna2TextBox tbTextToDecrypt;
    }
}