using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HalfMarathon.Startup))]
namespace HalfMarathon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
