namespace EcoPOSv2
{
    partial class EditSD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSD));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCompanyDetails = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.TableLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtpPTU_ValidUntil = new System.Windows.Forms.DateTimePicker();
            this.dtpPTU_DateIssued = new System.Windows.Forms.DateTimePicker();
            this.dtpAN_ValidUntil = new System.Windows.Forms.DateTimePicker();
            this.txtAN = new System.Windows.Forms.TextBox();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.txtMIN = new System.Windows.Forms.TextBox();
            this.txtVATRegTin = new System.Windows.Forms.TextBox();
            this.txtTaxPayer = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPTUNo = new System.Windows.Forms.TextBox();
            this.dtpAN_DateIssued = new System.Windows.Forms.DateTimePicker();
            this.Label8 = new System.Windows.Forms.Label();
            this.tmrClose = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel1.SuspendLayout();
            this.TableLayout1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.lblCompanyDetails);
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Controls.Add(this.btnSave);
            this.guna2Panel1.Controls.Add(this.TableLayout1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(746, 689);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // lblCompanyDetails
            // 
            this.lblCompanyDetails.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCompanyDetails.AutoSize = true;
            this.lblCompanyDetails.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCompanyDetails.Location = new System.Drawing.Point(275, 17);
            this.lblCompanyDetails.Name = "lblCompanyDetails";
            this.lblCompanyDetails.Size = new System.Drawing.Size(178, 30);
            this.lblCompanyDetails.TabIndex = 59;
            this.lblCompanyDetails.Text = "Business Details";
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
            this.btnCancel.Location = new System.Drawing.Point(390, 608);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(189, 57);
            this.btnCancel.TabIndex = 58;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextOffset = new System.Drawing.Point(10, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderColor = System.Drawing.Color.Green;
            this.btnSave.BorderThickness = 2;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnSave.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSave.Location = new System.Drawing.Point(171, 608);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(189, 57);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextOffset = new System.Drawing.Point(10, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TableLayout1
            // 
            this.TableLayout1.ColumnCount = 2;
            this.TableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.72487F));
            this.TableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.27513F));
            this.TableLayout1.Controls.Add(this.txtContactNo, 1, 2);
            this.TableLayout1.Controls.Add(this.Label1, 0, 2);
            this.TableLayout1.Controls.Add(this.dtpPTU_ValidUntil, 1, 12);
            this.TableLayout1.Controls.Add(this.dtpPTU_DateIssued, 1, 11);
            this.TableLayout1.Controls.Add(this.dtpAN_ValidUntil, 1, 9);
            this.TableLayout1.Controls.Add(this.txtAN, 1, 7);
            this.TableLayout1.Controls.Add(this.txtSN, 1, 6);
            this.TableLayout1.Controls.Add(this.txtMIN, 1, 5);
            this.TableLayout1.Controls.Add(this.txtVATRegTin, 1, 4);
            this.TableLayout1.Controls.Add(this.txtTaxPayer, 1, 3);
            this.TableLayout1.Controls.Add(this.txtAddress, 1, 1);
            this.TableLayout1.Controls.Add(this.Label23, 0, 12);
            this.TableLayout1.Controls.Add(this.Label4, 0, 0);
            this.TableLayout1.Controls.Add(this.Label5, 0, 3);
            this.TableLayout1.Controls.Add(this.Label3, 0, 4);
            this.TableLayout1.Controls.Add(this.Label11, 0, 6);
            this.TableLayout1.Controls.Add(this.Label10, 0, 5);
            this.TableLayout1.Controls.Add(this.Label14, 0, 7);
            this.TableLayout1.Controls.Add(this.Label16, 0, 10);
            this.TableLayout1.Controls.Add(this.Label21, 0, 11);
            this.TableLayout1.Controls.Add(this.Label13, 0, 9);
            this.TableLayout1.Controls.Add(this.Label18, 0, 8);
            this.TableLayout1.Controls.Add(this.txtName, 1, 0);
            this.TableLayout1.Controls.Add(this.txtPTUNo, 1, 10);
            this.TableLayout1.Controls.Add(this.dtpAN_DateIssued, 1, 8);
            this.TableLayout1.Controls.Add(this.Label8, 0, 1);
            this.TableLayout1.Location = new System.Drawing.Point(0, 64);
            this.TableLayout1.Name = "TableLayout1";
            this.TableLayout1.RowCount = 15;
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayout1.Size = new System.Drawing.Size(744, 507);
            this.TableLayout1.TabIndex = 14;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContactNo.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(320, 108);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(421, 30);
            this.txtContactNo.TabIndex = 51;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(3, 105);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(311, 35);
            this.Label1.TabIndex = 61;
            this.Label1.Text = "Business contact no.";
            // 
            // dtpPTU_ValidUntil
            // 
            this.dtpPTU_ValidUntil.CustomFormat = "MMMM dd, yyyy";
            this.dtpPTU_ValidUntil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPTU_ValidUntil.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPTU_ValidUntil.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPTU_ValidUntil.Location = new System.Drawing.Point(320, 458);
            this.dtpPTU_ValidUntil.Name = "dtpPTU_ValidUntil";
            this.dtpPTU_ValidUntil.Size = new System.Drawing.Size(421, 30);
            this.dtpPTU_ValidUntil.TabIndex = 60;
            this.dtpPTU_ValidUntil.Value = new System.DateTime(2021, 1, 10, 12, 39, 5, 0);
            // 
            // dtpPTU_DateIssued
            // 
            this.dtpPTU_DateIssued.CustomFormat = "MMMM dd, yyyy";
            this.dtpPTU_DateIssued.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPTU_DateIssued.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPTU_DateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPTU_DateIssued.Location = new System.Drawing.Point(320, 423);
            this.dtpPTU_DateIssued.Name = "dtpPTU_DateIssued";
            this.dtpPTU_DateIssued.Size = new System.Drawing.Size(421, 30);
            this.dtpPTU_DateIssued.TabIndex = 59;
            this.dtpPTU_DateIssued.Value = new System.DateTime(2021, 1, 10, 12, 39, 5, 0);
            // 
            // dtpAN_ValidUntil
            // 
            this.dtpAN_ValidUntil.CustomFormat = "MMMM dd, yyyy";
            this.dtpAN_ValidUntil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpAN_ValidUntil.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAN_ValidUntil.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAN_ValidUntil.Location = new System.Drawing.Point(320, 353);
            this.dtpAN_ValidUntil.Name = "dtpAN_ValidUntil";
            this.dtpAN_ValidUntil.Size = new System.Drawing.Size(421, 30);
            this.dtpAN_ValidUntil.TabIndex = 58;
            this.dtpAN_ValidUntil.Value = new System.DateTime(2021, 1, 10, 12, 39, 11, 0);
            // 
            // txtAN
            // 
            this.txtAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAN.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAN.Location = new System.Drawing.Point(320, 283);
            this.txtAN.Name = "txtAN";
            this.txtAN.Size = new System.Drawing.Size(421, 30);
            this.txtAN.TabIndex = 55;
            // 
            // txtSN
            // 
            this.txtSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSN.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSN.Location = new System.Drawing.Point(320, 248);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(421, 30);
            this.txtSN.TabIndex = 54;
            // 
            // txtMIN
            // 
            this.txtMIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMIN.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMIN.Location = new System.Drawing.Point(320, 213);
            this.txtMIN.Name = "txtMIN";
            this.txtMIN.Size = new System.Drawing.Size(421, 30);
            this.txtMIN.TabIndex = 53;
            // 
            // txtVATRegTin
            // 
            this.txtVATRegTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVATRegTin.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVATRegTin.Location = new System.Drawing.Point(320, 178);
            this.txtVATRegTin.Name = "txtVATRegTin";
            this.txtVATRegTin.Size = new System.Drawing.Size(421, 30);
            this.txtVATRegTin.TabIndex = 52;
            // 
            // txtTaxPayer
            // 
            this.txtTaxPayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaxPayer.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxPayer.Location = new System.Drawing.Point(320, 143);
            this.txtTaxPayer.Name = "txtTaxPayer";
            this.txtTaxPayer.Size = new System.Drawing.Size(421, 30);
            this.txtTaxPayer.TabIndex = 51;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(320, 73);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(421, 30);
            this.txtAddress.TabIndex = 50;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label23.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(3, 455);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(311, 20);
            this.Label23.TabIndex = 48;
            this.Label23.Text = "PTU Valid Until";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(3, 0);
            this.Label4.Name = "Label4";
            this.TableLayout1.SetRowSpan(this.Label4, 2);
            this.Label4.Size = new System.Drawing.Size(311, 70);
            this.Label4.TabIndex = 23;
            this.Label4.Text = "Business Name";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(3, 140);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(311, 35);
            this.Label5.TabIndex = 27;
            this.Label5.Text = "Name of the tax payer";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(3, 175);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(311, 35);
            this.Label3.TabIndex = 26;
            this.Label3.Text = "VAT/Non-VAT REG TIN";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label11.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(3, 245);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(311, 35);
            this.Label11.TabIndex = 33;
            this.Label11.Text = "Serial Number (SN)";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label10.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(3, 210);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(311, 35);
            this.Label10.TabIndex = 32;
            this.Label10.Text = "Machine Identification Number (MIN)\r\n";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label14.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(3, 280);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(311, 35);
            this.Label14.TabIndex = 41;
            this.Label14.Text = "Accreditation No.";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label16.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(3, 385);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(311, 35);
            this.Label16.TabIndex = 42;
            this.Label16.Text = "Permit To Use (PTU) No.";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label21.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.Black;
            this.Label21.Location = new System.Drawing.Point(3, 420);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(311, 35);
            this.Label21.TabIndex = 46;
            this.Label21.Text = "PTU Date Issued";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label13.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(3, 350);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(311, 35);
            this.Label13.TabIndex = 35;
            this.Label13.Text = "AN Valid Until";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label18.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label18.ForeColor = System.Drawing.Color.Black;
            this.Label18.Location = new System.Drawing.Point(3, 315);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(311, 35);
            this.Label18.TabIndex = 43;
            this.Label18.Text = "AN Date Issued";
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(320, 3);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.TableLayout1.SetRowSpan(this.txtName, 2);
            this.txtName.Size = new System.Drawing.Size(421, 64);
            this.txtName.TabIndex = 49;
            // 
            // txtPTUNo
            // 
            this.txtPTUNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPTUNo.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPTUNo.Location = new System.Drawing.Point(320, 388);
            this.txtPTUNo.Name = "txtPTUNo";
            this.txtPTUNo.Size = new System.Drawing.Size(421, 30);
            this.txtPTUNo.TabIndex = 56;
            // 
            // dtpAN_DateIssued
            // 
            this.dtpAN_DateIssued.CustomFormat = "MMMM dd, yyyy";
            this.dtpAN_DateIssued.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpAN_DateIssued.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAN_DateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAN_DateIssued.Location = new System.Drawing.Point(320, 318);
            this.dtpAN_DateIssued.Name = "dtpAN_DateIssued";
            this.dtpAN_DateIssued.Size = new System.Drawing.Size(421, 30);
            this.dtpAN_DateIssued.TabIndex = 57;
            this.dtpAN_DateIssued.Value = new System.DateTime(2021, 1, 10, 12, 39, 11, 0);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label8.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(3, 70);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(311, 35);
            this.Label8.TabIndex = 30;
            this.Label8.Text = "Business address";
            // 
            // tmrClose
            // 
            this.tmrClose.Interval = 1000;
            // 
            // EditSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 689);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditSD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditSD";
            this.Load += new System.EventHandler(this.EditSD_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.TableLayout1.ResumeLayout(false);
            this.TableLayout1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        internal System.Windows.Forms.TableLayoutPanel TableLayout1;
        internal System.Windows.Forms.TextBox txtContactNo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker dtpPTU_ValidUntil;
        internal System.Windows.Forms.DateTimePicker dtpPTU_DateIssued;
        internal System.Windows.Forms.DateTimePicker dtpAN_ValidUntil;
        internal System.Windows.Forms.TextBox txtAN;
        internal System.Windows.Forms.TextBox txtSN;
        internal System.Windows.Forms.TextBox txtMIN;
        internal System.Windows.Forms.TextBox txtVATRegTin;
        internal System.Windows.Forms.TextBox txtTaxPayer;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.TextBox txtPTUNo;
        internal System.Windows.Forms.DateTimePicker dtpAN_DateIssued;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Timer tmrClose;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        public Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label lblCompanyDetails;
    }
}