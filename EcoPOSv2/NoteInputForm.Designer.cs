
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteInputForm));
            this.btnKeep = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtInputNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.SuspendLayout();
            // 
            // btnKeep
            // 
            this.btnKeep.BorderColor = System.Drawing.Color.Green;
            this.btnKeep.BorderRadius = 3;
            this.btnKeep.BorderThickness = 2;
            this.btnKeep.CheckedState.Parent = this.btnKeep;
            this.btnKeep.CustomImages.Parent = this.btnKeep;
            this.btnKeep.FillColor = System.Drawing.Color.White;
            this.btnKeep.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnKeep.ForeColor = System.Drawing.Color.Green;
            this.btnKeep.HoverState.Parent = this.btnKeep;
            this.btnKeep.Image = ((System.Drawing.Image)(resources.GetObject("btnKeep.Image")));
            this.btnKeep.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKeep.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnKeep.ImageSize = new System.Drawing.Size(28, 28);
            this.btnKeep.Location = new System.Drawing.Point(23, 119);
            this.btnKeep.Name = "btnKeep";
            this.btnKeep.ShadowDecoration.Parent = this.btnKeep;
            this.btnKeep.Size = new System.Drawing.Size(177, 43);
            this.btnKeep.TabIndex = 58;
            this.btnKeep.Text = "KEEP";
            this.btnKeep.TextOffset = new System.Drawing.Point(10, 0);
            this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
            this.btnKeep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnKeep_KeyDown);
            this.btnKeep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnKeep_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.BorderRadius = 3;
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
            this.btnCancel.ImageSize = new System.Drawing.Size(28, 28);
            this.btnCancel.Location = new System.Drawing.Point(233, 119);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(177, 43);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextOffset = new System.Drawing.Point(10, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(18, 20);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(62, 25);
            this.Label2.TabIndex = 61;
            this.Label2.Text = "Name";
            // 
            // txtInputNote
            // 
            this.txtInputNote.BorderRadius = 3;
            this.txtInputNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInputNote.DefaultText = "";
            this.txtInputNote.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtInputNote.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtInputNote.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInputNote.DisabledState.Parent = this.txtInputNote;
            this.txtInputNote.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInputNote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.txtInputNote.FocusedState.Parent = this.txtInputNote;
            this.txtInputNote.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(73)))));
            this.txtInputNote.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtInputNote.HoverState.Parent = this.txtInputNote;
            this.txtInputNote.Location = new System.Drawing.Point(23, 62);
            this.txtInputNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputNote.Name = "txtInputNote";
            this.txtInputNote.PasswordChar = '\0';
            this.txtInputNote.PlaceholderText = "";
            this.txtInputNote.SelectedText = "";
            this.txtInputNote.ShadowDecoration.Parent = this.txtInputNote;
            this.txtInputNote.Size = new System.Drawing.Size(387, 33);
            this.txtInputNote.TabIndex = 62;
            this.txtInputNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputNote_KeyDown);
            // 
            // NoteInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(436, 190);
            this.Controls.Add(this.txtInputNote);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnKeep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoteInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Note";
            this.Load += new System.EventHandler(this.NoteInputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnKeep;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        internal System.Windows.Forms.Label Label2;
        private Guna.UI2.WinForms.Guna2TextBox txtInputNote;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}