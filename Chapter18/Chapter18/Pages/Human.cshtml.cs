using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter18.Pages
{
    public class HumanModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public Person Person { get; set; }
        public void OnGet()
        {
        }
    }
}
