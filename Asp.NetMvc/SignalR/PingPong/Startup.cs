using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PingPong.Startup))]
namespace PingPong
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
