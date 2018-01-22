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
                name: "AreasDescanso",
                columns: table => new
                {
                    AreaDescansoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    Localizacao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDescanso", x => x.AreaDescansoId);
                });

            migrationBuilder.CreateTable(
                name: "Dificuldades",
                columns: table => new
                {
                    DificuldadeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificuldades", x => x.DificuldadeId);
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
                    CodigoPostal = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.LocalidadeId);
                });

            migrationBuilder.CreateTable(
                name: "TipoAlojamentos",
                columns: table => new
                {
                    TipoAlojamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAlojamentos", x => x.TipoAlojamentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPontosInteresse",
                columns: table => new
                {
                    TipoPontoInteresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
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
                    DificuldadeId = table.Column<int>(nullable: false),
                    Distancia = table.Column<decimal>(nullable: false),
                    Duracao = table.Column<decimal>(nullable: false),
                    EpocaAnoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Partida = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhos", x => x.TrilhoId);
                    table.ForeignKey(
                        name: "FK_Trilhos_Dificuldades_DificuldadeId",
                        column: x => x.DificuldadeId,
                        principalTable: "Dificuldades",
                        principalColumn: "DificuldadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trilhos_EpocasAno_EpocaAnoId",
                        column: x => x.EpocaAnoId,
                        principalTable: "EpocasAno",
                        principalColumn: "EpocaAnoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    RestauranteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contacto = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: false),
                    LocalidadeId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.RestauranteId);
                    table.ForeignKey(
                        name: "FK_Restaurantes_Localidades_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidades",
                        principalColumn: "LocalidadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alojamentos",
                columns: table => new
                {
                    AlojamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contacto = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    LocalidadeId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    TipoAlojamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamentos", x => x.AlojamentoId);
                    table.ForeignKey(
                        name: "FK_Alojamentos_Localidades_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidades",
                        principalColumn: "LocalidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alojamentos_TipoAlojamentos_TipoAlojamentoId",
                        column: x => x.TipoAlojamentoId,
                        principalTable: "TipoAlojamentos",
                        principalColumn: "TipoAlojamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PontosInteresse",
                columns: table => new
                {
                    PontoInteresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Local = table.Column<string>(nullable: true),
                    LocalidadeId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true),
                    TipoPontoInteresseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosInteresse", x => x.PontoInteresseId);
                    table.ForeignKey(
                        name: "FK_PontosInteresse_Localidades_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidades",
                        principalColumn: "LocalidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PontosInteresse_TipoPontosInteresse_TipoPontoInteresseId",
                        column: x => x.TipoPontoInteresseId,
                        principalTable: "TipoPontosInteresse",
                        principalColumn: "TipoPontoInteresseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreasDescansoTrilhos",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(nullable: false),
                    AreaDescansoId = table.Column<int>(nullable: false),
                    AreaDescansoTrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDescansoTrilhos", x => new { x.TrilhoId, x.AreaDescansoId });
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
                name: "EstadosTrilho",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    Causa = table.Column<string>(nullable: true),
                    DataFim = table.Column<DateTime>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    EstadoTrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosTrilho", x => new { x.TrilhoId, x.EstadoId });
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
                    TrilhoId = table.Column<int>(nullable: false),
                    RestauranteId = table.Column<int>(nullable: false),
                    RestauranteTrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantesTrilhos", x => new { x.TrilhoId, x.RestauranteId });
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

            migrationBuilder.CreateTable(
                name: "AlojamentosTrilhos",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(nullable: false),
                    AlojamentoId = table.Column<int>(nullable: false),
                    AlojamentoTrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlojamentosTrilhos", x => new { x.TrilhoId, x.AlojamentoId });
                    table.ForeignKey(
                        name: "FK_AlojamentosTrilhos_Alojamentos_AlojamentoId",
                        column: x => x.AlojamentoId,
                        principalTable: "Alojamentos",
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
                name: "PontosInteresseTrilho",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(nullable: false),
                    PontoInteresseId = table.Column<int>(nullable: false),
                    PontoInteresseTrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosInteresseTrilho", x => new { x.TrilhoId, x.PontoInteresseId });
                    table.ForeignKey(
                        name: "FK_PontosInteresseTrilho_PontosInteresse_PontoInteresseId",
                        column: x => x.PontoInteresseId,
                        principalTable: "PontosInteresse",
                        principalColumn: "PontoInteresseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PontosInteresseTrilho_Trilhos_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trilhos",
                        principalColumn: "TrilhoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alojamentos_LocalidadeId",
                table: "Alojamentos",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Alojamentos_TipoAlojamentoId",
                table: "Alojamentos",
                column: "TipoAlojamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlojamentosTrilhos_AlojamentoId",
                table: "AlojamentosTrilhos",
                column: "AlojamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDescansoTrilhos_AreaDescansoId",
                table: "AreasDescansoTrilhos",
                column: "AreaDescansoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadosTrilho_EstadoId",
                table: "EstadosTrilho",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosInteresse_LocalidadeId",
                table: "PontosInteresse",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosInteresse_TipoPontoInteresseId",
                table: "PontosInteresse",
                column: "TipoPontoInteresseId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosInteresseTrilho_PontoInteresseId",
                table: "PontosInteresseTrilho",
                column: "PontoInteresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantes_LocalidadeId",
                table: "Restaurantes",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantesTrilhos_RestauranteId",
                table: "RestaurantesTrilhos",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilhos_DificuldadeId",
                table: "Trilhos",
                column: "DificuldadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilhos_EpocaAnoId",
                table: "Trilhos",
                column: "EpocaAnoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlojamentosTrilhos");

            migrationBuilder.DropTable(
                name: "AreasDescansoTrilhos");

            migrationBuilder.DropTable(
                name: "EstadosTrilho");

            migrationBuilder.DropTable(
                name: "PontosInteresseTrilho");

            migrationBuilder.DropTable(
                name: "RestaurantesTrilhos");

            migrationBuilder.DropTable(
                name: "Alojamentos");

            migrationBuilder.DropTable(
                name: "AreasDescanso");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "PontosInteresse");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropTable(
                name: "Trilhos");

            migrationBuilder.DropTable(
                name: "TipoAlojamentos");

            migrationBuilder.DropTable(
                name: "TipoPontosInteresse");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Dificuldades");

            migrationBuilder.DropTable(
                name: "EpocasAno");
        }
    }
}
