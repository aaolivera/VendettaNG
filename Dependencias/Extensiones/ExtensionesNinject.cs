using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Dependencias.Extensiones
{
    public static class ExtensionesNinject
    {
        public static object ConfigurationManager { get; private set; }


        internal static void BindChannelFactory<TChannel>(this NinjectModule module, string endpointConfigurationName, IEndpointBehavior behavior = null)
        {
            module.Bind<ChannelFactory<TChannel>>()
                .ToMethod(context => CreateChannelFactory<TChannel>(endpointConfigurationName, behavior))
                .InSingletonScope()
                .OnDeactivation(CloseCommunicationObject);

            module.Bind<TChannel>()
                .ToMethod(context => context.Kernel.Get<ChannelFactory<TChannel>>().CreateChannel())
                .InRequestScope()
                .OnDeactivation(channel => CloseCommunicationObject((ICommunicationObject)channel));
        }

        private static ChannelFactory<TChannel> CreateChannelFactory<TChannel>(string endpointConfigurationName, IEndpointBehavior behavior)
        {
            var factory = new ChannelFactory<TChannel>(endpointConfigurationName);

            if (behavior != null)
            {
                factory.Endpoint.Behaviors.Add(behavior);
            }
            return factory;
        }

        internal static void BindWorkflowChannelFactory<TChannel>(this NinjectModule module)
        {
            module.Bind<ChannelFactory<TChannel>>()
                .ToMethod(context => new ChannelFactory<TChannel>(new BasicHttpBinding("CommonBinding")))
                .InSingletonScope()
                .OnDeactivation(CloseCommunicationObject);

            module.Bind<TChannel>()
                .ToMethod(context =>
                {
                    var uri = (string)context.Parameters.First(p => p.Name == "uri").GetValue(context, null);
                    return context.Kernel.Get<ChannelFactory<TChannel>>().CreateChannel(new EndpointAddress(uri));
                })
                .InRequestScope()
                .OnDeactivation(channel => CloseCommunicationObject((ICommunicationObject)channel));
        }

        

        private static void CloseCommunicationObject(ICommunicationObject comObject)
        {
            try
            {
                if (comObject.State != CommunicationState.Faulted)
                {
                    comObject.Close();
                }
            }
            catch
            {
                try
                {
                    comObject.Abort();
                }
                catch
                {
                }
            }
        }
    }
}
