using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Truboprovod_V2.Startup))]
namespace Truboprovod_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
