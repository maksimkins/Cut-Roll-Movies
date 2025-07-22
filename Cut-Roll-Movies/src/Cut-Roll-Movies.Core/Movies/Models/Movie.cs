using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Crews.Models;
using Cut_Roll_Movies.Core.MovieGenres.Models;
using Cut_Roll_Movies.Core.MovieImages.Models;
using Cut_Roll_Movies.Core.MovieKeywords.Models;
using Cut_Roll_Movies.Core.MovieOriginCountries.Models;
using Cut_Roll_Movies.Core.MovieProductionCompanies.Models;
using Cut_Roll_Movies.Core.MovieProductionCountries.Models;
using Cut_Roll_Movies.Core.MovieSpokenLanguages.Models;
using Cut_Roll_Movies.Core.MovieVideos.Models;

namespace Cut_Roll_Movies.Core.Movies.Models;

public class Movie
{
    public int Id { get; set; }
    
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

    public ICollection<MovieGenre> MovieGenres { get; set; } = [];

    public ICollection<Cast> Cast { get; set; } = [];

    public ICollection<Crew> Crew { get; set; } = [];

    public ICollection<MovieProductionCompany> ProductionCompanies { get; set; } = [];

    public ICollection<MovieProductionCountry> ProductionCountries { get; set; } = [];

    public ICollection<MovieSpokenLanguage> SpokenLanguages { get; set; } = [];

    public ICollection<MovieVideo> Videos { get; set; } = [];

    public ICollection<MovieKeyword> Keywords { get; set; } = [];

    public ICollection<MovieOriginCountry> OriginCountries { get; set; } = [];

    public ICollection<MovieImage> Images { get; set; } = [];
}
