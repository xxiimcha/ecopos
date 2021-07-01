namespace EcoPOSv2
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlChild = new System.Windows.Forms.Panel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnOR = new FontAwesome.Sharp.IconButton();
            this.btnWarehouse = new FontAwesome.Sharp.IconButton();
            this.btnSupplier = new FontAwesome.Sharp.IconButton();
            this.btnReturn = new FontAwesome.Sharp.IconButton();
            this.btnPurchase = new FontAwesome.Sharp.IconButton();
            this.btnInventory = new FontAwesome.Sharp.IconButton();
            this.guna2Panel1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.pnlChild);
            this.guna2Panel1.Controls.Add(this.Panel1);
            this.guna2Panel1.Location = new System.Drawing.Point(1, 1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1162, 864);
            this.guna2Panel1.TabIndex = 0;
            // 
            // pnlChild
            // 
            this.pnlChild.BackColor = System.Drawing.Color.White;
            this.pnlChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChild.Location = new System.Drawing.Point(0, 39);
            this.pnlChild.Name = "pnlChild";
            this.pnlChild.Size = new System.Drawing.Size(1162, 825);
            this.pnlChild.TabIndex = 7;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.btnOR);
            this.Panel1.Controls.Add(this.btnWarehouse);
            this.Panel1.Controls.Add(this.btnSupplier);
            this.Panel1.Controls.Add(this.btnReturn);
            this.Panel1.Controls.Add(this.btnPurchase);
            this.Panel1.Controls.Add(this.btnInventory);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1162, 39);
            this.Panel1.TabIndex = 6;
            // 
            // btnOR
            // 
            this.btnOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOR.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnOR.FlatAppearance.BorderSize = 2;
            this.btnOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOR.ForeColor = System.Drawing.Color.Black;
            this.btnOR.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnOR.IconColor = System.Drawing.Color.White;
            this.btnOR.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOR.IconSize = 30;
            this.btnOR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOR.Location = new System.Drawing.Point(548, 0);
            this.btnOR.Name = "btnOR";
            this.btnOR.Size = new System.Drawing.Size(145, 39);
            this.btnOR.TabIndex = 13;
            this.btnOR.Text = "Operation Record";
            this.btnOR.UseVisualStyleBackColor = false;
            this.btnOR.Click += new System.EventHandler(this.BtnOR_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWarehouse.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnWarehouse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnWarehouse.FlatAppearance.BorderSize = 2;
            this.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWarehouse.ForeColor = System.Drawing.Color.Black;
            this.btnWarehouse.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnWarehouse.IconColor = System.Drawing.Color.White;
            this.btnWarehouse.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWarehouse.IconSize = 30;
            this.btnWarehouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWarehouse.Location = new System.Drawing.Point(439, 0);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(109, 39);
            this.btnWarehouse.TabIndex = 14;
            this.btnWarehouse.Text = "Warehouse";
            this.btnWarehouse.UseVisualStyleBackColor = false;
            this.btnWarehouse.Click += new System.EventHandler(this.BtnWarehouse_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSupplier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnSupplier.FlatAppearance.BorderSize = 2;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.Color.Black;
            this.btnSupplier.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSupplier.IconColor = System.Drawing.Color.White;
            this.btnSupplier.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSupplier.IconSize = 30;
            this.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.Location = new System.Drawing.Point(330, 0);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(109, 39);
            this.btnSupplier.TabIndex = 12;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.BtnSupplier_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReturn.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReturn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnReturn.FlatAppearance.BorderSize = 2;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.Black;
            this.btnReturn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnReturn.IconColor = System.Drawing.Color.White;
            this.btnReturn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReturn.IconSize = 30;
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(221, 0);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(109, 39);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPurchase.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPurchase.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnPurchase.FlatAppearance.BorderSize = 2;
            this.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.ForeColor = System.Drawing.Color.Black;
            this.btnPurchase.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPurchase.IconColor = System.Drawing.Color.White;
            this.btnPurchase.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPurchase.IconSize = 30;
            this.btnPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchase.Location = new System.Drawing.Point(112, 0);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(109, 39);
            this.btnPurchase.TabIndex = 8;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.BtnPurchase_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(147)))), ((int)(((byte)(214)))));
            this.btnInventory.FlatAppearance.BorderSize = 2;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.Black;
            this.btnInventory.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnInventory.IconColor = System.Drawing.Color.White;
            this.btnInventory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInventory.IconSize = 30;
            this.btnInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Location = new System.Drawing.Point(0, 0);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(112, 39);
            this.btnInventory.TabIndex = 7;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.BtnInventory_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 866);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        internal System.Windows.Forms.Panel pnlChild;
        internal System.Windows.Forms.Panel Panel1;
        internal FontAwesome.Sharp.IconButton btnOR;
        internal FontAwesome.Sharp.IconButton btnWarehouse;
        internal FontAwesome.Sharp.IconButton btnSupplier;
        internal FontAwesome.Sharp.IconButton btnReturn;
        internal FontAwesome.Sharp.IconButton btnPurchase;
        internal FontAwesome.Sharp.IconButton btnInventory;
    }
}