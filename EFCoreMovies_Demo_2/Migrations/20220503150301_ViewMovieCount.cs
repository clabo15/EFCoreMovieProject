using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies_Demo_2.Migrations
{
    public partial class ViewMovieCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW public.movieswithcounts
                AS
                    SELECT ""Movies"".""Id"",
                        ""Movies"".""Title"",
                        ( SELECT count(*) AS count
                            FROM ""GenreMovies""
                            WHERE ""GenreMovies"".""MovieId"" = ""Movies"".""Id"") AS amountgenres,
                        ( SELECT count(DISTINCT ""CinemaHallMovies"".""MovieId"") AS count
                            FROM ""CinemaHallMovies""
                                JOIN ""CinemaHalls"" ON ""CinemaHalls"".""Id"" = ""CinemaHallMovies"".""CinemaHallId""
                            WHERE ""CinemaHallMovies"".""MovieId"" = ""Movies"".""Id"") AS amountcinemas,
                        ( SELECT count(*) AS count
                            FROM ""MoviesActors""
                            WHERE ""MoviesActors"".""MovieId"" = ""Movies"".""Id"") AS amountactors
                        FROM ""Movies"";");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW public.movieswithcounts");
        }
    }
}
