using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogSystem.Admin
{
    public partial class Topic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                BlogSystemEntities db = new BlogSystemEntities();

                var currTopic = db.Topics.FirstOrDefault(t => t.Id == id);

                if (currTopic != null)
                {
                    name.InnerText = currTopic.Name;
                    descr.InnerText = currTopic.Description;
                    if (currTopic.Image == null)
                    {
                        img.Visible = false;
                    }
                    else
                    {
                        img.Src = "~/Images/" + currTopic.Image;
                    }

                    var allPosts = currTopic.Posts.ToList();
                    posts.DataSource = allPosts;
                    posts.DataBind();
                }
            }
        }
    }
}