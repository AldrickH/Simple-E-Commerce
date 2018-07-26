using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrderLibrary 
{
    public class PenjualanDAO : IDisposable
    {
        SqlConnection _conn = null;

        public PenjualanDAO(string connectionString) 
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

        public int GetNoOrderBerikutnya()
        {
            int result = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.CommandText = @"Select Top 1 NoOrder from Penjualan order by NoOrder desc";
                    cmd.Parameters.Clear();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            if(reader.Read())
                            {
                                result = int.Parse(reader["NoOrder"].ToString());
                            }
                        }
                    }
                }

                if (result.Equals(""))
                {
                    result = 0001;
                } else
                {
                    result += 1;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public int AddPenjualan(Penjualan jual)
        {
            int result = 0;
            SqlTransaction trans = null;
            try
            {
                trans = _conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = @"insert into penjualan values (@NoOrder, @Tanggal, @Username, @KodeBarang, @Quantity, @Total)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@NoOrder", jual.NoOrder);
                    cmd.Parameters.AddWithValue("@Tanggal", jual.Tanggal);
                    cmd.Parameters.AddWithValue("@Username", jual.DataAkun.Username);
                    cmd.Parameters.AddWithValue("@KodeBarang", jual.DataBarang.Kode);
                    cmd.Parameters.AddWithValue("@Quantity", jual.Quantity);
                    cmd.Parameters.AddWithValue("@Total", jual.Total);
                    result = cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                throw ex;
            }
            finally
            {
                if (trans != null) trans.Dispose();
            }
            return result;
        }

        public List<Penjualan> SejarahPenjualan(Akun akun, string connString) 
        {
            List<Penjualan> listSejarahPenjualan = null;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.CommandText = @"select * from penjualan where username = @username order by tanggal";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", akun.Username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            listSejarahPenjualan = new List<Penjualan>();
                            while (reader.Read())
                            {
                                listSejarahPenjualan.Add(new Penjualan
                                {
                                    DataAkun = new AkunDAO(connString).GetDataCustomerByUsername(reader["username"].ToString()),
                                    DataBarang = new BarangDAO(connString).GetDataBarangByKode(reader["kodebarang"].ToString()),
                                    NoOrder = int.Parse(reader["noOrder"].ToString()),
                                    Quantity = int.Parse(reader["quantity"].ToString()),
                                    Tanggal = Convert.ToDateTime(reader["Tanggal"].ToString()),
                                    Total = Convert.ToDecimal(reader["Total"])
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

            return listSejarahPenjualan;
        }

        public void Dispose()
        {
            if (_conn != null) _conn.Close();
        }
    }
}
