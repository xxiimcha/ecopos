namespace EcoPOSv2
{
    partial class RegularDiscountReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegularDiscountReport));
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.btnSort = new FontAwesome.Sharp.IconButton();
            this.btnGenerateReport = new FontAwesome.Sharp.IconButton();
            this.cmbDiscType = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.TableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AllowUserToDeleteRows = false;
            this.dgvRecords.AllowUserToResizeColumns = false;
            this.dgvRecords.AllowUserToResizeRows = false;
            this.dgvRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRecords.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecords.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRecords.Location = new System.Drawing.Point(285, 3);
            this.dgvRecords.MultiSelect = false;
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            this.dgvRecords.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecords.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecords.Size = new System.Drawing.Size(876, 860);
            this.dgvRecords.TabIndex = 38;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.25558F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.74442F));
            this.TableLayoutPanel1.Controls.Add(this.dgvRecords, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1164, 866);
            this.TableLayoutPanel1.TabIndex = 2;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TableLayoutPanel2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(276, 860);
            this.Panel1.TabIndex = 0;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel2.Controls.Add(this.Panel2, 0, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 2;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(276, 860);
            this.TableLayoutPanel2.TabIndex = 3;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.TableLayoutPanel3);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(3, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(270, 209);
            this.Panel2.TabIndex = 0;
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.ColumnCount = 3;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.40701F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.46032F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.22751F));
            this.TableLayoutPanel3.Controls.Add(this.Label13, 0, 1);
            this.TableLayoutPanel3.Controls.Add(this.Label14, 0, 2);
            this.TableLayoutPanel3.Controls.Add(this.dtpFrom, 1, 1);
            this.TableLayoutPanel3.Controls.Add(this.dtpTo, 1, 2);
            this.TableLayoutPanel3.Controls.Add(this.btnSearch, 2, 1);
            this.TableLayoutPanel3.Controls.Add(this.btnSort, 2, 2);
            this.TableLayoutPanel3.Controls.Add(this.btnGenerateReport, 1, 4);
            this.TableLayoutPanel3.Controls.Add(this.cmbDiscType, 1, 3);
            this.TableLayoutPanel3.Controls.Add(this.Label1, 0, 3);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 6;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.22488F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.09569F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.26794F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.39713F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(270, 209);
            this.TableLayoutPanel3.TabIndex = 0;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(3, 34);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(46, 35);
            this.Label13.TabIndex = 110;
            this.Label13.Text = "From";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(3, 69);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(46, 41);
            this.Label14.TabIndex = 112;
            this.Label14.Text = "To";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(55, 37);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(175, 29);
            this.dtpFrom.TabIndex = 111;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(55, 72);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(175, 29);
            this.dtpTo.TabIndex = 113;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearch.IconColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 31;
            this.btnSearch.Location = new System.Drawing.Point(236, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(31, 29);
            this.btnSearch.TabIndex = 114;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.White;
            this.btnSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSort.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnSort.FlatAppearance.BorderSize = 0;
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSort.ForeColor = System.Drawing.Color.White;
            this.btnSort.IconChar = FontAwesome.Sharp.IconChar.SortAlphaDown;
            this.btnSort.IconColor = System.Drawing.Color.Black;
            this.btnSort.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSort.IconSize = 30;
            this.btnSort.Location = new System.Drawing.Point(236, 72);
            this.btnSort.Name = "btnSort";
            this.btnSort.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnSort.Size = new System.Drawing.Size(31, 35);
            this.btnSort.TabIndex = 115;
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.Black;
            this.btnGenerateReport.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.btnGenerateReport.IconColor = System.Drawing.Color.DimGray;
            this.btnGenerateReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGenerateReport.IconSize = 31;
            this.btnGenerateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateReport.Location = new System.Drawing.Point(55, 146);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(175, 31);
            this.btnGenerateReport.TabIndex = 116;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // cmbDiscType
            // 
            this.cmbDiscType.BackColor = System.Drawing.Color.White;
            this.cmbDiscType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDiscType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDiscType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiscType.ForeColor = System.Drawing.Color.Black;
            this.cmbDiscType.FormattingEnabled = true;
            this.cmbDiscType.Items.AddRange(new object[] {
            "All",
            "Senior Citizen only",
            "PWD only",
            "Athlete only"});
            this.cmbDiscType.Location = new System.Drawing.Point(55, 113);
            this.cmbDiscType.MaxDropDownItems = 10;
            this.cmbDiscType.Name = "cmbDiscType";
            this.cmbDiscType.Size = new System.Drawing.Size(175, 29);
            this.cmbDiscType.TabIndex = 119;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(3, 110);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 33);
            this.Label1.TabIndex = 120;
            this.Label1.Text = "Type";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegularDiscountReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 866);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegularDiscountReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegularDiscountReport";
            this.Load += new System.EventHandler(this.RegularDiscountReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.TableLayoutPanel3.ResumeLayout(false);
            this.TableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvRecords;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.DateTimePicker dtpFrom;
        internal System.Windows.Forms.DateTimePicker dtpTo;
        internal FontAwesome.Sharp.IconButton btnSearch;
        internal FontAwesome.Sharp.IconButton btnSort;
        internal FontAwesome.Sharp.IconButton btnGenerateReport;
        internal System.Windows.Forms.ComboBox cmbDiscType;
        internal System.Windows.Forms.Label Label1;
    }
}