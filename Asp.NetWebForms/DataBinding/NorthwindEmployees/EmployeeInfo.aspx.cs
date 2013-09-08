using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindData;

namespace NorthwindEmployees
{
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Id"] == null)
            {
                Response.Redirect("Employees.aspx");
            }
            else
            {
                var context = new NORTHWNDEntities();
                using (context)
                {
                    int id = int.Parse(Request.Params["Id"]);

                    var employee = context.Employees.FirstOrDefault(em => em.EmployeeID == id);
                    this.EmployeeDetails.DataSource = new List<Employee>() { employee };
                    Page.DataBind();
                }
            }
        }
    }
}