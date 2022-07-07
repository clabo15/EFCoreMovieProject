using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies_Demo_2.Migrations
{
    public partial class AddCurrencyField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "CinemaHalls",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "CinemaHalls");
        }
    }
}
