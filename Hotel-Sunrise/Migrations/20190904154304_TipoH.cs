using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Sunrise.Migrations
{
    public partial class TipoH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleReservacion_Habitacion_HabitacionId",
                table: "DetalleReservacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitacion_TipoH_TipoId",
                table: "Habitacion");

            migrationBuilder.DropTable(
                name: "TipoH");

            migrationBuilder.DropIndex(
                name: "IX_Habitacion_TipoId",
                table: "Habitacion");

            migrationBuilder.DropIndex(
                name: "IX_DetalleReservacion_HabitacionId",
                table: "DetalleReservacion");

            migrationBuilder.DropColumn(
                name: "AsignarReservacionId",
                table: "Habitacion");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Habitacion");

            migrationBuilder.DropColumn(
                name: "Modificado",
                table: "Habitacion");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Habitacion");

            migrationBuilder.DropColumn(
                name: "HabitacionId",
                table: "DetalleReservacion");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Habitacion",
                newName: "Tipo_Habitacionid");

            migrationBuilder.RenameColumn(
                name: "Apps_CountriesId",
                table: "Clientes",
                newName: "Pais");

            migrationBuilder.AddColumn<bool>(
                name: "ocupada",
                table: "Habitacion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Tipo_Habitacion",
                columns: table => new
                {
                    Tipo_Habitacionid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DetalleReservacionId = table.Column<int>(nullable: false),
                    Camas = table.Column<int>(nullable: false),
                    PrecioDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Habitacion", x => x.Tipo_Habitacionid);
                    table.ForeignKey(
                        name: "FK_Tipo_Habitacion_DetalleReservacion_DetalleReservacionId",
                        column: x => x.DetalleReservacionId,
                        principalTable: "DetalleReservacion",
                        principalColumn: "DetalleReservacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_Tipo_Habitacionid",
                table: "Habitacion",
                column: "Tipo_Habitacionid");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Habitacion_DetalleReservacionId",
                table: "Tipo_Habitacion",
                column: "DetalleReservacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacion_Tipo_Habitacion_Tipo_Habitacionid",
                table: "Habitacion",
                column: "Tipo_Habitacionid",
                principalTable: "Tipo_Habitacion",
                principalColumn: "Tipo_Habitacionid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacion_Tipo_Habitacion_Tipo_Habitacionid",
                table: "Habitacion");

            migrationBuilder.DropTable(
                name: "Tipo_Habitacion");

            migrationBuilder.DropIndex(
                name: "IX_Habitacion_Tipo_Habitacionid",
                table: "Habitacion");

            migrationBuilder.DropColumn(
                name: "ocupada",
                table: "Habitacion");

            migrationBuilder.RenameColumn(
                name: "Tipo_Habitacionid",
                table: "Habitacion",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "Clientes",
                newName: "Apps_CountriesId");

            migrationBuilder.AddColumn<int>(
                name: "AsignarReservacionId",
                table: "Habitacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Habitacion",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modificado",
                table: "Habitacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Habitacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HabitacionId",
                table: "DetalleReservacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoH",
                columns: table => new
                {
                    TipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Modificado = table.Column<DateTime>(nullable: false),
                    T_Noche = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarifa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoH", x => x.TipoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_TipoId",
                table: "Habitacion",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleReservacion_HabitacionId",
                table: "DetalleReservacion",
                column: "HabitacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleReservacion_Habitacion_HabitacionId",
                table: "DetalleReservacion",
                column: "HabitacionId",
                principalTable: "Habitacion",
                principalColumn: "HabitacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacion_TipoH_TipoId",
                table: "Habitacion",
                column: "TipoId",
                principalTable: "TipoH",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
