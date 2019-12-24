using AutoMapper;
using EasyCore.DependencyInjection;
using EasyCore.FreeSql;
using EasyCore.FreeSql.Config;
using EasyCore.Minio;
using EasyCore.Minio.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Exceptionless;
using EasyCore.ExceptionlessExtensions.Config;
using EasyCore.ExceptionlessExtensions;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.AspNetCore;

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
            services.Configure<FreeSqlConfig>(Configuration.GetSection("SqlConfig:FreeSqlCollections"));
            services.Configure<MinioConfig>(Configuration.GetSection(nameof(MinioConfig)));
            services.Configure<ExceptionlessConfig>(Configuration.GetSection("Exceptionless"));
            #endregion

            //services.AddLogging();

            services.AddMinio();

            services.AddFreeSql();

            services.AddExceptionless();

            services.ScrutorRegistryService(typeof(IRepositoryKey));

            services.ScrutorRegistryService(typeof(IServiceKey));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddMvc(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
