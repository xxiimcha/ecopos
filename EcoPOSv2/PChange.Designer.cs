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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PChange));
            this.lblChange = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.btnReprint = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.tmrClose = new System.Windows.Forms.Timer(this.components);
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
            // btnReprint
            // 
            this.btnReprint.BorderColor = System.Drawing.Color.Orange;
            this.btnReprint.BorderThickness = 2;
            this.btnReprint.CheckedState.Parent = this.btnReprint;
            this.btnReprint.CustomImages.Parent = this.btnReprint;
            this.btnReprint.FillColor = System.Drawing.Color.White;
            this.btnReprint.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnReprint.ForeColor = System.Drawing.Color.Orange;
            this.btnReprint.HoverState.Parent = this.btnReprint;
            this.btnReprint.Image = ((System.Drawing.Image)(resources.GetObject("btnReprint.Image")));
            this.btnReprint.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReprint.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnReprint.ImageSize = new System.Drawing.Size(35, 35);
            this.btnReprint.Location = new System.Drawing.Point(8, 147);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.ShadowDecoration.Parent = this.btnReprint;
            this.btnReprint.Size = new System.Drawing.Size(257, 57);
            this.btnReprint.TabIndex = 39;
            this.btnReprint.Text = "REPRINT";
            this.btnReprint.TextOffset = new System.Drawing.Point(10, 0);
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BorderColor = System.Drawing.Color.Green;
            this.btnConfirm.BorderThickness = 2;
            this.btnConfirm.CheckedState.Parent = this.btnConfirm;
            this.btnConfirm.CustomImages.Parent = this.btnConfirm;
            this.btnConfirm.FillColor = System.Drawing.Color.White;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.Green;
            this.btnConfirm.HoverState.Parent = this.btnConfirm;
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnConfirm.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnConfirm.ImageSize = new System.Drawing.Size(40, 40);
            this.btnConfirm.Location = new System.Drawing.Point(273, 147);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ShadowDecoration.Parent = this.btnConfirm;
            this.btnConfirm.Size = new System.Drawing.Size(257, 57);
            this.btnConfirm.TabIndex = 40;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.TextOffset = new System.Drawing.Point(10, 0);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tmrClose
            // 
            this.tmrClose.Interval = 1000;
            this.tmrClose.Tick += new System.EventHandler(this.tmrClose_Tick);
            // 
            // PChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(539, 216);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.Label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PChange";
            this.Load += new System.EventHandler(this.PChange_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PChange_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblChange;
        internal System.Windows.Forms.Label Label9;
        private Guna.UI2.WinForms.Guna2Button btnReprint;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        internal System.Windows.Forms.Timer tmrClose;
    }
}