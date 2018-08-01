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
        SqlTransaction _trans = null;

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

        public string GetNoOrderBerikutnya()
        {
            string result = "";
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"Select Top 1 NoOrder from Penjualan order by NoOrder desc", _conn))
                {
                    cmd.Parameters.Clear();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                result = reader["NoOrder"].ToString();
                            }
                        }
                    }
                }

                if (result.Equals(""))
                {
                    result = "0001";
                }
                else
                {
                    result = $"{(int.Parse(result) + 1).ToString("0000")}";
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
            try
            {
                _trans = _conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand(@"insert into penjualan values (@NoOrder, @Tanggal, @Username, @KodeBarang, @Quantity, @Total)", _conn, _trans))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@NoOrder", jual.NoOrder);
                    cmd.Parameters.AddWithValue("@Tanggal", jual.Tanggal);
                    cmd.Parameters.AddWithValue("@Username", jual.DataAkun.Username);
                    cmd.Parameters.AddWithValue("@KodeBarang", jual.DataBarang.Kode);
                    cmd.Parameters.AddWithValue("@Quantity", jual.Quantity);
                    cmd.Parameters.AddWithValue("@Total", jual.Total);
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

        public List<Penjualan> SejarahPenjualan(Akun akun = null, string connString = null, string noOrder = null)
        {
            List<Penjualan> listSejarahPenjualan = null;
            string sqlString = @"select p.NoOrder, p.Tanggal, p.Username, p.Kode, p.Quantity, p.Total from penjualan p inner join akun a on a.username = p.Username inner join barang b on b.Kode = p.Kode";
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    if (akun != null) sqlString += " where p.username = @username";
                    if (noOrder != null) sqlString += " where p.noOrder = @noOrder";

                    cmd.CommandText = sqlString;
                    cmd.Parameters.Clear();

                    if (akun != null) cmd.Parameters.AddWithValue("@username", akun.Username);
                    if (noOrder != null) cmd.Parameters.AddWithValue("@noOrder", $"%{noOrder}%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        listSejarahPenjualan = new List<Penjualan>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                listSejarahPenjualan.Add(new Penjualan
                                {
                                    DataAkun = new AkunDAO(connString).GetDataCustomerByUsername(reader["username"].ToString()),
                                    DataBarang = new BarangDAO(connString).GetDataBarangByKode(reader["kode"].ToString()),
                                    NoOrder = reader["noOrder"].ToString(),
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
