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
            this.btnContinueSession = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton2 = new Guna.UI2.WinForms.Guna2TileButton();
            this.SuspendLayout();
            // 
            // btnContinueSession
            // 
            this.btnContinueSession.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnContinueSession.BorderThickness = 1;
            this.btnContinueSession.CheckedState.Parent = this.btnContinueSession;
            this.btnContinueSession.CustomImages.Parent = this.btnContinueSession;
            this.btnContinueSession.FillColor = System.Drawing.Color.White;
            this.btnContinueSession.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinueSession.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnContinueSession.HoverState.Parent = this.btnContinueSession;
            this.btnContinueSession.Location = new System.Drawing.Point(33, 29);
            this.btnContinueSession.Name = "btnContinueSession";
            this.btnContinueSession.ShadowDecoration.Parent = this.btnContinueSession;
            this.btnContinueSession.Size = new System.Drawing.Size(248, 53);
            this.btnContinueSession.TabIndex = 72;
            this.btnContinueSession.Text = "Regular Discount";
            // 
            // guna2TileButton1
            // 
            this.guna2TileButton1.BorderColor = System.Drawing.Color.DarkOrange;
            this.guna2TileButton1.BorderThickness = 1;
            this.guna2TileButton1.CheckedState.Parent = this.guna2TileButton1;
            this.guna2TileButton1.CustomImages.Parent = this.guna2TileButton1;
            this.guna2TileButton1.FillColor = System.Drawing.Color.White;
            this.guna2TileButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton1.ForeColor = System.Drawing.Color.DarkOrange;
            this.guna2TileButton1.HoverState.Parent = this.guna2TileButton1;
            this.guna2TileButton1.Location = new System.Drawing.Point(33, 97);
            this.guna2TileButton1.Name = "guna2TileButton1";
            this.guna2TileButton1.ShadowDecoration.Parent = this.guna2TileButton1;
            this.guna2TileButton1.Size = new System.Drawing.Size(248, 53);
            this.guna2TileButton1.TabIndex = 73;
            this.guna2TileButton1.Text = "Special Discount (PWD/SC/Athlete)";
            // 
            // guna2TileButton2
            // 
            this.guna2TileButton2.BorderColor = System.Drawing.Color.Red;
            this.guna2TileButton2.BorderThickness = 1;
            this.guna2TileButton2.CheckedState.Parent = this.guna2TileButton2;
            this.guna2TileButton2.CustomImages.Parent = this.guna2TileButton2;
            this.guna2TileButton2.FillColor = System.Drawing.Color.White;
            this.guna2TileButton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton2.ForeColor = System.Drawing.Color.Red;
            this.guna2TileButton2.HoverState.Parent = this.guna2TileButton2;
            this.guna2TileButton2.Location = new System.Drawing.Point(33, 168);
            this.guna2TileButton2.Name = "guna2TileButton2";
            this.guna2TileButton2.ShadowDecoration.Parent = this.guna2TileButton2;
            this.guna2TileButton2.Size = new System.Drawing.Size(248, 53);
            this.guna2TileButton2.TabIndex = 74;
            this.guna2TileButton2.Text = "Cancel";
            // 
            // DiscountOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 251);
            this.Controls.Add(this.guna2TileButton2);
            this.Controls.Add(this.guna2TileButton1);
            this.Controls.Add(this.btnContinueSession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiscountOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiscountOption";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TileButton btnContinueSession;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton1;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton2;
    }
}