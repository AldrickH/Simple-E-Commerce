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

        string connString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog = SimpleECommerce; Integrated Security = True;";
        AkunDAO daoAkun = null;

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            daoAkun = new AkunDAO(connString);
            List<Akun> listData = daoAkun.GetAllDataAccount();

            foreach (Akun temp in listData)
            {
                if (temp.Username.Equals(txtUsername.Text) && temp.Password.Equals(txtPassword.Text))
                {
                    if (temp.Username.Equals("admin"))
                    {
                        FrmAdminInterface frm = new FrmAdminInterface();
                        frm.Show();
                    }
                    else
                    {
                        FrmUserInterface frm = new FrmUserInterface();
                        frm.Show();
                    }
                } else
                {
                    MessageBox.Show("Please Sign up !");
                }
            }
        }
    }
}
