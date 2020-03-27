using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinoteca.Data.Migrations
{
    public partial class agregadoFotos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Vinos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Vinos");
        }
    }
}
