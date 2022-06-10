namespace EcoPOSv2
{
    partial class VoidReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoidReport));
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Label13 = new System.Windows.Forms.Label();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Label14 = new System.Windows.Forms.Label();
            this.btnSaveReport = new FontAwesome.Sharp.IconButton();
            this.dgv_VoidReport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnExportDGVToExcel = new Guna.UI2.WinForms.Guna2Button();
            this.TableLayoutPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VoidReport)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TableLayoutPanel1.Controls.Add(this.guna2Panel1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.dgv_VoidReport, 0, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1090, 734);
            this.TableLayoutPanel1.TabIndex = 5;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.dtpFrom);
            this.guna2Panel1.Controls.Add(this.Label13);
            this.guna2Panel1.Controls.Add(this.dtpTo);
            this.guna2Panel1.Controls.Add(this.Label14);
            this.guna2Panel1.Controls.Add(this.btnSaveReport);
            this.guna2Panel1.Controls.Add(this.btnExportDGVToExcel);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1084, 45);
            this.guna2Panel1.TabIndex = 39;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFrom.BorderRadius = 5;
            this.dtpFrom.BorderThickness = 1;
            this.dtpFrom.CheckedState.Parent = this.dtpFrom;
            this.dtpFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpFrom.FillColor = System.Drawing.Color.White;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.ForeColor = System.Drawing.Color.Black;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.HoverState.Parent = this.dtpFrom;
            this.dtpFrom.Location = new System.Drawing.Point(62, 4);
            this.dtpFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShadowDecoration.Parent = this.dtpFrom;
            this.dtpFrom.Size = new System.Drawing.Size(173, 36);
            this.dtpFrom.TabIndex = 132;
            this.dtpFrom.Tag = "From";
            this.dtpFrom.Value = new System.DateTime(2021, 11, 22, 8, 55, 16, 532);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // Label13
            // 
            this.Label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label13.BackColor = System.Drawing.Color.Transparent;
            this.Label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(3, 4);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(59, 36);
            this.Label13.TabIndex = 130;
            this.Label13.Text = "FROM";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpTo.BorderRadius = 5;
            this.dtpTo.BorderThickness = 1;
            this.dtpTo.CheckedState.Parent = this.dtpTo;
            this.dtpTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpTo.FillColor = System.Drawing.Color.White;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.ForeColor = System.Drawing.Color.Black;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.HoverState.Parent = this.dtpTo;
            this.dtpTo.Location = new System.Drawing.Point(284, 4);
            this.dtpTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShadowDecoration.Parent = this.dtpTo;
            this.dtpTo.Size = new System.Drawing.Size(176, 36);
            this.dtpTo.TabIndex = 133;
            this.dtpTo.Tag = "To";
            this.dtpTo.Value = new System.DateTime(2021, 11, 22, 8, 55, 16, 532);
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // Label14
            // 
            this.Label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label14.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(251, 1);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(41, 42);
            this.Label14.TabIndex = 131;
            this.Label14.Text = "TO";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveReport
            // 
            this.btnSaveReport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnSaveReport.FlatAppearance.BorderSize = 0;
            this.btnSaveReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveReport.ForeColor = System.Drawing.Color.Black;
            this.btnSaveReport.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.btnSaveReport.IconColor = System.Drawing.Color.DimGray;
            this.btnSaveReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSaveReport.IconSize = 31;
            this.btnSaveReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveReport.Location = new System.Drawing.Point(734, 0);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(185, 45);
            this.btnSaveReport.TabIndex = 116;
            this.btnSaveReport.Text = "Generate Report";
            this.btnSaveReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveReport.UseVisualStyleBackColor = true;
            this.btnSaveReport.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgv_VoidReport
            // 
            this.dgv_VoidReport.AllowUserToAddRows = false;
            this.dgv_VoidReport.AllowUserToDeleteRows = false;
            this.dgv_VoidReport.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_VoidReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_VoidReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_VoidReport.BackgroundColor = System.Drawing.Color.White;
            this.dgv_VoidReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_VoidReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_VoidReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_VoidReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_VoidReport.ColumnHeadersHeight = 40;
            this.dgv_VoidReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_VoidReport.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_VoidReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_VoidReport.EnableHeadersVisualStyles = false;
            this.dgv_VoidReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_VoidReport.Location = new System.Drawing.Point(3, 54);
            this.dgv_VoidReport.MultiSelect = false;
            this.dgv_VoidReport.Name = "dgv_VoidReport";
            this.dgv_VoidReport.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_VoidReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_VoidReport.RowHeadersVisible = false;
            this.dgv_VoidReport.RowTemplate.DividerHeight = 1;
            this.dgv_VoidReport.RowTemplate.Height = 35;
            this.dgv_VoidReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_VoidReport.Size = new System.Drawing.Size(1084, 677);
            this.dgv_VoidReport.TabIndex = 40;
            this.dgv_VoidReport.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgv_VoidReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_VoidReport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_VoidReport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_VoidReport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_VoidReport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_VoidReport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_VoidReport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_VoidReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_VoidReport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_VoidReport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgv_VoidReport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_VoidReport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_VoidReport.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_VoidReport.ThemeStyle.ReadOnly = true;
            this.dgv_VoidReport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_VoidReport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_VoidReport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgv_VoidReport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_VoidReport.ThemeStyle.RowsStyle.Height = 35;
            this.dgv_VoidReport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_VoidReport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnExportDGVToExcel
            // 
            this.btnExportDGVToExcel.BackColor = System.Drawing.Color.White;
            this.btnExportDGVToExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnExportDGVToExcel.BorderRadius = 5;
            this.btnExportDGVToExcel.BorderThickness = 2;
            this.btnExportDGVToExcel.CheckedState.Parent = this.btnExportDGVToExcel;
            this.btnExportDGVToExcel.CustomImages.Parent = this.btnExportDGVToExcel;
            this.btnExportDGVToExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportDGVToExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnExportDGVToExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportDGVToExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportDGVToExcel.HoverState.BorderColor = System.Drawing.Color.Green;
            this.btnExportDGVToExcel.HoverState.FillColor = System.Drawing.Color.Green;
            this.btnExportDGVToExcel.HoverState.Parent = this.btnExportDGVToExcel;
            this.btnExportDGVToExcel.Location = new System.Drawing.Point(919, 0);
            this.btnExportDGVToExcel.Name = "btnExportDGVToExcel";
            this.btnExportDGVToExcel.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExportDGVToExcel.ShadowDecoration.Depth = 50;
            this.btnExportDGVToExcel.ShadowDecoration.Parent = this.btnExportDGVToExcel;
            this.btnExportDGVToExcel.Size = new System.Drawing.Size(165, 45);
            this.btnExportDGVToExcel.TabIndex = 134;
            this.btnExportDGVToExcel.Text = "EXPORT TO EXCEL";
            this.btnExportDGVToExcel.Click += new System.EventHandler(this.btnExportDGVToExcel_Click);
            // 
            // VoidReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 734);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VoidReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoidReport";
            this.Load += new System.EventHandler(this.VoidReport_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VoidReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        internal FontAwesome.Sharp.IconButton btnSaveReport;
        internal Guna.UI2.WinForms.Guna2DataGridView dgv_VoidReport;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        internal System.Windows.Forms.Label Label13;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        internal System.Windows.Forms.Label Label14;
        public Guna.UI2.WinForms.Guna2Button btnExportDGVToExcel;
    }
}