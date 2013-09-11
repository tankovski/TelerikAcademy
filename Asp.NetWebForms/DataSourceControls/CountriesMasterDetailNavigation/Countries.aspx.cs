using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CountriesData;

namespace CountriesMasterDetailNavigation
{
    public partial class Countries : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TownsListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.TownsListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ButtonInsertTown_Click(object sender, EventArgs e)
        {
            this.TownsListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CountriesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            var context = new CountriesEntities1();
            using (context)
            {
                var country = new Country()
                {
                    Name = ViewState["Name"].ToString(),
                    Population = int.Parse(ViewState["Population"].ToString()),
                    LanguageId = int.Parse(ViewState["Language"].ToString()),
                    ContinentId = int.Parse(ViewState["ContinentId"].ToString())
                };
                context.Countries.Add(country);
                context.SaveChanges();
                this.CountriesGrid.DataBind();

                ViewState["Name"] = "";
                ViewState["Population"] = "";
                ViewState["Language"] = "";
                ViewState["ContinentId"] = "";

            }


        }

        protected void CountryNameInsertTb_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            ViewState["Name"] = tb.Text;
        }

        protected void CountryPopulationBind_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var text = tb.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {

                ViewState["Population"] = int.Parse(text);
            }
        }

        protected void LanguageId_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var text = tb.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {

                ViewState["Language"] = int.Parse(text);
            }
        }

        protected void CountinentId_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var text = tb.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {

                ViewState["ContinentId"] = int.Parse(text);
            }
        }


    }
}