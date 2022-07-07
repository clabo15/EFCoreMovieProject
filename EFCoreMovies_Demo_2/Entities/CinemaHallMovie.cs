using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.Entities;

public class CinemaHallMovie
{
    public Guid CinemaHallId { get; set; }
    public CinemaHall CinemaHall { get; set; }
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }
}