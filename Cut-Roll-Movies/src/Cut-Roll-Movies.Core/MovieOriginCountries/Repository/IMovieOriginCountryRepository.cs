namespace Cut_Roll_Movies.Core.MovieOriginCountries.Repository;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.MovieOriginCountries.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

public interface IMovieOriginCountryRepository : ICreateAsync<Guid, MovieOriginCountryDto>, IDeleteAsync<Guid, MovieOriginCountryDto>, IDeleteRangeById<bool, Guid>
{
    Task<IEnumerable<Country>> GetCountriesByMovieIdAsync(Guid movieId);
    Task<IEnumerable<Movie>> GetMoviesByOriginCountryIdAsync(MovieSearchByCountryDto movieSearchByCountryDto);
    Task<bool> ExistsAsync(Guid movieId, Guid countryId);
}
