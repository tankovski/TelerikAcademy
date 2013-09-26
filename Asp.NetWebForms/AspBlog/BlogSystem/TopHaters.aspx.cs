using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogSystem
{
    public partial class TopHaters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new BlogSystemEntities();
            var found = (from u in db.AspNetUsers
                         orderby u.Posts.Count
                         select new UserModel()
                         {
                             Username = u.UserName,
                             PostsCount = u.Posts.Count
                         }).Take(100).ToList();
            found.Reverse();


            UserRatingControl.DataSource = found;
            UserRatingControl.DataBind();
        }
    }
}