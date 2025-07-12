namespace Cut_Roll_Movies.Core.Movies.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Tagline { get; set; }
    public required string Overview { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? Runtime { get; set; }
    public float? VoteAverage { get; set; }
    public int? Budget { get; set; }
    public int? Revenue { get; set; }
    public string? Homepage { get; set; }
    public string? ImdbId { get; set; }
    public string? Rating { get; set; }
    public List<string> Genres { get; set; } = [];
    public List<string> Actors { get; set; } = [];
    public List<string> Directors { get; set; } = [];
    public List<string> Keywords { get; set; } = [];
    public List<string> ProductionCountries { get; set; } = [];
    public List<string> SpokenLanguages { get; set; } = [];
}