using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentSystem
{
    public partial class StudentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = this.firstNameTb.Text;
                string lastName = this.lastNameTb.Text;
                string facultyNumber = this.facultyNumberTb.Text;
                string university = this.universitysDropDown.Text;
                var courses = this.coursesList.Items;
                string list = "<ul>";
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i].Selected)
                    {
                        list += "<li><strong>" + Server.HtmlEncode(courses[i].Text) + "</strong></li>";
                    }
                }
                list += "</ul>";
                this.result.Text = "";
                this.result.Text += "<h3>" + Server.HtmlEncode(firstName) +" "+ Server.HtmlEncode(lastName) + "</h3>";
                this.result.Text += "<p> With faculty number <strong>" + Server.HtmlEncode(facultyNumber) + "</strong></p>";
                this.result.Text += "<p> From <strong>" + Server.HtmlEncode(university) + "</strong></p>";
                this.result.Text += "<p> The student is enrolled for: " + list + "</p>";
            }
            catch (Exception)
            {

                this.result.Text = "Invalid params";
            }

        }
    }
}