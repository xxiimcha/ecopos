namespace EcoPOSv2
{
    partial class Redeem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Redeem));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnProceed = new Guna.UI2.WinForms.Guna2Button();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.txtCardNo);
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Controls.Add(this.btnProceed);
            this.guna2Panel1.Controls.Add(this.Label2);
            this.guna2Panel1.Controls.Add(this.Label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(538, 167);
            this.guna2Panel1.TabIndex = 0;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(24, 51);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(86, 34);
            this.Label2.TabIndex = 19;
            this.Label2.Text = "CARD NO.";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(12, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(86, 25);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "REDEEM";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancel.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnCancel.ImageSize = new System.Drawing.Size(30, 30);
            this.btnCancel.Location = new System.Drawing.Point(26, 107);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(238, 45);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextOffset = new System.Drawing.Point(10, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnProceed
            // 
            this.btnProceed.BorderColor = System.Drawing.Color.Green;
            this.btnProceed.BorderRadius = 5;
            this.btnProceed.BorderThickness = 2;
            this.btnProceed.CheckedState.Parent = this.btnProceed;
            this.btnProceed.CustomImages.Parent = this.btnProceed;
            this.btnProceed.FillColor = System.Drawing.Color.White;
            this.btnProceed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProceed.ForeColor = System.Drawing.Color.Green;
            this.btnProceed.HoverState.Parent = this.btnProceed;
            this.btnProceed.Image = ((System.Drawing.Image)(resources.GetObject("btnProceed.Image")));
            this.btnProceed.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProceed.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnProceed.ImageSize = new System.Drawing.Size(30, 30);
            this.btnProceed.Location = new System.Drawing.Point(275, 107);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.ShadowDecoration.Parent = this.btnProceed;
            this.btnProceed.Size = new System.Drawing.Size(238, 45);
            this.btnProceed.TabIndex = 59;
            this.btnProceed.Text = "PROCEED";
            this.btnProceed.TextOffset = new System.Drawing.Point(10, 0);
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // txtCardNo
            // 
            this.txtCardNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNo.Location = new System.Drawing.Point(116, 55);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(397, 29);
            this.txtCardNo.TabIndex = 61;
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            // 
            // Redeem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(538, 167);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Redeem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Redeem";
            this.Load += new System.EventHandler(this.Redeem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Redeem_KeyDown);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnProceed;
        internal System.Windows.Forms.TextBox txtCardNo;
    }
}