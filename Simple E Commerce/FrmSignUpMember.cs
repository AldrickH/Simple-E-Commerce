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
        string connString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog = SimpleECommerce; Integrated Security = True;";

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (this.txtNama.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, nama tidak boleh kosong...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNama.Focus();
            }
            else if (this.txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, password tidak boleh kosong...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNama.Focus();
            }
            else if (this.txtUserID.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, username tidak boleh kosong...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNama.Focus();
            }
            else
            {
                try
                {
                    Akun akun = new Akun
                    {
                        Username = this.txtUserID.Text.Trim(),
                        Nama = this.txtNama.Text.Trim(),
                        Password = this.txtPassword.Text.Trim()
                    };
                    _result = new AkunDAO(connString).AddAkun(akun) > 0;
                    MessageBox.Show("Akun telah berhasil terdaftar...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //FrmLogInMember frm = new FrmLogInMember();
                    //this.Close();
                    //frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
