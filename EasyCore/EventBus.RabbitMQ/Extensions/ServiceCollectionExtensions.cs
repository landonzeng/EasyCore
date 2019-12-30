﻿using EasyCore.EventBus.Abstractions;
using EasyCore.EventBus.RabbitMQ.Configure;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCore.EventBus.RabbitMQ.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IEventBusBuilder UseRabbitMQ(this IEventBusBuilder builder, string sectionPath = "EventBus:RabbitMQ")
        {
            builder.Services.Configure<EventBusRabbitMqOptions>(builder.Configuration.GetSection(sectionPath));
            builder.Services.AddSingleton<IRabbitMQPersistentConnection, DefaultRabbitMQPersistentConnection>();
            builder.Services.AddSingleton<IEventBus, EventBusRabbitMQ>();
            return builder;
        }
    }
}
