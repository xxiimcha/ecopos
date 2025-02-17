﻿using System;
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
    public partial class DiscountOption : Form
    {
        public DiscountOption()
        {
            InitializeComponent();
        }
        //HOTKEYS

        public Order frmOrder;

        private void btnContinueSession_Click(object sender, EventArgs e)
        {
            RegularDiscount frmRegularDiscount = new RegularDiscount();
            frmRegularDiscount.frmOrder = frmOrder;
            frmRegularDiscount.frmDiscountOption = this;
            frmRegularDiscount.ShowDialog();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            SpecialDiscount frmSpecialDiscount = new SpecialDiscount();
            frmSpecialDiscount.frmOrder = frmOrder;
            frmSpecialDiscount.frmDiscountOption = this;
            frmSpecialDiscount.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiscountOption_Load(object sender, EventArgs e)
        {
            btnRegular.Focus();
        }

        private void DiscountOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();

            if (e.KeyCode == Keys.D1) btnRegular.PerformClick();

            if (e.KeyCode == Keys.D2) btnSpecial.PerformClick();
        }
    }
}
