namespace EcoPOSv2
{
    partial class StaffReport
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
            this.Label14 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cbxSales = new System.Windows.Forms.CheckBox();
            this.cbxItemsSold = new System.Windows.Forms.CheckBox();
            this.cbxRetailSales = new System.Windows.Forms.CheckBox();
            this.cbxWholesaleSales = new System.Windows.Forms.CheckBox();
            this.cbxRefund = new System.Windows.Forms.CheckBox();
            this.cbxReturnExchange = new System.Windows.Forms.CheckBox();
            this.cbxVoidItems = new System.Windows.Forms.CheckBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExport = new FontAwesome.Sharp.IconButton();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.cbxVoidTransactions = new System.Windows.Forms.CheckBox();
            this.cbxRegularDiscounts = new System.Windows.Forms.CheckBox();
            this.cbxPaymentMethod = new System.Windows.Forms.CheckBox();
            this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxSpecialDiscounts = new System.Windows.Forms.CheckBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TableLayoutPanel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.TableLayoutPanel4.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(3, 68);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(46, 34);
            this.Label14.TabIndex = 112;
            this.Label14.Text = "To";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "MMMM dd, yyyy HH:mm:ss";
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
            this.dtpTo.CustomFormat = "MMMM dd, yyyy HH:mm:ss";
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(55, 71);
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
            this.btnSearch.IconColor = System.Drawing.Color.Black;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 31;
            this.btnSearch.Location = new System.Drawing.Point(236, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(31, 28);
            this.btnSearch.TabIndex = 114;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbStaff
            // 
            this.cmbStaff.BackColor = System.Drawing.Color.White;
            this.cmbStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStaff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStaff.ForeColor = System.Drawing.Color.Black;
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Items.AddRange(new object[] {
            "All",
            "Order",
            "Refund",
            "Return",
            "Void"});
            this.cmbStaff.Location = new System.Drawing.Point(55, 105);
            this.cmbStaff.MaxDropDownItems = 10;
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(175, 29);
            this.cmbStaff.TabIndex = 122;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(3, 102);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 34);
            this.Label1.TabIndex = 123;
            this.Label1.Text = "Staff";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxSales
            // 
            this.cbxSales.AutoSize = true;
            this.cbxSales.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxSales.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSales.ForeColor = System.Drawing.Color.Black;
            this.cbxSales.Location = new System.Drawing.Point(30, 3);
            this.cbxSales.Name = "cbxSales";
            this.cbxSales.Size = new System.Drawing.Size(67, 33);
            this.cbxSales.TabIndex = 106;
            this.cbxSales.Text = "Sales";
            this.cbxSales.UseVisualStyleBackColor = true;
            // 
            // cbxItemsSold
            // 
            this.cbxItemsSold.AutoSize = true;
            this.cbxItemsSold.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxItemsSold.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxItemsSold.ForeColor = System.Drawing.Color.Black;
            this.cbxItemsSold.Location = new System.Drawing.Point(30, 393);
            this.cbxItemsSold.Name = "cbxItemsSold";
            this.cbxItemsSold.Size = new System.Drawing.Size(109, 33);
            this.cbxItemsSold.TabIndex = 115;
            this.cbxItemsSold.Text = "Items Sold";
            this.cbxItemsSold.UseVisualStyleBackColor = true;
            // 
            // cbxRetailSales
            // 
            this.cbxRetailSales.AutoSize = true;
            this.cbxRetailSales.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxRetailSales.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRetailSales.ForeColor = System.Drawing.Color.Black;
            this.cbxRetailSales.Location = new System.Drawing.Point(30, 42);
            this.cbxRetailSales.Name = "cbxRetailSales";
            this.cbxRetailSales.Size = new System.Drawing.Size(114, 33);
            this.cbxRetailSales.TabIndex = 109;
            this.cbxRetailSales.Text = "Retail Sales";
            this.cbxRetailSales.UseVisualStyleBackColor = true;
            // 
            // cbxWholesaleSales
            // 
            this.cbxWholesaleSales.AutoSize = true;
            this.cbxWholesaleSales.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxWholesaleSales.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxWholesaleSales.ForeColor = System.Drawing.Color.Black;
            this.cbxWholesaleSales.Location = new System.Drawing.Point(30, 81);
            this.cbxWholesaleSales.Name = "cbxWholesaleSales";
            this.cbxWholesaleSales.Size = new System.Drawing.Size(150, 33);
            this.cbxWholesaleSales.TabIndex = 110;
            this.cbxWholesaleSales.Text = "Wholesale Sales";
            this.cbxWholesaleSales.UseVisualStyleBackColor = true;
            // 
            // cbxRefund
            // 
            this.cbxRefund.AutoSize = true;
            this.cbxRefund.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxRefund.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRefund.ForeColor = System.Drawing.Color.Black;
            this.cbxRefund.Location = new System.Drawing.Point(30, 120);
            this.cbxRefund.Name = "cbxRefund";
            this.cbxRefund.Size = new System.Drawing.Size(83, 33);
            this.cbxRefund.TabIndex = 111;
            this.cbxRefund.Text = "Refund";
            this.cbxRefund.UseVisualStyleBackColor = true;
            // 
            // cbxReturnExchange
            // 
            this.cbxReturnExchange.AutoSize = true;
            this.cbxReturnExchange.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxReturnExchange.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxReturnExchange.ForeColor = System.Drawing.Color.Black;
            this.cbxReturnExchange.Location = new System.Drawing.Point(30, 159);
            this.cbxReturnExchange.Name = "cbxReturnExchange";
            this.cbxReturnExchange.Size = new System.Drawing.Size(160, 33);
            this.cbxReturnExchange.TabIndex = 116;
            this.cbxReturnExchange.Text = "Return/Exchange";
            this.cbxReturnExchange.UseVisualStyleBackColor = true;
            // 
            // cbxVoidItems
            // 
            this.cbxVoidItems.AutoSize = true;
            this.cbxVoidItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxVoidItems.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVoidItems.ForeColor = System.Drawing.Color.Black;
            this.cbxVoidItems.Location = new System.Drawing.Point(30, 198);
            this.cbxVoidItems.Name = "cbxVoidItems";
            this.cbxVoidItems.Size = new System.Drawing.Size(110, 33);
            this.cbxVoidItems.TabIndex = 113;
            this.cbxVoidItems.Text = "Void Items";
            this.cbxVoidItems.UseVisualStyleBackColor = true;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(3, 34);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(46, 34);
            this.Label13.TabIndex = 110;
            this.Label13.Text = "From";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.TableLayoutPanel3.Controls.Add(this.btnExport, 1, 4);
            this.TableLayoutPanel3.Controls.Add(this.cmbStaff, 1, 3);
            this.TableLayoutPanel3.Controls.Add(this.Label1, 0, 3);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 6;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(270, 209);
            this.TableLayoutPanel3.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(203)))), ((int)(((byte)(65)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.btnExport.IconColor = System.Drawing.Color.Black;
            this.btnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExport.IconSize = 31;
            this.btnExport.Location = new System.Drawing.Point(55, 139);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(175, 28);
            this.btnExport.TabIndex = 121;
            this.btnExport.Text = " Save Report";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
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
            // cbxVoidTransactions
            // 
            this.cbxVoidTransactions.AutoSize = true;
            this.cbxVoidTransactions.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxVoidTransactions.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVoidTransactions.ForeColor = System.Drawing.Color.Black;
            this.cbxVoidTransactions.Location = new System.Drawing.Point(30, 237);
            this.cbxVoidTransactions.Name = "cbxVoidTransactions";
            this.cbxVoidTransactions.Size = new System.Drawing.Size(162, 33);
            this.cbxVoidTransactions.TabIndex = 112;
            this.cbxVoidTransactions.Text = "Void Transactions";
            this.cbxVoidTransactions.UseVisualStyleBackColor = true;
            // 
            // cbxRegularDiscounts
            // 
            this.cbxRegularDiscounts.AutoSize = true;
            this.cbxRegularDiscounts.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxRegularDiscounts.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRegularDiscounts.ForeColor = System.Drawing.Color.Black;
            this.cbxRegularDiscounts.Location = new System.Drawing.Point(30, 276);
            this.cbxRegularDiscounts.Name = "cbxRegularDiscounts";
            this.cbxRegularDiscounts.Size = new System.Drawing.Size(166, 33);
            this.cbxRegularDiscounts.TabIndex = 108;
            this.cbxRegularDiscounts.Text = "Regular Discounts";
            this.cbxRegularDiscounts.UseVisualStyleBackColor = true;
            // 
            // cbxPaymentMethod
            // 
            this.cbxPaymentMethod.AutoSize = true;
            this.cbxPaymentMethod.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPaymentMethod.ForeColor = System.Drawing.Color.Black;
            this.cbxPaymentMethod.Location = new System.Drawing.Point(30, 354);
            this.cbxPaymentMethod.Name = "cbxPaymentMethod";
            this.cbxPaymentMethod.Size = new System.Drawing.Size(160, 33);
            this.cbxPaymentMethod.TabIndex = 107;
            this.cbxPaymentMethod.Text = "Payment Method";
            this.cbxPaymentMethod.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel4
            // 
            this.TableLayoutPanel4.ColumnCount = 3;
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel4.Controls.Add(this.cbxSales, 1, 0);
            this.TableLayoutPanel4.Controls.Add(this.cbxItemsSold, 1, 10);
            this.TableLayoutPanel4.Controls.Add(this.cbxRetailSales, 1, 1);
            this.TableLayoutPanel4.Controls.Add(this.cbxWholesaleSales, 1, 2);
            this.TableLayoutPanel4.Controls.Add(this.cbxRefund, 1, 3);
            this.TableLayoutPanel4.Controls.Add(this.cbxReturnExchange, 1, 4);
            this.TableLayoutPanel4.Controls.Add(this.cbxVoidItems, 1, 5);
            this.TableLayoutPanel4.Controls.Add(this.cbxVoidTransactions, 1, 6);
            this.TableLayoutPanel4.Controls.Add(this.cbxRegularDiscounts, 1, 7);
            this.TableLayoutPanel4.Controls.Add(this.cbxPaymentMethod, 1, 9);
            this.TableLayoutPanel4.Controls.Add(this.cbxSpecialDiscounts, 1, 8);
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
            this.TableLayoutPanel4.Size = new System.Drawing.Size(270, 639);
            this.TableLayoutPanel4.TabIndex = 0;
            // 
            // cbxSpecialDiscounts
            // 
            this.cbxSpecialDiscounts.AutoSize = true;
            this.cbxSpecialDiscounts.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxSpecialDiscounts.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSpecialDiscounts.ForeColor = System.Drawing.Color.Black;
            this.cbxSpecialDiscounts.Location = new System.Drawing.Point(30, 315);
            this.cbxSpecialDiscounts.Name = "cbxSpecialDiscounts";
            this.cbxSpecialDiscounts.Size = new System.Drawing.Size(161, 33);
            this.cbxSpecialDiscounts.TabIndex = 117;
            this.cbxSpecialDiscounts.Text = "Special Discounts";
            this.cbxSpecialDiscounts.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TableLayoutPanel4);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 218);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(270, 639);
            this.Panel1.TabIndex = 1;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel2.Controls.Add(this.Panel1, 0, 1);
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
            // Panel3
            // 
            this.Panel3.Controls.Add(this.TableLayoutPanel2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(3, 3);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(276, 860);
            this.Panel3.TabIndex = 0;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.25558F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.74442F));
            this.TableLayoutPanel1.Controls.Add(this.CrystalReportViewer1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Panel3, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1164, 866);
            this.TableLayoutPanel1.TabIndex = 4;
            // 
            // CrystalReportViewer1
            // 
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewer1.DisplayStatusBar = false;
            this.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalReportViewer1.Location = new System.Drawing.Point(285, 3);
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.ShowCloseButton = false;
            this.CrystalReportViewer1.ShowCopyButton = false;
            this.CrystalReportViewer1.ShowGroupTreeButton = false;
            this.CrystalReportViewer1.ShowParameterPanelButton = false;
            this.CrystalReportViewer1.Size = new System.Drawing.Size(876, 860);
            this.CrystalReportViewer1.TabIndex = 2;
            this.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // StaffReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 866);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StaffReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffReport";
            this.Load += new System.EventHandler(this.StaffReport_Load);
            this.TableLayoutPanel3.ResumeLayout(false);
            this.TableLayoutPanel3.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.TableLayoutPanel4.ResumeLayout(false);
            this.TableLayoutPanel4.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.DateTimePicker dtpFrom;
        internal System.Windows.Forms.DateTimePicker dtpTo;
        internal FontAwesome.Sharp.IconButton btnSearch;
        internal System.Windows.Forms.ComboBox cmbStaff;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.CheckBox cbxSales;
        internal System.Windows.Forms.CheckBox cbxItemsSold;
        internal System.Windows.Forms.CheckBox cbxRetailSales;
        internal System.Windows.Forms.CheckBox cbxWholesaleSales;
        internal System.Windows.Forms.CheckBox cbxRefund;
        internal System.Windows.Forms.CheckBox cbxReturnExchange;
        internal System.Windows.Forms.CheckBox cbxVoidItems;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal FontAwesome.Sharp.IconButton btnExport;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.CheckBox cbxVoidTransactions;
        internal System.Windows.Forms.CheckBox cbxRegularDiscounts;
        internal System.Windows.Forms.CheckBox cbxPaymentMethod;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel4;
        internal System.Windows.Forms.CheckBox cbxSpecialDiscounts;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer1;
    }
}