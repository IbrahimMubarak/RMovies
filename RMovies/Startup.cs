using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RMovies.Startup))]
namespace RMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
