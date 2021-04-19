using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            //            var builder = new ConfigurationBuilder()
            //            .AddInMemoryCollection(new Dictionary<string, string>
            //            {
            //{"firstname", "Tom"},
            //{"age", "31"}
            //            });
            //            AppConfiguration = builder.Build();

            //AppConfiguration = config;

            //var builder = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
            //{
            //    {"color", "blue"},
            //    {"text", "Hello ASP.NET 5"}
            //});
            //AppConfiguration = builder.Build();

            //var builder = new ConfigurationBuilder()?.AddJsonFile("AppCon.json");
            //AppConfiguration = builder.Build();

            //var builder = new ConfigurationBuilder()?.AddXmlFile("conf.xml");
            //AppConfiguration = builder.Build();

            //var builder = new ConfigurationBuilder().AddJsonFile("AppCon.json").AddEnvironmentVariables()
            //    .AddInMemoryCollection(new Dictionary<string, string>
            //{
            //    {"name","Tom"},
            //    {"age","19" }
            //}).AddConfiguration(config);
            //AppConfiguration = builder.Build();

            //var builder = new ConfigurationBuilder().AddJsonFile("project.json");
            //AppConfiguration = builder.Build();

            //var builder = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory());
            //    builder.AddTextFile("config.txt");
            //AppConfiguration = builder.Build();

            //var builder = new ConfigurationBuilder().AddJsonFile("person.json");
            //AppConfiguration = builder.Build();
        }
        public IConfiguration AppConfiguration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            // создание объекта Person по ключам из конфигурации
            //services.Configure<Person>(AppConfiguration);

            //services.Configure<Person>(opt =>
            //{
            //    opt.Age = 22;
            //});

            services.AddDistributedMemoryCache();
            services.AddSession(options=> { options.IdleTimeout = TimeSpan.FromSeconds(30); });
           
        }
        public void Configure(IApplicationBuilder app)
        {
            //AppConfiguration["firstname"] = "alice";
            //AppConfiguration["lastname"] = "simpson";
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"{AppConfiguration["firstname"]} {AppConfiguration["lastname"]} - {AppConfiguration["age"]}");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello world");
            //});


            //var color = AppConfiguration["color"];
            //var text = AppConfiguration["text"];
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            //});

            //app.Run(async (context) =>
            //{
            //    var msg = AppConfiguration["message"];
            //    await context.Response.WriteAsync(msg);
            //});

            //var color = AppConfiguration["color"];
            //var text = AppConfiguration["text:description:data"];
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            //});

            //var color = AppConfiguration["color"];  // определен в файле conf.json
            //string text = AppConfiguration["name"]; // определен в памяти
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            //});

            //string projectJsonContent = GetSectionContent(AppConfiguration);
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("{\n" + projectJsonContent + "}");
            //});

            //var color = AppConfiguration["color"];
            //var text = AppConfiguration["text"];
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            //});

            //var tom = new Person();
            //AppConfiguration.Bind(tom);
            //app.Run(async (context) =>
            //{
            //    string name = $"<p>Name:{tom.Name}</p>";
            //    string age =$"<p>Age:{tom.Age}</p>";
            //    string company = $"<p>Company:{tom.Company?.Title}({tom.Company?.Country})";
            //    string languages= "<p>Languages:</p><ul>";
            //    foreach(var l in tom.Languages)
            //    {
            //        languages += $"<li><p>{l}</p></li>";
            //    }
            //    languages+= "</ul>";
            //    await context.Response.WriteAsync($"{name}{age}{company}{languages}");
            //});


            //Company company = AppConfiguration.GetSection("company").Get<Company>();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"<p>Title: {company.Title}</p><p>Country: {company.Country}</p>");
            //});


            //app.UseMiddleware<PersonMiddleware>();


            //app.Use(async (context, next) =>
            //{
            //    context.Items.Add("text", "Привет мир");
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    context.Response.ContentType = "text/html; charset=utf-8";
            //    if (context.Items.ContainsKey("text"))
            //        await context.Response.WriteAsync($"Текст: {context.Items["text"]}");
            //    else
            //        await context.Response.WriteAsync("Случайный текст");
            //});

            //app.Run(async (context) =>
            //{
            //    if (context.Request.Cookies.ContainsKey("name"))
            //    {
            //        string name = context.Request.Cookies["name"];
            //        await context.Response.WriteAsync($"Hello {name}!");
            //    }
            //    else
            //    {
            //        context.Response.Cookies.Append("name", "Tom");
            //        await context.Response.WriteAsync("Hello World!");
            //    }
            //});

            app.UseSession();
            app.Run(async (context) =>
            {
                if (context.Session.Keys.Contains("person"))
                {
                    Person person = context.Session.Get<Person>("person");
                    await context.Response.WriteAsync($"Hello,{person.Name}, your age is {person.Age}");
                }
                else
                {
                    Person person = new Person { Name = "Fred", Age = 23 };
                    context.Session.Set<Person>("person", person);
                    await context.Response.WriteAsync("Hello World!");
                }

            });
        }
        private string GetSectionContent(IConfiguration configSection)
        {
            string sectionContent = "";
            foreach(var section in configSection.GetChildren())
            {
                sectionContent = "\"" + section.Key + "\":";
                if (section.Value == null)
                {
                    string subSectionContent = GetSectionContent(section);
                    sectionContent += "{\n" + subSectionContent + "},\n";
                }
                else
                {
                    sectionContent += "\"" + section.Value + "\",\n";
                }
            }
            return sectionContent;
        }
    }
}
