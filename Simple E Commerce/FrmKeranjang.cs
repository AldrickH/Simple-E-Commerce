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
        List<Penjualan> listPenjualan = null;
        bool _result = false;

        public FrmKeranjang()
        {
            InitializeComponent();
            this.dgvDataOrder.AutoGenerateColumns = false;
        }

        public bool Run(List<Penjualan> temp)
        {
            listPenjualan = temp;
            this.ShowDialog();
            return _result;
        }

        private void FrmKeranjang_Load(object sender, EventArgs e)
        {
            foreach (Penjualan jual in listPenjualan)
            {
                this.dgvDataOrder.Rows.Add(new string[]
                {
                    jual.NoOrder.ToString(), jual.Tanggal.ToShortDateString(), jual.DataAkun.Nama, jual.DataBarang.Kode,
                    jual.DataBarang.Nama, jual.DataBarang.Harga.ToString(), jual.Quantity.ToString(), jual.Total.ToString()});
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            foreach (Penjualan jual in listPenjualan)
            {
                _result = new PenjualanDAO(Setting.GetConnectionString()).AddPenjualan(jual) > 0;

                MessageBox.Show(jual.DataBarang.Kode);
                using (var dao = new BarangDAO(Setting.GetConnectionString()))
                {
                    dao.UpdateQuantity(jual.DataBarang, jual.Quantity);
                }
            }
            MessageBox.Show("Order telah diproses.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}

