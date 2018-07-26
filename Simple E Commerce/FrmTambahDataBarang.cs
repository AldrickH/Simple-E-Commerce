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
    public partial class FrmTambahDataBarang : Form
    {
        public FrmTambahDataBarang()
        {
            InitializeComponent();
        }

        bool _result = false;

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (this.txtKodeBarang.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, kode barang tidak boleh kosong ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtKodeBarang.Focus();
            }
            else if (this.txtNamaBarang.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, nama barang tidak boleh kosong ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNamaBarang.Focus();
            }
            else if (this.txtJumlah.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, jumlah tidak boleh kosong ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtJumlah.Focus();
            }
            else if (this.txtHarga.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, harga tidak boleh kosong ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtHarga.Focus();
            }
            else if (this.pictureBox.Image == null)
            {
                MessageBox.Show("Sorry, foto tidak boleh kosong ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.pictureBox.Focus();
            }
            else
            {
                try
                {
                    Barang barang = new Barang
                    {
                        Kode = this.txtKodeBarang.Text.Trim(),
                        Nama = this.txtNamaBarang.Text.Trim(),
                        Jumlah = Convert.ToInt32(txtJumlah.Text.Trim()),
                        Harga = Convert.ToDecimal(txtHarga.Text.Trim()),
                        Gambar = new ImageConverter().ConvertTo(pictureBox.Image, typeof(byte[])) as byte[]
                    };
                    _result = new BarangDAO(Setting.GetConnectionString()).AddBarang(barang) > 0;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFd = new OpenFileDialog();
            OpenFd.Filter = "Images only. |*.jpg; *,jpeg; *.png; *.gif;";
            DialogResult dr = OpenFd.ShowDialog();
            pictureBox.Image = Image.FromFile(OpenFd.FileName);
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
