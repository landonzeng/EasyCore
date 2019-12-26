using System;
using System.Linq;
using EasyCore.FreeSql.Config;
using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EasyCore.FreeSql.SimpleUseFreeSql
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSimpleFreeSql(this IServiceCollection service)
        {

            var thisFontColor = (int)Console.ForegroundColor;
            var newFontColor = (ConsoleColor)((thisFontColor + 1) > 15 ? 0 : (thisFontColor + 1));


            if (service == null) throw new ArgumentNullException(nameof(service));

            var freeSql = service.BuildServiceProvider().GetRequiredService<IOptions<FreeSqlCollectionConfig>>().Value;
            var config = freeSql.FreeSqlCollections.Where(it => it.Key == "IHRSystem").FirstOrDefault();

            if (config == null) throw new ArgumentNullException(nameof(config));

            //注入FreeSql
            service.AddScoped(f =>
            {
                var log = f.GetRequiredService<ILogger<IFreeSql>>();
                var freeBuilder = new FreeSqlBuilder()
                    .UseAutoSyncStructure(false)
                    .UseConnectionString(config.DataType, config.MasterConnetion)
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

                            log.LogInformation
                            (
                                "\n=================================================================================\n\n" 
                                                            + aop.CommandText + "\n\n"
                                                            + parametersValue + 
                                "\n=================================================================================\n\n"
                            );
                        }

                        log.LogInformation
                        (
                            "\n=================================================================================\n\n"
                                                                            + aop.CommandText +
                            "\n\n=================================================================================\n"
                        );

                        //Console.WriteLine("=================================================================================\n");
                        //Console.ForegroundColor = (ConsoleColor)thisFontColor;
                    });
                if (config.SlaveConnections?.Count > 0)//判断是否存在从库
                {
                    freeBuilder.UseSlave(config.SlaveConnections.Select(x => x.ConnectionString).ToArray());
                }
                var freesql = freeBuilder.Build();
                //我这里禁用了导航属性联级插入的功能
                freesql.SetDbContextOptions(opt => opt.EnableAddOrUpdateNavigateList = false);
                return freesql;
            });

            //注入Uow
            service.AddScoped(f => f.GetRequiredService<IFreeSql>().CreateUnitOfWork());
        }
    }
}
