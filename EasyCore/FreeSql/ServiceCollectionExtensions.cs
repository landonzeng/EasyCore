using EasyCore.FreeSql.Config;
using FreeSql;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyCore.FreeSql
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFreeSql(this IServiceCollection service)
        {

            var thisFontColor = (int)Console.ForegroundColor;
            var newFontColor = (ConsoleColor)((thisFontColor + 1) > 15 ? 0 : (thisFontColor + 1));


            if (service == null) throw new ArgumentNullException(nameof(service));

            var freeSql = service.BuildServiceProvider().GetRequiredService<IOptions<FreeSqlConfig>>().Value;
            //注入FreeSql
            service.AddScoped(f =>
            {
                var log = f.GetRequiredService<ILogger<IFreeSql>>();
                var freeBuilder = new FreeSqlBuilder()
                    .UseAutoSyncStructure(false)
                    .UseConnectionString(freeSql.DataType, freeSql.MasterConnetion)
                    .UseLazyLoading(true)
                    .UseMonitorCommand(aop =>
                    {
                        //Console.ForegroundColor = newFontColor;
                        //Console.WriteLine("=================================================================================\n");
                        //Console.WriteLine(aop.CommandText + "\n");

                        string parametersValue = "";
                        for (int i = 0; i < aop.Parameters.Count; i++)
                        {
                            parametersValue += $"{aop.Parameters[i].ParameterName}:{aop.Parameters[i].Value}" + ";\n";
                        }
                        if (!string.IsNullOrWhiteSpace(parametersValue))
                        {
                            //Console.WriteLine(parametersValue);

                            log.LogInformation("\n=================================================================================\n\n" + aop.CommandText + "\n\n");
                            log.LogInformation("\n" + parametersValue + "\n=================================================================================\n\n");
                        }

                        log.LogInformation("\n=================================================================================\n\n" 
                                                                            + aop.CommandText + 
                                            "\n\n=================================================================================\n");
                        //Console.WriteLine("=================================================================================\n");
                        //Console.ForegroundColor = (ConsoleColor)thisFontColor;
                    });
                if (freeSql.SlaveConnections?.Count > 0)//判断是否存在从库
                {
                    freeBuilder.UseSlave(freeSql.SlaveConnections.Select(x => x.ConnectionString).ToArray());
                }
                var freesql = freeBuilder.Build();
                //我这里禁用了导航属性联级插入的功能
                freesql.SetDbContextOptions(opt => opt.EnableAddOrUpdateNavigateList = false);
                return freesql;
            });

            //注入Uow
            service.AddScoped(f => f.GetRequiredService<IFreeSql>().CreateUnitOfWork());

            //注入HttpContextAccessor 可以从IOC中拿到HttpContext的内容
            service.AddHttpContextAccessor();

            service.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
    }
}
