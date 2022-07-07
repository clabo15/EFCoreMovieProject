using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.Entities;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool InCinemas { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string PosterURL { get; set; }
    public List<CinemaHallMovie> CinemaHallMovies { get; set; }
    public List<GenreMovie> GenreMovies { get; set; }
    public List<MovieActor> MoviesActors { get; set; }
    //public HashSet<Genre> Genres { get; set; }
}