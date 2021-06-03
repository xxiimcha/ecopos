namespace EcoPOSv2
{
    partial class Payment
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExact = new System.Windows.Forms.Button();
            this.btnGC = new System.Windows.Forms.Button();
            this.btnRemoveGC = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxUsePoints = new System.Windows.Forms.CheckBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblGCNo = new System.Windows.Forms.Label();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblDeductGC = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblDeductPoints = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.guna2Panel1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.gunaControlBox1);
            this.guna2Panel1.Controls.Add(this.TableLayoutPanel2);
            this.guna2Panel1.Controls.Add(this.cbxUsePoints);
            this.guna2Panel1.Controls.Add(this.Label6);
            this.guna2Panel1.Controls.Add(this.lblCustomerID);
            this.guna2Panel1.Controls.Add(this.lblGCNo);
            this.guna2Panel1.Controls.Add(this.cmbMethod);
            this.guna2Panel1.Controls.Add(this.Label3);
            this.guna2Panel1.Controls.Add(this.Label2);
            this.guna2Panel1.Controls.Add(this.Label1);
            this.guna2Panel1.Controls.Add(this.lblDeductGC);
            this.guna2Panel1.Controls.Add(this.Label10);
            this.guna2Panel1.Controls.Add(this.lblChange);
            this.guna2Panel1.Controls.Add(this.Label4);
            this.guna2Panel1.Controls.Add(this.lblGrandTotal);
            this.guna2Panel1.Controls.Add(this.lblDeductPoints);
            this.guna2Panel1.Controls.Add(this.lblTotal);
            this.guna2Panel1.Controls.Add(this.Label9);
            this.guna2Panel1.Controls.Add(this.Label7);
            this.guna2Panel1.Controls.Add(this.Label8);
            this.guna2Panel1.Controls.Add(this.txtAmount);
            this.guna2Panel1.Location = new System.Drawing.Point(2, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(613, 726);
            this.guna2Panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 28);
            this.label5.TabIndex = 103;
            this.label5.Text = "AMOUNT TENDERED:";
            // 
            // btnExact
            // 
            this.btnExact.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExact.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnExact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExact.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExact.ForeColor = System.Drawing.Color.Black;
            this.btnExact.Location = new System.Drawing.Point(351, 3);
            this.btnExact.Name = "btnExact";
            this.btnExact.Size = new System.Drawing.Size(230, 63);
            this.btnExact.TabIndex = 15;
            this.btnExact.Text = "Exact (F1)";
            this.btnExact.UseVisualStyleBackColor = false;
            // 
            // btnGC
            // 
            this.btnGC.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGC.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnGC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGC.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGC.ForeColor = System.Drawing.Color.Black;
            this.btnGC.Location = new System.Drawing.Point(351, 72);
            this.btnGC.Name = "btnGC";
            this.btnGC.Size = new System.Drawing.Size(230, 63);
            this.btnGC.TabIndex = 17;
            this.btnGC.Text = "Gift Card (F2)";
            this.btnGC.UseVisualStyleBackColor = false;
            // 
            // btnRemoveGC
            // 
            this.btnRemoveGC.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRemoveGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveGC.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnRemoveGC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveGC.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveGC.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveGC.Location = new System.Drawing.Point(351, 141);
            this.btnRemoveGC.Name = "btnRemoveGC";
            this.btnRemoveGC.Size = new System.Drawing.Size(230, 63);
            this.btnRemoveGC.TabIndex = 18;
            this.btnRemoveGC.Text = "Remove GC (F3)";
            this.btnRemoveGC.UseVisualStyleBackColor = false;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPay.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.Black;
            this.btnPay.Location = new System.Drawing.Point(351, 210);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(230, 64);
            this.btnPay.TabIndex = 19;
            this.btnPay.Text = "Pay (Enter)";
            this.btnPay.UseVisualStyleBackColor = false;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(557, 3);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(54, 45);
            this.gunaControlBox1.TabIndex = 102;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 4;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPanel2.Controls.Add(this.btnExact, 3, 0);
            this.TableLayoutPanel2.Controls.Add(this.btnGC, 3, 1);
            this.TableLayoutPanel2.Controls.Add(this.btnRemoveGC, 3, 2);
            this.TableLayoutPanel2.Controls.Add(this.btnPay, 3, 3);
            this.TableLayoutPanel2.Location = new System.Drawing.Point(18, 440);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 4;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(584, 277);
            this.TableLayoutPanel2.TabIndex = 101;
            // 
            // cbxUsePoints
            // 
            this.cbxUsePoints.AutoSize = true;
            this.cbxUsePoints.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxUsePoints.ForeColor = System.Drawing.Color.Black;
            this.cbxUsePoints.Location = new System.Drawing.Point(182, 338);
            this.cbxUsePoints.Name = "cbxUsePoints";
            this.cbxUsePoints.Size = new System.Drawing.Size(65, 29);
            this.cbxUsePoints.TabIndex = 100;
            this.cbxUsePoints.Text = "0.00";
            this.cbxUsePoints.UseVisualStyleBackColor = true;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(16, 338);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(94, 25);
            this.Label6.TabIndex = 99;
            this.Label6.Text = "Use Points";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerID.Location = new System.Drawing.Point(178, 402);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(424, 25);
            this.lblCustomerID.TabIndex = 98;
            this.lblCustomerID.Text = "0";
            // 
            // lblGCNo
            // 
            this.lblGCNo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGCNo.ForeColor = System.Drawing.Color.Black;
            this.lblGCNo.Location = new System.Drawing.Point(178, 370);
            this.lblGCNo.Name = "lblGCNo";
            this.lblGCNo.Size = new System.Drawing.Size(424, 25);
            this.lblGCNo.TabIndex = 97;
            this.lblGCNo.Text = "0";
            // 
            // cmbMethod
            // 
            this.cmbMethod.BackColor = System.Drawing.Color.White;
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMethod.ForeColor = System.Drawing.Color.White;
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Items.AddRange(new object[] {
            "Cash",
            "Gift Certificate",
            "Cheque",
            "GCash",
            "PayMaya",
            "PayPal",
            "American Express",
            "BancNet",
            "China UnionPay",
            "JCB",
            "Mastercard",
            "Visa "});
            this.cmbMethod.Location = new System.Drawing.Point(178, 303);
            this.cmbMethod.MaxDropDownItems = 10;
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(424, 29);
            this.cmbMethod.TabIndex = 96;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(16, 402);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(112, 25);
            this.Label3.TabIndex = 95;
            this.Label3.Text = "Customer ID";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(16, 370);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(68, 25);
            this.Label2.TabIndex = 94;
            this.Label2.Text = "GC No.";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(16, 305);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 25);
            this.Label1.TabIndex = 93;
            this.Label1.Text = "Method";
            // 
            // lblDeductGC
            // 
            this.lblDeductGC.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeductGC.ForeColor = System.Drawing.Color.Black;
            this.lblDeductGC.Location = new System.Drawing.Point(180, 147);
            this.lblDeductGC.Name = "lblDeductGC";
            this.lblDeductGC.Size = new System.Drawing.Size(422, 25);
            this.lblDeductGC.TabIndex = 92;
            this.lblDeductGC.Text = "0.00";
            this.lblDeductGC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(14, 147);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(165, 25);
            this.Label10.TabIndex = 91;
            this.Label10.Text = "Deduct by gift card";
            // 
            // lblChange
            // 
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.lblChange.Location = new System.Drawing.Point(174, 233);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(429, 46);
            this.lblChange.TabIndex = 90;
            this.lblChange.Text = "0.00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.Label4.Location = new System.Drawing.Point(13, 247);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(97, 32);
            this.Label4.TabIndex = 89;
            this.Label4.Text = "Change";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(185)))), ((int)(((byte)(80)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(174, 203);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(429, 36);
            this.lblGrandTotal.TabIndex = 88;
            this.lblGrandTotal.Text = "0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDeductPoints
            // 
            this.lblDeductPoints.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeductPoints.ForeColor = System.Drawing.Color.Black;
            this.lblDeductPoints.Location = new System.Drawing.Point(174, 178);
            this.lblDeductPoints.Name = "lblDeductPoints";
            this.lblDeductPoints.Size = new System.Drawing.Size(428, 25);
            this.lblDeductPoints.TabIndex = 87;
            this.lblDeductPoints.Text = "0.00";
            this.lblDeductPoints.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(184, 117);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(418, 25);
            this.lblTotal.TabIndex = 86;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(185)))), ((int)(((byte)(80)))));
            this.Label9.Location = new System.Drawing.Point(13, 207);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(137, 32);
            this.Label9.TabIndex = 85;
            this.Label9.Text = "Grand Total";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(14, 178);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(149, 25);
            this.Label7.TabIndex = 84;
            this.Label7.Text = "Deduct by points";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(14, 117);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(49, 25);
            this.Label8.TabIndex = 83;
            this.Label8.Text = "Total";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 34F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(10, 51);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(593, 59);
            this.txtAmount.TabIndex = 82;
            this.txtAmount.Text = "0";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(619, 730);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.Payment_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.TableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        internal System.Windows.Forms.Label label5;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Button btnExact;
        internal System.Windows.Forms.Button btnGC;
        internal System.Windows.Forms.Button btnRemoveGC;
        internal System.Windows.Forms.Button btnPay;
        internal System.Windows.Forms.CheckBox cbxUsePoints;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblCustomerID;
        internal System.Windows.Forms.Label lblGCNo;
        internal System.Windows.Forms.ComboBox cmbMethod;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblDeductGC;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label lblChange;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblGrandTotal;
        internal System.Windows.Forms.Label lblDeductPoints;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtAmount;
    }
}