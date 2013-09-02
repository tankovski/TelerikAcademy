using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CoolBlog.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "PostsAltApi",
                routeTemplate: "api/posts/{action}/{sessionKey}",
                defaults: new
                {
                    controller = "posts",
                    sessionKey = RouteParameter.Optional,
                    action = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/users/{userId}/{action}/{sessionKey}",
                defaults: new { controller = "users", userId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "PostsApi",
                routeTemplate: "api/posts/{action}/{id}/{sessionKey}",
                defaults: new {
                        controller = "posts",
                        action = RouteParameter.Optional,
                        id = RouteParameter.Optional,
                        sessionKey = RouteParameter.Optional
                    }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{sessionKey}",
                defaults: new { sessionKey = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
