using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataAccessLayer
{
    public class DbConfig
    {
        internal SqlConnection connection;
        public DbConfig()
        {
            string con = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            connection = new SqlConnection(con);
        }

  

    }
}
