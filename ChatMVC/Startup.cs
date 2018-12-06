using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatMVC.Startup))]
namespace ChatMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
