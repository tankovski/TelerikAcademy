using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class RegForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AtLeastOneContact_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var username = this.UsernameTb.Text;
            var password = this.PasswordTb.Text;
            var repeatPass = this.RepPasswordTb.Text;
            var firstName = this.FiesrNameTb.Text;
            var lastName = this.LastNameTb.Text;
            var age = this.AgeTb.Text;
            var email = this.EmailTb.Text;
            var address = this.AddressTb.Text;
            var phone = this.PhoneTb.Text;
            bool accept = this.AcceptCb.Checked;

            bool isValid = username.Length != 0 && password.Length != 0 && repeatPass.Length != 0 &&
                firstName.Length != 0 && lastName.Length != 0 && age.Length != 0 && email.Length != 0 &&
                address.Length != 0 && phone.Length != 0 && accept;



            args.IsValid = isValid;


        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                this.result.Text = "SUCCESS!";
            }
        }
    }
}