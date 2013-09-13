using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebFormsTemplate.Models;

namespace WebFormsTemplate.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Moderato"))
                {
                    Response.Redirect("../ModeratosPage.aspx");
                }
                else if (User.IsInRole("Admin"))
                {
                    Response.Redirect("../AdminsPage.aspx");
                }
                else
                {
                    Response.Redirect("../UsersPage.aspx");
                }

            }         
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            var manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
            ApplicationUser u = new ApplicationUser()
            { 
                UserName = userName,
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text,
                DisplayName=this.FirstName.Text+" "+this.LastName.Text

            };
            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
            if (result.Success) 
            {
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}