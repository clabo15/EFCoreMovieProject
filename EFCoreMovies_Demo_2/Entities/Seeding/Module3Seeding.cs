using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies_Demo_2.Entities.Seeding;

public static class Module3Seeding
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Insert Genre Data
        var action = new Genre { Id = new Guid("6f6a2004-828d-4672-b6f6-191fa912ef61"), Name = "Action" };
        var animation = new Genre { Id = new Guid("6fbeadf1-e817-43b0-9a1a-8bf4541b819d"), Name = "Animation" };
        var comedy = new Genre { Id = new Guid("3dbc58eb-9ecd-4463-83fb-969558cacb60"), Name = "Comedy" };
        var scienceFiction = new Genre { Id = new Guid("cd61ff22-0e1d-4e6d-a1c3-77d294c0394f"), Name = "Science Fiction" };
        var drama = new Genre { Id = new Guid("c3c7462e-77e9-49b5-8002-e9155ebd36da"), Name = "Drama" };
        modelBuilder.Entity<Genre>().HasData(action, animation, comedy, scienceFiction, drama);

        // Insert Actor Data
        var tomHolland = new Actor { Id = new Guid("fcc7d4ee-1fd3-4314-a0c4-6519a03eb394"), Name = "Tom Holland", DateOfBirth = new DateTime(1996, 6, 1), Biography = "Thomas Stanley Holland (born 1 June 1996) is an English actor. He is recipient of several accolades, including the 2017 BAFTA Rising Star Award. Holland began his acting career as a child actor on the West End stage in Billy Elliot the Musical at the Victoria Palace Theatre in 2008, playing a supporting part" };
        var samuelJackson = new Actor { Id = new Guid("5b12acb1-da6d-40f4-8112-dc60a26c2190"), Name = "Samuel L. Jackson", DateOfBirth = new DateTime(1948, 12, 21), Biography = "Samuel Leroy Jackson (born December 21, 1948) is an American actor and producer. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time (excluding cameo appearances and voice roles)." };
        var robertDowney = new Actor { Id = new Guid("9f9ab47b-c7ea-42da-a6a9-a74117335030"), Name = "Robert Downey Jr.", DateOfBirth = new DateTime(1965, 4, 4), Biography = "Robert John Downey Jr. (born April 4, 1965) is an American actor and producer. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success later in his career." };
        var chrisEvans = new Actor { Id = new Guid("8bb17c8b-6daf-409c-bd1b-cea29960152f"), Name = "Chris Evans", DateOfBirth = new DateTime(1981, 06, 13) };
        var laRoca = new Actor { Id = new Guid("9a00bd47-be1e-40ae-ba33-fa1022672eee"), Name = "Dwayne Johnson", DateOfBirth = new DateTime(1972, 5, 2) };
        var auliCravalho = new Actor { Id = new Guid("78787d39-3e76-4c00-b2ba-09e565abc68e"), Name = "Auli'i Cravalho", DateOfBirth = new DateTime(2000, 11, 22) };
        var scarlettJohansson = new Actor { Id = new Guid("db650382-7e89-4370-a68b-32b1547e76e4"), Name = "Scarlett Johansson", DateOfBirth = new DateTime(1984, 11, 22) };
        var keanuReeves = new Actor { Id = new Guid("0bda6131-7ff7-48d8-80ac-b68a9cb5aa22"), Name = "Keanu Reeves", DateOfBirth = new DateTime(1964, 9, 2) };
        modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
            robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);

        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

        // Insert Cinema Data
        var agora = new Cinema { Id = new Guid("11050110-9e19-47e4-a5c4-648ee2d11e2d"), Name = "Agora Mall", Location = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
        var sambil = new Cinema { Id = new Guid("5631e3e8-17d8-4792-8465-c3a9dd8cd419"), Name = "Sambil", Location = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
        var megacentro = new Cinema { Id = new Guid("bbef8cd5-3b7b-4351-89b5-da3cc5ae70de"), Name = "Megacentro", Location = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
        var acropolis = new Cinema { Id = new Guid("44e8898a-3baa-45f5-9848-77eefb592cbc"), Name = "Acropolis", Location = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };
        var AMC = new Cinema
        {
            Id = new Guid("0cbe7156-4cb8-45de-a6d1-b8748e4d114d"), Name = "AMC", Location = geometryFactory.CreatePoint(new Coordinate(-91.083980, 30.385680))
        };
        modelBuilder.Entity<Cinema>().HasData(agora, sambil, megacentro, acropolis, AMC);

        // Insert CinemaOffer Data
        var agorraOffer = new CinemaOffer { Id = new Guid("0367a614-e1e1-4d66-be6f-ae49b4808a15"), CinemaId = agora.Id, Begin = new DateTime(2022, 2, 22), End = new DateTime(2022, 4, 22), DiscountPercentage = 10 };
        var acropolisOffer = new CinemaOffer { Id = new Guid("2b9381ce-4090-42e1-a4cf-eb3fb0f749f9"), CinemaId = acropolis.Id, Begin = new DateTime(2022, 2, 15), End = new DateTime(2022, 2, 22), DiscountPercentage = 15 };
        modelBuilder.Entity<CinemaOffer>().HasData(acropolisOffer, agorraOffer);

        // Insert CinemaHall Data
        var cinemaHall2DAgora = new CinemaHall
        {
            Id = new Guid("732bf925-406c-4da7-a0f0-3c59cb29b3e5"),
            CinemaId = agora.Id,
            Cost = 220,
            CinemaHallType = CinemaHallType.TwoDimensions
        };
        var cinemaHall3DAgora = new CinemaHall
        {
            Id = new Guid("7c94e70b-7592-4abd-8fa7-691cf6e4e321"),
            CinemaId = agora.Id,
            Cost = 320,
            CinemaHallType = CinemaHallType.ThreeDimensions
        };
        var cinemaHall2DSambil = new CinemaHall
        {
            Id = new Guid("2e32ab6e-4d73-40bd-afb3-02f35010ad08"),
            CinemaId = sambil.Id,
            Cost = 200,
            CinemaHallType = CinemaHallType.TwoDimensions
        };
        var cinemaHall3DSambil = new CinemaHall
        {
            Id = new Guid("76e0328f-8b98-4725-92c8-8d43fc1ac124"),
            CinemaId = sambil.Id,
            Cost = 290,
            CinemaHallType = CinemaHallType.ThreeDimensions
        };
        var cinemaHall2DMegacentro = new CinemaHall
        {
            Id = new Guid("2c46b128-28eb-41cc-aa61-cffe16de6323"),
            CinemaId = megacentro.Id,
            Cost = 250,
            CinemaHallType = CinemaHallType.TwoDimensions
        };
        var cinemaHall3DMegacentro = new CinemaHall
        {
            Id = new Guid("5f373a94-ef2d-4ae6-9a90-5500bd7e3e0f"),
            CinemaId = megacentro.Id,
            Cost = 330,
            CinemaHallType = CinemaHallType.ThreeDimensions
        };
        var cinemaHallCXCMegacentro = new CinemaHall
        {
            Id = new Guid("25d2aaa5-9972-41b8-a270-2bd68f025004"),
            CinemaId = megacentro.Id,
            Cost = 450,
            CinemaHallType = CinemaHallType.CXC
        };
        var cinemaHall2DAcropolis = new CinemaHall
        {
            Id = new Guid("c8c230c7-a254-418b-9b6f-a56ea3d603a2"),
            CinemaId = acropolis.Id,
            Cost = 250,
            CinemaHallType = CinemaHallType.TwoDimensions
        };
        modelBuilder.Entity<CinemaHall>().HasData(cinemaHall2DMegacentro, cinemaHall3DMegacentro, cinemaHallCXCMegacentro, cinemaHall2DAcropolis, cinemaHall2DAgora, cinemaHall3DAgora, cinemaHall2DSambil, cinemaHall3DSambil);

        // Insert Movie Data
        var avengers = new Movie()
        {
            Id = new Guid("7adf1c01-f6f9-4768-a258-7c3162dda432"),
            Title = "Avengers",
            InCinemas = false,
            ReleaseDate = new DateTime(2012, 4, 11),
            PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
        };

        //Relationships
        var entityCinemaHallMovie = "CinemaHallMovies";
        var cinemaHallsId = "CinemaHallId";
        var moviesId = "MovieId";

        var entityGenreMovie = "GenreMovies";
        var genresId = "GenreId";

        //modelBuilder.Entity(entityGenreMovie).HasData(
        //    new Dictionary<string, object>
        //    {
        //        [genresId] = action.Id,
        //        [moviesId] = avengers.Id
        //    },
        //    new Dictionary<string, object>
        //    {
        //        [genresId] = scienceFiction.Id,
        //        [moviesId] = avengers.Id
        //    }
        //);

        var coco = new Movie()
        {
            Id = new Guid("06caa6de-e86a-4d33-83af-1e6501650fb6"),
            Title = "Coco",
            InCinemas = false,
            ReleaseDate = new DateTime(2017, 11, 22),
            PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
        };

       // modelBuilder.Entity(entityGenreMovie).HasData(
       //    new Dictionary<string, object> { [genresId] = animation.Id, [moviesId] = coco.Id }
       //);

        var noWayHome = new Movie()
        {
            Id = new Guid("340733b7-9d5b-4235-bb4f-4f040a53fa6c"),
            Title = "Spider-Man: No way home",
            InCinemas = false,
            ReleaseDate = new DateTime(2022, 12, 17),
            PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
        };

       // modelBuilder.Entity(entityGenreMovie).HasData(
       //    new Dictionary<string, object> { [genresId] = scienceFiction.Id, [moviesId] = noWayHome.Id },
       //    new Dictionary<string, object> { [genresId] = action.Id, [moviesId] = noWayHome.Id },
       //    new Dictionary<string, object> { [genresId] = comedy.Id, [moviesId] = noWayHome.Id }
       //);

        var farFromHome = new Movie()
        {
            Id = new Guid("9842b461-ac1e-4553-898b-bcb4bb0eddb7"),
            Title = "Spider-Man: Far From Home",
            InCinemas = false,
            ReleaseDate = new DateTime(2019, 7, 2),
            PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
        };

       // modelBuilder.Entity(entityGenreMovie).HasData(
       //    new Dictionary<string, object> { [genresId] = scienceFiction.Id, [moviesId] = farFromHome.Id },
       //    new Dictionary<string, object> { [genresId] = action.Id, [moviesId] = farFromHome.Id },
       //    new Dictionary<string, object> { [genresId] = comedy.Id, [moviesId] = farFromHome.Id }
       //);

        var theMatrixResurrections = new Movie()
        {
            Id = new Guid("f3d18550-7488-44b7-be01-256662c285c4"),
            Title = "The Matrix Resurrections",
            InCinemas = true,
            ReleaseDate = new DateTime(2023, 1, 1),
            PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
        };

        //  modelBuilder.Entity(entityGenreMovie).HasData(
        //    new Dictionary<string, object> { [genresId] = scienceFiction.Id, [moviesId] = theMatrixResurrections.Id },
        //    new Dictionary<string, object> { [genresId] = action.Id, [moviesId] = theMatrixResurrections.Id },
        //    new Dictionary<string, object> { [genresId] = drama.Id, [moviesId] = theMatrixResurrections.Id }
        //);
        // Cinema Hall Data
        //modelBuilder.Entity(entityCinemaHallMovie).HasData(
        //    new Dictionary<string, object> { [cinemaHallsId] = cinemaHall2DSambil.Id, [moviesId] = theMatrixResurrections.Id },
        //    new Dictionary<string, object> { [cinemaHallsId] = cinemaHall3DSambil.Id, [moviesId] = theMatrixResurrections.Id },
        //    new Dictionary<string, object> { [cinemaHallsId] = cinemaHall2DAgora.Id, [moviesId] = theMatrixResurrections.Id },
        //    new Dictionary<string, object> { [cinemaHallsId] = cinemaHall3DAgora.Id, [moviesId] = theMatrixResurrections.Id },
        //    new Dictionary<string, object> { [cinemaHallsId] = cinemaHall2DMegacentro.Id, [moviesId] = theMatrixResurrections.Id },
        //    new Dictionary<string, object> { [cinemaHallsId] = cinemaHall3DMegacentro.Id, [moviesId] = theMatrixResurrections.Id },
        //    new Dictionary<string, object> { [cinemaHallsId] = cinemaHallCXCMegacentro.Id, [moviesId] = theMatrixResurrections.Id }
        //);

        // MovieActor Data
        var keanuReevesMatrix = new MovieActor
        {
            ActorId = keanuReeves.Id,
            MovieId = theMatrixResurrections.Id,
            Order = 1,
            Character = "Neo"
        };

        var avengersChrisEvans = new MovieActor
        {
            ActorId = chrisEvans.Id,
            MovieId = avengers.Id,
            Order = 1,
            Character = "Capitán América"
        };

        var avengersRobertDowney = new MovieActor
        {
            ActorId = robertDowney.Id,
            MovieId = avengers.Id,
            Order = 2,
            Character = "Iron Man"
        };

        var avengersScarlettJohansson = new MovieActor
        {
            ActorId = scarlettJohansson.Id,
            MovieId = avengers.Id,
            Order = 3,
            Character = "Black Widow"
        };

        var tomHollandFFH = new MovieActor
        {
            ActorId = tomHolland.Id,
            MovieId = farFromHome.Id,
            Order = 1,
            Character = "Peter Parker"
        };

        var tomHollandNWH = new MovieActor
        {
            ActorId = tomHolland.Id,
            MovieId = noWayHome.Id,
            Order = 1,
            Character = "Peter Parker"
        };

        var samuelJacksonFFH = new MovieActor
        {
            ActorId = samuelJackson.Id,
            MovieId = farFromHome.Id,
            Order = 2,
            Character = "Samuel L. Jackson"
        };

        modelBuilder.Entity<Movie>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);

        modelBuilder.Entity<MovieActor>().HasData(samuelJacksonFFH, tomHollandFFH,
            tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
            avengersChrisEvans, keanuReevesMatrix);
    }
}