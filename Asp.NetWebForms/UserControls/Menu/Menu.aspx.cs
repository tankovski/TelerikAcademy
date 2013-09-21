using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Menu
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<MenuLink> items = new List<MenuLink>
            {
                new MenuLink("Telerik","http://telerikacademy.com/"),
                 new MenuLink("TelerikForum","http://forums.academy.telerik.com/")
            };

            this.MenuTest.MenuItems = items;
            this.MenuTest.DataBind();
        }
    }
}