using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderLibrary;

namespace Simple_E_Commerce
{
    public partial class FrmSignUpMember : Form
    {
        public FrmSignUpMember()
        {
            InitializeComponent();
        }

        bool _result = false;

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (this.txtNama.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, nama tidak boleh kosong...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNama.Focus();
            }
            else if (this.txtPassword.Text.Trim() == "" && this.txtPassword2.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, password tidak boleh kosong...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNama.Focus();
            }
            else if (this.txtUserID.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, username tidak boleh kosong...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNama.Focus();
            }else if (!this.txtPassword.Text.Trim().Equals(this.txtPassword2.Text.Trim()))
            {
                MessageBox.Show("Sorry, Password anda tidak sama...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPassword.Text = "";
                this.txtPassword2.Text = "";
                this.txtPassword.Focus();
            }
            else
            {
                try
                {
                    Akun akun = new Akun
                    {
                        Username = this.txtUserID.Text.Trim(),
                        Nama = this.txtNama.Text.Trim(),
                        Password = this.txtPassword.Text.Trim(),
                        Pict = new ImageConverter().ConvertTo(pboxPict.Image, typeof(byte[])) as byte[]                  
                    };
                    _result = new AkunDAO(Setting.GetConnectionString()).AddAkun(akun) > 0;
                    MessageBox.Show("Akun telah berhasil terdaftar...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            FrmLogInMember flm = new FrmLogInMember();
            this.Hide();
            flm.ShowDialog();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFd = new OpenFileDialog();
            OpenFd.Filter = "Images only. |*.jpg; *,jpeg; *.png; *.gif;";
            DialogResult dr = OpenFd.ShowDialog();
            pboxPict.Image = Image.FromFile(OpenFd.FileName);
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
