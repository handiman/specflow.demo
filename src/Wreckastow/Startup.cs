using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Wreckastow.Startup))]

namespace Wreckastow
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}
