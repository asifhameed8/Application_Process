using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Serilog;
using System.Collections.Generic;
using Hahn.ApplicatonProcess.December2020.Domain.Services;
using Hahn.ApplicatonProcess.December2020.Data.Repositories.Interfaces;
using Hahn.ApplicatonProcess.December2020.Data.Repositories.Base;
using Hahn.ApplicatonProcess.December2020.Data.UOW;
using Swashbuckle.Examples;

namespace Hahn.ApplicatonProcess.December2020.Web
{
    public class Startup
    {
        private const string SQLSERVER_CONNECTION_STRING_KEY = @"AppDbContext";
        private const string OPEN_API_TITLE = @"Hahn.ApplicatonProcess.December2020 API v1";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();


            services.Configure<FormOptions>(options => {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //Register services
            ServicesModule.Register(services);
 services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            // ASP.NET Core DI
            services.AddScoped<ApplicationContext, ApplicationContext>();
            //services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString(SQLSERVER_CONNECTION_STRING_KEY)));
            services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase(databaseName: "HaunDb"));
            services.AddControllersWithViews();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //Fluent Validator
            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = OPEN_API_TITLE, Version = "v1" });
                //c.OperationFilter<ExamplesOperationFilter>();
            });
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", OPEN_API_TITLE);
                });
                
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            app.UseCors("CorsPolicy");
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
