using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Sunrise.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Iso = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Modificado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "TipoH",
                columns: table => new
                {
                    TipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Tarifa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    T_Noche = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Modificado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoH", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Turno = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClientesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoIdentificacion = table.Column<string>(nullable: false),
                    Identificacion = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    PaisId = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Modificado = table.Column<DateTime>(nullable: false),
                    PaisId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClientesId);
                    table.ForeignKey(
                        name: "FK_Clientes_Pais_PaisId1",
                        column: x => x.PaisId1,
                        principalTable: "Pais",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    HabitacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    No_Habitacion = table.Column<int>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    AsignarReservacionId = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Modificado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.HabitacionId);
                    table.ForeignKey(
                        name: "FK_Habitacion_TipoH_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoH",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservacion",
                columns: table => new
                {
                    ReservacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ClientesId = table.Column<int>(nullable: false),
                    Fecha_Ingreso = table.Column<DateTime>(nullable: false),
                    Dias = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Modificado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservacion", x => x.ReservacionId);
                    table.ForeignKey(
                        name: "FK_Reservacion_Clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Clientes",
                        principalColumn: "ClientesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleReservacion",
                columns: table => new
                {
                    DetalleReservacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReservacionId = table.Column<int>(nullable: false),
                    HabitacionId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleReservacion", x => x.DetalleReservacionId);
                    table.ForeignKey(
                        name: "FK_DetalleReservacion_Habitacion_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitacion",
                        principalColumn: "HabitacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleReservacion_Reservacion_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservacion",
                        principalColumn: "ReservacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    PagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado_fact = table.Column<string>(nullable: true),
                    Tipo_Pago = table.Column<string>(nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReservacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pago_Reservacion_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservacion",
                        principalColumn: "ReservacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PaisId1",
                table: "Clientes",
                column: "PaisId1");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleReservacion_HabitacionId",
                table: "DetalleReservacion",
                column: "HabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleReservacion_ReservacionId",
                table: "DetalleReservacion",
                column: "ReservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_TipoId",
                table: "Habitacion",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ReservacionId",
                table: "Pago",
                column: "ReservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_ClientesId",
                table: "Reservacion",
                column: "ClientesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleReservacion");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "Reservacion");

            migrationBuilder.DropTable(
                name: "TipoH");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
