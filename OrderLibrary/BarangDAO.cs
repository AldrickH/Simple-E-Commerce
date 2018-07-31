using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLibrary
{
    public class BarangDAO : IDisposable
    {

        SqlConnection _conn = null;
        SqlTransaction _trans = null;

        public BarangDAO(string connectionString)
        {
            try
            {
                _conn = new SqlConnection(connectionString);
                _conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Barang> GetAllDataBarang(Barang brg = null, int jumlahMIN = 0, int jumlahMAX = 0, int hargaMIN = 0, int hargaMAX = 0)
        {
            List<Barang> listData = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    if (brg == null)
                    {
                        cmd.CommandText = @"select * from barang order by kode";
                    }
                    else
                    {
                        if (jumlahMIN > 0 && jumlahMAX == 0)
                        {
                            cmd.CommandText = @"select * from barang where kode like @kode and nama like @nama and jumlah >= @jumlahMIN order by kode";
                        }
                        else if (jumlahMAX > 0 && jumlahMIN == 0)
                        {
                            cmd.CommandText = @"select * from barang where kode like @kode and nama like @nama and jumlah <= @jumlahMAX order by kode";
                        }
                        else if (jumlahMIN > 0 && jumlahMAX > 0)
                        {
                            cmd.CommandText = @"select * from barang where kode like @kode and nama like @nama and jumlah between @jumlahMIN and @jumlahMAX order by kode";
                        }
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@kode", $"%{brg.Kode}%");
                        cmd.Parameters.AddWithValue("@nama", $"%{brg.Nama}%");
                        cmd.Parameters.AddWithValue("@jumlahMIN", jumlahMIN);
                        cmd.Parameters.AddWithValue("@jumlahMAX", jumlahMAX);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            listData = new List<Barang>();
                            while (reader.Read())
                            {
                                listData.Add(new Barang
                                {
                                    Kode = reader["Kode"].ToString(),
                                    Nama = reader["Nama"].ToString(),
                                    Harga = Convert.ToDecimal(reader["Harga"]),
                                    Jumlah = Convert.ToInt32(reader["Jumlah"]),
                                    Gambar = reader["gambar"] as byte[]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            return listData;
        }

        public Barang GetDataBarangByKode(string kode)
        {
            Barang result = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"select * from barang where kode = @kode", _conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Kode", kode);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                result = new Barang
                                {
                                    Kode = reader["Kode"].ToString(),
                                    Nama = reader["Nama"].ToString(),
                                    Harga = Convert.ToDecimal(reader["Harga"]),
                                    Jumlah = Convert.ToInt32(reader["Jumlah"]),
                                    Gambar = reader["gambar"] as byte[]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int AddBarang (Barang barang)
        {
            int result = 0;
            try
            {
                _trans = _conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand(@"insert into barang values (@kode, @nama, @jumlah, @harga, @gambar)", _conn, _trans))
                { 
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@kode", barang.Kode);
                    cmd.Parameters.AddWithValue("@nama", barang.Nama);
                    cmd.Parameters.AddWithValue("@jumlah", barang.Jumlah);
                    cmd.Parameters.AddWithValue("@harga", barang.Harga);
                    cmd.Parameters.AddWithValue("@gambar", barang.Gambar);
                    result = cmd.ExecuteNonQuery();
                }
                _trans.Commit();
            }
            catch (Exception ex)
            {
                if (_trans != null) _trans.Rollback();
                throw ex;
            }
            finally
            {
                if (_trans != null) _trans.Dispose();
            }
            return result;
        }

        public void UpdateQuantity(Barang temp, int qty)
        {
            int a = temp.Jumlah - qty;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.CommandText = @"update barang set jumlah = @jumlah where kode = @kode";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@jumlah", a);
                    cmd.Parameters.AddWithValue("@kode", temp.Kode);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (_trans != null) _trans.Rollback();
                throw ex;
            }
        }

        public int DeleteBarang(string kode)
        {
            int result = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"delete barang where kode = @kode", _conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@kode", kode);
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public void Dispose()
        {
            if (_conn != null) _conn.Close();
        }
    }
}
