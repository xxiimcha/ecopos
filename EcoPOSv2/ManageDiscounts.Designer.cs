namespace EcoPOSv2
{
    partial class ManageDiscounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDiscounts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnProduct_Delete = new Guna.UI2.WinForms.Guna2Button();
            this.btnProduct_Save = new Guna.UI2.WinForms.Guna2Button();
            this.btnProduct_New = new FontAwesome.Sharp.IconButton();
            this.rbAmount = new System.Windows.Forms.RadioButton();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.rbPercentage = new System.Windows.Forms.RadioButton();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnSort = new FontAwesome.Sharp.IconButton();
            this.dgvDiscount = new System.Windows.Forms.DataGridView();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Panel3.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscount)).BeginInit();
            this.TableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.btnProduct_Delete);
            this.Panel3.Controls.Add(this.btnProduct_Save);
            this.Panel3.Controls.Add(this.btnProduct_New);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel3.Location = new System.Drawing.Point(0, 806);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(784, 60);
            this.Panel3.TabIndex = 2;
            // 
            // btnProduct_Delete
            // 
            this.btnProduct_Delete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnProduct_Delete.BorderThickness = 2;
            this.btnProduct_Delete.CheckedState.Parent = this.btnProduct_Delete;
            this.btnProduct_Delete.CustomImages.Parent = this.btnProduct_Delete;
            this.btnProduct_Delete.FillColor = System.Drawing.Color.White;
            this.btnProduct_Delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProduct_Delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnProduct_Delete.HoverState.Parent = this.btnProduct_Delete;
            this.btnProduct_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct_Delete.Image")));
            this.btnProduct_Delete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProduct_Delete.ImageSize = new System.Drawing.Size(30, 30);
            this.btnProduct_Delete.Location = new System.Drawing.Point(195, 10);
            this.btnProduct_Delete.Name = "btnProduct_Delete";
            this.btnProduct_Delete.ShadowDecoration.Parent = this.btnProduct_Delete;
            this.btnProduct_Delete.Size = new System.Drawing.Size(120, 40);
            this.btnProduct_Delete.TabIndex = 67;
            this.btnProduct_Delete.Text = "DELETE";
            this.btnProduct_Delete.TextOffset = new System.Drawing.Point(10, 0);
            this.btnProduct_Delete.Click += new System.EventHandler(this.BtnProduct_Delete_Click);
            // 
            // btnProduct_Save
            // 
            this.btnProduct_Save.BorderColor = System.Drawing.Color.Green;
            this.btnProduct_Save.BorderThickness = 2;
            this.btnProduct_Save.CheckedState.Parent = this.btnProduct_Save;
            this.btnProduct_Save.CustomImages.Parent = this.btnProduct_Save;
            this.btnProduct_Save.FillColor = System.Drawing.Color.White;
            this.btnProduct_Save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProduct_Save.ForeColor = System.Drawing.Color.Green;
            this.btnProduct_Save.HoverState.Parent = this.btnProduct_Save;
            this.btnProduct_Save.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct_Save.Image")));
            this.btnProduct_Save.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProduct_Save.ImageSize = new System.Drawing.Size(30, 30);
            this.btnProduct_Save.Location = new System.Drawing.Point(321, 10);
            this.btnProduct_Save.Name = "btnProduct_Save";
            this.btnProduct_Save.ShadowDecoration.Parent = this.btnProduct_Save;
            this.btnProduct_Save.Size = new System.Drawing.Size(120, 40);
            this.btnProduct_Save.TabIndex = 66;
            this.btnProduct_Save.Text = "SAVE";
            this.btnProduct_Save.TextOffset = new System.Drawing.Point(10, 0);
            this.btnProduct_Save.Click += new System.EventHandler(this.BtnProduct_Save_Click);
            // 
            // btnProduct_New
            // 
            this.btnProduct_New.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnProduct_New.BackColor = System.Drawing.Color.White;
            this.btnProduct_New.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnProduct_New.FlatAppearance.BorderSize = 2;
            this.btnProduct_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct_New.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct_New.ForeColor = System.Drawing.Color.Orange;
            this.btnProduct_New.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnProduct_New.IconColor = System.Drawing.Color.Orange;
            this.btnProduct_New.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProduct_New.IconSize = 30;
            this.btnProduct_New.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProduct_New.Location = new System.Drawing.Point(447, 10);
            this.btnProduct_New.Name = "btnProduct_New";
            this.btnProduct_New.Size = new System.Drawing.Size(142, 40);
            this.btnProduct_New.TabIndex = 65;
            this.btnProduct_New.Text = "ADD NEW";
            this.btnProduct_New.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduct_New.UseVisualStyleBackColor = false;
            // 
            // rbAmount
            // 
            this.rbAmount.Checked = true;
            this.rbAmount.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAmount.ForeColor = System.Drawing.Color.Black;
            this.rbAmount.Location = new System.Drawing.Point(110, 73);
            this.rbAmount.Name = "rbAmount";
            this.rbAmount.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rbAmount.Size = new System.Drawing.Size(151, 29);
            this.rbAmount.TabIndex = 37;
            this.rbAmount.TabStop = true;
            this.rbAmount.Text = "Amount";
            this.rbAmount.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.64877F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.35123F));
            this.TableLayoutPanel1.Controls.Add(this.rbAmount, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.txtAmount, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.txtName, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label4, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label2, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.rbPercentage, 1, 3);
            this.TableLayoutPanel1.Controls.Add(this.Label3, 1, 4);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 5;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.46024F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.46024F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.46024F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.46024F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.15904F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(784, 806);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.Location = new System.Drawing.Point(110, 38);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(671, 29);
            this.txtAmount.TabIndex = 25;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(3, 35);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(101, 35);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Amount";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(110, 3);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(671, 29);
            this.txtName.TabIndex = 23;
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(3, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(101, 35);
            this.Label4.TabIndex = 22;
            this.Label4.Text = "Name";
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(3, 70);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(101, 35);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Type";
            // 
            // rbPercentage
            // 
            this.rbPercentage.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPercentage.ForeColor = System.Drawing.Color.Black;
            this.rbPercentage.Location = new System.Drawing.Point(110, 108);
            this.rbPercentage.Name = "rbPercentage";
            this.rbPercentage.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rbPercentage.Size = new System.Drawing.Size(151, 29);
            this.rbPercentage.TabIndex = 38;
            this.rbPercentage.Text = "Percentage";
            this.rbPercentage.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(110, 140);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(671, 137);
            this.Label3.TabIndex = 39;
            this.Label3.Text = "Note: Discounts can only be applied to items that are discountable. Products\' dis" +
    "countability can be configured in \'Manage Products\' tab. Only one (1) discount c" +
    "an be applied per transaction.";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(323, 29);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.Tag = "Search discount";
            this.txtSearch.Text = "Search discount";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.txtSearch);
            this.Panel2.Controls.Add(this.btnSort);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(3, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(370, 29);
            this.Panel2.TabIndex = 6;
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.White;
            this.btnSort.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSort.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnSort.FlatAppearance.BorderSize = 0;
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSort.ForeColor = System.Drawing.Color.Black;
            this.btnSort.IconChar = FontAwesome.Sharp.IconChar.SortAlphaUp;
            this.btnSort.IconColor = System.Drawing.Color.Black;
            this.btnSort.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSort.IconSize = 30;
            this.btnSort.Location = new System.Drawing.Point(323, 0);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(47, 29);
            this.btnSort.TabIndex = 25;
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.BtnSort_Click);
            // 
            // dgvDiscount
            // 
            this.dgvDiscount.AllowUserToAddRows = false;
            this.dgvDiscount.AllowUserToDeleteRows = false;
            this.dgvDiscount.AllowUserToResizeColumns = false;
            this.dgvDiscount.AllowUserToResizeRows = false;
            this.dgvDiscount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiscount.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDiscount.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDiscount.ColumnHeadersHeight = 6;
            this.dgvDiscount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscount.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDiscount.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDiscount.Location = new System.Drawing.Point(3, 38);
            this.dgvDiscount.Name = "dgvDiscount";
            this.dgvDiscount.ReadOnly = true;
            this.dgvDiscount.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscount.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDiscount.Size = new System.Drawing.Size(370, 692);
            this.dgvDiscount.TabIndex = 9;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel2.Controls.Add(this.dgvDiscount, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.Panel2, 0, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 2;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.051383F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.94862F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(376, 866);
            this.TableLayoutPanel2.TabIndex = 1;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.TableLayoutPanel2);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.TableLayoutPanel1);
            this.SplitContainer1.Panel2.Controls.Add(this.Panel3);
            this.SplitContainer1.Size = new System.Drawing.Size(1164, 866);
            this.SplitContainer1.SplitterDistance = 376;
            this.SplitContainer1.TabIndex = 2;
            // 
            // ManageDiscounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 866);
            this.Controls.Add(this.SplitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageDiscounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageDiscounts";
            this.Load += new System.EventHandler(this.ManageDiscounts_Load);
            this.Panel3.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscount)).EndInit();
            this.TableLayoutPanel2.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.RadioButton rbAmount;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.TextBox txtAmount;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.RadioButton rbPercentage;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.Panel Panel2;
        internal FontAwesome.Sharp.IconButton btnSort;
        internal System.Windows.Forms.DataGridView dgvDiscount;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        private Guna.UI2.WinForms.Guna2Button btnProduct_Delete;
        private Guna.UI2.WinForms.Guna2Button btnProduct_Save;
        internal FontAwesome.Sharp.IconButton btnProduct_New;
    }
}