using System.Web.Mvc;

namespace InformationalAspPage.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_byAuthor",
                "Administration/Admin/AllBooksFromAuthor/{author}",
                new { controller = "Admin",action = "AllBooksFromAuthor"  }
            );

            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}