using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.SpokenLanguages.Models;

namespace Cut_Roll_Movies.Core.MovieSpokenLanguages.Models;

public class MovieSpokenLanguage
{
    public Guid MovieId { get; set; }

    public required string LanguageCode { get; set; }

    public required Movie Movie { get; set; }

    public required SpokenLanguage Language { get; set; }
}
