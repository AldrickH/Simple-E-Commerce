using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_E_Commerce
{
    public partial class FrmReceipt : Form
    {

        DSPenjualan _ds = null;

        public FrmReceipt(DSPenjualan ds)
        {
            InitializeComponent();
            _ds = ds;
        }

        private void FrmReceipt_Load(object sender, EventArgs e)
        {
            if (_ds != null)
            {
                Receipt rpt = new Receipt();
                rpt.SetDataSource(_ds);
                this.crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}
