using Microsoft.Owin;
using Owin;
using System.Web.UI;

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
