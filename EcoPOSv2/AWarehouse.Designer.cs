namespace EcoPOSv2
{
    partial class AWarehouse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.btnTransfer = new FontAwesome.Sharp.IconButton();
            this.dgvFromWarehouse = new System.Windows.Forms.DataGridView();
            this.btnRemoveItem = new FontAwesome.Sharp.IconButton();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.btnSelectAll = new FontAwesome.Sharp.IconButton();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.cmbWarehouseFrom = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnRemoveAll = new FontAwesome.Sharp.IconButton();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.cmbWarehouseTo = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvToWarehouse = new System.Windows.Forms.DataGridView();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.txtSearchWarehouse = new System.Windows.Forms.TextBox();
            this.btnSort = new FontAwesome.Sharp.IconButton();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.btnDeleteWarehouse = new FontAwesome.Sharp.IconButton();
            this.dgvWarehouse = new System.Windows.Forms.DataGridView();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFromWarehouse)).BeginInit();
            this.Panel7.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel6.SuspendLayout();
            this.TableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToWarehouse)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).BeginInit();
            this.Panel4.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(446, 37);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Transfer items to another warehouse";
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearch.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 27;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 41);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchItem.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearchItem.Location = new System.Drawing.Point(3, 85);
            this.txtSearchItem.Multiline = true;
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(481, 39);
            this.txtSearchItem.TabIndex = 29;
            this.txtSearchItem.Tag = "Search item";
            this.txtSearchItem.Text = "Search item";
            this.txtSearchItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchItem_KeyUp);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTransfer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnTransfer.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            this.btnTransfer.IconColor = System.Drawing.Color.ForestGreen;
            this.btnTransfer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTransfer.IconSize = 27;
            this.btnTransfer.Location = new System.Drawing.Point(728, 130);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTransfer.Size = new System.Drawing.Size(244, 41);
            this.btnTransfer.TabIndex = 35;
            this.btnTransfer.Text = "Transfer warehouse";
            this.btnTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // dgvFromWarehouse
            // 
            this.dgvFromWarehouse.AllowUserToAddRows = false;
            this.dgvFromWarehouse.AllowUserToDeleteRows = false;
            this.dgvFromWarehouse.AllowUserToResizeColumns = false;
            this.dgvFromWarehouse.AllowUserToResizeRows = false;
            this.dgvFromWarehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFromWarehouse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFromWarehouse.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvFromWarehouse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFromWarehouse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFromWarehouse.ColumnHeadersHeight = 6;
            this.dgvFromWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFromWarehouse.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFromWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFromWarehouse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFromWarehouse.GridColor = System.Drawing.SystemColors.Control;
            this.dgvFromWarehouse.Location = new System.Drawing.Point(3, 177);
            this.dgvFromWarehouse.MultiSelect = false;
            this.dgvFromWarehouse.Name = "dgvFromWarehouse";
            this.dgvFromWarehouse.ReadOnly = true;
            this.dgvFromWarehouse.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFromWarehouse.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFromWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFromWarehouse.Size = new System.Drawing.Size(481, 677);
            this.dgvFromWarehouse.TabIndex = 36;
            this.dgvFromWarehouse.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFromWarehouse_CellClick);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(22)))), ((int)(((byte)(47)))));
            this.btnRemoveItem.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnRemoveItem.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(22)))), ((int)(((byte)(47)))));
            this.btnRemoveItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRemoveItem.IconSize = 27;
            this.btnRemoveItem.Location = new System.Drawing.Point(728, 85);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            this.btnRemoveItem.Size = new System.Drawing.Size(244, 39);
            this.btnRemoveItem.TabIndex = 33;
            this.btnRemoveItem.Text = "Remove item";
            this.btnRemoveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // Panel7
            // 
            this.Panel7.Controls.Add(this.btnSearch);
            this.Panel7.Controls.Add(this.btnSelectAll);
            this.Panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel7.Location = new System.Drawing.Point(3, 130);
            this.Panel7.Name = "Panel7";
            this.Panel7.Size = new System.Drawing.Size(481, 41);
            this.Panel7.TabIndex = 39;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.ForeColor = System.Drawing.Color.Orange;
            this.btnSelectAll.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnSelectAll.IconColor = System.Drawing.Color.Orange;
            this.btnSelectAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSelectAll.IconSize = 27;
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.Location = new System.Drawing.Point(237, 0);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(244, 41);
            this.btnSelectAll.TabIndex = 31;
            this.btnSelectAll.Text = "Select all in this table";
            this.btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.ForeColor = System.Drawing.Color.White;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(108, 6);
            this.cmbCategory.MaxDropDownItems = 10;
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(371, 31);
            this.cmbCategory.TabIndex = 29;
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(0, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(110, 40);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Category";
            // 
            // Panel5
            // 
            this.Panel5.Controls.Add(this.cmbCategory);
            this.Panel5.Controls.Add(this.Label3);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel5.Location = new System.Drawing.Point(3, 39);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(481, 40);
            this.Panel5.TabIndex = 28;
            // 
            // cmbWarehouseFrom
            // 
            this.cmbWarehouseFrom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbWarehouseFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouseFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWarehouseFrom.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouseFrom.ForeColor = System.Drawing.Color.White;
            this.cmbWarehouseFrom.FormattingEnabled = true;
            this.cmbWarehouseFrom.Location = new System.Drawing.Point(109, -1);
            this.cmbWarehouseFrom.MaxDropDownItems = 10;
            this.cmbWarehouseFrom.Name = "cmbWarehouseFrom";
            this.cmbWarehouseFrom.Size = new System.Drawing.Size(372, 31);
            this.cmbWarehouseFrom.TabIndex = 26;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(109, 28);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Warehouse";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btnRemoveAll.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnRemoveAll.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btnRemoveAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRemoveAll.IconSize = 27;
            this.btnRemoveAll.Location = new System.Drawing.Point(728, 39);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(244, 40);
            this.btnRemoveAll.TabIndex = 34;
            this.btnRemoveAll.Text = "Remove all in this table";
            this.btnRemoveAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.cmbWarehouseFrom);
            this.Panel3.Controls.Add(this.Label2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(3, 3);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(481, 30);
            this.Panel3.TabIndex = 27;
            // 
            // cmbWarehouseTo
            // 
            this.cmbWarehouseTo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbWarehouseTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbWarehouseTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouseTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWarehouseTo.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouseTo.ForeColor = System.Drawing.Color.White;
            this.cmbWarehouseTo.FormattingEnabled = true;
            this.cmbWarehouseTo.Location = new System.Drawing.Point(103, 0);
            this.cmbWarehouseTo.MaxDropDownItems = 10;
            this.cmbWarehouseTo.Name = "cmbWarehouseTo";
            this.cmbWarehouseTo.Size = new System.Drawing.Size(379, 31);
            this.cmbWarehouseTo.TabIndex = 26;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(0, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(103, 28);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Transfer to";
            // 
            // Panel6
            // 
            this.Panel6.Controls.Add(this.cmbWarehouseTo);
            this.Panel6.Controls.Add(this.Label4);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel6.Location = new System.Drawing.Point(490, 3);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(482, 30);
            this.Panel6.TabIndex = 38;
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.ColumnCount = 2;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel3.Controls.Add(this.Panel6, 1, 0);
            this.TableLayoutPanel3.Controls.Add(this.btnRemoveAll, 1, 1);
            this.TableLayoutPanel3.Controls.Add(this.Panel3, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.Panel5, 0, 1);
            this.TableLayoutPanel3.Controls.Add(this.txtSearchItem, 0, 2);
            this.TableLayoutPanel3.Controls.Add(this.btnTransfer, 1, 3);
            this.TableLayoutPanel3.Controls.Add(this.dgvFromWarehouse, 0, 4);
            this.TableLayoutPanel3.Controls.Add(this.dgvToWarehouse, 1, 4);
            this.TableLayoutPanel3.Controls.Add(this.btnRemoveItem, 1, 2);
            this.TableLayoutPanel3.Controls.Add(this.Panel7, 0, 3);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 37);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 5;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.261646F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.367561F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.250875F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.484247F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.46324F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(975, 857);
            this.TableLayoutPanel3.TabIndex = 10;
            // 
            // dgvToWarehouse
            // 
            this.dgvToWarehouse.AllowUserToAddRows = false;
            this.dgvToWarehouse.AllowUserToDeleteRows = false;
            this.dgvToWarehouse.AllowUserToResizeColumns = false;
            this.dgvToWarehouse.AllowUserToResizeRows = false;
            this.dgvToWarehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToWarehouse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvToWarehouse.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvToWarehouse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToWarehouse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvToWarehouse.ColumnHeadersHeight = 6;
            this.dgvToWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToWarehouse.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvToWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvToWarehouse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvToWarehouse.GridColor = System.Drawing.SystemColors.Control;
            this.dgvToWarehouse.Location = new System.Drawing.Point(490, 177);
            this.dgvToWarehouse.MultiSelect = false;
            this.dgvToWarehouse.Name = "dgvToWarehouse";
            this.dgvToWarehouse.ReadOnly = true;
            this.dgvToWarehouse.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToWarehouse.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvToWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToWarehouse.Size = new System.Drawing.Size(482, 677);
            this.dgvToWarehouse.TabIndex = 37;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.TableLayoutPanel3);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(462, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(975, 894);
            this.Panel2.TabIndex = 1;
            // 
            // txtSearchWarehouse
            // 
            this.txtSearchWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchWarehouse.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchWarehouse.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearchWarehouse.Location = new System.Drawing.Point(0, 0);
            this.txtSearchWarehouse.Multiline = true;
            this.txtSearchWarehouse.Name = "txtSearchWarehouse";
            this.txtSearchWarehouse.Size = new System.Drawing.Size(277, 36);
            this.txtSearchWarehouse.TabIndex = 25;
            this.txtSearchWarehouse.Tag = "Search warehouse";
            this.txtSearchWarehouse.Text = "Search warehouse";
            this.txtSearchWarehouse.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchWarehouse_KeyUp);
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.White;
            this.btnSort.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSort.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnSort.FlatAppearance.BorderSize = 0;
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSort.ForeColor = System.Drawing.Color.White;
            this.btnSort.IconChar = FontAwesome.Sharp.IconChar.SortAlphaUp;
            this.btnSort.IconColor = System.Drawing.Color.DimGray;
            this.btnSort.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSort.IconSize = 30;
            this.btnSort.Location = new System.Drawing.Point(277, 0);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(47, 36);
            this.btnSort.TabIndex = 27;
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(51)))));
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAdd.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(51)))));
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 30;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(324, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(41, 36);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(165)))), ((int)(((byte)(238)))));
            this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnEdit.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(165)))), ((int)(((byte)(238)))));
            this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEdit.IconSize = 30;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(365, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnEdit.Size = new System.Drawing.Size(41, 36);
            this.btnEdit.TabIndex = 28;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDeleteWarehouse
            // 
            this.btnDeleteWarehouse.BackColor = System.Drawing.Color.White;
            this.btnDeleteWarehouse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteWarehouse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnDeleteWarehouse.FlatAppearance.BorderSize = 0;
            this.btnDeleteWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteWarehouse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteWarehouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(22)))), ((int)(((byte)(47)))));
            this.btnDeleteWarehouse.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDeleteWarehouse.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(22)))), ((int)(((byte)(47)))));
            this.btnDeleteWarehouse.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDeleteWarehouse.IconSize = 30;
            this.btnDeleteWarehouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteWarehouse.Location = new System.Drawing.Point(406, 0);
            this.btnDeleteWarehouse.Name = "btnDeleteWarehouse";
            this.btnDeleteWarehouse.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnDeleteWarehouse.Size = new System.Drawing.Size(41, 36);
            this.btnDeleteWarehouse.TabIndex = 23;
            this.btnDeleteWarehouse.UseVisualStyleBackColor = false;
            this.btnDeleteWarehouse.Click += new System.EventHandler(this.btnDeleteWarehouse_Click);
            // 
            // dgvWarehouse
            // 
            this.dgvWarehouse.AllowUserToAddRows = false;
            this.dgvWarehouse.AllowUserToDeleteRows = false;
            this.dgvWarehouse.AllowUserToResizeColumns = false;
            this.dgvWarehouse.AllowUserToResizeRows = false;
            this.dgvWarehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarehouse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvWarehouse.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvWarehouse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWarehouse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWarehouse.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWarehouse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvWarehouse.GridColor = System.Drawing.SystemColors.Control;
            this.dgvWarehouse.Location = new System.Drawing.Point(3, 45);
            this.dgvWarehouse.MultiSelect = false;
            this.dgvWarehouse.Name = "dgvWarehouse";
            this.dgvWarehouse.ReadOnly = true;
            this.dgvWarehouse.RowHeadersVisible = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWarehouse.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouse.Size = new System.Drawing.Size(447, 846);
            this.dgvWarehouse.TabIndex = 9;
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.txtSearchWarehouse);
            this.Panel4.Controls.Add(this.btnSort);
            this.Panel4.Controls.Add(this.btnAdd);
            this.Panel4.Controls.Add(this.btnEdit);
            this.Panel4.Controls.Add(this.btnDeleteWarehouse);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 3);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(447, 36);
            this.Panel4.TabIndex = 8;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel2.Controls.Add(this.dgvWarehouse, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.Panel4, 0, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 2;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.697987F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.30202F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(453, 894);
            this.TableLayoutPanel2.TabIndex = 0;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TableLayoutPanel2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(453, 894);
            this.Panel1.TabIndex = 0;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.88586F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.11414F));
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Panel2, 1, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1440, 900);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // AWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1440, 900);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AWarehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AWarehouse";
            this.Load += new System.EventHandler(this.AWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFromWarehouse)).EndInit();
            this.Panel7.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel6.ResumeLayout(false);
            this.Panel6.PerformLayout();
            this.TableLayoutPanel3.ResumeLayout(false);
            this.TableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToWarehouse)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.TableLayoutPanel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal FontAwesome.Sharp.IconButton btnSearch;
        internal System.Windows.Forms.TextBox txtSearchItem;
        internal FontAwesome.Sharp.IconButton btnTransfer;
        internal System.Windows.Forms.DataGridView dgvFromWarehouse;
        internal FontAwesome.Sharp.IconButton btnRemoveItem;
        internal System.Windows.Forms.Panel Panel7;
        internal FontAwesome.Sharp.IconButton btnSelectAll;
        internal System.Windows.Forms.ComboBox cmbCategory;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.ComboBox cmbWarehouseFrom;
        internal System.Windows.Forms.Label Label2;
        internal FontAwesome.Sharp.IconButton btnRemoveAll;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.ComboBox cmbWarehouseTo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal System.Windows.Forms.DataGridView dgvToWarehouse;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.TextBox txtSearchWarehouse;
        internal FontAwesome.Sharp.IconButton btnSort;
        internal FontAwesome.Sharp.IconButton btnAdd;
        internal FontAwesome.Sharp.IconButton btnEdit;
        internal FontAwesome.Sharp.IconButton btnDeleteWarehouse;
        internal System.Windows.Forms.DataGridView dgvWarehouse;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
    }
}