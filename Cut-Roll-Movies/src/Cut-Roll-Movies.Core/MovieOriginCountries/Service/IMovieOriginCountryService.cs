using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.MovieOriginCountries.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

namespace Cut_Roll_Movies.Core.MovieOriginCountries.Service;

public interface IMovieOriginCountryService
{
    Task<Guid> CreateMovieOriginCountryAsync(MovieOriginCountryDto? dto);
    Task<Guid> DeleteMovieOriginCountryAsync(MovieOriginCountryDto? dto);
    Task<bool> DeleteMovieOriginCountryRangeByMovieIdAsync(Guid? movieId);
    Task<IEnumerable<Country>> GetCountriesByMovieIdAsync(Guid? movieId);
    Task<PagedResult<Movie>> GetMoviesByOriginCountryIdAsync(MovieSearchByCountryDto? movieSearchByCountryDto);
    Task<bool> BulkCreateMovieOriginCountryAsync(IEnumerable<MovieOriginCountryDto?>? toCreate);
    Task<bool> BulkDeleteMovieOriginCountryAsync(IEnumerable<MovieOriginCountryDto?>? toDelete);
}
