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
    public partial class _Default : Page
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
        public IQueryable<Category> CategoriesListView_GetData()
        {
            var context = new LibrarySystemEntities();

            var categories = context.Categories.Include("Books");

            return categories;
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var textToSearch = this.SearchTb.Text;
                Response.Redirect("Search.aspx?q="+textToSearch);
            }
        }

        protected void LenghtValidate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var searchText = this.SearchTb.Text;

            args.IsValid = searchText.Length < 1000;
        }
    }
}