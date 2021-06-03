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
    public partial class Prompt : Form
    {
        public Prompt()
        {
            InitializeComponent();
        }
        Helper Helper = new Helper();

        DataSet ds = new DataSet();
        bool userfound = false;
        bool runOnlyOnce = false;
        int validation_type = 0;
        private void btnProceed_Click(object sender, EventArgs e)
        {

        }
    }
}
