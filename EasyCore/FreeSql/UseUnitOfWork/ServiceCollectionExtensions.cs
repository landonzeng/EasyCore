using System;
using FreeSql;
using FreeSql.Aop;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text;
using EasyCore.FreeSql.Config;
using System.Linq;
using EasyCore.FreeSql.UseUnitOfWork;

namespace EasyCore.FreeSql.Datas
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 直接从配置文件读取配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        public static void AddFreeSql<T>(this IServiceCollection service)
        {
            service.AddSingleton(f =>
            {
                var current = f.GetRequiredService<IOptions<FreeSqlCollectionConfig>>()
               .Value.FreeSqlCollections.FirstOrDefault(x => x.Key == typeof(T).Name);
                var builder = new FreeSqlBuilder()
                    .UseConnectionString(current.DataType, current.MasterConnetion)
                    .UseAutoSyncStructure(current.IsSyncStructure)
                    .UseMonitorCommand(x =>
                    {
                    },
                    (executed, s) =>
                    {
                        if (current.DebugShowSql)
                        {
                            Console.WriteLine(executed.CommandText);
                        }
                    });
                if (current.SlaveConnections.Count > 0)
                {
                    builder.UseSlave(current.SlaveConnections.Select(x => x.ConnectionString).ToArray());
                }
                var res = builder.Build<T>();
                
                #region //使用FreeSql AOP做对应的业务拓展，有需要自行实现
                //res.GlobalFilter.Apply<IDeleted>(SysConsts.IsDeletedDataFilter, x => !x.IsDeleted);
                //res.GlobalFilter.Apply<IEnabled>(SysConsts.IsEnabledDataFilter, x => x.Enabled == true);
                //res.Aop.ConfigEntity += new EventHandler<ConfigEntityEventArgs>((_, e) =>
                //{
                //    var attrs = e.EntityType.GetCustomAttributes(typeof(IndexAttribute), false);
                //    foreach (var attr in attrs)
                //    {
                //        var temp = attr as IndexAttribute;
                //        e.ModifyIndexResult.Add(new FreeSql.DataAnnotations.IndexAttribute(temp.Name, temp.Fields, temp.IsUnique));
                //    }
                //});
                #endregion

                return res;
            });
            service.AddScoped<IUnitOfWork<T>, UnitOfWork<T>>();
        }
    }
}
