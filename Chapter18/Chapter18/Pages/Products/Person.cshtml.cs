using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter18.Pages.Products
{
    public class PersonModel : PageModel
    {
        public IActionResult OnGet(string name, int age)
        {
            return Content($"Запрошенные данные: name {name} age {age}");
        }
    }
}
