using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogSystem.Startup))]
namespace BlogSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
