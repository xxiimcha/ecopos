
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
            this.btn2 = new Guna.UI2.WinForms.Guna2Button();
            this.btn1 = new Guna.UI2.WinForms.Guna2Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnCLose = new Guna.UI.WinForms.GunaControlBox();
            this.SuspendLayout();
            // 
            // btn2
            // 
            this.btn2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn2.BorderColor = System.Drawing.Color.Red;
            this.btn2.BorderThickness = 2;
            this.btn2.CheckedState.Parent = this.btn2;
            this.btn2.CustomImages.Parent = this.btn2;
            this.btn2.FillColor = System.Drawing.Color.White;
            this.btn2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.ForeColor = System.Drawing.Color.Red;
            this.btn2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn2.HoverState.Parent = this.btn2;
            this.btn2.Location = new System.Drawing.Point(188, 56);
            this.btn2.Name = "btn2";
            this.btn2.ShadowDecoration.Parent = this.btn2;
            this.btn2.Size = new System.Drawing.Size(161, 50);
            this.btn2.TabIndex = 47;
            this.btn2.Text = "DELETE";
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn1.BorderThickness = 2;
            this.btn1.CheckedState.Parent = this.btn1;
            this.btn1.CustomImages.Parent = this.btn1;
            this.btn1.FillColor = System.Drawing.Color.White;
            this.btn1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn1.HoverState.Parent = this.btn1;
            this.btn1.Location = new System.Drawing.Point(12, 56);
            this.btn1.Name = "btn1";
            this.btn1.ShadowDecoration.Parent = this.btn1;
            this.btn1.Size = new System.Drawing.Size(161, 50);
            this.btn1.TabIndex = 48;
            this.btn1.Text = "Button1";
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(190, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(18, 25);
            this.lblMessage.TabIndex = 49;
            this.lblMessage.Text = ".";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCLose
            // 
            this.btnCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCLose.AnimationHoverSpeed = 0.07F;
            this.btnCLose.AnimationSpeed = 0.03F;
            this.btnCLose.IconColor = System.Drawing.Color.Black;
            this.btnCLose.IconSize = 15F;
            this.btnCLose.Location = new System.Drawing.Point(328, 1);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCLose.OnHoverIconColor = System.Drawing.Color.White;
            this.btnCLose.OnPressedColor = System.Drawing.Color.Black;
            this.btnCLose.Size = new System.Drawing.Size(33, 33);
            this.btnCLose.TabIndex = 57;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // OptionConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 139);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionConfirmation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Button btn2;
        public Guna.UI2.WinForms.Guna2Button btn1;
        private System.Windows.Forms.Label lblMessage;
        private Guna.UI.WinForms.GunaControlBox btnCLose;
    }
}