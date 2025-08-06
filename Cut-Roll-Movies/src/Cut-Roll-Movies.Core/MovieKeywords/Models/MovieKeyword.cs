#pragma warning disable CS8618

namespace Cut_Roll_Movies.Core.MovieKeywords.Models;

using System.Text.Json.Serialization;
using Cut_Roll_Movies.Core.Keywords.Models;
using Cut_Roll_Movies.Core.Movies.Models;

public class MovieKeyword
{
    public Guid MovieId { get; set; }
    public Guid KeywordId { get; set; }
    [JsonIgnore]
    public Movie Movie { get; set; }
    public Keyword Keyword { get; set; }
}
