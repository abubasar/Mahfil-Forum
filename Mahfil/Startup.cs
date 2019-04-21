using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mahfil.Startup))]
namespace Mahfil
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
