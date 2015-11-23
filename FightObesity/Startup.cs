using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FightObesity.Startup))]
namespace FightObesity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
