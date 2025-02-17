﻿using Microsoft.Win32;
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
            const string appName = "EcoPOSv3";
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
                }
            }
            else
            {
                //DISABLE DAPAT TO KAPAG TRIAL

                RegistryKey myKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Electronics\\EcoPOS", true);

                if (myKey == null)
                {
                    MessageBox.Show("Copying this to another PC is illegal and falls under Piracy. If you want to avail another POS, please directly contact WNO", "Piracy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (myKey.GetValue("EcoPOS").ToString() != new Helper().Decrypt("CD7MY63RkDVQJfI8epabkw=="))
                {
                    MessageBox.Show("Copying this to another PC is illegal and falls under Piracy. If you want to avail another POS, please directly contact WNO", "Piracy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //if(Properties.Settings.Default.Trial == "")
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new TrialAuth());
            //}
            //else if(Properties.Settings.Default.Trial == "Active")
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new SplashScreen());
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }
    }
}
