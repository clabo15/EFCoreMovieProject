using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.DTOs;

public class ActorDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
}