namespace Cut_Roll_Movies.Core.MovieProductionCountries.Repostiroes;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.MovieProductionCountries.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;


public interface IMovieProductionCountryRepository : ICreateAsync<Guid, MovieProductionCountryDto>, IDeleteAsync<Guid, MovieProductionCountryDto>,
IDeleteRangeById<bool, Guid>
{
    Task<bool> ExistsAsync(Guid movieId, Guid countryId);
    Task<IEnumerable<Movie>> GetMoviesByCountryIdAsync(MovieSearchByCountryDto movieSearchByCountryDto);
    Task<IEnumerable<Country>> GetCountriesByMovieIdAsync(Guid movieId);
}
