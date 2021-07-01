using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Management;
using System.Windows.Forms;
using System.Drawing;
using EcoPOSControl;
using System.IO.Ports;
using EcoPOSv2;
using System.Threading;

public class FormLoad
{
    public void changePanel(Panel childPanel, ref Panel currentchildPanel, Button senderBtn, ref Button currentButton)
    {
        currentButton.FlatAppearance.BorderColor = Color.FromArgb(42, 42, 42);
        currentButton = senderBtn;
        currentButton.FlatAppearance.BorderColor = Color.FromArgb(47, 147, 214);

        currentchildPanel.Visible = false;
        currentchildPanel = childPanel;
        currentchildPanel.BringToFront();
        currentchildPanel.Dock = DockStyle.Fill;
        currentchildPanel.Visible = true;

        currentchildPanel = childPanel;
        currentButton = senderBtn;
    }

    public void changeForm(Form childform, Form currentChildForm, Panel pnlChild)
    {

        // close current child form
        if (currentChildForm != null)
            currentChildForm.Close();

        // if current child form is the same then do nothing
        if (currentChildForm == childform)
            return;

        // set new child form
        currentChildForm = childform;
        childform.TopLevel = false;
        childform.FormBorderStyle = FormBorderStyle.None;
        childform.Dock = DockStyle.Fill;
        pnlChild.Controls.Add(childform);
        pnlChild.Tag = childform;
        childform.BringToFront();
        childform.Show();
    }

    public void changeFormWithButton(Form childform, ref Form currentChildForm, Button senderBtn, ref Button currentButton, ref Panel pnlChild)
    {

        // highlight button
        currentButton.FlatAppearance.BorderColor = Color.FromArgb(42, 42, 42);
        currentButton = senderBtn;
        currentButton.FlatAppearance.BorderColor = Color.FromArgb(47, 147, 214);

        // close current child form
        if (currentChildForm != null)
            currentChildForm.Close();

        // if current child form is the same then do nothing

        if (currentChildForm == childform)
            return;

        // set new child form
        currentChildForm = childform;
        childform.TopLevel = false;
        childform.FormBorderStyle = FormBorderStyle.None;
        childform.Dock = DockStyle.Fill;
        pnlChild.Controls.Add(childform);
        pnlChild.Tag = childform;
        childform.BringToFront();
        childform.Show();
    }

    public void ComboValues(ComboBox cmb, string colID, string colVal, string tbl)
    {
        SQLControl SQL = new SQLControl();

        cmb.DataSource = null;
        SQL.Query("SELECT " + colID + ", " + colVal + " FROM " + tbl + " ORDER BY " + colVal + " ASC");
        if (SQL.HasException(true))
            return;

        cmb.DataSource = SQL.DBDT;

        cmb.ValueMember = colID;
        cmb.DisplayMember = colVal;
    }

    public void ComboValuesQuery(ComboBox cmb, string query, string colID, string colVal)
    {
        SQLControl SQL = new SQLControl();

        SQL.Query(query);
        if (SQL.HasException(true))
            return;


        cmb.DataSource = SQL.DBDT;

        cmb.ValueMember = colID;

        cmb.DisplayMember = colVal;
    }

    public decimal GetSumColumn(DataGridView dgv, int colNum)
    {
        decimal sum = 0;

        if (dgv.RowCount > 0)
        {
            for (int i = 0; i <= dgv.RowCount - 1; i++)

                sum += Convert.ToDecimal(dgv.Rows[i].Cells[colNum].Value);
        }

        return sum;
    }

    public void CusDisplay(string text1, string text2 = "")
    {
        try
        {
            //SerialPort sp = new SerialPort(Main.Instance.pd_customer_display_port, 9600, Parity.None, 8, StopBits.One);
            //sp.Open();
            //// to clear the display
            //sp.Write(Convert.ToString((char)12));

            //// first line goes here
            //sp.WriteLine(text1);

            //// 2nd line goes here

            //sp.WriteLine((char)13 + text2);

            //sp.Close();
            //sp.Dispose();
            //sp = null;


                SerialPort sp = new SerialPort(Main.Instance.pd_customer_display_port, 9600, Parity.None, 8, StopBits.One);
                //in my case COM4  is the RJ11 connector port
                //POS to Line display connector is RJ11 (Like modem connector)
                sp.Open();

                //Clear the Display
                sp.Write(new byte[] { 0x0C }, 0, 1);
                sp.Write(text1);

                //Goto Bottem Line
                sp.Write(new byte[] { 0x0A, 0x0D }, 0, 2);
                sp.Write(text2);

                
            sp.Close();
            sp.Dispose();

                //Here it will sleep for 3 sec and then excecute again

                ////Clear the Display
                //sp.Write(new byte[] { 0x0C }, 0, 1);
                //sp.Write("3rd line=");

                ////Goto Bottem Line
                //sp.Write(new byte[] { 0x0A, 0x0D }, 0, 2);
                //sp.Write("4th line=");
                //sp.Close();

        }
        catch (Exception)
        {

        }
       
    }
}
