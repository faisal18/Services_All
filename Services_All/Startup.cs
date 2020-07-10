using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Services_All.Startup))]
namespace Services_All
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
