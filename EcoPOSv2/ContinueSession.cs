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
    public partial class ContinueSession : Form
    {
        public ContinueSession()
        {
            InitializeComponent();
        }

        private void ContinueSession_Load(object sender, EventArgs e)
        {

        }

        private void ContinueSession_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
