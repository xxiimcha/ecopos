using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoPOSv2
{
    public partial class CodePlayGround : Form
    {
        public CodePlayGround()
        {
            InitializeComponent();
        }
        Helper HP = new Helper();

        private void TbTextToEncrypt_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                new Thread(() =>
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        tbEncryptedText.Text = HP.Encrypt(tbTextToEncrypt.Text);
                    }));
                }).Start();
            }
        }

        private void GunaControlBox1_Click(object sender, EventArgs e)
        {
            new DVOptions().Show();

            this.Close();
        }

        private void CodePlayGround_Load(object sender, EventArgs e)
        {
            
        }

        private void TbTextToDecrypt_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                tbDecryptedText.Text = HP.Decrypt(tbTextToDecrypt.Text);
            }
        }
    }
}
