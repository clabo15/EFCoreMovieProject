using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies_Demo_2.Entities.Configurations;

public class MovieConfig : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(p => p.Title).HasMaxLength(250).IsRequired();
        builder.Property(p => p.ReleaseDate);
        builder.Property(p => p.PosterURL).HasMaxLength(500).IsUnicode(false);
    }
}