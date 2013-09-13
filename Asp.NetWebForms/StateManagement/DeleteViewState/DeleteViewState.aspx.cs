using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeleteViewState
{
    public partial class DeleteViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RunScript_Click(object sender, EventArgs e)
        {
           
            var text = this.ScriptHolder.Text;
            //<script>alert("ss")</script>
            this.ScriptResult.Text = text;
        }
    }
}