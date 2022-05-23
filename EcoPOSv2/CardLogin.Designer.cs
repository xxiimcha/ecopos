
namespace EcoPOSv2
{
    partial class CardLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardLogin));
            this.lblTapCard = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbCardNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTapCard
            // 
            this.lblTapCard.AutoSize = true;
            this.lblTapCard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTapCard.Location = new System.Drawing.Point(23, 18);
            this.lblTapCard.Name = "lblTapCard";
            this.lblTapCard.Size = new System.Drawing.Size(498, 21);
            this.lblTapCard.TabIndex = 1;
            this.lblTapCard.Text = "P    L    E    S    E            T    A    P            Y    O    U    R         " +
    "   C    A    R    D";
            this.lblTapCard.Click += new System.EventHandler(this.lblTapCard_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // tbCardNo
            // 
            this.tbCardNo.Location = new System.Drawing.Point(16, 70);
            this.tbCardNo.Name = "tbCardNo";
            this.tbCardNo.Size = new System.Drawing.Size(507, 20);
            this.tbCardNo.TabIndex = 2;
            this.tbCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCardNo_KeyDown);
            // 
            // CardLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 55);
            this.Controls.Add(this.tbCardNo);
            this.Controls.Add(this.lblTapCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CardLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CardLogin_FormClosed);
            this.Load += new System.EventHandler(this.CardLogin_Load);
            this.Click += new System.EventHandler(this.CardLogin_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTapCard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbCardNo;
    }
}