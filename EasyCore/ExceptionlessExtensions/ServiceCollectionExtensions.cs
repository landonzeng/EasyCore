using System;
using System.Collections.Generic;
using System.Text;
using EasyCore.ExceptionlessExtensions.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace EasyCore.ExceptionlessExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddExceptionless(this IServiceCollection service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            var config = service.BuildServiceProvider().GetRequiredService<IOptions<ExceptionlessConfig>>().Value;

            if (string.IsNullOrWhiteSpace(config.ApiKey))
            {
                throw new Exception("\nExceptionless 配置异常，请检查appsettings.json是否存在Exceptionless的配置，例：\n\"Exceptionless\": \n{\n\"ApiKey\": \"\",\n\"ServerUrl\": \"\"\n}");
            }
            service.TryAddScoped<ILoggerHelper, ExceptionlessLogger>();

        }
    }
}
