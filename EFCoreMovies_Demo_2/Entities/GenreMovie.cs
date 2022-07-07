using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.Entities;

public class GenreMovie
{
    public Guid GenreId { get; set; }
    public virtual Genre Genre { get; set; }
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }
}