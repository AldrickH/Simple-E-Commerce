using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrderLibrary
{
    class PenjualanDAO
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
    }
}
