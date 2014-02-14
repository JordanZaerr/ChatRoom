using Microsoft.AspNet.SignalR;
using Owin;

namespace ChatRoom
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.HubPipeline.AddModule(new ErrorModule());
            app.MapSignalR();
        }
    }
}