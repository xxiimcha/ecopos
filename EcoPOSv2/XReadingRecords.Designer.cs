namespace EcoPOSv2
{
    partial class XReadingRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XReadingRecords));
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.CrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Label14 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.Label13 = new System.Windows.Forms.Label();
            this.btnPrint = new FontAwesome.Sharp.IconButton();
            this.btnSort = new FontAwesome.Sharp.IconButton();
            this.btnSearchDates = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
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
            this.dgvRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecords_CellClick);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.26F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.74F));
            this.TableLayoutPanel1.Controls.Add(this.dgvRecords, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1164, 866);
            this.TableLayoutPanel1.TabIndex = 113;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.CrystalReportViewer1);
            this.Panel1.Controls.Add(this.TableLayoutPanel2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(276, 860);
            this.Panel1.TabIndex = 39;
            // 
            // CrystalReportViewer1
            // 
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewer1.DisplayStatusBar = false;
            this.CrystalReportViewer1.DisplayToolbar = false;
            this.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalReportViewer1.Location = new System.Drawing.Point(0, 203);
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.Size = new System.Drawing.Size(276, 657);
            this.CrystalReportViewer1.TabIndex = 1;
            this.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 3;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.61905F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.04762F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.57143F));
            this.TableLayoutPanel2.Controls.Add(this.Label14, 0, 2);
            this.TableLayoutPanel2.Controls.Add(this.dtpTo, 1, 2);
            this.TableLayoutPanel2.Controls.Add(this.dtpFrom, 1, 1);
            this.TableLayoutPanel2.Controls.Add(this.btnSave, 1, 4);
            this.TableLayoutPanel2.Controls.Add(this.Label13, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.btnPrint, 1, 5);
            this.TableLayoutPanel2.Controls.Add(this.btnSort, 2, 2);
            this.TableLayoutPanel2.Controls.Add(this.btnSearchDates, 2, 1);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 6;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.24138F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.74877F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.418719F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.18227F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.6601F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(276, 203);
            this.TableLayoutPanel2.TabIndex = 0;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(3, 68);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(42, 34);
            this.Label14.TabIndex = 103;
            this.Label14.Text = "To";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(51, 71);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(184, 29);
            this.dtpTo.TabIndex = 104;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(51, 36);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(184, 29);
            this.dtpFrom.TabIndex = 102;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.btnSave.IconColor = System.Drawing.Color.Black;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 31;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(51, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 37);
            this.btnSave.TabIndex = 109;
            this.btnSave.Text = "Save Report";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(3, 33);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(42, 35);
            this.Label13.TabIndex = 101;
            this.Label13.Text = "From";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnPrint.IconColor = System.Drawing.Color.Black;
            this.btnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrint.IconSize = 31;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(51, 159);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(183, 41);
            this.btnPrint.TabIndex = 110;
            this.btnPrint.Text = "Print Receipt";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.btnSort.Location = new System.Drawing.Point(241, 71);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(32, 28);
            this.btnSort.TabIndex = 106;
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnSearchDates
            // 
            this.btnSearchDates.BackColor = System.Drawing.Color.White;
            this.btnSearchDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchDates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnSearchDates.FlatAppearance.BorderSize = 0;
            this.btnSearchDates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDates.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnSearchDates.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearchDates.IconColor = System.Drawing.Color.Black;
            this.btnSearchDates.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchDates.IconSize = 31;
            this.btnSearchDates.Location = new System.Drawing.Point(241, 36);
            this.btnSearchDates.Name = "btnSearchDates";
            this.btnSearchDates.Size = new System.Drawing.Size(32, 29);
            this.btnSearchDates.TabIndex = 105;
            this.btnSearchDates.UseVisualStyleBackColor = false;
            this.btnSearchDates.Click += new System.EventHandler(this.btnSearchDates_Click);
            // 
            // XReadingRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 866);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XReadingRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XReadingRecords";
            this.Load += new System.EventHandler(this.XReadingRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvRecords;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Panel Panel1;
        internal CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.DateTimePicker dtpTo;
        internal System.Windows.Forms.DateTimePicker dtpFrom;
        internal FontAwesome.Sharp.IconButton btnSave;
        internal System.Windows.Forms.Label Label13;
        internal FontAwesome.Sharp.IconButton btnPrint;
        internal FontAwesome.Sharp.IconButton btnSort;
        internal FontAwesome.Sharp.IconButton btnSearchDates;
    }
}