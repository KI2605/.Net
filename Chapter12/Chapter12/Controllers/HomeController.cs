using Chapter12.Models;
using Chapter12.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<Phone> phones;
        List<Company> companies;
        public HomeController()
        {
            Company apple = new Company { Id = 1, Name = "Apple", Country = "США" };
            Company microsoft = new Company { Id = 2, Name = "Samsung", Country = "Республика Корея" };
            Company google = new Company { Id = 3, Name = "Google", Country = "США" };
            companies = new List<Company> { apple, microsoft, google };

            phones = new List<Phone>
            {
                new Phone { Id=1, Manufacturer= apple, Name="iPhone X", Price=56000 },
                new Phone { Id=2, Manufacturer= apple, Name="iPhone XZ", Price=41000 },
                new Phone { Id=3, Manufacturer= microsoft, Name="Galaxy 9", Price=9000 },
                new Phone { Id=4, Manufacturer= microsoft, Name="Galaxy 10", Price=40000 },
                new Phone { Id=5, Manufacturer= google, Name="Pixel 2", Price=30000 },
                new Phone { Id=6, Manufacturer= google, Name="Pixel XL", Price=50000 }
            };
        }

        public IActionResult Index(int? companyId)
        {
            //return View();

            // формируем список компаний для передачи в представление
            List<CompanyModel> compModels = companies.
                Select(c => new CompanyModel { Id = c.Id, Name = c.Name }).ToList();
            //добавляем на первое место
            compModels.Insert(0, new CompanyModel { Id = 0, Name = "Все" });
            
            IndexViewModel ivm = new IndexViewModel { Companies = compModels, Phones = phones };
            //если передан id компании, фильтруем список
            if (companyId != null && companyId > 0)
                ivm.Phones = phones.Where(p => p.Manufacturer.Id == companyId);

            return View(ivm);
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
        public IActionResult GetData()
        {
            return View();
        }

        public IActionResult GetData(string[] items)
        {
            string result = "";
            foreach (var item in items)
                result += item + "; ";
            return Content(result);
        }
        [HttpGet]
        public IActionResult GetPhones()
        {
            return View();
        }
        public IActionResult GetPhones(Phone[] phones)
        {
            string result = "";
            foreach (var p in phones)
                result = $"{result}{p.Name} - {p.Price} - {p.Manufacturer?.Name} \n";
            return Content(result);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            string userInfo = $"Id: {user.Id}  Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
            return Content(userInfo);
        }
    }
}
