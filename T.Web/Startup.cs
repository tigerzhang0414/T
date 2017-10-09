using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(T.Web.Startup))]
namespace T.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
