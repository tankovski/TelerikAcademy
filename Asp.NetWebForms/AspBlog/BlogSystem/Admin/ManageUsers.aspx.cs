using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogSystem.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EditUser_Command(object sender, CommandEventArgs e)
        {
            var userId = e.CommandArgument.ToString();

            Response.Redirect("EditUser.aspx?id=" +
                    userId);
        }

    }
}