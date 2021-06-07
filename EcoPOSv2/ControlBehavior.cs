using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    static class ControlBehavior
    {
        public enum Behavior
        {
            CloseOnOutOfBounds = 1,
            ClearSearch = 2,
            CheckText = 3,
            RequireField = 4
        }


        public static void SetBehavior(ref Control Ctrl, Behavior Behavior)
        {
            switch (Behavior)
            {
                case Behavior.CloseOnOutOfBounds:
                    {
                        Form form = Ctrl as Form;
                        form.Deactivate += CloseOnOutOfBounds;
                        break;
                    }

                case Behavior.ClearSearch:
                    {
                        TextBox textbox = Ctrl as TextBox;
                        textbox.Click += ClearSearch;
                        break;
                    }
            }
        }

        public static void CloseOnOutOfBounds(object sender, System.EventArgs e)
        {
            Form form = sender as Form;
            form.Close();
        }

        public static void ClearSearch(object sender, System.EventArgs e)
        {
            TextBox textbox = sender as TextBox;

            if (textbox.ForeColor == Color.DimGray)
            {
                textbox.Clear();
                textbox.ForeColor = Color.Black;
            }

            textbox.Leave += BringBackHint;
        }

        public static void BringBackHint(object sender, System.EventArgs e)
        {
            TextBox textbox = sender as TextBox;

            if (textbox.Text == "")
            {
                textbox.ForeColor = Color.DimGray;
                textbox.Text = textbox.Tag.ToString();
            }
        }


        public static int RequireField(ref List<TextBox> list)
        {
            int textbox_not_empty = 0;
            int result = 0;
            foreach (TextBox field in list)
            {
                if (field.Text != "")
                    textbox_not_empty = textbox_not_empty + 1;
            }

            if (textbox_not_empty == list.Count)
                result = 1;

            return result;

            list = new List<TextBox>();
        }
    }

}
