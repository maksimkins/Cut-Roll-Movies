namespace Cut_Roll_Movies.Core.MovieImages.Dtos;

public class MovieImageCreateDto
{
    public int MovieId { get; set; }

    public required string Type { get; set; }
    
    public required string FilePath { get; set; }
}
