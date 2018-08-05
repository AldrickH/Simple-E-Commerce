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

        public List<Akun> GetAllDataAccount(Akun akn = null)
        {
            List<Akun> listData = null;
            string sqlString = @"select * from akun";
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if(akn != null)
                    {
                        sqlString += " where nama like @nama and username like @username";
                    }
                    sqlString += " order by username";

                    cmd.CommandText = sqlString;
                    cmd.Connection = _conn;

                    if(akn != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@nama", $"%{akn.Nama}%");
                        cmd.Parameters.AddWithValue("@username", $"%{akn.Username}%");            
                    }

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
                                    Total = Convert.ToDecimal(reader["Total"]),
                                    Pict = reader["Pict"] as byte []                                    
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
                using (SqlCommand cmd = new SqlCommand(@"select * from akun Where username = @username", _conn))
                {
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
                                    Total = Convert.ToDecimal(reader["Total"]),
                                    Pict = reader["Pict"] as byte[]
                                    
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

        public bool CheckAkunByUsername(string username)
        {
            bool result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"select username from akun Where username = @username", _conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                result = true;
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

        public void UpdateTotal(Akun temp, decimal total)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"update akun set total = @total where username = @username", _conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@total", temp.Total += total);
                    cmd.Parameters.AddWithValue("@username", temp.Username);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddAkun (Akun akun)
        {
            int result = 0;
            SqlTransaction trans = null;
            try
            {
                trans = _conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand(@"insert into akun values (@username, @nama, @password, @total, @pict)", _conn, trans))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", akun.Username);
                    cmd.Parameters.AddWithValue("@nama", akun.Nama);
                    cmd.Parameters.AddWithValue("@password", akun.Password);
                    cmd.Parameters.AddWithValue("@total", akun.Total);
                    cmd.Parameters.AddWithValue("@pict", akun.Pict);
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

        public void Dispose()
        {
            if (_conn != null) _conn.Close();
        }
    }
}

