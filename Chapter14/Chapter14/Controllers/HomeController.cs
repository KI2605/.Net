using Chapter14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter14.Controllers
{
    public class HomeController : Controller
    {
        IEnumerable<Company> companies = new List<Company>
        {
        new Company{Id=1,Name="Apple"},
        new Company{Id=2,Name="Samsung" },
        new Company{Id=3,Name="Google"}
        };
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        public IActionResult GetPerson(int id, string name, int age)
        {
            return Content($"id={id}  name={name}  age={age}");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(companies, "Id", "Name");
            return View();
        }
        [HttpPost]
        public string Create(Product product)
        {
            Company company = companies.FirstOrDefault(c => c.Id == product.CompanyId);
            return $"Добавлен новый элемент: {product.Name} ({company?.Name})";
        }
    }
}
