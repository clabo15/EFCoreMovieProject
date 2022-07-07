using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies_Demo_2.Migrations
{
    public partial class CleanUpModule6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureURL",
                table: "Actors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureURL",
                table: "Actors",
                type: "character varying(150)",
                unicode: false,
                maxLength: 150,
                nullable: true);
        }
    }
}
