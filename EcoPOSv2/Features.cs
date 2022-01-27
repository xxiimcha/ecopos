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
    public partial class Features : Form
    {
        public Features()
        {
            InitializeComponent();
        }

        private void checkBoxCardLogin_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Features_Load(object sender, EventArgs e)
        {
            //CARD LOGIN
            if (Properties.Settings.Default.cardlogin == true)
            {
                checkBoxCardLogin.Checked = true;
            }
            else
            {
                checkBoxCardLogin.Checked = false;
            }

            //PRICE EDITOR FOR TRAININGMODE ONLY
            if (Properties.Settings.Default.priceeditor == true)
            {
                checkBoxPriceEditor.Checked = true;
            }
            else
            {
                checkBoxPriceEditor.Checked = false;
            }

            //VAT NON-VAT
            if(Properties.Settings.Default.vatnonvat == true)
            {
                checkBoxVatNonVat.Checked = true;
            }
            else
            {
                checkBoxVatNonVat.Checked = false;
            }

            //INVENTORY PRODUCT VIEW
            if(Properties.Settings.Default.inventoryproductview == true)
            {
                checkBox_InventoryView.Checked = true;
            }
            else
            {
                checkBox_InventoryView.Checked = false;
            }

            //VAT/NON-VAT REGISTERED
            if(Properties.Settings.Default.nonvat_registered == true)
            {
                CheckBox_Non_Vat_Registered.Checked = true;
            }
            else
            {
                CheckBox_Non_Vat_Registered.Checked = false;
            }

            //CLOUDBASE
            if (Properties.Settings.Default.CloudBase == true)
            {
                CheckBox_CloudBase.Checked = true;
            }
            else
            {
                CheckBox_CloudBase.Checked = false;
            }


            if(DVOptions.Instance.login == 1)
            {
                checkBoxCardLogin.Enabled = false;
                checkBoxPriceEditor.Enabled = false;
                checkBox_InventoryView.Enabled = false;
                checkBoxVatNonVat.Enabled = true;
                CheckBox_Non_Vat_Registered.Enabled = false;
                CheckBox_CloudBase.Enabled = false;
            }
        }

        private void checkBoxServerType_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void CheckBoxPriceEditor_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void CheckBoxVatNonVat_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void CheckBox_InventoryView_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void CheckBox_Non_Vat_Registered_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Features_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CheckBox_CloudBase_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnCloudConfig_Click(object sender, EventArgs e)
        {
            new CloudConfiguration().ShowDialog();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            //if card login is checked
            if (checkBoxCardLogin.Checked)
            {
                Properties.Settings.Default.cardlogin = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.cardlogin = false;
                Properties.Settings.Default.Save();
            }

            //if cloudbase is checked
            if (CheckBox_CloudBase.Checked)
            {
                Properties.Settings.Default.CloudBase = true;
                Properties.Settings.Default.Save();

                btnCloudConfig.Visible = true;
            }
            else
            {
                Properties.Settings.Default.CloudBase = false;
                Properties.Settings.Default.Save();

                btnCloudConfig.Visible = false;
            }

            //if non-vat registered is checked
            if (CheckBox_Non_Vat_Registered.Checked)
            {
                Properties.Settings.Default.vatnonvat = true;
                Properties.Settings.Default.nonvat_registered = true;
                Properties.Settings.Default.Save();

                SQLControl SQL = new SQLControl();
                SQL.Query(@"UPDATE products set is_vatable = 'False',s_discPWD_SC='False',s_PWD_SC_perc=0,s_discAth='False'");
                if (SQL.HasException(true)) return;

                SQL.Query(@"UPDATE product_category set s_discPWD_SC='False',s_PWD_SC_perc=0,s_discAth='False'");
                if (SQL.HasException(true)) return;
            }
            else
            {
                Properties.Settings.Default.nonvat_registered = false;
                Properties.Settings.Default.Save();

                SQLControl SQL = new SQLControl();
                SQL.Query(@"UPDATE products set is_vatable = 'True',s_discPWD_SC='True',s_PWD_SC_perc=20,s_discAth='True'");
                if (SQL.HasException(true)) return;

                SQL.Query(@"UPDATE product_category set s_discPWD_SC='True',s_PWD_SC_perc=20,s_discAth='True'");
                if (SQL.HasException(true)) return;
            }

            //if inventory view is checked
            if (checkBox_InventoryView.Checked)
            {
                Properties.Settings.Default.inventoryproductview = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.inventoryproductview = false;
                Properties.Settings.Default.Save();
            }

            //if VatNonVat is checked
            if (checkBoxVatNonVat.Checked)
            {
                Properties.Settings.Default.vatnonvat = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.vatnonvat = false;
                Properties.Settings.Default.Save();
            }

            //if price editor is checked
            if (checkBoxPriceEditor.Checked)
            {
                Properties.Settings.Default.priceeditor = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.priceeditor = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
