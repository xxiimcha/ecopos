
namespace EcoPOSv2
{
    partial class CancelPopup
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
            this.pnlTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI.WinForms.GunaControlBox();
            this.lblTitle = new Guna.UI.WinForms.GunaLabel();
            this.tbReason = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTitle.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlTitle.BorderThickness = 1;
            this.pnlTitle.Controls.Add(this.btnClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.CustomBorderColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.ShadowDecoration.Depth = 40;
            this.pnlTitle.ShadowDecoration.Enabled = true;
            this.pnlTitle.ShadowDecoration.Parent = this.pnlTitle;
            this.pnlTitle.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlTitle.Size = new System.Drawing.Size(444, 35);
            this.pnlTitle.TabIndex = 129;
            // 
            // btnClose
            // 
            this.btnClose.AnimationHoverSpeed = 0.07F;
            this.btnClose.AnimationSpeed = 0.03F;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.IconColor = System.Drawing.Color.Black;
            this.btnClose.IconSize = 15F;
            this.btnClose.Location = new System.Drawing.Point(402, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.OnHoverIconColor = System.Drawing.Color.White;
            this.btnClose.OnPressedColor = System.Drawing.Color.Black;
            this.btnClose.Size = new System.Drawing.Size(42, 35);
            this.btnClose.TabIndex = 102;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(10, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(187, 21);
            this.lblTitle.TabIndex = 103;
            this.lblTitle.Text = "CANCEL TRANSACTION";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbReason
            // 
            this.tbReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReason.Animated = true;
            this.tbReason.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(119)))), ((int)(((byte)(252)))));
            this.tbReason.BorderRadius = 5;
            this.tbReason.BorderThickness = 2;
            this.tbReason.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbReason.DefaultText = "";
            this.tbReason.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbReason.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbReason.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbReason.DisabledState.Parent = this.tbReason;
            this.tbReason.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbReason.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbReason.FocusedState.Parent = this.tbReason;
            this.tbReason.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbReason.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbReason.HoverState.Parent = this.tbReason;
            this.tbReason.Location = new System.Drawing.Point(17, 79);
            this.tbReason.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbReason.Name = "tbReason";
            this.tbReason.PasswordChar = '\0';
            this.tbReason.PlaceholderText = "";
            this.tbReason.SelectedText = "";
            this.tbReason.ShadowDecoration.Parent = this.tbReason;
            this.tbReason.Size = new System.Drawing.Size(415, 45);
            this.tbReason.TabIndex = 0;
            this.tbReason.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbReason_KeyUp);
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel2.Location = new System.Drawing.Point(13, 46);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(163, 21);
            this.gunaLabel2.TabIndex = 132;
            this.gunaLabel2.Text = "Please select a reason:";
            this.gunaLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnConfirm.BorderRadius = 5;
            this.btnConfirm.BorderThickness = 2;
            this.btnConfirm.CheckedState.Parent = this.btnConfirm;
            this.btnConfirm.CustomImages.Parent = this.btnConfirm;
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.HoverState.BorderColor = System.Drawing.Color.Green;
            this.btnConfirm.HoverState.FillColor = System.Drawing.Color.Green;
            this.btnConfirm.HoverState.Parent = this.btnConfirm;
            this.btnConfirm.Location = new System.Drawing.Point(322, 136);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnConfirm.ShadowDecoration.Depth = 50;
            this.btnConfirm.ShadowDecoration.Parent = this.btnConfirm;
            this.btnConfirm.Size = new System.Drawing.Size(110, 41);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(214)))));
            this.btnCancel.BorderRadius = 3;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(206, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.BorderRadius = 3;
            this.btnCancel.ShadowDecoration.Depth = 50;
            this.btnCancel.ShadowDecoration.Enabled = true;
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnCancel.Size = new System.Drawing.Size(110, 41);
            this.btnCancel.TabIndex = 134;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Gray;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Controls.Add(this.tbReason);
            this.guna2Panel1.Controls.Add(this.btnConfirm);
            this.guna2Panel1.Controls.Add(this.gunaLabel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(444, 190);
            this.guna2Panel1.TabIndex = 135;
            // 
            // CancelPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 190);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CancelPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CancelPopup";
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTitle;
        private Guna.UI.WinForms.GunaControlBox btnClose;
        private Guna.UI.WinForms.GunaLabel lblTitle;
        public Guna.UI2.WinForms.Guna2TextBox tbReason;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        public Guna.UI2.WinForms.Guna2Button btnConfirm;
        public Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}