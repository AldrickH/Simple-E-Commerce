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
            if (brg != null && brg.Jumlah >= 0)
            {
                this.lblNama.Text = brg.Nama;
                this.lblHarga.Text = brg.Harga.ToString("n0");
                this.lblQty.Text = brg.Jumlah.ToString();
                this.pBox.Image = new ImageConverter().ConvertFrom(brg.Gambar) as Image;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (brg.Jumlah > 0 && Convert.ToInt32(txtBoxJumlah.Text) < brg.Jumlah)
                txtBoxJumlah.Text = (Convert.ToInt32(txtBoxJumlah.Text) + 1).ToString();
        }

        private void btnKurang_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtBoxJumlah.Text) > 0)
            {
                txtBoxJumlah.Text = (Convert.ToInt32(txtBoxJumlah.Text) - 1).ToString();
            }
        }

        private void txtBoxJumlah_TextChanged(object sender, EventArgs e)
        {
            int temp = 0;
            if (this.txtBoxJumlah.Text != "")
            {
                temp = Convert.ToInt32(this.txtBoxJumlah.Text);
                if (temp >= brg.Jumlah)
                {
                    this.txtBoxJumlah.Text = Convert.ToInt32(brg.Jumlah).ToString();
                }
                else
                {
                    this.txtBoxJumlah.Text = temp.ToString();
                }
                this.txtBoxJumlah.Select(txtBoxJumlah.Text.Length, 0);
            }
            else
            {
                txtBoxJumlah.Text = "0";
            }
        }

        private void txtBoxJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
