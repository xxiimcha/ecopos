namespace EcoPOSv2
{
    partial class ImportDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportDatabase));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnConfirm2 = new System.Windows.Forms.Button();
            this.btnChooseFile2 = new System.Windows.Forms.Button();
            this.txtDatabase2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRestartApp = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(105, 94);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(196, 65);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFile.TabIndex = 10;
            this.btnChooseFile.Text = "Choose file";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(14, 39);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(260, 20);
            this.txtDatabase.TabIndex = 9;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 23);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(48, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "EcoPOS";
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            this.OpenFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // btnConfirm2
            // 
            this.btnConfirm2.Location = new System.Drawing.Point(105, 191);
            this.btnConfirm2.Name = "btnConfirm2";
            this.btnConfirm2.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm2.TabIndex = 15;
            this.btnConfirm2.Text = "Confirm";
            this.btnConfirm2.UseVisualStyleBackColor = true;
            this.btnConfirm2.Click += new System.EventHandler(this.BtnConfirm2_Click);
            // 
            // btnChooseFile2
            // 
            this.btnChooseFile2.Location = new System.Drawing.Point(196, 160);
            this.btnChooseFile2.Name = "btnChooseFile2";
            this.btnChooseFile2.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFile2.TabIndex = 14;
            this.btnChooseFile2.Text = "Choose file";
            this.btnChooseFile2.UseVisualStyleBackColor = true;
            this.btnChooseFile2.Click += new System.EventHandler(this.BtnChooseFile2_Click);
            // 
            // txtDatabase2
            // 
            this.txtDatabase2.Location = new System.Drawing.Point(14, 134);
            this.txtDatabase2.Name = "txtDatabase2";
            this.txtDatabase2.Size = new System.Drawing.Size(260, 20);
            this.txtDatabase2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "EcoPOS_Training";
            // 
            // btnRestartApp
            // 
            this.btnRestartApp.Location = new System.Drawing.Point(84, 250);
            this.btnRestartApp.Name = "btnRestartApp";
            this.btnRestartApp.Size = new System.Drawing.Size(120, 23);
            this.btnRestartApp.TabIndex = 16;
            this.btnRestartApp.Text = "Restart Application";
            this.btnRestartApp.UseVisualStyleBackColor = true;
            this.btnRestartApp.Click += new System.EventHandler(this.BtnRestartApp_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "OpenFileDialog1";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog2_FileOk);
            // 
            // ImportDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 285);
            this.Controls.Add(this.btnRestartApp);
            this.Controls.Add(this.btnConfirm2);
            this.Controls.Add(this.btnChooseFile2);
            this.Controls.Add(this.txtDatabase2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportDatabase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnConfirm;
        internal System.Windows.Forms.Button btnChooseFile;
        internal System.Windows.Forms.TextBox txtDatabase;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.Button btnConfirm2;
        internal System.Windows.Forms.Button btnChooseFile2;
        internal System.Windows.Forms.TextBox txtDatabase2;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnRestartApp;
        internal System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}