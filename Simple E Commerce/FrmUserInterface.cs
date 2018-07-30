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
        List<Penjualan> listPenjualan = null;
        Akun user = null;

        public FrmUserInterface(Akun temp)
        {
            InitializeComponent();
            user = temp;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                listPenjualan = new List<Penjualan>();
                using (PenjualanDAO dao = new PenjualanDAO(Setting.GetConnectionString()))
                {
                    string Nomor = dao.GetNoOrderBerikutnya();
                    foreach (CustomCntrlBrg custom in flowLayoutPnl.Controls)
                    {
                        Barang brg = custom.GetItemBarang();
                        int qty = custom.GetQuantityOrder();
                        //
                        if (qty > 0 && brg.Jumlah > 0)
                        {
                            listPenjualan.Add(new Penjualan
                            {
                                NoOrder = Nomor,
                                DataAkun = user,
                                DataBarang = brg,
                                Quantity = qty,
                                Tanggal = DateTime.Today,
                                Total = qty * brg.Harga
                            });
                            Nomor = $"{(int.Parse(Nomor) + 1).ToString("0000")}";
                        }
                    }
                }

                if (listPenjualan.Capacity > 0)
                {
                    if (new FrmKeranjang().Run(listPenjualan) == true)
                    {
                        this.FrmUserInterface_Load(null, null);
                    }
                }
                else
                {
                    throw new Exception("Maaf anda belum order barang");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmUserInterface_Load(object sender, EventArgs e)
        {
            try
            {
                this.flowLayoutPnl.Controls.Clear();
                this.lblNama.Text = user.Nama;
                this.pbUser.Image = new ImageConverter().ConvertFrom(user.Pict) as Image;

                using (var dao = new BarangDAO(Setting.GetConnectionString()))
                {
                    List<Barang> listBarang = dao.GetAllDataBarang();

                    foreach (var brg in listBarang)
                    {
                        CustomCntrlBrg custom = new CustomCntrlBrg(brg);
                        this.flowLayoutPnl.Controls.Add(custom);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSejarahPembelian_Click(object sender, EventArgs e)
        {
            FrmSejarahPembelian frm = new FrmSejarahPembelian(user);
            frm.Show();
        }
    }
}

