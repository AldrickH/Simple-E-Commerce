﻿using System;
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
    public partial class FrmUserInterface : Form
    {
        List<Penjualan> listPenjualan = null;
        Akun user = null;

        public FrmUserInterface(Akun temp)
        {
            InitializeComponent();
            user = temp;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                listPenjualan = new List<Penjualan>();
                using (PenjualanDAO dao = new PenjualanDAO(Setting.GetConnectionString()))
                {
                    int Nomor = dao.GetNoOrderBerikutnya();
                    foreach (CustomCntrlBrg custom in flowLayoutPnl.Controls)
                    {
                        Barang brg = custom.GetItemBarang();
                        int qty = custom.GetQuantityOrder();
                        if (qty > 0)
                        {
                            listPenjualan.Add(new Penjualan
                            {
                                NoOrder = Nomor,
                                DataAkun = user,
                                DataBarang = brg,
                                Quantity = qty,
                                Tanggal = DateTime.Today,
                                Total = qty * brg.Harga
                            });
                        }
                        Nomor++;
                    }
                }

                FrmKeranjang frm = new FrmKeranjang(listPenjualan);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmUserInterface_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblNama.Text = user.Nama;

                using (var dao = new BarangDAO(Setting.GetConnectionString()))
                {
                    List<Barang> listBarang = dao.GetAllDataBarang();

                    foreach (var brg in listBarang)
                    {
                        CustomCntrlBrg custom = new CustomCntrlBrg(brg);
                        this.flowLayoutPnl.Controls.Add(custom);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSejarahPembelian_Click(object sender, EventArgs e)
        {
            FrmSejarahPembelian frm = new FrmSejarahPembelian(user);
            frm.Show();
        }
    }
}

