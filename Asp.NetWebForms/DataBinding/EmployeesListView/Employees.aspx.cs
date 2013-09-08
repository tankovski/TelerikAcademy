using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesListView
{
    public partial class Employees : System.Web.UI.Page
    {
        public ICollection<Employee> GetEmployees()
        {
            var context = new NORTHWNDEntities();
            using (context)
            {
                var employees = context.Employees.ToList();

                return employees;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.EmployeesListView.DataSource = this.GetEmployees();

            Page.DataBind();
        }
    }
}