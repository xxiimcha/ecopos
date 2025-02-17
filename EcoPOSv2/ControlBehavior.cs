﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace EcoPOSv2
{
    class ControlBehavior
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

        public static void CloseOnOutOfBounds(object sender, EventArgs e)
        {
            Form form = (sender as Form);
            form.Close();
        }

        public static void ClearSearch(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.ForeColor == Color.DimGray)
            {
                textbox.Clear();
                textbox.ForeColor = Color.Black;
            }

            textbox.Leave += BringBackHint;
        }

        public static void BringBackHint(object sender, EventArgs e)
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
                {
                    textbox_not_empty = textbox_not_empty + 1;
                }
            }

            if (textbox_not_empty == list.Count)
            {
                result = 1;
            }

            return result;
            list = new List<TextBox>();
        }

        public static int GunaRequireField(ref List<Guna2TextBox> list)
        {
            int textbox_not_empty = 0;
            int result = 0;
            foreach (Guna2TextBox field in list)
            {
                if (field.Text != "")
                {
                    textbox_not_empty = textbox_not_empty + 1;
                }
            }

            if (textbox_not_empty == list.Count)
            {
                result = 1;
            }

            return result;
            list = new List<Guna2TextBox>();
        }
    }
}
