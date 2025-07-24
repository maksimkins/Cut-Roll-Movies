using Cut_Roll_Movies.Core.Movies.Models;

namespace Cut_Roll_Movies.Core.MovieImages.Models;

public class MovieImage
{
    public Guid Id { get; set; }

    public Guid MovieId { get; set; }

    public required string Type { get; set; }
    
    public required string FilePath { get; set; }

    public required Movie Movie { get; set; }
}
