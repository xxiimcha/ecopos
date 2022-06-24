namespace EcoPOSv2
{
    partial class Database
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Database));
            this.btnImportGC = new FontAwesome.Sharp.IconButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnImportMembership = new FontAwesome.Sharp.IconButton();
            this.btnExportGC = new FontAwesome.Sharp.IconButton();
            this.btnExportProducts = new FontAwesome.Sharp.IconButton();
            this.btnImportProducts = new FontAwesome.Sharp.IconButton();
            this.btnExportCategory = new FontAwesome.Sharp.IconButton();
            this.btnImportCategory = new FontAwesome.Sharp.IconButton();
            this.btnExportCustomer = new FontAwesome.Sharp.IconButton();
            this.btnImportCustomer = new FontAwesome.Sharp.IconButton();
            this.btnExportMC = new FontAwesome.Sharp.IconButton();
            this.btnImportMC = new FontAwesome.Sharp.IconButton();
            this.btnExportMembership = new FontAwesome.Sharp.IconButton();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportGC
            // 
            this.btnImportGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportGC.Enabled = false;
            this.btnImportGC.FlatAppearance.BorderSize = 0;
            this.btnImportGC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportGC.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportGC.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnImportGC.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnImportGC.IconColor = System.Drawing.Color.DarkCyan;
            this.btnImportGC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportGC.IconSize = 30;
            this.btnImportGC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportGC.Location = new System.Drawing.Point(3, 538);
            this.btnImportGC.Name = "btnImportGC";
            this.btnImportGC.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnImportGC.Size = new System.Drawing.Size(1158, 44);
            this.btnImportGC.TabIndex = 14;
            this.btnImportGC.Text = "Import Gift Card";
            this.btnImportGC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportGC.UseVisualStyleBackColor = true;
            this.btnImportGC.Click += new System.EventHandler(this.btnImportGC_Click);
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.DimGray;
            this.Label1.Location = new System.Drawing.Point(3, 585);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.Label1.Size = new System.Drawing.Size(1158, 100);
            this.Label1.TabIndex = 11;
            this.Label1.Text = resources.GetString("Label1.Text");
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnImportMembership
            // 
            this.btnImportMembership.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportMembership.Enabled = false;
            this.btnImportMembership.FlatAppearance.BorderSize = 0;
            this.btnImportMembership.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportMembership.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportMembership.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnImportMembership.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnImportMembership.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnImportMembership.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportMembership.IconSize = 30;
            this.btnImportMembership.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportMembership.Location = new System.Drawing.Point(3, 444);
            this.btnImportMembership.Name = "btnImportMembership";
            this.btnImportMembership.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnImportMembership.Size = new System.Drawing.Size(1158, 44);
            this.btnImportMembership.TabIndex = 17;
            this.btnImportMembership.Text = "Import Membership";
            this.btnImportMembership.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportMembership.UseVisualStyleBackColor = true;
            this.btnImportMembership.Click += new System.EventHandler(this.btnImportMembership_Click);
            // 
            // btnExportGC
            // 
            this.btnExportGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportGC.Enabled = false;
            this.btnExportGC.FlatAppearance.BorderSize = 0;
            this.btnExportGC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportGC.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportGC.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnExportGC.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnExportGC.IconColor = System.Drawing.Color.DarkCyan;
            this.btnExportGC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportGC.IconSize = 30;
            this.btnExportGC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportGC.Location = new System.Drawing.Point(3, 494);
            this.btnExportGC.Name = "btnExportGC";
            this.btnExportGC.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnExportGC.Size = new System.Drawing.Size(1158, 38);
            this.btnExportGC.TabIndex = 12;
            this.btnExportGC.Text = "Export Gift Card";
            this.btnExportGC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportGC.UseVisualStyleBackColor = true;
            this.btnExportGC.Click += new System.EventHandler(this.btnExportGC_Click);
            // 
            // btnExportProducts
            // 
            this.btnExportProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportProducts.FlatAppearance.BorderSize = 0;
            this.btnExportProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportProducts.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(97)))), ((int)(((byte)(62)))));
            this.btnExportProducts.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnExportProducts.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(97)))), ((int)(((byte)(62)))));
            this.btnExportProducts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportProducts.IconSize = 30;
            this.btnExportProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportProducts.Location = new System.Drawing.Point(3, 3);
            this.btnExportProducts.Name = "btnExportProducts";
            this.btnExportProducts.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnExportProducts.Size = new System.Drawing.Size(1158, 53);
            this.btnExportProducts.TabIndex = 5;
            this.btnExportProducts.Text = "Export Products";
            this.btnExportProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportProducts.UseVisualStyleBackColor = true;
            this.btnExportProducts.Click += new System.EventHandler(this.btnExportProducts_Click);
            // 
            // btnImportProducts
            // 
            this.btnImportProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportProducts.FlatAppearance.BorderSize = 0;
            this.btnImportProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportProducts.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(97)))), ((int)(((byte)(62)))));
            this.btnImportProducts.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnImportProducts.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(97)))), ((int)(((byte)(62)))));
            this.btnImportProducts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportProducts.IconSize = 30;
            this.btnImportProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportProducts.Location = new System.Drawing.Point(3, 62);
            this.btnImportProducts.Name = "btnImportProducts";
            this.btnImportProducts.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnImportProducts.Size = new System.Drawing.Size(1158, 48);
            this.btnImportProducts.TabIndex = 8;
            this.btnImportProducts.Text = "Import Products";
            this.btnImportProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportProducts.UseVisualStyleBackColor = true;
            this.btnImportProducts.Click += new System.EventHandler(this.btnImportProducts_Click);
            // 
            // btnExportCategory
            // 
            this.btnExportCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportCategory.FlatAppearance.BorderSize = 0;
            this.btnExportCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCategory.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExportCategory.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnExportCategory.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExportCategory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportCategory.IconSize = 30;
            this.btnExportCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportCategory.Location = new System.Drawing.Point(3, 116);
            this.btnExportCategory.Name = "btnExportCategory";
            this.btnExportCategory.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnExportCategory.Size = new System.Drawing.Size(1158, 44);
            this.btnExportCategory.TabIndex = 6;
            this.btnExportCategory.Text = "Export Category";
            this.btnExportCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportCategory.UseVisualStyleBackColor = true;
            this.btnExportCategory.Click += new System.EventHandler(this.btnExportCategory_Click);
            // 
            // btnImportCategory
            // 
            this.btnImportCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportCategory.FlatAppearance.BorderSize = 0;
            this.btnImportCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCategory.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnImportCategory.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnImportCategory.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnImportCategory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportCategory.IconSize = 30;
            this.btnImportCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportCategory.Location = new System.Drawing.Point(3, 166);
            this.btnImportCategory.Name = "btnImportCategory";
            this.btnImportCategory.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnImportCategory.Size = new System.Drawing.Size(1158, 41);
            this.btnImportCategory.TabIndex = 9;
            this.btnImportCategory.Text = "Import Category";
            this.btnImportCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportCategory.UseVisualStyleBackColor = true;
            this.btnImportCategory.Click += new System.EventHandler(this.btnImportCategory_Click);
            // 
            // btnExportCustomer
            // 
            this.btnExportCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportCustomer.FlatAppearance.BorderSize = 0;
            this.btnExportCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCustomer.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCustomer.ForeColor = System.Drawing.Color.Teal;
            this.btnExportCustomer.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnExportCustomer.IconColor = System.Drawing.Color.Teal;
            this.btnExportCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportCustomer.IconSize = 30;
            this.btnExportCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportCustomer.Location = new System.Drawing.Point(3, 213);
            this.btnExportCustomer.Name = "btnExportCustomer";
            this.btnExportCustomer.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnExportCustomer.Size = new System.Drawing.Size(1158, 42);
            this.btnExportCustomer.TabIndex = 7;
            this.btnExportCustomer.Text = "Export Customer";
            this.btnExportCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportCustomer.UseVisualStyleBackColor = true;
            this.btnExportCustomer.Click += new System.EventHandler(this.btnExportCustomer_Click);
            // 
            // btnImportCustomer
            // 
            this.btnImportCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportCustomer.FlatAppearance.BorderSize = 0;
            this.btnImportCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCustomer.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCustomer.ForeColor = System.Drawing.Color.Teal;
            this.btnImportCustomer.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnImportCustomer.IconColor = System.Drawing.Color.Teal;
            this.btnImportCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportCustomer.IconSize = 30;
            this.btnImportCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportCustomer.Location = new System.Drawing.Point(3, 261);
            this.btnImportCustomer.Name = "btnImportCustomer";
            this.btnImportCustomer.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnImportCustomer.Size = new System.Drawing.Size(1158, 35);
            this.btnImportCustomer.TabIndex = 10;
            this.btnImportCustomer.Text = "Import Customer";
            this.btnImportCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportCustomer.UseVisualStyleBackColor = true;
            this.btnImportCustomer.Click += new System.EventHandler(this.btnImportCustomer_Click);
            // 
            // btnExportMC
            // 
            this.btnExportMC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportMC.Enabled = false;
            this.btnExportMC.FlatAppearance.BorderSize = 0;
            this.btnExportMC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportMC.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportMC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(120)))), ((int)(((byte)(209)))));
            this.btnExportMC.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnExportMC.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(120)))), ((int)(((byte)(209)))));
            this.btnExportMC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportMC.IconSize = 30;
            this.btnExportMC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportMC.Location = new System.Drawing.Point(3, 302);
            this.btnExportMC.Name = "btnExportMC";
            this.btnExportMC.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnExportMC.Size = new System.Drawing.Size(1158, 40);
            this.btnExportMC.TabIndex = 13;
            this.btnExportMC.Text = "Export Member Card";
            this.btnExportMC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportMC.UseVisualStyleBackColor = true;
            this.btnExportMC.Click += new System.EventHandler(this.btnExportMC_Click);
            // 
            // btnImportMC
            // 
            this.btnImportMC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportMC.Enabled = false;
            this.btnImportMC.FlatAppearance.BorderSize = 0;
            this.btnImportMC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportMC.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportMC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(120)))), ((int)(((byte)(209)))));
            this.btnImportMC.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnImportMC.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(120)))), ((int)(((byte)(209)))));
            this.btnImportMC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportMC.IconSize = 30;
            this.btnImportMC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportMC.Location = new System.Drawing.Point(3, 348);
            this.btnImportMC.Name = "btnImportMC";
            this.btnImportMC.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnImportMC.Size = new System.Drawing.Size(1158, 41);
            this.btnImportMC.TabIndex = 15;
            this.btnImportMC.Text = "Import Member Card";
            this.btnImportMC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportMC.UseVisualStyleBackColor = true;
            this.btnImportMC.Click += new System.EventHandler(this.btnImportMC_Click);
            // 
            // btnExportMembership
            // 
            this.btnExportMembership.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportMembership.Enabled = false;
            this.btnExportMembership.FlatAppearance.BorderSize = 0;
            this.btnExportMembership.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportMembership.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportMembership.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExportMembership.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnExportMembership.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExportMembership.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportMembership.IconSize = 30;
            this.btnExportMembership.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportMembership.Location = new System.Drawing.Point(3, 395);
            this.btnExportMembership.Name = "btnExportMembership";
            this.btnExportMembership.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnExportMembership.Size = new System.Drawing.Size(1158, 43);
            this.btnExportMembership.TabIndex = 16;
            this.btnExportMembership.Text = "Export Membership";
            this.btnExportMembership.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportMembership.UseVisualStyleBackColor = true;
            this.btnExportMembership.Click += new System.EventHandler(this.btnExportMembership_Click);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.btnImportGC, 0, 11);
            this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 12);
            this.TableLayoutPanel1.Controls.Add(this.btnImportMembership, 0, 9);
            this.TableLayoutPanel1.Controls.Add(this.btnExportGC, 0, 10);
            this.TableLayoutPanel1.Controls.Add(this.btnExportProducts, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.btnImportProducts, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.btnExportCategory, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.btnImportCategory, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.btnExportCustomer, 0, 4);
            this.TableLayoutPanel1.Controls.Add(this.btnImportCustomer, 0, 5);
            this.TableLayoutPanel1.Controls.Add(this.btnExportMC, 0, 6);
            this.TableLayoutPanel1.Controls.Add(this.btnImportMC, 0, 7);
            this.TableLayoutPanel1.Controls.Add(this.btnExportMembership, 0, 8);
            this.TableLayoutPanel1.Controls.Add(this.dgv, 0, 13);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 14;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.505774F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.928406F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.351039F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.004619F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.120092F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.196305F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.889145F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.004619F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.235566F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.351039F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.658199F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.351039F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.70208F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.47113F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1164, 788);
            this.TableLayoutPanel1.TabIndex = 20;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(3, 688);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(1158, 97);
            this.dgv.TabIndex = 18;
            this.dgv.Visible = false;
            // 
            // Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 788);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Database";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database";
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal FontAwesome.Sharp.IconButton btnImportGC;
        internal System.Windows.Forms.Label Label1;
        internal FontAwesome.Sharp.IconButton btnImportMembership;
        internal FontAwesome.Sharp.IconButton btnExportGC;
        internal FontAwesome.Sharp.IconButton btnExportProducts;
        internal FontAwesome.Sharp.IconButton btnImportProducts;
        internal FontAwesome.Sharp.IconButton btnExportCategory;
        internal FontAwesome.Sharp.IconButton btnImportCategory;
        internal FontAwesome.Sharp.IconButton btnExportCustomer;
        internal FontAwesome.Sharp.IconButton btnImportCustomer;
        internal FontAwesome.Sharp.IconButton btnExportMC;
        internal FontAwesome.Sharp.IconButton btnImportMC;
        internal FontAwesome.Sharp.IconButton btnExportMembership;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv;
    }
}