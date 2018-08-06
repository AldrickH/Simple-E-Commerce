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
                        if (temp.Username.ToLower().Equals("admin"))
                        {
                            FrmAdminInterface frm = new FrmAdminInterface(temp);
                            this.Hide();
                            frm.ShowDialog();

                            FrmLogInMember_Load(null, null);
                            this.Show();
                        }
                        else
                        {
                            FrmUserInterface frm = new FrmUserInterface(temp);
                            this.Hide();
                            frm.ShowDialog();

                            FrmLogInMember_Load(null, null);
                            this.Show();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                this.lblAccountError.Visible = true;
                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
                this.txtUsername.Focus();
            }
        }

        private void linkLblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSignUpMember frm = new FrmSignUpMember();
            this.Hide();
            frm.ShowDialog();

            FrmLogInMember_Load(null, null);
            this.Show();
        }

        private void FrmLogInMember_Load(object sender, EventArgs e)
        {
            this.txtUsername.Text = "";
            this.txtPassword.Text = "";
            this.lblAccountError.Visible = false;
            this.txtUsername.Focus();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
