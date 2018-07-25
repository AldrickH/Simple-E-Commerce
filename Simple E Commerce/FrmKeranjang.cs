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
    public partial class FrmKeranjang : Form
    {
        List<Penjualan> data;

        public FrmKeranjang(List<Penjualan> temp)
        {
            InitializeComponent();
            this.dgvDataOrder.AutoGenerateColumns = false;
            data = temp;
        }

        private void FrmKeranjang_Load(object sender, EventArgs e)
        {
            foreach (Penjualan jual in data)
            {
                this.dgvDataOrder.Rows.Add(new string[]
                {
                    jual.NoOrder, jual.Tanggal.ToShortDateString(), jual.DataAkun.Nama, jual.DataBarang.Kode,
                    jual.DataBarang.Nama, jual.DataBarang.Harga.ToString(), jual.Quantity.ToString(), jual.Total.ToString()});
            }
        }
    }
}
