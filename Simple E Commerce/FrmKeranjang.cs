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
        List<Penjualan> data;

        public FrmKeranjang(List<Penjualan> temp)
        {
            InitializeComponent();
            this.dgvDataOrder.AutoGenerateColumns = false;
            data = temp;
        }

        private void FrmKeranjang_Load(object sender, EventArgs e)
        {
            this.dgvDataOrder.DataSource = data;
            this.dgvDataOrder.Columns[0].DataPropertyName = "Total";
            this.dgvDataOrder.Columns[1].DataPropertyName = "Tanggal";
        }
    }
}
