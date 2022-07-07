using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace EFCoreMovies_Demo_2.Entities;

public class Cinema
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Point Location { get; set; }
    public CinemaOffer CinemaOffer { get; set; }
    public HashSet<CinemaHall> CinemaHalls { get; set; }
}