﻿namespace EcoPOSv2
{
    partial class StaffType
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffType));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvStaffType = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnClose = new Guna.UI.WinForms.GunaControlBox();
            this.txtStaffType = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.flpPermission = new System.Windows.Forms.FlowLayoutPanel();
            this.Label2 = new System.Windows.Forms.Label();
            this.cbxOrd_Payment = new System.Windows.Forms.CheckBox();
            this.cbxOrd_Customer = new System.Windows.Forms.CheckBox();
            this.cbxOrd_Discount = new System.Windows.Forms.CheckBox();
            this.cbxOrd_VoidItem = new System.Windows.Forms.CheckBox();
            this.cbxOrd_VoidTransaction = new System.Windows.Forms.CheckBox();
            this.cbxOrd_CancelTransaction = new System.Windows.Forms.CheckBox();
            this.cbxOrd_RefundTransaction = new System.Windows.Forms.CheckBox();
            this.cbxOrd_KeepTransaction = new System.Windows.Forms.CheckBox();
            this.cbxOrd_ReturnExchange = new System.Windows.Forms.CheckBox();
            this.cbxOrd_RedeemItem = new System.Windows.Forms.CheckBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cbxHome_SwitchCashier = new System.Windows.Forms.CheckBox();
            this.cbxHome_More = new System.Windows.Forms.CheckBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cbxPay_PaymentMethod = new System.Windows.Forms.CheckBox();
            this.cbxPay_GiftCertificate = new System.Windows.Forms.CheckBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cbxMore_EJournal = new System.Windows.Forms.CheckBox();
            this.cbxMore_Logs = new System.Windows.Forms.CheckBox();
            this.cbxMore_RedeemSettings = new System.Windows.Forms.CheckBox();
            this.cbxMore_ManageDiscounts = new System.Windows.Forms.CheckBox();
            this.cbxMore_ManageProducts = new System.Windows.Forms.CheckBox();
            this.cbxMore_Inventory = new System.Windows.Forms.CheckBox();
            this.cbxMore_CloseStore = new System.Windows.Forms.CheckBox();
            this.cbxMore_Database = new System.Windows.Forms.CheckBox();
            this.cbxMore_Settings = new System.Windows.Forms.CheckBox();
            this.cbxMore_CustomerMembership = new System.Windows.Forms.CheckBox();
            this.cbxMore_PayInOut = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffType)).BeginInit();
            this.flpPermission.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.SplitContainer1);
            this.guna2Panel1.Location = new System.Drawing.Point(1, 1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(948, 577);
            this.guna2Panel1.TabIndex = 0;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BackColor = System.Drawing.Color.White;
            this.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.SplitContainer1.Panel1.Controls.Add(this.dgvStaffType);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.SplitContainer1.Panel2.Controls.Add(this.btnClose);
            this.SplitContainer1.Panel2.Controls.Add(this.txtStaffType);
            this.SplitContainer1.Panel2.Controls.Add(this.lblID);
            this.SplitContainer1.Panel2.Controls.Add(this.label7);
            this.SplitContainer1.Panel2.Controls.Add(this.btnSave);
            this.SplitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.SplitContainer1.Panel2.Controls.Add(this.btnAdd);
            this.SplitContainer1.Panel2.Controls.Add(this.flpPermission);
            this.SplitContainer1.Panel2.Controls.Add(this.Label1);
            this.SplitContainer1.Panel2.Controls.Add(this.Label6);
            this.SplitContainer1.Size = new System.Drawing.Size(948, 577);
            this.SplitContainer1.SplitterDistance = 315;
            this.SplitContainer1.TabIndex = 1;
            // 
            // dgvStaffType
            // 
            this.dgvStaffType.AllowUserToAddRows = false;
            this.dgvStaffType.AllowUserToDeleteRows = false;
            this.dgvStaffType.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvStaffType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStaffType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaffType.BackgroundColor = System.Drawing.Color.White;
            this.dgvStaffType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStaffType.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStaffType.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaffType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStaffType.ColumnHeadersHeight = 40;
            this.dgvStaffType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStaffType.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStaffType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaffType.EnableHeadersVisualStyles = false;
            this.dgvStaffType.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStaffType.Location = new System.Drawing.Point(0, 0);
            this.dgvStaffType.MultiSelect = false;
            this.dgvStaffType.Name = "dgvStaffType";
            this.dgvStaffType.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaffType.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStaffType.RowHeadersVisible = false;
            this.dgvStaffType.RowTemplate.DividerHeight = 1;
            this.dgvStaffType.RowTemplate.Height = 35;
            this.dgvStaffType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaffType.Size = new System.Drawing.Size(313, 575);
            this.dgvStaffType.TabIndex = 131;
            this.dgvStaffType.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvStaffType.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStaffType.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvStaffType.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvStaffType.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvStaffType.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvStaffType.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvStaffType.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStaffType.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvStaffType.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvStaffType.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvStaffType.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStaffType.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStaffType.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvStaffType.ThemeStyle.ReadOnly = true;
            this.dgvStaffType.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStaffType.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStaffType.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvStaffType.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStaffType.ThemeStyle.RowsStyle.Height = 35;
            this.dgvStaffType.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStaffType.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStaffType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaffType_CellClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AnimationHoverSpeed = 0.07F;
            this.btnClose.AnimationSpeed = 0.03F;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.IconColor = System.Drawing.Color.Black;
            this.btnClose.IconSize = 15F;
            this.btnClose.Location = new System.Drawing.Point(585, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.OnHoverIconColor = System.Drawing.Color.White;
            this.btnClose.OnPressedColor = System.Drawing.Color.Black;
            this.btnClose.Size = new System.Drawing.Size(42, 35);
            this.btnClose.TabIndex = 103;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtStaffType
            // 
            this.txtStaffType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtStaffType.BorderRadius = 3;
            this.txtStaffType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStaffType.DefaultText = "";
            this.txtStaffType.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtStaffType.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtStaffType.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.txtStaffType.DisabledState.Parent = this.txtStaffType;
            this.txtStaffType.DisabledState.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtStaffType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStaffType.FocusedState.Parent = this.txtStaffType;
            this.txtStaffType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffType.ForeColor = System.Drawing.Color.Black;
            this.txtStaffType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStaffType.HoverState.Parent = this.txtStaffType;
            this.txtStaffType.Location = new System.Drawing.Point(106, 56);
            this.txtStaffType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStaffType.Name = "txtStaffType";
            this.txtStaffType.PasswordChar = '\0';
            this.txtStaffType.PlaceholderText = "";
            this.txtStaffType.SelectedText = "";
            this.txtStaffType.ShadowDecoration.Parent = this.txtStaffType;
            this.txtStaffType.Size = new System.Drawing.Size(488, 33);
            this.txtStaffType.TabIndex = 76;
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Black;
            this.lblID.Location = new System.Drawing.Point(108, 26);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(259, 25);
            this.lblID.TabIndex = 75;
            this.lblID.Text = "    ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(8, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 21);
            this.label7.TabIndex = 74;
            this.label7.Text = "Staff ID:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BorderColor = System.Drawing.Color.Green;
            this.btnSave.BorderThickness = 2;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(89, 519);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(142, 40);
            this.btnSave.TabIndex = 72;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextOffset = new System.Drawing.Point(10, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.BorderThickness = 2;
            this.btnDelete.CheckedState.Parent = this.btnDelete;
            this.btnDelete.CustomImages.Parent = this.btnDelete;
            this.btnDelete.FillColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.HoverState.Parent = this.btnDelete;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDelete.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDelete.Location = new System.Drawing.Point(246, 519);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(142, 40);
            this.btnDelete.TabIndex = 73;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.TextOffset = new System.Drawing.Point(10, 0);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Orange;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAdd.IconColor = System.Drawing.Color.Orange;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 30;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(403, 519);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(142, 40);
            this.btnAdd.TabIndex = 71;
            this.btnAdd.Text = "ADD NEW";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // flpPermission
            // 
            this.flpPermission.BackColor = System.Drawing.Color.White;
            this.flpPermission.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpPermission.Controls.Add(this.Label2);
            this.flpPermission.Controls.Add(this.cbxOrd_Payment);
            this.flpPermission.Controls.Add(this.cbxOrd_Customer);
            this.flpPermission.Controls.Add(this.cbxOrd_Discount);
            this.flpPermission.Controls.Add(this.cbxOrd_VoidItem);
            this.flpPermission.Controls.Add(this.cbxOrd_VoidTransaction);
            this.flpPermission.Controls.Add(this.cbxOrd_CancelTransaction);
            this.flpPermission.Controls.Add(this.cbxOrd_RefundTransaction);
            this.flpPermission.Controls.Add(this.cbxOrd_KeepTransaction);
            this.flpPermission.Controls.Add(this.cbxOrd_ReturnExchange);
            this.flpPermission.Controls.Add(this.cbxOrd_RedeemItem);
            this.flpPermission.Controls.Add(this.Label3);
            this.flpPermission.Controls.Add(this.cbxHome_SwitchCashier);
            this.flpPermission.Controls.Add(this.cbxHome_More);
            this.flpPermission.Controls.Add(this.Label5);
            this.flpPermission.Controls.Add(this.cbxPay_PaymentMethod);
            this.flpPermission.Controls.Add(this.cbxPay_GiftCertificate);
            this.flpPermission.Controls.Add(this.Label4);
            this.flpPermission.Controls.Add(this.cbxMore_EJournal);
            this.flpPermission.Controls.Add(this.cbxMore_Logs);
            this.flpPermission.Controls.Add(this.cbxMore_RedeemSettings);
            this.flpPermission.Controls.Add(this.cbxMore_ManageDiscounts);
            this.flpPermission.Controls.Add(this.cbxMore_ManageProducts);
            this.flpPermission.Controls.Add(this.cbxMore_Inventory);
            this.flpPermission.Controls.Add(this.cbxMore_CloseStore);
            this.flpPermission.Controls.Add(this.cbxMore_Database);
            this.flpPermission.Controls.Add(this.cbxMore_Settings);
            this.flpPermission.Controls.Add(this.cbxMore_CustomerMembership);
            this.flpPermission.Controls.Add(this.cbxMore_PayInOut);
            this.flpPermission.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPermission.Location = new System.Drawing.Point(13, 119);
            this.flpPermission.Name = "flpPermission";
            this.flpPermission.Size = new System.Drawing.Size(604, 386);
            this.flpPermission.TabIndex = 56;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(3, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(54, 23);
            this.Label2.TabIndex = 53;
            this.Label2.Text = "Order";
            // 
            // cbxOrd_Payment
            // 
            this.cbxOrd_Payment.AutoSize = true;
            this.cbxOrd_Payment.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrd_Payment.ForeColor = System.Drawing.Color.Black;
            this.cbxOrd_Payment.Location = new System.Drawing.Point(3, 26);
            this.cbxOrd_Payment.Name = "cbxOrd_Payment";
            this.cbxOrd_Payment.Size = new System.Drawing.Size(84, 24);
            this.cbxOrd_Payment.TabIndex = 0;
            this.cbxOrd_Payment.Text = "Payment";
            this.cbxOrd_Payment.UseVisualStyleBackColor = true;
            // 
            // cbxOrd_Customer
            // 
            this.cbxOrd_Customer.AutoSize = true;
            this.cbxOrd_Customer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrd_Customer.ForeColor = System.Drawing.Color.Black;
            this.cbxOrd_Customer.Location = new System.Drawing.Point(3, 56);
            this.cbxOrd_Customer.Name = "cbxOrd_Customer";
            this.cbxOrd_Customer.Size = new System.Drawing.Size(91, 24);
            this.cbxOrd_Customer.TabIndex = 13;
            this.cbxOrd_Customer.Text = "Customer";
            this.cbxOrd_Customer.UseVisualStyleBackColor = true;
            // 
            // cbxOrd_Discount
            // 
            this.cbxOrd_Discount.AutoSize = true;
            this.cbxOrd_Discount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrd_Discount.ForeColor = System.Drawing.Color.Black;
            this.cbxOrd_Discount.Location = new System.Drawing.Point(3, 86);
            this.cbxOrd_Discount.Name = "cbxOrd_Discount";
            this.cbxOrd_Discount.Size = new System.Drawing.Size(86, 24);
            this.cbxOrd_Discount.TabIndex = 10;
            this.cbxOrd_Discount.Text = "Discount";
            this.cbxOrd_Discount.UseVisualStyleBackColor = true;
            // 
            // cbxOrd_VoidItem
            // 
            this.cbxOrd_VoidItem.AutoSize = true;
            this.cbxOrd_VoidItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrd_VoidItem.ForeColor = System.Drawing.Color.Black;
            this.cbxOrd_VoidItem.Location = new System.Drawing.Point(3, 116);
            this.cbxOrd_VoidItem.Name = "cbxOrd_VoidItem";
            this.cbxOrd_VoidItem.Size = new System.Drawing.Size(92, 24);
            this.cbxOrd_VoidItem.TabIndex = 12;
            this.cbxOrd_VoidItem.Text = "Void Item";
            this.cbxOrd_VoidItem.UseVisualStyleBackColor = true;
            // 
            // cbxOrd_VoidTransaction
            // 
            this.cbxOrd_VoidTransaction.AutoSize = true;
            this.cbxOrd_VoidTransaction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrd_VoidTransaction.ForeColor = System.Drawing.Color.Black;
            this.cbxOrd_VoidTransaction.Location = new System.Drawing.Point(3, 146);
            this.cbxOrd_VoidTransaction.Name = "cbxOrd_VoidTransaction";
            this.cbxOrd_VoidTransaction.Size = new System.Drawing.Size(137, 24);
            this.cbxOrd_VoidTransaction.TabIndex = 2;
            this.cbxOrd_VoidTransaction.Text = "Void Transaction";
            this.cbxOrd_VoidTransaction.UseVisualStyleBackColor = true;
            // 
            // cbxOrd_CancelTransaction
            // 
            this.cbxOrd_CancelTransaction.AutoSize = true;
            this.cbxOrd_CancelTransaction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrd_CancelTransaction.ForeColor = System.Drawing.Color.Black;
            this.cbxOrd_CancelTransaction.Location = new System.Drawing.Point(3, 176);
            this.cbxOrd_CancelTransaction.Name = "cbxOrd_CancelTransaction";
            this.cbxOrd_CancelTransaction.Size = new System.Drawing.Size(151, 24);
            this.cbxOrd_CancelTransaction.TabIndex = 3;
            this.cbxOrd_CancelTransaction.Text = "Cancel Transaction";
            this.cbxOrd_CancelTransaction.UseVisualStyleBackColor = true;
            // 
            // cbxOrd_RefundTransaction
            // 
            this.cbxOrd_RefundTransaction.AutoSize = true;
            this.cbxOrd_RefundTransaction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrd_RefundTransaction.ForeColor = System.Drawing.Color.Black;
            this.cbxOrd_RefundTransaction.Location = new System.Drawing.Point(3, 206);
            this.cbxOrd_RefundTransaction.Name = "cbxOrd_RefundTransaction";
            this.cbxOrd_RefundTransaction.Size = new System.Drawing.Size(154, 24);
            this.cbxOrd_RefundTransaction.TabIndex = 4;
            this.cbxOrd_RefundTransaction.Text = "Refund Transaction";
            this.cbxOrd_RefundTransaction.UseVisualStyleBackColor = true;
            // 
            // cbxOrd_KeepTransaction
            // 
            this.cbxOrd_KeepTransaction.AutoSize = true;
            this.cbxOrd_KeepTransaction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrd_KeepTransaction.ForeColor = System.Drawing.Color.Black;
            this.cbxOrd_KeepTransaction.Location = new System.Drawing.Point(3, 236);
            this.cbxOrd_KeepTransaction.Name = "cbxOrd_KeepTransaction";
            this.cbxOrd_KeepTransaction.Size = new System.Drawing.Size(141, 24);
            this.cbxOrd_KeepTransaction.TabIndex = 69;
            this.cbxOrd_KeepTransaction.Text = "Keep Transaction";
            this.cbxOrd_KeepTransaction.UseVisualStyleBackColor = true;
            // 
            // cbxOrd_ReturnExchange
            // 
            this.cbxOrd_ReturnExchange.AutoSize = true;
            this.cbxOrd_ReturnExchange.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrd_ReturnExchange.ForeColor = System.Drawing.Color.Black;
            this.cbxOrd_ReturnExchange.Location = new System.Drawing.Point(3, 266);
            this.cbxOrd_ReturnExchange.Name = "cbxOrd_ReturnExchange";
            this.cbxOrd_ReturnExchange.Size = new System.Drawing.Size(140, 24);
            this.cbxOrd_ReturnExchange.TabIndex = 5;
            this.cbxOrd_ReturnExchange.Text = "Return/Exchange";
            this.cbxOrd_ReturnExchange.UseVisualStyleBackColor = true;
            // 
            // cbxOrd_RedeemItem
            // 
            this.cbxOrd_RedeemItem.AutoSize = true;
            this.cbxOrd_RedeemItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrd_RedeemItem.ForeColor = System.Drawing.Color.Black;
            this.cbxOrd_RedeemItem.Location = new System.Drawing.Point(3, 296);
            this.cbxOrd_RedeemItem.Name = "cbxOrd_RedeemItem";
            this.cbxOrd_RedeemItem.Size = new System.Drawing.Size(117, 24);
            this.cbxOrd_RedeemItem.TabIndex = 6;
            this.cbxOrd_RedeemItem.Text = "Redeem Item";
            this.cbxOrd_RedeemItem.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(3, 323);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(57, 23);
            this.Label3.TabIndex = 54;
            this.Label3.Text = "Home";
            // 
            // cbxHome_SwitchCashier
            // 
            this.cbxHome_SwitchCashier.AutoSize = true;
            this.cbxHome_SwitchCashier.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHome_SwitchCashier.ForeColor = System.Drawing.Color.Black;
            this.cbxHome_SwitchCashier.Location = new System.Drawing.Point(3, 349);
            this.cbxHome_SwitchCashier.Name = "cbxHome_SwitchCashier";
            this.cbxHome_SwitchCashier.Size = new System.Drawing.Size(123, 24);
            this.cbxHome_SwitchCashier.TabIndex = 7;
            this.cbxHome_SwitchCashier.Text = "Switch Cashier";
            this.cbxHome_SwitchCashier.UseVisualStyleBackColor = true;
            // 
            // cbxHome_More
            // 
            this.cbxHome_More.AutoSize = true;
            this.cbxHome_More.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHome_More.ForeColor = System.Drawing.Color.Black;
            this.cbxHome_More.Location = new System.Drawing.Point(163, 3);
            this.cbxHome_More.Name = "cbxHome_More";
            this.cbxHome_More.Size = new System.Drawing.Size(63, 24);
            this.cbxHome_More.TabIndex = 9;
            this.cbxHome_More.Text = "More";
            this.cbxHome_More.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(163, 30);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(78, 23);
            this.Label5.TabIndex = 65;
            this.Label5.Text = "Payment";
            // 
            // cbxPay_PaymentMethod
            // 
            this.cbxPay_PaymentMethod.AutoSize = true;
            this.cbxPay_PaymentMethod.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPay_PaymentMethod.ForeColor = System.Drawing.Color.Black;
            this.cbxPay_PaymentMethod.Location = new System.Drawing.Point(163, 56);
            this.cbxPay_PaymentMethod.Name = "cbxPay_PaymentMethod";
            this.cbxPay_PaymentMethod.Size = new System.Drawing.Size(140, 24);
            this.cbxPay_PaymentMethod.TabIndex = 66;
            this.cbxPay_PaymentMethod.Text = "Payment Method";
            this.cbxPay_PaymentMethod.UseVisualStyleBackColor = true;
            // 
            // cbxPay_GiftCertificate
            // 
            this.cbxPay_GiftCertificate.AutoSize = true;
            this.cbxPay_GiftCertificate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPay_GiftCertificate.ForeColor = System.Drawing.Color.Black;
            this.cbxPay_GiftCertificate.Location = new System.Drawing.Point(163, 86);
            this.cbxPay_GiftCertificate.Name = "cbxPay_GiftCertificate";
            this.cbxPay_GiftCertificate.Size = new System.Drawing.Size(124, 24);
            this.cbxPay_GiftCertificate.TabIndex = 67;
            this.cbxPay_GiftCertificate.Text = "Gift Certificate";
            this.cbxPay_GiftCertificate.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(163, 113);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(51, 23);
            this.Label4.TabIndex = 55;
            this.Label4.Text = "More";
            // 
            // cbxMore_EJournal
            // 
            this.cbxMore_EJournal.AutoSize = true;
            this.cbxMore_EJournal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_EJournal.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_EJournal.Location = new System.Drawing.Point(163, 139);
            this.cbxMore_EJournal.Name = "cbxMore_EJournal";
            this.cbxMore_EJournal.Size = new System.Drawing.Size(89, 24);
            this.cbxMore_EJournal.TabIndex = 15;
            this.cbxMore_EJournal.Text = "E-Journal";
            this.cbxMore_EJournal.UseVisualStyleBackColor = true;
            // 
            // cbxMore_Logs
            // 
            this.cbxMore_Logs.AutoSize = true;
            this.cbxMore_Logs.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_Logs.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_Logs.Location = new System.Drawing.Point(163, 169);
            this.cbxMore_Logs.Name = "cbxMore_Logs";
            this.cbxMore_Logs.Size = new System.Drawing.Size(59, 24);
            this.cbxMore_Logs.TabIndex = 57;
            this.cbxMore_Logs.Text = "Logs";
            this.cbxMore_Logs.UseVisualStyleBackColor = true;
            // 
            // cbxMore_RedeemSettings
            // 
            this.cbxMore_RedeemSettings.AutoSize = true;
            this.cbxMore_RedeemSettings.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_RedeemSettings.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_RedeemSettings.Location = new System.Drawing.Point(163, 199);
            this.cbxMore_RedeemSettings.Name = "cbxMore_RedeemSettings";
            this.cbxMore_RedeemSettings.Size = new System.Drawing.Size(140, 24);
            this.cbxMore_RedeemSettings.TabIndex = 58;
            this.cbxMore_RedeemSettings.Text = "Redeem Settings";
            this.cbxMore_RedeemSettings.UseVisualStyleBackColor = true;
            // 
            // cbxMore_ManageDiscounts
            // 
            this.cbxMore_ManageDiscounts.AutoSize = true;
            this.cbxMore_ManageDiscounts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_ManageDiscounts.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_ManageDiscounts.Location = new System.Drawing.Point(163, 229);
            this.cbxMore_ManageDiscounts.Name = "cbxMore_ManageDiscounts";
            this.cbxMore_ManageDiscounts.Size = new System.Drawing.Size(150, 24);
            this.cbxMore_ManageDiscounts.TabIndex = 60;
            this.cbxMore_ManageDiscounts.Text = "Manage Discounts";
            this.cbxMore_ManageDiscounts.UseVisualStyleBackColor = true;
            // 
            // cbxMore_ManageProducts
            // 
            this.cbxMore_ManageProducts.AutoSize = true;
            this.cbxMore_ManageProducts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_ManageProducts.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_ManageProducts.Location = new System.Drawing.Point(163, 259);
            this.cbxMore_ManageProducts.Name = "cbxMore_ManageProducts";
            this.cbxMore_ManageProducts.Size = new System.Drawing.Size(143, 24);
            this.cbxMore_ManageProducts.TabIndex = 59;
            this.cbxMore_ManageProducts.Text = "Manage Products";
            this.cbxMore_ManageProducts.UseVisualStyleBackColor = true;
            // 
            // cbxMore_Inventory
            // 
            this.cbxMore_Inventory.AutoSize = true;
            this.cbxMore_Inventory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_Inventory.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_Inventory.Location = new System.Drawing.Point(163, 289);
            this.cbxMore_Inventory.Name = "cbxMore_Inventory";
            this.cbxMore_Inventory.Size = new System.Drawing.Size(89, 24);
            this.cbxMore_Inventory.TabIndex = 61;
            this.cbxMore_Inventory.Text = "Inventory";
            this.cbxMore_Inventory.UseVisualStyleBackColor = true;
            // 
            // cbxMore_CloseStore
            // 
            this.cbxMore_CloseStore.AutoSize = true;
            this.cbxMore_CloseStore.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_CloseStore.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_CloseStore.Location = new System.Drawing.Point(163, 319);
            this.cbxMore_CloseStore.Name = "cbxMore_CloseStore";
            this.cbxMore_CloseStore.Size = new System.Drawing.Size(103, 24);
            this.cbxMore_CloseStore.TabIndex = 62;
            this.cbxMore_CloseStore.Text = "Close Store";
            this.cbxMore_CloseStore.UseVisualStyleBackColor = true;
            // 
            // cbxMore_Database
            // 
            this.cbxMore_Database.AutoSize = true;
            this.cbxMore_Database.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_Database.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_Database.Location = new System.Drawing.Point(163, 349);
            this.cbxMore_Database.Name = "cbxMore_Database";
            this.cbxMore_Database.Size = new System.Drawing.Size(91, 24);
            this.cbxMore_Database.TabIndex = 63;
            this.cbxMore_Database.Text = "Database";
            this.cbxMore_Database.UseVisualStyleBackColor = true;
            // 
            // cbxMore_Settings
            // 
            this.cbxMore_Settings.AutoSize = true;
            this.cbxMore_Settings.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_Settings.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_Settings.Location = new System.Drawing.Point(319, 3);
            this.cbxMore_Settings.Name = "cbxMore_Settings";
            this.cbxMore_Settings.Size = new System.Drawing.Size(81, 24);
            this.cbxMore_Settings.TabIndex = 64;
            this.cbxMore_Settings.Text = "Settings";
            this.cbxMore_Settings.UseVisualStyleBackColor = true;
            // 
            // cbxMore_CustomerMembership
            // 
            this.cbxMore_CustomerMembership.AutoSize = true;
            this.cbxMore_CustomerMembership.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_CustomerMembership.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_CustomerMembership.Location = new System.Drawing.Point(319, 33);
            this.cbxMore_CustomerMembership.Name = "cbxMore_CustomerMembership";
            this.cbxMore_CustomerMembership.Size = new System.Drawing.Size(178, 24);
            this.cbxMore_CustomerMembership.TabIndex = 68;
            this.cbxMore_CustomerMembership.Text = "Customer Membership";
            this.cbxMore_CustomerMembership.UseVisualStyleBackColor = true;
            // 
            // cbxMore_PayInOut
            // 
            this.cbxMore_PayInOut.AutoSize = true;
            this.cbxMore_PayInOut.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMore_PayInOut.ForeColor = System.Drawing.Color.Black;
            this.cbxMore_PayInOut.Location = new System.Drawing.Point(319, 63);
            this.cbxMore_PayInOut.Name = "cbxMore_PayInOut";
            this.cbxMore_PayInOut.Size = new System.Drawing.Size(96, 24);
            this.cbxMore_PayInOut.TabIndex = 56;
            this.cbxMore_PayInOut.Text = "Pay In/Out";
            this.cbxMore_PayInOut.UseVisualStyleBackColor = true;
            this.cbxMore_PayInOut.Visible = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(7, 95);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(224, 21);
            this.Label1.TabIndex = 55;
            this.Label1.Text = "Accessibility and Restriction";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(8, 60);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(80, 21);
            this.Label6.TabIndex = 52;
            this.Label6.Text = "Staff Type:";
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.SplitContainer1.Panel2;
            // 
            // StaffType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 579);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StaffType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffType";
            this.Load += new System.EventHandler(this.StaffType_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffType)).EndInit();
            this.flpPermission.ResumeLayout(false);
            this.flpPermission.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.FlowLayoutPanel flpPermission;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.CheckBox cbxOrd_Payment;
        internal System.Windows.Forms.CheckBox cbxOrd_Customer;
        internal System.Windows.Forms.CheckBox cbxOrd_Discount;
        internal System.Windows.Forms.CheckBox cbxOrd_VoidItem;
        internal System.Windows.Forms.CheckBox cbxOrd_VoidTransaction;
        internal System.Windows.Forms.CheckBox cbxOrd_CancelTransaction;
        internal System.Windows.Forms.CheckBox cbxOrd_RefundTransaction;
        internal System.Windows.Forms.CheckBox cbxOrd_ReturnExchange;
        internal System.Windows.Forms.CheckBox cbxOrd_RedeemItem;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.CheckBox cbxHome_SwitchCashier;
        internal System.Windows.Forms.CheckBox cbxHome_More;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.CheckBox cbxPay_PaymentMethod;
        internal System.Windows.Forms.CheckBox cbxPay_GiftCertificate;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.CheckBox cbxMore_EJournal;
        internal System.Windows.Forms.CheckBox cbxMore_PayInOut;
        internal System.Windows.Forms.CheckBox cbxMore_Logs;
        internal System.Windows.Forms.CheckBox cbxMore_RedeemSettings;
        internal System.Windows.Forms.CheckBox cbxMore_ManageDiscounts;
        internal System.Windows.Forms.CheckBox cbxMore_ManageProducts;
        internal System.Windows.Forms.CheckBox cbxMore_Inventory;
        internal System.Windows.Forms.CheckBox cbxMore_CloseStore;
        internal System.Windows.Forms.CheckBox cbxMore_Database;
        internal System.Windows.Forms.CheckBox cbxMore_Settings;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label6;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        internal FontAwesome.Sharp.IconButton btnAdd;
        internal System.Windows.Forms.CheckBox cbxMore_CustomerMembership;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        internal System.Windows.Forms.Label lblID;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.CheckBox cbxOrd_KeepTransaction;
        internal Guna.UI2.WinForms.Guna2TextBox txtStaffType;
        internal Guna.UI2.WinForms.Guna2DataGridView dgvStaffType;
        private Guna.UI.WinForms.GunaControlBox btnClose;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}