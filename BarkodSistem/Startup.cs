using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarkodSistem.Startup))]
namespace BarkodSistem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
