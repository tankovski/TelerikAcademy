using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var query = Request.Params["q"];
            this.SearchHeader.InnerText = "Search Results for Query : " + query;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Book> SearchResultsListView_GetData()
        {
            var context = new LibrarySystemEntities();
            var query = Request.Params["q"];
            if (query.Length > 0)
            {
                var books = context.Books
                .Where(book => book.Title.ToLower().Contains(query.ToLower()) ||
                    book.Author.ToLower().Contains(query.ToLower()));

                return books.OrderBy(b=>b.Title).ThenBy(b=>b.Author);
            }
            else
            {
                var books = context.Books;

                return books.OrderBy(b => b.Title).ThenBy(b => b.Author);
            }
        }
    }
}