using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication27.Data;
using WebApplication27.Models;

namespace WebApplication27.Pages.Institutii
{
    public class EditModel : PageModel
    {
        private readonly WebApplication27.Data.WebApplication27Context _context;

        public EditModel(WebApplication27.Data.WebApplication27Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Institutie Institutie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Institutie == null)
            {
                return NotFound();
            }

            var institutie =  await _context.Institutie.FirstOrDefaultAsync(m => m.ID == id);
            if (institutie == null)
            {
                return NotFound();
            }
            Institutie = institutie;
            ViewData["ColectieID"] = new SelectList(_context.Set<Colectie>(), "ID",
"NumeleColectiilor");
            ViewData["ExponatID"] = new SelectList(_context.Set<Colectie>(), "ID",
"DenumireExponat");
            ViewData["ExponatID"] = new SelectList(_context.Set<Colectie>(), "ID",
"Locatie");
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

            _context.Attach(Institutie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutieExists(Institutie.ID))
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

        private bool InstitutieExists(int id)
        {
          return _context.Institutie.Any(e => e.ID == id);
        }
    }
}
