using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;
using ModelLayer;

namespace AspMultitier
{
    public partial class Default : System.Web.UI.Page
    {
        // private SqlConnection connection;
        private EmployeeBusiness employeeBusiness;
        public string title = "Create Employee";
        private SharedBusinessServices businessServices;

        public Default()
        {
            employeeBusiness = new EmployeeBusiness();
            businessServices = new SharedBusinessServices();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();
                ddl_dept.DataSource = businessServices.GetDepartments();
                ddl_dept.DataBind();
                ddl_dept.Items.Insert(0, new ListItem() { Text = "Select", Value = "" });
            }
        }

        private void LoadEmployees()
        {
            GV_Emp.DataSource = employeeBusiness.GetEmployees();
           
            GV_Emp.DataBind();
            
        }
        protected void btn_connect_Click(object sender, EventArgs e)
        {
            //string con = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            //connection = new SqlConnection(con);
            //connection.Open();
            //if(connection.State==System.Data.ConnectionState.Open)
            //{
            //    Response.Write(" Db Connection success");
            //}
            //else
            //{
            //    Response.Write(" Db Connection not success");
            //}

           
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            EmployeeModel model = new EmployeeModel()
            {
                Name = txt_name.Text,
                Email = txt_email.Text,
                Address = txt_address.Text,
                Salary = Decimal.Parse(txt_salary.Text),
                Department = ddl_dept.SelectedItem.Text,
                Gender = ddl_gender.SelectedItem.Text
               
            };
            if(txt_id.Value!="")
            {
                model.Id = Int32.Parse(txt_id.Value);
                int i=employeeBusiness.UpdateEmployee(model);

                if (i >= 1)
                {
                    txt_message.Text = "Employee updated Successfully !";
                    txt_message.ForeColor = System.Drawing.Color.Green;
                    LoadEmployees();
                }
                else
                {
                    txt_message.Text = "Employee not updated Successfully !";
                    txt_message.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {

            var r=employeeBusiness.CreateEmployee(model);
                if (r >= 1)
                {
                    txt_message.Text = "Employee Created Successfully !";
                    txt_message.ForeColor = System.Drawing.Color.Green;
                    LoadEmployees();
                }
                else
                {
                    txt_message.Text = "Employee not Created Successfully !";
                    txt_message.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            var lbl = gvr.FindControl("lbl_id") as Label;
            // Response.Write(lbl.Text);
            int i=employeeBusiness.DeleteEmployee(Int32.Parse(lbl.Text));
            if (i == 1)
            {
                txt_message.Text = "Employee deleted Successfully !";
                txt_message.ForeColor = System.Drawing.Color.Red;
                LoadEmployees();
            }
            else
            {
                txt_message.Text = "Employee not deleted Successfully !";
                txt_message.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            var lbl = gvr.FindControl("lbl_id") as Label;
           EmployeeModel em=employeeBusiness.GetEmployeeById(Int32.Parse(lbl.Text));
            txt_name.Text = em.Name;
            txt_email.Text = em.Email;
            txt_address.Text = em.Address;
            txt_salary.Text = em.Salary.ToString();
            ddl_gender.SelectedValue = em.Gender;
          //  ddl_dept.SelectedValue = em.Department;
            txt_id.Value = em.Id.ToString();

            

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            var lbl = gvr.FindControl("lbl_id") as Label;
            Response.Redirect("details.aspx?id="+lbl.Text);
        }
    }
}