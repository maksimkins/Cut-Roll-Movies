namespace Cut_Roll_Movies.Core.MovieProductionCountries.Service;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.MovieProductionCountries.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

public interface IMovieProductionCountryService
{
    Task<Guid> CreateMovieProductionCountryAsync(MovieProductionCountryDto? dto);
    Task<Guid> DeleteMovieProductionCountryAsyncMovieProductionCountryAsync(MovieProductionCountryDto? dto);
    Task<bool> DeleteMovieProductionCountryRangeByMovieId(Guid? movieId);
    Task<PagedResult<Movie>> GetMoviesByCountryIdAsync(MovieSearchByCountryDto? movieSearchByCountryDto);
    Task<IEnumerable<Country>> GetCountriesByMovieIdAsync(Guid? movieId);
    Task<bool> BulkCreateMovieProductionCountryAsync(IEnumerable<MovieProductionCountryDto>? toCreate);
    Task<bool> BulkDeleteMovieProductionCountryAsync(IEnumerable<MovieProductionCountryDto>? toDelete);
}


