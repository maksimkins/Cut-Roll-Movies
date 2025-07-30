namespace Cut_Roll_Movies.Core.MovieImages.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieImages.Dtos;
using Cut_Roll_Movies.Core.MovieImages.Models;

public interface IMovieImageRepository : ICreateAsync<MovieImageCreateDto, Guid?>, IDeleteByIdAsync<Guid, Guid?>, IDeleteRangeById<Guid, bool>, 
IBulkCreateAsync<MovieImageCreateDto, bool>, IBulkDeleteAsync<MovieImageDeleteDto, bool>
{
    Task<IEnumerable<MovieImage>> GetImagesByMovieIdAsync(Guid movieId);
    Task<IEnumerable<MovieImage>> GetImagesByTypeAsync(Guid movieId, string type);
}
