namespace EcoPOSv2
{
    partial class SeeItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeeItem));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnCLose = new Guna.UI.WinForms.GunaControlBox();
            this.rbWholesale = new System.Windows.Forms.RadioButton();
            this.rbRetail = new System.Windows.Forms.RadioButton();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnClear);
            this.guna2Panel1.Controls.Add(this.dgvProducts);
            this.guna2Panel1.Controls.Add(this.btnCLose);
            this.guna2Panel1.Controls.Add(this.rbWholesale);
            this.guna2Panel1.Controls.Add(this.rbRetail);
            this.guna2Panel1.Controls.Add(this.txtBarcode);
            this.guna2Panel1.Controls.Add(this.Label3);
            this.guna2Panel1.Controls.Add(this.Label2);
            this.guna2Panel1.Location = new System.Drawing.Point(2, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(826, 676);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Click += new System.EventHandler(this.guna2Panel1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(627, 43);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(189, 33);
            this.btnClear.TabIndex = 58;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeColumns = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProducts.Location = new System.Drawing.Point(3, 119);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(819, 554);
            this.dgvProducts.TabIndex = 57;
            this.dgvProducts.Click += new System.EventHandler(this.dgvProducts_Click);
            this.dgvProducts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvProducts_KeyUp);
            // 
            // btnCLose
            // 
            this.btnCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCLose.AnimationHoverSpeed = 0.07F;
            this.btnCLose.AnimationSpeed = 0.03F;
            this.btnCLose.IconColor = System.Drawing.Color.Black;
            this.btnCLose.IconSize = 15F;
            this.btnCLose.Location = new System.Drawing.Point(782, 4);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCLose.OnHoverIconColor = System.Drawing.Color.White;
            this.btnCLose.OnPressedColor = System.Drawing.Color.Black;
            this.btnCLose.Size = new System.Drawing.Size(40, 40);
            this.btnCLose.TabIndex = 56;
            // 
            // rbWholesale
            // 
            this.rbWholesale.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWholesale.ForeColor = System.Drawing.Color.Black;
            this.rbWholesale.Location = new System.Drawing.Point(665, 82);
            this.rbWholesale.Name = "rbWholesale";
            this.rbWholesale.Size = new System.Drawing.Size(142, 31);
            this.rbWholesale.TabIndex = 55;
            this.rbWholesale.Text = "Wholesale";
            this.rbWholesale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbWholesale.UseVisualStyleBackColor = true;
            // 
            // rbRetail
            // 
            this.rbRetail.Checked = true;
            this.rbRetail.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRetail.ForeColor = System.Drawing.Color.Black;
            this.rbRetail.Location = new System.Drawing.Point(563, 82);
            this.rbRetail.Name = "rbRetail";
            this.rbRetail.Size = new System.Drawing.Size(96, 31);
            this.rbRetail.TabIndex = 54;
            this.rbRetail.TabStop = true;
            this.rbRetail.Text = "Retail";
            this.rbRetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbRetail.UseVisualStyleBackColor = true;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.Color.Black;
            this.txtBarcode.Location = new System.Drawing.Point(187, 43);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(433, 33);
            this.txtBarcode.TabIndex = 52;
            this.txtBarcode.Tag = "";
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(4, 45);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(184, 28);
            this.Label3.TabIndex = 51;
            this.Label3.Text = "Barcode # Or Name";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(4, 79);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(509, 37);
            this.Label2.TabIndex = 53;
            this.Label2.Text = "Price Mode:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SeeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(830, 680);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeeItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeeItem";
            this.Load += new System.EventHandler(this.SeeItem_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        internal System.Windows.Forms.DataGridView dgvProducts;
        private Guna.UI.WinForms.GunaControlBox btnCLose;
        internal System.Windows.Forms.RadioButton rbWholesale;
        internal System.Windows.Forms.RadioButton rbRetail;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtBarcode;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnClear;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}