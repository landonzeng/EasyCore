using System;
using System.Collections.Generic;
using System.Text;
using EasyCore.EventBus.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCore.EventBus.Implementation
{
    public class EventBusBuilder : IEventBusBuilder
    {
        public IServiceCollection Services { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public EventBusBuilder(IServiceCollection services, IConfiguration configurationRoot)
        {
            Configuration = configurationRoot;
            Services = services;

            Services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
        }
    }
}