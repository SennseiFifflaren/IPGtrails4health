using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IPGTrails4Health.Models;
using IPGTrails4Health.Models.TurismoViewModels;

namespace IPGTrails4Health.Data
{
    public class TurismoContext : DbContext
    {
        public TurismoContext(DbContextOptions<TurismoContext> options) : base(options)
        {
        }

        public DbSet<AlojamentoViewModel> Alojamento { get; set; }
        public DbSet<RestauranteViewModel> Restaurante { get; set; }
        public DbSet<AreasDescansoViewModel> AreasDescanso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlojamentoViewModel>().ToTable("Alojamento");
            modelBuilder.Entity<RestauranteViewModel>().ToTable("Restaurante");
            modelBuilder.Entity<AreasDescansoViewModel>().ToTable("AreasDescanso");
        }
    }
}
