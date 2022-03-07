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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OrderPanel = new System.Windows.Forms.Panel();
            this.enteredOrdersPanel = new System.Windows.Forms.Panel();
            this.dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
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
            resources.ApplyResources(this.OrderPanel, "OrderPanel");
            this.OrderPanel.Controls.Add(this.enteredOrdersPanel);
            this.OrderPanel.Controls.Add(this.panel4);
            this.OrderPanel.Name = "OrderPanel";
            // 
            // enteredOrdersPanel
            // 
            resources.ApplyResources(this.enteredOrdersPanel, "enteredOrdersPanel");
            this.enteredOrdersPanel.Controls.Add(this.dgvCart);
            this.enteredOrdersPanel.Controls.Add(this.tbBarcode);
            this.enteredOrdersPanel.Controls.Add(this.label6);
            this.enteredOrdersPanel.Name = "enteredOrdersPanel";
            // 
            // dgvCart
            // 
            resources.ApplyResources(this.dgvCart, "dgvCart");
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AllowUserToResizeColumns = false;
            this.dgvCart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
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
            this.dgvCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCart.ThemeStyle.HeaderStyle.Height = 25;
            this.dgvCart.ThemeStyle.ReadOnly = true;
            this.dgvCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCart.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCart.Click += new System.EventHandler(this.dgvCart_Click);
            this.dgvCart.DoubleClick += new System.EventHandler(this.dgvCart_DoubleClick);
            // 
            // tbBarcode
            // 
            resources.ApplyResources(this.tbBarcode, "tbBarcode");
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBarcode_KeyDown);
            this.tbBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBarcode_KeyPress);
            this.tbBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBarcode_KeyUp);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Name = "label6";
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel4.Name = "panel4";
            // 
            // btnViewKeeps
            // 
            resources.ApplyResources(this.btnViewKeeps, "btnViewKeeps");
            this.btnViewKeeps.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnViewKeeps.BorderThickness = 2;
            this.btnViewKeeps.CheckedState.Parent = this.btnViewKeeps;
            this.btnViewKeeps.CustomImages.Parent = this.btnViewKeeps;
            this.btnViewKeeps.FillColor = System.Drawing.Color.White;
            this.btnViewKeeps.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnViewKeeps.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnViewKeeps.HoverState.Parent = this.btnViewKeeps;
            this.btnViewKeeps.Name = "btnViewKeeps";
            this.btnViewKeeps.ShadowDecoration.Parent = this.btnViewKeeps;
            this.btnViewKeeps.Click += new System.EventHandler(this.btnViewKeep);
            // 
            // btnKeep
            // 
            resources.ApplyResources(this.btnKeep, "btnKeep");
            this.btnKeep.BorderColor = System.Drawing.Color.Olive;
            this.btnKeep.BorderThickness = 2;
            this.btnKeep.CheckedState.Parent = this.btnKeep;
            this.btnKeep.CustomImages.Parent = this.btnKeep;
            this.btnKeep.FillColor = System.Drawing.Color.White;
            this.btnKeep.ForeColor = System.Drawing.Color.Olive;
            this.btnKeep.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnKeep.HoverState.Parent = this.btnKeep;
            this.btnKeep.Name = "btnKeep";
            this.btnKeep.ShadowDecoration.Parent = this.btnKeep;
            this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
            // 
            // btnPriceEditor
            // 
            resources.ApplyResources(this.btnPriceEditor, "btnPriceEditor");
            this.btnPriceEditor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(154)))));
            this.btnPriceEditor.BorderThickness = 2;
            this.btnPriceEditor.CheckedState.Parent = this.btnPriceEditor;
            this.btnPriceEditor.CustomImages.Parent = this.btnPriceEditor;
            this.btnPriceEditor.FillColor = System.Drawing.Color.White;
            this.btnPriceEditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(154)))));
            this.btnPriceEditor.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPriceEditor.HoverState.Parent = this.btnPriceEditor;
            this.btnPriceEditor.Name = "btnPriceEditor";
            this.btnPriceEditor.ShadowDecoration.Parent = this.btnPriceEditor;
            this.btnPriceEditor.Click += new System.EventHandler(this.btnPriceEditor_Click);
            // 
            // btnPayment
            // 
            resources.ApplyResources(this.btnPayment, "btnPayment");
            this.btnPayment.BackColor = System.Drawing.Color.White;
            this.btnPayment.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnPayment.BorderThickness = 2;
            this.btnPayment.CheckedState.Parent = this.btnPayment;
            this.btnPayment.CustomImages.Parent = this.btnPayment;
            this.btnPayment.FillColor = System.Drawing.Color.White;
            this.btnPayment.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnPayment.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPayment.HoverState.Parent = this.btnPayment;
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.ShadowDecoration.Parent = this.btnPayment;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnRedeem
            // 
            resources.ApplyResources(this.btnRedeem, "btnRedeem");
            this.btnRedeem.BackColor = System.Drawing.Color.White;
            this.btnRedeem.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnRedeem.BorderThickness = 2;
            this.btnRedeem.CheckedState.Parent = this.btnRedeem;
            this.btnRedeem.CustomImages.Parent = this.btnRedeem;
            this.btnRedeem.FillColor = System.Drawing.Color.White;
            this.btnRedeem.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRedeem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRedeem.HoverState.Parent = this.btnRedeem;
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.ShadowDecoration.Parent = this.btnRedeem;
            this.btnRedeem.Click += new System.EventHandler(this.btnRedeem_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnVoid
            // 
            resources.ApplyResources(this.btnVoid, "btnVoid");
            this.btnVoid.BorderColor = System.Drawing.Color.Red;
            this.btnVoid.BorderThickness = 2;
            this.btnVoid.CheckedState.Parent = this.btnVoid;
            this.btnVoid.CustomImages.Parent = this.btnVoid;
            this.btnVoid.FillColor = System.Drawing.Color.White;
            this.btnVoid.ForeColor = System.Drawing.Color.Red;
            this.btnVoid.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoid.HoverState.Parent = this.btnVoid;
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.ShadowDecoration.Parent = this.btnVoid;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // lblOperation
            // 
            resources.ApplyResources(this.lblOperation, "lblOperation");
            this.lblOperation.BackColor = System.Drawing.Color.White;
            this.lblOperation.ForeColor = System.Drawing.Color.Black;
            this.lblOperation.Name = "lblOperation";
            // 
            // lblOperationt
            // 
            resources.ApplyResources(this.lblOperationt, "lblOperationt");
            this.lblOperationt.BackColor = System.Drawing.Color.White;
            this.lblOperationt.ForeColor = System.Drawing.Color.Black;
            this.lblOperationt.Name = "lblOperationt";
            // 
            // lblCustomer
            // 
            resources.ApplyResources(this.lblCustomer, "lblCustomer");
            this.lblCustomer.BackColor = System.Drawing.Color.White;
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Name = "lblCustomer";
            // 
            // lblCustomert
            // 
            resources.ApplyResources(this.lblCustomert, "lblCustomert");
            this.lblCustomert.BackColor = System.Drawing.Color.White;
            this.lblCustomert.ForeColor = System.Drawing.Color.Black;
            this.lblCustomert.Name = "lblCustomert";
            // 
            // lblZeroRated
            // 
            resources.ApplyResources(this.lblZeroRated, "lblZeroRated");
            this.lblZeroRated.BackColor = System.Drawing.Color.White;
            this.lblZeroRated.ForeColor = System.Drawing.Color.Black;
            this.lblZeroRated.Name = "lblZeroRated";
            // 
            // lblZeroRatedt
            // 
            resources.ApplyResources(this.lblZeroRatedt, "lblZeroRatedt");
            this.lblZeroRatedt.BackColor = System.Drawing.Color.White;
            this.lblZeroRatedt.ForeColor = System.Drawing.Color.Black;
            this.lblZeroRatedt.Name = "lblZeroRatedt";
            // 
            // lblVATExempt
            // 
            resources.ApplyResources(this.lblVATExempt, "lblVATExempt");
            this.lblVATExempt.BackColor = System.Drawing.Color.White;
            this.lblVATExempt.ForeColor = System.Drawing.Color.Black;
            this.lblVATExempt.Name = "lblVATExempt";
            // 
            // lblVATExemptt
            // 
            resources.ApplyResources(this.lblVATExemptt, "lblVATExemptt");
            this.lblVATExemptt.BackColor = System.Drawing.Color.White;
            this.lblVATExemptt.ForeColor = System.Drawing.Color.Black;
            this.lblVATExemptt.Name = "lblVATExemptt";
            // 
            // lblVAT
            // 
            resources.ApplyResources(this.lblVAT, "lblVAT");
            this.lblVAT.BackColor = System.Drawing.Color.White;
            this.lblVAT.ForeColor = System.Drawing.Color.Black;
            this.lblVAT.Name = "lblVAT";
            // 
            // lblVATt
            // 
            resources.ApplyResources(this.lblVATt, "lblVATt");
            this.lblVATt.BackColor = System.Drawing.Color.White;
            this.lblVATt.ForeColor = System.Drawing.Color.Black;
            this.lblVATt.Name = "lblVATt";
            // 
            // lblVATSale
            // 
            resources.ApplyResources(this.lblVATSale, "lblVATSale");
            this.lblVATSale.BackColor = System.Drawing.Color.White;
            this.lblVATSale.ForeColor = System.Drawing.Color.Black;
            this.lblVATSale.Name = "lblVATSale";
            // 
            // lblVATSalet
            // 
            resources.ApplyResources(this.lblVATSalet, "lblVATSalet");
            this.lblVATSalet.BackColor = System.Drawing.Color.White;
            this.lblVATSalet.ForeColor = System.Drawing.Color.Black;
            this.lblVATSalet.Name = "lblVATSalet";
            // 
            // lblLessVAT
            // 
            resources.ApplyResources(this.lblLessVAT, "lblLessVAT");
            this.lblLessVAT.BackColor = System.Drawing.Color.White;
            this.lblLessVAT.ForeColor = System.Drawing.Color.Black;
            this.lblLessVAT.Name = "lblLessVAT";
            // 
            // lblLessVATt
            // 
            resources.ApplyResources(this.lblLessVATt, "lblLessVATt");
            this.lblLessVATt.BackColor = System.Drawing.Color.White;
            this.lblLessVATt.ForeColor = System.Drawing.Color.Black;
            this.lblLessVATt.Name = "lblLessVATt";
            // 
            // lblTotal
            // 
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.ForeColor = System.Drawing.Color.Green;
            this.lblTotal.Name = "lblTotal";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.ForeColor = System.Drawing.Color.Green;
            this.label17.Name = "label17";
            // 
            // lblDiscount
            // 
            resources.ApplyResources(this.lblDiscount, "lblDiscount");
            this.lblDiscount.BackColor = System.Drawing.Color.White;
            this.lblDiscount.ForeColor = System.Drawing.Color.Black;
            this.lblDiscount.Name = "lblDiscount";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Name = "label15";
            // 
            // lblSubtotal
            // 
            resources.ApplyResources(this.lblSubtotal, "lblSubtotal");
            this.lblSubtotal.BackColor = System.Drawing.Color.White;
            this.lblSubtotal.ForeColor = System.Drawing.Color.Black;
            this.lblSubtotal.Name = "lblSubtotal";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Name = "label13";
            // 
            // lblItems
            // 
            resources.ApplyResources(this.lblItems, "lblItems");
            this.lblItems.BackColor = System.Drawing.Color.White;
            this.lblItems.ForeColor = System.Drawing.Color.Black;
            this.lblItems.Name = "lblItems";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Name = "label11";
            // 
            // lblOrderNumber
            // 
            resources.ApplyResources(this.lblOrderNumber, "lblOrderNumber");
            this.lblOrderNumber.BackColor = System.Drawing.Color.White;
            this.lblOrderNumber.ForeColor = System.Drawing.Color.Black;
            this.lblOrderNumber.Name = "lblOrderNumber";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Name = "label8";
            // 
            // btnVoidItem
            // 
            resources.ApplyResources(this.btnVoidItem, "btnVoidItem");
            this.btnVoidItem.BorderColor = System.Drawing.Color.Red;
            this.btnVoidItem.BorderThickness = 1;
            this.btnVoidItem.CheckedState.Parent = this.btnVoidItem;
            this.btnVoidItem.CustomImages.Parent = this.btnVoidItem;
            this.btnVoidItem.FillColor = System.Drawing.Color.White;
            this.btnVoidItem.ForeColor = System.Drawing.Color.Red;
            this.btnVoidItem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoidItem.HoverState.Parent = this.btnVoidItem;
            this.btnVoidItem.Name = "btnVoidItem";
            this.btnVoidItem.ShadowDecoration.Parent = this.btnVoidItem;
            this.btnVoidItem.Click += new System.EventHandler(this.btnVoidItem_Click);
            // 
            // btnQuantity
            // 
            resources.ApplyResources(this.btnQuantity, "btnQuantity");
            this.btnQuantity.BorderColor = System.Drawing.Color.Green;
            this.btnQuantity.BorderThickness = 1;
            this.btnQuantity.CheckedState.Parent = this.btnQuantity;
            this.btnQuantity.CustomImages.Parent = this.btnQuantity;
            this.btnQuantity.FillColor = System.Drawing.Color.White;
            this.btnQuantity.ForeColor = System.Drawing.Color.Green;
            this.btnQuantity.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnQuantity.HoverState.Parent = this.btnQuantity;
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.ShadowDecoration.Parent = this.btnQuantity;
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // btnCustomer
            // 
            resources.ApplyResources(this.btnCustomer, "btnCustomer");
            this.btnCustomer.BorderColor = System.Drawing.Color.Navy;
            this.btnCustomer.BorderThickness = 1;
            this.btnCustomer.CheckedState.Parent = this.btnCustomer;
            this.btnCustomer.CustomImages.Parent = this.btnCustomer;
            this.btnCustomer.FillColor = System.Drawing.Color.White;
            this.btnCustomer.ForeColor = System.Drawing.Color.Navy;
            this.btnCustomer.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCustomer.HoverState.Parent = this.btnCustomer;
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.ShadowDecoration.Parent = this.btnCustomer;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnDiscount
            // 
            resources.ApplyResources(this.btnDiscount, "btnDiscount");
            this.btnDiscount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDiscount.BorderThickness = 1;
            this.btnDiscount.CheckedState.Parent = this.btnDiscount;
            this.btnDiscount.CustomImages.Parent = this.btnDiscount;
            this.btnDiscount.FillColor = System.Drawing.Color.White;
            this.btnDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDiscount.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDiscount.HoverState.Parent = this.btnDiscount;
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.ShadowDecoration.Parent = this.btnDiscount;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // guna2Panel1
            // 
            resources.ApplyResources(this.guna2Panel1, "guna2Panel1");
            this.guna2Panel1.Controls.Add(this.btnWholeSale);
            this.guna2Panel1.Controls.Add(this.btnRetail);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            // 
            // btnWholeSale
            // 
            resources.ApplyResources(this.btnWholeSale, "btnWholeSale");
            this.btnWholeSale.BorderRadius = 5;
            this.btnWholeSale.BorderThickness = 1;
            this.btnWholeSale.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnWholeSale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(230)))), ((int)(((byte)(82)))));
            this.btnWholeSale.CheckedState.Parent = this.btnWholeSale;
            this.btnWholeSale.CustomImages.Parent = this.btnWholeSale;
            this.btnWholeSale.FillColor = System.Drawing.Color.White;
            this.btnWholeSale.ForeColor = System.Drawing.Color.Black;
            this.btnWholeSale.HoverState.Parent = this.btnWholeSale;
            this.btnWholeSale.Name = "btnWholeSale";
            this.btnWholeSale.ShadowDecoration.Parent = this.btnWholeSale;
            this.btnWholeSale.Click += new System.EventHandler(this.btnWholeSale_Click);
            // 
            // btnRetail
            // 
            resources.ApplyResources(this.btnRetail, "btnRetail");
            this.btnRetail.BorderRadius = 5;
            this.btnRetail.BorderThickness = 1;
            this.btnRetail.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnRetail.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(230)))), ((int)(((byte)(82)))));
            this.btnRetail.CheckedState.Parent = this.btnRetail;
            this.btnRetail.CustomImages.Parent = this.btnRetail;
            this.btnRetail.FillColor = System.Drawing.Color.White;
            this.btnRetail.ForeColor = System.Drawing.Color.Black;
            this.btnRetail.HoverState.Parent = this.btnRetail;
            this.btnRetail.Name = "btnRetail";
            this.btnRetail.ShadowDecoration.Parent = this.btnRetail;
            this.btnRetail.Click += new System.EventHandler(this.btnRetail_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
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
        internal System.Windows.Forms.Label label6;
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
        internal System.Windows.Forms.Label label17;
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
        public System.Windows.Forms.TextBox tbBarcode;
        public Guna.UI2.WinForms.Guna2DataGridView dgvCart;
        public Guna.UI2.WinForms.Guna2Button btnQuantity;
        public Guna.UI2.WinForms.Guna2Button btnPriceEditor;
        public Guna.UI2.WinForms.Guna2Button btnKeep;
        public Guna.UI2.WinForms.Guna2Button btnViewKeeps;
    }
}