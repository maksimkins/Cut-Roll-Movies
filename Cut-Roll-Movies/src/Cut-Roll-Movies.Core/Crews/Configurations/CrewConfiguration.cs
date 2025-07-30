namespace Cut_Roll_Movies.Core.Crews.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cut_Roll_Movies.Core.Crews.Models;

public class CrewConfiguration : IEntityTypeConfiguration<Crew>
{
    public void Configure(EntityTypeBuilder<Crew> builder)
    {
        builder.ToTable("crew")
            .HasKey(c => new { c.MovieId, c.PersonId });


        builder.HasOne(c => c.Movie)
            .WithMany(m => m.Crew)
            .HasForeignKey(c => c.MovieId);

        builder.HasOne(c => c.Person)
            .WithMany(p => p.CrewRoles)
            .HasForeignKey(c => c.PersonId);

    }
}