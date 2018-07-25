using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_E_Commerce
{
    public static class Setting
    {
        public static string GetConnectionString()
        {
            return @"Data Source = (localdb)\mssqllocaldb; Initial Catalog = SimpleECommerce; Integrated Security = True;";
        }
    }
}
