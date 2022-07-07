using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.DTOs;

public class GenreCreationDTO
{
    [Required]
    public string Name { get; set; }
}