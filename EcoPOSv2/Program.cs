using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Mutex mutex = null;
            const string appName = "EcoPOSv2";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //MessageBox.Show(appName + " is already running!","Already running",MessageBoxButtons.OK,MessageBoxIcon.Error);

                if (string.IsNullOrWhiteSpace(appName))
                {
                    Environment.Exit(1);
                }
                Process[] mainAppProcessOrProcessesRunning = Process.GetProcessesByName(appName);
                foreach (var p in mainAppProcessOrProcessesRunning)
                {
                    p.Kill();
                    // or p.close(); 
                    /*If you have permission issues then you have to capture each MainWindow using the proccess, focus that window, and do mainWindow.Exit(). 
                    This may require using system32 automation to mimic the user. You may also have to pull each Modal attached to the main window and close those before hand.*/

                }
                ////APPLICATION EXIT
                //Process[] runningProcesses = Process.GetProcesses();
                //foreach (Process process in runningProcesses)
                //{
                //    // now check the modules of the process
                //    foreach (ProcessModule module in process.Modules)
                //    {
                //        if (module.FileName.Equals("EcoPOSv2.exe"))
                //        {
                //            process.Kill();
                //        }
                //        else return;
                //    }
                //}
                ////APPLICATION EXIT
            }
            else
            {
                RegistryKey myKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Electronics\\EcoPOS", true);

                if(myKey == null)
                {
                    MessageBox.Show("Wag mo na icopy. Sa Ibang Computer ^_^", "Piracy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (myKey.GetValue("EcoPOS").ToString() != "102618")
                {
                    MessageBox.Show("Wag mo na icopy. Sa Ibang Computer ^_^", "Piracy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }
    }
}
