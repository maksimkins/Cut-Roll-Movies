namespace Cut_Roll_Movies.Core.MovieImages.Configurations;

using Cut_Roll_Movies.Core.MovieImages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MovieImageConfiguration : IEntityTypeConfiguration<MovieImage>
{
    public void Configure(EntityTypeBuilder<MovieImage> builder)
    {
        builder.ToTable("movie_images")
            .HasKey(i => i.Id);

        builder.HasOne(i => i.Movie)
            .WithMany(m => m.Images)
            .HasForeignKey(i => i.MovieId);
    }
}
