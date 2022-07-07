using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFCoreMovies_Demo_2.Entities;
using EFCoreMovies_Demo_2.Entities.Keyless;
using EFCoreMovies_Demo_2.Entities.Seeding;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies_Demo_2;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<CinemaOffer> CinemasOffers { get; set; }
    public DbSet<CinemaHall> CinemaHalls { get; set; }
    public DbSet<CinemaHallMovie> CinemaHallMovies { get; set; }
    public DbSet<GenreMovie> GenreMovies { get; set; }
    public DbSet<MovieActor> MoviesActors { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<CinemaWithoutLocation> CinemaWithoutLocations { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        configurationBuilder.Properties<string>().HaveMaxLength(150);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        Module3Seeding.Seed(builder);

        // Raw SQL
        builder.Entity<CinemaWithoutLocation>().ToSqlQuery("select \"Id\", \"Name\" from public.\"Cinemas\"").ToView(null);

        //builder.Entity<MovieWithCounts>().ToView("movieswithcounts");
        builder.Entity<MovieWithCounts>().ToSqlQuery("select * from public.movieswithcounts");

        
    }
}