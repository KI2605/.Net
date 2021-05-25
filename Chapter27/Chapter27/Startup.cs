using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter27
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            // подключаем URL Rewriting
            var options = new RewriteOptions()
                    .AddRedirect("(.*)/$", "$1")
                    .AddRewrite("home/index", "home/about", skipRemainingRules: false);
            app.UseRewriter(options);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/home/about", async context =>
                {
                    await context.Response.WriteAsync($"About: {context.Request.Path}");
                });
                endpoints.MapGet("/home/index", async context =>
                {
                    await context.Response.WriteAsync("Home Index Page!");
                });
            });
        }
    }
}