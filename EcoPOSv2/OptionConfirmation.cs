using EcoPOSControl;
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
    public partial class OptionConfirmation : Form
    {
        string message, buttonText1, buttonText2;
        SQLControl SQL = new SQLControl();

        private void btn1_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM keep WHERE note = '" + message + "'");
            if (SQL.HasException(true)) return;

            foreach (DataRow dr in SQL.DBDT.Rows)
            {
                
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SQL.Query("DELETE FROM keep WHERE note = '" + message + "'");
            if (SQL.HasException(true)) return;
            
            Close();
        }

        private void OptionConfirmation_Load(object sender, EventArgs e)
        {
            btn1.Text = buttonText1;
            btn2.Text = buttonText2;
        }

        public OptionConfirmation(string message, string buttonText1, string buttonText2)
        {
            InitializeComponent();
            this.message = message;
            this.buttonText1 = buttonText1;
            this.buttonText2 = buttonText2;
        }

       

    }
}
