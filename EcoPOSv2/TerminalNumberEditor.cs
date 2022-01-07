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
    public partial class TerminalNumberEditor : Form
    {
        public TerminalNumberEditor()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        private void BtnChange_Click(object sender, EventArgs e)
        {
            if (int.Parse(SQL.ReturnResult("SELECT COUNT(*) FROM terminals WHERE terminal_id=" + tbTerminalID.Text)) > 0 || int.Parse(SQL.ReturnResult("SELECT COUNT(*) FROM terminals WHERE terminal_name=" + tbTerminalNumber.Text)) > 0 || int.Parse(SQL.ReturnResult("SELECT COUNT(*) FROM terminals WHERE machine_no=" + tbMachineNumber.Text)) > 0)
            {
                //MessageBox.Show("This terminal/machine number already exist in our system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;

                Properties.Settings.Default.Terminal_id = tbTerminalID.Text;
                Properties.Settings.Default.Terminal_name = tbTerminalNumber.Text;
                Properties.Settings.Default.Machine_no = tbMachineNumber.Text;
                Properties.Settings.Default.Save();

                SQL.AddParam("terminal_id", tbTerminalID.Text);
                SQL.AddParam("terminal_name", tbTerminalNumber.Text);
                SQL.AddParam("machine_no", tbMachineNumber.Text);

                //SQL.Query("Insert into terminals (terminal_id, terminal_name, machine_no) Values (@terminal_id, @terminal_name, @machine_no)");
                SQL.Query("UPDATE terminals set terminal_id=@terminal_id,terminal_name=@terminal_name,machine_no=@machine_no where terminal_id=@terminal_id");

                if (SQL.HasException(true)) return;

                MessageBox.Show("Terminal Number has been changed.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this.Close();
                //DVOptions.Instance.Close();
                //Login.Instance.lblTerminal.Text = "Terminal " + Properties.Settings.Default.Terminal_name;
                //Application.Restart();

            }
            else
            {
                Properties.Settings.Default.Terminal_id = tbTerminalID.Text;
                Properties.Settings.Default.Terminal_name = tbTerminalNumber.Text;
                Properties.Settings.Default.Machine_no = tbMachineNumber.Text;
                Properties.Settings.Default.Save();

                SQL.AddParam("terminal_id", tbTerminalID.Text);
                SQL.AddParam("terminal_name", tbTerminalNumber.Text);
                SQL.AddParam("machine_no", tbMachineNumber.Text);

                SQL.Query("Insert into terminals (terminal_id, terminal_name, machine_no) Values (@terminal_id, @terminal_name, @machine_no)");

                if (SQL.HasException(true)) return;

                MessageBox.Show("Terminal Number has been changed.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this.Close();
                //DVOptions.Instance.Close();
                //Login.Instance.lblTerminal.Text = "Terminal " + Properties.Settings.Default.Terminal_name;
                //Application.Restart();
            }
        }

        private void TbMachineNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnChange.PerformClick();
        }

        void loadterminals()
        {
            Task.Run(() =>
            {
                Invoke(new MethodInvoker(delegate
                {
                    SQLControl psql = new SQLControl();

                    psql.Query("select * from terminals");

                    if (psql.HasException(true)) return;

                    dt.DataSource = psql.DBDT;
                }));
            });
        }
        private void TerminalNumberEditor_Load(object sender, EventArgs e)
        {
            loadterminals();
        }

        private void Dt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {

                SQLControl psql = new SQLControl();

                psql.AddParam("@terminal_id", dt.CurrentRow.Cells[0].Value.ToString());
                psql.Query("delete from terminals where terminal_id=@terminal_id");

                if (psql.HasException(true)) return;

                loadterminals();
            }
        }
    }
}
