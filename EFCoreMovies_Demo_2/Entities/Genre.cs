using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.Entities;

public class Genre
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsDelete { get; set; }
    public HashSet<GenreMovie> GenreMovies { get; set; }
}