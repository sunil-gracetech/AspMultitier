using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspMultitier
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private EmployeeBusiness businessServices;
        public EmployeeModel model=new EmployeeModel();
        public WebForm1()
        {
            businessServices = new EmployeeBusiness();
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Int32.Parse(Request.QueryString["id"]);
                model = businessServices.GetEmployeeById(id);
            }
        }
    }
}