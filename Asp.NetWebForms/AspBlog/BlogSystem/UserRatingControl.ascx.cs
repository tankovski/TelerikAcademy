using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogSystem
{
    public partial class UserRatingControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<UserModel> DataSource { get; set; }

        public override void DataBind()
        {
            int place = 1;

            foreach (var item in DataSource)
            {
                item.RatingPlace = place;
                place++;
            }

            UserRepeater.DataSource = DataSource;
            UserRepeater.DataBind();

            base.DataBind();
        }
    }
}