using VendettaNG.App_Start;
using VendettaNG.ServicioHub;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Owin;
using Ninject;
using Owin;
using Servicios;
using Servicios.Impl;

[assembly: OwinStartup(typeof(Startup))]
namespace VendettaNG.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}