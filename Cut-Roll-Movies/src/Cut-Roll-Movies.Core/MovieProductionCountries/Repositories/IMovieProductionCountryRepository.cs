namespace Cut_Roll_Movies.Core.MovieProductionCountries.Repositories;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.MovieProductionCountries.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;


public interface IMovieProductionCountryRepository : ICreateAsync<MovieProductionCountryDto, Guid?>, IDeleteAsync<MovieProductionCountryDto, Guid?>,
IDeleteRangeById<Guid, bool>, IBulkCreateAsync<MovieProductionCountryDto, bool>, IBulkDeleteAsync<MovieProductionCountryDto, bool>
{
    Task<bool> ExistsAsync(MovieProductionCountryDto dto);
    Task<PagedResult<MovieSimplifiedDto>> GetMoviesByCountryIdAsync(MovieSearchByCountryDto movieSearchByCountryDto);
    Task<IEnumerable<Country>> GetCountriesByMovieIdAsync(Guid movieId);
}
