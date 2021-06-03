namespace EcoPOSv2
{
    partial class DVOptions
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
            this.Label1 = new System.Windows.Forms.Label();
            this.btnShowMainForm = new System.Windows.Forms.Button();
            this.btnImportDatabase = new System.Windows.Forms.Button();
            this.btnChangeStoreSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(6, 200);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(267, 34);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Note: Setup store details and import database first for new systems before procee" +
    "ding.";
            // 
            // btnShowMainForm
            // 
            this.btnShowMainForm.Location = new System.Drawing.Point(3, 237);
            this.btnShowMainForm.Name = "btnShowMainForm";
            this.btnShowMainForm.Size = new System.Drawing.Size(270, 23);
            this.btnShowMainForm.TabIndex = 6;
            this.btnShowMainForm.Text = "Show main form";
            this.btnShowMainForm.UseVisualStyleBackColor = true;
            // 
            // btnImportDatabase
            // 
            this.btnImportDatabase.Location = new System.Drawing.Point(3, 32);
            this.btnImportDatabase.Name = "btnImportDatabase";
            this.btnImportDatabase.Size = new System.Drawing.Size(270, 23);
            this.btnImportDatabase.TabIndex = 5;
            this.btnImportDatabase.Text = "Import database";
            this.btnImportDatabase.UseVisualStyleBackColor = true;
            // 
            // btnChangeStoreSettings
            // 
            this.btnChangeStoreSettings.Location = new System.Drawing.Point(3, 3);
            this.btnChangeStoreSettings.Name = "btnChangeStoreSettings";
            this.btnChangeStoreSettings.Size = new System.Drawing.Size(270, 23);
            this.btnChangeStoreSettings.TabIndex = 4;
            this.btnChangeStoreSettings.Text = "Change store details";
            this.btnChangeStoreSettings.UseVisualStyleBackColor = true;
            // 
            // DVOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 262);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnShowMainForm);
            this.Controls.Add(this.btnImportDatabase);
            this.Controls.Add(this.btnChangeStoreSettings);
            this.Name = "DVOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DVOptions";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnShowMainForm;
        internal System.Windows.Forms.Button btnImportDatabase;
        internal System.Windows.Forms.Button btnChangeStoreSettings;
    }
}