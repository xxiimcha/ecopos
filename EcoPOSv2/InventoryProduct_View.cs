using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class InventoryProduct_View : Form
    {
        public InventoryProduct_View()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        public void SetDoubleBuffered(Panel panel)
        {
            typeof(Panel).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               panel,
               new object[] { true });
        }

        public static InventoryProduct_View _InventoryProduct_View;
        public static InventoryProduct_View Instance
        {
            get
            {
                if (_InventoryProduct_View == null)
                {
                    _InventoryProduct_View = new InventoryProduct_View();
                }
                return _InventoryProduct_View;
            }
        }

        public string productname,productID;
        //METHOD
        void LoadDataSoldSummary()
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    try
                    {
                        SQLControl SQL = new SQLControl();

                        SQL.AddParam("@ProductID", productID);
                        SQL.AddParam("@dateFrom", dtpFrom.Value.ToString());
                        SQL.AddParam("@dateTo", dtpTo.Value.ToString());
                        SQL.Query(@"select CONVERT(DECIMAL(10,2),(ti.selling_price_inclusive/ti.static_price_inclusive)*1) as 'Quantity',ti.selling_price_inclusive as 'Price',td.date_time as 'DateTime' from transaction_items as ti INNER JOIN transaction_details as td ON td.order_ref = ti.order_ref where ti.productID = @productID AND td.date_time BETWEEN
                                                          @dateFrom AND @dateTo AND ti.selling_price_inclusive >= 0 ORDER BY td.date_time desc");

                        if (SQL.HasException(true)) return;

                        dgvSold.DataSource = SQL.DBDT;

                        dgvSold.Columns[2].Width = 150;

                        //Compute Total Price Sold
                        decimal TotalSold = 0;

                        for (int i = 0; i < dgvSold.Rows.Count; i++)
                        {
                            TotalSold += Convert.ToDecimal(dgvSold.Rows[i].Cells["Quantity"].Value);
                        }

                        lblSold.Text = TotalSold.ToString();

                        //Compute Total Price Sold
                        decimal Total = 0;

                        for (int i = 0; i < dgvSold.Rows.Count; i++)
                        {
                            Total += Convert.ToDecimal(dgvSold.Rows[i].Cells["Price"].Value);
                        }

                        lblTotalSold.Text = Total.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }));
            }).Start();
        }
        void LoadDataReturnSummary()
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    try
                    {
                        SQLControl SQL = new SQLControl();

                        SQL.AddParam("@ProductID", productID);
                        SQL.AddParam("@dateFrom", dtpFrom.Value.ToString());
                        SQL.AddParam("@dateTo", dtpTo.Value.ToString());
                        SQL.Query(@"select CONVERT(DECIMAL(10,2),(ti.selling_price_inclusive/ti.static_price_inclusive)*1) as 'Quantity',ABS(ti.selling_price_inclusive) as 'Price',td.date_time as 'DateTime' from transaction_items as ti INNER JOIN transaction_details as td ON td.order_ref = ti.order_ref where ti.productID = @productID AND td.date_time BETWEEN
                                                          @dateFrom AND @dateTo AND ti.selling_price_inclusive < 0 ORDER BY td.date_time desc");

                        if (SQL.HasException(true)) return;

                        dgvReturn.DataSource = SQL.DBDT;

                        dgvReturn.Columns[2].Width = 150;

                        //Compute Total Return Sold
                        decimal TotalReturn = 0;

                        for (int i = 0; i < dgvReturn.Rows.Count; i++)
                        {
                            TotalReturn += Convert.ToDecimal(dgvReturn.Rows[i].Cells["Quantity"].Value);
                        }

                        lblReturn.Text = TotalReturn.ToString();


                        //Compute Total Price Return
                        decimal Total = 0;

                        for (int i = 0; i < dgvReturn.Rows.Count; i++)
                        {
                            Total += Convert.ToDecimal(dgvReturn.Rows[i].Cells["Price"].Value);
                        }

                        lblTotalReturn.Text = Total.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }));
            }).Start();
        }
        void LoadDataTotalProductSummary()
        {
            new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    try
                    {
                        SQLControl SQL = new SQLControl();

                        SQL.AddParam("@ProductID", productID);
                        string totalProducts = SQL.ReturnResult(@"SELECT stock_qty from inventory where productID = @productID");
                        if (SQL.HasException(true)) return;

                        lblTotalStock.Text = totalProducts;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }));
            }).Start();
        }

        //METHOD
        private void DtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if(dtpFrom.Value > DateTime.Now)
            {
                dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
                return;
            }

            LoadDataSoldSummary();
            LoadDataReturnSummary();
            LoadDataTotalProductSummary();


        }

        private void DtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTo.Value < DateTime.Now)
            {
                dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));
                return;
            }

            LoadDataSoldSummary();
            LoadDataReturnSummary();
            LoadDataTotalProductSummary();
        }

        private void InventoryProduct_View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void InventoryProduct_View_Load(object sender, EventArgs e)
        {
            _InventoryProduct_View = this;

            dtpFrom.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 00:00:01"));
            dtpTo.Value = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy 23:59:59"));

            LoadDataSoldSummary();
            LoadDataReturnSummary();
            LoadDataTotalProductSummary();
        }
    }
}
