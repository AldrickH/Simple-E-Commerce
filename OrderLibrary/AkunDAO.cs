using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLibrary
{
    public class AkunDAO : IDisposable
    {

        SqlConnection _conn = null;

        public AkunDAO(string connectionString)
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

        public List<Akun> GetAllDataAccount()
        {
            List<Akun> listData = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.CommandText = @"select * from akun order by username";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            listData = new List<Akun>();
                            while (reader.Read())
                            {
                                listData.Add(new Akun
                                {
                                    Username = reader["username"].ToString(),
                                    Nama = reader["Nama"].ToString(),
                                    Password = reader["Password"].ToString(),
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
            return listData;
        }

        public Akun GetDataCustomerByUsername(string username)
        {
            Akun result = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.CommandText = @"select * from akun Where username = @username";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                result = new Akun
                                {
                                    Username = reader["username"].ToString(),
                                    Nama = reader["Nama"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Total = Convert.ToDecimal(reader["Total"])
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

        public void Dispose()
        {
            if (_conn != null) _conn.Close();
        }
    }
}

