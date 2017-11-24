using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IPGTrails4Health.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alojamento",
                columns: table => new
                {
                    AlojamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamento", x => x.AlojamentoId);
                });

            migrationBuilder.CreateTable(
                name: "AreasDescanso",
                columns: table => new
                {
                    AreaDescansoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDescanso", x => x.AreaDescansoId);
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
                    TipoPontoInteresse = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.RestauranteId);
                });

            migrationBuilder.CreateTable(
                name: "Trilhos",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlojamentoId = table.Column<int>(type: "int", nullable: true),
                    AreaDescansoId = table.Column<int>(type: "int", nullable: true),
                    Chegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dificuldade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distancia = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Duracao = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    EstadoTrilho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PontoInteresseId = table.Column<int>(type: "int", nullable: true),
                    RestauranteId = table.Column<int>(type: "int", nullable: false),
                    Sazonalidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhos", x => x.TrilhoId);
                    table.ForeignKey(
                        name: "FK_Trilhos_Alojamento_AlojamentoId",
                        column: x => x.AlojamentoId,
                        principalTable: "Alojamento",
                        principalColumn: "AlojamentoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trilhos_AreasDescanso_AreaDescansoId",
                        column: x => x.AreaDescansoId,
                        principalTable: "AreasDescanso",
                        principalColumn: "AreaDescansoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trilhos_PontosInteresse_PontoInteresseId",
                        column: x => x.PontoInteresseId,
                        principalTable: "PontosInteresse",
                        principalColumn: "PontoInteresseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trilhos_Restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurante",
                        principalColumn: "RestauranteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlojamentosTrilhos",
                columns: table => new
                {
                    AlojamentoTrilhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlojamentoId = table.Column<int>(type: "int", nullable: false),
                    TrilhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlojamentosTrilhos", x => x.AlojamentoTrilhoId);
                    table.ForeignKey(
                        name: "FK_AlojamentosTrilhos_Alojamento_AlojamentoId",
                        column: x => x.AlojamentoId,
                        principalTable: "Alojamento",
                        principalColumn: "AlojamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlojamentosTrilhos_Trilhos_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trilhos",
                        principalColumn: "TrilhoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreasDescansoTrilhos",
                columns: table => new
                {
                    AreaDescansoTrilhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaDescansoId = table.Column<int>(type: "int", nullable: false),
                    TrilhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDescansoTrilhos", x => x.AreaDescansoTrilhoId);
                    table.ForeignKey(
                        name: "FK_AreasDescansoTrilhos_AreasDescanso_AreaDescansoId",
                        column: x => x.AreaDescansoId,
                        principalTable: "AreasDescanso",
                        principalColumn: "AreaDescansoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreasDescansoTrilhos_Trilhos_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trilhos",
                        principalColumn: "TrilhoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PontosInteresseTrilhos",
                columns: table => new
                {
                    PontoInteresseTrilhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PontoInteresseId = table.Column<int>(type: "int", nullable: false),
                    TrilhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosInteresseTrilhos", x => x.PontoInteresseTrilhoId);
                    table.ForeignKey(
                        name: "FK_PontosInteresseTrilhos_PontosInteresse_PontoInteresseId",
                        column: x => x.PontoInteresseId,
                        principalTable: "PontosInteresse",
                        principalColumn: "PontoInteresseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PontosInteresseTrilhos_Trilhos_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trilhos",
                        principalColumn: "TrilhoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantesTrilhos",
                columns: table => new
                {
                    RestauranteTrilhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RestauranteId = table.Column<int>(type: "int", nullable: false),
                    TrilhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantesTrilhos", x => x.RestauranteTrilhoId);
                    table.ForeignKey(
                        name: "FK_RestaurantesTrilhos_Restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurante",
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
                name: "IX_AlojamentosTrilhos_AlojamentoId",
                table: "AlojamentosTrilhos",
                column: "AlojamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlojamentosTrilhos_TrilhoId",
                table: "AlojamentosTrilhos",
                column: "TrilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDescansoTrilhos_AreaDescansoId",
                table: "AreasDescansoTrilhos",
                column: "AreaDescansoId");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDescansoTrilhos_TrilhoId",
                table: "AreasDescansoTrilhos",
                column: "TrilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosInteresseTrilhos_PontoInteresseId",
                table: "PontosInteresseTrilhos",
                column: "PontoInteresseId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosInteresseTrilhos_TrilhoId",
                table: "PontosInteresseTrilhos",
                column: "TrilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantesTrilhos_RestauranteId",
                table: "RestaurantesTrilhos",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantesTrilhos_TrilhoId",
                table: "RestaurantesTrilhos",
                column: "TrilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilhos_AlojamentoId",
                table: "Trilhos",
                column: "AlojamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilhos_AreaDescansoId",
                table: "Trilhos",
                column: "AreaDescansoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilhos_PontoInteresseId",
                table: "Trilhos",
                column: "PontoInteresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilhos_RestauranteId",
                table: "Trilhos",
                column: "RestauranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlojamentosTrilhos");

            migrationBuilder.DropTable(
                name: "AreasDescansoTrilhos");

            migrationBuilder.DropTable(
                name: "PontosInteresseTrilhos");

            migrationBuilder.DropTable(
                name: "RestaurantesTrilhos");

            migrationBuilder.DropTable(
                name: "Trilhos");

            migrationBuilder.DropTable(
                name: "Alojamento");

            migrationBuilder.DropTable(
                name: "AreasDescanso");

            migrationBuilder.DropTable(
                name: "PontosInteresse");

            migrationBuilder.DropTable(
                name: "Restaurante");
        }
    }
}
