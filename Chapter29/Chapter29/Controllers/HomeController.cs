using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter29.Controllers
{
    public class HomeController:Controller
    {
        IHubContext<ChatHub> hub;
        public HomeController(IHubContext<ChatHub> hubContext)
        {
            hub = hubContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task Create(string product, string connectionId)
        {
            await hub.Clients.AllExcept(connectionId).SendAsync("Notify", $"Добавлено: {product} - {DateTime.Now.ToShortTimeString()}");
            await hub.Clients.Client(connectionId).SendAsync("Notify", $"Ваш товар добавлен!");
        }
    }
}

