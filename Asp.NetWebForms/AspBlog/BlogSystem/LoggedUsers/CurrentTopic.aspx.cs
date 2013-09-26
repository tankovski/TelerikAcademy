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
    public partial class CurrentTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("~/Default.aspx");
            }
        }


        public IQueryable<BlogSystem.Models.Post> CurrentTopicListView_GetData1()
        {
            int id=0;
            try
            {
                id = int.Parse(Request.Params["id"].ToString());
            }
            catch (Exception)
            {
                Response.Redirect("~/Default.aspx");
            }
                var context = new BlogSystemEntities();

                var posts = context.Posts.Include("Topic").Include("AspNetUser").Where(post => post.TopicId == id);

                if (posts.Count() > 0)
                {
                    this.TopicName.InnerText = posts.FirstOrDefault().Topic.Name;
                }


                return posts;
           
           
        }

        protected void ButtonInsertTopic_Click(object sender, EventArgs e)
        {
            this.CurrentTopicListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CurrentTopicListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.CurrentTopicListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void InsertPostBtn_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {
                var postContent = this.PostContent.Text;
                int id = int.Parse(Request.Params["id"]);

                var context = new BlogSystemEntities();

                var author = context.AspNetUsers.FirstOrDefault(user => user.UserName == User.Identity.Name);

                Post post = new Post()
                {
                    PostContent = postContent,
                    AspNetUser = author,
                    TopicId = id
                };

                //if (this.PostImgUpload.HasFile)
                //{
                //    string extension = Path.GetExtension(PostImgUpload.FileName.ToString());
                //    if (extension.Trim().ToLower() == ".png")
                //    {
                //        this.PostImgUpload.SaveAs(Server.MapPath("~/Images/" + PostImgUpload.FileName.ToString()));

                //        Server.MapPath("~/Images/" + PostImgUpload.FileName.ToString());

                //        post.Image = PostImgUpload.FileName.ToString();
                //    }
                //}

                context.Posts.Add(post);
                context.SaveChanges();

                this.PostContent.Text = "";
                this.CurrentTopicListView.DataBind();

            }
        }


    }
}