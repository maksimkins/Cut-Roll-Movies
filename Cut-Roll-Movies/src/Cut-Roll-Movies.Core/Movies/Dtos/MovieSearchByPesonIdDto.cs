namespace Cut_Roll_Movies.Core.Movies.Dtos;

public class MovieSearchByPesonIdDto
{
    public Guid PersonId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
