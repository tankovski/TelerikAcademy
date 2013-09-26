using Error_Handler_Control;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class BookDetails : System.Web.UI.Page
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
        public Book BookDetailsListView_GetData()
        {
            int id=0;
            try
            {
                id = int.Parse(Request.Params["id"]);
            }
            catch (Exception)
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid Id argument");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                Response.Redirect("Default.aspx");
            }

            var context = new LibrarySystemEntities();
            var book = context.Books.Find(id);
            return book;
        }
    }
}