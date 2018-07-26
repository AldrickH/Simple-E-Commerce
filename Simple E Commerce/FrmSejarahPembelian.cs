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
    public partial class FrmSejarahPembelian : Form   
    {
        Akun user = null;
        List<Penjualan> listData = null;

        public FrmSejarahPembelian(Akun temp)
        {
            InitializeComponent();
            user = temp;
        }

        private void FrmSejarahPembelian_Load(object sender, EventArgs e)
        {
            using(var dao = new PenjualanDAO(Setting.GetConnectionString()))
            {
                listData = dao.SejarahPenjualan(user, Setting.GetConnectionString());

                foreach (Penjualan jual in listData)
                {
                    this.dgvDataOrder.Rows.Add(new string[]
                    {
                    jual.NoOrder.ToString(), jual.Tanggal.ToShortDateString(), jual.DataAkun.Nama, jual.DataBarang.Kode,
                    jual.DataBarang.Nama, jual.DataBarang.Harga.ToString(), jual.Quantity.ToString(), jual.Total.ToString()});
                }
            }
        }
    }
}
