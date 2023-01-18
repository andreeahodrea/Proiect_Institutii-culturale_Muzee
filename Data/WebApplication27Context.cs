using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication27.Models;

namespace WebApplication27.Data
{
    public class WebApplication27Context : DbContext
    {
        public WebApplication27Context (DbContextOptions<WebApplication27Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication27.Models.Institutie> Institutie { get; set; } = default!;

        public DbSet<WebApplication27.Models.Colectie> Colectie { get; set; }

        public DbSet<WebApplication27.Models.Exponat> Exponat { get; set; }
    }
}
