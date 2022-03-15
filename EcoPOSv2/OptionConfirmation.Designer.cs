
namespace EcoPOSv2
{
    partial class OptionConfirmation
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
            this.btn2 = new Guna.UI2.WinForms.Guna2Button();
            this.btn1 = new Guna.UI2.WinForms.Guna2Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnCLose = new Guna.UI.WinForms.GunaControlBox();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn2
            // 
            this.btn2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn2.BackColor = System.Drawing.Color.White;
            this.btn2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn2.BorderRadius = 3;
            this.btn2.BorderThickness = 2;
            this.btn2.CheckedState.Parent = this.btn2;
            this.btn2.CustomImages.Parent = this.btn2;
            this.btn2.FillColor = System.Drawing.Color.White;
            this.btn2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn2.HoverState.Parent = this.btn2;
            this.btn2.Location = new System.Drawing.Point(14, 78);
            this.btn2.Name = "btn2";
            this.btn2.ShadowDecoration.Parent = this.btn2;
            this.btn2.Size = new System.Drawing.Size(161, 43);
            this.btn2.TabIndex = 47;
            this.btn2.Text = "DELETE";
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn1.BackColor = System.Drawing.Color.White;
            this.btn1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btn1.BorderRadius = 3;
            this.btn1.BorderThickness = 2;
            this.btn1.CheckedState.Parent = this.btn1;
            this.btn1.CustomImages.Parent = this.btn1;
            this.btn1.FillColor = System.Drawing.Color.White;
            this.btn1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(93)))));
            this.btn1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn1.HoverState.Parent = this.btn1;
            this.btn1.Location = new System.Drawing.Point(186, 78);
            this.btn1.Name = "btn1";
            this.btn1.ShadowDecoration.Parent = this.btn1;
            this.btn1.Size = new System.Drawing.Size(161, 43);
            this.btn1.TabIndex = 48;
            this.btn1.Text = "PAY";
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblMessage.Location = new System.Drawing.Point(12, 24);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(232, 40);
            this.lblMessage.TabIndex = 49;
            this.lblMessage.Text = "Name";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCLose
            // 
            this.btnCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCLose.AnimationHoverSpeed = 0.07F;
            this.btnCLose.AnimationSpeed = 0.03F;
            this.btnCLose.BackColor = System.Drawing.Color.Transparent;
            this.btnCLose.IconColor = System.Drawing.Color.Black;
            this.btnCLose.IconSize = 15F;
            this.btnCLose.Location = new System.Drawing.Point(323, 3);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCLose.OnHoverIconColor = System.Drawing.Color.White;
            this.btnCLose.OnPressedColor = System.Drawing.Color.Black;
            this.btnCLose.Size = new System.Drawing.Size(35, 33);
            this.btnCLose.TabIndex = 57;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btn1);
            this.guna2Panel1.Controls.Add(this.btn2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(361, 133);
            this.guna2Panel1.TabIndex = 58;
            // 
            // OptionConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(361, 133);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionConfirmation_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionConfirmation_KeyDown);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Button btn2;
        public Guna.UI2.WinForms.Guna2Button btn1;
        private System.Windows.Forms.Label lblMessage;
        private Guna.UI.WinForms.GunaControlBox btnCLose;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}