using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLibrary
{
     public class Penjualan
    {
        public string NoOrder { get; set; }
        public DateTime Tanggal { get; set; }
        public Akun DataAkun { get; set; }
        public Barang DataBarang { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
