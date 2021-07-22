﻿using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }
        SQLControl SQL = new SQLControl();
        ExportImport EI = new ExportImport();
        //METHODS

        //METHODS
        BackgroundWorker workerEProducts,workerECategory;
        private void btnExportProducts_Click(object sender, EventArgs e)
        {
            workerEProducts = new BackgroundWorker();
            workerEProducts.DoWork += WorkerEProducts_DoWork;
            workerEProducts.RunWorkerCompleted += WorkerEProducts_RunWorkerCompleted;
            workerEProducts.RunWorkerAsync();
            //EI.ExportDgvToExcel(dgv);
        }

        private void WorkerEProducts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                new Notification().PopUp("There are no products in our database.", "", "error");
                return;
            }


            if (dgv.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dgv.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dgv.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgv.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgv.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dgv.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void WorkerEProducts_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLControl pSQL = new SQLControl();
            //pSQL.Query("SELECT products.name,products.description,product_category.name as 'Category',products.rp_inclusive,products.wp_inclusive,products.barcode1,products.barcode2,warehouse.name as 'Warehouse',products.s_discR,products.s_discPWD_SC,products.s_PWD_SC_perc,products.s_discAth,products.s_ask_qty FROM products INNER JOIN product_category ON products.categoryID = product_category.categoryID INNER JOIN warehouse ON products.warehouseID = warehouse.warehouseID");

            pSQL.Query("SELECT products.name,products.description,product_category.name as 'Category',products.rp_inclusive,products.wp_inclusive,products.barcode1,products.barcode2,warehouse.name as 'Warehouse',products.s_discR,products.s_discPWD_SC,products.s_PWD_SC_perc,products.s_discAth,products.s_ask_qty,inventory.stock_qty FROM products INNER JOIN product_category ON products.categoryID = product_category.categoryID INNER JOIN warehouse ON products.warehouseID = warehouse.warehouseID INNER JOIN inventory ON products.warehouseID = warehouse.warehouseID");

            if (pSQL.HasException(true)) return;

            dgv.Invoke(new System.Action(() => {
                dgv.DataSource = pSQL.DBDT;
            }));
        }

        private void btnImportProducts_Click(object sender, EventArgs e)
        {
            TableImportCSV frmTableImport = new TableImportCSV();

            frmTableImport.table_import_type = 1;
            frmTableImport.ShowDialog();
        }

        private void btnExportCategory_Click(object sender, EventArgs e)
        {
            workerECategory = new BackgroundWorker();
            workerECategory.DoWork += WorkerECategory_DoWork;
            workerECategory.RunWorkerCompleted += WorkerECategory_RunWorkerCompleted;
            workerECategory.RunWorkerAsync();
            //EI.ExportDgvToExcel(dgv);
        }

        private void WorkerECategory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                new Notification().PopUp("There are no products in our database.", "", "error");
                return;
            }


            if (dgv.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dgv.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dgv.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgv.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgv.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dgv.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void WorkerECategory_DoWork(object sender, DoWorkEventArgs e)
        {
            SQL.Query("SELECT name,s_discR,s_discPWD_SC,s_PWD_SC_perc,s_discAth,s_ask_qty FROM product_category");
            if (SQL.HasException(true))
                return;

            dgv.Invoke(new System.Action(() => {
                dgv.DataSource = SQL.DBDT;
            }));
        }

        private void btnImportCategory_Click(object sender, EventArgs e)
        {
            TableImportCSV frmTableImport = new TableImportCSV();

            frmTableImport.table_import_type = 2;
            frmTableImport.ShowDialog();
        }

        private void btnExportCustomer_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM customer");
            if (SQL.HasException(true))
                return;

            dgv.DataSource = SQL.DBDT;

            EI.ExportDgvToExcel(dgv);
        }

        private void btnImportCustomer_Click(object sender, EventArgs e)
        {
            TableImport frmTableImport = new TableImport();

            frmTableImport.table_import_type = 3;
            frmTableImport.ShowDialog();
        }

        private void btnExportMC_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM member_card");
            if (SQL.HasException(true))
                return;

            dgv.DataSource = SQL.DBDT;

            EI.ExportDgvToExcel(dgv);
        }

        private void btnImportMC_Click(object sender, EventArgs e)
        {
            TableImport frmTableImport = new TableImport();

            frmTableImport.table_import_type = 4;
            frmTableImport.ShowDialog();
        }

        private void btnExportMembership_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM membership");
            if (SQL.HasException(true))
                return;

            dgv.DataSource = SQL.DBDT;

            EI.ExportDgvToExcel(dgv);
        }

        private void btnImportMembership_Click(object sender, EventArgs e)
        {
            TableImport frmTableImport = new TableImport();

            frmTableImport.table_import_type = 5;
            frmTableImport.ShowDialog();
        }

        private void btnExportGC_Click(object sender, EventArgs e)
        {
            SQL.Query("SELECT * FROM giftcard");
            if (SQL.HasException(true))
                return;

            dgv.DataSource = SQL.DBDT;

            EI.ExportDgvToExcel(dgv);
        }

        private void btnImportGC_Click(object sender, EventArgs e)
        {
            TableImport frmTableImport = new TableImport();

            frmTableImport.table_import_type = 6;
            frmTableImport.ShowDialog();
        }
    }
}
