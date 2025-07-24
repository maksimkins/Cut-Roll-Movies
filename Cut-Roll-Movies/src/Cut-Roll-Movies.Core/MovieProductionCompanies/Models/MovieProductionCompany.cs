using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.ProductionCompanies.Models;

namespace Cut_Roll_Movies.Core.MovieProductionCompanies.Models;

public class MovieProductionCompany
{
    public Guid MovieId { get; set; }

    public Guid CompanyId { get; set; }

    public required Movie Movie { get; set; }

    public required ProductionCompany Company { get; set; }
}
