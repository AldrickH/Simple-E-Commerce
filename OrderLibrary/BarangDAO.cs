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

        public List<Barang> GetAllDataBarang()
        {
            List<Barang> listData = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.CommandText = @"select * from barang order by kode";

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
        public List<Barang> GetFilter(Barang barang)
        {
            List<Barang> listData = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    
                    cmd.Connection = _conn;
                    cmd.CommandText = @"select * from barang where kode line @kode and nama like @nama and jumlah like @jumlah and harga like @harga";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue(@"" ,barang.Kode);
                    cmd.Parameters.AddWithValue(@"" , barang.Nama);
                    cmd.Parameters.AddWithValue(@"" , barang.Harga);
                    cmd.Parameters.AddWithValue(@"" , barang.Jumlah);

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
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.CommandText = @"select * from barang where kode = @kode";
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
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.Transaction = _trans;
                    cmd.CommandText = @"insert into barang values (@kode, @nama, @jumlah, @harga, @gambar)";
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

        public int DeleteBarang(string kode)
        {
            int result = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.Transaction = _trans;
                    cmd.CommandText = @"delete barang where kode = @kode";
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
