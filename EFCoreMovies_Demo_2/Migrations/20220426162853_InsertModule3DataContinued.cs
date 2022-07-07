using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies_Demo_2.Migrations
{
    public partial class InsertModule3DataContinued : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = AppDomain.CurrentDomain.BaseDirectory + @"\SQL\InsertModule3DataContinued.sql";
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
