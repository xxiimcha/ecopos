using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class Notification : Form
    {
        int counter = 0;
        int time = 2;

        public Notification()
        {
            InitializeComponent();
        }

        public Notification(int time)
        {
            InitializeComponent();
            time = time;
        }

        
        public static Notification _Notification;
        //METHODS
        public static Notification Instance
        {
            get
            {
                if (_Notification == null)
                {
                    _Notification = new Notification();
                }
                return _Notification;
            }
        }

        public void PopUp(string text = "", string title = "", string type = "")
        {
            if(type == "success")
            {
                tbllayout.BackColor = Color.FromArgb(48, 96, 25);
                lblText.BackColor = Color.FromArgb(48, 96, 25);
                lblTitle.BackColor = Color.FromArgb(48, 96, 25);
                this.BackColor = Color.FromArgb(48, 96, 25);
            }
            else if(type == "error")
            {
                tbllayout.BackColor = Color.FromArgb(244, 67, 54);
                lblTitle.BackColor = Color.FromArgb(244, 67, 54);
                lblText.BackColor = Color.FromArgb(244, 67, 54);
                this.BackColor = Color.FromArgb(244, 67, 54);
            }
            else if(type == "information")
            {
                tbllayout.BackColor = Color.FromArgb(0, 90, 156);
                lblTitle.BackColor = Color.FromArgb(0, 90, 156);
                lblText.BackColor = Color.FromArgb(0, 90, 156);
                this.BackColor = Color.FromArgb(0, 90, 156);
            }
            else if (type == "warning")
            {
                tbllayout.BackColor = Color.FromArgb(255, 121, 0);
                lblTitle.BackColor = Color.FromArgb(255, 121, 0);
                lblText.BackColor = Color.FromArgb(255, 121, 0);
                this.BackColor = Color.FromArgb(255, 121, 0);
            }

            TopMost = true;
            ShowInTaskbar = false;
            Location = new Point((int)((Screen.PrimaryScreen.WorkingArea.Width / (double)2) - 125), Screen.PrimaryScreen.WorkingArea.Height - 100);

            this.Show();

            lblTitle.Text = title;
            lblText.Text = text;

            tmr_open.Start();
        }
        //METHODS
        private void tmr_open_Tick(object sender, EventArgs e)
        {
            counter++;

            if (counter == time)
            {
                Close();
            }
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            _Notification = this;
        }

        private void Notification_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
