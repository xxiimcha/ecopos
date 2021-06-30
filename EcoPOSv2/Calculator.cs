﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeryHotKeys.WinForms;
using static EcoPOSv2.TextBoxValidation;

namespace EcoPOSv2
{
    public partial class Calculator : GlobalHotKeyForm
    {
        public static Calculator _Calculator;
        public static Calculator Instance
        {
            get
            {
                if (_Calculator == null)
                {
                    _Calculator = new Calculator();
                }
                return _Calculator;
            }
        }
        public Calculator()
        {
            InitializeComponent();
            AddHotKeyRegisterer(Button0, HotKeyMods.None, ConsoleKey.D0);
            AddHotKeyRegisterer(Button1, HotKeyMods.None, ConsoleKey.D1);
            AddHotKeyRegisterer(Button2, HotKeyMods.None, ConsoleKey.D2);
            AddHotKeyRegisterer(Button3, HotKeyMods.None, ConsoleKey.D3);
            AddHotKeyRegisterer(Button4, HotKeyMods.None, ConsoleKey.D4);
            AddHotKeyRegisterer(Button5, HotKeyMods.None, ConsoleKey.D5);
            AddHotKeyRegisterer(Button6, HotKeyMods.None, ConsoleKey.D6);
            AddHotKeyRegisterer(Button7, HotKeyMods.None, ConsoleKey.D7);
            AddHotKeyRegisterer(Button8, HotKeyMods.None, ConsoleKey.D8);
            AddHotKeyRegisterer(Button9, HotKeyMods.None, ConsoleKey.D9);


            //OPERANDS
            AddHotKeyRegisterer(Divide, HotKeyMods.None, ConsoleKey.Divide);
            AddHotKeyRegisterer(Multiply, HotKeyMods.None, ConsoleKey.Multiply);
            AddHotKeyRegisterer(Add, HotKeyMods.None, ConsoleKey.Add);
            AddHotKeyRegisterer(Subtract, HotKeyMods.None, ConsoleKey.Subtract);
            AddHotKeyRegisterer(Enter, HotKeyMods.None, ConsoleKey.Enter);

            //HOTKEYS
            AddHotKeyRegisterer(Reset, HotKeyMods.None, ConsoleKey.C);
            AddHotKeyRegisterer(Escape, HotKeyMods.None, ConsoleKey.Escape);
        }

