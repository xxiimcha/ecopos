using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class GroupAction
    {
        public enum ControlType
        {
            TextBox = 1,
            RadioButton = 2,
            CheckBox = 3
        }

        public enum Action
        {
            Clear = 1,
            Enable = 2,
            Disable = 3,
            Check = 4,
            Uncheck = 5
        }

        public static List<Control> FindControlRecursive(List<Control> list, Control parent, Type ctrlType)
        {
            if (parent is null)
                return list;
            if (object.ReferenceEquals(parent.GetType(), ctrlType))
            {
                list.Add(parent);
            }

            foreach (Control child in parent.Controls)
                FindControlRecursive(list, child, ctrlType);
            return list;
        }

        public void DoThis(ref List<Control> list, Control parent, ControlType ControlType, Action Action)
        {
            switch (ControlType)
            {
                case ControlType.TextBox:
                    {
                        foreach (TextBox txt in FindControlRecursive(list, parent, typeof(TextBox)))
                        {
                            switch (Action)
                            {
                                case Action.Clear:
                                    {
                                        txt.Clear();
                                        break;
                                    }

                                case Action.Enable:
                                    {
                                        txt.Enabled = true;
                                        break;
                                    }

                                case Action.Disable:
                                    {
                                        txt.Enabled = false;
                                        break;
                                    }

                                default:
                                    {
                                        MessageBox.Show("No action");
                                        break;
                                    }
                            }
                        }

                        break;
                    }

                case ControlType.CheckBox:
                    {
                        foreach (CheckBox cbx in FindControlRecursive(list, parent, typeof(CheckBox)))
                        {
                            switch (Action)
                            {
                                case Action.Check:
                                    {
                                        cbx.Checked = true;
                                        break;
                                    }

                                case Action.Uncheck:
                                    {
                                        cbx.Checked = false;
                                        break;
                                    }

                                case Action.Enable:
                                    {
                                        cbx.Enabled = true;
                                        break;
                                    }

                                case Action.Disable:
                                    {
                                        cbx.Enabled = false;
                                        break;
                                    }

                                default:
                                    {
                                        MessageBox.Show("No action");
                                        break;
                                    }
                            }
                        }

                        break;
                    }

                case ControlType.RadioButton:
                    {
                        foreach (RadioButton rb in FindControlRecursive(list, parent, typeof(RadioButton)))
                        {
                            switch (Action)
                            {
                                case Action.Check:
                                    {
                                        rb.Checked = true;
                                        break;
                                    }

                                case Action.Uncheck:
                                    {
                                        rb.Checked = false;
                                        break;
                                    }

                                case Action.Enable:
                                    {
                                        rb.Enabled = true;
                                        break;
                                    }

                                case Action.Disable:
                                    {
                                        rb.Enabled = false;
                                        break;
                                    }

                                default:
                                    {
                                        MessageBox.Show("No action");
                                        break;
                                    }
                            }
                        }

                        break;
                    }
            }

            list = new List<Control>();
        }
    }
}
