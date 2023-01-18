using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication27.Data;
using WebApplication27.Models;

namespace WebApplication27.Pages.Institutii
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication27.Data.WebApplication27Context _context;

        public DeleteModel(WebApplication27.Data.WebApplication27Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Institutie Institutie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Institutie == null)
            {
                return NotFound();
            }

            var institutie = await _context.Institutie.FirstOrDefaultAsync(m => m.ID == id);

            if (institutie == null)
            {
                return NotFound();
            }
            else 
            {
                Institutie = institutie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Institutie == null)
            {
                return NotFound();
            }
            var institutie = await _context.Institutie.FindAsync(id);

            if (institutie != null)
            {
                Institutie = institutie;
                _context.Institutie.Remove(Institutie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
