using Chapter17.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;
        BukoContext db;
        public HomeController(BukoContext context)
        {

            db = context;
            if (!db.Services.Any())
            {

                Service dogs = new Service { Name = "Funny Dogs", Description = "Let's have some fun", ImageLink = "/asd.png" };
                Service ski = new Service { Name = "Ski School", Description = "Ваша самая большая мечта чтобы ребенок или Вы встали на лыжи? Ski School любит воплощать заветные мечты своих гостей.", ImageLink = "h:\root\\home\\ikolopatin-001\\www\\bukovel\\skichool.png" };
                db.Services.AddRange(dogs, ski);
                db.SaveChanges();
            }
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
        [HttpGet]
        //[Route("Bukovel/GetServices")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await db.Services.ToListAsync();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Register(User user)
        {
           // await db.Users.ToListAsync();
            bool s;
            foreach (var i in db.Users) {
                if (i.NickName==user.NickName)
                {
                    s = false;
                    return Json(s);
                    
                }
            }
            User u1 = new User() { NickName = user.NickName, Password = user.Password, IsAdmin = false };
            db.Users.Add(u1);
            await db.SaveChangesAsync();
            s = true;
            return Json(s);
        }
        [HttpGet]
        public IActionResult AddServiceReview()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddServiceReview(ServiceReview s)
        {
            foreach (var j in db.Users.ToList())
            {
                if (j.NickName == s.User.NickName)
                {
                    foreach (var i in db.Services.ToList())
                    {
                        if (i.Name == s.Service.Name)
                        {
                            ServiceReview s1 = new ServiceReview { ServiceId = i.Id, Mark = s.Mark, Service = i, Review = "",User=j,UserId=j.Id };
                            //await db.ServiceReviews.ToListAsync();
                            //foreach (var j in db.ServiceReviews)
                            //{
                            //    j.ServiceId = s.ServiceId;
                            //    j.Mark = s.Mark;
                            //    //j.Service = from sc in db.Services
                            //    //            where sc.Id = 
                            //    //            select sc;
                            //    j.Service = i;
                            db.ServiceReviews.Add(s);
                            db.SaveChanges();
                            return Content("good");
                            //}

                        }
                    }
                }
            }
                return Content("unable");
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int ?id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
       public JsonResult InfoService(string name)
        {
            foreach(var i in db.Services)
            {
                if (name == i.Name)
                {
                    Service s = new Service { Name = i.Name, Description = i.Description, ImageLink = i.ImageLink, Reviews = i.Reviews, Mark = i.Mark };
                    return Json(s);
                }
            }
            return Json("there is no service with this name in database");
        }
        
        
    }
}
