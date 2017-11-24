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

        public DbSet<RestauranteTrilho> RestaurantesTrilhos { get; set; }
        public DbSet<AlojamentoTrilho> AlojamentosTrilhos { get; set; }
        public DbSet<PontoInteresseTrilho> PontosInteresseTrilhos { get; set; }
        public DbSet<AreaDescansoTrilho> AreasDescansoTrilhos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alojamento>().ToTable("Alojamento");
            modelBuilder.Entity<Restaurante>().ToTable("Restaurante");
            modelBuilder.Entity<AreaDescanso>().ToTable("AreasDescanso");
            modelBuilder.Entity<Trilho>().ToTable("Trilhos")
                .HasOne(trilho => trilho.Restaurante)
                .WithMany(restaurante => restaurante.Trilhos)
                .HasForeignKey(trilho => trilho.RestauranteId); ;
            modelBuilder.Entity<PontoInteresse>().ToTable("PontosInteresse");

            modelBuilder.Entity<Trilho>()
                .HasOne(trilho => trilho.AreaDescanso)
                .WithMany(areadescanso => areadescanso.Trilhos)
                .HasForeignKey(trilho => trilho.AreaDescansoId);

            modelBuilder.Entity<Trilho>()
                .HasOne(trilho => trilho.Alojamento)
                .WithMany(alojamento => alojamento.Trilhos)
                .HasForeignKey(trilho => trilho.AlojamentoId);

            modelBuilder.Entity<Trilho>()
                .HasOne(trilho => trilho.PontoInteresse)
                .WithMany(pontointeresse => pontointeresse.Trilhos)
                .HasForeignKey(trilho => trilho.PontoInteresseId);

        }
    }
}
