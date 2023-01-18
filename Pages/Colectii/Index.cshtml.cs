using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication27.Data;
using WebApplication27.Models;

namespace WebApplication27.Pages.Colectii
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication27.Data.WebApplication27Context _context;

        public IndexModel(WebApplication27.Data.WebApplication27Context context)
        {
            _context = context;
        }

        public IList<Colectie> Colectie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Colectie != null)
            {
                Colectie = await _context.Colectie.ToListAsync();
            }
        }
    }
}
