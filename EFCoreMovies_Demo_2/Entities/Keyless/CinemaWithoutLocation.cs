using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.Entities.Keyless;

public class CinemaWithoutLocation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}