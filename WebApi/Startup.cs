using System;
using AutoMapper;
using EasyCore.DependencyInjection;
using EasyCore.ExceptionlessExtensions;
using EasyCore.ExceptionlessExtensions.Config;
using EasyCore.FreeSql.Config;
using EasyCore.FreeSql.Datas;
using EasyCore.FreeSql.SimpleUseFreeSql;
using EasyCore.Minio;
using EasyCore.Minio.Config;
using Exceptionless;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using WebApi.DbContext;

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
            #endregion

            //services.AddLogging();

            services.AddMinio();

            //services.AddSimpleFreeSql();

            services.AddFreeSql<IHRSystem>();
            services.AddFreeSql<IPMWebApi>();

            services.AddExceptionless();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            ////注入HttpContextAccessor 可以从IOC中拿到HttpContext的内容
            //services.AddHttpContextAccessor();
            //services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddControllers();

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

            app.UseExceptionless(Configuration);
        }

    }
}
