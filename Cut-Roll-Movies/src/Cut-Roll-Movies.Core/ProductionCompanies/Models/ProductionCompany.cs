using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.MovieProductionCompanies;

namespace Cut_Roll_Movies.Core.ProductionCompanies.Models;

public class ProductionCompany
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? CountryCode { get; set; }

    public string? LogoPath { get; set; }

    public Country? Country { get; set; }

    public ICollection<MovieProductionCompany> MovieProductionCompanies { get; set; } = [];
}
