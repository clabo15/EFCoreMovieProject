using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.Entities;

public class CinemaHall
{
    public Guid Id { get; set; }
    public CinemaHallType CinemaHallType { get; set; }
    public decimal Cost { get; set; }
    public Currency Currency { get; set; }
    public Guid CinemaId { get; set; }
    public Cinema Cinema { get; set; }
    public HashSet<CinemaHallMovie> CinemaHallMovies { get; set; }
}