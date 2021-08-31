using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class EmployeeOperation:DbConfig
    {
        public DataTable GetEmployees()
        {
            string query = "select* from employees";
            using (SqlDataAdapter cmd = new SqlDataAdapter(query, connection))
            {
                //if (connection.State == ConnectionState.Closed)
                //  connection.Open();
                DataTable ds = new DataTable();
                cmd.Fill(ds);
                cmd.Dispose();
                return ds;
            }
 
        }

        public int CreateEmployee(EmployeeModel employee) {

            SqlCommand cmd = new SqlCommand("insert_employee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);
            cmd.Parameters.AddWithValue("@dept", employee.Department);
            cmd.Parameters.AddWithValue("@email", employee.Email);
            cmd.Parameters.AddWithValue("@gender", employee.Gender);
            cmd.Parameters.AddWithValue("@address", employee.Address);
            string org_id="";
                
            cmd.Parameters.Add("@orgid", SqlDbType.VarChar,100);
            cmd.Parameters["@orgid"].Direction = ParameterDirection.Output;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            org_id=(string)cmd.Parameters["@orgid"].Value;
            int create = (int)dr[0];

            return create;
        }



        public int DeleteEmployee(int id)
        {
            SqlCommand cmd = new SqlCommand("emp_operation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@action", 1);
             if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int i = (int)dr["completed"];          
            return 1;
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            SqlCommand cmd = new SqlCommand("emp_operation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@action", 4);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            EmployeeModel model = new EmployeeModel()
            {
                Id = (int)dr["id"],
                Name = dr["name"].ToString(),
                Email = dr["email"].ToString(),
                Address = dr["address"].ToString(),
                Department = dr["dept"].ToString(),
                Gender = dr["gender"].ToString(),
                Salary = (decimal)dr["salary"],
                Emp_Id = dr["emp_id"].ToString()

            };
            return model;
        }


        public int UpdateEmployee(EmployeeModel employee)
        {

            SqlCommand cmd = new SqlCommand("emp_operation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);
            cmd.Parameters.AddWithValue("@dept", employee.Department);
            cmd.Parameters.AddWithValue("@email", employee.Email);
            cmd.Parameters.AddWithValue("@gender", employee.Gender);
            cmd.Parameters.AddWithValue("@address", employee.Address);
            cmd.Parameters.AddWithValue("@id", employee.Id);
            cmd.Parameters.AddWithValue("@action", 2);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int update = (int)dr[0];

            return update;
        }

    }
}
