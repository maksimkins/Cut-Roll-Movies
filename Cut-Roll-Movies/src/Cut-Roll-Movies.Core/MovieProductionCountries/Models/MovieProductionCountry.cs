using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.Movies.Models;

namespace Cut_Roll_Movies.Core.MovieProductionCountries.Models;

public class MovieProductionCountry
{
    public int MovieId { get; set; }

    public required string CountryCode { get; set; }

    public required Movie Movie { get; set; }

    public required Country Country { get; set; }
}
