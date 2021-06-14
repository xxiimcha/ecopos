using EcoPOSv2.Properties;
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
    public partial class TrainingMode : Form
    {
        public TrainingMode()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Main.Instance.dynamicDB = "EcoPOS_Training";
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Main.Instance.dynamicDB = "EcoPOS";
        }
    }
}
