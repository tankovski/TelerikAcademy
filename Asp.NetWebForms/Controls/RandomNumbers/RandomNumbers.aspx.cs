using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbers
{
    public partial class RandomNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateRandomNum_Click(object sender, EventArgs e)
        {
            try
            {
                int fromNum = int.Parse(this.fromTb.Value);
                int toNum = int.Parse(this.toTb.Value);
                Random randomGenerator = new Random();
                var result = randomGenerator.Next(fromNum, toNum+1);
                Response.Write(result);

            }
            catch (Exception)
            {

                Response.Write("Invalid parameters");
            }
        }
    }
}