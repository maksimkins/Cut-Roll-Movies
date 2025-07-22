using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cut_Roll_Movies.Core.Casts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cut_Roll_Movies.Core.Casts.Configuration;

public class CastConfiguration : IEntityTypeConfiguration<Cast>
{
    public void Configure(EntityTypeBuilder<Cast> builder)
    {
        builder.ToTable("cast")
        .HasKey(c => c.Id);

        builder.HasOne(c => c.Movie)
            .WithMany(m => m.Cast)
            .HasForeignKey(c => c.MovieId);

        builder.HasOne(c => c.Person)
            .WithMany(p => p.CastRoles)
            .HasForeignKey(c => c.PersonId);
    }
}
