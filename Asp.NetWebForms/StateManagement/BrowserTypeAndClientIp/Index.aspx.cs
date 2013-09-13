using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrowserTypeAndClientIp
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ipAdress = HttpContext.Current.Request.UserHostAddress; 
                //Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

            Response.Write("IP adress - " + ipAdress + "<br/>");
            Response.Write("Browser Type: " + Request.Browser.Type);
        }
    }
}