using Cut_Roll_Movies.Core.Movies.Models;

namespace Cut_Roll_Movies.Core.MovieVideos.Models;

public class MovieVideo
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public required string Name { get; set; }

    public string? Type { get; set; }

    public required string Site { get; set; }

    public required string Key { get; set; }

    public required Movie Movie { get; set; }
}
