using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace PrintHelloAspAndLocation
{
    public partial class PrintHelloAspAndLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string path = Assembly.GetExecutingAssembly().CodeBase;
            Response.Write("Hello, ASP.NET frtom c#"+"<br/>");
            Response.Write(path);
        }
    }
}