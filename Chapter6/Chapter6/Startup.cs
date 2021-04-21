using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter6
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory /*,ILogger<Startup> logger */)
        {
            //app.Run(async (context) =>
            //{
            //    logger.LogCritical("LogCritical {0}", context.Request.Path);
            //    logger.LogDebug("LogDebug {0}", context.Request.Path);
            //    logger.LogError("LogError {0}", context.Request.Path);
            //    logger.LogInformation("LogInformation {0}", context.Request.Path);
            //    logger.LogWarning("LogWarning {0}", context.Request.Path);

            //    await context.Response.WriteAsync("Hello World!");
            //});

            //var loggerFactory = LoggerFactory.Create(builder =>
            // {
            //     builder.AddDebug();
            // });
            //ILogger logger = loggerFactory.CreateLogger<Startup>();

            //app.Run(async (context) =>
            //{
            //    logger.LogInformation("Requested Path: {0}", context.Request.Path);
            //    await context.Response.WriteAsync("Hello World!");
            //});


            //app.Run(async (context) =>
            //{
            //    var loggerFactory = LoggerFactory.Create(builder =>
            //    {
            //        builder.AddDebug();
            //        builder.AddConsole();
            //        if (env.IsDevelopment())
            //        {
            //            builder.AddFilter("System", LogLevel.Debug)
            //            .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);

            //        }
            //        // builder.AddDebug();
            //        else
            //        {
            //            builder.AddFilter("System", LogLevel.Debug)
            //                    .SetMinimumLevel(LogLevel.Debug);   // Определение MinimumLevel
            //        }
            //    });
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            //var logger = loggerFactory.CreateLogger("FileLogger");

            //app.Run(async (context) =>
            //{
            //    logger.LogInformation("Processing request {0}", context.Request.Path);
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.UseRouting();
            //app.Use(async (context, next) =>
            //{
            //    Endpoint endpoint = context.GetEndpoint();
            //    if (endpoint == null)
            //    {
            //        Debug.WriteLine("Endpoint: null");
            //        // если конечная точка не определена, завершаем обработку
            //        await context.Response.WriteAsync("Endpoint is not defined");
            //    }
            //    else
            //    {
            //        var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern?.RawText;
            //        Debug.WriteLine($"Endpoint Name: {endpoint.DisplayName}");
            //        Debug.WriteLine($"Route Pattern: {routePattern}");

            //        // если конечная точка определена, передаем обработку дальше
            //        await next();
            //    }
            //});
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/index", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Index!");
            //    });
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

        }
    }
}
