using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrintHello
{
    public partial class PrintHello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PrintName(object sender, EventArgs e)
        {
            try
            {
                string name = this.EnterNameTextBox.Text;
                //this.EnterNameTextBox.Text = "Hello, " + name;
                Response.Write("Hello, "+name);
            }
            catch (Exception)
            {

                 this.EnterNameTextBox.Text = "Invalid input";
            }
        }
    }
}