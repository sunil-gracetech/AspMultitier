using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;
using ModelLayer;

namespace BusinessLayer
{
    public class EmployeeBusiness
    {
        private EmployeeOperation employee;

        public EmployeeBusiness()
        {
            employee = new EmployeeOperation();
        }

        public DataTable GetEmployees()
        {
            return employee.GetEmployees();
        }

        public int CreateEmployee(EmployeeModel model  )
        {
            return employee.CreateEmployee(model);
        }

        public int DeleteEmployee(int id  )
        {
            return employee.DeleteEmployee(id);
        }
        public EmployeeModel GetEmployeeById(int id  )
        {
            return employee.GetEmployeeById(id);
        }

        public int UpdateEmployee(EmployeeModel model)
        {
            return employee.UpdateEmployee(model);
        }
    }
}
