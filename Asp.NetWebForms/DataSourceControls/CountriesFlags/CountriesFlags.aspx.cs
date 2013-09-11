using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CountriesData;

namespace CountriesFlags
{
    public partial class CountriesFlags : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CountriesListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.CountriesListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ButtonInsertCountrie_Click(object sender, EventArgs e)
        {
            this.CountriesListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

    }
}