using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter18.Pages
{
    public class UserModel : PageModel
    {
        List<User> users;
        public User user { get; set; }
        public UserModel()
        {
            users = new List<User>() {
             new User { NickName = "Tom1", Password = "12345678" },
            new User { NickName = "Tom2", Password = "11223344" },
            new User { NickName = "John", Password = "33334444" }
        };
    }
        public IActionResult OnGet(string name,string password)
        {
            user = users.FirstOrDefault(u => u.NickName == name);
            if (user == null)
            {
                return NotFound("Такого пользователя не существует");
            }
            if (user.Password != password)
            {
                return Unauthorized();
            }
            return Page();
        }
    }
}
