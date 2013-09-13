using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsTemplate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Moderator"))
                {
                    Response.Redirect("ModeratorsPage.aspx");
                }
                else if (User.IsInRole("Admin"))
                {
                    Response.Redirect("AdminsPage.aspx");
                }
                else
                {
                    Response.Redirect("UsersPage.aspx");
                }

            }         
        }
    }
}