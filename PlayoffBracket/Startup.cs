using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayoffBracket.Startup))]
namespace PlayoffBracket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
