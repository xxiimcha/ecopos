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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoidTransaction_UI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSelectAll = new FontAwesome.Sharp.IconButton();
            this.dgvVoidList = new System.Windows.Forms.DataGridView();
            this.panelInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCashReturn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVoid = new Guna.UI2.WinForms.Guna2Button();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoOfItemsToVoid = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.dgvToVoidList = new System.Windows.Forms.DataGridView();
            this.btnRemove = new Guna.UI2.WinForms.Guna2TileButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTerminalNo = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoidList)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToVoidList)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.BorderColor = System.Drawing.Color.Black;
            this.MainPanel.BorderRadius = 25;
            this.MainPanel.BorderThickness = 1;
            this.MainPanel.Controls.Add(this.lblTerminalNo);
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Controls.Add(this.tbSearch);
            this.MainPanel.Controls.Add(this.btnSelectAll);
            this.MainPanel.Controls.Add(this.dgvVoidList);
            this.MainPanel.Controls.Add(this.panelInfo);
            this.MainPanel.Controls.Add(this.dgvToVoidList);
            this.MainPanel.Controls.Add(this.btnRemove);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Controls.Add(this.gunaControlBox1);
            this.MainPanel.Location = new System.Drawing.Point(3, 2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.ShadowDecoration.Parent = this.MainPanel;
            this.MainPanel.Size = new System.Drawing.Size(968, 695);
            this.MainPanel.TabIndex = 0;
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.Color.Gray;
            this.tbSearch.Location = new System.Drawing.Point(656, 40);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(185, 35);
            this.tbSearch.TabIndex = 90;
            this.tbSearch.Text = "Search";
            this.tbSearch.TextChanged += new System.EventHandler(this.TbSearch_TextChanged);
            this.tbSearch.Enter += new System.EventHandler(this.TbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.TbSearch_Leave);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatAppearance.BorderSize = 2;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.ForeColor = System.Drawing.Color.Orange;
            this.btnSelectAll.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnSelectAll.IconColor = System.Drawing.Color.Orange;
            this.btnSelectAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSelectAll.IconSize = 27;
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.Location = new System.Drawing.Point(847, 40);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(111, 36);
            this.btnSelectAll.TabIndex = 89;
            this.btnSelectAll.Text = "Select all";
            this.btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // dgvVoidList
            // 
            this.dgvVoidList.AllowUserToAddRows = false;
            this.dgvVoidList.AllowUserToDeleteRows = false;
            this.dgvVoidList.AllowUserToResizeColumns = false;
            this.dgvVoidList.AllowUserToResizeRows = false;
            this.dgvVoidList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVoidList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVoidList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvVoidList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVoidList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVoidList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVoidList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvVoidList.Location = new System.Drawing.Point(9, 38);
            this.dgvVoidList.MultiSelect = false;
            this.dgvVoidList.Name = "dgvVoidList";
            this.dgvVoidList.ReadOnly = true;
            this.dgvVoidList.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVoidList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVoidList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVoidList.Size = new System.Drawing.Size(556, 457);
            this.dgvVoidList.TabIndex = 78;
            // 
            // panelInfo
            // 
            this.panelInfo.BorderColor = System.Drawing.Color.Black;
            this.panelInfo.BorderRadius = 20;
            this.panelInfo.BorderThickness = 1;
            this.panelInfo.Controls.Add(this.lblCashReturn);
            this.panelInfo.Controls.Add(this.label4);
            this.panelInfo.Controls.Add(this.btnVoid);
            this.panelInfo.Controls.Add(this.lblInvoice);
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.lblNoOfItemsToVoid);
            this.panelInfo.Controls.Add(this.Label6);
            this.panelInfo.Location = new System.Drawing.Point(10, 502);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.ShadowDecoration.Parent = this.panelInfo;
            this.panelInfo.Size = new System.Drawing.Size(555, 185);
            this.panelInfo.TabIndex = 85;
            // 
            // lblCashReturn
            // 
            this.lblCashReturn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashReturn.ForeColor = System.Drawing.Color.Black;
            this.lblCashReturn.Location = new System.Drawing.Point(151, 107);
            this.lblCashReturn.Name = "lblCashReturn";
            this.lblCashReturn.Size = new System.Drawing.Size(243, 25);
            this.lblCashReturn.TabIndex = 61;
            this.lblCashReturn.Text = "0";
            this.lblCashReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(152, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 21);
            this.label4.TabIndex = 60;
            this.label4.Text = "Total Cash to return";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVoid
            // 
            this.btnVoid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnVoid.BorderThickness = 2;
            this.btnVoid.CheckedState.Parent = this.btnVoid;
            this.btnVoid.CustomImages.Parent = this.btnVoid;
            this.btnVoid.FillColor = System.Drawing.Color.White;
            this.btnVoid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnVoid.HoverState.Parent = this.btnVoid;
            this.btnVoid.Image = ((System.Drawing.Image)(resources.GetObject("btnVoid.Image")));
            this.btnVoid.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnVoid.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnVoid.ImageSize = new System.Drawing.Size(40, 40);
            this.btnVoid.Location = new System.Drawing.Point(156, 135);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.ShadowDecoration.Parent = this.btnVoid;
            this.btnVoid.Size = new System.Drawing.Size(238, 45);
            this.btnVoid.TabIndex = 59;
            this.btnVoid.Text = "VOID";
            this.btnVoid.TextOffset = new System.Drawing.Point(10, 0);
            this.btnVoid.Click += new System.EventHandler(this.BtnVoid_Click);
            // 
            // lblInvoice
            // 
            this.lblInvoice.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoice.ForeColor = System.Drawing.Color.Black;
            this.lblInvoice.Location = new System.Drawing.Point(14, 40);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(233, 25);
            this.lblInvoice.TabIndex = 49;
            this.lblInvoice.Text = "0";
            this.lblInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 48;
            this.label2.Text = "Invoice ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNoOfItemsToVoid
            // 
            this.lblNoOfItemsToVoid.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfItemsToVoid.ForeColor = System.Drawing.Color.Black;
            this.lblNoOfItemsToVoid.Location = new System.Drawing.Point(302, 40);
            this.lblNoOfItemsToVoid.Name = "lblNoOfItemsToVoid";
            this.lblNoOfItemsToVoid.Size = new System.Drawing.Size(233, 25);
            this.lblNoOfItemsToVoid.TabIndex = 47;
            this.lblNoOfItemsToVoid.Text = "0";
            this.lblNoOfItemsToVoid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(303, 13);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(165, 21);
            this.Label6.TabIndex = 44;
            this.Label6.Text = "No of items to be Void";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvToVoidList
            // 
            this.dgvToVoidList.AllowUserToAddRows = false;
            this.dgvToVoidList.AllowUserToDeleteRows = false;
            this.dgvToVoidList.AllowUserToResizeColumns = false;
            this.dgvToVoidList.AllowUserToResizeRows = false;
            this.dgvToVoidList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToVoidList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvToVoidList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvToVoidList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvToVoidList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToVoidList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvToVoidList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvToVoidList.Location = new System.Drawing.Point(655, 82);
            this.dgvToVoidList.MultiSelect = false;
            this.dgvToVoidList.Name = "dgvToVoidList";
            this.dgvToVoidList.ReadOnly = true;
            this.dgvToVoidList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToVoidList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvToVoidList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToVoidList.Size = new System.Drawing.Size(303, 605);
            this.dgvToVoidList.TabIndex = 84;
            this.dgvToVoidList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvToVoidList_CellClick);
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
            this.btnRemove.Location = new System.Drawing.Point(571, 38);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.ShadowDecoration.Parent = this.btnRemove;
            this.btnRemove.Size = new System.Drawing.Size(78, 45);
            this.btnRemove.TabIndex = 83;
            this.btnRemove.Text = "X";
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 30);
            this.label1.TabIndex = 86;
            this.label1.Text = "Void Transaction";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(907, 4);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(135)))), ((int)(((byte)(127)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(51, 30);
            this.gunaControlBox1.TabIndex = 88;
            this.gunaControlBox1.Click += new System.EventHandler(this.GunaControlBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 21);
            this.label3.TabIndex = 91;
            this.label3.Text = "From:";
            // 
            // lblTerminalNo
            // 
            this.lblTerminalNo.AutoSize = true;
            this.lblTerminalNo.Location = new System.Drawing.Point(257, 10);
            this.lblTerminalNo.Name = "lblTerminalNo";
            this.lblTerminalNo.Size = new System.Drawing.Size(90, 21);
            this.lblTerminalNo.TabIndex = 92;
            this.lblTerminalNo.Text = "TerminalNo";
            // 
            // VoidTransaction_UI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(973, 701);
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
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToVoidList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        internal System.Windows.Forms.DataGridView dgvVoidList;
        private Guna.UI2.WinForms.Guna2TileButton btnRemove;
        internal System.Windows.Forms.DataGridView dgvToVoidList;
        private Guna.UI2.WinForms.Guna2Panel panelInfo;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblNoOfItemsToVoid;
        internal System.Windows.Forms.Label lblInvoice;
        internal System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnVoid;
        internal System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private System.Windows.Forms.TextBox tbSearch;
        internal FontAwesome.Sharp.IconButton btnSelectAll;
        internal System.Windows.Forms.Label lblCashReturn;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTerminalNo;
        private System.Windows.Forms.Label label3;
    }
}