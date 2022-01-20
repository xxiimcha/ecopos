
namespace EcoPOSv2
{
    partial class NoteInputForm
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
            this.txtInputNote = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblInsertNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInputNote
            // 
            this.txtInputNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputNote.Location = new System.Drawing.Point(66, 92);
            this.txtInputNote.Name = "txtInputNote";
            this.txtInputNote.Size = new System.Drawing.Size(250, 29);
            this.txtInputNote.TabIndex = 0;
            this.txtInputNote.Tag = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "Keep";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblInsertNote
            // 
            this.lblInsertNote.AutoSize = true;
            this.lblInsertNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertNote.Location = new System.Drawing.Point(158, 59);
            this.lblInsertNote.Name = "lblInsertNote";
            this.lblInsertNote.Size = new System.Drawing.Size(55, 18);
            this.lblInsertNote.TabIndex = 2;
            this.lblInsertNote.Text = "NAME:";
            // 
            // NoteInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 217);
            this.Controls.Add(this.lblInsertNote);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtInputNote);
            this.Name = "NoteInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Note";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputNote;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblInsertNote;
    }
}