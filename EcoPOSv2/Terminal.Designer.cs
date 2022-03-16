namespace EcoPOSv2
{
    partial class Terminal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.cmbTerminalNames = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblterminal = new System.Windows.Forms.Label();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.CrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.cbxItemsSold = new System.Windows.Forms.CheckBox();
            this.cbxPaymentMethod = new System.Windows.Forms.CheckBox();
            this.cbxSpecialDiscounts = new System.Windows.Forms.CheckBox();
            this.cbxRegularDiscounts = new System.Windows.Forms.CheckBox();
            this.cbxVoidTransactions = new System.Windows.Forms.CheckBox();
            this.cbxVoidItems = new System.Windows.Forms.CheckBox();
            this.cbxWholesaleSales = new System.Windows.Forms.CheckBox();
            this.cbxRetailSales = new System.Windows.Forms.CheckBox();
            this.cbxStaffSales = new System.Windows.Forms.CheckBox();
            this.cbxSales = new System.Windows.Forms.CheckBox();
            this.cbxProfit = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExportToExcel = new Guna.UI2.WinForms.Guna2Button();
            this.dt = new System.Windows.Forms.DataGridView();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExport = new FontAwesome.Sharp.IconButton();
            this.btnGenerateEJournal = new FontAwesome.Sharp.IconButton();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Label13 = new System.Windows.Forms.Label();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Label14 = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TableLayoutPanel4.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.Controls.Add(this.Panel3, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.CrystalReportViewer1, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel2, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1090, 734);
            this.TableLayoutPanel1.TabIndex = 3;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.dtpFrom);
            this.Panel3.Controls.Add(this.Label13);
            this.Panel3.Controls.Add(this.dtpTo);
            this.Panel3.Controls.Add(this.Label14);
            this.Panel3.Controls.Add(this.cmbTerminalNames);
            this.Panel3.Controls.Add(this.lblterminal);
            this.Panel3.Controls.Add(this.btnSearch);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(3, 3);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(811, 45);
            this.Panel3.TabIndex = 0;
            // 
            // cmbTerminalNames
            // 
            this.cmbTerminalNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTerminalNames.BackColor = System.Drawing.Color.Transparent;
            this.cmbTerminalNames.BorderColor = System.Drawing.Color.Black;
            this.cmbTerminalNames.BorderRadius = 3;
            this.cmbTerminalNames.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTerminalNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerminalNames.FocusedColor = System.Drawing.Color.Empty;
            this.cmbTerminalNames.FocusedState.Parent = this.cmbTerminalNames;
            this.cmbTerminalNames.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTerminalNames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTerminalNames.FormattingEnabled = true;
            this.cmbTerminalNames.HoverState.Parent = this.cmbTerminalNames;
            this.cmbTerminalNames.ItemHeight = 30;
            this.cmbTerminalNames.ItemsAppearance.Parent = this.cmbTerminalNames;
            this.cmbTerminalNames.Location = new System.Drawing.Point(571, 4);
            this.cmbTerminalNames.Name = "cmbTerminalNames";
            this.cmbTerminalNames.ShadowDecoration.Parent = this.cmbTerminalNames;
            this.cmbTerminalNames.Size = new System.Drawing.Size(137, 36);
            this.cmbTerminalNames.TabIndex = 126;
            // 
            // lblterminal
            // 
            this.lblterminal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblterminal.BackColor = System.Drawing.Color.Transparent;
            this.lblterminal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblterminal.ForeColor = System.Drawing.Color.Black;
            this.lblterminal.Location = new System.Drawing.Point(478, 1);
            this.lblterminal.Name = "lblterminal";
            this.lblterminal.Size = new System.Drawing.Size(105, 42);
            this.lblterminal.TabIndex = 134;
            this.lblterminal.Text = "TERMINAL:";
            this.lblterminal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearch.IconColor = System.Drawing.Color.Black;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 31;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(714, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 45);
            this.btnSearch.TabIndex = 114;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // CrystalReportViewer1
            // 
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewer1.DisplayStatusBar = false;
            this.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalReportViewer1.Location = new System.Drawing.Point(3, 54);
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.ShowCloseButton = false;
            this.CrystalReportViewer1.ShowCopyButton = false;
            this.CrystalReportViewer1.ShowGroupTreeButton = false;
            this.CrystalReportViewer1.ShowParameterPanelButton = false;
            this.CrystalReportViewer1.Size = new System.Drawing.Size(811, 677);
            this.CrystalReportViewer1.TabIndex = 2;
            this.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel2.Controls.Add(this.Panel1, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.gunaLabel1, 0, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(820, 54);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 2;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.533235F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.46677F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(267, 677);
            this.TableLayoutPanel2.TabIndex = 3;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TableLayoutPanel4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 54);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(261, 620);
            this.Panel1.TabIndex = 1;
            // 
            // TableLayoutPanel4
            // 
            this.TableLayoutPanel4.ColumnCount = 3;
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel4.Controls.Add(this.cbSelectAll, 1, 0);
            this.TableLayoutPanel4.Controls.Add(this.cbxItemsSold, 1, 10);
            this.TableLayoutPanel4.Controls.Add(this.cbxPaymentMethod, 1, 9);
            this.TableLayoutPanel4.Controls.Add(this.cbxSpecialDiscounts, 1, 8);
            this.TableLayoutPanel4.Controls.Add(this.cbxRegularDiscounts, 1, 7);
            this.TableLayoutPanel4.Controls.Add(this.cbxVoidTransactions, 1, 6);
            this.TableLayoutPanel4.Controls.Add(this.cbxVoidItems, 1, 5);
            this.TableLayoutPanel4.Controls.Add(this.cbxWholesaleSales, 1, 4);
            this.TableLayoutPanel4.Controls.Add(this.cbxRetailSales, 1, 3);
            this.TableLayoutPanel4.Controls.Add(this.cbxStaffSales, 1, 2);
            this.TableLayoutPanel4.Controls.Add(this.cbxSales, 1, 1);
            this.TableLayoutPanel4.Controls.Add(this.cbxProfit, 1, 11);
            this.TableLayoutPanel4.Controls.Add(this.panel4, 1, 12);
            this.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel4.Name = "TableLayoutPanel4";
            this.TableLayoutPanel4.RowCount = 13;
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.109482F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.68622F));
            this.TableLayoutPanel4.Size = new System.Drawing.Size(261, 620);
            this.TableLayoutPanel4.TabIndex = 0;
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSelectAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectAll.Location = new System.Drawing.Point(29, 3);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(202, 31);
            this.cbSelectAll.TabIndex = 118;
            this.cbSelectAll.Text = "Select All";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // cbxItemsSold
            // 
            this.cbxItemsSold.AutoSize = true;
            this.cbxItemsSold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxItemsSold.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxItemsSold.ForeColor = System.Drawing.Color.Black;
            this.cbxItemsSold.Location = new System.Drawing.Point(29, 373);
            this.cbxItemsSold.Name = "cbxItemsSold";
            this.cbxItemsSold.Size = new System.Drawing.Size(202, 31);
            this.cbxItemsSold.TabIndex = 115;
            this.cbxItemsSold.Text = "Items Sold";
            this.cbxItemsSold.UseVisualStyleBackColor = true;
            // 
            // cbxPaymentMethod
            // 
            this.cbxPaymentMethod.AutoSize = true;
            this.cbxPaymentMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPaymentMethod.ForeColor = System.Drawing.Color.Black;
            this.cbxPaymentMethod.Location = new System.Drawing.Point(29, 336);
            this.cbxPaymentMethod.Name = "cbxPaymentMethod";
            this.cbxPaymentMethod.Size = new System.Drawing.Size(202, 31);
            this.cbxPaymentMethod.TabIndex = 107;
            this.cbxPaymentMethod.Text = "Payment Method";
            this.cbxPaymentMethod.UseVisualStyleBackColor = true;
            // 
            // cbxSpecialDiscounts
            // 
            this.cbxSpecialDiscounts.AutoSize = true;
            this.cbxSpecialDiscounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxSpecialDiscounts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSpecialDiscounts.ForeColor = System.Drawing.Color.Black;
            this.cbxSpecialDiscounts.Location = new System.Drawing.Point(29, 299);
            this.cbxSpecialDiscounts.Name = "cbxSpecialDiscounts";
            this.cbxSpecialDiscounts.Size = new System.Drawing.Size(202, 31);
            this.cbxSpecialDiscounts.TabIndex = 117;
            this.cbxSpecialDiscounts.Text = "Special Discounts";
            this.cbxSpecialDiscounts.UseVisualStyleBackColor = true;
            // 
            // cbxRegularDiscounts
            // 
            this.cbxRegularDiscounts.AutoSize = true;
            this.cbxRegularDiscounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxRegularDiscounts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRegularDiscounts.ForeColor = System.Drawing.Color.Black;
            this.cbxRegularDiscounts.Location = new System.Drawing.Point(29, 262);
            this.cbxRegularDiscounts.Name = "cbxRegularDiscounts";
            this.cbxRegularDiscounts.Size = new System.Drawing.Size(202, 31);
            this.cbxRegularDiscounts.TabIndex = 108;
            this.cbxRegularDiscounts.Text = "Regular Discounts";
            this.cbxRegularDiscounts.UseVisualStyleBackColor = true;
            // 
            // cbxVoidTransactions
            // 
            this.cbxVoidTransactions.AutoSize = true;
            this.cbxVoidTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxVoidTransactions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVoidTransactions.ForeColor = System.Drawing.Color.Black;
            this.cbxVoidTransactions.Location = new System.Drawing.Point(29, 225);
            this.cbxVoidTransactions.Name = "cbxVoidTransactions";
            this.cbxVoidTransactions.Size = new System.Drawing.Size(202, 31);
            this.cbxVoidTransactions.TabIndex = 112;
            this.cbxVoidTransactions.Text = "Void Transactions";
            this.cbxVoidTransactions.UseVisualStyleBackColor = true;
            // 
            // cbxVoidItems
            // 
            this.cbxVoidItems.AutoSize = true;
            this.cbxVoidItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxVoidItems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVoidItems.ForeColor = System.Drawing.Color.Black;
            this.cbxVoidItems.Location = new System.Drawing.Point(29, 188);
            this.cbxVoidItems.Name = "cbxVoidItems";
            this.cbxVoidItems.Size = new System.Drawing.Size(202, 31);
            this.cbxVoidItems.TabIndex = 113;
            this.cbxVoidItems.Text = "Void Items";
            this.cbxVoidItems.UseVisualStyleBackColor = true;
            // 
            // cbxWholesaleSales
            // 
            this.cbxWholesaleSales.AutoSize = true;
            this.cbxWholesaleSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxWholesaleSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxWholesaleSales.ForeColor = System.Drawing.Color.Black;
            this.cbxWholesaleSales.Location = new System.Drawing.Point(29, 151);
            this.cbxWholesaleSales.Name = "cbxWholesaleSales";
            this.cbxWholesaleSales.Size = new System.Drawing.Size(202, 31);
            this.cbxWholesaleSales.TabIndex = 110;
            this.cbxWholesaleSales.Text = "Wholesale Sales";
            this.cbxWholesaleSales.UseVisualStyleBackColor = true;
            // 
            // cbxRetailSales
            // 
            this.cbxRetailSales.AutoSize = true;
            this.cbxRetailSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxRetailSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRetailSales.ForeColor = System.Drawing.Color.Black;
            this.cbxRetailSales.Location = new System.Drawing.Point(29, 114);
            this.cbxRetailSales.Name = "cbxRetailSales";
            this.cbxRetailSales.Size = new System.Drawing.Size(202, 31);
            this.cbxRetailSales.TabIndex = 109;
            this.cbxRetailSales.Text = "Retail Sales";
            this.cbxRetailSales.UseVisualStyleBackColor = true;
            // 
            // cbxStaffSales
            // 
            this.cbxStaffSales.AutoSize = true;
            this.cbxStaffSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxStaffSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStaffSales.ForeColor = System.Drawing.Color.Black;
            this.cbxStaffSales.Location = new System.Drawing.Point(29, 77);
            this.cbxStaffSales.Name = "cbxStaffSales";
            this.cbxStaffSales.Size = new System.Drawing.Size(202, 31);
            this.cbxStaffSales.TabIndex = 114;
            this.cbxStaffSales.Text = "Staff Sales";
            this.cbxStaffSales.UseVisualStyleBackColor = true;
            // 
            // cbxSales
            // 
            this.cbxSales.AutoSize = true;
            this.cbxSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSales.ForeColor = System.Drawing.Color.Black;
            this.cbxSales.Location = new System.Drawing.Point(29, 40);
            this.cbxSales.Name = "cbxSales";
            this.cbxSales.Size = new System.Drawing.Size(202, 31);
            this.cbxSales.TabIndex = 106;
            this.cbxSales.Text = "Sales";
            this.cbxSales.UseVisualStyleBackColor = true;
            // 
            // cbxProfit
            // 
            this.cbxProfit.AutoSize = true;
            this.cbxProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxProfit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProfit.ForeColor = System.Drawing.Color.Black;
            this.cbxProfit.Location = new System.Drawing.Point(29, 410);
            this.cbxProfit.Name = "cbxProfit";
            this.cbxProfit.Size = new System.Drawing.Size(202, 31);
            this.cbxProfit.TabIndex = 115;
            this.cbxProfit.Text = "Profit";
            this.cbxProfit.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnExportToExcel);
            this.panel4.Controls.Add(this.dt);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(29, 447);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(202, 170);
            this.panel4.TabIndex = 119;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(96)))), ((int)(((byte)(25)))));
            this.btnExportToExcel.BorderRadius = 5;
            this.btnExportToExcel.BorderThickness = 1;
            this.btnExportToExcel.CheckedState.Parent = this.btnExportToExcel;
            this.btnExportToExcel.CustomImages.Parent = this.btnExportToExcel;
            this.btnExportToExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(96)))), ((int)(((byte)(25)))));
            this.btnExportToExcel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportToExcel.HoverState.Parent = this.btnExportToExcel;
            this.btnExportToExcel.Location = new System.Drawing.Point(7, 35);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.ShadowDecoration.Parent = this.btnExportToExcel;
            this.btnExportToExcel.Size = new System.Drawing.Size(189, 42);
            this.btnExportToExcel.TabIndex = 74;
            this.btnExportToExcel.Text = "EXPORT TO EXCEL";
            this.btnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // dt
            // 
            this.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt.Location = new System.Drawing.Point(7, 3);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(189, 31);
            this.dt.TabIndex = 0;
            this.dt.Visible = false;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.Location = new System.Drawing.Point(3, 0);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(261, 51);
            this.gunaLabel1.TabIndex = 2;
            this.gunaLabel1.Text = "Select from the items below:";
            this.gunaLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnExport, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnGenerateEJournal, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(820, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(267, 45);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.btnExport.IconColor = System.Drawing.Color.Black;
            this.btnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExport.IconSize = 27;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(3, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(127, 39);
            this.btnExport.TabIndex = 121;
            this.btnExport.Text = "Export Report";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnGenerateEJournal
            // 
            this.btnGenerateEJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateEJournal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnGenerateEJournal.FlatAppearance.BorderSize = 0;
            this.btnGenerateEJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateEJournal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerateEJournal.ForeColor = System.Drawing.Color.Black;
            this.btnGenerateEJournal.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnGenerateEJournal.IconColor = System.Drawing.Color.Black;
            this.btnGenerateEJournal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGenerateEJournal.IconSize = 27;
            this.btnGenerateEJournal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateEJournal.Location = new System.Drawing.Point(136, 3);
            this.btnGenerateEJournal.Name = "btnGenerateEJournal";
            this.btnGenerateEJournal.Size = new System.Drawing.Size(128, 39);
            this.btnGenerateEJournal.TabIndex = 102;
            this.btnGenerateEJournal.Text = "Generate E-Journal";
            this.btnGenerateEJournal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerateEJournal.UseVisualStyleBackColor = true;
            this.btnGenerateEJournal.Visible = false;
            this.btnGenerateEJournal.Click += new System.EventHandler(this.btnGenerateEJournal_Click);
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
            this.dtpFrom.TabIndex = 137;
            this.dtpFrom.Tag = "From";
            this.dtpFrom.Value = new System.DateTime(2021, 11, 22, 8, 55, 16, 532);
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
            this.Label13.TabIndex = 135;
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
            this.dtpTo.TabIndex = 138;
            this.dtpTo.Tag = "To";
            this.dtpTo.Value = new System.DateTime(2021, 11, 22, 8, 55, 16, 532);
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
            this.Label14.TabIndex = 136;
            this.Label14.Text = "TO";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 734);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Terminal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Terminal_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.TableLayoutPanel4.ResumeLayout(false);
            this.TableLayoutPanel4.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel4;
        internal System.Windows.Forms.CheckBox cbxRegularDiscounts;
        internal System.Windows.Forms.CheckBox cbxSales;
        internal System.Windows.Forms.CheckBox cbxStaffSales;
        internal System.Windows.Forms.CheckBox cbxVoidTransactions;
        internal System.Windows.Forms.CheckBox cbxRetailSales;
        internal System.Windows.Forms.CheckBox cbxWholesaleSales;
        internal System.Windows.Forms.CheckBox cbxVoidItems;
        internal System.Windows.Forms.CheckBox cbxItemsSold;
        internal System.Windows.Forms.CheckBox cbxPaymentMethod;
        internal System.Windows.Forms.CheckBox cbxSpecialDiscounts;
        internal FontAwesome.Sharp.IconButton btnGenerateEJournal;
        internal FontAwesome.Sharp.IconButton btnSearch;
        internal FontAwesome.Sharp.IconButton btnExport;
        internal CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer1;
        private System.Windows.Forms.CheckBox cbSelectAll;
        internal System.Windows.Forms.CheckBox cbxProfit;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2Button btnExportToExcel;
        private System.Windows.Forms.DataGridView dt;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTerminalNames;
        internal System.Windows.Forms.Label lblterminal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        internal System.Windows.Forms.Label Label13;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        internal System.Windows.Forms.Label Label14;
    }
}