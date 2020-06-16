using EasyCore.FreeSql.Config;
using EasyCore.FreeSql.Datas;
using EasyCore.Quartz.DbContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCore.Quartz.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddQuartz(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddFreeSql<IQuartzDB>();

            var freeSql = services.BuildServiceProvider().GetRequiredService<IOptions<FreeSqlCollectionConfig>>().Value;
            var config = freeSql.FreeSqlCollections.Where(it => it.Key == "IQuartzDB").FirstOrDefault();
            if (config == null)
            {
                throw new ArgumentException("Quartz的数据库配置异常，请检查appsettings.json是否存在FreeSql的QuartDB的配置，例：\n\"\"SqlConfig\":{\"FreeSqlCollections\":[{\"Key\":\"IQuartzDB\",\"MasterConnetion\":\"Server=.;Initial Catalog=QuartzDB;User ID=sa;Password=1234;MultipleActiveResultSets=true;\",\"DataType\":1,\"IsSyncStructure\":\"true\"}]}");
            }
            services.TryAddScoped<IScheduleManage, ScheduleManage>();
        }
    }
}