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
        int tempJumlahBrg = 0;
        decimal tempTotalHrg = 0;

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
                    jual.DataBarang.Nama, jual.DataBarang.Harga.ToString("n0"), jual.Quantity.ToString("n0"), jual.Total.ToString("n0")});

                tempJumlahBrg += jual.Quantity;
                tempTotalHrg += jual.Total;
            }

            this.lblTotalBarangIsi.Text = tempJumlahBrg.ToString("n0");
            this.lblTotalHargaIsi.Text = $"Rp. {tempTotalHrg.ToString("n0")}";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            DSPenjualan ds = new DSPenjualan();

            if (MessageBox.Show("Apakah anda yakin membeli barang ini ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Penjualan jual in listPenjualan)
                {
                    var row = ds.Penjualan.NewPenjualanRow();
                    row.NoOrder = jual.NoOrder;
                    row.NamaBarang = jual.DataBarang.Nama;
                    row.NamaCustomer = jual.DataAkun.Nama;
                    row.Quantity = jual.Quantity.ToString();
                    row.Tanggal = jual.Tanggal.ToShortDateString();
                    row.SubTotal = jual.Total.ToString("n0");
                    row.Total = $"Rp. {tempTotalHrg.ToString("n0")}";
                    ds.Penjualan.AddPenjualanRow(row);

                    _result = new PenjualanDAO(Setting.GetConnectionString()).AddPenjualan(jual) > 0;

                    using (var dao = new BarangDAO(Setting.GetConnectionString()))
                    {
                        dao.UpdateQuantity(jual.DataBarang, jual.Quantity);
                    }

                    using (var dao = new AkunDAO(Setting.GetConnectionString()))
                    {
                        dao.UpdateTotal(jual.DataAkun, jual.Total);
                    }
                }

                FrmReceipt frmReceipt = new FrmReceipt(ds);
               frmReceipt.ShowDialog();


                MessageBox.Show("Order telah diproses.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void dgvDataOrder_Resize(object sender, EventArgs e)
        {
            this.dgvDataOrder.Columns[0].Width = 10 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[1].Width = 10 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[2].Width = 20 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[3].Width = 10 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[4].Width = 20 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[5].Width = 10 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[6].Width = 5 * this.dgvDataOrder.Width / 100;
            this.dgvDataOrder.Columns[7].Width = 15 * this.dgvDataOrder.Width / 100;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

