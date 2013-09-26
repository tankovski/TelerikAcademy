using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlogSystem.Models;

namespace BlogSystem.Admin
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();

            categories.DataSource = db.Categories.ToList();
            categories.DataBind();
        }

        protected void deleteCategory_Click(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            BlogSystemEntities db = new BlogSystemEntities();
            var currCategory = db.Categories.Include("Topics").Include("Topics.Posts").
                FirstOrDefault(c => c.Id == id);

            if (currCategory != null)
            {
                db.Posts.RemoveRange(currCategory.Topics.SelectMany(t => t.Posts));
                db.Topics.RemoveRange(currCategory.Topics);
                db.Categories.Remove(currCategory);
                db.SaveChanges();
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();
            var currCategory = new BlogSystem.Models.Category();

            currCategory.Description = descr.Text;
            currCategory.Name = name.Text;

            if (this.PostImgUpload.HasFile)
            {
                string extension = Path.GetExtension(PostImgUpload.FileName.ToString())
                                        .Trim().ToLower();
                if (extension == ".png" || extension == ".jpg")
                {
                    string fileName = Guid.NewGuid() + "_"
                                    + PostImgUpload.FileName.ToString();
                    this.PostImgUpload.SaveAs(Server.MapPath("~/Images/" + fileName));

                    currCategory.Image = fileName;
                }
            }

            db.Categories.Add(currCategory);
            db.SaveChanges();
            descr.Text = string.Empty;
            name.Text = string.Empty;
        }

        private BlogSystem.Models.Category GetCategory(int id, BlogSystemEntities db)
        {
            var currCategory = db.Categories.FirstOrDefault(t => t.Id == id);
            return currCategory;
        }

        protected void ValidateNameLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var name = this.name.Text;

            args.IsValid = name.Length < 100;
        }
    }
}