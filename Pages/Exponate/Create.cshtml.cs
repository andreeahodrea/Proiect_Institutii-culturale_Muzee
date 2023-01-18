using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication27.Data;
using WebApplication27.Models;

namespace WebApplication27.Pages.Exponate
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
            return Page();
        }

        [BindProperty]
        public Exponat Exponat { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exponat.Add(Exponat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
