#pragma warning disable CS8618

using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.SpokenLanguages.Models;

namespace Cut_Roll_Movies.Core.MovieSpokenLanguages.Models;

public class MovieSpokenLanguage
{
    public Guid MovieId { get; set; }

    public required string LanguageCode { get; set; }

    public Movie Movie { get; set; }

    public SpokenLanguage Language { get; set; }
}
