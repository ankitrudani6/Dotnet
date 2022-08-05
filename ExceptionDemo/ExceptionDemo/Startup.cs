using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ExceptionDemo
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
            services.AddControllers();
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
                app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
