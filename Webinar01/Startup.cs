using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webinar01.Startup))]
namespace Webinar01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
