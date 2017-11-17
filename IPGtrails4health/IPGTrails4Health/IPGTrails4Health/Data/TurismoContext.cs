using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IPGTrails4Health.Models;

namespace IPGTrails4Health.Data
{
    public class TurismoContext : DbContext
    {
        public TurismoContext(DbContextOptions<TurismoContext> options) : base(options)
        {
        }

        public DbSet<Alojamento> Alojamento { get; set; }
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<AreaDescanso> AreasDescanso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alojamento>().ToTable("Alojamento");
            modelBuilder.Entity<Restaurante>().ToTable("Restaurante");
            modelBuilder.Entity<AreaDescanso>().ToTable("AreasDescanso");
        }
    }
}
