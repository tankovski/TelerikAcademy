using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InformationalAspPage.Startup))]
namespace InformationalAspPage
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
