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
    public partial class FrmAdminInterface : Form
    {

        Akun admin = null;
        List<Penjualan> listData = null;

        public FrmAdminInterface(Akun temp)
        {
            InitializeComponent();
            this.dgvDataBarang.AutoGenerateColumns = this.dgvDataMember.AutoGenerateColumns = false;
            admin = temp;
        }

        private void FrmAdminInterface_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblAdmin.Text = admin.Nama;
                this.pictureBox1.Image = new ImageConverter().ConvertFrom(admin.Pict) as Image;

                using (var dao = new BarangDAO(Setting.GetConnectionString()))
                {
                    this.dgvDataBarang.DataSource = null;
                    this.dgvDataBarang.DataSource = dao.GetAllDataBarang();
                    this.dgvDataBarang.Columns[0].DataPropertyName = nameof(Barang.Kode);
                    this.dgvDataBarang.Columns[1].DataPropertyName = nameof(Barang.Nama);
                    this.dgvDataBarang.Columns[2].DataPropertyName = nameof(Barang.Jumlah);
                    this.dgvDataBarang.Columns[3].DataPropertyName = nameof(Barang.Harga);
                }

                using (var dao = new AkunDAO(Setting.GetConnectionString()))
                {
                    this.dgvDataMember.DataSource = null;
                    this.dgvDataMember.DataSource = dao.GetAllDataAccount();
                    this.dgvDataMember.Columns[0].DataPropertyName = nameof(Akun.Username);
                    this.dgvDataMember.Columns[1].DataPropertyName = nameof(Akun.Nama);
                    this.dgvDataMember.Columns[2].DataPropertyName = nameof(Akun.Total);
                }

                using (var dao = new PenjualanDAO(Setting.GetConnectionString()))
                {
                    this.dgvDataOrder.DataSource = null;
                    listData = dao.SejarahPenjualan(admin, Setting.GetConnectionString());
                    
                    foreach (Penjualan jual in listData)
                    {
                        this.dgvDataOrder.Rows.Add(new string[]
                            {
                                jual.NoOrder.ToString(), jual.Tanggal.ToShortDateString(), jual.DataBarang.Kode,
                                jual.DataBarang.Nama, jual.DataAkun.Nama, jual.DataBarang.Harga.ToString("n0"), jual.Quantity.ToString("n0"), jual.Total.ToString("n0")});     
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvDataBarang.SelectedRows.Count > 0 && MessageBox.Show("Hapus Item Data Terpilih ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var dao = new BarangDAO(Setting.GetConnectionString()))
                    {
                        if (dao.DeleteBarang(this.dgvDataBarang.SelectedRows[0].Cells[0].Value.ToString().Trim()) > 0)
                        {
                            FrmAdminInterface_Load(null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            FrmTambahDataBarang frm = new FrmTambahDataBarang();
            frm.ShowDialog();
            FrmAdminInterface_Load(null, null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvDataBarang.SelectedRows.Count > 0)
            {
                FrmTambahDataBarang frm = new FrmTambahDataBarang();
                    frm.Run(new BarangDAO(Setting.GetConnectionString()).GetDataBarangByKode(this.dgvDataBarang.CurrentRow.Cells[0].Value.ToString()));                   
            }
            FrmAdminInterface_Load(null, null);
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDataBarang_Resize(object sender, EventArgs e)
        {
            this.dgvDataBarang.Columns[0].Width = 24 * this.dgvDataBarang.Width / 100;
            this.dgvDataBarang.Columns[1].Width = 25 * this.dgvDataBarang.Width / 100;
            this.dgvDataBarang.Columns[2].Width = 25 * this.dgvDataBarang.Width / 100;
            this.dgvDataBarang.Columns[3].Width = 25 * this.dgvDataBarang.Width / 100;
        }

        private void dgvDataMember_Resize(object sender, EventArgs e)
        {
            this.dgvDataMember.Columns[0].Width = 33 * this.dgvDataBarang.Width / 100;
            this.dgvDataMember.Columns[1].Width = 33 * this.dgvDataBarang.Width / 100;
            this.dgvDataMember.Columns[2].Width = 33 * this.dgvDataBarang.Width / 100;
        }

        private void txtKodeBarang_Leave(object sender, EventArgs e)
        { 
            this.dgvDataBarang.DataSource = null;
            using (var dao = new BarangDAO(Setting.GetConnectionString()))
            {
                this.dgvDataBarang.DataSource = dao.GetAllDataBarang(new Barang
                {
                    Nama = this.txtNamaBarang.Text.Trim(),
                    Kode = this.txtKodeBarang.Text.Trim(),
                    Gambar = null,
                    Harga = 0,
                    Jumlah = 0,
                }, int.Parse(this.txtJumlahMin.Text, System.Globalization.NumberStyles.AllowThousands), int.Parse(this.txtJumlahMax.Text, System.Globalization.NumberStyles.AllowThousands), int.Parse(this.txtHargaMin.Text, System.Globalization.NumberStyles.AllowThousands), int.Parse(this.txtHargaMax.Text, System.Globalization.NumberStyles.AllowThousands));
            }

            this.dgvDataBarang.Columns[0].DataPropertyName = nameof(Barang.Kode);
            this.dgvDataBarang.Columns[1].DataPropertyName = nameof(Barang.Nama);
            this.dgvDataBarang.Columns[2].DataPropertyName = nameof(Barang.Jumlah);
            this.dgvDataBarang.Columns[3].DataPropertyName = nameof(Barang.Harga);

        }

        private void txtNamaBarang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAngka_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtJumlahHarga_Click(object sender, EventArgs e)
        {
            if (this.txtJumlahMin.Focus() == true)
            {
                this.txtJumlahMin.SelectionStart = this.txtJumlahMin.Text.Length;
            }
            else if (this.txtJumlahMax.Focus() == true)
            {
                this.txtJumlahMax.SelectionStart = this.txtJumlahMax.Text.Length;
            }
            else if (this.txtHargaMin.Focus() == true)
            {
                this.txtHargaMin.SelectionStart = this.txtHargaMin.Text.Length;
            }
            else if (this.txtHargaMax.Focus() == true)
            {
                this.txtHargaMax.SelectionStart = this.txtHargaMax.Text.Length;
            }
        }

        private void txtJumlahHarga_TextChanged(object sender, EventArgs e)
        {
            if (this.txtJumlahMin.Focus() == true)
            {
                if (this.txtJumlahMin.Text != "")
                {
                    this.txtJumlahMin.Text = Convert.ToDecimal(this.txtJumlahMin.Text).ToString("n0");
                }
                else
                {
                    this.txtJumlahMin.Text = "0";
                }
                this.txtJumlahMin.SelectionStart = this.txtJumlahMin.Text.Length;
            }

            else if (this.txtJumlahMax.Focus() == true)
            {
                if (this.txtJumlahMax.Text != "")
                {
                    this.txtJumlahMax.Text = Convert.ToDecimal(this.txtJumlahMax.Text).ToString("n0");
                    this.txtJumlahMax.SelectionStart = this.txtJumlahMax.Text.Length;
                }
                else
                {
                    this.txtJumlahMax.Text = "0";
                }
                this.txtJumlahMax.SelectionStart = this.txtJumlahMax.Text.Length;
            }

            else if (this.txtHargaMin.Focus() == true)
            {
                if (this.txtHargaMin.Text != "")
                {
                    this.txtHargaMin.Text = Convert.ToDecimal(this.txtHargaMin.Text).ToString("n0");
                    this.txtHargaMin.SelectionStart = this.txtHargaMin.Text.Length;
                }
                else
                {
                    this.txtHargaMin.Text = "0";
                }
                this.txtHargaMin.SelectionStart = this.txtHargaMin.Text.Length;
            }

            else if (this.txtHargaMax.Focus() == true)
            {
                if (this.txtHargaMax.Text != "")
                {
                    this.txtHargaMax.Text = Convert.ToDecimal(this.txtHargaMax.Text).ToString("n0");
                    this.txtHargaMax.SelectionStart = this.txtHargaMax.Text.Length;
                }
                else
                {
                    this.txtHargaMax.Text = "0";
                }
                this.txtHargaMax.SelectionStart = this.txtHargaMax.Text.Length;
            }
        }
    }
}
