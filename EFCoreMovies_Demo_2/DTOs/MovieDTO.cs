using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreMovies_Demo_2.Entities;

namespace EFCoreMovies_Demo_2.DTOs;

public class MovieDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public ICollection<GenreDTO> Genres { get; set; }
    public ICollection<CinemaDTO> Cinemas { get; set; }
    public ICollection<ActorDTO> Actors { get; set; }

}