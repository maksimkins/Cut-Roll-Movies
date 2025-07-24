namespace Cut_Roll_Movies.Core.MovieProductionCountries.Dtos;

public class MovieProductionCountryDto
{
    public Guid MovieId { get; set; }

    public required string CountryCode { get; set; }

}
