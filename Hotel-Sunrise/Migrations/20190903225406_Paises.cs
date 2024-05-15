using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Sunrise.Migrations
{
    public partial class Paises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Pais_PaisId1",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PaisId1",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PaisId1",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "PaisId",
                table: "Clientes",
                newName: "Apps_CountriesId");

            migrationBuilder.CreateTable(
                name: "Apps_Countries",
                columns: table => new
                {
                    Apps_CountriesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    country_code = table.Column<string>(nullable: true),
                    country_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps_Countries", x => x.Apps_CountriesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apps_Countries");

            migrationBuilder.RenameColumn(
                name: "Apps_CountriesId",
                table: "Clientes",
                newName: "PaisId");

            migrationBuilder.AddColumn<int>(
                name: "PaisId1",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Iso = table.Column<string>(nullable: true),
                    Modificado = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PaisId1",
                table: "Clientes",
                column: "PaisId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Pais_PaisId1",
                table: "Clientes",
                column: "PaisId1",
                principalTable: "Pais",
                principalColumn: "PaisId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
