namespace EcoPOSv2
{
    partial class Order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OrderPanel = new System.Windows.Forms.Panel();
            this.enteredOrdersPanel = new System.Windows.Forms.Panel();
            this.dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnSeeItem = new Guna.UI2.WinForms.Guna2Button();
            this.tbBarcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBarcode = new Guna.UI2.WinForms.Guna2Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblLine = new Guna.UI.WinForms.GunaLabel();
            this.btnViewKeeps = new Guna.UI2.WinForms.Guna2Button();
            this.btnKeep = new Guna.UI2.WinForms.Guna2Button();
            this.btnPriceEditor = new Guna.UI2.WinForms.Guna2Button();
            this.btnPayment = new Guna.UI2.WinForms.Guna2Button();
            this.btnRedeem = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnVoid = new Guna.UI2.WinForms.Guna2Button();
            this.lblOperation = new System.Windows.Forms.Label();
            this.lblOperationt = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblCustomert = new System.Windows.Forms.Label();
            this.lblZeroRated = new System.Windows.Forms.Label();
            this.lblZeroRatedt = new System.Windows.Forms.Label();
            this.lblVATExempt = new System.Windows.Forms.Label();
            this.lblVATExemptt = new System.Windows.Forms.Label();
            this.lblVAT = new System.Windows.Forms.Label();
            this.lblVATt = new System.Windows.Forms.Label();
            this.lblVATSale = new System.Windows.Forms.Label();
            this.lblVATSalet = new System.Windows.Forms.Label();
            this.lblLessVAT = new System.Windows.Forms.Label();
            this.lblLessVATt = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnVoidItem = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuantity = new Guna.UI2.WinForms.Guna2Button();
            this.btnCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.btnDiscount = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnWholeSale = new Guna.UI2.WinForms.Guna2Button();
            this.btnRetail = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.OrderPanel.SuspendLayout();
            this.enteredOrdersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.panel4.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrderPanel
            // 
            this.OrderPanel.Controls.Add(this.enteredOrdersPanel);
            this.OrderPanel.Controls.Add(this.panel4);
            resources.ApplyResources(this.OrderPanel, "OrderPanel");
            this.OrderPanel.Name = "OrderPanel";
            // 
            // enteredOrdersPanel
            // 
            this.enteredOrdersPanel.Controls.Add(this.dgvCart);
            this.enteredOrdersPanel.Controls.Add(this.btnSeeItem);
            this.enteredOrdersPanel.Controls.Add(this.tbBarcode);
            this.enteredOrdersPanel.Controls.Add(this.btnBarcode);
            resources.ApplyResources(this.enteredOrdersPanel, "enteredOrdersPanel");
            this.enteredOrdersPanel.Name = "enteredOrdersPanel";
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgvCart, "dgvCart");
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowTemplate.DividerHeight = 1;
            this.dgvCart.RowTemplate.Height = 35;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCart.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvCart.ThemeStyle.ReadOnly = true;
            this.dgvCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCart.ThemeStyle.RowsStyle.Height = 35;
            this.dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCart.Click += new System.EventHandler(this.dgvCart_Click);
            this.dgvCart.DoubleClick += new System.EventHandler(this.dgvCart_DoubleClick);
            // 
            // btnSeeItem
            // 
            resources.ApplyResources(this.btnSeeItem, "btnSeeItem");
            this.btnSeeItem.BorderRadius = 5;
            this.btnSeeItem.CheckedState.Parent = this.btnSeeItem;
            this.btnSeeItem.CustomImages.Parent = this.btnSeeItem;
            this.btnSeeItem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.btnSeeItem.ForeColor = System.Drawing.Color.White;
            this.btnSeeItem.HoverState.Parent = this.btnSeeItem;
            this.btnSeeItem.Name = "btnSeeItem";
            this.btnSeeItem.ShadowDecoration.Parent = this.btnSeeItem;
            this.btnSeeItem.Click += new System.EventHandler(this.btnSeeItem_Click);
            // 
            // tbBarcode
            // 
            resources.ApplyResources(this.tbBarcode, "tbBarcode");
            this.tbBarcode.Animated = true;
            this.tbBarcode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(119)))), ((int)(((byte)(252)))));
            this.tbBarcode.BorderRadius = 5;
            this.tbBarcode.BorderThickness = 2;
            this.tbBarcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbBarcode.DefaultText = "";
            this.tbBarcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbBarcode.DisabledState.Parent = this.tbBarcode;
            this.tbBarcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbBarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbBarcode.FocusedState.Parent = this.tbBarcode;
            this.tbBarcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbBarcode.HoverState.Parent = this.tbBarcode;
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.PasswordChar = '\0';
            this.tbBarcode.PlaceholderText = "";
            this.tbBarcode.SelectedText = "";
            this.tbBarcode.ShadowDecoration.Parent = this.tbBarcode;
            this.tbBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBarcode_KeyDown);
            this.tbBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBarcode_KeyPress);
            this.tbBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBarcode_KeyUp);
            // 
            // btnBarcode
            // 
            this.btnBarcode.BorderRadius = 5;
            this.btnBarcode.CheckedState.Parent = this.btnBarcode;
            this.btnBarcode.CustomImages.Parent = this.btnBarcode;
            this.btnBarcode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btnBarcode, "btnBarcode");
            this.btnBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(119)))), ((int)(((byte)(252)))));
            this.btnBarcode.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.btnBarcode.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.btnBarcode.HoverState.Parent = this.btnBarcode;
            this.btnBarcode.Image = global::EcoPOSv2.Properties.Resources.code;
            this.btnBarcode.ImageSize = new System.Drawing.Size(30, 40);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.btnBarcode.ShadowDecoration.Parent = this.btnBarcode;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblLine);
            this.panel4.Controls.Add(this.btnViewKeeps);
            this.panel4.Controls.Add(this.btnKeep);
            this.panel4.Controls.Add(this.btnPriceEditor);
            this.panel4.Controls.Add(this.btnPayment);
            this.panel4.Controls.Add(this.btnRedeem);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnVoid);
            this.panel4.Controls.Add(this.lblOperation);
            this.panel4.Controls.Add(this.lblOperationt);
            this.panel4.Controls.Add(this.lblCustomer);
            this.panel4.Controls.Add(this.lblCustomert);
            this.panel4.Controls.Add(this.lblZeroRated);
            this.panel4.Controls.Add(this.lblZeroRatedt);
            this.panel4.Controls.Add(this.lblVATExempt);
            this.panel4.Controls.Add(this.lblVATExemptt);
            this.panel4.Controls.Add(this.lblVAT);
            this.panel4.Controls.Add(this.lblVATt);
            this.panel4.Controls.Add(this.lblVATSale);
            this.panel4.Controls.Add(this.lblVATSalet);
            this.panel4.Controls.Add(this.lblLessVAT);
            this.panel4.Controls.Add(this.lblLessVATt);
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.lblTotalTitle);
            this.panel4.Controls.Add(this.lblDiscount);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.lblSubtotal);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.lblItems);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.lblOrderNumber);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.btnVoidItem);
            this.panel4.Controls.Add(this.btnQuantity);
            this.panel4.Controls.Add(this.btnCustomer);
            this.panel4.Controls.Add(this.btnDiscount);
            this.panel4.Controls.Add(this.guna2Panel1);
            this.panel4.Controls.Add(this.label7);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // lblLine
            // 
            this.lblLine.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblLine, "lblLine");
            this.lblLine.Image = global::EcoPOSv2.Properties.Resources.paymentline;
            this.lblLine.Name = "lblLine";
            // 
            // btnViewKeeps
            // 
            resources.ApplyResources(this.btnViewKeeps, "btnViewKeeps");
            this.btnViewKeeps.BackColor = System.Drawing.Color.Transparent;
            this.btnViewKeeps.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(214)))));
            this.btnViewKeeps.BorderRadius = 3;
            this.btnViewKeeps.BorderThickness = 1;
            this.btnViewKeeps.CheckedState.Parent = this.btnViewKeeps;
            this.btnViewKeeps.CustomImages.Parent = this.btnViewKeeps;
            this.btnViewKeeps.FillColor = System.Drawing.Color.White;
            this.btnViewKeeps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnViewKeeps.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.btnViewKeeps.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnViewKeeps.HoverState.Parent = this.btnViewKeeps;
            this.btnViewKeeps.Name = "btnViewKeeps";
            this.btnViewKeeps.ShadowDecoration.BorderRadius = 3;
            this.btnViewKeeps.ShadowDecoration.Depth = 50;
            this.btnViewKeeps.ShadowDecoration.Enabled = true;
            this.btnViewKeeps.ShadowDecoration.Parent = this.btnViewKeeps;
            this.btnViewKeeps.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnViewKeeps.Click += new System.EventHandler(this.btnViewKeep);
            // 
            // btnKeep
            // 
            resources.ApplyResources(this.btnKeep, "btnKeep");
            this.btnKeep.BackColor = System.Drawing.Color.Transparent;
            this.btnKeep.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(214)))));
            this.btnKeep.BorderRadius = 3;
            this.btnKeep.BorderThickness = 1;
            this.btnKeep.CheckedState.Parent = this.btnKeep;
            this.btnKeep.CustomImages.Parent = this.btnKeep;
            this.btnKeep.FillColor = System.Drawing.Color.White;
            this.btnKeep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnKeep.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.btnKeep.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnKeep.HoverState.Parent = this.btnKeep;
            this.btnKeep.Name = "btnKeep";
            this.btnKeep.ShadowDecoration.BorderRadius = 3;
            this.btnKeep.ShadowDecoration.Depth = 50;
            this.btnKeep.ShadowDecoration.Enabled = true;
            this.btnKeep.ShadowDecoration.Parent = this.btnKeep;
            this.btnKeep.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
            // 
            // btnPriceEditor
            // 
            resources.ApplyResources(this.btnPriceEditor, "btnPriceEditor");
            this.btnPriceEditor.BackColor = System.Drawing.Color.Transparent;
            this.btnPriceEditor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(214)))));
            this.btnPriceEditor.BorderRadius = 3;
            this.btnPriceEditor.BorderThickness = 1;
            this.btnPriceEditor.CheckedState.Parent = this.btnPriceEditor;
            this.btnPriceEditor.CustomImages.Parent = this.btnPriceEditor;
            this.btnPriceEditor.FillColor = System.Drawing.Color.White;
            this.btnPriceEditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnPriceEditor.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.btnPriceEditor.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnPriceEditor.HoverState.Parent = this.btnPriceEditor;
            this.btnPriceEditor.Name = "btnPriceEditor";
            this.btnPriceEditor.ShadowDecoration.BorderRadius = 3;
            this.btnPriceEditor.ShadowDecoration.Depth = 50;
            this.btnPriceEditor.ShadowDecoration.Enabled = true;
            this.btnPriceEditor.ShadowDecoration.Parent = this.btnPriceEditor;
            this.btnPriceEditor.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnPriceEditor.Click += new System.EventHandler(this.btnPriceEditor_Click);
            // 
            // btnPayment
            // 
            resources.ApplyResources(this.btnPayment, "btnPayment");
            this.btnPayment.BackColor = System.Drawing.Color.White;
            this.btnPayment.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnPayment.BorderRadius = 5;
            this.btnPayment.BorderThickness = 2;
            this.btnPayment.CheckedState.Parent = this.btnPayment;
            this.btnPayment.CustomImages.Parent = this.btnPayment;
            this.btnPayment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.HoverState.BorderColor = System.Drawing.Color.Green;
            this.btnPayment.HoverState.FillColor = System.Drawing.Color.Green;
            this.btnPayment.HoverState.Parent = this.btnPayment;
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPayment.ShadowDecoration.Depth = 50;
            this.btnPayment.ShadowDecoration.Parent = this.btnPayment;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnRedeem
            // 
            resources.ApplyResources(this.btnRedeem, "btnRedeem");
            this.btnRedeem.BackColor = System.Drawing.Color.Transparent;
            this.btnRedeem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(214)))));
            this.btnRedeem.BorderRadius = 3;
            this.btnRedeem.BorderThickness = 1;
            this.btnRedeem.CheckedState.Parent = this.btnRedeem;
            this.btnRedeem.CustomImages.Parent = this.btnRedeem;
            this.btnRedeem.FillColor = System.Drawing.Color.White;
            this.btnRedeem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnRedeem.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.btnRedeem.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnRedeem.HoverState.Parent = this.btnRedeem;
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.ShadowDecoration.BorderRadius = 3;
            this.btnRedeem.ShadowDecoration.Depth = 50;
            this.btnRedeem.ShadowDecoration.Enabled = true;
            this.btnRedeem.ShadowDecoration.Parent = this.btnRedeem;
            this.btnRedeem.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnRedeem.Click += new System.EventHandler(this.btnRedeem_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(214)))));
            this.btnCancel.BorderRadius = 3;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.BorderRadius = 3;
            this.btnCancel.ShadowDecoration.Depth = 50;
            this.btnCancel.ShadowDecoration.Enabled = true;
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnVoid
            // 
            resources.ApplyResources(this.btnVoid, "btnVoid");
            this.btnVoid.BackColor = System.Drawing.Color.Transparent;
            this.btnVoid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(214)))));
            this.btnVoid.BorderRadius = 3;
            this.btnVoid.BorderThickness = 1;
            this.btnVoid.CheckedState.Parent = this.btnVoid;
            this.btnVoid.CustomImages.Parent = this.btnVoid;
            this.btnVoid.FillColor = System.Drawing.Color.White;
            this.btnVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnVoid.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.btnVoid.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnVoid.HoverState.Parent = this.btnVoid;
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.ShadowDecoration.BorderRadius = 3;
            this.btnVoid.ShadowDecoration.Depth = 50;
            this.btnVoid.ShadowDecoration.Enabled = true;
            this.btnVoid.ShadowDecoration.Parent = this.btnVoid;
            this.btnVoid.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // lblOperation
            // 
            this.lblOperation.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblOperation, "lblOperation");
            this.lblOperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblOperation.Name = "lblOperation";
            // 
            // lblOperationt
            // 
            resources.ApplyResources(this.lblOperationt, "lblOperationt");
            this.lblOperationt.BackColor = System.Drawing.Color.White;
            this.lblOperationt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblOperationt.Name = "lblOperationt";
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblCustomer, "lblCustomer");
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblCustomer.Name = "lblCustomer";
            // 
            // lblCustomert
            // 
            resources.ApplyResources(this.lblCustomert, "lblCustomert");
            this.lblCustomert.BackColor = System.Drawing.Color.White;
            this.lblCustomert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblCustomert.Name = "lblCustomert";
            // 
            // lblZeroRated
            // 
            this.lblZeroRated.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblZeroRated, "lblZeroRated");
            this.lblZeroRated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblZeroRated.Name = "lblZeroRated";
            // 
            // lblZeroRatedt
            // 
            resources.ApplyResources(this.lblZeroRatedt, "lblZeroRatedt");
            this.lblZeroRatedt.BackColor = System.Drawing.Color.White;
            this.lblZeroRatedt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblZeroRatedt.Name = "lblZeroRatedt";
            // 
            // lblVATExempt
            // 
            this.lblVATExempt.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblVATExempt, "lblVATExempt");
            this.lblVATExempt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblVATExempt.Name = "lblVATExempt";
            // 
            // lblVATExemptt
            // 
            resources.ApplyResources(this.lblVATExemptt, "lblVATExemptt");
            this.lblVATExemptt.BackColor = System.Drawing.Color.White;
            this.lblVATExemptt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblVATExemptt.Name = "lblVATExemptt";
            // 
            // lblVAT
            // 
            this.lblVAT.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblVAT, "lblVAT");
            this.lblVAT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblVAT.Name = "lblVAT";
            // 
            // lblVATt
            // 
            resources.ApplyResources(this.lblVATt, "lblVATt");
            this.lblVATt.BackColor = System.Drawing.Color.White;
            this.lblVATt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblVATt.Name = "lblVATt";
            // 
            // lblVATSale
            // 
            this.lblVATSale.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblVATSale, "lblVATSale");
            this.lblVATSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblVATSale.Name = "lblVATSale";
            // 
            // lblVATSalet
            // 
            resources.ApplyResources(this.lblVATSalet, "lblVATSalet");
            this.lblVATSalet.BackColor = System.Drawing.Color.White;
            this.lblVATSalet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblVATSalet.Name = "lblVATSalet";
            // 
            // lblLessVAT
            // 
            this.lblLessVAT.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblLessVAT, "lblLessVAT");
            this.lblLessVAT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblLessVAT.Name = "lblLessVAT";
            // 
            // lblLessVATt
            // 
            resources.ApplyResources(this.lblLessVATt, "lblLessVATt");
            this.lblLessVATt.BackColor = System.Drawing.Color.White;
            this.lblLessVATt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblLessVATt.Name = "lblLessVATt";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.lblTotal.Name = "lblTotal";
            // 
            // lblTotalTitle
            // 
            resources.ApplyResources(this.lblTotalTitle, "lblTotalTitle");
            this.lblTotalTitle.BackColor = System.Drawing.Color.White;
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.lblTotalTitle.Name = "lblTotalTitle";
            // 
            // lblDiscount
            // 
            this.lblDiscount.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblDiscount, "lblDiscount");
            this.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblDiscount.Name = "lblDiscount";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.label15.Name = "label15";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblSubtotal, "lblSubtotal");
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblSubtotal.Name = "lblSubtotal";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.label13.Name = "label13";
            // 
            // lblItems
            // 
            this.lblItems.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblItems, "lblItems");
            this.lblItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblItems.Name = "lblItems";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.label11.Name = "label11";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblOrderNumber, "lblOrderNumber");
            this.lblOrderNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.lblOrderNumber.Name = "lblOrderNumber";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.label8.Name = "label8";
            // 
            // btnVoidItem
            // 
            this.btnVoidItem.BorderColor = System.Drawing.Color.Red;
            this.btnVoidItem.BorderRadius = 5;
            this.btnVoidItem.BorderThickness = 1;
            this.btnVoidItem.CheckedState.Parent = this.btnVoidItem;
            this.btnVoidItem.CustomImages.Parent = this.btnVoidItem;
            this.btnVoidItem.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnVoidItem, "btnVoidItem");
            this.btnVoidItem.ForeColor = System.Drawing.Color.Red;
            this.btnVoidItem.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btnVoidItem.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnVoidItem.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoidItem.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnVoidItem.HoverState.Parent = this.btnVoidItem;
            this.btnVoidItem.Name = "btnVoidItem";
            this.btnVoidItem.ShadowDecoration.Parent = this.btnVoidItem;
            this.btnVoidItem.Click += new System.EventHandler(this.btnVoidItem_Click);
            // 
            // btnQuantity
            // 
            this.btnQuantity.BorderColor = System.Drawing.Color.Green;
            this.btnQuantity.BorderRadius = 5;
            this.btnQuantity.BorderThickness = 1;
            this.btnQuantity.CheckedState.Parent = this.btnQuantity;
            this.btnQuantity.CustomImages.Parent = this.btnQuantity;
            this.btnQuantity.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnQuantity, "btnQuantity");
            this.btnQuantity.ForeColor = System.Drawing.Color.Green;
            this.btnQuantity.HoverState.BorderColor = System.Drawing.Color.Green;
            this.btnQuantity.HoverState.FillColor = System.Drawing.Color.Green;
            this.btnQuantity.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuantity.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnQuantity.HoverState.Parent = this.btnQuantity;
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.ShadowDecoration.Parent = this.btnQuantity;
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BorderColor = System.Drawing.Color.Navy;
            this.btnCustomer.BorderRadius = 5;
            this.btnCustomer.BorderThickness = 1;
            this.btnCustomer.CheckedState.Parent = this.btnCustomer;
            this.btnCustomer.CustomImages.Parent = this.btnCustomer;
            this.btnCustomer.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnCustomer, "btnCustomer");
            this.btnCustomer.ForeColor = System.Drawing.Color.Navy;
            this.btnCustomer.HoverState.BorderColor = System.Drawing.Color.Navy;
            this.btnCustomer.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnCustomer.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.HoverState.Parent = this.btnCustomer;
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.ShadowDecoration.Parent = this.btnCustomer;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDiscount.BorderRadius = 5;
            this.btnDiscount.BorderThickness = 1;
            this.btnDiscount.CheckedState.Parent = this.btnDiscount;
            this.btnDiscount.CustomImages.Parent = this.btnDiscount;
            this.btnDiscount.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnDiscount, "btnDiscount");
            this.btnDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDiscount.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDiscount.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnDiscount.HoverState.Parent = this.btnDiscount;
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.ShadowDecoration.Parent = this.btnDiscount;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnWholeSale);
            this.guna2Panel1.Controls.Add(this.btnRetail);
            resources.ApplyResources(this.guna2Panel1, "guna2Panel1");
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            // 
            // btnWholeSale
            // 
            this.btnWholeSale.BackColor = System.Drawing.Color.Transparent;
            this.btnWholeSale.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnWholeSale.BorderRadius = 5;
            this.btnWholeSale.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnWholeSale.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnWholeSale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnWholeSale.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnWholeSale.CheckedState.Parent = this.btnWholeSale;
            this.btnWholeSale.CustomImages.Parent = this.btnWholeSale;
            this.btnWholeSale.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnWholeSale, "btnWholeSale");
            this.btnWholeSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnWholeSale.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnWholeSale.HoverState.Parent = this.btnWholeSale;
            this.btnWholeSale.Name = "btnWholeSale";
            this.btnWholeSale.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnWholeSale.ShadowDecoration.Depth = 50;
            this.btnWholeSale.ShadowDecoration.Enabled = true;
            this.btnWholeSale.ShadowDecoration.Parent = this.btnWholeSale;
            this.btnWholeSale.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnWholeSale.Click += new System.EventHandler(this.btnWholeSale_Click);
            // 
            // btnRetail
            // 
            this.btnRetail.BackColor = System.Drawing.Color.Transparent;
            this.btnRetail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnRetail.BorderRadius = 5;
            this.btnRetail.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnRetail.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnRetail.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnRetail.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnRetail.CheckedState.Parent = this.btnRetail;
            this.btnRetail.CustomImages.Parent = this.btnRetail;
            this.btnRetail.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnRetail, "btnRetail");
            this.btnRetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnRetail.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnRetail.HoverState.Parent = this.btnRetail;
            this.btnRetail.Name = "btnRetail";
            this.btnRetail.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btnRetail.ShadowDecoration.Depth = 50;
            this.btnRetail.ShadowDecoration.Enabled = true;
            this.btnRetail.ShadowDecoration.Parent = this.btnRetail;
            this.btnRetail.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.btnRetail.Click += new System.EventHandler(this.btnRetail_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.label7.Name = "label7";
            // 
            // Order
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.OrderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Order";
            this.Activated += new System.EventHandler(this.Order_Activated);
            this.Load += new System.EventHandler(this.Order_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Order_KeyDown);
            this.OrderPanel.ResumeLayout(false);
            this.enteredOrdersPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel OrderPanel;
        private System.Windows.Forms.Panel enteredOrdersPanel;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Label lblOperation;
        internal System.Windows.Forms.Label lblOperationt;
        internal System.Windows.Forms.Label lblCustomer;
        internal System.Windows.Forms.Label lblCustomert;
        internal System.Windows.Forms.Label lblZeroRatedt;
        internal System.Windows.Forms.Label lblVATExempt;
        internal System.Windows.Forms.Label lblVATExemptt;
        internal System.Windows.Forms.Label lblVAT;
        internal System.Windows.Forms.Label lblVATt;
        internal System.Windows.Forms.Label lblVATSale;
        internal System.Windows.Forms.Label lblVATSalet;
        internal System.Windows.Forms.Label lblLessVAT;
        internal System.Windows.Forms.Label lblLessVATt;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Label lblTotalTitle;
        internal System.Windows.Forms.Label lblDiscount;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label lblSubtotal;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label lblItems;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label lblOrderNumber;
        internal System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnWholeSale;
        private Guna.UI2.WinForms.Guna2Button btnRetail;
        internal System.Windows.Forms.Label label7;
        public Guna.UI2.WinForms.Guna2Button btnPayment;
        public Guna.UI2.WinForms.Guna2Button btnCustomer;
        public Guna.UI2.WinForms.Guna2Button btnDiscount;
        public Guna.UI2.WinForms.Guna2Button btnVoidItem;
        public Guna.UI2.WinForms.Guna2Button btnCancel;
        public Guna.UI2.WinForms.Guna2Button btnRedeem;
        public System.Windows.Forms.Label lblZeroRated;
        public Guna.UI2.WinForms.Guna2Button btnVoid;
        public Guna.UI2.WinForms.Guna2Button btnQuantity;
        public Guna.UI2.WinForms.Guna2Button btnPriceEditor;
        public Guna.UI2.WinForms.Guna2Button btnKeep;
        public Guna.UI2.WinForms.Guna2Button btnViewKeeps;
        private Guna.UI2.WinForms.Guna2Button btnBarcode;
        public Guna.UI2.WinForms.Guna2TextBox tbBarcode;
        private Guna.UI2.WinForms.Guna2Button btnSeeItem;
        public Guna.UI2.WinForms.Guna2DataGridView dgvCart;
        private Guna.UI.WinForms.GunaLabel lblLine;
    }
}