using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies_Demo_2.Entities.Configurations;

public class GenreMovieConfig : IEntityTypeConfiguration<GenreMovie>
{
    public void Configure(EntityTypeBuilder<GenreMovie> builder)
    {
        builder.HasKey(_ => new { _.MovieId, _.GenreId });
    }
}