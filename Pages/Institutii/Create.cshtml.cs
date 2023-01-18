using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication27.Data;
using WebApplication27.Models;

namespace WebApplication27.Pages.Institutii
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication27.Data.WebApplication27Context _context;

        public CreateModel(WebApplication27.Data.WebApplication27Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ColectieID"] = new SelectList(_context.Set<Colectie>(), "ID",
"NumeleColectiilor");
            ViewData["ExponatID"] = new SelectList(_context.Set<Colectie>(), "ID",
"DenumireExponat");
            ViewData["ExponatID"] = new SelectList(_context.Set<Colectie>(), "ID",
"Locatie");
            return Page();
        }

        [BindProperty]
        public Institutie Institutie { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Institutie.Add(Institutie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
