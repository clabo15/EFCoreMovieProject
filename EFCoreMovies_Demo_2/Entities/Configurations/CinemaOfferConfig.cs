using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies_Demo_2.Entities.Configurations;

public class CinemaOfferConfig : IEntityTypeConfiguration<CinemaOffer>
{
    public void Configure(EntityTypeBuilder<CinemaOffer> builder)
    {
        builder.Property(p => p.DiscountPercentage).HasPrecision(5, 2);
        builder.Property(p => p.Begin);
        builder.Property(p => p.End);
    }
}