using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace BlogSystem
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            NavigationMenuControl.OnDataBoundCallback = (() =>
            {
                if (Context.User.IsInRole("Admin"))
                {
                    var cpItem = new MenuItem();
                    cpItem.Text = "<span class='navbar-text menuItem'>Control Panel</span>";
                    cpItem.NavigateUrl = "~/Admin/ControlPanel.aspx";
                    NavigationMenuControl.GetMenu.Items[0].ChildItems.Add(cpItem);

                    var muItem = new MenuItem();
                    muItem.Text = "<span class='navbar-text menuItem'>Manage Users</span>";
                    muItem.NavigateUrl = "~/Admin/ManageUsers.aspx";
                    NavigationMenuControl.GetMenu.Items[0].ChildItems[3].ChildItems.Add(muItem);

                    var niItem = new MenuItem();
                    niItem.Text = "<span class='navbar-text menuItem'>News management</span>";
                    niItem.NavigateUrl = "~/Admin/News.aspx";
                    NavigationMenuControl.GetMenu.Items[0].ChildItems[3].ChildItems.Add(niItem);
                }
                else
                {

                }
            });

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            //"~/Admin/ControlPanel.aspx"
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            string username = Context.User.Identity.Name;
            BlogSystemEntities ctx = new BlogSystemEntities();
            using (ctx)
            {
                var user = ctx.AspNetUsers.FirstOrDefault(usr => usr.UserName == username);
                if (user != null)
                {
                    if (!user.IsActive)
                    {
                        Context.GetOwinContext().Authentication.SignOut();
                        Response.Redirect("~/Account/Login.aspx");
                    }
                }
            }
        }

        protected void RenderComplete(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }



    }

}