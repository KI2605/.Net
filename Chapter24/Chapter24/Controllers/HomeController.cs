using Chapter24.Models;
using Chapter24.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter24.Controllers
{
    public class HomeController : Controller
    {
        UserService userService;
        public HomeController(UserService service)
        {
            userService = service;
            userService.Initialize();
        }
      //  [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 300)]
      [ResponseCache(CacheProfileName ="Caching")]
        public IActionResult About()
        {
            return View();
        }
        public async Task<IActionResult> Index(int id)
        {
            User user = await userService.GetUser(id);
            if (user != null)
                return Content($"User: {user.Name}");
            return Content("User not found");
        }
    }
}