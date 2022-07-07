using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.DTOs;

public class MovieActorCreationDTO
{
    public Guid ActorId { get; set; }
    public string Character { get; set; }
}