using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies_Demo_2.Entities.Configurations;

public class GenreConfig : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        // Filter to only display genres where IsDelete is false
        builder.HasQueryFilter(g => !g.IsDelete);
        //Index
        //builder.HasIndex(p => p.Name).IsUnique().HasFilter("IsDelete = 'false'");
        builder.HasIndex(p => p.Name).IsUnique();

        // Shadow Property
        builder.Property<DateTime>("CreatedDate").HasDefaultValueSql("LOCALTIMESTAMP").HasColumnType("timestamp with time zone");
    }
}