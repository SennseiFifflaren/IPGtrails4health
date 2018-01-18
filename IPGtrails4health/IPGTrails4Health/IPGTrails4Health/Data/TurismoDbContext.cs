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
        public DbSet<AreaDescansoTrilho> AreasDescansoTrilhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //restaurante trilho
            modelBuilder.Entity<RestauranteTrilho>()
                .HasKey(rt => new { rt.TrilhoId, rt.RestauranteId });

            modelBuilder.Entity<RestauranteTrilho>()
                .HasOne(rt => rt.Trilho)
                .WithMany(t => t.RestaurantesTrilhos)
                .HasForeignKey(rt => rt.TrilhoId);

            modelBuilder.Entity<RestauranteTrilho>()
                .HasOne(rt => rt.Restaurante)
                .WithMany(r => r.RestaurantesTrilhos)
                .HasForeignKey(rt => rt.RestauranteId);

            //alojamento trilho
            modelBuilder.Entity<AlojamentoTrilho>()
                .HasKey(at => new { at.TrilhoId, at.AlojamentoId });

            modelBuilder.Entity<AlojamentoTrilho>()
                .HasOne(at => at.Trilho)
                .WithMany(t => t.AlojamentoTrilhos)
                .HasForeignKey(at => at.TrilhoId);

            modelBuilder.Entity<AlojamentoTrilho>()
                .HasOne(at => at.Alojamento)
                .WithMany(a => a.AlojamentoTrilhos)
                .HasForeignKey(at => at.AlojamentoId);

            //ponto interesse trilho
            modelBuilder.Entity<PontoInteresseTrilho>()
                .HasKey(pit => new { pit.TrilhoId, pit.PontoInteresseId });

            modelBuilder.Entity<PontoInteresseTrilho>()
                .HasOne(pit => pit.Trilho)
                .WithMany(t => t.PontosInteresseTrilhos)
                .HasForeignKey(pit => pit.TrilhoId);

            modelBuilder.Entity<PontoInteresseTrilho>()
                .HasOne(pit => pit.PontoInteresse)
                .WithMany(pi => pi.PontosInteresseTrilhos)
                .HasForeignKey(pit => pit.PontoInteresseId);

            //area descanso trilho
            modelBuilder.Entity<AreaDescansoTrilho>()
                .HasKey(adt => new { adt.TrilhoId, adt.AreaDescansoId });

            modelBuilder.Entity<AreaDescansoTrilho>()
                .HasOne(adt => adt.Trilho)
                .WithMany(t => t.AreasDescansoTrilhos)
                .HasForeignKey(adt => adt.TrilhoId);

            modelBuilder.Entity<AreaDescansoTrilho>()
                .HasOne(adt => adt.AreaDescanso)
                .WithMany(ad => ad.AreasDescansoTrilhos)
                .HasForeignKey(adt => adt.AreaDescansoId);

            //estado trilho
            modelBuilder.Entity<EstadoTrilho>()
                .HasKey(et => new { et.TrilhoId, et.EstadoId });

            modelBuilder.Entity<EstadoTrilho>()
                .HasOne(et => et.Trilho)
                .WithMany(t => t.EstadosTrilho)
                .HasForeignKey(et => et.TrilhoId);

            modelBuilder.Entity<EstadoTrilho>()
                .HasOne(et => et.Estado)
                .WithMany(e => e.EstadosTrilho)
                .HasForeignKey(et => et.EstadoId);
        }

    }

}

