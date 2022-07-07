using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.DTOs;

public class MovieFilterDTO
{
    public string Title { get; set; }
    public Guid GenreId { get; set; }
    public bool InCinemas { get; set; }
    public bool UpcomingReleases { get; set; }
}