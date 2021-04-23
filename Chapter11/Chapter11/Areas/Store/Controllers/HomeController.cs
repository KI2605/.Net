using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter11.Areas.Store.Controllers
{
        [Area("Store")]
        public class HomeController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }
    }
