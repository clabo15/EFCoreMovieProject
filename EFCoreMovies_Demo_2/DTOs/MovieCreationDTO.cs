using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.DTOs;

public class MovieCreationDTO
{
    public string Title { get; set; }
    public bool InCinemas { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<Guid> GenresIds { get; set; }
    public List<Guid> CinemaHallIds { get; set; }
    public List<MovieActorCreationDTO> MoviesActors { get; set; }
}