using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoPOSControl;

namespace EcoPOSv2
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        //DECLARING AREA
        public static SplashScreen _splashScreen;
        SQLControl sql = new SQLControl();
        int seconds = 0;



        //DECLARING AREA
        public static SplashScreen Instance
        {
            get
            {
                if (_splashScreen == null)
                {
                    _splashScreen = new SplashScreen();
                }
                return _splashScreen;
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            _splashScreen = this;
            seconds = 3;

            //DATABASE CONNECTION CHECKER
            sql.Query("select * from users");

            if(sql.HasException())
            {

            }
            else
            {
                //DITO LAHAT NG ADDIONAL FUNCTION



                //HULI TO LAGI
                CountDownTimer.Start();
            }
        }

        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            seconds--;

            if (seconds == 0)
            {
                CountDownTimer.Stop();

                Login l = new Login();
                l.Show();

                this.Hide();
                //DECLARE LOGIN FORM
            }
        }
    }
}
