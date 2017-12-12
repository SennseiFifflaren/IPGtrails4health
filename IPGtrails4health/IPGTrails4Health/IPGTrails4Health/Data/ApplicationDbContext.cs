using IPGTrails4Health.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Data
{
    public class TurismoDbContext : DbContext
    {
        public TurismoDbContext(DbContextOptions<TurismoDbContext> options) : base(options) { }
        public DbSet<Trilho> Trilhos { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<RestauranteTrilho> RestaurantesTrilhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Alojamento>();
            modelBuilder.Entity<Restaurante>();
            //modelBuilder.Entity<AreaDescanso>();
            modelBuilder.Entity<Trilho>();
            //modelBuilder.Entity<PontoInteresse>();
            modelBuilder.Entity<RestauranteTrilho>()
                .HasKey(rt => new { rt.RestauranteId, rt.TrilhoId });

            modelBuilder.Entity<RestauranteTrilho>()
                .HasOne(rt => rt.Trilho)
                .WithMany(t => t.RestaurantesTrilhos)
                .HasForeignKey(rt => rt.TrilhoId);

            modelBuilder.Entity<RestauranteTrilho>()
                .HasOne(rt => rt.Restaurante)
                .WithMany(r => r.RestaurantesTrilhos)
                .HasForeignKey(rt => rt.RestauranteId);
        }

    }

}

