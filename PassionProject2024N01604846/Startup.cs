using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PassionProject2024N01604846.Startup))]
namespace PassionProject2024N01604846
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
