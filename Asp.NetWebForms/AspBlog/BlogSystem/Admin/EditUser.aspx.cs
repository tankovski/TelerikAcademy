using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogSystem.Admin
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string userId = Request.QueryString["id"];

            //BlogSystemEntities ctx = new BlogSystemEntities();
            //using (ctx)
            //{
            //    var users = ctx.AspNetUsers.Where(usr => usr.Id == userId).ToList();
            //    DetailsViewUser.DataSource = users;
            //    DetailsViewUser.DataBind();
            //}
        }

        protected void ButtonDeleteUser_Click(object sender, EventArgs e)
        {
            string userId = Request.QueryString["id"];

            BlogSystemEntities ctx = new BlogSystemEntities();
            using (ctx)
            {
                var user = ctx.AspNetUsers.FirstOrDefault(usr => usr.Id == userId);
                user.IsActive = false;
                ctx.SaveChanges();
            }
        }

        protected void ButtonRestoreUser_Click(object sender, EventArgs e)
        {
            string userId = Request.QueryString["id"];

            BlogSystemEntities ctx = new BlogSystemEntities();
            using (ctx)
            {
                var user = ctx.AspNetUsers.FirstOrDefault(usr => usr.Id == userId);
                user.IsActive = true;
                ctx.SaveChanges();
            }
        }

        protected void ButtonMakeAdmin_Click(object sender, EventArgs e)
        {
            string userId = Request.QueryString["id"];

            BlogSystemEntities ctx = new BlogSystemEntities();
            
            using (ctx)
            {
                var adminRole = ctx.AspNetRoles.Single(x => x.Name == "Admin");
                var user = ctx.AspNetUsers.FirstOrDefault(usr => usr.Id == userId);

                user.AspNetRoles.Add(adminRole);
                
                ctx.SaveChanges();
            }
        }
    }
}