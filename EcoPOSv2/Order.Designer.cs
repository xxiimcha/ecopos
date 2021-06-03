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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OrderPanel = new System.Windows.Forms.Panel();
            this.enteredOrdersPanel = new System.Windows.Forms.Panel();
            this.dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnPayment = new Guna.UI2.WinForms.Guna2Button();
            this.btnRedeem = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnVoid = new Guna.UI2.WinForms.Guna2Button();
            this.lblOperation = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblZeroRated = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblVATExempt = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblVAT = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblVATSale = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblLessVAT = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
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
            this.OrderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderPanel.Location = new System.Drawing.Point(0, 0);
            this.OrderPanel.Name = "OrderPanel";
            this.OrderPanel.Size = new System.Drawing.Size(1164, 866);
            this.OrderPanel.TabIndex = 4;
            // 
            // enteredOrdersPanel
            // 
            this.enteredOrdersPanel.Controls.Add(this.dgvCart);
            this.enteredOrdersPanel.Controls.Add(this.tbBarcode);
            this.enteredOrdersPanel.Controls.Add(this.label6);
            this.enteredOrdersPanel.Location = new System.Drawing.Point(4, 6);
            this.enteredOrdersPanel.Name = "enteredOrdersPanel";
            this.enteredOrdersPanel.Size = new System.Drawing.Size(763, 860);
            this.enteredOrdersPanel.TabIndex = 3;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.ColumnHeadersHeight = 21;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.Location = new System.Drawing.Point(3, 75);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(757, 782);
            this.dgvCart.TabIndex = 19;
            this.dgvCart.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCart.ThemeStyle.HeaderStyle.Height = 21;
            this.dgvCart.ThemeStyle.ReadOnly = true;
            this.dgvCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCart.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tbBarcode
            // 
            this.tbBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBarcode.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBarcode.Location = new System.Drawing.Point(136, 0);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(627, 39);
            this.tbBarcode.TabIndex = 18;
            this.tbBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBarcode_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 37);
            this.label6.TabIndex = 17;
            this.label6.Text = "Barcode #";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnPayment);
            this.panel4.Controls.Add(this.btnRedeem);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnVoid);
            this.panel4.Controls.Add(this.lblOperation);
            this.panel4.Controls.Add(this.label31);
            this.panel4.Controls.Add(this.lblCustomer);
            this.panel4.Controls.Add(this.label29);
            this.panel4.Controls.Add(this.lblZeroRated);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Controls.Add(this.lblVATExempt);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.lblVAT);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.lblVATSale);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.lblLessVAT);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.label17);
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
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(773, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(391, 866);
            this.panel4.TabIndex = 0;
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.White;
            this.btnPayment.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnPayment.BorderThickness = 2;
            this.btnPayment.CheckedState.Parent = this.btnPayment;
            this.btnPayment.CustomImages.Parent = this.btnPayment;
            this.btnPayment.FillColor = System.Drawing.Color.White;
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnPayment.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnPayment.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPayment.HoverState.Parent = this.btnPayment;
            this.btnPayment.Location = new System.Drawing.Point(5, 777);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.ShadowDecoration.Parent = this.btnPayment;
            this.btnPayment.Size = new System.Drawing.Size(378, 76);
            this.btnPayment.TabIndex = 49;
            this.btnPayment.Text = "PAYMENT (CTRL + P)";
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnRedeem
            // 
            this.btnRedeem.BackColor = System.Drawing.Color.White;
            this.btnRedeem.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnRedeem.BorderThickness = 2;
            this.btnRedeem.CheckedState.Parent = this.btnRedeem;
            this.btnRedeem.CustomImages.Parent = this.btnRedeem;
            this.btnRedeem.FillColor = System.Drawing.Color.White;
            this.btnRedeem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRedeem.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRedeem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRedeem.HoverState.Parent = this.btnRedeem;
            this.btnRedeem.Location = new System.Drawing.Point(5, 601);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.ShadowDecoration.Parent = this.btnRedeem;
            this.btnRedeem.Size = new System.Drawing.Size(188, 52);
            this.btnRedeem.TabIndex = 48;
            this.btnRedeem.Text = "REDEEM ITEM (F7)";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(196, 546);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(188, 52);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "CANCEL TRANSACTION (F4)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnVoid
            // 
            this.btnVoid.BorderColor = System.Drawing.Color.Red;
            this.btnVoid.BorderThickness = 2;
            this.btnVoid.CheckedState.Parent = this.btnVoid;
            this.btnVoid.CustomImages.Parent = this.btnVoid;
            this.btnVoid.FillColor = System.Drawing.Color.White;
            this.btnVoid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnVoid.ForeColor = System.Drawing.Color.Red;
            this.btnVoid.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoid.HoverState.Parent = this.btnVoid;
            this.btnVoid.Location = new System.Drawing.Point(5, 546);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.ShadowDecoration.Parent = this.btnVoid;
            this.btnVoid.Size = new System.Drawing.Size(188, 52);
            this.btnVoid.TabIndex = 46;
            this.btnVoid.Text = "VOID TRANSACTION (F3)";
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // lblOperation
            // 
            this.lblOperation.BackColor = System.Drawing.Color.White;
            this.lblOperation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.ForeColor = System.Drawing.Color.Black;
            this.lblOperation.Location = new System.Drawing.Point(195, 420);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(191, 21);
            this.lblOperation.TabIndex = 45;
            this.lblOperation.Text = "Name";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.White;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(2, 420);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(80, 21);
            this.label31.TabIndex = 44;
            this.label31.Text = "Operation";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.White;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(195, 399);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(191, 21);
            this.lblCustomer.TabIndex = 43;
            this.lblCustomer.Text = "Name";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.White;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(2, 399);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(78, 21);
            this.label29.TabIndex = 42;
            this.label29.Text = "Customer";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZeroRated
            // 
            this.lblZeroRated.BackColor = System.Drawing.Color.White;
            this.lblZeroRated.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroRated.ForeColor = System.Drawing.Color.Black;
            this.lblZeroRated.Location = new System.Drawing.Point(195, 378);
            this.lblZeroRated.Name = "lblZeroRated";
            this.lblZeroRated.Size = new System.Drawing.Size(191, 21);
            this.lblZeroRated.TabIndex = 41;
            this.lblZeroRated.Text = "0.00";
            this.lblZeroRated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.White;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(2, 378);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 21);
            this.label27.TabIndex = 40;
            this.label27.Text = "Zero Rated";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVATExempt
            // 
            this.lblVATExempt.BackColor = System.Drawing.Color.White;
            this.lblVATExempt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATExempt.ForeColor = System.Drawing.Color.Black;
            this.lblVATExempt.Location = new System.Drawing.Point(195, 357);
            this.lblVATExempt.Name = "lblVATExempt";
            this.lblVATExempt.Size = new System.Drawing.Size(191, 21);
            this.lblVATExempt.TabIndex = 39;
            this.lblVATExempt.Text = "0.00";
            this.lblVATExempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.White;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(2, 357);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(87, 21);
            this.label25.TabIndex = 38;
            this.label25.Text = "Vat Exempt";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVAT
            // 
            this.lblVAT.BackColor = System.Drawing.Color.White;
            this.lblVAT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVAT.ForeColor = System.Drawing.Color.Black;
            this.lblVAT.Location = new System.Drawing.Point(195, 336);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(191, 21);
            this.lblVAT.TabIndex = 37;
            this.lblVAT.Text = "0.00";
            this.lblVAT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.White;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(2, 336);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 21);
            this.label23.TabIndex = 36;
            this.label23.Text = "Vat (12%)";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVATSale
            // 
            this.lblVATSale.BackColor = System.Drawing.Color.White;
            this.lblVATSale.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATSale.ForeColor = System.Drawing.Color.Black;
            this.lblVATSale.Location = new System.Drawing.Point(195, 315);
            this.lblVATSale.Name = "lblVATSale";
            this.lblVATSale.Size = new System.Drawing.Size(191, 21);
            this.lblVATSale.TabIndex = 35;
            this.lblVATSale.Text = "0.00";
            this.lblVATSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(2, 315);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 21);
            this.label21.TabIndex = 34;
            this.label21.Text = "Vatable Sale";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLessVAT
            // 
            this.lblLessVAT.BackColor = System.Drawing.Color.White;
            this.lblLessVAT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLessVAT.ForeColor = System.Drawing.Color.Black;
            this.lblLessVAT.Location = new System.Drawing.Point(195, 294);
            this.lblLessVAT.Name = "lblLessVAT";
            this.lblLessVAT.Size = new System.Drawing.Size(191, 21);
            this.lblLessVAT.TabIndex = 33;
            this.lblLessVAT.Text = "0.00";
            this.lblLessVAT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(2, 294);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 21);
            this.label19.TabIndex = 32;
            this.label19.Text = "Less Vat";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Green;
            this.lblTotal.Location = new System.Drawing.Point(196, 230);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(191, 45);
            this.lblTotal.TabIndex = 31;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Green;
            this.label17.Location = new System.Drawing.Point(-1, 230);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(126, 45);
            this.label17.TabIndex = 30;
            this.label17.Text = "TOTAL:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiscount
            // 
            this.lblDiscount.BackColor = System.Drawing.Color.White;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.Black;
            this.lblDiscount.Location = new System.Drawing.Point(195, 203);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(191, 21);
            this.lblDiscount.TabIndex = 29;
            this.lblDiscount.Text = "0.00";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(2, 203);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 21);
            this.label15.TabIndex = 28;
            this.label15.Text = "Discount";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.BackColor = System.Drawing.Color.White;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.Black;
            this.lblSubtotal.Location = new System.Drawing.Point(195, 182);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(191, 21);
            this.lblSubtotal.TabIndex = 27;
            this.lblSubtotal.Text = "0.00";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(2, 182);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 21);
            this.label13.TabIndex = 26;
            this.label13.Text = "Subtotal";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItems
            // 
            this.lblItems.BackColor = System.Drawing.Color.White;
            this.lblItems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.ForeColor = System.Drawing.Color.Black;
            this.lblItems.Location = new System.Drawing.Point(195, 161);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(191, 21);
            this.lblItems.TabIndex = 25;
            this.lblItems.Text = "0";
            this.lblItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(2, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 21);
            this.label11.TabIndex = 24;
            this.label11.Text = "No. of Items";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.BackColor = System.Drawing.Color.White;
            this.lblOrderNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.ForeColor = System.Drawing.Color.Black;
            this.lblOrderNumber.Location = new System.Drawing.Point(195, 140);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(191, 21);
            this.lblOrderNumber.TabIndex = 23;
            this.lblOrderNumber.Text = "0";
            this.lblOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(2, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 21);
            this.label8.TabIndex = 22;
            this.label8.Text = "Order No.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVoidItem
            // 
            this.btnVoidItem.BorderColor = System.Drawing.Color.Red;
            this.btnVoidItem.BorderThickness = 1;
            this.btnVoidItem.CheckedState.Parent = this.btnVoidItem;
            this.btnVoidItem.CustomImages.Parent = this.btnVoidItem;
            this.btnVoidItem.FillColor = System.Drawing.Color.White;
            this.btnVoidItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVoidItem.ForeColor = System.Drawing.Color.Red;
            this.btnVoidItem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoidItem.HoverState.Parent = this.btnVoidItem;
            this.btnVoidItem.Location = new System.Drawing.Point(293, 82);
            this.btnVoidItem.Name = "btnVoidItem";
            this.btnVoidItem.ShadowDecoration.Parent = this.btnVoidItem;
            this.btnVoidItem.Size = new System.Drawing.Size(95, 45);
            this.btnVoidItem.TabIndex = 21;
            this.btnVoidItem.Text = "VOID ITEM (CTRL + V)";
            this.btnVoidItem.Click += new System.EventHandler(this.btnVoidItem_Click);
            // 
            // btnQuantity
            // 
            this.btnQuantity.BorderColor = System.Drawing.Color.Green;
            this.btnQuantity.BorderThickness = 1;
            this.btnQuantity.CheckedState.Parent = this.btnQuantity;
            this.btnQuantity.CustomImages.Parent = this.btnQuantity;
            this.btnQuantity.FillColor = System.Drawing.Color.White;
            this.btnQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnQuantity.ForeColor = System.Drawing.Color.Green;
            this.btnQuantity.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnQuantity.HoverState.Parent = this.btnQuantity;
            this.btnQuantity.Location = new System.Drawing.Point(196, 82);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.ShadowDecoration.Parent = this.btnQuantity;
            this.btnQuantity.Size = new System.Drawing.Size(95, 45);
            this.btnQuantity.TabIndex = 20;
            this.btnQuantity.Text = "QUANTITY (CTRL +Q)";
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BorderColor = System.Drawing.Color.Navy;
            this.btnCustomer.BorderThickness = 1;
            this.btnCustomer.CheckedState.Parent = this.btnCustomer;
            this.btnCustomer.CustomImages.Parent = this.btnCustomer;
            this.btnCustomer.FillColor = System.Drawing.Color.White;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCustomer.ForeColor = System.Drawing.Color.Navy;
            this.btnCustomer.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCustomer.HoverState.Parent = this.btnCustomer;
            this.btnCustomer.Location = new System.Drawing.Point(99, 82);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.ShadowDecoration.Parent = this.btnCustomer;
            this.btnCustomer.Size = new System.Drawing.Size(95, 45);
            this.btnCustomer.TabIndex = 19;
            this.btnCustomer.Text = "CUSTOMER (CTRL + C)";
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDiscount.BorderThickness = 1;
            this.btnDiscount.CheckedState.Parent = this.btnDiscount;
            this.btnDiscount.CustomImages.Parent = this.btnDiscount;
            this.btnDiscount.FillColor = System.Drawing.Color.White;
            this.btnDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDiscount.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDiscount.HoverState.Parent = this.btnDiscount;
            this.btnDiscount.Location = new System.Drawing.Point(2, 82);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.ShadowDecoration.Parent = this.btnDiscount;
            this.btnDiscount.Size = new System.Drawing.Size(95, 45);
            this.btnDiscount.TabIndex = 18;
            this.btnDiscount.Text = "DISCOUNT (CTRL + D)";
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnWholeSale);
            this.guna2Panel1.Controls.Add(this.btnRetail);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 27);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(388, 56);
            this.guna2Panel1.TabIndex = 17;
            // 
            // btnWholeSale
            // 
            this.btnWholeSale.BorderRadius = 5;
            this.btnWholeSale.BorderThickness = 1;
            this.btnWholeSale.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnWholeSale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(230)))), ((int)(((byte)(82)))));
            this.btnWholeSale.CheckedState.Parent = this.btnWholeSale;
            this.btnWholeSale.CustomImages.Parent = this.btnWholeSale;
            this.btnWholeSale.FillColor = System.Drawing.Color.White;
            this.btnWholeSale.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWholeSale.ForeColor = System.Drawing.Color.Black;
            this.btnWholeSale.HoverState.Parent = this.btnWholeSale;
            this.btnWholeSale.Location = new System.Drawing.Point(197, 4);
            this.btnWholeSale.Name = "btnWholeSale";
            this.btnWholeSale.ShadowDecoration.Parent = this.btnWholeSale;
            this.btnWholeSale.Size = new System.Drawing.Size(180, 45);
            this.btnWholeSale.TabIndex = 20;
            this.btnWholeSale.Text = "WHOLESALE";
            this.btnWholeSale.Click += new System.EventHandler(this.btnWholeSale_Click);
            // 
            // btnRetail
            // 
            this.btnRetail.BorderRadius = 5;
            this.btnRetail.BorderThickness = 1;
            this.btnRetail.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnRetail.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(230)))), ((int)(((byte)(82)))));
            this.btnRetail.CheckedState.Parent = this.btnRetail;
            this.btnRetail.CustomImages.Parent = this.btnRetail;
            this.btnRetail.FillColor = System.Drawing.Color.White;
            this.btnRetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetail.ForeColor = System.Drawing.Color.Black;
            this.btnRetail.HoverState.Parent = this.btnRetail;
            this.btnRetail.Location = new System.Drawing.Point(11, 4);
            this.btnRetail.Name = "btnRetail";
            this.btnRetail.ShadowDecoration.Parent = this.btnRetail;
            this.btnRetail.Size = new System.Drawing.Size(180, 45);
            this.btnRetail.TabIndex = 19;
            this.btnRetail.Text = "RETAIL";
            this.btnRetail.Click += new System.EventHandler(this.btnRetail_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "PRICE MODE:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 866);
            this.Controls.Add(this.OrderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Order_KeyDown);
            this.OrderPanel.ResumeLayout(false);
            this.enteredOrdersPanel.ResumeLayout(false);
            this.enteredOrdersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel OrderPanel;
        private System.Windows.Forms.Panel enteredOrdersPanel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCart;
        internal System.Windows.Forms.TextBox tbBarcode;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Label lblOperation;
        internal System.Windows.Forms.Label label31;
        internal System.Windows.Forms.Label lblCustomer;
        internal System.Windows.Forms.Label label29;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.Label lblVATExempt;
        internal System.Windows.Forms.Label label25;
        internal System.Windows.Forms.Label lblVAT;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.Label lblVATSale;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label lblLessVAT;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label lblDiscount;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label lblSubtotal;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label lblItems;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label lblOrderNumber;
        internal System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button btnQuantity;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnWholeSale;
        private Guna.UI2.WinForms.Guna2Button btnRetail;
        internal System.Windows.Forms.Label label7;
        public Guna.UI2.WinForms.Guna2Button btnPayment;
        public Guna.UI2.WinForms.Guna2Button btnCustomer;
        public Guna.UI2.WinForms.Guna2Button btnDiscount;
        public Guna.UI2.WinForms.Guna2Button btnVoidItem;
        public Guna.UI2.WinForms.Guna2Button btnVoid;
        public Guna.UI2.WinForms.Guna2Button btnCancel;
        public Guna.UI2.WinForms.Guna2Button btnRedeem;
        public System.Windows.Forms.Label lblZeroRated;
    }
}