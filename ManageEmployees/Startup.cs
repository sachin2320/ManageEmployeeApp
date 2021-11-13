using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageEmployees.Startup))]
namespace ManageEmployees
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
