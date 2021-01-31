using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Task_Assignment.Startup))]
namespace Task_Assignment
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}