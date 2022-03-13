﻿namespace EcoPOSv2
{
    partial class SpecialDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialDiscount));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.cmbDesc = new System.Windows.Forms.ComboBox();
            this.txtIDNo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Controls.Add(this.btnConfirm);
            this.guna2Panel1.Controls.Add(this.cmbDesc);
            this.guna2Panel1.Controls.Add(this.txtIDNo);
            this.guna2Panel1.Controls.Add(this.txtName);
            this.guna2Panel1.Controls.Add(this.Label3);
            this.guna2Panel1.Controls.Add(this.Label1);
            this.guna2Panel1.Controls.Add(this.Label2);
            this.guna2Panel1.Location = new System.Drawing.Point(2, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(530, 219);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button1.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button1.Location = new System.Drawing.Point(20, 151);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(238, 57);
            this.guna2Button1.TabIndex = 62;
            this.guna2Button1.Text = "CANCEL";
            this.guna2Button1.TextOffset = new System.Drawing.Point(10, 0);
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
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
            this.btnConfirm.ImageSize = new System.Drawing.Size(40, 40);
            this.btnConfirm.Location = new System.Drawing.Point(274, 151);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ShadowDecoration.Parent = this.btnConfirm;
            this.btnConfirm.Size = new System.Drawing.Size(238, 57);
            this.btnConfirm.TabIndex = 61;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.TextOffset = new System.Drawing.Point(10, 0);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cmbDesc
            // 
            this.cmbDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDesc.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDesc.ForeColor = System.Drawing.Color.Black;
            this.cmbDesc.FormattingEnabled = true;
            this.cmbDesc.Items.AddRange(new object[] {
            "Senior Citizen",
            "Person with Disability",
            "Athlete"});
            this.cmbDesc.Location = new System.Drawing.Point(149, 12);
            this.cmbDesc.MaxDropDownItems = 10;
            this.cmbDesc.Name = "cmbDesc";
            this.cmbDesc.Size = new System.Drawing.Size(363, 31);
            this.cmbDesc.TabIndex = 60;
            // 
            // txtIDNo
            // 
            this.txtIDNo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDNo.ForeColor = System.Drawing.Color.Black;
            this.txtIDNo.Location = new System.Drawing.Point(149, 100);
            this.txtIDNo.Multiline = true;
            this.txtIDNo.Name = "txtIDNo";
            this.txtIDNo.Size = new System.Drawing.Size(363, 33);
            this.txtIDNo.TabIndex = 59;
            this.txtIDNo.Tag = "";
            this.txtIDNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDNo_KeyDown);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(149, 54);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(363, 33);
            this.txtName.TabIndex = 58;
            this.txtName.Tag = "";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(15, 54);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(64, 28);
            this.Label3.TabIndex = 57;
            this.Label3.Text = "Name";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(15, 102);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 28);
            this.Label1.TabIndex = 56;
            this.Label1.Text = "ID No.";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(15, 10);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(112, 28);
            this.Label2.TabIndex = 55;
            this.Label2.Text = "Description";
            // 
            // SpecialDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(533, 223);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpecialDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpecialDiscount";
            this.Load += new System.EventHandler(this.SpecialDiscount_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        internal System.Windows.Forms.ComboBox cmbDesc;
        internal System.Windows.Forms.TextBox txtIDNo;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
    }
}