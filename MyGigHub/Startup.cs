using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyGigHub.Startup))]
namespace MyGigHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
