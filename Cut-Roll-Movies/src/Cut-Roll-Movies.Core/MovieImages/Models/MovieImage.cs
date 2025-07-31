#pragma warning disable CS8618

namespace Cut_Roll_Movies.Core.MovieImages.Models;

using Cut_Roll_Movies.Core.Movies.Models;

public class MovieImage
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public required string Type { get; set; }
    public required string FilePath { get; set; }
    public Movie Movie { get; set; }
}
