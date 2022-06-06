namespace EcoPOSv2
{
    partial class VoidTransaction_UI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoidTransaction_UI));
            this.MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvVoidList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvToVoidList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTerminalNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectAll = new FontAwesome.Sharp.IconButton();
            this.panelInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCashReturn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVoid = new Guna.UI2.WinForms.Guna2Button();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoOfItemsToVoid = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.lblPointsReturn = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoidList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToVoidList)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.BorderColor = System.Drawing.Color.Silver;
            this.MainPanel.BorderThickness = 1;
            this.MainPanel.Controls.Add(this.dgvVoidList);
            this.MainPanel.Controls.Add(this.dgvToVoidList);
            this.MainPanel.Controls.Add(this.label5);
            this.MainPanel.Controls.Add(this.btnRemove);
            this.MainPanel.Controls.Add(this.pnlTitle);
            this.MainPanel.Controls.Add(this.tbSearch);
            this.MainPanel.Controls.Add(this.lblTerminalNo);
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Controls.Add(this.btnSelectAll);
            this.MainPanel.Controls.Add(this.panelInfo);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.ShadowDecoration.Parent = this.MainPanel;
            this.MainPanel.Size = new System.Drawing.Size(934, 738);
            this.MainPanel.TabIndex = 0;
            // 
            // dgvVoidList
            // 
            this.dgvVoidList.AllowUserToAddRows = false;
            this.dgvVoidList.AllowUserToDeleteRows = false;
            this.dgvVoidList.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dgvVoidList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvVoidList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVoidList.BackgroundColor = System.Drawing.Color.White;
            this.dgvVoidList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVoidList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVoidList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVoidList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvVoidList.ColumnHeadersHeight = 40;
            this.dgvVoidList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVoidList.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvVoidList.EnableHeadersVisualStyles = false;
            this.dgvVoidList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVoidList.Location = new System.Drawing.Point(21, 88);
            this.dgvVoidList.MultiSelect = false;
            this.dgvVoidList.Name = "dgvVoidList";
            this.dgvVoidList.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVoidList.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvVoidList.RowHeadersVisible = false;
            this.dgvVoidList.RowTemplate.DividerHeight = 1;
            this.dgvVoidList.RowTemplate.Height = 35;
            this.dgvVoidList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVoidList.Size = new System.Drawing.Size(556, 443);
            this.dgvVoidList.TabIndex = 96;
            this.dgvVoidList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvVoidList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvVoidList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvVoidList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvVoidList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvVoidList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvVoidList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvVoidList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVoidList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvVoidList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvVoidList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvVoidList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvVoidList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVoidList.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvVoidList.ThemeStyle.ReadOnly = true;
            this.dgvVoidList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvVoidList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVoidList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvVoidList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvVoidList.ThemeStyle.RowsStyle.Height = 35;
            this.dgvVoidList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVoidList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvToVoidList
            // 
            this.dgvToVoidList.AllowUserToAddRows = false;
            this.dgvToVoidList.AllowUserToDeleteRows = false;
            this.dgvToVoidList.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvToVoidList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvToVoidList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToVoidList.BackgroundColor = System.Drawing.Color.White;
            this.dgvToVoidList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvToVoidList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvToVoidList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToVoidList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvToVoidList.ColumnHeadersHeight = 40;
            this.dgvToVoidList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvToVoidList.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvToVoidList.EnableHeadersVisualStyles = false;
            this.dgvToVoidList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvToVoidList.Location = new System.Drawing.Point(597, 88);
            this.dgvToVoidList.MultiSelect = false;
            this.dgvToVoidList.Name = "dgvToVoidList";
            this.dgvToVoidList.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToVoidList.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvToVoidList.RowHeadersVisible = false;
            this.dgvToVoidList.RowTemplate.DividerHeight = 1;
            this.dgvToVoidList.RowTemplate.Height = 35;
            this.dgvToVoidList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToVoidList.Size = new System.Drawing.Size(317, 631);
            this.dgvToVoidList.TabIndex = 0;
            this.dgvToVoidList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvToVoidList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvToVoidList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvToVoidList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvToVoidList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvToVoidList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvToVoidList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvToVoidList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvToVoidList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvToVoidList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvToVoidList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvToVoidList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvToVoidList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvToVoidList.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvToVoidList.ThemeStyle.ReadOnly = true;
            this.dgvToVoidList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvToVoidList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvToVoidList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvToVoidList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvToVoidList.ThemeStyle.RowsStyle.Height = 35;
            this.dgvToVoidList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvToVoidList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvToVoidList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvToVoidList_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 21);
            this.label5.TabIndex = 94;
            this.label5.Text = "ITEMS TO BE VOIDED";
            // 
            // btnRemove
            // 
            this.btnRemove.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemove.BorderRadius = 3;
            this.btnRemove.BorderThickness = 2;
            this.btnRemove.CheckedState.Parent = this.btnRemove;
            this.btnRemove.CustomImages.Parent = this.btnRemove;
            this.btnRemove.FillColor = System.Drawing.Color.White;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemove.HoverState.Parent = this.btnRemove;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRemove.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnRemove.ImageSize = new System.Drawing.Size(25, 25);
            this.btnRemove.Location = new System.Drawing.Point(370, 44);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.ShadowDecoration.Parent = this.btnRemove;
            this.btnRemove.Size = new System.Drawing.Size(207, 35);
            this.btnRemove.TabIndex = 62;
            this.btnRemove.Text = "REMOVE FROM LIST";
            this.btnRemove.TextOffset = new System.Drawing.Point(10, 0);
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
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
            this.pnlTitle.Size = new System.Drawing.Size(934, 35);
            this.pnlTitle.TabIndex = 93;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(889, 0);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 35);
            this.gunaControlBox1.TabIndex = 4;
            this.gunaControlBox1.Click += new System.EventHandler(this.GunaControlBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 21);
            this.label1.TabIndex = 86;
            this.label1.Text = "VOID TRANSACTION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.tbSearch.BorderRadius = 3;
            this.tbSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearch.DefaultText = "";
            this.tbSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearch.DisabledState.Parent = this.tbSearch;
            this.tbSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.tbSearch.FocusedState.Parent = this.tbSearch;
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.tbSearch.HoverState.Parent = this.tbSearch;
            this.tbSearch.Location = new System.Drawing.Point(597, 46);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PasswordChar = '\0';
            this.tbSearch.PlaceholderText = "";
            this.tbSearch.SelectedText = "";
            this.tbSearch.ShadowDecoration.Parent = this.tbSearch;
            this.tbSearch.Size = new System.Drawing.Size(208, 31);
            this.tbSearch.TabIndex = 49;
            this.tbSearch.Tag = "SEARCH";
            this.tbSearch.TextChanged += new System.EventHandler(this.TbSearch_TextChanged);
            this.tbSearch.Enter += new System.EventHandler(this.TbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.TbSearch_Leave);
            // 
            // lblTerminalNo
            // 
            this.lblTerminalNo.AutoSize = true;
            this.lblTerminalNo.Location = new System.Drawing.Point(274, 51);
            this.lblTerminalNo.Name = "lblTerminalNo";
            this.lblTerminalNo.Size = new System.Drawing.Size(90, 21);
            this.lblTerminalNo.TabIndex = 92;
            this.lblTerminalNo.Text = "TerminalNo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 91;
            this.label3.Text = "FROM:";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatAppearance.BorderSize = 2;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.ForeColor = System.Drawing.Color.Orange;
            this.btnSelectAll.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnSelectAll.IconColor = System.Drawing.Color.Orange;
            this.btnSelectAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSelectAll.IconSize = 20;
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.Location = new System.Drawing.Point(812, 47);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(102, 31);
            this.btnSelectAll.TabIndex = 89;
            this.btnSelectAll.Text = "Select all";
            this.btnSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.BorderColor = System.Drawing.Color.Silver;
            this.panelInfo.BorderRadius = 5;
            this.panelInfo.BorderThickness = 1;
            this.panelInfo.Controls.Add(this.lblPointsReturn);
            this.panelInfo.Controls.Add(this.label8);
            this.panelInfo.Controls.Add(this.lblCashReturn);
            this.panelInfo.Controls.Add(this.label4);
            this.panelInfo.Controls.Add(this.btnVoid);
            this.panelInfo.Controls.Add(this.lblInvoice);
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.lblNoOfItemsToVoid);
            this.panelInfo.Controls.Add(this.Label6);
            this.panelInfo.Location = new System.Drawing.Point(21, 544);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.ShadowDecoration.Parent = this.panelInfo;
            this.panelInfo.Size = new System.Drawing.Size(556, 175);
            this.panelInfo.TabIndex = 85;
            // 
            // lblCashReturn
            // 
            this.lblCashReturn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashReturn.ForeColor = System.Drawing.Color.Black;
            this.lblCashReturn.Location = new System.Drawing.Point(14, 87);
            this.lblCashReturn.Name = "lblCashReturn";
            this.lblCashReturn.Size = new System.Drawing.Size(243, 25);
            this.lblCashReturn.TabIndex = 61;
            this.lblCashReturn.Text = "0";
            this.lblCashReturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 21);
            this.label4.TabIndex = 60;
            this.label4.Text = "TOTAL CASH TO RETURN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVoid
            // 
            this.btnVoid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnVoid.BorderRadius = 3;
            this.btnVoid.BorderThickness = 2;
            this.btnVoid.CheckedState.Parent = this.btnVoid;
            this.btnVoid.CustomImages.Parent = this.btnVoid;
            this.btnVoid.Enabled = false;
            this.btnVoid.FillColor = System.Drawing.Color.White;
            this.btnVoid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnVoid.HoverState.Parent = this.btnVoid;
            this.btnVoid.Image = ((System.Drawing.Image)(resources.GetObject("btnVoid.Image")));
            this.btnVoid.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnVoid.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnVoid.ImageSize = new System.Drawing.Size(33, 33);
            this.btnVoid.Location = new System.Drawing.Point(297, 113);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.ShadowDecoration.Parent = this.btnVoid;
            this.btnVoid.Size = new System.Drawing.Size(238, 46);
            this.btnVoid.TabIndex = 59;
            this.btnVoid.Text = "VOID";
            this.btnVoid.TextOffset = new System.Drawing.Point(10, 0);
            this.btnVoid.Click += new System.EventHandler(this.BtnVoid_Click);
            // 
            // lblInvoice
            // 
            this.lblInvoice.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoice.ForeColor = System.Drawing.Color.Black;
            this.lblInvoice.Location = new System.Drawing.Point(14, 36);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(233, 25);
            this.lblInvoice.TabIndex = 49;
            this.lblInvoice.Text = "0";
            this.lblInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 48;
            this.label2.Text = "INVOICE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNoOfItemsToVoid
            // 
            this.lblNoOfItemsToVoid.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfItemsToVoid.ForeColor = System.Drawing.Color.Black;
            this.lblNoOfItemsToVoid.Location = new System.Drawing.Point(302, 36);
            this.lblNoOfItemsToVoid.Name = "lblNoOfItemsToVoid";
            this.lblNoOfItemsToVoid.Size = new System.Drawing.Size(233, 25);
            this.lblNoOfItemsToVoid.TabIndex = 47;
            this.lblNoOfItemsToVoid.Text = "0";
            this.lblNoOfItemsToVoid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(303, 12);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(215, 21);
            this.Label6.TabIndex = 44;
            this.Label6.Text = "NO OF ITEMS TO BE VOIDED";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.pnlTitle;
            // 
            // lblPointsReturn
            // 
            this.lblPointsReturn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsReturn.ForeColor = System.Drawing.Color.Black;
            this.lblPointsReturn.Location = new System.Drawing.Point(14, 139);
            this.lblPointsReturn.Name = "lblPointsReturn";
            this.lblPointsReturn.Size = new System.Drawing.Size(243, 25);
            this.lblPointsReturn.TabIndex = 63;
            this.lblPointsReturn.Text = "0";
            this.lblPointsReturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(15, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 21);
            this.label8.TabIndex = 62;
            this.label8.Text = "TOTAL POINTS TO RETURN";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VoidTransaction_UI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(934, 738);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "VoidTransaction_UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoidTransaction_UI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VoidTransaction_UI_FormClosing);
            this.Load += new System.EventHandler(this.VoidTransaction_UI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VoidTransaction_UI_KeyDown);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoidList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToVoidList)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        private Guna.UI2.WinForms.Guna2Panel panelInfo;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblNoOfItemsToVoid;
        internal System.Windows.Forms.Label lblInvoice;
        internal System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnVoid;
        internal System.Windows.Forms.Label label1;
        internal FontAwesome.Sharp.IconButton btnSelectAll;
        internal System.Windows.Forms.Label lblCashReturn;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTerminalNo;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private Guna.UI2.WinForms.Guna2Panel pnlTitle;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
        internal Guna.UI2.WinForms.Guna2DataGridView dgvToVoidList;
        internal Guna.UI2.WinForms.Guna2DataGridView dgvVoidList;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        internal System.Windows.Forms.Label lblPointsReturn;
        internal System.Windows.Forms.Label label8;
    }
}