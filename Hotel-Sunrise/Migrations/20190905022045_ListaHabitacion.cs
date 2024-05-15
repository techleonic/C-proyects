using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Sunrise.Migrations
{
    public partial class ListaHabitacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "listaHabitaciones",
                columns: table => new
                {
                    ListaHabitacionesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true),
                    Camas = table.Column<int>(nullable: false),
                    PrecioxDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaSalida = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listaHabitaciones", x => x.ListaHabitacionesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "listaHabitaciones");
        }
    }
}
