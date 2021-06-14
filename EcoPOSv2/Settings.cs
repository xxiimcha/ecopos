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
    public partial class Settings : Form
    {
        private Panel currentPanel;
        private Button currentBtn;
        private FormLoad OL = new FormLoad();
        public Form currentChildForm;


        public Settings()
        {
            InitializeComponent();
        }

        private void BtnStore_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new Store(), ref currentChildForm, btnStore, ref currentBtn, ref pnlChild);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            currentBtn = btnStore;
            OL.changeFormWithButton(new Store(), ref currentChildForm, btnStore, ref currentBtn, ref pnlChild);
        }

        private void BtnStaff_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new Staff(), ref currentChildForm, btnStore, ref currentBtn, ref pnlChild);
        }

        private void BtnDeveloper_Click(object sender, EventArgs e)
        {
            OL.changeFormWithButton(new Developer(), ref currentChildForm, btnStore, ref currentBtn, ref pnlChild);
        }
    }
}
