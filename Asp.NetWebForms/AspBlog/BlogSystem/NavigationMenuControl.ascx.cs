using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogSystem
{
    public partial class NavigationMenuControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuControl.DataSourceID = this.DataSourceID;
        }

        public string DataSourceID { get; set; }

        public Action OnDataBoundCallback { private get; set; }

        public MenuItemCollection Items
        {
            get
            {
                return this.MenuControl.Items;
            }
        }

        public Menu GetMenu
        {
            get { return this.MenuControl; }
        }

        protected void MenuControl_DataBound(object sender, EventArgs e)
        {
            OnDataBoundCallback.Invoke();
        }


        protected void NavigationMenuControl_PreRender()
        {
            
        }
    }
}