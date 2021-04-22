using Chapter10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Countries = new List<string> { "Бразилия", "Аргентина", "Уругвай", "Чили" };
            return View();
        }
        //частичное представление, за рендеринг отвечает PartialView
        public ActionResult GetMessage()
        {
            return PartialView("_GetMessage");
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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string login,string password,string comment)
        {
            string authData = $"Login: {login}   Password: {password}  Comment: {comment}";
            return Content(authData);
        }
        [HttpGet]
        public IActionResult PhoneChoice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PhoneChoice(string[] phones)
        {
            string result = "";
            foreach (string p in phones)
            {
                result += p;
                result += ";";
            }
            result = "Вы выбрали: " + result;
            return Content(result);
        }
    }
}
