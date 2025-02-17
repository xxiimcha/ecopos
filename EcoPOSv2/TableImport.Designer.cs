﻿namespace EcoPOSv2
{
    partial class TableImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableImport));
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbSheet = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(12, 111);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(87, 15);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Choose Sheet:";
            // 
            // cmbSheet
            // 
            this.cmbSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSheet.FormattingEnabled = true;
            this.cmbSheet.Location = new System.Drawing.Point(12, 129);
            this.cmbSheet.Name = "cmbSheet";
            this.cmbSheet.Size = new System.Drawing.Size(259, 21);
            this.cmbSheet.TabIndex = 11;
            this.cmbSheet.SelectedIndexChanged += new System.EventHandler(this.cmbSheet_SelectedIndexChanged);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(104, 156);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(196, 75);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(12, 49);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(259, 20);
            this.txtFile.TabIndex = 8;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 30);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 15);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "File Name: ";
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(304, 16);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(10, 10);
            this.DataGridView1.TabIndex = 13;
            this.DataGridView1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 197);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(266, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // TableImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 227);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbSheet);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.DataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TableImport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TableImport_FormClosing);
            this.Load += new System.EventHandler(this.TableImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cmbSheet;
        internal System.Windows.Forms.Button btnImport;
        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.TextBox txtFile;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}