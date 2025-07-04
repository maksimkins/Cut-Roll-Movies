using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.Movies.Models;

namespace Cut_Roll_Movies.Core.MovieOriginCountries.Models;

public class MovieOriginCountry
{
    public int MovieId { get; set; }

    public int CountryCode { get; set; }

    public required Movie Movie { get; set; }

    public required Country Country { get; set; }
}