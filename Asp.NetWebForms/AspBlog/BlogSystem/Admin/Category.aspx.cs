using System;
using System.Linq;
using BlogSystem.Models;

namespace BlogSystem.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                BlogSystemEntities db = new BlogSystemEntities();

                var currCategory = db.Categories.FirstOrDefault(c => c.Id == id);

                if (currCategory != null)
                {
                    name.InnerText = currCategory.Name;
                    descr.InnerText = currCategory.Description;
                    if (currCategory.Image == null)
                    {
                        imgCategory.Visible = false;
                    }
                    else
                    {
                        imgCategory.Src = "~/Images/" + currCategory.Image;
                    }

                    var allTopics = currCategory.Topics.ToList();
                    topics.DataSource = allTopics;
                    topics.DataBind();
                }
            }
        }
    }
}