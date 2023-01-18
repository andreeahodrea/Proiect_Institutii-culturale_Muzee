using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication27.Data;
using WebApplication27.Models;

namespace WebApplication27.Pages.Exponate
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication27.Data.WebApplication27Context _context;

        public DeleteModel(WebApplication27.Data.WebApplication27Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Exponat Exponat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Exponat == null)
            {
                return NotFound();
            }

            var exponat = await _context.Exponat.FirstOrDefaultAsync(m => m.ID == id);

            if (exponat == null)
            {
                return NotFound();
            }
            else 
            {
                Exponat = exponat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Exponat == null)
            {
                return NotFound();
            }
            var exponat = await _context.Exponat.FindAsync(id);

            if (exponat != null)
            {
                Exponat = exponat;
                _context.Exponat.Remove(Exponat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
