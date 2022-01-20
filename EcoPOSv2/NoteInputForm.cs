using EcoPOSControl;
using System;
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
    public partial class NoteInputForm : Form
    {
        SQLControl SQL = new SQLControl();
        public NoteInputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtInputNote.Text.Equals(""))
            {
                List<KeepItem> itemToKeep = new List<KeepItem>();
                SQL.Query("SELECT * FROM order_cart where terminal_id = " + Properties.Settings.Default.Terminal_id);
                if (SQL.HasException(true)) return;
                string note = txtInputNote.Text;
                if (SQL.DBDT.Rows.Count != 0)
                {
                    foreach (DataRow dr in SQL.DBDT.Rows)
                    {
                        KeepItem keepItem = new KeepItem(int.Parse(dr["terminal_id"].ToString()), int.Parse(dr["productID"].ToString()), Convert.ToInt32(Convert.ToDouble(dr["quantity"].ToString())));
                        itemToKeep.Add(keepItem);
                    }

                    SQL.Query("SELECT * FROM keep WHERE note ='" + note + "'");
                    if (SQL.HasException(true)) return;
                    if (SQL.DBDT.Rows.Count == 0)
                    {
                        if (itemToKeep.Count > 0)
                        {
                            foreach (KeepItem item in itemToKeep)
                            {
                                SQL.Query("INSERT INTO keep (terminalID, productID, quantity, total, note, dateTime) VALUES (" + item.TerminalID + "," + item.ProductID + "," + item.Quantity + "," + Convert.ToDouble(Order.Instance.lblTotal.Text) + ",'" + note + "','" + DateTime.Now.ToString() + "')");
                                if (SQL.HasException(true)) return;
                            }
                        }
                        SQL.Query("DELETE FROM order_cart WHERE terminal_id = " + Properties.Settings.Default.Terminal_id);
                        if (SQL.HasException(true)) return;
                        Order.Instance.LoadOrder();
                        Close();
                    }
                    else {
                        MessageBox.Show("Name already listed on keep.");
                    }
                    }
                }
            }
        }
}
