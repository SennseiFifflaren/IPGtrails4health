using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IPGTrails4Health.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alojamento",
                columns: table => new
                {
                    AlojamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlojamentoId1 = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoMax = table.Column<int>(type: "int", nullable: false),
                    PrecoMin = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamento", x => x.AlojamentoId);
                    table.ForeignKey(
                        name: "FK_Alojamento_Alojamento_AlojamentoId1",
                        column: x => x.AlojamentoId1,
                        principalTable: "Alojamento",
                        principalColumn: "AlojamentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AreasDescanso",
                columns: table => new
                {
                    AreaDescansoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaDescansoId1 = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDescanso", x => x.AreaDescansoId);
                    table.ForeignKey(
                        name: "FK_AreasDescanso_AreasDescanso_AreaDescansoId1",
                        column: x => x.AreaDescansoId1,
                        principalTable: "AreasDescanso",
                        principalColumn: "AreaDescansoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PontosInteresse",
                columns: table => new
                {
                    PontoInteresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sazonalidade = table.Column<int>(type: "int", nullable: false),
                    TipoPontoInteresse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosInteresse", x => x.PontoInteresseId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    RestauranteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestauranteId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.RestauranteId);
                    table.ForeignKey(
                        name: "FK_Restaurante_Restaurante_RestauranteId1",
                        column: x => x.RestauranteId1,
                        principalTable: "Restaurante",
                        principalColumn: "RestauranteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trilhos",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Chegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dificuldade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distancia = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Duracao = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    EstadoTrilho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sazonalidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhos", x => x.TrilhoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alojamento_AlojamentoId1",
                table: "Alojamento",
                column: "AlojamentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDescanso_AreaDescansoId1",
                table: "AreasDescanso",
                column: "AreaDescansoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_RestauranteId1",
                table: "Restaurante",
                column: "RestauranteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alojamento");

            migrationBuilder.DropTable(
                name: "AreasDescanso");

            migrationBuilder.DropTable(
                name: "PontosInteresse");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "Trilhos");
        }
    }
}
