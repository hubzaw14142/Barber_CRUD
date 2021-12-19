using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(newbarbershop.Startup))]
namespace newbarbershop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
