﻿using System;
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
    public partial class Developer : Form
    {
        public Developer()
        {
            InitializeComponent();
        }

        private void btnTrainingMode_Click(object sender, EventArgs e)
        {
            Prompt frmPrompt = new Prompt();
            frmPrompt.Pop(2);
        }
    }
}
