using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CareAlz.Startup))]
namespace CareAlz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
