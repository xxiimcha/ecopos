namespace EcoPOSv2
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChild = new System.Windows.Forms.Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDatabaseManagement = new FontAwesome.Sharp.IconButton();
            this.btnDeveloper = new FontAwesome.Sharp.IconButton();
            this.btnStaff = new FontAwesome.Sharp.IconButton();
            this.btnStore = new FontAwesome.Sharp.IconButton();
            this.guna2Panel1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.TableLayoutPanel2);
            this.guna2Panel1.Location = new System.Drawing.Point(1, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1090, 734);
            this.guna2Panel1.TabIndex = 0;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel2.Controls.Add(this.pnlChild, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.guna2Panel2, 0, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 2;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.598985F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.40102F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(1090, 734);
            this.TableLayoutPanel2.TabIndex = 24;
            // 
            // pnlChild
            // 
            this.pnlChild.BackColor = System.Drawing.Color.White;
            this.pnlChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChild.Location = new System.Drawing.Point(3, 51);
            this.pnlChild.Name = "pnlChild";
            this.pnlChild.Size = new System.Drawing.Size(1084, 680);
            this.pnlChild.TabIndex = 7;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btnDatabaseManagement);
            this.guna2Panel2.Controls.Add(this.btnDeveloper);
            this.guna2Panel2.Controls.Add(this.btnStaff);
            this.guna2Panel2.Controls.Add(this.btnStore);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(1084, 42);
            this.guna2Panel2.TabIndex = 8;
            // 
            // btnDatabaseManagement
            // 
            this.btnDatabaseManagement.BackColor = System.Drawing.Color.White;
            this.btnDatabaseManagement.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDatabaseManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDatabaseManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabaseManagement.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatabaseManagement.ForeColor = System.Drawing.Color.Black;
            this.btnDatabaseManagement.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDatabaseManagement.IconColor = System.Drawing.Color.White;
            this.btnDatabaseManagement.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDatabaseManagement.IconSize = 30;
            this.btnDatabaseManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatabaseManagement.Location = new System.Drawing.Point(513, 0);
            this.btnDatabaseManagement.Name = "btnDatabaseManagement";
            this.btnDatabaseManagement.Size = new System.Drawing.Size(271, 42);
            this.btnDatabaseManagement.TabIndex = 14;
            this.btnDatabaseManagement.Text = "DATABASE MANAGEMENT";
            this.btnDatabaseManagement.UseVisualStyleBackColor = false;
            this.btnDatabaseManagement.Click += new System.EventHandler(this.btnDatabackup_Click);
            // 
            // btnDeveloper
            // 
            this.btnDeveloper.BackColor = System.Drawing.Color.White;
            this.btnDeveloper.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeveloper.Enabled = false;
            this.btnDeveloper.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeveloper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeveloper.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeveloper.ForeColor = System.Drawing.Color.Black;
            this.btnDeveloper.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDeveloper.IconColor = System.Drawing.Color.White;
            this.btnDeveloper.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDeveloper.IconSize = 30;
            this.btnDeveloper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeveloper.Location = new System.Drawing.Point(342, 0);
            this.btnDeveloper.Name = "btnDeveloper";
            this.btnDeveloper.Size = new System.Drawing.Size(171, 42);
            this.btnDeveloper.TabIndex = 13;
            this.btnDeveloper.Text = "DEVELOPER";
            this.btnDeveloper.UseVisualStyleBackColor = false;
            this.btnDeveloper.Visible = false;
            this.btnDeveloper.Click += new System.EventHandler(this.BtnDeveloper_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.White;
            this.btnStaff.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStaff.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.Color.Black;
            this.btnStaff.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnStaff.IconColor = System.Drawing.Color.White;
            this.btnStaff.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStaff.IconSize = 30;
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.Location = new System.Drawing.Point(171, 0);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(171, 42);
            this.btnStaff.TabIndex = 10;
            this.btnStaff.Text = "STAFF";
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.BtnStaff_Click);
            // 
            // btnStore
            // 
            this.btnStore.BackColor = System.Drawing.Color.White;
            this.btnStore.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStore.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStore.ForeColor = System.Drawing.Color.Black;
            this.btnStore.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnStore.IconColor = System.Drawing.Color.White;
            this.btnStore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStore.IconSize = 30;
            this.btnStore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStore.Location = new System.Drawing.Point(0, 0);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(171, 42);
            this.btnStore.TabIndex = 9;
            this.btnStore.Text = "STORE";
            this.btnStore.UseVisualStyleBackColor = false;
            this.btnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 734);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        internal FontAwesome.Sharp.IconButton btnDeveloper;
        internal FontAwesome.Sharp.IconButton btnStaff;
        internal FontAwesome.Sharp.IconButton btnStore;
        internal FontAwesome.Sharp.IconButton btnDatabaseManagement;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Panel pnlChild;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
    }
}