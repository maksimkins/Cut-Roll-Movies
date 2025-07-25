using Cut_Roll_Movies.Core.MovieSpokenLanguages.Models;

namespace Cut_Roll_Movies.Core.SpokenLanguages.Models;

public class SpokenLanguage
{
    public required string Iso639_1 { get; set; }

    public required string EnglishName { get; set; }

    public string? Name { get; set; }

    public ICollection<MovieSpokenLanguage> MovieSpokenLanguages { get; set; } = [];
}