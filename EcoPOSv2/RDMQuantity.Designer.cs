namespace EcoPOSv2
{
    partial class RDMQuantity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RDMQuantity));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnQuantity = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.lblItem = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(533, 196);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.txtQuantity);
            this.guna2Panel2.Controls.Add(this.btnQuantity);
            this.guna2Panel2.Controls.Add(this.btnConfirm);
            this.guna2Panel2.Controls.Add(this.lblItem);
            this.guna2Panel2.Controls.Add(this.Label1);
            this.guna2Panel2.Controls.Add(this.Label3);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(533, 196);
            this.guna2Panel2.TabIndex = 1;
            // 
            // btnQuantity
            // 
            this.btnQuantity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuantity.BorderRadius = 5;
            this.btnQuantity.BorderThickness = 2;
            this.btnQuantity.CheckedState.Parent = this.btnQuantity;
            this.btnQuantity.CustomImages.Parent = this.btnQuantity;
            this.btnQuantity.FillColor = System.Drawing.Color.White;
            this.btnQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuantity.HoverState.Parent = this.btnQuantity;
            this.btnQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnQuantity.Image")));
            this.btnQuantity.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuantity.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnQuantity.ImageSize = new System.Drawing.Size(30, 30);
            this.btnQuantity.Location = new System.Drawing.Point(23, 131);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.ShadowDecoration.Parent = this.btnQuantity;
            this.btnQuantity.Size = new System.Drawing.Size(238, 49);
            this.btnQuantity.TabIndex = 58;
            this.btnQuantity.Text = "CANCEL";
            this.btnQuantity.TextOffset = new System.Drawing.Point(10, 0);
            this.btnQuantity.Click += new System.EventHandler(this.BtnQuantity_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BorderColor = System.Drawing.Color.Green;
            this.btnConfirm.BorderRadius = 5;
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
            this.btnConfirm.ImageSize = new System.Drawing.Size(30, 30);
            this.btnConfirm.Location = new System.Drawing.Point(272, 131);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ShadowDecoration.Parent = this.btnConfirm;
            this.btnConfirm.Size = new System.Drawing.Size(238, 49);
            this.btnConfirm.TabIndex = 57;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.TextOffset = new System.Drawing.Point(10, 0);
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.Black;
            this.lblItem.Location = new System.Drawing.Point(107, 15);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(403, 28);
            this.lblItem.TabIndex = 56;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(18, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 28);
            this.Label1.TabIndex = 55;
            this.Label1.Text = "Item";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(21, 65);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(88, 33);
            this.Label3.TabIndex = 53;
            this.Label3.Text = "Quantity";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.Black;
            this.txtQuantity.Location = new System.Drawing.Point(112, 66);
            this.txtQuantity.Multiline = true;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(398, 33);
            this.txtQuantity.TabIndex = 57;
            this.txtQuantity.Tag = "";
            // 
            // RDMQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(533, 196);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RDMQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RDMQuantity";
            this.Load += new System.EventHandler(this.RDMQuantity_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        internal System.Windows.Forms.TextBox txtQuantity;
        private Guna.UI2.WinForms.Guna2Button btnQuantity;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        internal System.Windows.Forms.Label lblItem;
        public System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label3;
    }
}