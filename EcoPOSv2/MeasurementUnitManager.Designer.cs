
namespace EcoPOSv2
{
    partial class MeasurementUnitManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeasurementUnitManager));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlUnit = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvUnit = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.radioUnitNo = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioUnitYes = new Guna.UI2.WinForms.Guna2RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.btnUnitDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnUnitSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnUnitNew = new FontAwesome.Sharp.IconButton();
            this.label29 = new System.Windows.Forms.Label();
            this.txtUnitName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.pnlTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.pnlUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnit)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.pnlUnit);
            this.guna2Panel1.Controls.Add(this.pnlTitle);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(791, 531);
            this.guna2Panel1.TabIndex = 0;
            // 
            // pnlUnit
            // 
            this.pnlUnit.Controls.Add(this.splitContainer1);
            this.pnlUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnit.Location = new System.Drawing.Point(0, 35);
            this.pnlUnit.Name = "pnlUnit";
            this.pnlUnit.Size = new System.Drawing.Size(791, 496);
            this.pnlUnit.TabIndex = 95;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvUnit);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.guna2Panel2);
            this.splitContainer1.Size = new System.Drawing.Size(791, 496);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvUnit
            // 
            this.dgvUnit.AllowUserToAddRows = false;
            this.dgvUnit.AllowUserToDeleteRows = false;
            this.dgvUnit.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            this.dgvUnit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvUnit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnit.BackgroundColor = System.Drawing.Color.White;
            this.dgvUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUnit.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUnit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvUnit.ColumnHeadersHeight = 40;
            this.dgvUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUnit.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnit.EnableHeadersVisualStyles = false;
            this.dgvUnit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUnit.Location = new System.Drawing.Point(0, 0);
            this.dgvUnit.MultiSelect = false;
            this.dgvUnit.Name = "dgvUnit";
            this.dgvUnit.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnit.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvUnit.RowHeadersVisible = false;
            this.dgvUnit.RowTemplate.DividerHeight = 1;
            this.dgvUnit.RowTemplate.Height = 35;
            this.dgvUnit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnit.Size = new System.Drawing.Size(246, 496);
            this.dgvUnit.TabIndex = 135;
            this.dgvUnit.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvUnit.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUnit.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvUnit.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvUnit.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvUnit.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvUnit.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvUnit.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUnit.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvUnit.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUnit.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvUnit.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUnit.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUnit.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvUnit.ThemeStyle.ReadOnly = true;
            this.dgvUnit.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUnit.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUnit.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvUnit.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvUnit.ThemeStyle.RowsStyle.Height = 35;
            this.dgvUnit.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUnit.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvUnit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnit_CellClick);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.radioUnitNo);
            this.guna2Panel2.Controls.Add(this.radioUnitYes);
            this.guna2Panel2.Controls.Add(this.label16);
            this.guna2Panel2.Controls.Add(this.btnUnitDelete);
            this.guna2Panel2.Controls.Add(this.btnUnitSave);
            this.guna2Panel2.Controls.Add(this.btnUnitNew);
            this.guna2Panel2.Controls.Add(this.label29);
            this.guna2Panel2.Controls.Add(this.txtUnitName);
            this.guna2Panel2.Controls.Add(this.label20);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(541, 496);
            this.guna2Panel2.TabIndex = 0;
            // 
            // radioUnitNo
            // 
            this.radioUnitNo.AutoSize = true;
            this.radioUnitNo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioUnitNo.CheckedState.BorderThickness = 0;
            this.radioUnitNo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioUnitNo.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioUnitNo.CheckedState.InnerOffset = -4;
            this.radioUnitNo.Location = new System.Drawing.Point(173, 156);
            this.radioUnitNo.Name = "radioUnitNo";
            this.radioUnitNo.Size = new System.Drawing.Size(41, 17);
            this.radioUnitNo.TabIndex = 162;
            this.radioUnitNo.TabStop = true;
            this.radioUnitNo.Text = "NO";
            this.radioUnitNo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioUnitNo.UncheckedState.BorderThickness = 2;
            this.radioUnitNo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioUnitNo.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.radioUnitNo.UseVisualStyleBackColor = true;
            // 
            // radioUnitYes
            // 
            this.radioUnitYes.AutoSize = true;
            this.radioUnitYes.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioUnitYes.CheckedState.BorderThickness = 0;
            this.radioUnitYes.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioUnitYes.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioUnitYes.CheckedState.InnerOffset = -4;
            this.radioUnitYes.Location = new System.Drawing.Point(173, 129);
            this.radioUnitYes.Name = "radioUnitYes";
            this.radioUnitYes.Size = new System.Drawing.Size(46, 17);
            this.radioUnitYes.TabIndex = 161;
            this.radioUnitYes.TabStop = true;
            this.radioUnitYes.Text = "YES";
            this.radioUnitYes.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioUnitYes.UncheckedState.BorderThickness = 2;
            this.radioUnitYes.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioUnitYes.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.radioUnitYes.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(39, 118);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 34);
            this.label16.TabIndex = 160;
            this.label16.Text = "Has Decimal";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUnitDelete
            // 
            this.btnUnitDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnitDelete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUnitDelete.BorderThickness = 2;
            this.btnUnitDelete.CheckedState.Parent = this.btnUnitDelete;
            this.btnUnitDelete.CustomImages.Parent = this.btnUnitDelete;
            this.btnUnitDelete.FillColor = System.Drawing.Color.White;
            this.btnUnitDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUnitDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUnitDelete.HoverState.Parent = this.btnUnitDelete;
            this.btnUnitDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnUnitDelete.Image")));
            this.btnUnitDelete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUnitDelete.ImageSize = new System.Drawing.Size(25, 25);
            this.btnUnitDelete.Location = new System.Drawing.Point(65, 419);
            this.btnUnitDelete.Name = "btnUnitDelete";
            this.btnUnitDelete.ShadowDecoration.Parent = this.btnUnitDelete;
            this.btnUnitDelete.Size = new System.Drawing.Size(124, 40);
            this.btnUnitDelete.TabIndex = 159;
            this.btnUnitDelete.Text = "DELETE";
            this.btnUnitDelete.TextOffset = new System.Drawing.Point(10, 0);
            this.btnUnitDelete.Click += new System.EventHandler(this.btnUnitDelete_Click);
            // 
            // btnUnitSave
            // 
            this.btnUnitSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnitSave.BorderColor = System.Drawing.Color.Green;
            this.btnUnitSave.BorderThickness = 2;
            this.btnUnitSave.CheckedState.Parent = this.btnUnitSave;
            this.btnUnitSave.CustomImages.Parent = this.btnUnitSave;
            this.btnUnitSave.FillColor = System.Drawing.Color.White;
            this.btnUnitSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUnitSave.ForeColor = System.Drawing.Color.Green;
            this.btnUnitSave.HoverState.Parent = this.btnUnitSave;
            this.btnUnitSave.Image = ((System.Drawing.Image)(resources.GetObject("btnUnitSave.Image")));
            this.btnUnitSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUnitSave.ImageSize = new System.Drawing.Size(25, 25);
            this.btnUnitSave.Location = new System.Drawing.Point(208, 419);
            this.btnUnitSave.Name = "btnUnitSave";
            this.btnUnitSave.ShadowDecoration.Parent = this.btnUnitSave;
            this.btnUnitSave.Size = new System.Drawing.Size(124, 40);
            this.btnUnitSave.TabIndex = 158;
            this.btnUnitSave.Text = "SAVE";
            this.btnUnitSave.TextOffset = new System.Drawing.Point(10, 0);
            this.btnUnitSave.Click += new System.EventHandler(this.btnUnitSave_Click);
            // 
            // btnUnitNew
            // 
            this.btnUnitNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnitNew.BackColor = System.Drawing.Color.White;
            this.btnUnitNew.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnUnitNew.FlatAppearance.BorderSize = 2;
            this.btnUnitNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnitNew.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnitNew.ForeColor = System.Drawing.Color.Orange;
            this.btnUnitNew.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnUnitNew.IconColor = System.Drawing.Color.Orange;
            this.btnUnitNew.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUnitNew.IconSize = 25;
            this.btnUnitNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnitNew.Location = new System.Drawing.Point(351, 419);
            this.btnUnitNew.Name = "btnUnitNew";
            this.btnUnitNew.Size = new System.Drawing.Size(124, 40);
            this.btnUnitNew.TabIndex = 157;
            this.btnUnitNew.Text = "ADD NEW";
            this.btnUnitNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUnitNew.UseVisualStyleBackColor = false;
            this.btnUnitNew.Click += new System.EventHandler(this.btnUnitNew_Click);
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(31, 12);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(400, 34);
            this.label29.TabIndex = 156;
            this.label29.Text = "UNIT OF MEASUREMENT DETAILS";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUnitName
            // 
            this.txtUnitName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtUnitName.BorderRadius = 3;
            this.txtUnitName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUnitName.DefaultText = "";
            this.txtUnitName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUnitName.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtUnitName.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.txtUnitName.DisabledState.Parent = this.txtUnitName;
            this.txtUnitName.DisabledState.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtUnitName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUnitName.FocusedState.Parent = this.txtUnitName;
            this.txtUnitName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitName.ForeColor = System.Drawing.Color.Black;
            this.txtUnitName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUnitName.HoverState.Parent = this.txtUnitName;
            this.txtUnitName.Location = new System.Drawing.Point(174, 68);
            this.txtUnitName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.PasswordChar = '\0';
            this.txtUnitName.PlaceholderText = "";
            this.txtUnitName.SelectedText = "";
            this.txtUnitName.ShadowDecoration.Parent = this.txtUnitName;
            this.txtUnitName.Size = new System.Drawing.Size(318, 33);
            this.txtUnitName.TabIndex = 148;
            this.txtUnitName.TextChanged += new System.EventHandler(this.txtUnitName_TextChanged);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(39, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(128, 34);
            this.label20.TabIndex = 138;
            this.label20.Text = "Unit Name";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlTitle.BorderThickness = 1;
            this.pnlTitle.Controls.Add(this.gunaControlBox1);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.ShadowDecoration.Enabled = true;
            this.pnlTitle.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pnlTitle.ShadowDecoration.Parent = this.pnlTitle;
            this.pnlTitle.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlTitle.Size = new System.Drawing.Size(791, 35);
            this.pnlTitle.TabIndex = 94;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(746, 0);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 35);
            this.gunaControlBox1.TabIndex = 4;
            this.gunaControlBox1.Click += new System.EventHandler(this.gunaControlBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 86;
            this.label1.Text = "UNIT MANAGER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MeasurementUnitManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 531);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MeasurementUnitManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeasurementUnitManager";
            this.Load += new System.EventHandler(this.MeasurementUnitManager_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.pnlUnit.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnit)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnlTitle;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Panel pnlUnit;
        internal System.Windows.Forms.SplitContainer splitContainer1;
        internal Guna.UI2.WinForms.Guna2DataGridView dgvUnit;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2RadioButton radioUnitNo;
        private Guna.UI2.WinForms.Guna2RadioButton radioUnitYes;
        internal System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2Button btnUnitDelete;
        private Guna.UI2.WinForms.Guna2Button btnUnitSave;
        internal FontAwesome.Sharp.IconButton btnUnitNew;
        internal System.Windows.Forms.Label label29;
        internal Guna.UI2.WinForms.Guna2TextBox txtUnitName;
        internal System.Windows.Forms.Label label20;
    }
}