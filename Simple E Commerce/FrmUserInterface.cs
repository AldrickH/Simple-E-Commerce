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
    public partial class FrmUserInterface : Form
    {
        public FrmUserInterface()
        {
            InitializeComponent();
        }

        string connString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog = SimpleECommerce; Integrated Security = True;";

        private void FrmUserInterface_Load(object sender, EventArgs e)
        {
            try
            {
                using (var dao = new BarangDAO(connString))
                {
                    List<Barang> listData = dao.GetAllDataBarang();

                    foreach(Barang temp in listData)
                    {
                        if(temp.Kode.Equals("0001"))
                        {
                            this.lblBarang1.Text = temp.Jumlah.ToString();
                        }
                        else if (temp.Kode.Equals("0002"))
                        {
                            this.lblBarang2.Text = temp.Jumlah.ToString();
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
