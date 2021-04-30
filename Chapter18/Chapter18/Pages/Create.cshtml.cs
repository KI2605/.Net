using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter18.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public Human Human { get; set; }
        public CreateModel(ApplicationContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Humen.Add(Human);
                await _context.SaveChangesAsync();
                return RedirectToPage("IndexDb");
            }
            return Page();
        }
    }
}
