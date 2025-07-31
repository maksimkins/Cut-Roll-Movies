#pragma warning disable CS8618

namespace Cut_Roll_Movies.Core.MovieProductionCountries.Models;

using System.Text.Json.Serialization;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.Movies.Models;

public class MovieProductionCountry
{
    public Guid MovieId { get; set; }

    public required string CountryCode { get; set; }
    public Movie Movie { get; set; }
    public Country Country { get; set; }
}
