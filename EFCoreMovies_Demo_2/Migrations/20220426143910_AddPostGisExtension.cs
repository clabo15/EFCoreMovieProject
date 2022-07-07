using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies_Demo_2.Migrations
{
    public partial class AddPostGisExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = AppDomain.CurrentDomain.BaseDirectory + @"\SQL\CreateExtensionPostGis.sql";
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
