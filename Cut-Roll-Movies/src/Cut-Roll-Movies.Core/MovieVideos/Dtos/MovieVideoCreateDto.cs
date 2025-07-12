namespace Cut_Roll_Movies.Core.MovieVideos.Dtos;

public class MovieVideoCreateDto
{
    public required string Name { get; set; }

    public string? Type { get; set; }

    public required string Site { get; set; }
}
