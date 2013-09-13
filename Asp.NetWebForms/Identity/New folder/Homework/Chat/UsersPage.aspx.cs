using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;

namespace WebFormsTemplate
{
    public partial class Contact : Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Post> usersPosts_GetData()
        {
            var context = new UsersEntities();
            var posts = context.Posts;

            return posts;
        }

        protected void makePostBtn_Click(object sender, EventArgs e)
        {
            var context = new UsersEntities();

            using (context)
            {
                var text = this.usersPostText.Text;
                var user = context.AspNetUsers.FirstOrDefault(u => u.UserName == User.Identity.Name);
                Post post = new Post()
                {
                    Text=text
                };
                user.Posts.Add(post);

                context.SaveChanges();

                this.usersPosts.DataBind();

            }
        }
    }
}