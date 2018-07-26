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

                using (var dao = new BarangDAO(Setting.GetConnectionString()))
                {
                    this.dgvDataBarang.DataSource = null;
                    this.dgvDataBarang.DataSource = dao.GetAllDataBarang();
                    this.dgvDataBarang.Columns[0].DataPropertyName = "Kode";
                    this.dgvDataBarang.Columns[1].DataPropertyName = "Nama";
                    this.dgvDataBarang.Columns[2].DataPropertyName = "Jumlah";
                    this.dgvDataBarang.Columns[3].DataPropertyName = "Harga";
                }

                using (var dao = new AkunDAO(Setting.GetConnectionString()))
                {
                    this.dgvDataMember.DataSource = null;
                    this.dgvDataMember.DataSource = dao.GetAllDataAccount();
                    this.dgvDataMember.Columns[0].DataPropertyName = "Username";
                    this.dgvDataMember.Columns[1].DataPropertyName = "Nama";
                    this.dgvDataMember.Columns[2].DataPropertyName = "Total";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvDataBarang.SelectedRows.Count > 0 &&
                MessageBox.Show("Hapus Item Data Terpilih ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        }
    }
}
