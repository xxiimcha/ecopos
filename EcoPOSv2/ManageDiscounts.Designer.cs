namespace EcoPOSv2
{
    partial class ManageDiscounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDiscounts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnProduct_Delete = new Guna.UI2.WinForms.Guna2Button();
            this.btnProduct_Save = new Guna.UI2.WinForms.Guna2Button();
            this.btnNew = new FontAwesome.Sharp.IconButton();
            this.rbAmount = new System.Windows.Forms.RadioButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.rbPercentage = new System.Windows.Forms.RadioButton();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDiscount = new Guna.UI2.WinForms.Guna2DataGridView();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel2.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProduct_Delete
            // 
            this.btnProduct_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProduct_Delete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnProduct_Delete.BorderThickness = 2;
            this.btnProduct_Delete.CheckedState.Parent = this.btnProduct_Delete;
            this.btnProduct_Delete.CustomImages.Parent = this.btnProduct_Delete;
            this.btnProduct_Delete.FillColor = System.Drawing.Color.White;
            this.btnProduct_Delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProduct_Delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnProduct_Delete.HoverState.Parent = this.btnProduct_Delete;
            this.btnProduct_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct_Delete.Image")));
            this.btnProduct_Delete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProduct_Delete.ImageSize = new System.Drawing.Size(30, 30);
            this.btnProduct_Delete.Location = new System.Drawing.Point(132, 671);
            this.btnProduct_Delete.Name = "btnProduct_Delete";
            this.btnProduct_Delete.ShadowDecoration.Parent = this.btnProduct_Delete;
            this.btnProduct_Delete.Size = new System.Drawing.Size(135, 39);
            this.btnProduct_Delete.TabIndex = 1;
            this.btnProduct_Delete.Text = "DELETE";
            this.btnProduct_Delete.TextOffset = new System.Drawing.Point(10, 0);
            this.btnProduct_Delete.Click += new System.EventHandler(this.BtnProduct_Delete_Click);
            // 
            // btnProduct_Save
            // 
            this.btnProduct_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProduct_Save.BorderColor = System.Drawing.Color.Green;
            this.btnProduct_Save.BorderThickness = 2;
            this.btnProduct_Save.CheckedState.Parent = this.btnProduct_Save;
            this.btnProduct_Save.CustomImages.Parent = this.btnProduct_Save;
            this.btnProduct_Save.FillColor = System.Drawing.Color.White;
            this.btnProduct_Save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProduct_Save.ForeColor = System.Drawing.Color.Green;
            this.btnProduct_Save.HoverState.Parent = this.btnProduct_Save;
            this.btnProduct_Save.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct_Save.Image")));
            this.btnProduct_Save.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProduct_Save.ImageSize = new System.Drawing.Size(30, 30);
            this.btnProduct_Save.Location = new System.Drawing.Point(282, 671);
            this.btnProduct_Save.Name = "btnProduct_Save";
            this.btnProduct_Save.ShadowDecoration.Parent = this.btnProduct_Save;
            this.btnProduct_Save.Size = new System.Drawing.Size(135, 39);
            this.btnProduct_Save.TabIndex = 0;
            this.btnProduct_Save.Text = "SAVE";
            this.btnProduct_Save.TextOffset = new System.Drawing.Point(10, 0);
            this.btnProduct_Save.Click += new System.EventHandler(this.BtnProduct_Save_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.BackColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnNew.FlatAppearance.BorderSize = 2;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.Orange;
            this.btnNew.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNew.IconColor = System.Drawing.Color.Orange;
            this.btnNew.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNew.IconSize = 30;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(432, 671);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(135, 39);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "ADD NEW";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // rbAmount
            // 
            this.rbAmount.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAmount.ForeColor = System.Drawing.Color.Black;
            this.rbAmount.Location = new System.Drawing.Point(3, 42);
            this.rbAmount.Name = "rbAmount";
            this.rbAmount.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rbAmount.Size = new System.Drawing.Size(178, 34);
            this.rbAmount.TabIndex = 2;
            this.rbAmount.Text = "Amount";
            this.rbAmount.UseVisualStyleBackColor = true;
            this.rbAmount.Visible = false;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(31, 114);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(167, 41);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Discount Percentage";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(31, 73);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(167, 41);
            this.Label4.TabIndex = 22;
            this.Label4.Text = "Discount Name";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(31, 158);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(167, 41);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Discount Type";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label2.Visible = false;
            // 
            // rbPercentage
            // 
            this.rbPercentage.Checked = true;
            this.rbPercentage.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbPercentage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPercentage.ForeColor = System.Drawing.Color.Black;
            this.rbPercentage.Location = new System.Drawing.Point(3, 3);
            this.rbPercentage.Name = "rbPercentage";
            this.rbPercentage.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rbPercentage.Size = new System.Drawing.Size(178, 33);
            this.rbPercentage.TabIndex = 3;
            this.rbPercentage.TabStop = true;
            this.rbPercentage.Text = "Percentage";
            this.rbPercentage.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(31, 252);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(628, 66);
            this.Label3.TabIndex = 39;
            this.Label3.Text = "Note: Discounts can only be applied to items that are discountable. Products\' dis" +
    "countability can be configured in \'Manage Products\' tab. Only one (1) discount c" +
    "an be applied per transaction.";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSearch.Size = new System.Drawing.Size(346, 33);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.Tag = "Search discount";
            this.txtSearch.Text = "Search discount";
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.txtSearch);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(3, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(346, 37);
            this.Panel2.TabIndex = 6;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel2.Controls.Add(this.dgvDiscount, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.Panel2, 0, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 2;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.99455F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.00545F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(352, 734);
            this.TableLayoutPanel2.TabIndex = 1;
            // 
            // dgvDiscount
            // 
            this.dgvDiscount.AllowUserToAddRows = false;
            this.dgvDiscount.AllowUserToDeleteRows = false;
            this.dgvDiscount.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDiscount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDiscount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiscount.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDiscount.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDiscount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDiscount.ColumnHeadersHeight = 40;
            this.dgvDiscount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiscount.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiscount.EnableHeadersVisualStyles = false;
            this.dgvDiscount.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDiscount.Location = new System.Drawing.Point(3, 46);
            this.dgvDiscount.MultiSelect = false;
            this.dgvDiscount.Name = "dgvDiscount";
            this.dgvDiscount.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscount.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDiscount.RowHeadersVisible = false;
            this.dgvDiscount.RowTemplate.DividerHeight = 1;
            this.dgvDiscount.RowTemplate.Height = 35;
            this.dgvDiscount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscount.Size = new System.Drawing.Size(346, 685);
            this.dgvDiscount.TabIndex = 135;
            this.dgvDiscount.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvDiscount.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDiscount.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDiscount.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDiscount.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDiscount.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDiscount.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDiscount.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDiscount.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDiscount.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDiscount.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvDiscount.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDiscount.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDiscount.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvDiscount.ThemeStyle.ReadOnly = true;
            this.dgvDiscount.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDiscount.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDiscount.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvDiscount.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDiscount.ThemeStyle.RowsStyle.Height = 35;
            this.dgvDiscount.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDiscount.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDiscount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscount_CellClick);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BackColor = System.Drawing.Color.White;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.TableLayoutPanel2);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.SplitContainer1.Panel2.Controls.Add(this.btnProduct_Delete);
            this.SplitContainer1.Panel2.Controls.Add(this.btnProduct_Save);
            this.SplitContainer1.Panel2.Controls.Add(this.txtAmount);
            this.SplitContainer1.Panel2.Controls.Add(this.btnNew);
            this.SplitContainer1.Panel2.Controls.Add(this.label5);
            this.SplitContainer1.Panel2.Controls.Add(this.txtName);
            this.SplitContainer1.Panel2.Controls.Add(this.Label1);
            this.SplitContainer1.Panel2.Controls.Add(this.Label4);
            this.SplitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.SplitContainer1.Panel2.Controls.Add(this.Label2);
            this.SplitContainer1.Panel2.Controls.Add(this.Label3);
            this.SplitContainer1.Size = new System.Drawing.Size(1090, 734);
            this.SplitContainer1.SplitterDistance = 352;
            this.SplitContainer1.TabIndex = 2;
            // 
            // txtAmount
            // 
            this.txtAmount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtAmount.BorderRadius = 3;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.DefaultText = "";
            this.txtAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAmount.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtAmount.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.DisabledState.Parent = this.txtAmount;
            this.txtAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmount.FocusedState.Parent = this.txtAmount;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmount.HoverState.Parent = this.txtAmount;
            this.txtAmount.Location = new System.Drawing.Point(210, 119);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.PlaceholderText = "";
            this.txtAmount.SelectedText = "";
            this.txtAmount.ShadowDecoration.Parent = this.txtAmount;
            this.txtAmount.Size = new System.Drawing.Size(399, 33);
            this.txtAmount.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(21, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(318, 39);
            this.label5.TabIndex = 41;
            this.label5.Text = "REGULAR DISCOUNT DETAILS";
            // 
            // txtName
            // 
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtName.BorderRadius = 3;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.txtName.DisabledState.Parent = this.txtName;
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.FocusedState.Parent = this.txtName;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.HoverState.Parent = this.txtName;
            this.txtName.Location = new System.Drawing.Point(210, 76);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.ShadowDecoration.Parent = this.txtName;
            this.txtName.Size = new System.Drawing.Size(399, 33);
            this.txtName.TabIndex = 70;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.rbPercentage, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rbAmount, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(210, 162);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 79);
            this.tableLayoutPanel3.TabIndex = 40;
            this.tableLayoutPanel3.Visible = false;
            // 
            // ManageDiscounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 734);
            this.Controls.Add(this.SplitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageDiscounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageDiscounts";
            this.Load += new System.EventHandler(this.ManageDiscounts_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.TableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscount)).EndInit();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.RadioButton rbAmount;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.RadioButton rbPercentage;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        private Guna.UI2.WinForms.Guna2Button btnProduct_Delete;
        private Guna.UI2.WinForms.Guna2Button btnProduct_Save;
        internal FontAwesome.Sharp.IconButton btnNew;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        internal Guna.UI2.WinForms.Guna2TextBox txtName;
        internal Guna.UI2.WinForms.Guna2TextBox txtAmount;
        internal Guna.UI2.WinForms.Guna2DataGridView dgvDiscount;
    }
}