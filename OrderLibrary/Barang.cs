using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLibrary
{
     public class Barang
    {
        public string Kode { get; set; }
        public string Nama { get; set; }
        public int Jumlah { get; set; }
        public decimal Harga { get; set; }
        public byte[] Gambar { get; set; }
    }
}
