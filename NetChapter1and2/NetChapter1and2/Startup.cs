using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetChapter1and2
{
    public class Startup
    {
        IWebHostEnvironment _env;
        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("us.example.com");
                options.ExcludedHosts.Add("www.example.com");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync($"Application Name: {_env.ApplicationName}");
            //    });
            //});

            //int x = 2;
            //app.Run(async (context) =>
            //{
            //    x = x * 2;  //  2 * 2 = 4
            //    await context.Response.WriteAsync($"Result: {x}");
            //});

            //int x = 5;
            //int y = 8;
            //int z = 0;
            //app.Use(async (context, next) =>
            //{
            //    z = x * y;
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"x * y = {z}");
            //});

            //int x = 2;
            //app.Use(async (context, next) =>
            //{
            //    x = x * 2;
            //    await next.Invoke();
            //    x = x * 2;
            //    await context.Response.WriteAsync($"Result: {x}");
            //});
            //app.Run(async (context) =>
            //{
            //    x = x * 2;
            //    await Task.FromResult(0);
            //});

            // app.Map("/index", Index);
            //app.Map("/about", About);

            //app.MapWhen(context =>
            //{
            //    return context.Request.Query.ContainsKey("id") && context.Request.Query["id"] == "5";
            //}, HandleId);
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Page Not Found");
            //});

            //   app.UseMiddleware<TokenMiddleware>();


            //app.UseToken("123456");
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});


            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.UseMiddleware<ErrorHandlingMiddleware>();
            //app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseMiddleware<RoutingMiddleware>();

            //app.Run(async (context) =>
            //{
            //    context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";

            //    if (env.IsEnvironment("Test")) // Если проект в состоянии "Test"
            //    {
            //        await context.Response.WriteAsync("В состоянии тестирования");
            //    }
            //    else
            //    {
            //        await context.Response.WriteAsync("В процессе разработки или в продакшене");
            //    }
            //});

            //app.UseStaticFiles();   // добавляем поддержку статических файло
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("index.html");
            //app.UseDefaultFiles(options);

            //app.UseDirectoryBrowser();
            //app.UseStaticFiles();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});


            //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),

            //    RequestPath = new PathString("/pages")
            //});
            //app.UseStaticFiles();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //app.UseFileServer(new FileServerOptions
            //{
            //    EnableDirectoryBrowsing = true,
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
            //    RequestPath = new PathString("/pages"),
            //    EnableDefaultFiles = false
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            // обработка ошибок HTTP
            app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

            app.Map("/error", ap => ap.Run(async context =>
            {
                await context.Response.WriteAsync($"Err: {context.Request.Query["code"]}");
            }));

            app.Map("/hello", ap => ap.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Hello ASP.NET Core");
            }));

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}
          
            //app.UseHttpsRedirection();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("About");
            });
        }
        private static void HandleId(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("id is equal to 5");
            });
        }
    }
}
