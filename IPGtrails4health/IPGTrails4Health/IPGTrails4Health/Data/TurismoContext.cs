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

        public DbSet<Alojamento> Alojamentos { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<AreaDescanso> AreasDescanso { get; set; }
        public DbSet<Trilho> Trilhos { get; set; }
        public DbSet<PontoInteresse> PontosInteresse { get; set; }
        public DbSet<Estado> Estados { get; set; }

        public DbSet<RestauranteTrilho> RestaurantesTrilhos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alojamento>().ToTable("Alojamento");
            modelBuilder.Entity<Restaurante>().ToTable("Restaurante");
            modelBuilder.Entity<AreaDescanso>().ToTable("AreasDescanso");
            modelBuilder.Entity<Trilho>().ToTable("Trilhos")
                .HasOne(trilho => trilho.Restaurante)
                .WithMany(restaurante => restaurante.Trilhos)
                .HasForeignKey(trilho => trilho.RestauranteId);
            modelBuilder.Entity<PontoInteresse>().ToTable("PontosInteresse");

            //modelBuilder.Entity<Trilho>()
            //    .HasOne(trilho => trilho.TipoEstado)
            //    .WithMany(estado => estado.Trilhos)
            //    .HasForeignKey(trilho => trilho.EstadoId);
        }
    }
}
