using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyCore.DependencyInjection
{
    /// <summary>
    /// Scrutor注入使用
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Scrutor注入使用
        /// </summary>
        /// <param name="services"></param>
        /// <param name="type"></param>
        /// <param name="contextLifetime"></param>
        /// <returns></returns>
        public static IServiceCollection ScrutorRegistryService(this IServiceCollection services, Type type, ServiceLifetime contextLifetime = ServiceLifetime.Scoped)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            //程序入口程序集
            var entryAssembly = Assembly.GetEntryAssembly();
            //再获取程序入口程序集的引用程序集
            var referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
            //合并这些程序集
            var assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);


            if (contextLifetime == ServiceLifetime.Scoped)
            {
                services.Scan(s =>
                {
                    //扫描所有程序集通过接口找相关实现
                    s.FromAssemblies(assemblies).AddClasses(classes => classes.AssignableTo(type))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
                    //这里使用了Scope周期 可以使用 WithLifetime(ServiceLifetime.Singleton)传入其他生命周期来灵活配置
                });
            }
            if (contextLifetime == ServiceLifetime.Singleton)
            {
                services.Scan(s =>
                {
                    s.FromAssemblies(assemblies).AddClasses(classes => classes.AssignableTo(type))
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime();
                });
            }
            if (contextLifetime == ServiceLifetime.Transient)
            {
                services.Scan(s =>
                {
                    s.FromAssemblies(assemblies).AddClasses(classes => classes.AssignableTo(type))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
                });
            }

            return services;
        }
    }
}
