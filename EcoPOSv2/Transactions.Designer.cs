namespace EcoPOSv2
{
    partial class Transactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transactions));
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvRecords = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Label13 = new System.Windows.Forms.Label();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Label14 = new System.Windows.Forms.Label();
            this.cmbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReprint = new FontAwesome.Sharp.IconButton();
            this.btnGenerateReport = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportDGVToExcel = new Guna.UI2.WinForms.Guna2Button();
            this.CrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.Controls.Add(this.dgvRecords, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.guna2Panel1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.guna2Panel2, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 1, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1090, 734);
            this.TableLayoutPanel1.TabIndex = 2;
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AllowUserToDeleteRows = false;
            this.dgvRecords.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRecords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRecords.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecords.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecords.ColumnHeadersHeight = 40;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecords.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecords.EnableHeadersVisualStyles = false;
            this.dgvRecords.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecords.Location = new System.Drawing.Point(3, 54);
            this.dgvRecords.MultiSelect = false;
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRecords.RowHeadersVisible = false;
            this.dgvRecords.RowTemplate.DividerHeight = 1;
            this.dgvRecords.RowTemplate.Height = 35;
            this.dgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecords.Size = new System.Drawing.Size(811, 677);
            this.dgvRecords.TabIndex = 1;
            this.dgvRecords.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvRecords.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecords.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRecords.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRecords.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRecords.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRecords.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecords.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecords.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvRecords.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRecords.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvRecords.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRecords.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecords.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvRecords.ThemeStyle.ReadOnly = true;
            this.dgvRecords.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecords.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecords.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvRecords.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRecords.ThemeStyle.RowsStyle.Height = 35;
            this.dgvRecords.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecords.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecords_CellContentClick);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.dtpFrom);
            this.guna2Panel1.Controls.Add(this.Label13);
            this.guna2Panel1.Controls.Add(this.dtpTo);
            this.guna2Panel1.Controls.Add(this.Label14);
            this.guna2Panel1.Controls.Add(this.cmbType);
            this.guna2Panel1.Controls.Add(this.Label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(811, 45);
            this.guna2Panel1.TabIndex = 122;
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
            this.dtpFrom.TabIndex = 121;
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
            this.Label13.TabIndex = 110;
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
            this.dtpTo.TabIndex = 122;
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
            this.Label14.TabIndex = 112;
            this.Label14.Text = "TO";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.BackColor = System.Drawing.Color.Transparent;
            this.cmbType.BorderColor = System.Drawing.Color.Black;
            this.cmbType.BorderRadius = 5;
            this.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FocusedColor = System.Drawing.Color.Empty;
            this.cmbType.FocusedState.Parent = this.cmbType;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.HoverState.Parent = this.cmbType;
            this.cmbType.ItemHeight = 30;
            this.cmbType.Items.AddRange(new object[] {
            "All",
            "Order",
            "Void"});
            this.cmbType.ItemsAppearance.Parent = this.cmbType;
            this.cmbType.Location = new System.Drawing.Point(631, 4);
            this.cmbType.Name = "cmbType";
            this.cmbType.ShadowDecoration.Parent = this.cmbType;
            this.cmbType.Size = new System.Drawing.Size(176, 36);
            this.cmbType.TabIndex = 123;
            this.cmbType.SelectedValueChanged += new System.EventHandler(this.cmbType_SelectedValueChanged);
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(584, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 36);
            this.Label1.TabIndex = 120;
            this.Label1.Text = "TYPE";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.tableLayoutPanel2);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(820, 3);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(267, 45);
            this.guna2Panel2.TabIndex = 123;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnReprint, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGenerateReport, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(267, 45);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnReprint
            // 
            this.btnReprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReprint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnReprint.FlatAppearance.BorderSize = 0;
            this.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReprint.ForeColor = System.Drawing.Color.Black;
            this.btnReprint.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnReprint.IconColor = System.Drawing.Color.Black;
            this.btnReprint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReprint.IconSize = 24;
            this.btnReprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprint.Location = new System.Drawing.Point(3, 3);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(127, 39);
            this.btnReprint.TabIndex = 117;
            this.btnReprint.Text = "Reprint Receipt";
            this.btnReprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.Black;
            this.btnGenerateReport.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.btnGenerateReport.IconColor = System.Drawing.Color.Black;
            this.btnGenerateReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGenerateReport.IconSize = 24;
            this.btnGenerateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateReport.Location = new System.Drawing.Point(136, 3);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(128, 39);
            this.btnGenerateReport.TabIndex = 116;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.btnExportDGVToExcel, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.CrystalReportViewer1, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(820, 54);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(267, 677);
            this.tableLayoutPanel8.TabIndex = 124;
            // 
            // btnExportDGVToExcel
            // 
            this.btnExportDGVToExcel.BackColor = System.Drawing.Color.White;
            this.btnExportDGVToExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnExportDGVToExcel.BorderRadius = 5;
            this.btnExportDGVToExcel.BorderThickness = 2;
            this.btnExportDGVToExcel.CheckedState.Parent = this.btnExportDGVToExcel;
            this.btnExportDGVToExcel.CustomImages.Parent = this.btnExportDGVToExcel;
            this.btnExportDGVToExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportDGVToExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnExportDGVToExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportDGVToExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportDGVToExcel.HoverState.BorderColor = System.Drawing.Color.Green;
            this.btnExportDGVToExcel.HoverState.FillColor = System.Drawing.Color.Green;
            this.btnExportDGVToExcel.HoverState.Parent = this.btnExportDGVToExcel;
            this.btnExportDGVToExcel.Location = new System.Drawing.Point(3, 3);
            this.btnExportDGVToExcel.Name = "btnExportDGVToExcel";
            this.btnExportDGVToExcel.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExportDGVToExcel.ShadowDecoration.Depth = 50;
            this.btnExportDGVToExcel.ShadowDecoration.Parent = this.btnExportDGVToExcel;
            this.btnExportDGVToExcel.Size = new System.Drawing.Size(261, 41);
            this.btnExportDGVToExcel.TabIndex = 125;
            this.btnExportDGVToExcel.Text = "EXPORT TO EXCEL";
            this.btnExportDGVToExcel.Click += new System.EventHandler(this.btnExportDGVToExcel_Click);
            // 
            // CrystalReportViewer1
            // 
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewer1.DisplayStatusBar = false;
            this.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalReportViewer1.Location = new System.Drawing.Point(0, 47);
            this.CrystalReportViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.ShowCloseButton = false;
            this.CrystalReportViewer1.ShowCopyButton = false;
            this.CrystalReportViewer1.ShowExportButton = false;
            this.CrystalReportViewer1.ShowGotoPageButton = false;
            this.CrystalReportViewer1.ShowGroupTreeButton = false;
            this.CrystalReportViewer1.ShowLogo = false;
            this.CrystalReportViewer1.ShowPageNavigateButtons = false;
            this.CrystalReportViewer1.ShowParameterPanelButton = false;
            this.CrystalReportViewer1.ShowPrintButton = false;
            this.CrystalReportViewer1.ShowRefreshButton = false;
            this.CrystalReportViewer1.Size = new System.Drawing.Size(267, 630);
            this.CrystalReportViewer1.TabIndex = 2;
            this.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Transactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 734);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Transactions_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        private Guna.UI2.WinForms.Guna2ComboBox cmbType;
        internal Guna.UI2.WinForms.Guna2DataGridView dgvRecords;
        internal FontAwesome.Sharp.IconButton btnGenerateReport;
        internal FontAwesome.Sharp.IconButton btnReprint;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        public Guna.UI2.WinForms.Guna2Button btnExportDGVToExcel;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer1;
    }
}