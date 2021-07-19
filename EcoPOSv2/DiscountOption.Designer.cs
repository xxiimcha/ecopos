namespace EcoPOSv2
{
    partial class DiscountOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscountOption));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnContinueSession = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Controls.Add(this.guna2TileButton1);
            this.guna2Panel1.Controls.Add(this.btnContinueSession);
            this.guna2Panel1.Location = new System.Drawing.Point(2, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(310, 246);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.Red;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(31, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(248, 53);
            this.btnCancel.TabIndex = 77;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // guna2TileButton1
            // 
            this.guna2TileButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.guna2TileButton1.BorderThickness = 2;
            this.guna2TileButton1.CheckedState.Parent = this.guna2TileButton1;
            this.guna2TileButton1.CustomImages.Parent = this.guna2TileButton1;
            this.guna2TileButton1.FillColor = System.Drawing.Color.White;
            this.guna2TileButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.guna2TileButton1.HoverState.Parent = this.guna2TileButton1;
            this.guna2TileButton1.Location = new System.Drawing.Point(31, 95);
            this.guna2TileButton1.Name = "guna2TileButton1";
            this.guna2TileButton1.ShadowDecoration.Parent = this.guna2TileButton1;
            this.guna2TileButton1.Size = new System.Drawing.Size(248, 53);
            this.guna2TileButton1.TabIndex = 76;
            this.guna2TileButton1.Text = "Special Discount (PWD/SC/Athlete)";
            this.guna2TileButton1.Click += new System.EventHandler(this.guna2TileButton1_Click);
            // 
            // btnContinueSession
            // 
            this.btnContinueSession.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnContinueSession.BorderThickness = 2;
            this.btnContinueSession.CheckedState.Parent = this.btnContinueSession;
            this.btnContinueSession.CustomImages.Parent = this.btnContinueSession;
            this.btnContinueSession.FillColor = System.Drawing.Color.White;
            this.btnContinueSession.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinueSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(96)))), ((int)(((byte)(25)))));
            this.btnContinueSession.HoverState.Parent = this.btnContinueSession;
            this.btnContinueSession.Location = new System.Drawing.Point(31, 27);
            this.btnContinueSession.Name = "btnContinueSession";
            this.btnContinueSession.ShadowDecoration.Parent = this.btnContinueSession;
            this.btnContinueSession.Size = new System.Drawing.Size(248, 53);
            this.btnContinueSession.TabIndex = 75;
            this.btnContinueSession.Text = "Regular Discount";
            this.btnContinueSession.Click += new System.EventHandler(this.btnContinueSession_Click);
            // 
            // DiscountOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(315, 251);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "DiscountOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiscountOption";
            this.Load += new System.EventHandler(this.DiscountOption_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DiscountOption_KeyDown);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TileButton btnCancel;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton1;
        private Guna.UI2.WinForms.Guna2TileButton btnContinueSession;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}