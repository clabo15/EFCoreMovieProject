using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.Entities.Keyless;

public class MovieWithCounts
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int AmountGenres { get; set; }
    public int AmountCinemas { get; set; }
    public int AmountActors { get; set; }
}