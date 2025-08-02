namespace Cut_Roll_Movies.Core.MovieOriginCountries.Repository;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.MovieOriginCountries.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

public interface IMovieOriginCountryRepository : ICreateAsync<MovieOriginCountryDto, Guid?>, IDeleteAsync<MovieOriginCountryDto, Guid?>,
    IDeleteRangeById<Guid, bool>, IBulkCreateAsync<MovieOriginCountryDto, bool>, IBulkDeleteAsync<MovieOriginCountryDto, bool>
{
    Task<IEnumerable<Country>> GetCountriesByMovieIdAsync(Guid movieId);
    Task<PagedResult<Movie>> GetMoviesByOriginCountryIdAsync(MovieSearchByCountryDto movieSearchByCountryDto);
    Task<bool> ExistsAsync(MovieOriginCountryDto dto);
}
