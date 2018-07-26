using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderLibrary;

namespace Simple_E_Commerce
{
    public partial class CustomCntrlBrg : UserControl
    {
        Barang brg = null;

        public CustomCntrlBrg(Barang temp)
        {
            InitializeComponent();
            brg = temp;
        }

        public Barang GetItemBarang()
        {
            return brg;
        }

        public int GetQuantityOrder()
        {
            int result = 0;
            if (int.TryParse(this.txtBoxJumlah.Text, out int n))
            {
                result = n;
            }
            return result;
        }

        private void CustomCntrlBrg_Load(object sender, EventArgs e)
        {
            if (brg != null)
            {
                this.lblNama.Text = brg.Nama;
                this.lblHarga.Text = brg.Harga.ToString("n0");
                this.lblQty.Text = brg.Jumlah.ToString();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            txtBoxJumlah.Text = (Convert.ToInt32(txtBoxJumlah.Text) + 1).ToString();
        }

        private void btnKurang_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtBoxJumlah.Text) > 0)
            {
                txtBoxJumlah.Text = (Convert.ToInt32(txtBoxJumlah.Text) - 1).ToString();
            }
        }
    }
}
