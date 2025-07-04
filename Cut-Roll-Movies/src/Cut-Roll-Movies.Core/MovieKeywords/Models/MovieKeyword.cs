using Cut_Roll_Movies.Core.Keywords.Models;
using Cut_Roll_Movies.Core.Movies.Models;

namespace Cut_Roll_Movies.Core.MovieKeywords.Models;

public class MovieKeyword
{
    public int MovieId { get; set; }

    public int KeywordId { get; set; }

    public required Movie Movie { get; set; }

    public required Keyword Keyword { get; set; }
}
