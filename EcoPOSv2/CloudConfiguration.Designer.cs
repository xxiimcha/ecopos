namespace EcoPOSv2
{
    partial class CloudConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloudConfiguration));
            this.MainFormDragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.MainFormElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbDBName1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbDBName2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.btnSyncFromServer = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormDragControl
            // 
            this.MainFormDragControl.TargetControl = this;
            // 
            // MainFormElipse
            // 
            this.MainFormElipse.BorderRadius = 25;
            this.MainFormElipse.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(162)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.gunaControlBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-19, -45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 100);
            this.panel1.TabIndex = 0;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.White;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(431, 44);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(97)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(71, 56);
            this.gunaControlBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cloudbase Database Configuration";
            // 
            // tbServerName
            // 
            this.tbServerName.BorderRadius = 5;
            this.tbServerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbServerName.DefaultText = "";
            this.tbServerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbServerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbServerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbServerName.DisabledState.Parent = this.tbServerName;
            this.tbServerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbServerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.tbServerName.FocusedState.Parent = this.tbServerName;
            this.tbServerName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServerName.ForeColor = System.Drawing.Color.Black;
            this.tbServerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbServerName.HoverState.Parent = this.tbServerName;
            this.tbServerName.Location = new System.Drawing.Point(60, 96);
            this.tbServerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.PasswordChar = '\0';
            this.tbServerName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbServerName.PlaceholderText = "Server Name/Server IP";
            this.tbServerName.SelectedText = "";
            this.tbServerName.ShadowDecoration.Parent = this.tbServerName;
            this.tbServerName.Size = new System.Drawing.Size(369, 34);
            this.tbServerName.TabIndex = 2;
            this.tbServerName.TextChanged += new System.EventHandler(this.TbServerName_TextChanged);
            // 
            // tbDBName1
            // 
            this.tbDBName1.BorderRadius = 5;
            this.tbDBName1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDBName1.DefaultText = "";
            this.tbDBName1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbDBName1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbDBName1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDBName1.DisabledState.Parent = this.tbDBName1;
            this.tbDBName1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDBName1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.tbDBName1.FocusedState.Parent = this.tbDBName1;
            this.tbDBName1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDBName1.ForeColor = System.Drawing.Color.Black;
            this.tbDBName1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDBName1.HoverState.Parent = this.tbDBName1;
            this.tbDBName1.Location = new System.Drawing.Point(60, 140);
            this.tbDBName1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDBName1.Name = "tbDBName1";
            this.tbDBName1.PasswordChar = '\0';
            this.tbDBName1.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbDBName1.PlaceholderText = "Database Name EcoPOS";
            this.tbDBName1.SelectedText = "";
            this.tbDBName1.ShadowDecoration.Parent = this.tbDBName1;
            this.tbDBName1.Size = new System.Drawing.Size(369, 34);
            this.tbDBName1.TabIndex = 3;
            this.tbDBName1.TextChanged += new System.EventHandler(this.TbDBName1_TextChanged);
            // 
            // tbDBName2
            // 
            this.tbDBName2.BorderRadius = 5;
            this.tbDBName2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDBName2.DefaultText = "";
            this.tbDBName2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbDBName2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbDBName2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDBName2.DisabledState.Parent = this.tbDBName2;
            this.tbDBName2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDBName2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(221)))), ((int)(((byte)(119)))));
            this.tbDBName2.FocusedState.Parent = this.tbDBName2;
            this.tbDBName2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDBName2.ForeColor = System.Drawing.Color.Black;
            this.tbDBName2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDBName2.HoverState.Parent = this.tbDBName2;
            this.tbDBName2.Location = new System.Drawing.Point(60, 184);
            this.tbDBName2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDBName2.Name = "tbDBName2";
            this.tbDBName2.PasswordChar = '\0';
            this.tbDBName2.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbDBName2.PlaceholderText = "Database Name EcoPOS Training";
            this.tbDBName2.SelectedText = "";
            this.tbDBName2.ShadowDecoration.Parent = this.tbDBName2;
            this.tbDBName2.Size = new System.Drawing.Size(369, 34);
            this.tbDBName2.TabIndex = 4;
            this.tbDBName2.TextChanged += new System.EventHandler(this.TbDBName2_TextChanged);
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.panel1;
            // 
            // btnSyncFromServer
            // 
            this.btnSyncFromServer.BorderRadius = 5;
            this.btnSyncFromServer.CheckedState.Parent = this.btnSyncFromServer;
            this.btnSyncFromServer.CustomImages.Parent = this.btnSyncFromServer;
            this.btnSyncFromServer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.btnSyncFromServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncFromServer.ForeColor = System.Drawing.Color.White;
            this.btnSyncFromServer.HoverState.Parent = this.btnSyncFromServer;
            this.btnSyncFromServer.Location = new System.Drawing.Point(85, 60);
            this.btnSyncFromServer.Name = "btnSyncFromServer";
            this.btnSyncFromServer.ShadowDecoration.Parent = this.btnSyncFromServer;
            this.btnSyncFromServer.Size = new System.Drawing.Size(273, 37);
            this.btnSyncFromServer.TabIndex = 9;
            this.btnSyncFromServer.Text = "Restore Database From Server";
            this.btnSyncFromServer.Click += new System.EventHandler(this.BtnSyncFromServer_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderRadius = 8;
            this.guna2GroupBox1.Controls.Add(this.rtbStatus);
            this.guna2GroupBox1.Controls.Add(this.btnSyncFromServer);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(22, 241);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(433, 321);
            this.guna2GroupBox1.TabIndex = 10;
            this.guna2GroupBox1.Text = "Options";
            // 
            // rtbStatus
            // 
            this.rtbStatus.Location = new System.Drawing.Point(16, 123);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.ReadOnly = true;
            this.rtbStatus.Size = new System.Drawing.Size(400, 178);
            this.rtbStatus.TabIndex = 10;
            this.rtbStatus.Text = "";
            // 
            // CloudConfiguration
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(479, 580);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.tbDBName2);
            this.Controls.Add(this.tbDBName1);
            this.Controls.Add(this.tbServerName);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CloudConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CloudConfiguration";
            this.Load += new System.EventHandler(this.CloudConfiguration_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DragControl MainFormDragControl;
        private Guna.UI2.WinForms.Guna2Elipse MainFormElipse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private Guna.UI2.WinForms.Guna2TextBox tbDBName2;
        private Guna.UI2.WinForms.Guna2TextBox tbDBName1;
        private Guna.UI2.WinForms.Guna2TextBox tbServerName;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        public Guna.UI2.WinForms.Guna2TileButton btnSyncFromServer;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.RichTextBox rtbStatus;
    }
}