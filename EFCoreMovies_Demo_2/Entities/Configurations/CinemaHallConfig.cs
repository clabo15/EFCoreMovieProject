using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreMovies_Demo_2.Entities.Conversions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies_Demo_2.Entities.Configurations;

public class CinemaHallConfig : IEntityTypeConfiguration<CinemaHall>
{
    public void Configure(EntityTypeBuilder<CinemaHall> builder)
    {
        builder.Property(p => p.Cost).HasPrecision(9, 2);
        builder.Property(p => p.CinemaHallType).HasDefaultValue(CinemaHallType.TwoDimensions);
        builder.Property(p => p.Currency).HasConversion<CurrencyToSymbolConverter>();
    }
}