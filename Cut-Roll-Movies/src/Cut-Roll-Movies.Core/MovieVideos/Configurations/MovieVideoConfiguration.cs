namespace Cut_Roll_Movies.Core.MovieVideos.Configurations;

using Cut_Roll_Movies.Core.MovieVideos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MovieVideoConfiguration : IEntityTypeConfiguration<MovieVideo>
{
    public void Configure(EntityTypeBuilder<MovieVideo> builder)
    {
        builder.ToTable("movie_videos")
            .HasKey(v => v.Id);

        builder.HasOne(v => v.Movie)
            .WithMany(m => m.Videos)
            .HasForeignKey(v => v.MovieId);
    }
}
