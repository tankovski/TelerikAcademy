using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterProject.Startup))]
namespace TwitterProject
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
