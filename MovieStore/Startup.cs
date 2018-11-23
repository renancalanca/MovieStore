using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieStore.Startup))]
namespace MovieStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
