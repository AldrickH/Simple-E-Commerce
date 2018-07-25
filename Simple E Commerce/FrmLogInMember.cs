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
    public partial class FrmLogInMember : Form
    {
        public FrmLogInMember()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var daoAkun = new AkunDAO(Setting.GetConnectionString()))
                {
                    Akun temp = daoAkun.GetDataCustomerByUsername(txtUsername.Text);

                    if (temp.Password.Equals(txtPassword.Text))
                    {
                        if (temp.Username.Equals("admin"))
                        {
                            FrmAdminInterface frm = new FrmAdminInterface(temp);
                            this.Hide();
                            frm.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            FrmUserInterface frm = new FrmUserInterface(temp);
                            this.Hide();
                            frm.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        throw new Exception("Password yang anda masukkan salah");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSignUpMember frm = new FrmSignUpMember();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}
