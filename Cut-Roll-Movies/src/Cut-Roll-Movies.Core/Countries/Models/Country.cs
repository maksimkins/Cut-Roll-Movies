using Cut_Roll_Movies.Core.ProductionCompanies.Models;

namespace Cut_Roll_Movies.Core.Countries.Models;

public class Country
{
    public required string Iso3166_1 { get; set; }
    public required string Name { get; set; }
    public ICollection<ProductionCompany> Companies { get; set; } = [];
}
