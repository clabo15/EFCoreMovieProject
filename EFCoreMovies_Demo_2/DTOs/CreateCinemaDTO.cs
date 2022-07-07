using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.DTOs;

public class CreateCinemaDTO
{
    public string Name { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public CinemaOfferCreationDTO CinemaOffer { get; set; }
    public CinemaHallCreationDTO[] CinemaHalls { get; set; }
}