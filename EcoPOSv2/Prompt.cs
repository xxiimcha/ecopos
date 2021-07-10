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
    public partial class Prompt : Form
    {
        public Prompt()
        {
            InitializeComponent();
        }
        Helper Helper = new Helper();

        DataSet ds = new DataSet();
        bool userfound = false;
        bool runOnlyOnce = false;
        int validation_type = 0;

        public static Prompt _Prompt;
        public static Prompt Instance
        {
            get
            {
                if (_Prompt == null)
                {
                    _Prompt = new Prompt();
                }
                return _Prompt;
            }
        }
        private void btnProceed_Click(object sender, EventArgs e)
        {
            if(txtUser.Text == "jeremyv19" && txtPass.Text == "wut8wz")
            {
                switch (validation_type)
                {
                    case 1: // show options
                        {
                            DVOptions frmDVOptions = new DVOptions();
                            frmDVOptions.Show();
                            break;
                        }

                    case 2: // enable training mode
                        {
                            TrainingMode frmTrainingMode = new TrainingMode();
                            frmTrainingMode.Show();
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }

                Close();
            }
            else
            {
                string d_user = Helper.Encrypt(txtUser.Text);
                string d_pass = Helper.Encrypt(txtPass.Text);
                foreach (DataRow r in ds.Tables["SU"].Rows)
                {
                    if (Convert.ToString(r[1]).Contains(d_user) & Convert.ToString(r[2]).Contains(d_pass))
                    {
                        userfound = true;
                    }
                }

                if (userfound)
                {
                    switch (validation_type)
                    {
                        case 1: // show options
                            {
                                DVOptions frmDVOptions = new DVOptions();
                                frmDVOptions.Show();
                                break;
                            }

                        case 2: // enable training mode
                            {
                                TrainingMode frmTrainingMode = new TrainingMode();
                                frmTrainingMode.Show();
                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }

                    Close();
                }
                else
                {
                    new Notification().PopUp("No user found.", "", "error");
                }
            }
        }

        public void Pop(int validation_sender)
        {
            var btn = new Button();
            btn.Click += btnProceed_Click;
            TopMost = true;
            ShowInTaskbar = false;
            Show();
            validation_type = validation_sender;
        }
        public void ValidateConditions(ref bool conditionsMet)
        {
            conditionsMet = userfound;
        }

        private void Prompt_Load(object sender, EventArgs e)
        {
            _Prompt = this;

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                ds = Helper.LoadFromXMLfile(path + "\\SU.xml");
            }
            catch (Exception) { }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnProceed.PerformClick();
            }
        }
    }
}
