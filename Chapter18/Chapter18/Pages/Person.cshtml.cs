using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter18.Pages
{
    public class PersonModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public Person person { get; set; }
        public void OnGet()
        {
            Message = "Введите данные";
        }
        public void OnPost()
        {
            Message = $"Имя: {person.Name}  Возраст: {person.Age}";
        }
    }
}
