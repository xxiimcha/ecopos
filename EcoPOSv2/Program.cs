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

                //APPLICATION EXIT
                Process[] runningProcesses = Process.GetProcesses();
                foreach (Process process in runningProcesses)
                {
                    // now check the modules of the process
                    foreach (ProcessModule module in process.Modules)
                    {
                        if (module.FileName.Equals("EcoPOSv2.exe"))
                        {
                            process.Kill();
                        }
                        else return;
                    }
                }
                //APPLICATION EXIT

                return;
            }
            else
            {
                RegistryKey myKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Electronics\\EcoPOS", true);

                if(myKey == null)
                {
                    MessageBox.Show("Wag mo na icopy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (myKey.GetValue("EcoPOS").ToString() != "102618")
                {
                    MessageBox.Show("Wag mo na icopy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SplashScreen());
            }
        }
    }
}
