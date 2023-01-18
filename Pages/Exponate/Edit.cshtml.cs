using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication27.Data;
using WebApplication27.Models;

namespace WebApplication27.Pages.Exponate
{
    public class EditModel : PageModel
    {
        private readonly WebApplication27.Data.WebApplication27Context _context;

        public EditModel(WebApplication27.Data.WebApplication27Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Exponat Exponat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Exponat == null)
            {
                return NotFound();
            }

            var exponat =  await _context.Exponat.FirstOrDefaultAsync(m => m.ID == id);
            if (exponat == null)
            {
                return NotFound();
            }
            Exponat = exponat;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Exponat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExponatExists(Exponat.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExponatExists(int id)
        {
          return _context.Exponat.Any(e => e.ID == id);
        }
    }
}
