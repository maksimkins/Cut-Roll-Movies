using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Crews.Dtos;
using Cut_Roll_Movies.Core.MovieImages.Dtos;
using Cut_Roll_Movies.Core.MovieVideos.Dtos;

namespace Cut_Roll_Movies.Core.Movies.Dtos;

public class MovieCreateDto
{
    public required string Title { get; set; }
    public string? Tagline { get; set; }
    public required string Overview { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? Runtime { get; set; }
    public float? VoteAverage { get; set; }
    public long? Budget { get; set; }
    public long? Revenue { get; set; }
    public string? Homepage { get; set; }
    public string? ImdbId { get; set; }
    public string? Rating { get; set; }

    public List<Guid> GenreIds { get; set; } = [];
    public List<Guid> KeywordIds { get; set; } = [];
    public List<Guid> ProductionCompanyIds { get; set; } = [];
    public List<Guid> ProductionCountryIds { get; set; } = [];
    public List<string> OriginCountryCodes { get; set; } = [];
    public List<string> SpokenLanguageCodes { get; set; } = [];
    public List<MovieImageCreateDto> Images { get; set; } = [];
    public List<MovieVideoCreateDto> Videos { get; set; } = [];

    public List<CastCreateDto> Cast { get; set; } = [];
    public List<CrewCreateDto> Crew { get; set; } = [];
}
