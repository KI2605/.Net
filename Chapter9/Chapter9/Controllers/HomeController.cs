using Chapter9.Models;
using Chapter9.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter9.Controllers
{
    public class HomeController : Controller
    {
        

        //получить полный физический путь каталога относительно проекта
        private readonly IWebHostEnvironment _appEnvironment;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;
        }
      
        public IActionResult Index()
        {

           // return RedirectToRoute("default", new { controller = "Home", action = "Area", height = 2, altitude = 20 });
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
        //public IActionResult Area(int altitude, int height)
        //{
        //    double area = altitude * height / 2;
        //    return Content($"Площадь треугольника с основанием {altitude} и высотой {height} равна {area}");
        //}
        [HttpGet]
        public IActionResult Area(int altitude,int height)
        {
            return View();
        }
        [HttpPost]
        public string Area()
        {
            string altitudeString = Request.Form.FirstOrDefault(p => p.Key == "altitude").Value;
            int altitude = Int32.Parse(altitudeString);

            string heightString = Request.Form.FirstOrDefault(p => p.Key == "height").Value;
            int height = Int32.Parse(heightString);

            double square = altitude * height / 2;
            return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
        }
        public VirtualFileResult GetVirtualFile()
        {
            var filepath = Path.Combine("~/Files", "hello.txt");
            return File(filepath, "text/plain", "hello.txt");
        }
        //public string Time([FromServices] ITimeServices timeService)
        //{
        //    return timeService.Time;
        //}
        public string Time()
        {
            {
                ITimeServices timeService = HttpContext.RequestServices.GetService<ITimeServices>();
                return timeService?.Time;
            }
        }
        public JsonResult Check()
        {
            return Json("yes");
        }
       
        [HttpPost]
        public JsonResult getLift(Lift l)
        {
            if (l.Id == 0)
            {
             
                return Json(0);
                
            }
            Lift lift = new Lift { Id = l.Id, Mark = 5 };
            return Json(lift);
        }
        [HttpGet]
        public IActionResult getLift()
        {
            return View();
        }
        public IActionResult GetFile()
        {
            // Путь к файлу
            //Свойство ContentRootPath данного сервиса
            //указывает на физический путь к каталогу проекта.
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files/book.pdf");
            // Тип файла - content-type
            string file_type = "application/pdf";
            // Имя файла - необязательно
            string file_name = "book.pdf";
            return PhysicalFile(file_path, file_type, file_name);
        }
    }
    public class Geometry
    {
        public int Altitude { get; set; } // основание
        public int Height { get; set; } // высота

        public double GetArea() // вычисление площади треугольника
        {
            return Altitude * Height / 2;
        }
    }
    public class Lift
    {
       public int Id { get; set; }
        public int Mark { get; set; }
    }
   
   
}
