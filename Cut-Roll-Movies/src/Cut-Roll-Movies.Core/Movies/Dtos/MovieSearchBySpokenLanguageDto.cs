namespace Cut_Roll_Movies.Core.Movies.Dtos;

public class MovieSearchBySpokenLanguageDto
{
    public string? Iso639_1 { get; set; }
    public string? EnglishName { get; set; }
    public string? Name { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
