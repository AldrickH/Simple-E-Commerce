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
        Akun user = null;

        public FrmUserInterface(Akun temp)
        {
            InitializeComponent();
            user = temp;
        }

        List<Penjualan> listData = new List<Penjualan>();

        private void btn1_Click(object sender, EventArgs e)
        {
            using (var dao = new BarangDAO(Setting.GetConnectionString()))
            {
                Barang brg = dao.GetDataBarangByKode("0001");
                listData.Add(new Penjualan
                {
                    NoOrder = "0001",
                    Quantity = Convert.ToInt32(textBox1.Text),
                    DataAkun = new Akun { Nama = user.Nama, Password = user.Password, Username = user.Username, Total = user.Total },
                    DataBarang = brg,
                    Tanggal = DateTime.Today,
                    Total = Convert.ToInt32(textBox1.Text) * brg.Harga
                });
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            using (var dao = new BarangDAO(Setting.GetConnectionString()))
            {
                Barang brg = dao.GetDataBarangByKode("0002");
                listData.Add(new Penjualan
                {
                    NoOrder = "0002",
                    Quantity = Convert.ToInt32(textBox1.Text),
                    DataAkun = new Akun { Nama = user.Nama, Password = user.Password, Username = user.Username, Total = user.Total },
                    DataBarang = brg,
                    Tanggal = DateTime.Today,
                    Total = Convert.ToInt32(textBox1.Text) * brg.Harga
                });
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            FrmKeranjang frm = new FrmKeranjang(listData);
            frm.ShowDialog();
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

