namespace Cut_Roll_Movies.Core.Movies.Service;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

public interface IMovieService
{
    Task<PagedResult<Movie>> SearchMovieAsync(MovieSearchRequest? movieSearchRequest);
    Task<Movie?> GetMovieByIdAsync(Guid? id);
    Task<Guid> UpdateMovieAsync(MovieUpdateDto? dto);
    Task<Guid> DeleteMovieByIdAsync(Guid? id);
    Task<Guid> CreateMovieAsync(MovieCreateDto? dto);
    Task<int> CountMoviesAsync();
}

