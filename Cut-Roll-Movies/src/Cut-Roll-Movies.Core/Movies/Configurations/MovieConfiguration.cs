namespace Cut_Roll_Movies.Core.Movies.Configurations;

using Cut_Roll_Movies.Core.Movies.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movies")
            .HasKey(m => m.Id);
    }
}

