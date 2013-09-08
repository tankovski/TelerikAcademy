using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindData;

namespace NorthwindEmployeesWithFormView
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

            if (Request.Params["Id"] == null)
            {
                this.employeesGrid.DataSource = this.GetEmployees();

                Page.DataBind();
            }
            else
            {
                var context = new NORTHWNDEntities();
                using (context)
                {
                    this.employeesGrid.DataSource = this.GetEmployees();

                    int id = int.Parse(Request.Params["Id"]);
                    var employee = context.Employees.FirstOrDefault(em => em.EmployeeID == id);

                    this.FormViewEmployee.DataSource = new List<Employee> { employee };
                    Page.DataBind();

                }
            }

            
        }
    }
}