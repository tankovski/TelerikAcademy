using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindData;

namespace NorthwindEmployees
{
    public partial class Employees : System.Web.UI.Page
    {

        public IList<EmployeeModel> GetEmployees()
        {
            var context = new NORTHWNDEntities();
            using (context)
            {
                var employees =
                    (from employee in context.Employees
                     select new EmployeeModel()
                     {
                         FullName = employee.FirstName + " " + employee.LastName,
                         Id = employee.EmployeeID
                     }).ToList();

                return employees;

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            this.employeesGrid.DataSource = this.GetEmployees();

            Page.DataBind();
        }
    }
}