using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter20.Filters
{
    public class SimpleHeadFilter : Attribute, IResourceFilter
    {
        int _id;
        string _token;
        public SimpleHeadFilter(int id, string token)
        {
            _id = id;
            _token = token;
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Id", _id.ToString());
            context.HttpContext.Response.Headers.Add("Token", _token);
        }
    }
}
