using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace EFCoreMovies_Demo_2.Migrations
{
    public partial class InsertModule3Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Biography", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { new Guid("0bda6131-7ff7-48d8-80ac-b68a9cb5aa22"), null, new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keanu Reeves" },
                    { new Guid("5b12acb1-da6d-40f4-8112-dc60a26c2190"), "Samuel Leroy Jackson (born December 21, 1948) is an American actor and producer. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time (excluding cameo appearances and voice roles).", new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel L. Jackson" },
                    { new Guid("78787d39-3e76-4c00-b2ba-09e565abc68e"), null, new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auli'i Cravalho" },
                    { new Guid("8bb17c8b-6daf-409c-bd1b-cea29960152f"), null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Evans" },
                    { new Guid("9a00bd47-be1e-40ae-ba33-fa1022672eee"), null, new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwayne Johnson" },
                    { new Guid("9f9ab47b-c7ea-42da-a6a9-a74117335030"), "Robert John Downey Jr. (born April 4, 1965) is an American actor and producer. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success later in his career.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Downey Jr." },
                    { new Guid("db650382-7e89-4370-a68b-32b1547e76e4"), null, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlett Johansson" },
                    { new Guid("fcc7d4ee-1fd3-4314-a0c4-6519a03eb394"), "Thomas Stanley Holland (born 1 June 1996) is an English actor. He is recipient of several accolades, including the 2017 BAFTA Rising Star Award. Holland began his acting career as a child actor on the West End stage in Billy Elliot the Musical at the Victoria Palace Theatre in 2008, playing a supporting part", new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Holland" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("11050110-9e19-47e4-a5c4-648ee2d11e2d"), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)"), "Agora Mall" },
                    { new Guid("44e8898a-3baa-45f5-9848-77eefb592cbc"), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.939248 18.469649)"), "Acropolis" },
                    { new Guid("5631e3e8-17d8-4792-8465-c3a9dd8cd419"), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.911582 18.482455)"), "Sambil" },
                    { new Guid("bbef8cd5-3b7b-4351-89b5-da3cc5ae70de"), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.856309 18.506662)"), "Megacentro" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3dbc58eb-9ecd-4463-83fb-969558cacb60"), "Comedy" },
                    { new Guid("6f6a2004-828d-4672-b6f6-191fa912ef61"), "Action" },
                    { new Guid("6fbeadf1-e817-43b0-9a1a-8bf4541b819d"), "Animation" },
                    { new Guid("c3c7462e-77e9-49b5-8002-e9155ebd36da"), "Drama" },
                    { new Guid("cd61ff22-0e1d-4e6d-a1c3-77d294c0394f"), "Science Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "InCinemas", "PosterURL", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("06caa6de-e86a-4d33-83af-1e6501650fb6"), false, "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg", new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coco" },
                    { new Guid("340733b7-9d5b-4235-bb4f-4f040a53fa6c"), false, "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: No way home" },
                    { new Guid("7adf1c01-f6f9-4768-a258-7c3162dda432"), false, "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers" },
                    { new Guid("9842b461-ac1e-4553-898b-bcb4bb0eddb7"), false, "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: Far From Home" },
                    { new Guid("f3d18550-7488-44b7-be01-256662c285c4"), true, "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix Resurrections" }
                });

            migrationBuilder.InsertData(
                table: "CinemaHalls",
                columns: new[] { "Id", "CinemaHallType", "CinemaId", "Cost" },
                values: new object[,]
                {
                    { new Guid("25d2aaa5-9972-41b8-a270-2bd68f025004"), 3, new Guid("bbef8cd5-3b7b-4351-89b5-da3cc5ae70de"), 450m },
                    { new Guid("2c46b128-28eb-41cc-aa61-cffe16de6323"), 1, new Guid("bbef8cd5-3b7b-4351-89b5-da3cc5ae70de"), 250m },
                    { new Guid("2e32ab6e-4d73-40bd-afb3-02f35010ad08"), 1, new Guid("5631e3e8-17d8-4792-8465-c3a9dd8cd419"), 200m },
                    { new Guid("5f373a94-ef2d-4ae6-9a90-5500bd7e3e0f"), 2, new Guid("bbef8cd5-3b7b-4351-89b5-da3cc5ae70de"), 330m },
                    { new Guid("732bf925-406c-4da7-a0f0-3c59cb29b3e5"), 1, new Guid("11050110-9e19-47e4-a5c4-648ee2d11e2d"), 220m },
                    { new Guid("76e0328f-8b98-4725-92c8-8d43fc1ac124"), 2, new Guid("5631e3e8-17d8-4792-8465-c3a9dd8cd419"), 290m },
                    { new Guid("7c94e70b-7592-4abd-8fa7-691cf6e4e321"), 2, new Guid("11050110-9e19-47e4-a5c4-648ee2d11e2d"), 320m },
                    { new Guid("c8c230c7-a254-418b-9b6f-a56ea3d603a2"), 1, new Guid("44e8898a-3baa-45f5-9848-77eefb592cbc"), 250m }
                });

            migrationBuilder.InsertData(
                table: "CinemasOffers",
                columns: new[] { "Id", "Begin", "CinemaId", "DiscountPercentage", "End" },
                values: new object[,]
                {
                    { new Guid("0367a614-e1e1-4d66-be6f-ae49b4808a15"), new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11050110-9e19-47e4-a5c4-648ee2d11e2d"), 10m, new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b9381ce-4090-42e1-a4cf-eb3fb0f749f9"), new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44e8898a-3baa-45f5-9848-77eefb592cbc"), 15m, new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MoviesActors",
                columns: new[] { "ActorId", "MovieId", "Character", "Order" },
                values: new object[,]
                {
                    { new Guid("0bda6131-7ff7-48d8-80ac-b68a9cb5aa22"), new Guid("f3d18550-7488-44b7-be01-256662c285c4"), "Neo", 1 },
                    { new Guid("5b12acb1-da6d-40f4-8112-dc60a26c2190"), new Guid("9842b461-ac1e-4553-898b-bcb4bb0eddb7"), "Samuel L. Jackson", 2 },
                    { new Guid("8bb17c8b-6daf-409c-bd1b-cea29960152f"), new Guid("7adf1c01-f6f9-4768-a258-7c3162dda432"), "Capitán América", 1 },
                    { new Guid("9f9ab47b-c7ea-42da-a6a9-a74117335030"), new Guid("7adf1c01-f6f9-4768-a258-7c3162dda432"), "Iron Man", 2 },
                    { new Guid("db650382-7e89-4370-a68b-32b1547e76e4"), new Guid("7adf1c01-f6f9-4768-a258-7c3162dda432"), "Black Widow", 3 },
                    { new Guid("fcc7d4ee-1fd3-4314-a0c4-6519a03eb394"), new Guid("340733b7-9d5b-4235-bb4f-4f040a53fa6c"), "Peter Parker", 1 },
                    { new Guid("fcc7d4ee-1fd3-4314-a0c4-6519a03eb394"), new Guid("9842b461-ac1e-4553-898b-bcb4bb0eddb7"), "Peter Parker", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("78787d39-3e76-4c00-b2ba-09e565abc68e"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("9a00bd47-be1e-40ae-ba33-fa1022672eee"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("25d2aaa5-9972-41b8-a270-2bd68f025004"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("2c46b128-28eb-41cc-aa61-cffe16de6323"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("2e32ab6e-4d73-40bd-afb3-02f35010ad08"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("5f373a94-ef2d-4ae6-9a90-5500bd7e3e0f"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("732bf925-406c-4da7-a0f0-3c59cb29b3e5"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("76e0328f-8b98-4725-92c8-8d43fc1ac124"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("7c94e70b-7592-4abd-8fa7-691cf6e4e321"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("c8c230c7-a254-418b-9b6f-a56ea3d603a2"));

            migrationBuilder.DeleteData(
                table: "CinemasOffers",
                keyColumn: "Id",
                keyValue: new Guid("0367a614-e1e1-4d66-be6f-ae49b4808a15"));

            migrationBuilder.DeleteData(
                table: "CinemasOffers",
                keyColumn: "Id",
                keyValue: new Guid("2b9381ce-4090-42e1-a4cf-eb3fb0f749f9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3dbc58eb-9ecd-4463-83fb-969558cacb60"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6f6a2004-828d-4672-b6f6-191fa912ef61"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6fbeadf1-e817-43b0-9a1a-8bf4541b819d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c3c7462e-77e9-49b5-8002-e9155ebd36da"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cd61ff22-0e1d-4e6d-a1c3-77d294c0394f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("06caa6de-e86a-4d33-83af-1e6501650fb6"));

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("0bda6131-7ff7-48d8-80ac-b68a9cb5aa22"), new Guid("f3d18550-7488-44b7-be01-256662c285c4") });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("5b12acb1-da6d-40f4-8112-dc60a26c2190"), new Guid("9842b461-ac1e-4553-898b-bcb4bb0eddb7") });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("8bb17c8b-6daf-409c-bd1b-cea29960152f"), new Guid("7adf1c01-f6f9-4768-a258-7c3162dda432") });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("9f9ab47b-c7ea-42da-a6a9-a74117335030"), new Guid("7adf1c01-f6f9-4768-a258-7c3162dda432") });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("db650382-7e89-4370-a68b-32b1547e76e4"), new Guid("7adf1c01-f6f9-4768-a258-7c3162dda432") });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("fcc7d4ee-1fd3-4314-a0c4-6519a03eb394"), new Guid("340733b7-9d5b-4235-bb4f-4f040a53fa6c") });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("fcc7d4ee-1fd3-4314-a0c4-6519a03eb394"), new Guid("9842b461-ac1e-4553-898b-bcb4bb0eddb7") });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("0bda6131-7ff7-48d8-80ac-b68a9cb5aa22"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("5b12acb1-da6d-40f4-8112-dc60a26c2190"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("8bb17c8b-6daf-409c-bd1b-cea29960152f"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("9f9ab47b-c7ea-42da-a6a9-a74117335030"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("db650382-7e89-4370-a68b-32b1547e76e4"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("fcc7d4ee-1fd3-4314-a0c4-6519a03eb394"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("11050110-9e19-47e4-a5c4-648ee2d11e2d"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("44e8898a-3baa-45f5-9848-77eefb592cbc"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("5631e3e8-17d8-4792-8465-c3a9dd8cd419"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("bbef8cd5-3b7b-4351-89b5-da3cc5ae70de"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("340733b7-9d5b-4235-bb4f-4f040a53fa6c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7adf1c01-f6f9-4768-a258-7c3162dda432"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9842b461-ac1e-4553-898b-bcb4bb0eddb7"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f3d18550-7488-44b7-be01-256662c285c4"));
        }
    }
}
