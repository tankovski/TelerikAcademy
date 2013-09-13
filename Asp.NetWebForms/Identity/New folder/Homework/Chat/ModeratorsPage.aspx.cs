using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsTemplate
{
    public partial class ModeratorsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
                    Text = text
                };
                user.Posts.Add(post);

                context.SaveChanges();

                this.usersPosts.DataBind();

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void usersPosts_UpdateItem(int id)
        {

            var context = new UsersEntities();

            using (context)
            {
                var item = context.Posts.FirstOrDefault(p => p.Id == id);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    context.SaveChanges();

                }
            }

            
        }
    }
}