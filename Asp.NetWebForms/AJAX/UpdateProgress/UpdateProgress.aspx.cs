using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpdateProgress
{
    public partial class UpdateProgress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Employee> CountriesGrid_GetData()
        {
            var context = new NORTHWNDEntities();

            var employees = context.Employees;

            return employees;
        }

        protected void EmployeesGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OrdersGrid.DataSource = null;
            this.OrdersGrid.DataBind();
            Thread.Sleep(2000);
            int id = int.Parse(this.EmployeesGrid.SelectedDataKey.Value.ToString());

            var context = new NORTHWNDEntities();
            var orders = context.Orders.Where(o => o.EmployeeID == id).ToList();
            this.OrdersGrid.DataSource = orders;
            this.OrdersGrid.DataBind();
        }

    }
}