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
            return int.Parse(this.txtBoxJumlah.Text, System.Globalization.NumberStyles.AllowThousands);
        }

        private void CustomCntrlBrg_Load(object sender, EventArgs e)
        {
            if (brg != null && brg.Jumlah >= 0)
            {
                this.lblNama.Text = brg.Nama;
                this.lblHarga.Text = $"Rp. { brg.Harga.ToString("n0")}";
                this.lblQty.Text = brg.Jumlah.ToString("n0");
                this.pBox.Image = new ImageConverter().ConvertFrom(brg.Gambar) as Image;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (brg.Jumlah > 0 && Convert.ToDecimal(txtBoxJumlah.Text) < brg.Jumlah)
                txtBoxJumlah.Text = (Convert.ToDecimal(txtBoxJumlah.Text) + 1).ToString("n0");
        }

        private void btnKurang_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtBoxJumlah.Text) > 0)
            {
                txtBoxJumlah.Text = (Convert.ToDecimal(txtBoxJumlah.Text) - 1).ToString("n0");
            }
        }

        private void txtBoxJumlah_TextChanged(object sender, EventArgs e)
        {
            decimal temp = 0;
            if (this.txtBoxJumlah.Text != "")
            {
                temp = Convert.ToDecimal(this.txtBoxJumlah.Text);
                if (temp >= brg.Jumlah)
                {
                    this.txtBoxJumlah.Text = Convert.ToDecimal(brg.Jumlah).ToString("n0");
                }
                else
                {
                    this.txtBoxJumlah.Text = temp.ToString("n0");
                }
                this.txtBoxJumlah.SelectionStart = this.txtBoxJumlah.Text.Length;
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

        private void txtBoxJumlah_Click(object sender, EventArgs e)
        {
            this.txtBoxJumlah.SelectionStart = this.txtBoxJumlah.Text.Length;
        }
    }
}
