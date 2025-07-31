#pragma warning disable CS8618

namespace Cut_Roll_Movies.Core.MovieProductionCompanies.Models;

using System.Text.Json.Serialization;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.ProductionCompanies.Models;

public class MovieProductionCompany
{
    public Guid MovieId { get; set; }
    public Guid CompanyId { get; set; }
    public Movie Movie { get; set; }
    public ProductionCompany Company { get; set; }
}
