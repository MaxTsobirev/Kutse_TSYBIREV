using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kutse_TSYBIREV.Startup))]
namespace Kutse_TSYBIREV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
