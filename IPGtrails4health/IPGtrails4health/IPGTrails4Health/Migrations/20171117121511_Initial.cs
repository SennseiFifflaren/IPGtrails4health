using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IPGTrails4Health.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alojamento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlojamentoID = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoMax = table.Column<int>(type: "int", nullable: false),
                    PrecoMin = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alojamento_Alojamento_AlojamentoID",
                        column: x => x.AlojamentoID,
                        principalTable: "Alojamento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AreasDescanso",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaDescansoID = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDescanso", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AreasDescanso_AreasDescanso_AreaDescansoID",
                        column: x => x.AreaDescansoID,
                        principalTable: "AreasDescanso",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestauranteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Restaurante_Restaurante_RestauranteID",
                        column: x => x.RestauranteID,
                        principalTable: "Restaurante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alojamento_AlojamentoID",
                table: "Alojamento",
                column: "AlojamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDescanso_AreaDescansoID",
                table: "AreasDescanso",
                column: "AreaDescansoID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_RestauranteID",
                table: "Restaurante",
                column: "RestauranteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alojamento");

            migrationBuilder.DropTable(
                name: "AreasDescanso");

            migrationBuilder.DropTable(
                name: "Restaurante");
        }
    }
}
