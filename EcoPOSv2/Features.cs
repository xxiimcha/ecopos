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
    public partial class Features : Form
    {
        public Features()
        {
            InitializeComponent();
        }

        private void checkBoxCardLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCardLogin.Checked)
            {
                Properties.Settings.Default.cardlogin = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.cardlogin = false;
                Properties.Settings.Default.Save();
            }
        }

        private void Features_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cardlogin == true)
            {
                checkBoxCardLogin.Checked = true;
            }
            else
            {
                checkBoxCardLogin.Checked = false;
            }


            if (Properties.Settings.Default.priceeditor == true)
            {
                checkBoxPriceEditor.Checked = true;
            }
            else
            {
                checkBoxPriceEditor.Checked = false;
            }

            if (Properties.Settings.Default.servertype == true)
            {
                checkBoxServerType.Checked = true;
            }
            else
            {
                checkBoxServerType.Checked = false;
            }
        }

        private void checkBoxServerType_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxServerType.Checked)
            {
                Properties.Settings.Default.servertype = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.servertype = false;
                Properties.Settings.Default.Save();
            }
        }

        private void CheckBoxPriceEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPriceEditor.Checked)
            {
                Properties.Settings.Default.priceeditor = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.priceeditor = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
