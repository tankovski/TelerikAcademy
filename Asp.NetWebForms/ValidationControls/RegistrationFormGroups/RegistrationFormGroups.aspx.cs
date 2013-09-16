using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationFormGroups
{
    public partial class RegistrationFormGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate("PersonalInfoGroup");
            Page.Validate("AddressInfoGroup");

            if (IsValid)
            {
                Response.Write("SUCCESS");
            }
        }

        protected void PersonalInfoGroupCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.PersonalInfo.Visible = this.PersonalInfoGroupCheckBtn.Checked;
        }

        protected void AddressInfoCb_CheckedChanged(object sender, EventArgs e)
        {
            this.AddressInfo.Visible = this.AddressInfoCb.Checked;
        }
    }
}