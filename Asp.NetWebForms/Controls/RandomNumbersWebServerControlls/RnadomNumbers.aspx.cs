using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbersWebServerControlls
{
    public partial class RnadomNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int fromNum = int.Parse(this.FromTb.Text);
                int toNum = int.Parse(this.ToTb.Text);
                Random randomGenerator = new Random();
                int number = randomGenerator.Next(fromNum, toNum+1);
                Response.Write(number);

            }
            catch (Exception)
            {
                Response.Write("Invalid parameters!");
            }
        }
    }
}