using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogSystem.LoggedUsers
{
    public partial class Topics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("~/Default.aspx");
            }

            
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Topic> AllTopicsListView_GetData()
        {
            var context = new BlogSystemEntities();
            var id = int.Parse(Request.Params["id"]);

            var topics = context.Topics.Include("AspNetUser").Where(topic => topic.CategoryId == id);

            return topics;
        }

        protected void InsertTopicBtn_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {


                var topicTitle = this.TopicTitle.Text;
                var topicDescription = this.TopicDescription.Text;
                int id = int.Parse(Request.Params["id"]);

                var context = new BlogSystemEntities();

                var author = context.AspNetUsers.FirstOrDefault(user => user.UserName == User.Identity.Name);

                var topic = new Topic()
                {
                    CategoryId = id,
                    Name = topicTitle,
                    Description = topicDescription,
                    AspNetUser = author
                };

                if (this.TopicImgUpload.FileName != string.Empty)
                {
                    string extension = Path.GetExtension(TopicImgUpload.FileName.ToString());
                    if (extension.Trim().ToLower() == ".png")
                    {
                        this.TopicImgUpload.SaveAs(Server.MapPath("~/Images/" + TopicImgUpload.FileName.ToString()));

                        Server.MapPath("~/Images/" + TopicImgUpload.FileName.ToString());

                        topic.Image = TopicImgUpload.FileName.ToString();
                    }
                }



                context.Topics.Add(topic);
                context.SaveChanges();

                this.TopicTitle.Text = "";
                this.TopicDescription.Text = "";
                this.AllTopicsListView.DataBind();
            }
        }


        protected void ValidateTitleLenght_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var title = this.TopicTitle.Text;

            args.IsValid = title.Length < 100;

        }
    }
}