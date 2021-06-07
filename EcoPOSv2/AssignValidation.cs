using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Guna.UI2.WinForms.Suite;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EcoPOSv2TextValidation
{
    public sealed class Strings { }
    class TextBoxValidation
    {

        [ComVisible(true)]
        public enum ValidationType
        {
            NumbersOnly = 1,
            CharactersOnly = 2,
            Decimal = 3,
            NumberDash = 4,
            NotNull = 5
        }
        public void AssignValidationTB(System.Windows.Forms.TextBox CTRL, ValidationType Validation_Type)
        {
            System.Windows.Forms.TextBox txt = CTRL;
            switch (Validation_Type)
            {
                case ValidationType.NumbersOnly:
                    txt.KeyPress += NumbersOnly;
                    break;
                case ValidationType.CharactersOnly:
                    txt.KeyPress += CharactersOnly;
                    break;
                case ValidationType.Decimal:
                    txt.KeyPress += Decimals;
                    break;
                case ValidationType.NumberDash:
                    txt.KeyPress += NumberDash;
                    break;
                case ValidationType.NotNull:
                    txt.Leave += NotNull;
                    break;
                default:
                    break;
            }
        }
        public void AssignValidation(Guna.UI2.WinForms.Guna2TextBox CTRL, ValidationType Validation_Type)
        {
            Guna.UI2.WinForms.Guna2TextBox txt = CTRL;
            switch (Validation_Type)
            {
                case ValidationType.NumbersOnly:
                    txt.KeyPress += NumbersOnly;
                    break;
                case ValidationType.CharactersOnly:
                    txt.KeyPress += CharactersOnly;
                    break;
                case ValidationType.Decimal:
                    txt.KeyPress += Decimals;
                    break;
                case ValidationType.NumberDash:
                    txt.KeyPress += NumberDash;
                    break;
                case ValidationType.NotNull:
                    txt.Leave += NotNull;
                    break;
                default:
                    break;
            }
        }

        public void NumbersOnly(object sender, KeyPressEventArgs e)
        {
            string userInput;
            userInput = e.KeyChar.ToString();
            System.Windows.Forms.TextBox numbers = (System.Windows.Forms.TextBox)sender;

            if (Microsoft.VisualBasic.Strings.InStr("1234567890", userInput) == 0 && Microsoft.VisualBasic.Strings.Asc(userInput) != 8 || userInput == "." && Microsoft.VisualBasic.Strings.InStr(numbers.Text, ".") > 0)
            {
                e.KeyChar = Microsoft.VisualBasic.Strings.Chr(0);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public void CharactersOnly(object sender, KeyPressEventArgs e)
        {
            string userInput;
            userInput = e.KeyChar.ToString();
            Guna.UI2.WinForms.Guna2TextBox numbers = (Guna.UI2.WinForms.Guna2TextBox)sender;

            if (Microsoft.VisualBasic.Strings.InStr("1234567890!@#$%^&*()_+=-", userInput) > 0)
            {
                e.KeyChar = Microsoft.VisualBasic.Strings.Chr(0);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public void Decimals(object sender, KeyPressEventArgs e)
        {
            string userInput;
            userInput = e.KeyChar.ToString();
            Guna.UI2.WinForms.Guna2TextBox numbers = (Guna.UI2.WinForms.Guna2TextBox)sender;

            if (Microsoft.VisualBasic.Strings.InStr("1234567890.", userInput) == 0 && Microsoft.VisualBasic.Strings.Asc(userInput) != 8 || userInput == "." && Microsoft.VisualBasic.Strings.InStr(numbers.Text, ".") > 0)
            {
                e.KeyChar = Microsoft.VisualBasic.Strings.Chr(0);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public void NumberDash(object sender, KeyPressEventArgs e)
        {
            string userInput;
            userInput = e.KeyChar.ToString();
            Guna.UI2.WinForms.Guna2TextBox numbers = (Guna.UI2.WinForms.Guna2TextBox)sender;

            if (Microsoft.VisualBasic.Strings.InStr("1234567890-", userInput) == 0 && Microsoft.VisualBasic.Strings.Asc(userInput) != 8 || userInput == "." && Microsoft.VisualBasic.Strings.InStr(numbers.Text, ".") > 0)
            {
                e.KeyChar = Microsoft.VisualBasic.Strings.Chr(0);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public void NotNull(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox userInput = (System.Windows.Forms.TextBox)sender;

            if (userInput.Text.Trim() == "")
            {
                MessageBox.Show("Cannot be blank","Error");
                userInput.BackColor = System.Drawing.Color.FromArgb(227, 30, 36);
            }
            else
                userInput.BackColor = System.Drawing.Color.Transparent;
        }
    }
}