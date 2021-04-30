using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter18.Pages.Products
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            string url = Url.Page("Person", new { name = "Tom", age = 34 });
            return Redirect(url);
        }
    }
}
