using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogAndRedirect
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserName"];
            if (cookie != null)
            {
                this.ResponseLabel.Text = "Hello, " + cookie.Value;
            }
            else
            {
                Page.Response.Redirect("Log.aspx");
            }         
        }
    }
}