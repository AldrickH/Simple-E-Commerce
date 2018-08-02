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
        Barang brg = null;
        bool _result = false;

        public FrmTambahDataBarang()
        {
            InitializeComponent();
        }

        public bool Run(Barang temp = null)
        {
            brg = temp;
            this.ShowDialog();
            return _result;
        }


        private void FrmTambahDataBarang_Load(object sender, EventArgs e)
        {
            if (brg != null)
            {
                this.pictureBox.Image = new ImageConverter().ConvertFrom(brg.Gambar) as Image;
                this.txtKodeBarang.Text = brg.Kode;
                this.txtKodeBarang.Enabled = false;
                this.txtNamaBarang.Text = brg.Nama;
                this.txtJumlah.Text = brg.Jumlah.ToString();
                this.txtHarga.Text = Convert.ToDecimal(brg.Harga).ToString();
            }
        }
        
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
                        Jumlah = int.Parse(txtJumlah.Text.Trim(), System.Globalization.NumberStyles.AllowThousands ),
                        Harga = Convert.ToDecimal(txtHarga.Text.Trim()),
                        Gambar = new ImageConverter().ConvertTo(pictureBox.Image, typeof(byte[])) as byte[]
                    };

                    if (brg != null)
                    _result = new BarangDAO(Setting.GetConnectionString()).UpdateBarang(barang) > 0;
                    else
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

        private void txtAngka_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {
            if (this.txtHarga.Text != "")
            {
                this.txtHarga.Text = Convert.ToDecimal(this.txtHarga.Text).ToString("n0");
                this.txtHarga.SelectionStart = this.txtHarga.TextLength;
            }
        }

        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {
            if (this.txtJumlah.Text != "")
            {
                this.txtJumlah.Text = Convert.ToDouble(this.txtJumlah.Text).ToString("n0");
                this.txtJumlah.SelectionStart = this.txtJumlah.TextLength;
            }
        }

    }
}
