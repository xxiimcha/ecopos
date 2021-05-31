using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECOPOSSQLControl;

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

            //HULI TO LAGI
            CountDownTimer.Start();
        }

        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            seconds--;

            if (seconds == 0)
            {
                CountDownTimer.Stop();
                
                //DECLARE LOGIN FORM
            }
        }
    }
}
