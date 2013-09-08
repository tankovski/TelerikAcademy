using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HtmlEscaping
{
    public partial class HtmlEscaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void printTextBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string inputText = this.textInputTb.Text;
                this.resultTb.Text = inputText;
                this.resultLabel.Text = Server.HtmlEncode(inputText);
            }
            catch (Exception)
            {
                 Response.Write("Error");
            }
        }
    }
}