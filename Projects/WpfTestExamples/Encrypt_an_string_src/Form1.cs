using System;
using System.Windows.Forms;

namespace Encrypt_an_string_src
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            
            EncryptionAlgorithm alg=(EncryptionAlgorithm)cmbMethod.SelectedIndex;

            try
            {
                Encryptor en = new Encryptor(alg, txtPrivateKey.Text);
                txtResult.Text = en.Encrypt(txtString.Text);
                txtIV.Text = Convert.ToBase64String(en.IV);
                btnDecrypt.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbMethod.SelectedIndex = 0;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            EncryptionAlgorithm alg = (EncryptionAlgorithm)cmbMethod.SelectedIndex;

            try
            {
                byte[] IV=Convert.FromBase64String(txtIV.Text);
                Decryptor dec = new Decryptor(alg, IV);
                txtResult.Text = dec.Decrypt(txtResult.Text, txtPrivateKey.Text);
                btnDecrypt.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}