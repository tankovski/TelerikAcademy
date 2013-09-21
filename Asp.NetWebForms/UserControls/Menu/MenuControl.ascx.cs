using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Menu
{
    [System.ComponentModel.DefaultBindingProperty("MenuItems")]
    public partial class MenuControl : System.Web.UI.UserControl
    {
        public MenuControl()
        {
           
        }

        public IEnumerable<MenuLink> MenuItems
        {
            get { return (IEnumerable<MenuLink>)this.MenuListBox.DataSource; }
            set { this.MenuListBox.DataSource = value; }
        }

        public Color FontColor
        {
            get
            {
                return this.MenuListBox.ForeColor;
            }
            set
            {
                this.MenuListBox.ForeColor = value;
                
            }
        }

        public string FontFamily
        {
            get { return this.MenuListBox.Font.ToString(); }
            set { this.MenuListBox.Style.Add("font-family", value); }
        }

        public override void DataBind()
        {
            this.MenuListBox.DataBind();

            base.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            foreach (var item in this.MenuItems)
            {
                item.FontColor = this.FontColor;
                
            }
            this.DataBind();
        }
    }
}