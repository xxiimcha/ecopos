
namespace EcoPOSv2
{
    partial class Notification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notification));
            this.lblText = new System.Windows.Forms.Label();
            this.tmr_open = new System.Windows.Forms.Timer(this.components);
            this.tbllayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbllayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.Black;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(3, 27);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(255, 68);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Label2";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmr_open
            // 
            this.tmr_open.Interval = 1000;
            this.tmr_open.Tick += new System.EventHandler(this.tmr_open_Tick);
            // 
            // tbllayout
            // 
            this.tbllayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tbllayout.ColumnCount = 1;
            this.tbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbllayout.Controls.Add(this.lblTitle, 0, 0);
            this.tbllayout.Controls.Add(this.lblText, 0, 1);
            this.tbllayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbllayout.Location = new System.Drawing.Point(0, 0);
            this.tbllayout.Name = "tbllayout";
            this.tbllayout.RowCount = 2;
            this.tbllayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.75F));
            this.tbllayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.25F));
            this.tbllayout.Size = new System.Drawing.Size(261, 95);
            this.tbllayout.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Label1";
            // 
            // Notification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(261, 95);
            this.Controls.Add(this.tbllayout);
            this.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Notification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notification";
            this.Load += new System.EventHandler(this.Notification_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Notification_KeyDown);
            this.tbllayout.ResumeLayout(false);
            this.tbllayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Timer tmr_open;
        internal System.Windows.Forms.TableLayoutPanel tbllayout;
        public System.Windows.Forms.Label lblText;
        public System.Windows.Forms.Label lblTitle;
    }
}