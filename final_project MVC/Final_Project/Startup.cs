using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Final_Project.Startup))]
namespace Final_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
