namespace EcoPOSv2
{
    partial class Quantity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quantity));
            this.lblItem = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnQuantity = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.Black;
            this.lblItem.Location = new System.Drawing.Point(108, 25);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(403, 28);
            this.lblItem.TabIndex = 46;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 25);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(51, 28);
            this.Label1.TabIndex = 45;
            this.Label1.Text = "Item";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.Black;
            this.txtQuantity.Location = new System.Drawing.Point(113, 68);
            this.txtQuantity.Multiline = true;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(398, 33);
            this.txtQuantity.TabIndex = 44;
            this.txtQuantity.Tag = "";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(19, 68);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(88, 28);
            this.Label3.TabIndex = 43;
            this.Label3.Text = "Quantity";
            // 
            // btnQuantity
            // 
            this.btnQuantity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.btnQuantity.ImageSize = new System.Drawing.Size(40, 40);
            this.btnQuantity.Location = new System.Drawing.Point(24, 149);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.ShadowDecoration.Parent = this.btnQuantity;
            this.btnQuantity.Size = new System.Drawing.Size(238, 57);
            this.btnQuantity.TabIndex = 52;
            this.btnQuantity.Text = "CANCEL";
            this.btnQuantity.TextOffset = new System.Drawing.Point(10, 0);
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
            this.btnConfirm.Location = new System.Drawing.Point(273, 149);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ShadowDecoration.Parent = this.btnConfirm;
            this.btnConfirm.Size = new System.Drawing.Size(238, 57);
            this.btnConfirm.TabIndex = 51;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // Quantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 218);
            this.Controls.Add(this.btnQuantity);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.Label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Quantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblItem;
        public System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtQuantity;
        internal System.Windows.Forms.Label Label3;
        private Guna.UI2.WinForms.Guna2Button btnQuantity;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
    }
}