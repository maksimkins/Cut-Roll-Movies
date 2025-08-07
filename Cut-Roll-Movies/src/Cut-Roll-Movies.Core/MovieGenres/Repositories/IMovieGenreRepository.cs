namespace Cut_Roll_Movies.Core.MovieGenres.Repositories;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Genres.Models;
using Cut_Roll_Movies.Core.MovieGenres.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;

public interface IMovieGenreRepository : ICreateAsync<MovieGenreDto, Guid?>, IDeleteAsync<MovieGenreDto, Guid?>, IDeleteRangeById<Guid, bool>,
    IBulkCreateAsync<MovieGenreDto, bool>, IBulkDeleteAsync<MovieGenreDto, bool>
{
    Task<IEnumerable<Genre>> GetGenresByMovieIdAsync(Guid movieId);
    Task<PagedResult<MovieSimplifiedDto>> GetMoviesByGenreIdAsync(MovieSearchByGenreDto searchDto);
    Task<bool> ExistsAsync(MovieGenreDto dto);
}
