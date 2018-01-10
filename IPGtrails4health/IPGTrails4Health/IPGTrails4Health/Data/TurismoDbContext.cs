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
        public TurismoDbContext (DbContextOptions<TurismoDbContext> options) : base(options) { }
        public DbSet<Trilho> Trilhos { get; set; }
        public DbSet<Dificuldade> Dificuldades { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<RestauranteTrilho> RestaurantesTrilhos { get; set; }
        public DbSet<Alojamento> Alojamentos { get; set; }
        public DbSet<AreaDescanso> AreasDescanso { get; set; }
        public DbSet<EpocaAno> EpocasAno { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<EstadoTrilho> EstadosTrilho { get; set; }
        public DbSet<Localidade> Localidades { get; set; }
        public DbSet<PontoInteresse> PontosInteresse { get; set; }
        public DbSet<PontoInteresseTrilho> PontosInteresseTrilho { get; set; }
        public DbSet<TipoPontoInteresse> TipoPontosInteresse { get; set; }
        public DbSet<TipoAlojamento> TipoAlojamentos { get; set; }
        public DbSet<AlojamentoTrilho> AlojamentosTrilhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Alojamento>();
            modelBuilder.Entity<Restaurante>();
            //modelBuilder.Entity<AreaDescanso>();
            modelBuilder.Entity<Trilho>();
            //modelBuilder.Entity<PontoInteresse>();
            modelBuilder.Entity<RestauranteTrilho>()
                .HasKey(rt => new { rt.RestauranteId, rt.TrilhoId });
            modelBuilder.Entity<EstadoTrilho>()
                .HasKey(et => new { et.EstadoId, et.TrilhoId });

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

