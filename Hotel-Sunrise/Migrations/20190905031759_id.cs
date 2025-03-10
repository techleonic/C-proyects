﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Sunrise.Migrations
{
    public partial class id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdHabitacion",
                table: "Reservacion",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdHabitacion",
                table: "Reservacion");
        }
    }
}
