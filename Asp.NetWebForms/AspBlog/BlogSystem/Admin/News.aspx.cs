using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogSystem.Admin
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var db = new BlogSystemEntities();
            var allNews = db.News.ToList();
            allNews.Reverse();

            NewsRepeater.DataSource = allNews;
            NewsRepeater.DataBind();
        }

        protected void deleteNews_Command(object sender, CommandEventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();
            var id = Convert.ToInt32(e.CommandArgument);
            var currNews = db.News.FirstOrDefault(t => t.Id == id);

            if (currNews != null)
            {
                db.News.Remove(currNews);
                db.SaveChanges();
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();
            var currNews = new BlogSystem.Models.News();

            currNews.Text = text.Text;
            currNews.Title = title.Text;

            if (this.PostImgUpload.HasFile)
            {
                string extension = Path.GetExtension(PostImgUpload.FileName.ToString())
                                        .Trim().ToLower();
                if (extension == ".png" || extension == ".jpg")
                {
                    string fileName = Guid.NewGuid() + "_"
                                        + PostImgUpload.FileName.ToString();
                    this.PostImgUpload.SaveAs(Server.MapPath("~/Images/" + fileName));

                    currNews.Image = fileName;
                }
            }

            db.News.Add(currNews);
            db.SaveChanges();
            text.Text = string.Empty;
            title.Text = string.Empty;
        }
    }
}