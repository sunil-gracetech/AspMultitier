using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DataAccessLayer
{
   public class SharedServices:DbConfig
    {
        public SqlDataReader GetDepartments()
        {
            SqlCommand cmd = new SqlCommand("get_department", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
