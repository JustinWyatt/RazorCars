using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RazorCars.Web.Startup))]
namespace RazorCars.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
