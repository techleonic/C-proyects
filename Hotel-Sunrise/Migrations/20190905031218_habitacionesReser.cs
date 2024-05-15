using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Sunrise.Migrations
{
    public partial class habitacionesReser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reservacionesid",
                table: "listaHabitaciones",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reservacionesid",
                table: "listaHabitaciones");
        }
    }
}
