using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreMovies_Demo_2.Entities;

namespace EFCoreMovies_Demo_2.DTOs;

public class CinemaHallCreationDTO
{
    public Guid Id { get; set; }
    public double Cost { get; set; }
    public CinemaHallType CinemaHallType { get; set; }
}