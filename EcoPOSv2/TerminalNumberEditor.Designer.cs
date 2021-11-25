namespace EcoPOSv2
{
    partial class TerminalNumberEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminalNumberEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.tbTerminalID = new System.Windows.Forms.TextBox();
            this.tbTerminalNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMachineNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Terminal ID:";
            // 
            // tbTerminalID
            // 
            this.tbTerminalID.Location = new System.Drawing.Point(183, 33);
            this.tbTerminalID.Name = "tbTerminalID";
            this.tbTerminalID.Size = new System.Drawing.Size(265, 29);
            this.tbTerminalID.TabIndex = 1;
            // 
            // tbTerminalNumber
            // 
            this.tbTerminalNumber.Location = new System.Drawing.Point(183, 68);
            this.tbTerminalNumber.Name = "tbTerminalNumber";
            this.tbTerminalNumber.Size = new System.Drawing.Size(265, 29);
            this.tbTerminalNumber.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Terminal Number:";
            // 
            // tbMachineNumber
            // 
            this.tbMachineNumber.Location = new System.Drawing.Point(183, 103);
            this.tbMachineNumber.Name = "tbMachineNumber";
            this.tbMachineNumber.Size = new System.Drawing.Size(265, 29);
            this.tbMachineNumber.TabIndex = 5;
            this.tbMachineNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbMachineNumber_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "MachineNumber:";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(317, 138);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(131, 47);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // TerminalNumberEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(488, 202);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.tbMachineNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTerminalNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTerminalID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TerminalNumberEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TerminalNumberEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTerminalID;
        private System.Windows.Forms.TextBox tbTerminalNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMachineNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChange;
    }
}