namespace Cut_Roll_Movies.Infrastructure.MovieImages.Services;

using Cut_Roll_Movies.Core.MovieImages.Dtos;
using Cut_Roll_Movies.Core.MovieImages.Models;
using Cut_Roll_Movies.Core.MovieImages.Repositories;
using Cut_Roll_Movies.Core.MovieImages.Service;

public class MovieImageService : IMovieImageService
{
    private readonly IMovieImageRepository _movieImageRepository;
    public MovieImageService(IMovieImageRepository movieImageRepository)
    {
        _movieImageRepository = movieImageRepository ?? throw new Exception(nameof(movieImageRepository));
    }
    public Task<bool> BulkMovieImageCreateAsync(IEnumerable<MovieImageCreateDto?>? toCreate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> BulkMovieImageDeleteAsync(IEnumerable<MovieImageDeleteDto?>? toDelete)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> CreateMovieGenreAsync(MovieImageCreateDto? dto)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> DeleteMovieImageByIdAsync(Guid? id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMovieImageRangeByMovieId(Guid? movieId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieImage>> GetMovieImagesByMovieIdAsync(Guid? movieId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieImage>> GetMovieImagesByTypeAsync(Guid? movieId, string? type)
    {
        throw new NotImplementedException();
    }
}
