using EasyCore.DependencyInjection;
using EasyCore.EventBus.Abstractions;
using EasyCore.EventBus.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EasyCore.EventBus.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加事件消息总线
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEventBusBuilder AddEventBus(this IServiceCollection services, Action<IEventBusBuilder> action)
        {
            var service = services.First(x => x.ServiceType == typeof(IConfiguration));
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var builder = new EventBusBuilder(services, configuration);
            action(builder);
            return builder;
        }
        /// <summary>
        /// 添加事件消息总线
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEventBusBuilder AddEventBus(this IServiceCollection services, IConfiguration configuration, Action<IEventBusBuilder> action)
        {
            var builder = new EventBusBuilder(services, configuration);
            action(builder);
            return builder;
        }
        /// <summary>
        /// 添加事件消息总线
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEventBusBuilder AddEventBus(this IEasyBuilder builder, Action<IEventBusBuilder> action)
        {
            return AddEventBus(builder.Services, action);
        }
    }
}