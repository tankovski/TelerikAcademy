using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegFormGroups
{
    public partial class RegGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate("PersonalInfoGroup");

            if (IsValid)
            {
                this.result.Text = "SUCCESS!";
            }
        }

        protected void PersonalInfoGroupCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.PersonalInfo.Visible = this.PersonalInfoGroupCheckBtn.Checked;
        }

        
    }
}