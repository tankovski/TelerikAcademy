using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TreeView
{
    public partial class TreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TreeView1_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
        {

        }

      

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            
            this.innerXml.Text = this.TreeView1.SelectedNode.Target;

        }
        
    }
}