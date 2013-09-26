using System;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using BlogSystem.Models;

namespace BlogSystem.Admin
{
    public partial class EditCategory : System.Web.UI.Page
    {
        public static int Id { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Id = Convert.ToInt32(Request.QueryString["id"]);

                var currCategory = GetCategory(Id, new BlogSystemEntities());

                if (currCategory != null)
                {
                    name.Text = currCategory.Name;
                    descr.Text = currCategory.Description;
                    if (currCategory.Image == null)
                    {
                        img.Visible = false;
                    }
                    else
                    {
                        img.Src = "~/Images/" + currCategory.Image;
                    }
                }
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            BlogSystemEntities db = new BlogSystemEntities();
            var currCategory = GetCategory(Id, db);

            if (currCategory != null)
            {
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

                db.SaveChanges();
                Response.Redirect("~/Admin/ControlPanel.aspx");
            }
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