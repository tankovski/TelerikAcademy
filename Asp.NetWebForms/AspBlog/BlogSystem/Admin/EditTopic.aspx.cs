using System;
using System.Linq;
using System.Web.UI.WebControls;
using BlogSystem.Models;
using System.IO;

namespace BlogSystem.Admin
{
    public partial class EditTopic : System.Web.UI.Page
    {
        public static int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Id = Convert.ToInt32(Request.QueryString["id"]);

                var currTopic = GetTopic(Id, new BlogSystemEntities());

                if (currTopic != null)
                {
                    name.Text = currTopic.Name;
                    descr.Text = currTopic.Description;
                    if (currTopic.Image == null)
                    {
                        img.Visible = false;
                    }
                    else
                    {
                        img.Src = "~/Images/" + currTopic.Image;
                    }
                }
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();
            var currTopic = GetTopic(Id, db);

            if (currTopic != null)
            {
                currTopic.Description = descr.Text;
                currTopic.Name = name.Text;

                if (this.PostImgUpload.HasFile)
                {
                    string extension = Path.GetExtension(PostImgUpload.FileName.ToString())
                                        .Trim().ToLower();
                    if (extension == ".png" || extension == ".jpg")
                    {
                        string fileName = Guid.NewGuid() + "_"
                                        + PostImgUpload.FileName.ToString();
                        this.PostImgUpload.SaveAs(Server.MapPath("~/Images/" + fileName));

                        currTopic.Image = fileName;
                    }
                }

                db.SaveChanges();
            }
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();
            var currTopic = db.Topics.Include("Posts").
                FirstOrDefault(t => t.Id == Id);

            if (currTopic != null)
            {
                db.Posts.RemoveRange(currTopic.Posts);
                db.Topics.Remove(currTopic);
                db.SaveChanges();
            }
        }

        private BlogSystem.Models.Topic GetTopic(int id, BlogSystemEntities db)
        {
            var currTopic = db.Topics.FirstOrDefault(t => t.Id == id);
            return currTopic;
        }

        protected void ValidateNameLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var name = this.name.Text;

            args.IsValid = name.Length < 100;
        }
    }
}