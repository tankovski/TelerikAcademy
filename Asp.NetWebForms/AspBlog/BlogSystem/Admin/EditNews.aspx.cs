using BlogSystem.Models;
using System;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace BlogSystem.Admin
{
    public partial class EditNews : System.Web.UI.Page
    {
        public static int Id { get; set; }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Id = Convert.ToInt32(Request.QueryString["id"]);

                var currNews = GetNews(Id, new BlogSystemEntities());

                if (currNews != null)
                {
                    title.Text = currNews.Title;
                    text.Text = currNews.Text;
                    if (currNews.Image == null)
                    {
                        img.Visible = false;
                    }
                    else
                    {
                        img.Src = "~/Images/" + currNews.Image;
                    }
                }
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();
            var currNews = GetNews(Id, db);

            if (currNews != null)
            {
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

                db.SaveChanges();
            }
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();
            var currNews = db.News.FirstOrDefault(t => t.Id == Id);

            if (currNews != null)
            {
                db.News.Remove(currNews);
                db.SaveChanges();

                Response.Redirect("~/Admin/News.aspx");
            }
        }

        private BlogSystem.Models.News GetNews(int id, BlogSystemEntities db)
        {
            var currNews = db.News.FirstOrDefault(n => n.Id == id);
            return currNews;
        }

        protected void ValidateTitleLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var name = this.title.Text;

            args.IsValid = name.Length < 100;
        }
    }
}