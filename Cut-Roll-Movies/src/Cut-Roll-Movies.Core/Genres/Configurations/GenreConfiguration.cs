namespace Cut_Roll_Movies.Core.Genres.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cut_Roll_Movies.Core.Genres.Models;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    { 
        builder.ToTable("genres")
            .HasKey(g => g.Id);
    }
}

