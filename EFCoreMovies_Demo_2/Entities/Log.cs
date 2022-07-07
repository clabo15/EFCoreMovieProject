using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.Entities;

public class Log
{
    public Guid Id { get; set; }
    public string Message { get; set; }

    public Log()
    {
        Id = Guid.NewGuid();
    }
}