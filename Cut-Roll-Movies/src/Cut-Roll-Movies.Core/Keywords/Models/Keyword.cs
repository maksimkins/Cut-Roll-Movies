using System.Text.Json.Serialization;
using Cut_Roll_Movies.Core.MovieKeywords.Models;

namespace Cut_Roll_Movies.Core.Keywords.Models;

public class Keyword
{
    public Guid Id { get; set; }

    public required string Name { get; set; }
    [JsonIgnore]
    
    public ICollection<MovieKeyword> MovieKeywords { get; set; } = [];
}
