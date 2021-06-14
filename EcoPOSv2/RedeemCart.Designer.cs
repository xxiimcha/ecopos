namespace EcoPOSv2
{
    partial class RedeemCart
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedeemCart));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRemove = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnQuantity = new Guna.UI2.WinForms.Guna2TileButton();
            this.dgvRedeemItems = new System.Windows.Forms.DataGridView();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.dgvRedeemCart = new System.Windows.Forms.DataGridView();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnProceed = new Guna.UI2.WinForms.Guna2Button();
            this.lblRemainingPoints = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedeemItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedeemCart)).BeginInit();
            this.Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnRemove);
            this.guna2Panel1.Controls.Add(this.btnQuantity);
            this.guna2Panel1.Controls.Add(this.dgvRedeemItems);
            this.guna2Panel1.Controls.Add(this.txtSearchItem);
            this.guna2Panel1.Controls.Add(this.dgvRedeemCart);
            this.guna2Panel1.Controls.Add(this.Panel3);
            this.guna2Panel1.Location = new System.Drawing.Point(2, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(970, 697);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.BorderColor = System.Drawing.Color.Red;
            this.btnRemove.BorderThickness = 2;
            this.btnRemove.CheckedState.Parent = this.btnRemove;
            this.btnRemove.CustomImages.Parent = this.btnRemove;
            this.btnRemove.FillColor = System.Drawing.Color.White;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.HoverState.Parent = this.btnRemove;
            this.btnRemove.Location = new System.Drawing.Point(565, 47);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.ShadowDecoration.Parent = this.btnRemove;
            this.btnRemove.Size = new System.Drawing.Size(78, 45);
            this.btnRemove.TabIndex = 81;
            this.btnRemove.Text = "X";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnQuantity
            // 
            this.btnQuantity.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnQuantity.BorderThickness = 2;
            this.btnQuantity.CheckedState.Parent = this.btnQuantity;
            this.btnQuantity.CustomImages.Parent = this.btnQuantity;
            this.btnQuantity.FillColor = System.Drawing.Color.White;
            this.btnQuantity.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuantity.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnQuantity.HoverState.Parent = this.btnQuantity;
            this.btnQuantity.Location = new System.Drawing.Point(565, -1);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.ShadowDecoration.Parent = this.btnQuantity;
            this.btnQuantity.Size = new System.Drawing.Size(78, 45);
            this.btnQuantity.TabIndex = 80;
            this.btnQuantity.Text = "Qty";
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // dgvRedeemItems
            // 
            this.dgvRedeemItems.AllowUserToAddRows = false;
            this.dgvRedeemItems.AllowUserToDeleteRows = false;
            this.dgvRedeemItems.AllowUserToResizeColumns = false;
            this.dgvRedeemItems.AllowUserToResizeRows = false;
            this.dgvRedeemItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRedeemItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRedeemItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRedeemItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRedeemItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRedeemItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRedeemItems.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRedeemItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRedeemItems.Location = new System.Drawing.Point(647, 40);
            this.dgvRedeemItems.MultiSelect = false;
            this.dgvRedeemItems.Name = "dgvRedeemItems";
            this.dgvRedeemItems.ReadOnly = true;
            this.dgvRedeemItems.RowHeadersVisible = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRedeemItems.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRedeemItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRedeemItems.Size = new System.Drawing.Size(322, 654);
            this.dgvRedeemItems.TabIndex = 79;
            this.dgvRedeemItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRedeemItems_CellClick);
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchItem.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearchItem.Location = new System.Drawing.Point(647, 1);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(322, 33);
            this.txtSearchItem.TabIndex = 78;
            this.txtSearchItem.Tag = "Search item/barcode";
            this.txtSearchItem.Text = "Search item/barcode";
            this.txtSearchItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchItem_KeyDown);
            this.txtSearchItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchItem_KeyUp);
            // 
            // dgvRedeemCart
            // 
            this.dgvRedeemCart.AllowUserToAddRows = false;
            this.dgvRedeemCart.AllowUserToDeleteRows = false;
            this.dgvRedeemCart.AllowUserToResizeColumns = false;
            this.dgvRedeemCart.AllowUserToResizeRows = false;
            this.dgvRedeemCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRedeemCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRedeemCart.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRedeemCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRedeemCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvRedeemCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRedeemCart.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvRedeemCart.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRedeemCart.Location = new System.Drawing.Point(5, 1);
            this.dgvRedeemCart.MultiSelect = false;
            this.dgvRedeemCart.Name = "dgvRedeemCart";
            this.dgvRedeemCart.ReadOnly = true;
            this.dgvRedeemCart.RowHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRedeemCart.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvRedeemCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRedeemCart.Size = new System.Drawing.Size(556, 441);
            this.dgvRedeemCart.TabIndex = 77;
            this.dgvRedeemCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRedeemCart_CellClick);
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.btnCancel);
            this.Panel3.Controls.Add(this.btnProceed);
            this.Panel3.Controls.Add(this.lblRemainingPoints);
            this.Panel3.Controls.Add(this.Label5);
            this.Panel3.Controls.Add(this.lblBalance);
            this.Panel3.Controls.Add(this.Label3);
            this.Panel3.Controls.Add(this.lblTotal);
            this.Panel3.Controls.Add(this.lblItems);
            this.Panel3.Controls.Add(this.Label7);
            this.Panel3.Controls.Add(this.Label8);
            this.Panel3.Controls.Add(this.lblCardNo);
            this.Panel3.Controls.Add(this.lblCustomerName);
            this.Panel3.Controls.Add(this.Label1);
            this.Panel3.Controls.Add(this.Label6);
            this.Panel3.Location = new System.Drawing.Point(2, 448);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(636, 249);
            this.Panel3.TabIndex = 76;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancel.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnCancel.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCancel.Location = new System.Drawing.Point(75, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(238, 45);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextOffset = new System.Drawing.Point(10, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnProceed
            // 
            this.btnProceed.BorderColor = System.Drawing.Color.Green;
            this.btnProceed.BorderThickness = 2;
            this.btnProceed.CheckedState.Parent = this.btnProceed;
            this.btnProceed.CustomImages.Parent = this.btnProceed;
            this.btnProceed.FillColor = System.Drawing.Color.White;
            this.btnProceed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProceed.ForeColor = System.Drawing.Color.Green;
            this.btnProceed.HoverState.Parent = this.btnProceed;
            this.btnProceed.Image = ((System.Drawing.Image)(resources.GetObject("btnProceed.Image")));
            this.btnProceed.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProceed.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnProceed.ImageSize = new System.Drawing.Size(40, 40);
            this.btnProceed.Location = new System.Drawing.Point(324, 193);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.ShadowDecoration.Parent = this.btnProceed;
            this.btnProceed.Size = new System.Drawing.Size(238, 45);
            this.btnProceed.TabIndex = 56;
            this.btnProceed.Text = "REDEEM";
            this.btnProceed.TextOffset = new System.Drawing.Point(10, 0);
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // lblRemainingPoints
            // 
            this.lblRemainingPoints.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingPoints.ForeColor = System.Drawing.Color.Black;
            this.lblRemainingPoints.Location = new System.Drawing.Point(326, 139);
            this.lblRemainingPoints.Name = "lblRemainingPoints";
            this.lblRemainingPoints.Size = new System.Drawing.Size(295, 26);
            this.lblRemainingPoints.TabIndex = 55;
            this.lblRemainingPoints.Text = "0.00";
            this.lblRemainingPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(489, 118);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(131, 21);
            this.Label5.TabIndex = 54;
            this.Label5.Text = "Remaining Points";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalance
            // 
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Black;
            this.lblBalance.Location = new System.Drawing.Point(5, 149);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(293, 26);
            this.lblBalance.TabIndex = 53;
            this.lblBalance.Text = "0.00";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(6, 128);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(63, 21);
            this.Label3.TabIndex = 52;
            this.Label3.Text = "Balance";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(326, 88);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(295, 26);
            this.lblTotal.TabIndex = 51;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblItems
            // 
            this.lblItems.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.ForeColor = System.Drawing.Color.Black;
            this.lblItems.Location = new System.Drawing.Point(327, 36);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(294, 25);
            this.lblItems.TabIndex = 50;
            this.lblItems.Text = "0.00";
            this.lblItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(577, 67);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(42, 21);
            this.Label7.TabIndex = 49;
            this.Label7.Text = "Total";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(573, 15);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(48, 21);
            this.Label8.TabIndex = 48;
            this.Label8.Text = "Items";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardNo
            // 
            this.lblCardNo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNo.ForeColor = System.Drawing.Color.Black;
            this.lblCardNo.Location = new System.Drawing.Point(5, 93);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(293, 26);
            this.lblCardNo.TabIndex = 47;
            this.lblCardNo.Text = "0";
            this.lblCardNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerName.Location = new System.Drawing.Point(5, 36);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(292, 25);
            this.lblCustomerName.TabIndex = 46;
            this.lblCustomerName.Text = "Customer";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(7, 72);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(71, 21);
            this.Label1.TabIndex = 44;
            this.Label1.Text = "Card No.";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(6, 11);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(78, 21);
            this.Label6.TabIndex = 43;
            this.Label6.Text = "Customer";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RedeemCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 701);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RedeemCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RedeemCart";
            this.Load += new System.EventHandler(this.RedeemCart_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedeemItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedeemCart)).EndInit();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TileButton btnRemove;
        private Guna.UI2.WinForms.Guna2TileButton btnQuantity;
        internal System.Windows.Forms.DataGridView dgvRedeemItems;
        internal System.Windows.Forms.TextBox txtSearchItem;
        internal System.Windows.Forms.DataGridView dgvRedeemCart;
        internal System.Windows.Forms.Panel Panel3;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnProceed;
        internal System.Windows.Forms.Label lblRemainingPoints;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label lblBalance;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Label lblItems;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label lblCardNo;
        internal System.Windows.Forms.Label lblCustomerName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label6;
    }
}