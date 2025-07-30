using Cut_Roll_Movies.Core.Casts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cut_Roll_Movies.Core.Casts.Configuration;

public class CastConfiguration : IEntityTypeConfiguration<Cast>
{
    public void Configure(EntityTypeBuilder<Cast> builder)
    {
        builder.ToTable("cast")
        .HasKey(mg => new { mg.PersonId, mg.MovieId });

        builder.HasOne(c => c.Movie)
            .WithMany(m => m.Cast)
            .HasForeignKey(c => c.MovieId);

        builder.HasOne(c => c.Person)
            .WithMany(p => p.CastRoles)
            .HasForeignKey(c => c.PersonId);
    }
}
