using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Sunrise.Migrations
{
    public partial class Disponible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponible",
                table: "listaHabitaciones",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponible",
                table: "listaHabitaciones");
        }
    }
}
