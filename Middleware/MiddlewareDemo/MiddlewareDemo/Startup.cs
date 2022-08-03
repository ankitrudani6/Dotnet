using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MiddlewareDemo.Interfaces;
using MiddlewareDemo.Middleware;
using MiddlewareDemo.Models;
using MiddlewareDemo.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MiddlewareDemo
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
            services.AddDbContext<DotnetDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DotnetDB")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIPractice", Version = "v1" });
            });
            services.AddControllers();
            services.AddScoped<IPerson, PersonService>();
            services.AddScoped<IException, ExceptionService>();
            services.AddScoped<IClientConfiguration, ClientConfiguration>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseClientConfigurationMiddleware();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EMployeeAPI"));
            }
            app.UseStatusCodePages();
            app.UseExceptionHandler(options =>
            {
                options.Run(
                   async context =>
                   {
                       context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                       context.Response.ContentType = "text/html";
                       var ex = context.Features.Get<IExceptionHandlerFeature>();
                       if (ex != null)
                       {
                           var exeption = ex.Error;
                           ExceptionLogging exceptionLogging = new ExceptionLogging()
                           {
                               ExceptionMsg = exeption.Message,
                               ExceptionSource = exeption.Source,
                               ExceptionType = exeption.GetType().Name,
                               ExceptionUrl = exeption.TargetSite.Name,
                               Logdate = new DateTime()
                           };
                           var exService = context.RequestServices.GetService<IException>();
                           await exService.AddError(exceptionLogging);
                           var err = $"<h1>Error: {ex.Error.Message}</h1>";
                           await context.Response.WriteAsync(err).ConfigureAwait(false);
                       }

                   });

            });



            app.UseHttpsRedirection();
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
            //    await next();
            //    await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Before Invoke from 2nd app.Use()\n");
            //    await next();
            //    await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
            //});
            //app.UseWelcomePage();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from 1st app.Run()\n");
            //});

            //Enabling directory browsing through Middleware
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/images"
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
