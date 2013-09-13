using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionState
{
    public partial class SessionState : System.Web.UI.Page
    {
        private List<string> list = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetInput_Click(object sender, EventArgs e)
        {
            var text = this.Input.Text;
            this.Input.Text = "";
            Session["Text"] += text;
            list.Add(text);

            foreach (var item in list)
            {
                this.Result.Text += item +"<br/>";
            }

            //this.Result.Text = Session["Text"].ToString();
        }
    }
}