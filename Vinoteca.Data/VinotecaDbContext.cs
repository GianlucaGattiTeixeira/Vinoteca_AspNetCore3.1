using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vinoteca.Core;

namespace Vinoteca.Data
{
    public class VinotecaDbContext : DbContext
    {
        public VinotecaDbContext(DbContextOptions<VinotecaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vino> Vinos { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
    }
}
