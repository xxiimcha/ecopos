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
    public partial class CancelPopup : Form
    {
        SQLControl sql = new SQLControl();
        public static Boolean ConfirmedToCancel { get; set; }
        #region
        //DROP SHADOW START HERE===================================================================================
        private bool Drag;
        private int MouseX;
        private int MouseY;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }
        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }
        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
            }
        }
        //DROP SHADOW ENDS HERE===================================================================================
        #endregion
        public CancelPopup()
        {
            InitializeComponent();
            ConfirmedToCancel = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            String current_invoice_number = sql.ReturnResult("SELECT TOP 1 order_ref_temp FROM transaction_details ORDER BY order_ref DESC");
            ConfirmedToCancel = true;
            sql.Query($"select * from order_cart where terminal_id = {int.Parse(Properties.Settings.Default.Terminal_id)} ");
            if (sql.HasException(true)) return;
            if(sql.DBDT.Rows.Count > 0)
            {
                foreach(DataRow dr in sql.DBDT.Rows)
                {
                    if (Main.Instance.by_pass_user)
                    {
                        //bypass insert
                        sql.Query($"insert into canceled_items(date_time,cashier_name,canceled_by, cancel_reason, canceled_item,quantity,current_order_no,latest_invoice,canceled_amount,terminal_no) values " +
                        $"('{date}','{Main.Instance.lblUser.Text}','{Main.Instance.lblByPassUser.Text}','{tbReason.Text}','{dr["name"].ToString()}',{int.Parse(dr["quantity"].ToString())}," +
                        $"'{Order.Instance.lblOrderNumber.Text}','{current_invoice_number}' " +
                        $",{decimal.Parse(dr["selling_price_inclusive"].ToString())},{int.Parse(Properties.Settings.Default.Terminal_id)})");
                        if (sql.HasException(true)) return;
                    }
                    else
                    {
                        //normal insert
                        sql.Query($"insert into canceled_items(date_time,cashier_name,canceled_by, cancel_reason, canceled_item,quantity,current_order_no,latest_invoice,canceled_amount,terminal_no) values " +
                        $"('{date}','{Main.Instance.lblUser.Text}','{Main.Instance.lblUser.Text}','{tbReason.Text}','{dr["name"].ToString()}',{int.Parse(dr["quantity"].ToString())}," +
                        $"'{Order.Instance.lblOrderNumber.Text}','{current_invoice_number}' " +
                        $",{decimal.Parse(dr["selling_price_inclusive"].ToString())},{int.Parse(Properties.Settings.Default.Terminal_id)})");
                        if (sql.HasException(true)) return;
                    }

                }
            }
            MessageBox.Show(this, "Cancel transaction successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
