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
    public partial class EditPost : System.Web.UI.Page
    {
        public static int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Id = Convert.ToInt32(Request.QueryString["id"]);
                BlogSystemEntities db = new BlogSystemEntities();
                var currPost = GetPost(Id, db);

                if (currPost != null)
                {
                    content.Text = currPost.PostContent;
                    if (currPost.Image == null)
                    {
                        img.Visible = false;
                    }
                    else
                    {
                        img.Src = "~/Images/" + currPost.Image;
                    }
                }
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();
            var currPost = GetPost(Id, db);

            if (currPost != null)
            {
                currPost.PostContent = content.Text;

                if (this.PostImgUpload.HasFile)
                {
                    string extension = Path.GetExtension(PostImgUpload.FileName.ToString())
                                        .Trim().ToLower();
                    if (extension == ".png" || extension == ".jpg")
                    {
                        string fileName = currPost.PostContent.Take(10) + "_" + DateTime.Now.ToLongTimeString()
                                            + PostImgUpload.FileName.ToString();
                        this.PostImgUpload.SaveAs(Server.MapPath("~/Images/" + fileName));

                        currPost.Image = fileName;
                    }
                }

                db.SaveChanges();
            }
        }
        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();
            var currPost = GetPost(Id, db);

            if (currPost != null)
            {
                db.Posts.Remove(currPost);
                db.SaveChanges();
            }
        }

        private BlogSystem.Models.Post GetPost(int id, BlogSystemEntities db)
        {
            var currPost = db.Posts.FirstOrDefault(t => t.Id == Id);
            return currPost;
        }
    }
}