namespace EcoPOSv2
{
    partial class StartingCash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingCash));
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.tbCash = new System.Windows.Forms.TextBox();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2TileButton();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(275, 0);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 4;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.tbCash);
            this.guna2Panel1.Controls.Add(this.btnConfirm);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Location = new System.Drawing.Point(12, 35);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(296, 196);
            this.guna2Panel1.TabIndex = 8;
            // 
            // tbCash
            // 
            this.tbCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCash.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCash.Location = new System.Drawing.Point(12, 59);
            this.tbCash.Multiline = true;
            this.tbCash.Name = "tbCash";
            this.tbCash.Size = new System.Drawing.Size(271, 53);
            this.tbCash.TabIndex = 10;
            this.tbCash.TextChanged += new System.EventHandler(this.tbCash_TextChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.CheckedState.Parent = this.btnConfirm;
            this.btnConfirm.CustomImages.Parent = this.btnConfirm;
            this.btnConfirm.FillColor = System.Drawing.Color.Green;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.HoverState.Parent = this.btnConfirm;
            this.btnConfirm.Location = new System.Drawing.Point(35, 123);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ShadowDecoration.Parent = this.btnConfirm;
            this.btnConfirm.Size = new System.Drawing.Size(227, 50);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "STARTING CASH";
            // 
            // StartingCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 248);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.gunaControlBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartingCash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartingCash";
            this.Load += new System.EventHandler(this.StartingCash_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TileButton btnConfirm;
        private System.Windows.Forms.TextBox tbCash;
    }
}