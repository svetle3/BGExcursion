using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BGExcursion.Startup))]
namespace BGExcursion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
