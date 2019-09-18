using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PralnaDemo.Startup))]
namespace PralnaDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
