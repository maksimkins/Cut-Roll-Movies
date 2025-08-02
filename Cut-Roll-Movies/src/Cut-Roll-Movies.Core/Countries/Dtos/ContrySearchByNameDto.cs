namespace Cut_Roll_Movies.Core.Countries.Dtos;

public class ContrySearchByNameDto
{
    public required string Name { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10; 
}
