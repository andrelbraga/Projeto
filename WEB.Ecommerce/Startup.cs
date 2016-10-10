using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEB.Ecommerce.Startup))]
namespace WEB.Ecommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
