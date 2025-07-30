namespace Cut_Roll_Movies.Core.MovieGenres.Services;

using Cut_Roll_Movies.Core.Genres.Models;
using Cut_Roll_Movies.Core.MovieGenres.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

public interface IMovieGenreService
{
    Task<Guid?> DeleteMovieGenreAsync(MovieGenreDto dto);
    Task<Guid> CreateMovieGenreAsync(MovieGenreDto dto);
    Task<bool> DeleteMovieGenreRangeByMovieId(Guid movieId);
    Task<IEnumerable<Genre>> GetGenresForMovieAsync(Guid movieId);
    Task<IEnumerable<Movie>> GetMoviesForGenreAsync(MovieSearchByGenreDto searchDto);
    public Task<bool> BulkCreateMovieGenreAsync(IEnumerable<MovieGenreDto> toCreate);
    public Task<bool> BulkDeleteMovieGenreAsync(IEnumerable<MovieGenreDto> toDelete);
}



