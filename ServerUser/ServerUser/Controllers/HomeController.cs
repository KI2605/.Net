using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerUser.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ServerUser.Controllers
{
    public class HomeController : Controller
    {
        UserContext db;
        public HomeController(UserContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Authentication()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authentication(string nickname,string password)
        {
           foreach(var i in db.Users)
            {
                if (nickname == i.NickName&&password==i.Password)
                {

                    return Ok("Welcome");
                    }
            }
            // return RedirectToAction("Index");
            return Unauthorized("The User is not registered");
        }
        [HttpPost]
        public string Authorization(User user)
        {
            foreach(var i in db.Users)
            {
                if (user.NickName == i.NickName)
                {
                    return "The user with this nickname is already in database";
                }
            }
            User u1 = new User() { NickName =user.NickName , Password = user.Password, IsAdmin = false };
            db.Users.Add(u1);
            db.SaveChanges();
            return "User" + u1.NickName + "has been successfully registered";
            //db.Orders.Add(order);
            //// сохраняем в бд все изменения
            //db.SaveChanges();
            //return "Спасибо, " + order.User + ", за покупку!";
        }
    }
}
