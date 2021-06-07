﻿using EcoPOSControl;
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
    public partial class SeeItem : Form
    {
        public SeeItem()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();

        public Order frmOrder;

        //private void btnConfirm_Click(object sender, EventArgs e)
        //{
        //    if (dgvProducts.SelectedRows.Count == 0)
        //        return;

        //    string type_query = " rp_exclusive, rp_tax, rp_inclusive";
        //    string type = "R";

        //    if (rbWholesale.Checked)
        //    {
        //        type = "W";
        //        type_query = "wp_exclusive, wp_tax, wp_inclusive";
        //    }

        //    SQL.AddParam("@productID", dgvProducts.CurrentRow.Cells[0].Value.ToString());
        //    SQL.AddParam("@type", type);
        //    int check_in_cart = Convert.ToInt32(SQL.ReturnResult("SELECT COUNT(*) FROM order_cart WHERE productID = @productID AND type = @type"));

        //    if (SQL.HasException(true))
        //        return;

        //    if (check_in_cart == 0)
        //    {
        //        SQL.AddParam("@productID", dgvProducts.CurrentRow.Cells[0].Value.ToString());
        //        SQL.AddParam("@type", type);

        //        SQL.Query(@"INSERT INTO order_cart (productID , description, name, type, static_price_exclusive, static_price_vat, static_price_inclusive, quantity, discount) 
        //               SELECT productID, description, name, @type," + type_query + ", 1, 0 FROM products WHERE productID = @productID");

        //        if (SQL.HasException(true))
        //            return;
        //    }
        //    else
        //    {
        //        SQL.AddParam("@productID", dgvProducts.CurrentRow.Cells[0].Value.ToString());
        //        SQL.AddParam("@type", type);

        //        SQL.Query("UPDATE order_cart SET quantity = quantity + 1 WHERE productID = @productID AND type = @type");
        //        if (SQL.HasException(true))
        //            return;
        //    }

        //    frmOrder.LoadOrder();
        //    frmOrder.GetTotal();
        //    frmOrder.tbBarcode.Clear();
        //    frmOrder.tbBarcode.Focus();

        //    Close();
        //}

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            SQL.AddParam("@find", txtBarcode.Text + "%");

            SQL.Query(@"SELECT productID, barcode1 as 'Barcode 1', barcode2 as 'Barcode 2', description as 'Name', rp_inclusive as 'SRP', wp_inclusive as 'Wholesale' FROM products
                       WHERE barcode1 LIKE @find OR barcode2 LIKE @find ORDER BY description DESC");

            if (SQL.HasException(true))
                return;

            dgvProducts.DataSource = SQL.DBDT;
            dgvProducts.Columns[0].Visible = false;

            //if (e.KeyCode == Keys.Enter)
            //    btnConfirm.PerformClick();
        }

        private void dgvProducts_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    btnConfirm.PerformClick();
        }

        private void SeeItem_Load(object sender, EventArgs e)
        {
            SQL.Query("SELECT productID, barcode1 as 'Barcode 1', barcode2 as 'Barcode 2', description as 'Name', rp_inclusive as 'SRP', wp_inclusive as 'Wholesale' FROM products");

            dgvProducts.DataSource = SQL.DBDT;
            dgvProducts.Columns[0].Visible = false;
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                txtBarcode.Clear();
                txtBarcode.Focus();
                txtBarcode.Text = txtBarcode.Text.Replace(" ", "");
            }
        }
    }
}
