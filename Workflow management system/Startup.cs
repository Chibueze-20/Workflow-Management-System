using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Workflow_management_system.Startup))]
namespace Workflow_management_system
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
