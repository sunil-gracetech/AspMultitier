using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLayer
{
    

  public  class SharedBusinessServices
    {
        private SharedServices services;
        public SharedBusinessServices()
        {
            services = new SharedServices();
        }

        public SqlDataReader GetDepartments()
        {
            return services.GetDepartments();
        }

    }
}
