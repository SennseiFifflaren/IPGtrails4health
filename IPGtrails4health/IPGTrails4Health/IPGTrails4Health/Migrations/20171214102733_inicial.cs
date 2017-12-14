using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IPGTrails4Health.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alojamentos",
                columns: table => new
                {
                    AlojamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    Local = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamentos", x => x.AlojamentoId);
                });

            migrationBuilder.CreateTable(
                name: "AreasDescanso",
                columns: table => new
                {
                    AreaDescansoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    Local = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDescanso", x => x.AreaDescansoId);
                });

            migrationBuilder.CreateTable(
                name: "EpocasAno",
                columns: table => new
                {
                    EpocaAnoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpocasAno", x => x.EpocaAnoId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    LocalidadeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.LocalidadeId);
                });

            migrationBuilder.CreateTable(
                name: "PontosInteresse",
                columns: table => new
                {
                    PontoInteresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Local = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true),
                    Sazonalidade = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosInteresse", x => x.PontoInteresseId);
                });

            migrationBuilder.CreateTable(
                name: "PontosInteresseTrilho",
                columns: table => new
                {
                    PontoInteresseTrilhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosInteresseTrilho", x => x.PontoInteresseTrilhoId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    RestauranteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    Local = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.RestauranteId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPontosInteresse",
                columns: table => new
                {
                    TipoPontoInteresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPontosInteresse", x => x.TipoPontoInteresseId);
                });

            migrationBuilder.CreateTable(
                name: "Trilhos",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Chegada = table.Column<string>(nullable: false),
                    Dificuldade = table.Column<string>(nullable: false),
                    Distancia = table.Column<decimal>(nullable: false),
                    Duracao = table.Column<decimal>(nullable: false),
                    EstadoTrilho = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Partida = table.Column<string>(nullable: false),
                    Percurso = table.Column<string>(nullable: false),
                    RestauranteId = table.Column<int>(nullable: false),
                    Sazonalidade = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhos", x => x.TrilhoId);
                    table.ForeignKey(
                        name: "FK_Trilhos_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "RestauranteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadosTrilho",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false),
                    TrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosTrilho", x => new { x.EstadoId, x.TrilhoId });
                    table.ForeignKey(
                        name: "FK_EstadosTrilho_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstadosTrilho_Trilhos_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trilhos",
                        principalColumn: "TrilhoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantesTrilhos",
                columns: table => new
                {
                    RestauranteId = table.Column<int>(nullable: false),
                    TrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantesTrilhos", x => new { x.RestauranteId, x.TrilhoId });
                    table.ForeignKey(
                        name: "FK_RestaurantesTrilhos_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "RestauranteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantesTrilhos_Trilhos_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trilhos",
                        principalColumn: "TrilhoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadosTrilho_TrilhoId",
                table: "EstadosTrilho",
                column: "TrilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantesTrilhos_TrilhoId",
                table: "RestaurantesTrilhos",
                column: "TrilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilhos_RestauranteId",
                table: "Trilhos",
                column: "RestauranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alojamentos");

            migrationBuilder.DropTable(
                name: "AreasDescanso");

            migrationBuilder.DropTable(
                name: "EpocasAno");

            migrationBuilder.DropTable(
                name: "EstadosTrilho");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "PontosInteresse");

            migrationBuilder.DropTable(
                name: "PontosInteresseTrilho");

            migrationBuilder.DropTable(
                name: "RestaurantesTrilhos");

            migrationBuilder.DropTable(
                name: "TipoPontosInteresse");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Trilhos");

            migrationBuilder.DropTable(
                name: "Restaurantes");
        }
    }
}
