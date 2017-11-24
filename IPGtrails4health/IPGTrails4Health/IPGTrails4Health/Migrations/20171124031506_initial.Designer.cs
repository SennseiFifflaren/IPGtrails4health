﻿// <auto-generated />
using IPGTrails4Health.Data;
using IPGTrails4Health.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace IPGTrails4Health.Migrations
{
    [DbContext(typeof(TurismoContext))]
    [Migration("20171124031506_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IPGTrails4Health.Models.Alojamento", b =>
                {
                    b.Property<int>("AlojamentoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Local")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Tipo");

                    b.HasKey("AlojamentoId");

                    b.ToTable("Alojamento");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.AlojamentoTrilho", b =>
                {
                    b.Property<int>("AlojamentoTrilhoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlojamentoId");

                    b.Property<int>("TrilhoId");

                    b.HasKey("AlojamentoTrilhoId");

                    b.HasIndex("AlojamentoId");

                    b.HasIndex("TrilhoId");

                    b.ToTable("AlojamentosTrilhos");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.AreaDescanso", b =>
                {
                    b.Property<int>("AreaDescansoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Local")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Tipo");

                    b.HasKey("AreaDescansoId");

                    b.ToTable("AreasDescanso");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.AreaDescansoTrilho", b =>
                {
                    b.Property<int>("AreaDescansoTrilhoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaDescansoId");

                    b.Property<int>("TrilhoId");

                    b.HasKey("AreaDescansoTrilhoId");

                    b.HasIndex("AreaDescansoId");

                    b.HasIndex("TrilhoId");

                    b.ToTable("AreasDescansoTrilhos");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.PontoInteresse", b =>
                {
                    b.Property<int>("PontoInteresseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Local")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Observacoes");

                    b.Property<int>("Sazonalidade");

                    b.Property<string>("TipoPontoInteresse")
                        .IsRequired();

                    b.HasKey("PontoInteresseId");

                    b.ToTable("PontosInteresse");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.PontoInteresseTrilho", b =>
                {
                    b.Property<int>("PontoInteresseTrilhoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PontoInteresseId");

                    b.Property<int>("TrilhoId");

                    b.HasKey("PontoInteresseTrilhoId");

                    b.HasIndex("PontoInteresseId");

                    b.HasIndex("TrilhoId");

                    b.ToTable("PontosInteresseTrilhos");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.Restaurante", b =>
                {
                    b.Property<int>("RestauranteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Local")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("RestauranteId");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.RestauranteTrilho", b =>
                {
                    b.Property<int>("RestauranteTrilhoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RestauranteId");

                    b.Property<int>("TrilhoId");

                    b.HasKey("RestauranteTrilhoId");

                    b.HasIndex("RestauranteId");

                    b.HasIndex("TrilhoId");

                    b.ToTable("RestaurantesTrilhos");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.Trilho", b =>
                {
                    b.Property<int>("TrilhoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlojamentoId");

                    b.Property<int?>("AreaDescansoId");

                    b.Property<string>("Chegada")
                        .IsRequired();

                    b.Property<string>("Dificuldade")
                        .IsRequired();

                    b.Property<decimal>("Distancia");

                    b.Property<decimal>("Duracao");

                    b.Property<string>("EstadoTrilho")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Partida")
                        .IsRequired();

                    b.Property<string>("Percurso")
                        .IsRequired();

                    b.Property<int?>("PontoInteresseId");

                    b.Property<int>("RestauranteId");

                    b.Property<string>("Sazonalidade")
                        .IsRequired();

                    b.HasKey("TrilhoId");

                    b.HasIndex("AlojamentoId");

                    b.HasIndex("AreaDescansoId");

                    b.HasIndex("PontoInteresseId");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Trilhos");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.AlojamentoTrilho", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.Alojamento", "Alojamento")
                        .WithMany("AlojamentosTrilhos")
                        .HasForeignKey("AlojamentoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IPGTrails4Health.Models.Trilho", "Trilho")
                        .WithMany()
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IPGTrails4Health.Models.AreaDescansoTrilho", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.AreaDescanso", "AreaDescanso")
                        .WithMany("AreasDescansoTrilhos")
                        .HasForeignKey("AreaDescansoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IPGTrails4Health.Models.Trilho", "Trilho")
                        .WithMany()
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IPGTrails4Health.Models.PontoInteresseTrilho", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.PontoInteresse", "PontoInteresse")
                        .WithMany("PontosInteresseTrilhos")
                        .HasForeignKey("PontoInteresseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IPGTrails4Health.Models.Trilho", "Trilho")
                        .WithMany()
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IPGTrails4Health.Models.RestauranteTrilho", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.Restaurante", "Restaurante")
                        .WithMany()
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IPGTrails4Health.Models.Trilho", "Trilho")
                        .WithMany()
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IPGTrails4Health.Models.Trilho", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.Alojamento")
                        .WithMany("Trilhos")
                        .HasForeignKey("AlojamentoId");

                    b.HasOne("IPGTrails4Health.Models.AreaDescanso")
                        .WithMany("Trilhos")
                        .HasForeignKey("AreaDescansoId");

                    b.HasOne("IPGTrails4Health.Models.PontoInteresse")
                        .WithMany("Trilhos")
                        .HasForeignKey("PontoInteresseId");

                    b.HasOne("IPGTrails4Health.Models.Restaurante", "Restaurante")
                        .WithMany("Trilhos")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
