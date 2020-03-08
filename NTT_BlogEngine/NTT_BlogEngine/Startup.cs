using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NTT_BlogEngine.Startup))]
namespace NTT_BlogEngine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
