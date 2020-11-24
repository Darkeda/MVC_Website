using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library_Course_Project.Startup))]
namespace Library_Course_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
