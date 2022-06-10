using EcoPOSControl;
using Guna.UI2.WinForms;
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
        public static decimal itemQuantity { get; set; }
        public static String itemName{ get; set; }
        public static decimal itemPrice{ get; set; }

        public long GenerateTransactionID()
        {
            var finalString = "";
            var chars = "1234567890";
            var stringChars = new char[16];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            finalString = new String(stringChars);

            sql.Query("SELECT * FROM tbl_order_details WHERE transaction_id ='" + finalString + "' ");

            if (sql.DBDT.Rows.Count == 0)
            {
                return long.Parse(finalString);
            }
            else
            {
                return GenerateTransactionID();
            }
        }
        void PrintCancelReceipt(Guna2DataGridView dataGrid, String cashierName, String canceled_by, String cancelReason, String currentOrderNumber, String latest_invoice)
        {
            if (Properties.Settings.Default.papersize == "58MM")
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                dt.Columns.Add("Qty", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Price", typeof(string));

                if (lblTitle.Text.Equals("CANCEL TRANSACTION"))
                {
                    foreach (DataGridViewRow dgv in dataGrid.Rows)
                    {
                        dt.Rows.Add(dgv.Cells[11].Value, dgv.Cells[2].Value, dgv.Cells[10].Value);
                    }
                    ds.Tables.Add(dt);
                }
                else
                {
                    dt.Rows.Add(itemQuantity,itemName, itemPrice);
                    ds.Tables.Add(dt);
                }

                CancelReceipt58 cancelReceipt80 = new CancelReceipt58();
                cancelReceipt80.SetDataSource(dt);

                cancelReceipt80.SetParameterValue("date_time", DateTime.Now.ToString());
                cancelReceipt80.SetParameterValue("cashierName", cashierName);
                cancelReceipt80.SetParameterValue("Terminal_No", Properties.Settings.Default.Terminal_id);

                cancelReceipt80.SetParameterValue("canceled_by", canceled_by);
                cancelReceipt80.SetParameterValue("cancelReason", cancelReason);
                cancelReceipt80.SetParameterValue("currentOrderNumber", currentOrderNumber);
                cancelReceipt80.SetParameterValue("latest_invoice", latest_invoice);

                if (lblTitle.Text.Equals("CANCEL TRANSACTION"))
                {
                    cancelReceipt80.SetParameterValue("title", "CANCEL TRANSACTION RECEIPT");
                    decimal sum = 0;
                    for (int i = 0; i < dataGrid.Rows.Count; ++i)
                    {
                        sum += Convert.ToDecimal(dataGrid.Rows[i].Cells[10].Value);
                    }
                    cancelReceipt80.SetParameterValue("total", sum.ToString("N2"));
                }
                else
                {
                    cancelReceipt80.SetParameterValue("title", "VOID TRANSACTION RECEIPT");
                    cancelReceipt80.SetParameterValue("total", itemPrice.ToString("N2"));
                }



                try
                {
                    cancelReceipt80.PrintOptions.NoPrinter = false;
                    cancelReceipt80.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                    cancelReceipt80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                    cancelReceipt80.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    cancelReceipt80.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception)
                {

                    cancelReceipt80.PrintOptions.NoPrinter = false;
                    cancelReceipt80.PrintOptions.PrinterName = "Microsoft Print to PDF";
                    cancelReceipt80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                    cancelReceipt80.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    cancelReceipt80.PrintToPrinter(0, false, 0, 0);

                }
                finally
                {
                    if (cancelReceipt80.IsLoaded)
                    {
                        cancelReceipt80.Close();
                        //rpt.Dispose();
                    }
                }
            }
            else
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                dt.Columns.Add("Qty", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Price", typeof(string));

                if (lblTitle.Text.Equals("CANCEL TRANSACTION"))
                {
                    foreach (DataGridViewRow dgv in dataGrid.Rows)
                    {
                        dt.Rows.Add(dgv.Cells[11].Value, dgv.Cells[2].Value, dgv.Cells[10].Value);
                    }
                    ds.Tables.Add(dt);
                }
                else
                {
                    dt.Rows.Add(itemQuantity, itemName, itemPrice);
                    ds.Tables.Add(dt);
                }
                CancelReceipt80 cancelReceipt80 = new CancelReceipt80();
                cancelReceipt80.SetDataSource(dt);

                cancelReceipt80.SetParameterValue("date_time", DateTime.Now.ToString());
                cancelReceipt80.SetParameterValue("cashierName", cashierName);
                cancelReceipt80.SetParameterValue("Terminal_No", Properties.Settings.Default.Terminal_id);

                cancelReceipt80.SetParameterValue("canceled_by", canceled_by);
                cancelReceipt80.SetParameterValue("cancelReason", cancelReason);
                cancelReceipt80.SetParameterValue("currentOrderNumber", currentOrderNumber);
                cancelReceipt80.SetParameterValue("latest_invoice", latest_invoice);

                if (lblTitle.Text.Equals("CANCEL TRANSACTION"))
                {
                    cancelReceipt80.SetParameterValue("title", "CANCEL TRANSACTION RECEIPT");
                    decimal sum = 0;
                    for (int i = 0; i < dataGrid.Rows.Count; ++i)
                    {
                        sum += Convert.ToDecimal(dataGrid.Rows[i].Cells[10].Value);
                    }
                    cancelReceipt80.SetParameterValue("total", sum.ToString("N2"));
                }
                else
                {
                    cancelReceipt80.SetParameterValue("title", "VOID TRANSACTION RECEIPT");
                    cancelReceipt80.SetParameterValue("total", itemPrice.ToString("N2"));
                }

                try
                {
                    cancelReceipt80.PrintOptions.NoPrinter = false;
                    cancelReceipt80.PrintOptions.PrinterName = Main.Instance.pd_receipt_printer;
                    cancelReceipt80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                    cancelReceipt80.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    cancelReceipt80.PrintToPrinter(1, false, 0, 0);
                }
                catch (Exception)
                {

                    cancelReceipt80.PrintOptions.NoPrinter = false;
                    cancelReceipt80.PrintOptions.PrinterName = "Microsoft Print to PDF";
                    cancelReceipt80.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                    cancelReceipt80.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    cancelReceipt80.PrintToPrinter(0, false, 0, 0);

                }
                finally
                {
                    if (cancelReceipt80.IsLoaded)
                    {
                        cancelReceipt80.Close();
                        //rpt.Dispose();
                    }
                }
            }
        }
        String title;
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
        public CancelPopup(String title)
        {
            InitializeComponent();
            ConfirmedToCancel = false;
            this.title = title;
            lblTitle.Text = title;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbReason.Text.Equals(""))
            {
                MessageBox.Show(this, "Please enter valid reason first!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbReason.Focus();
            }
            else
            {
                if (lblTitle.Text.Equals("CANCEL TRANSACTION"))
                {
                    //Cancel transaction
                    String cancelTransactionID = GenerateTransactionID().ToString();
                    String current_invoice_number = sql.ReturnResult("SELECT TOP 1 order_ref_temp FROM transaction_details ORDER BY order_ref DESC");
                    ConfirmedToCancel = true;
                    sql.Query($"select * from order_cart where terminal_id = {int.Parse(Properties.Settings.Default.Terminal_id)} ");
                    if (sql.HasException(true)) return;
                    if (sql.DBDT.Rows.Count > 0)
                    {
                        foreach (DataRow dr in sql.DBDT.Rows)
                        {
                            if (Main.Instance.by_pass_user)
                            {
                                //bypass insert
                                sql.AddParam("@cashierName", Main.Instance.lblUser.Text);
                                sql.AddParam("@canceledBy", Main.Instance.lblByPassUser.Text);
                                sql.AddParam("@cancelReason", tbReason.Text);
                                sql.AddParam("@canceled_item", dr["name"].ToString());
                                sql.AddParam("@quantity", dr["quantity"].ToString());
                                sql.AddParam("@currentOrderNumber", Order.Instance.lblOrderNumber.Text);
                                sql.AddParam("@latestInvoiceNumber", current_invoice_number);
                                sql.AddParam("@sellingPriceInclusive", decimal.Parse(dr["selling_price_inclusive"].ToString()));
                                sql.AddParam("@terminalID", Properties.Settings.Default.Terminal_id);
                                sql.AddParam("@canceltransactionID", cancelTransactionID);
                                sql.AddParam("@Status", "Canceled_Order");
                                //normal insert
                                sql.Query($"insert into canceled_items(status,date_time,cashier_name,canceled_by, cancel_reason, canceled_item,quantity,current_order_no,latest_invoice,canceled_amount,terminal_no,cancel_transaction_id) values " +
                                $"(@Status,@cashierName,@canceledBy,@cancelReason,@canceled_item,@quantity,@currentOrderNumber,@latestInvoiceNumber,@sellingPriceInclusive,@terminalID, @canceltransactionID)");
                            }
                            else
                            {
                                sql.AddParam("@cashierName", Main.Instance.lblUser.Text);
                                sql.AddParam("@canceledBy", Main.Instance.lblUser.Text);
                                sql.AddParam("@cancelReason", tbReason.Text);
                                sql.AddParam("@canceled_item", dr["name"].ToString());
                                sql.AddParam("@quantity", dr["quantity"].ToString());
                                sql.AddParam("@currentOrderNumber", Order.Instance.lblOrderNumber.Text);
                                sql.AddParam("@latestInvoiceNumber", current_invoice_number);
                                sql.AddParam("@sellingPriceInclusive", decimal.Parse(dr["selling_price_inclusive"].ToString()));
                                sql.AddParam("@terminalID", Properties.Settings.Default.Terminal_id);
                                sql.AddParam("@canceltransactionID", cancelTransactionID);
                                sql.AddParam("@Status", "Canceled_Order");
                                //normal insert
                                sql.Query($"insert into canceled_items(status,cashier_name,canceled_by, cancel_reason, canceled_item,quantity,current_order_no,latest_invoice,canceled_amount,terminal_no,cancel_transaction_id) values " +
                                $"(@Status,@cashierName,@canceledBy,@cancelReason,@canceled_item,@quantity,@currentOrderNumber,@latestInvoiceNumber,@sellingPriceInclusive,@terminalID, @canceltransactionID )");
                            }
                        }
                    }
                    PrintCancelReceipt(Order.Instance.dgvCart, Main.Instance.lblUser.Text, Main.Instance.lblUser.Text, tbReason.Text, Order.Instance.lblOrderNumber.Text, current_invoice_number);
                    MessageBox.Show(this, "Canceled transaction successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    //Void Transaction
                    String cancelTransactionID = GenerateTransactionID().ToString();
                    String current_invoice_number = sql.ReturnResult("SELECT TOP 1 order_ref_temp FROM transaction_details ORDER BY order_ref DESC");
                    ConfirmedToCancel = true;
                    if (Main.Instance.by_pass_user)
                    {
                        //bypass insert
                        sql.AddParam("@cashierName", Main.Instance.lblUser.Text);
                        sql.AddParam("@canceledBy", Main.Instance.lblByPassUser.Text);
                        sql.AddParam("@cancelReason", tbReason.Text);
                        sql.AddParam("@canceled_item", itemName);
                        sql.AddParam("@quantity", itemQuantity);
                        sql.AddParam("@currentOrderNumber", Order.Instance.lblOrderNumber.Text);
                        sql.AddParam("@latestInvoiceNumber", current_invoice_number);
                        sql.AddParam("@sellingPriceInclusive", itemPrice);
                        sql.AddParam("@terminalID", Properties.Settings.Default.Terminal_id);
                        sql.AddParam("@canceltransactionID", cancelTransactionID);
                        sql.AddParam("@Status", "Void_Order");
                        //normal insert
                        sql.Query($"insert into canceled_items(status,date_time,cashier_name,canceled_by, cancel_reason, canceled_item,quantity,current_order_no,latest_invoice,canceled_amount,terminal_no,cancel_transaction_id) values " +
                        $"(@Status,@cashierName,@canceledBy,@cancelReason,@canceled_item,@quantity,@currentOrderNumber,@latestInvoiceNumber,@sellingPriceInclusive,@terminalID, @canceltransactionID)");
                    }
                    else
                    {
                        sql.AddParam("@cashierName", Main.Instance.lblUser.Text);
                        sql.AddParam("@canceledBy", Main.Instance.lblUser.Text);
                        sql.AddParam("@cancelReason", tbReason.Text);
                        sql.AddParam("@canceled_item", itemName);
                        sql.AddParam("@quantity", itemQuantity);
                        sql.AddParam("@currentOrderNumber", Order.Instance.lblOrderNumber.Text);
                        sql.AddParam("@latestInvoiceNumber", current_invoice_number);
                        sql.AddParam("@sellingPriceInclusive", itemPrice);
                        sql.AddParam("@terminalID", Properties.Settings.Default.Terminal_id);
                        sql.AddParam("@canceltransactionID", cancelTransactionID);
                        sql.AddParam("@Status", "Void_Order");
                        //normal insert
                        sql.Query($"insert into canceled_items(status,cashier_name,canceled_by, cancel_reason, canceled_item,quantity,current_order_no,latest_invoice,canceled_amount,terminal_no,cancel_transaction_id) values " +
                        $"(@Status,@cashierName,@canceledBy,@cancelReason,@canceled_item,@quantity,@currentOrderNumber,@latestInvoiceNumber,@sellingPriceInclusive,@terminalID, @canceltransactionID )");
                    }
                    PrintCancelReceipt(Order.Instance.dgvCart, Main.Instance.lblUser.Text, Main.Instance.lblUser.Text, tbReason.Text, Order.Instance.lblOrderNumber.Text, current_invoice_number);
                    MessageBox.Show(this, "Voided Item successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
              
            }
        }

        private void tbReason_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
        }
    }
}
