using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.Entities;

public class MovieActor
{
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }
    public Guid ActorId { get; set; }
    public Actor Actor { get; set; }
    public string Character { get; set; }
    public int Order { get; set; }
    
}