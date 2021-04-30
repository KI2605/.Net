using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Chapter18.Pages
{
    public class IndexDbModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Human> Humen { get; set; }
        public IndexDbModel(ApplicationContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            Humen = _context.Humen.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.Humen.FindAsync(id);

            if (product != null)
            {
                _context.Humen.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}