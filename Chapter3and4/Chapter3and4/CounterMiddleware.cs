using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter3and4.Services;
namespace Chapter3and4
{
    public class CounterMiddleware
    {
        private readonly RequestDelegate _next;
        private int i = 0;
       // TimeService _timeService;
        public CounterMiddleware(RequestDelegate next,TimeService timeService)
        {
            _next = next;
         //   _timeService = timeService;
        }
        public async Task Invoke(HttpContext context, CounterService cs, ICounter c, TimeService _timeService)
        {
           
                //context.Response.ContentType = "text/html; charset=utf-8";
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"Запрос {i}; Counter: {c.Value}; Service: {cs.Counter.Value};time: {_timeService?.Time}");
           
        }
    }
}
