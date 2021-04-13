using System;
using AutoMapper;
using EasyCore.EventBus.Abstractions;
using EasyCore.EventBus.Extensions;
using EasyCore.EventBus.RabbitMQ.Extensions;
using EasyCore.ExceptionlessExtensions;
using EasyCore.ExceptionlessExtensions.Config;
using EasyCore.FreeSql.Config;
using EasyCore.FreeSql.Datas;
using EasyCore.Minio;
using EasyCore.Minio.Config;
using EasyCore.Quartz.Extensions;
using Exceptionless;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.DbContext;
using WebApi.Module;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Configuration Injection

            services.AddOptions();
            services.Configure<FreeSqlCollectionConfig>(Configuration.GetSection("SqlConfig"));
            services.Configure<MinioConfig>(Configuration.GetSection(nameof(MinioConfig)));
            services.Configure<ExceptionlessConfig>(Configuration.GetSection("Exceptionless"));

            #endregion Configuration Injection

            //services.AddLogging();

            services.AddMinio();

            //services.AddSimpleFreeSql();

            services.AddFreeSql<IHRSystem>();
            services.AddFreeSql<IPMWebApi>();

            //services.AddQuartz();

            services.AddExceptionless();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            ////ע��HttpContextAccessor ���Դ�IOC���õ�HttpContext������
            //services.AddHttpContextAccessor();
            //services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddControllers();

            services.AddEventBus(option => { option.UseRabbitMQ(); });
            //����ע��
            //RegisterEventBus(services);

            services.AddMvc(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddFluentValidation();

            //services.ScrutorRegistryService(typeof(IRepositoryKey));
            //services.ScrutorRegistryService(typeof(IServiceKey));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //����404
            ExceptionlessClient.Default.SubmittingEvent += GlobalExceptionless.OnSubmittingEvent;

            app.UseExceptionless(Configuration);

            //����EventBus����
            //ConfigureEventBus(app);
        }

        #region ��������

        /// <summary>
        /// ע�ᶩ���¼�����
        /// </summary>
        /// <param name="services"></param>
        private void RegisterEventBus(IServiceCollection services)
        {
            services.AddScoped<HouseBackTempEventHandler>();
        }

        /// <summary>
        /// ����EventBus����
        /// </summary>
        /// <param name="app"></param>
        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<OperationHouseBackInfoEvent, HouseBackTempEventHandler>();
            eventBus.StartSubscribe();
        }

        #endregion ��������
    }
}