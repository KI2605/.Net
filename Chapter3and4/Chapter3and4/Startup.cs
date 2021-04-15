using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter3and4.Services;


namespace Chapter3and4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

       private IServiceCollection _services;
        public void ConfigureServices(IServiceCollection services)
        {
           _services = services;
            //services.AddTransient<IMessageSender, EmailMessageSender>();
            //services.AddTransient<MessageService>();

            services.AddTransient<IMessageSender>(provider => {

                if (DateTime.Now.Hour >= 12) return new EmailMessageSender();
                return new SmsMessageSender();
            });

            services.AddTransient<MessageService>();
            services.AddTransient<TimeService>();
            services.AddScoped<ICounter, RandomCounter>();
            services.AddScoped<CounterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MessageService messageService, TimeService timeService)
        {
            //app.Run(async context =>
            //{
            //    var sb = new StringBuilder();
            //    sb.Append("<h1>Все сервисы</h1>");
            //    sb.Append("<table>");
            //    sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
            //    foreach (var svc in _services)
            //    {
            //        sb.Append("<tr>");
            //        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
            //        sb.Append($"<td>{svc.Lifetime}</td>");
            //        sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
            //        sb.Append("</tr>");
            //    }
            //    sb.Append("</table>");
            //    context.Response.ContentType = "text/html;charset=utf-8";
            //    await context.Response.WriteAsync(sb.ToString());



            //}
            //);


            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.Run(async (context) =>
            //{
            //    //context.Response.ContentType = "text/html; charset=utf-8";
            //    //await context.Response.WriteAsync(messageService.Send());

            //    //await context.Response.WriteAsync($"Current Time: {timeService?.GetTime()}");

            //    IMessageSender messageSender = context.RequestServices.GetService<IMessageSender>();
            //    context.Response.ContentType = "text/html;charset=utf-8";
            //    await context.Response.WriteAsync(messageSender.Send());
            //});

            // app.UseMiddleware<MessageMiddleware>();


            app.UseMiddleware<CounterMiddleware>();
        }
    }
}
