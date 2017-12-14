﻿// <auto-generated />
using IPGTrails4Health.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace IPGTrails4Health.Migrations
{
    [DbContext(typeof(TurismoDbContext))]
    [Migration("20171214102733_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
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

                    b.Property<string>("Tipo")
                        .IsRequired();

                    b.HasKey("AlojamentoId");

                    b.ToTable("Alojamentos");
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

                    b.Property<string>("Tipo")
                        .IsRequired();

                    b.HasKey("AreaDescansoId");

                    b.ToTable("AreasDescanso");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.EpocaAno", b =>
                {
                    b.Property<int>("EpocaAnoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("EpocaAnoId");

                    b.ToTable("EpocasAno");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.EstadoTrilho", b =>
                {
                    b.Property<int>("EstadoId");

                    b.Property<int>("TrilhoId");

                    b.HasKey("EstadoId", "TrilhoId");

                    b.HasIndex("TrilhoId");

                    b.ToTable("EstadosTrilho");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.Localidade", b =>
                {
                    b.Property<int>("LocalidadeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("LocalidadeId");

                    b.ToTable("Localidades");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.PontoInteresse", b =>
                {
                    b.Property<int>("PontoInteresseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Local");

                    b.Property<string>("Nome");

                    b.Property<string>("Observacoes");

                    b.Property<string>("Sazonalidade");

                    b.Property<string>("Tipo");

                    b.HasKey("PontoInteresseId");

                    b.ToTable("PontosInteresse");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.PontoInteresseTrilho", b =>
                {
                    b.Property<int>("PontoInteresseTrilhoId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("PontoInteresseTrilhoId");

                    b.ToTable("PontosInteresseTrilho");
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

                    b.ToTable("Restaurantes");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.RestauranteTrilho", b =>
                {
                    b.Property<int>("RestauranteId");

                    b.Property<int>("TrilhoId");

                    b.HasKey("RestauranteId", "TrilhoId");

                    b.HasIndex("TrilhoId");

                    b.ToTable("RestaurantesTrilhos");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.TipoPontoInteresse", b =>
                {
                    b.Property<int>("TipoPontoInteresseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tipo");

                    b.HasKey("TipoPontoInteresseId");

                    b.ToTable("TipoPontosInteresse");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.Trilho", b =>
                {
                    b.Property<int>("TrilhoId")
                        .ValueGeneratedOnAdd();

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

                    b.Property<int>("RestauranteId");

                    b.Property<string>("Sazonalidade")
                        .IsRequired();

                    b.HasKey("TrilhoId");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Trilhos");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.EstadoTrilho", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IPGTrails4Health.Models.Trilho", "Trilho")
                        .WithMany()
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IPGTrails4Health.Models.RestauranteTrilho", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.Restaurante", "Restaurante")
                        .WithMany("RestaurantesTrilhos")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IPGTrails4Health.Models.Trilho", "Trilho")
                        .WithMany("RestaurantesTrilhos")
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IPGTrails4Health.Models.Trilho", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.Restaurante", "Restaurante")
                        .WithMany()
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
