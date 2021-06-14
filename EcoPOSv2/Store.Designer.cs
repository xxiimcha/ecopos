namespace EcoPOSv2
{
    partial class Store
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnPrintersDevices = new FontAwesome.Sharp.IconButton();
            this.btnEditReceiptFooter = new FontAwesome.Sharp.IconButton();
            this.btnSeeStoreDetails = new FontAwesome.Sharp.IconButton();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.btnPrintersDevices);
            this.Panel1.Controls.Add(this.btnEditReceiptFooter);
            this.Panel1.Controls.Add(this.btnSeeStoreDetails);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1164, 866);
            this.Panel1.TabIndex = 9;
            // 
            // btnPrintersDevices
            // 
            this.btnPrintersDevices.BackColor = System.Drawing.Color.White;
            this.btnPrintersDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrintersDevices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnPrintersDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintersDevices.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintersDevices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(47)))), ((int)(((byte)(53)))));
            this.btnPrintersDevices.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.btnPrintersDevices.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(47)))), ((int)(((byte)(53)))));
            this.btnPrintersDevices.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrintersDevices.IconSize = 30;
            this.btnPrintersDevices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintersDevices.Location = new System.Drawing.Point(0, 106);
            this.btnPrintersDevices.Name = "btnPrintersDevices";
            this.btnPrintersDevices.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPrintersDevices.Size = new System.Drawing.Size(1164, 53);
            this.btnPrintersDevices.TabIndex = 5;
            this.btnPrintersDevices.Text = "Printers and Devices";
            this.btnPrintersDevices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintersDevices.UseVisualStyleBackColor = false;
            this.btnPrintersDevices.Click += new System.EventHandler(this.BtnPrintersDevices_Click);
            // 
            // btnEditReceiptFooter
            // 
            this.btnEditReceiptFooter.BackColor = System.Drawing.Color.White;
            this.btnEditReceiptFooter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditReceiptFooter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnEditReceiptFooter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditReceiptFooter.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditReceiptFooter.ForeColor = System.Drawing.Color.Purple;
            this.btnEditReceiptFooter.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnEditReceiptFooter.IconColor = System.Drawing.Color.Purple;
            this.btnEditReceiptFooter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditReceiptFooter.IconSize = 30;
            this.btnEditReceiptFooter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditReceiptFooter.Location = new System.Drawing.Point(0, 53);
            this.btnEditReceiptFooter.Name = "btnEditReceiptFooter";
            this.btnEditReceiptFooter.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEditReceiptFooter.Size = new System.Drawing.Size(1164, 53);
            this.btnEditReceiptFooter.TabIndex = 4;
            this.btnEditReceiptFooter.Text = "Edit Receipt Footer Text";
            this.btnEditReceiptFooter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditReceiptFooter.UseVisualStyleBackColor = false;
            this.btnEditReceiptFooter.Click += new System.EventHandler(this.BtnEditReceiptFooter_Click);
            // 
            // btnSeeStoreDetails
            // 
            this.btnSeeStoreDetails.BackColor = System.Drawing.Color.White;
            this.btnSeeStoreDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSeeStoreDetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnSeeStoreDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeeStoreDetails.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeeStoreDetails.ForeColor = System.Drawing.Color.Navy;
            this.btnSeeStoreDetails.IconChar = FontAwesome.Sharp.IconChar.Store;
            this.btnSeeStoreDetails.IconColor = System.Drawing.Color.Navy;
            this.btnSeeStoreDetails.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSeeStoreDetails.IconSize = 30;
            this.btnSeeStoreDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeeStoreDetails.Location = new System.Drawing.Point(0, 0);
            this.btnSeeStoreDetails.Name = "btnSeeStoreDetails";
            this.btnSeeStoreDetails.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSeeStoreDetails.Size = new System.Drawing.Size(1164, 53);
            this.btnSeeStoreDetails.TabIndex = 3;
            this.btnSeeStoreDetails.Text = "See Store Details";
            this.btnSeeStoreDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeeStoreDetails.UseVisualStyleBackColor = false;
            this.btnSeeStoreDetails.Click += new System.EventHandler(this.BtnSeeStoreDetails_Click);
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1164, 866);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Store";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store";
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal FontAwesome.Sharp.IconButton btnPrintersDevices;
        internal FontAwesome.Sharp.IconButton btnEditReceiptFooter;
        internal FontAwesome.Sharp.IconButton btnSeeStoreDetails;
    }
}