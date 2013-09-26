using BlogSystem.Models;
using System;
using System.Linq;

namespace BlogSystem
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new BlogSystemEntities();
            var allNews = db.News.ToList();
            allNews.Reverse();

            NewsRepeater.DataSource = allNews;
            NewsRepeater.DataBind();
        }
    }
}