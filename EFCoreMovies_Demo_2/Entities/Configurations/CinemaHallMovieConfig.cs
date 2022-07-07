using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies_Demo_2.Entities.Configurations;

public class CinemaHallMovieConfig : IEntityTypeConfiguration<CinemaHallMovie>
{
    public void Configure(EntityTypeBuilder<CinemaHallMovie> builder)
    {
        builder.HasKey(_ => new { _.CinemaHallId, _.MovieId });
    }
}