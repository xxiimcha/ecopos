using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

namespace EcoPOSv2
{
    class TextBoxValidation
    {
        public enum ValidationType
        {
            Only_Numbers = 1, // 1234567890.
            Only_Characters = 2, // deny input 1234567890!@#$%^&*()_+=-
            Not_Null = 3, // cannot be blank
            Only_Email = 4, // must have @
            Phone_Number = 5, // 1234567890.()-+ 
            SetText_Null = 6, // set to 0 if blank
            Number_Negative = 7, // 1234567890.-
            Barcode_Only = 8, // 1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ
            Text_Warn = 9, // change textbox border to red if left blank
            Int_Only = 10, // 1234567890
            Username = 11, // deny input ?!@#$%^&*()_+=-<>.,/\{}:;'""
            NumberDash = 12, // 1234567890-
            Price = 13
        }

        public static void AssignValidation(ref TextBox CTRL, ValidationType Validation_Type)
        {
            var txt = CTRL;
            switch (Validation_Type)
            {
                case ValidationType.Only_Numbers:
                    {
                        txt.KeyPress += number_Leave;
                        break;
                    }

                case ValidationType.Only_Characters:
                    {
                        txt.KeyPress += OCHAR_Leave;
                        break;
                    }

                case ValidationType.Not_Null:
                    {
                        txt.Leave += NotNull_Leave;
                        break;
                    }

                case ValidationType.Only_Email:
                    {
                        txt.Leave += Email_Leave;
                        break;
                    }

                case ValidationType.Phone_Number:
                    {
                        txt.KeyPress += Phonenumber_Leave;
                        break;
                    }

                case ValidationType.SetText_Null:
                    {
                        txt.Leave += SetTextToNull_Leave;
                        break;
                    }

                case ValidationType.Number_Negative:
                    {
                        txt.KeyPress += numberNegative_Leave;
                        break;
                    }

                case ValidationType.Barcode_Only:
                    {
                        txt.KeyPress += barcode_Only;
                        break;
                    }

                case ValidationType.Text_Warn:
                    {
                        txt.TextChanged += Text_Change;
                        break;
                    }

                case ValidationType.Int_Only:
                    {
                        txt.KeyPress += Int_Only;
                        break;
                    }

                case ValidationType.Username:
                    {
                        txt.KeyPress += Username;
                        break;
                    }

                case ValidationType.NumberDash:
                    {
                        txt.KeyPress += numberdash;
                        break;
                    }

                case ValidationType.Price:
                    {
                        txt.TextChanged += Price;
                        break;
                    }
            }
        }

        #region definitions

        public static void number_Leave(object sender, KeyPressEventArgs e)
        {
            TextBox numbers = sender as TextBox;
            if ((Strings.InStr("1234567890.", e.KeyChar.ToString()) == 0 & Strings.Asc(e.KeyChar) != 8) | e.KeyChar == '.' & Strings.InStr(numbers.Text, ".") > 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        public static void Price(object sender, EventArgs e)
        {
            TextBox numbers = sender as TextBox;
            if (((TextBox)sender).Text.Contains("."))
            {
                string s = Conversions.ToString(sender);
                int i = Strings.InStr(s, "."); // //Find Position of decimal place
                if (i + 2 <= s.Length) // //If try to write more than 2 decimal places then truncate it.
                {
                    numbers.Text = s.Substring(0, i + 2);
                    numbers.SelectionStart = numbers.Text.Length;
                }
            }
        }

        public static void numberdash(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox numbers = sender as TextBox;
            if (Strings.InStr("1234567890-", e.KeyChar.ToString()) == 0 & Strings.Asc(e.KeyChar) != 8 | e.KeyChar == '.' & Strings.InStr(numbers.Text, ".") > 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        public static void barcode_Only(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox numbers = sender as TextBox;
            if (Strings.InStr("1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ", e.KeyChar.ToString()) == 0 & Strings.Asc(e.KeyChar) != 8 | e.KeyChar == '.' & Strings.InStr(numbers.Text, ".") > 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        public static void numberNegative_Leave(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox numbers = sender as TextBox;
            if (Strings.InStr("1234567890.-", e.KeyChar.ToString()) == 0 & Strings.Asc(e.KeyChar) != 8 | e.KeyChar == '.' & Strings.InStr(numbers.Text, ".") > 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        public static void Phonenumber_Leave(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox numbers = sender as TextBox;
            if (Strings.InStr("1234567890.()-+ ", e.KeyChar.ToString()) == 0 & Strings.Asc(e.KeyChar) != 8 | e.KeyChar == '.' & Strings.InStr(numbers.Text, ".") > 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        public static void OCHAR_Leave(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Strings.InStr("1234567890!@#$%^&*()_+=-", e.KeyChar.ToString()) > 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        public static void Username(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Strings.InStr(@"?!@#$%^&*()_+=-<>.,/\{}:;'""", e.KeyChar.ToString()) > 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        public static void NotNull_Leave(object sender, EventArgs e)
        {
            TextBox No = sender as TextBox;
            if (No.Text.Trim() == "")
            {
                MessageBox.Show("Cannot be blank");
                No.Focus();
            }
        }

        public static void SetTextToNull_Leave(object sender, EventArgs e)
        {
            TextBox No = sender as TextBox;
            if (No.Text.Trim() == "")
            {
                No.Text = "0";
            }
        }

        public static void Email_Leave(object sender, EventArgs e)
        {
            TextBox Email = sender as TextBox;
            if (Email.Text != "")
            {
                var rex = Regex.Match(Strings.Trim(Email.Text), @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,3})$", RegexOptions.IgnoreCase);
                if (rex.Success == false)
                {
                    // MessageBox.Show("Please Enter a valid Email Address", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Email.BackColor = Color.Red;
                    // Email.Focus()
                    return;
                }
                else
                {
                    Email.BackColor = Color.White;
                }
            }
        }

        public static void Text_Change(object sender, EventArgs e)
        {
            TextBox No = sender as TextBox;
            if (No.Text.Trim() == "")
            {
                No.BackColor = Color.Red;
            }
            else
            {
                No.BackColor = Color.White;
            }
        }

        public static void Int_Only(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox numbers = sender as TextBox;
            if (Strings.InStr("1234567890", e.KeyChar.ToString()) == 0 & Strings.Asc(e.KeyChar) != 8 | e.KeyChar == '.' & Strings.InStr(numbers.Text, ".") > 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        #endregion
    }
}
