using Chapter20.Filters;
using Chapter20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter20.Controllers
{
    
    [ServiceFilter(typeof(SimpleResourceFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [SimpleHeadFilter(30, "8h6ell3o5wor5ld8")]
        [Whitespace]
        [DateTimeExecutionFilter]
        [CustomExceptionFilter]
        //[IEFilterAttribute]
        public IActionResult Index()
        {
            int x = 0;
            int y = 8 / x;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Get()
        {
            string browser = HttpContext.Request.Headers["User-Agent"].ToString();
            return Content(browser);
        }
    }
}
