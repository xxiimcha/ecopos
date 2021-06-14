using EcoPOSControl;
using ExcelDataReader;
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
    public partial class TableImport : Form
    {
        public TableImport()
        {
            InitializeComponent();
        }

        private SQLControl SQL = new SQLControl();

        public int table_import_type;

        private DataTableCollection tables;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = OpenFileDialog1.FileName;
                using (var stream = File.Open(txtFile.Text, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration { ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = true } });
                        tables = result.Tables;
                        cmbSheet.Items.Clear();
                        foreach (DataTable table in tables)
                            cmbSheet.Items.Add(table.TableName);
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            switch (table_import_type)
            {
                case 1 // products
               :
                    {
                        SQL.Query("DELETE FROM products");
                        if (SQL.HasException(true))
                            return;

                        SQL.Query("DELETE FROM inventory");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            SQL.AddParam("@name", DataGridView1.Rows[i].Cells[1].Value.ToString());
                            SQL.AddParam("@description", DataGridView1.Rows[i].Cells[2].Value.ToString());
                            SQL.AddParam("@categoryID", DataGridView1.Rows[i].Cells[3].Value.ToString());
                            SQL.AddParam("@rp_inclusive", DataGridView1.Rows[i].Cells[4].Value.ToString());
                            SQL.AddParam("@wp_inclusive", DataGridView1.Rows[i].Cells[5].Value.ToString());
                            SQL.AddParam("@barcode1", DataGridView1.Rows[i].Cells[6].Value.ToString());
                            SQL.AddParam("@barcode2", DataGridView1.Rows[i].Cells[7].Value.ToString());
                            SQL.AddParam("@warehouseID", DataGridView1.Rows[i].Cells[8].Value.ToString());
                            SQL.AddParam("@s_discR", DataGridView1.Rows[i].Cells[9].Value.ToString());
                            SQL.AddParam("@s_discPWD_SC", DataGridView1.Rows[i].Cells[10].Value.ToString());
                            SQL.AddParam("@s_PWD_SC_perc", DataGridView1.Rows[i].Cells[11].Value.ToString());
                            SQL.AddParam("@s_discAth", DataGridView1.Rows[i].Cells[12].Value.ToString());
                            SQL.AddParam("@s_ask_qty", DataGridView1.Rows[i].Cells[13].Value.ToString());

                            SQL.Query(@"INSERT INTO products
                                   (description, name, categoryID, rp_inclusive, wp_inclusive, barcode1, barcode2, warehouseID, 
                                    s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty)
                                   VALUES
                                   (@description, @name, @categoryID, @rp_inclusive, @wp_inclusive, @barcode1, @barcode2, @warehouseID, 
                                    @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty)");

                            if (SQL.HasException(true))
                                return;

                            // create inventory

                            SQL.Query("INSERT INTO inventory (productID, stock_qty) VALUES ((SELECT MAX(productID) FROM products), 0)");

                            if (SQL.HasException(true))
                                return;
                        }

                        new Notification().PopUp("Import success.", "", "information");
                        break;
                    }

                case 2 // category
         :
                    {
                        SQL.Query("DELETE FROM product_category");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            SQL.AddParam("@name", DataGridView1.Rows[i].Cells[1].Value.ToString());
                            SQL.AddParam("@s_discR", DataGridView1.Rows[i].Cells[2].Value.ToString());
                            SQL.AddParam("@s_discPWD_SC", DataGridView1.Rows[i].Cells[3].Value.ToString());
                            SQL.AddParam("@s_PWD_SC_perc", DataGridView1.Rows[i].Cells[4].Value.ToString());
                            SQL.AddParam("@s_discAth", DataGridView1.Rows[i].Cells[5].Value.ToString());
                            SQL.AddParam("@s_ask_qty", DataGridView1.Rows[i].Cells[6].Value.ToString());

                            SQL.Query(@"INSERT INTO product_category
                                   (name, s_discR, s_discPWD_SC, s_PWD_SC_perc, s_discAth, s_ask_qty)
                                   VALUES
                                   (@name, @s_discR, @s_discPWD_SC, @s_PWD_SC_perc, @s_discAth, @s_ask_qty)
                                  ");

                            if (SQL.HasException(true))
                                return;

                            new Notification().PopUp("Import success.", "", "information");
                        }

                        break;
                    }

                case 3 // customer
         :
                    {
                        SQL.Query("DELETE FROM customer");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            SQL.AddParam("@name", DataGridView1.Rows[i].Cells[1].Value.ToString());
                            SQL.AddParam("@contact", DataGridView1.Rows[i].Cells[2].Value.ToString());
                            SQL.AddParam("@birthday", DataGridView1.Rows[i].Cells[3].Value.ToString());
                            SQL.AddParam("@add1", DataGridView1.Rows[i].Cells[4].Value.ToString());
                            SQL.AddParam("@add2", DataGridView1.Rows[i].Cells[5].Value.ToString());
                            SQL.AddParam("@email", DataGridView1.Rows[i].Cells[6].Value.ToString());
                            SQL.AddParam("@member_type_ID", DataGridView1.Rows[i].Cells[7].Value.ToString());
                            SQL.AddParam("@card_no", DataGridView1.Rows[i].Cells[8].Value.ToString());

                            SQL.Query(@"INSERT INTO customer (name, contact, birthday, add1, add2, email, member_type_ID, card_no)
                                      VALUES (@name, @contact, @birthday, @add1, @add2, @email, @member_type_ID, @card_no)");

                            if (SQL.HasException(true))
                                return;

                            new Notification().PopUp("Import success.", "", "information");
                        }

                        break;
                    }

                case 4 // member card
         :
                    {
                        SQL.Query("DELETE FROM member_card");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            SQL.AddParam("@card_no", DataGridView1.Rows[i].Cells[1].Value.ToString());

                            SQL.Query(@"INSERT INTO member_card (card_no, member_type_ID, customerID, customer_name, card_balance, status)
                                      VALUES (@card_no, 0, 0, '', 0, 'Available')");
                            if (SQL.HasException(true))
                                return;
                        }

                        new Notification().PopUp("Import success.", "", "information");
                        break;
                    }

                case 5 // membership
         :
                    {
                        SQL.Query("DELETE FROM membership");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            SQL.AddParam("@member_type_ID", DataGridView1.Rows[i].Cells[0].Value.ToString());
                            SQL.AddParam("@name", DataGridView1.Rows[i].Cells[1].Value.ToString());
                            SQL.AddParam("@discountable", DataGridView1.Rows[i].Cells[2].Value.ToString());
                            SQL.AddParam("@disc_amt", DataGridView1.Rows[i].Cells[3].Value.ToString());
                            SQL.AddParam("@disc_type", DataGridView1.Rows[i].Cells[4].Value.ToString());
                            SQL.AddParam("@expiration", DataGridView1.Rows[i].Cells[5].Value.ToString());
                            SQL.AddParam("@rewardable", DataGridView1.Rows[i].Cells[6].Value.ToString());
                            SQL.AddParam("@amt_per_pt", DataGridView1.Rows[i].Cells[7].Value.ToString());

                            SQL.Query(@"SET IDENTITY_INSERT membership ON;
                                   INSERT INTO membership (member_type_ID, name, discountable, disc_amt, disc_type, 
                                        expiration, rewardable, amt_per_pt) VALUES (@member_type_ID, @name, @discountable, 
                                        @disc_amt, @disc_type, @expiration, @rewardable, @amt_per_pt)
                                   SET IDENTITY_INSERT membership OFF;");

                            if (SQL.HasException(true))
                                return;
                        }

                        new Notification().PopUp("Import success.", "", "information");
                        break;
                    }

                case 6 // gift card
         :
                    {
                        SQL.Query("DELETE FROM giftcard");
                        if (SQL.HasException(true))
                            return;

                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            SQL.AddParam("@giftcard_no", DataGridView1.Rows[i].Cells[1].Value.ToString());
                            SQL.AddParam("@amount", DataGridView1.Rows[i].Cells[2].Value.ToString());
                            SQL.AddParam("@status", DataGridView1.Rows[i].Cells[3].Value.ToString());
                            SQL.AddParam("@expiration", DataGridView1.Rows[i].Cells[4].Value.ToString());

                            SQL.Query(@"INSERT INTO giftcard (giftcard_no, amount, status, expiration)
                                       VALUES (@giftcard_no, @amount, @status, @expiration)");

                            if (SQL.HasException(true))
                                return;
                        }

                        new Notification().PopUp("Import success.", "", "information");
                        break;
                    }
            }
        }

        private void cmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tables[cmbSheet.SelectedItem.ToString()];
            DataGridView1.DataSource = dt;
        }
    }
}
