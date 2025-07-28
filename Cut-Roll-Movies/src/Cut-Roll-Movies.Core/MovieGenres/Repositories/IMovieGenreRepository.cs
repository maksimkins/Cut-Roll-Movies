namespace Cut_Roll_Movies.Core.MovieGenres.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Genres.Models;
using Cut_Roll_Movies.Core.MovieGenres.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

public interface IMovieGenreRepository : ICreateAsync<Guid, MovieGenreDto>, IDeleteAsync<Guid, MovieGenreDto>, IDeleteRangeById<bool, Guid>
{
    Task<IEnumerable<Genre>> GetGenresForMovieAsync(Guid movieId);
    Task<IEnumerable<Movie>> GetMoviesForGenreAsync(MovieSearchByGenreDto searchDto);
}
