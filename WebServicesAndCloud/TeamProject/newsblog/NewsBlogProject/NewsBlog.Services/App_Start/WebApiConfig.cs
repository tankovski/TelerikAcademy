using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NewsBlog.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
               name: "Users",
               routeTemplate: "api/Users/{action}/{sessionKey}",
               defaults: new { controller = "Users", sessionKey = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "Comments",
                routeTemplate: "api/Comments/{action}/{sessionKey}/{id}",
                defaults: new { controller = "Comments",action=RouteParameter.Optional ,id = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
                name: "SubComments",
                routeTemplate: "api/SubComments/{action}/{sessionKey}/{id}",
                defaults: new { controller = "SubComments", action = RouteParameter.Optional, id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Articles",
                routeTemplate: "api/Articles/create/{sessionKey}",
                defaults: new { controller = "Articles",action="create"}
            );

            config.Routes.MapHttpRoute(
                name: "ArticlesWithId",
                routeTemplate: "api/Articles/{action}/{id}",
                defaults: new { controller = "Articles"}
            );

            config.Routes.MapHttpRoute(
                name: "ArticlesDelete",
                routeTemplate: "api/Articles/Delete/{sessionKey}/{id}",
                defaults: new { controller = "Articles", action = "Delete" }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{sessionKey}",
                defaults: new { sessionKey = RouteParameter.Optional }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
