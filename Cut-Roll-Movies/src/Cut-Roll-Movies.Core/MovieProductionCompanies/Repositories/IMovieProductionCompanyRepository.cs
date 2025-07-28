namespace Cut_Roll_Movies.Core.MovieProductionCompanies.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieProductionCompanies.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.ProductionCompanies.Models;

public interface IMovieProductionCompanyRepository : ICreateAsync<int, MovieProductionCompanyDto>, IDeleteAsync<int, MovieProductionCompanyDto>,
IDeleteRangeById<bool, int>
{
    Task<IEnumerable<ProductionCompany>> GetCompaniesByMovieIdAsync(Guid movieId);
    Task<IEnumerable<Movie>> GetMoviesByCompanyIdAsync(MovieSearchByCompanyDto movieSearchByCompanyDto);
}
