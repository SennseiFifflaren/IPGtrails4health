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
    [Migration("20171117121511_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IPGTrails4Health.Models.Alojamento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlojamentoID");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Local")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("PrecoMax");

                    b.Property<int>("PrecoMin");

                    b.Property<int>("Tipo");

                    b.HasKey("ID");

                    b.HasIndex("AlojamentoID");

                    b.ToTable("Alojamento");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.AreaDescanso", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AreaDescansoID");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Local")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Tipo");

                    b.HasKey("ID");

                    b.HasIndex("AreaDescansoID");

                    b.ToTable("AreasDescanso");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.Restaurante", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Local")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int?>("RestauranteID");

                    b.HasKey("ID");

                    b.HasIndex("RestauranteID");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.Alojamento", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.Alojamento")
                        .WithMany("Alojamentos")
                        .HasForeignKey("AlojamentoID");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.AreaDescanso", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.AreaDescanso")
                        .WithMany("AreasDescanso")
                        .HasForeignKey("AreaDescansoID");
                });

            modelBuilder.Entity("IPGTrails4Health.Models.Restaurante", b =>
                {
                    b.HasOne("IPGTrails4Health.Models.Restaurante")
                        .WithMany("Restaurantes")
                        .HasForeignKey("RestauranteID");
                });
#pragma warning restore 612, 618
        }
    }
}
