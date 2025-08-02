namespace Cut_Roll_Movies.Core.MovieProductionCompanies.Repositories;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieProductionCompanies.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.ProductionCompanies.Models;

public interface IMovieProductionCompanyRepository : ICreateAsync<MovieProductionCompanyDto, Guid?>, IDeleteAsync<MovieProductionCompanyDto, Guid?>,
IDeleteRangeById<Guid, bool>, IBulkCreateAsync<MovieProductionCompanyDto, bool>, IBulkDeleteAsync<MovieProductionCompanyDto, bool>
{
    Task<IEnumerable<ProductionCompany>> GetCompaniesByMovieIdAsync(Guid movieId);
    Task<PagedResult<Movie>> GetMoviesByCompanyIdAsync(MovieSearchByCompanyDto movieSearchByCompanyDto);
    Task<bool> ExistsAsync(MovieProductionCompanyDto dto);
}