        private void Escape(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reset(object sender, EventArgs e)
        {
            btnClear.PerformClick();
        }

        //OPERANDS
        private void Divide(object sender, EventArgs e)
        {
            btnDivide.PerformClick();
        }
        private void Multiply(object sender, EventArgs e)
        {
            btnMultiply.PerformClick();
        }
        private void Add(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }
        private void Subtract(object sender, EventArgs e)
        {
            btnSubtract.PerformClick();
        }
        private void Enter(object sender, EventArgs e)
        {
            btnEqual.PerformClick();
        }
        //OPERANDS
        private void Button0(object sender, EventArgs e)
        {
            btn0.PerformClick();
        }
        private void Button1(object sender, EventArgs e)
        {
            btn1.PerformClick();
        }
        private void Button2(object sender, EventArgs e)
        {
            btn2.PerformClick();
        }
        private void Button3(object sender, EventArgs e)
        {
            btn3.PerformClick();
        }
        private void Button4(object sender, EventArgs e)
        {
            btn4.PerformClick();
        }
        private void Button5(object sender, EventArgs e)
        {
            btn5.PerformClick();
        }
        private void Button6(object sender, EventArgs e)
        {
            btn6.PerformClick();
        }
        private void Button7(object sender, EventArgs e)
        {
            btn7.PerformClick();
        }
        private void Button8(object sender, EventArgs e)
        {
            btn8.PerformClick();
        }
        private void Button9(object sender, EventArgs e)
        {
            btn9.PerformClick();
        }


        // variables to hold operands
        private double valHolder1;
        private double valHolder2;
        // Varible to hold temporary values
        private double tmpValue;
        // variable for Memory storage
        private double Memory;
        // True if "." is use else false
        private bool hasDecimal;
        private bool inputStatus;
        private bool clearText;
        // variable to hold Operater
        private string calcFunc;


        //METHODS
        private void CalculateTotals()
        {
            valHolder2 = System.Convert.ToDouble(txtInput.Text);
            switch (calcFunc)
            {
                case "Add":
                    {
                        valHolder1 = valHolder1 + valHolder2;
                        break;
                    }

                case "Subtract":
                    {
                        valHolder1 = valHolder1 - valHolder2;
                        break;
                    }

                case "Divide":
                    {
                        valHolder1 = valHolder1 / valHolder2;
                        break;
                    }

                case "Multiply":
                    {
                        valHolder1 = valHolder1 * valHolder2;
                        break;
                    }

                case "PowerOf":
                    {
                        valHolder1 = System.Math.Pow(valHolder1, valHolder2);
                        break;
                    }
            }
            txtInput.Text = System.Convert.ToString(valHolder1);
            inputStatus = true;
        }

        //METHODS
        private void Calculator_Load(object sender, EventArgs e)
        {
            _Calculator = this;

            AssignValidation(ref txtInput, ValidationType.Price);
            AssignValidation(ref txtInput, ValidationType.Int_Only);
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length > 11)
                return;

            if (inputStatus == false)
                txtInput.Text += (sender as Button).Text;
            else
            {
                txtInput.Text = (sender as Button).Text;
                inputStatus = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str;
            int loc;
            if (txtInput.Text.Length > 0)
            {
                str = txtInput.Text.Substring(txtInput.Text.Length - 1);
                if (str == ".")
                    hasDecimal = false;
                loc = txtInput.Text.Length;
                txtInput.Text = txtInput.Text.Remove(loc - 1, 1);
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtInput.Text = string.Empty;
            hasDecimal = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = string.Empty;
            valHolder1 = 0;
            valHolder2 = 0;
            calcFunc = string.Empty;
            hasDecimal = false;

            this.ActiveControl = txtInput;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                if (calcFunc == string.Empty)
                {
                    valHolder1 = System.Convert.ToDouble(txtInput.Text);
                    txtInput.Text = string.Empty;
                }
                else
                    CalculateTotals();

                calcFunc = "Divide";
                hasDecimal = false;
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                if (calcFunc == string.Empty)
                {
                    valHolder1 = System.Convert.ToDouble(txtInput.Text);
                    txtInput.Text = string.Empty;
                }
                else
                    CalculateTotals();

                calcFunc = "Multiply";
                hasDecimal = false;
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (calcFunc == string.Empty)
            {
                valHolder1 = Convert.ToDouble(txtInput.Text);
                txtInput.Text = string.Empty;
            }
            else
                CalculateTotals();

            calcFunc = "Subtract";
            hasDecimal = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            
            if (txtInput.Text.Length != 0 && valHolder1 != 0)
            {
                MessageBox.Show("equals");
                CalculateTotals();
                calcFunc = "";
                hasDecimal = false;
            }
            else
                MessageBox.Show("wala");
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            // Check for input status (we want flase)
            if (!inputStatus)
            {
                // Check if it already has a decimal (if it does then do nothing)
                if (!hasDecimal)
                {
                    // Check to make sure the length is > than 1
                    // Dont want user to add decimal as first character
                    if (txtInput.Text.Length > 0)
                    {
                        // Make sure 0 isnt the first number
                        if (txtInput.Text != "0")
                        {
                            // It met all our requirements so add the zero
                            txtInput.Text += btnDecimal.Text;
                            // Toggle the flag to true (only 1 decimal per calculation)
                            hasDecimal = true;
                        }
                    }
                    else
                    {
                        txtInput.Text = "0.";
                        hasDecimal = true;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                if (calcFunc == string.Empty)
                {
                    valHolder1 = System.Convert.ToDouble(txtInput.Text);
                    txtInput.Text = string.Empty;
                }
                else
                    CalculateTotals();

                calcFunc = "Add";
                hasDecimal = false;
            }
        }
    }
}
