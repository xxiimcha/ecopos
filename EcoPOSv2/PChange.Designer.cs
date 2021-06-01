namespace EcoPOSv2
{
    partial class PChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PChange));
            this.lblChange = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblChange
            // 
            this.lblChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.Green;
            this.lblChange.Location = new System.Drawing.Point(8, 60);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(522, 66);
            this.lblChange.TabIndex = 38;
            this.lblChange.Text = "0.00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Green;
            this.Label9.Location = new System.Drawing.Point(8, 14);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(97, 32);
            this.Label9.TabIndex = 37;
            this.Label9.Text = "Change";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.Orange;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Orange;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button1.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2Button1.Location = new System.Drawing.Point(8, 147);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(257, 57);
            this.guna2Button1.TabIndex = 39;
            this.guna2Button1.Text = "REPRINT";
            this.guna2Button1.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderColor = System.Drawing.Color.Green;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.Green;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button2.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button2.Location = new System.Drawing.Point(273, 147);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(257, 57);
            this.guna2Button2.TabIndex = 40;
            this.guna2Button2.Text = "CONFIRM";
            this.guna2Button2.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // PChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(539, 216);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.Label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PChange";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblChange;
        internal System.Windows.Forms.Label Label9;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}