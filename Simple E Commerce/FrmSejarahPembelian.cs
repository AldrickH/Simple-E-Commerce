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
            using (var dao = new PenjualanDAO(Setting.GetConnectionString()))
            {
                int totalBelanja = 0;
                listData = dao.SejarahPenjualan(user, Setting.GetConnectionString());
                if (listData != null)
                    foreach (Penjualan jual in listData)
                    {
                        this.dgvDataOrder.Rows.Add(new string[]
                        {
                    jual.NoOrder.ToString(), jual.Tanggal.ToShortDateString(), jual.DataBarang.Kode,
                    jual.DataBarang.Nama, jual.DataBarang.Harga.ToString(), jual.Quantity.ToString(), jual.Total.ToString()});

                        totalBelanja += (int)jual.Total;
                    }
                this.lblNominalHarga.Text = totalBelanja.ToString();
            }
        }

        private void dgvDataOrder_Resize(object sender, EventArgs e)
        {
            this.dgvDataOrder.Columns[0].Width = 15 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[1].Width = 15 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[2].Width = 15 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[3].Width = 15 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[4].Width = 15 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[5].Width = 10 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[6].Width = 15 * this.dgvDataOrder.Width / 100;
        }
    }
}
