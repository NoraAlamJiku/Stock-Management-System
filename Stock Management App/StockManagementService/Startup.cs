using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StockManagementService.Startup))]
namespace StockManagementService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
