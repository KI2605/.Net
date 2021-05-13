using Chapter26.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter26.Controllers
{
    public class HomeController : Controller
    {
        IRepository rep;
        public HomeController(IRepository r)
        {
            rep = r;
        }
        public HomeController() { }
        public IActionResult Index()
        {
            ViewData["Message"] = "Hello world!";
            return View("Index");
        }
        public IActionResult NewIndex()
        {
            return View(rep.GetAll());
        }
        public IActionResult GetUser(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            User user = rep.Get(id.Value);
            if (user == null)
                return NotFound();
            return View(user);
        }

        public IActionResult AddUser() => View();

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                rep.Create(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}