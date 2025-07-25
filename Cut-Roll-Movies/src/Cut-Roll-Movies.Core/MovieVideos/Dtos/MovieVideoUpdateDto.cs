namespace Cut_Roll_Movies.Core.MovieVideos.Dtos;

public class MovieVideoUpdateDto
{
    public required string Name { get; set; }

    public string? Type { get; set; }

    public required string Site { get; set; }

    public required string Key { get; set; }

}
