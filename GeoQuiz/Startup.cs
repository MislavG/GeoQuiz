using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeoQuiz.Startup))]
namespace GeoQuiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
