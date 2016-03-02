﻿using Microsoft.AspNet.SignalR.Hubs;
using Ninject;

namespace VendettaNG.ServicioHub
{
    public class HubActivator : IHubActivator
    {
        private readonly IKernel container;

        public HubActivator(IKernel container)
        {
            this.container = container;
        }

        public IHub Create(HubDescriptor descriptor)
        {
            return (IHub) container.GetService(descriptor.HubType);
        }
    }
}