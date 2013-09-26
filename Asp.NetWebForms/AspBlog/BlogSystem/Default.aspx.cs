using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BlogSystemEntities ctx = new BlogSystemEntities();

            using (ctx)
            {
                var news = ctx.News.OrderByDescending(n => n.Id).Take(5).ToList();
                lvNews.DataSource = news;
                lvNews.DataBind();
            }
        }
    }
}