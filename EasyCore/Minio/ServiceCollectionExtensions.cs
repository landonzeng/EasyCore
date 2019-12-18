using System;
using System.Collections.Generic;
using System.Text;
using EasyCore.Minio.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Minio;

namespace EasyCore.Minio
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMinio(this IServiceCollection services)
        {
            var minioConfig = services.BuildServiceProvider().GetRequiredService<IOptions<MinioConfig>>().Value;
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.TryAddScoped<IMinioRepository>(x => new MinioRepository(minioConfig.Endpoint, minioConfig.AccessKey, minioConfig.SecretKey, minioConfig.Region, minioConfig.SessionToken));

            return services;
        }
    }
}
